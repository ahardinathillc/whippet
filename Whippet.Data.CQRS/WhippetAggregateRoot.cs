using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NodaTime;
using Athi.Whippet.Data.CQRS.Extensions;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Represents objects the client code loads from the repository. This class must be inherited.
    /// </summary>
    public abstract class WhippetAggregateRoot : WhippetEntity
    {
        private Queue<WhippetDomainEvent> _uncommitted;
        private IList<WhippetAggregateEntity> _entities;

        /// <summary>
        /// Gets the last event sequence number. This property is read-only.
        /// </summary>
        public int LastEventSequence
        { get; protected set; }

        /// <summary>
        /// Gets the unique ID of the entity. This property is read-only.
        /// </summary>
        public new Guid ID
        {
            get
            {
                return base.ID;
            }
            protected internal set
            {
                base.ID = value;
            }
        }

        /// <summary>
        /// Gets all uncommitted events currently associated with the current entity. This property is read-only.
        /// </summary>
        public IReadOnlyList<WhippetDomainEvent> UncommittedEvents
        {
            get
            {
                return new List<WhippetDomainEvent>(EventQueue).AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the internal uncommitted event queue. This property is read-only.
        /// </summary>
        private Queue<WhippetDomainEvent> EventQueue
        {
            get
            {
                if (_uncommitted == null)
                {
                    _uncommitted = new Queue<WhippetDomainEvent>();
                }

                return _uncommitted;
            }
        }

        /// <summary>
        /// Gets an <see cref="IList{T}"/> of all <see cref="WhippetAggregateEntity"/> objects assigned to the aggregate root. This property is read-only.
        /// </summary>
        private IList<WhippetAggregateEntity> Entities
        {
            get
            {
                if(_entities == null)
                {
                    _entities = new List<WhippetAggregateEntity>();
                }

                return _entities;
            }
        }

        /// <summary>
        /// Provides a custom implementation to invoke when a <see cref="WhippetDomainEvent"/> instance is applied. If the invocation fails and <see cref="UseDefaultEventHandlerOnFailure"/> is set to <see langword="true"/>, the inner exception will not be raised unless another exception occurs afterwards. This property is read-only.
        /// </summary>
        protected Action<WhippetDomainEvent> ApplyEventDelegate
        { get; private set; }

        /// <summary>
        /// Specifies whether to use the default internal implementaiton when a <see cref="WhippetDomainEvent"/> instance is applied and the custom invocation fails.
        /// </summary>
        protected bool UseDefaultEventHandlerOnFailure
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAggregateRoot"/> class with no arguments.
        /// </summary>
        protected WhippetAggregateRoot()
            : this(null, false)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAggregateRoot"/> class with the specified <see cref="Guid"/>.
        /// </summary>
        /// <param name="id"><see cref="Guid"/> value that represents the unique identifier of the entity.</param>
        protected WhippetAggregateRoot(Guid id)
            : this(id, null, false)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAggregateRoot"/> class.
        /// </summary>
        /// <param name="applyEventDelegate">Custom implementation to invoke when a <see cref="WhippetDomainEvent"/> instance is applied.</param>
        /// <param name="useDefaultOnFailure">If <see langword="true"/>, will default to the internal implementation when a <see cref="WhippetDomainEvent"/> instance is supplied and the custom invocation fails.</param>
        protected WhippetAggregateRoot(Action<WhippetDomainEvent> applyEventDelegate, bool useDefaultOnFailure)
            : base()
        {
            ApplyEventDelegate = applyEventDelegate;
            UseDefaultEventHandlerOnFailure = useDefaultOnFailure;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAggregateRoot"/> class.
        /// </summary>
        /// <param name="id"><see cref="Guid"/> value that represents the unique identifier of the entity.</param>
        /// <param name="applyEventDelegate">Custom implementation to invoke when a <see cref="WhippetDomainEvent"/> instance is applied.</param>
        /// <param name="useDefaultOnFailure">If <see langword="true"/>, will default to the internal implementation when a <see cref="WhippetDomainEvent"/> instance is supplied and the custom invocation fails.</param>
        protected WhippetAggregateRoot(Guid id, Action<WhippetDomainEvent> applyEventDelegate, bool useDefaultOnFailure)
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

            foreach(WhippetAggregateEntity wea in Entities)
            {
                wea.CommitEvents();
            }
        }

        /// <summary>
        /// Registers the specified <see cref="WhippetAggregateEntity"/> object.
        /// </summary>
        /// <param name="entity"><see cref="WhippetAggregateEntity"/> object to register.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void RegisterEntity(WhippetAggregateEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            else
            {
                entity.AggregateRoot = this;
                Entities.Add(entity);
            }
        }

        /// <summary>
        /// Applies the specified <see cref="WhippetDomainEvent"/> to the current instance.
        /// </summary>
        /// <param name="domainEvent"><see cref="WhippetDomainEvent"/> object to apply.</param>
        /// <exception cref="ArgumentNullException" />
        public virtual void Apply(WhippetDomainEvent domainEvent)
        {
            if (domainEvent == null)
            {
                throw new ArgumentNullException(nameof(domainEvent));
            }
            else
            {
                domainEvent.Sequence = ++LastEventSequence;
                
                ApplyEventToInternalState(domainEvent);

                domainEvent.AggregateRootId = ID;
                domainEvent.EventDate = Instant.FromDateTimeUtc(DateTime.UtcNow);

                WhippetDomainEventModifier.ApplyModification(domainEvent);

                EventQueue.Enqueue(domainEvent);
            }
        }

        /// <summary>
        /// Applies the specified collection of event(s) that have already taken place without populating the event queue.
        /// </summary>
        /// <param name="domainEvents"><see cref="IEnumerable{T}"/> collection of <see cref="WhippetDomainEvent"/> objects.</param>
        /// <exception cref="TargetInvocationException" />
        public virtual void ApplyHistorical(IEnumerable<WhippetDomainEvent> domainEvents)
        {
            if(domainEvents != null && domainEvents.Any())
            {
                LastEventSequence = domainEvents.Max(de => de.Sequence);

                foreach(WhippetDomainEvent waede in domainEvents.OrderBy(de => de.Sequence))
                {
                    ApplyEventToInternalState(waede);
                }
            }
        }

        /// <summary>
        /// Applies the specified <see cref="WhippetDomainEvent"/> via its corresponding event handler.
        /// </summary>
        /// <param name="domainEvent"><see cref="WhippetDomainEvent"/> event to apply.</param>
        /// <exception cref="TargetInvocationException"></exception>
        private void ApplyEventToInternalState(WhippetDomainEvent domainEvent)
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
