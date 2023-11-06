using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Athi.Whippet.Data.CQRS.Extensions;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Base class for all <see cref="WhippetEntity"/> objects that have a <see cref="WhippetAggregateRoot"/>. This class must be inherited.
    /// </summary>
    public abstract class WhippetAggregateEntity : WhippetEntity, IWhippetEntity
    {
        private Queue<WhippetAggregateEntityDomainEvent> _uncommitted;

        /// <summary>
        /// Gets or sets the aggregate root for the entity.
        /// </summary>
        public WhippetAggregateRoot AggregateRoot
        { get; set; }

        /// <summary>
        /// Gets the unique ID of the entity. This property is read-only.
        /// </summary>
        public new Guid ID
        { 
            get
            {
                return base.ID;
            }
            protected set
            {
                base.ID = value;
            }
        }

        /// <summary>
        /// Gets all uncommitted events currently associated with the current entity. This property is read-only.
        /// </summary>
        public IReadOnlyList<WhippetAggregateEntityDomainEvent> UncommittedEvents
        {
            get
            {
                return new List<WhippetAggregateEntityDomainEvent>(EventQueue).AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the internal uncommitted event queue. This property is read-only.
        /// </summary>
        private Queue<WhippetAggregateEntityDomainEvent> EventQueue
        {
            get
            {
                if (_uncommitted == null)
                {
                    _uncommitted = new Queue<WhippetAggregateEntityDomainEvent>();
                }

                return _uncommitted;
            }
        }

        /// <summary>
        /// Provides a custom implementation to invoke when a <see cref="WhippetAggregateEntityDomainEvent"/> instance is applied. If the invocation fails and <see cref="UseDefaultEventHandlerOnFailure"/> is set to <see langword="true"/>, the inner exception will not be raised unless another exception occurs afterwards. This property is read-only.
        /// </summary>
        protected Action<WhippetAggregateEntityDomainEvent> ApplyEventDelegate
        { get; private set; }

        /// <summary>
        /// Specifies whether to use the default internal implementaiton when a <see cref="WhippetAggregateEntityDomainEvent"/> instance is applied and the custom invocation fails.
        /// </summary>
        protected bool UseDefaultEventHandlerOnFailure
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAggregateEntity"/> class with no arguments.
        /// </summary>
        protected WhippetAggregateEntity()
            : this(null, false)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAggregateEntity"/> class with the specified <see cref="Guid"/>.
        /// </summary>
        /// <param name="id"><see cref="Guid"/> value that represents the unique identifier of the entity.</param>
        protected WhippetAggregateEntity(Guid id)
            : this(id, null, false)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAggregateEntity"/> class.
        /// </summary>
        /// <param name="applyEventDelegate">Custom implementation to invoke when a <see cref="WhippetAggregateEntityDomainEvent"/> instance is applied.</param>
        /// <param name="useDefaultOnFailure">If <see langword="true"/>, will default to the internal implementation when a <see cref="WhippetAggregateEntityDomainEvent"/> instance is supplied and the custom invocation fails.</param>
        protected WhippetAggregateEntity(Action<WhippetAggregateEntityDomainEvent> applyEventDelegate, bool useDefaultOnFailure)
            : base()
        {
            ApplyEventDelegate = applyEventDelegate;
            UseDefaultEventHandlerOnFailure = useDefaultOnFailure;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAggregateEntity"/> class.
        /// </summary>
        /// <param name="id"><see cref="Guid"/> value that represents the unique identifier of the entity.</param>
        /// <param name="applyEventDelegate">Custom implementation to invoke when a <see cref="WhippetAggregateEntityDomainEvent"/> instance is applied.</param>
        /// <param name="useDefaultOnFailure">If <see langword="true"/>, will default to the internal implementation when a <see cref="WhippetAggregateEntityDomainEvent"/> instance is supplied and the custom invocation fails.</param>
        protected WhippetAggregateEntity(Guid id, Action<WhippetAggregateEntityDomainEvent> applyEventDelegate, bool useDefaultOnFailure)
            : base(id)
        {
            ApplyEventDelegate = applyEventDelegate;
            UseDefaultEventHandlerOnFailure = useDefaultOnFailure;
        }

        /// <summary>
        /// Removes all uncommitted events from the <see cref="UncommittedEvents"/> queue.
        /// </summary>
        public void CommitEvents()
        {
            EventQueue.Clear();
        }

        /// <summary>
        /// Applies the specified <see cref="WhippetAggregateEntityDomainEvent"/> to the current instance.
        /// </summary>
        /// <param name="domainEvent"><see cref="WhippetAggregateEntityDomainEvent"/> object to apply.</param>
        /// <exception cref="ArgumentNullException" />
        public virtual void Apply(WhippetAggregateEntityDomainEvent domainEvent)
        {
            if(domainEvent == null)
            {
                throw new ArgumentNullException(nameof(domainEvent));
            }
            else
            {
                domainEvent.EntityID = ID;

                AggregateRoot.Apply(domainEvent);
                EventQueue.Enqueue(domainEvent);
                ApplyEventToInternalState(domainEvent);
            }
        }

        /// <summary>
        /// Applies the specified collection of event(s) that have already taken place without populating the event queue.
        /// </summary>
        /// <param name="domainEvents"><see cref="IEnumerable{T}"/> collection of <see cref="WhippetAggregateEntityDomainEvent"/> objects.</param>
        /// <exception cref="TargetInvocationException" />
        public virtual void ApplyHistorical(IEnumerable<WhippetAggregateEntityDomainEvent> domainEvents)
        {
            if(domainEvents != null && domainEvents.Any())
            {
                foreach(WhippetAggregateEntityDomainEvent waede in domainEvents)
                {
                    if (waede != null)
                    {
                        ApplyEventToInternalState(waede);
                    }
                }
            }
        }

        /// <summary>
        /// Applies the specified <see cref="WhippetAggregateEntityDomainEvent"/> via its corresponding event handler.
        /// </summary>
        /// <param name="domainEvent"><see cref="WhippetAggregateEntityDomainEvent"/> event to apply.</param>
        /// <exception cref="TargetInvocationException"></exception>
        private void ApplyEventToInternalState(WhippetAggregateEntityDomainEvent domainEvent)
        {
            if (domainEvent == null)
            {
                throw new ArgumentNullException(nameof(domainEvent));
            }
            else
            {
                Exception trappedException = null;

                MethodInfo methodInfo = null;
                ParameterInfo[] parameters = null;

                if (ApplyEventDelegate != null)
                {
                    try
                    {
                        ApplyEventDelegate(domainEvent);
                    }
                    catch (Exception e)
                    {
                        if (!UseDefaultEventHandlerOnFailure)
                        {
                            throw new TargetInvocationException(e);
                        }
                        else
                        {
                            trappedException = e;
                        }
                    }
                }

                if (ApplyEventDelegate == null || (UseDefaultEventHandlerOnFailure && (trappedException != null)))
                {
                    try
                    {
                        methodInfo = GetType().GetMethod(domainEvent.GetEventHandlerMethodName(), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new[] { domainEvent.GetType() }, null);

                        if (methodInfo != null)
                        {
                            // ensure that the parameters match before invocation

                            parameters = methodInfo.GetParameters();

                            if (parameters != null && (parameters.Length == 1 && parameters[0].ParameterType == domainEvent.GetType()))
                            {
                                methodInfo.Invoke(this, new[] { domainEvent });
                            }
                        }
                    }
                    catch (Exception miException)
                    {
                        throw new TargetInvocationException(miException.ToString(), trappedException);
                    }
                }
            }
        }
    }
}
