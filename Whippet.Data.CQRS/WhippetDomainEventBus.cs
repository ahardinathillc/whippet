using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Athi.Whippet.Collections.Extensions;
using Athi.Whippet.Localization;
using Athi.Whippet.EventManagement;
using Athi.Whippet.Data.CQRS.ResourceFiles;
using Athi.Whippet.Services;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Local event bus dispatcher for <see cref="WhippetDomainEvent"/> instances.
    /// </summary>
    public class WhippetDomainEventBus : IWhippetDomainEventBus, IWhippetEventBus
    {
        private IDictionary<Type, EventHandlerInvoker> _eventHandlers;

        /// <summary>
        /// Gets the <see cref="IWhippetServiceContext"/> used for instantiating event handlers. This property is read-only.
        /// </summary>
        protected IWhippetServiceContext EventHandlerServiceLocator
        { get; private set; }

        /// <summary>
        /// Gets or sets the <see cref="IDictionary{TKey, TValue}"/> collection of all domain event types and their associated invokers.
        /// </summary>
        private IDictionary<Type, EventHandlerInvoker> EventHandlerInvokers
        {
            get
            {
                if(_eventHandlers == null)
                {
                    _eventHandlers = new Dictionary<Type, EventHandlerInvoker>();
                }

                return _eventHandlers;
            }
            set
            {
                _eventHandlers = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDomainEventBus"/> class with no arguments.
        /// </summary>
        private WhippetDomainEventBus()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDomainEventBus"/> class with the specified parameters.
        /// </summary>
        /// <param name="whippetEventHandlerTypes">Event handler types that will be published on the bus.</param>
        /// <param name="eventHandlerServiceLocator"><see cref="IWhippetServiceContext"/> service locator that is used for constructing the event handler instances.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetDomainEventBus(IEnumerable<Type> whippetEventHandlerTypes, IWhippetServiceContext eventHandlerServiceLocator)
            : this()
        { 
            if(whippetEventHandlerTypes == null)
            {
                throw new ArgumentNullException(nameof(whippetEventHandlerTypes));
            }
            else if(eventHandlerServiceLocator == null)
            {
                throw new ArgumentNullException(nameof(eventHandlerServiceLocator));
            }
            else
            {
                IEnumerable<Type> domainEventTypes = null;
                EventHandlerInvoker invoker = null;

                EventHandlerServiceLocator = eventHandlerServiceLocator;

                foreach(Type eventHandlerType in whippetEventHandlerTypes)
                {
                    domainEventTypes =
                        from interfaceType in eventHandlerType.GetInterfaces()
                        where interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof(IWhippetDomainEventHandler<>)
                        select interfaceType.GetGenericArguments()[0];

                    foreach(Type domainEventType in domainEventTypes)
                    {
                        if(!EventHandlerInvokers.TryGetValue(domainEventType, out invoker))
                        {
                            invoker = new EventHandlerInvoker(eventHandlerServiceLocator, domainEventType);
                        }

                        invoker.AddEventHandlerType(eventHandlerType);
                        EventHandlerInvokers[domainEventType] = invoker;
                    }
                }
            }
        }

        /// <summary>
        /// Publishes an event to the event bus.
        /// </summary>
        /// <param name="whippetEvent"><see cref="WhippetDomainEvent"/> object to publish.</param>
        /// <exception cref="ArgumentNullException" />
        public virtual void PublishEvent(WhippetDomainEvent whippetEvent)
        {
            if (whippetEvent == null)
            {
                throw new ArgumentNullException(nameof(whippetEvent));
            }
            else
            {
                IEnumerable<EventHandlerInvoker> invokers = (from entry in EventHandlerInvokers where entry.Key.IsAssignableFrom(whippetEvent.GetType()) select entry.Value);

                if (invokers.Any())
                {
                    invokers.ForEach(i => i.Publish(whippetEvent));
                }
            }
        }

        /// <summary>
        /// Publishes a collection of events to the event bus.
        /// </summary>
        /// <param name="whippetEvents"><see cref="IEnumerable{T}"/> colleciton of <see cref="WhippetDomainEvent"/> objects to publish.</param>
        /// <exception cref="ArgumentNullException" />
        public virtual void PublishEvents(IEnumerable<WhippetDomainEvent> whippetEvents)
        {
            if(whippetEvents == null)
            {
                throw new ArgumentNullException(nameof(whippetEvents));
            }
            else
            {
                whippetEvents.ForEach(e => PublishEvent(e));
            }
        }

        /// <summary>
        /// Publishes an event to the event bus.
        /// </summary>
        /// <param name="whippetEvent"><see cref="WhippetEvent"/> object to publish.</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        void IWhippetEventBus.PublishEvent(WhippetEvent whippetEvent)
        {
            if(whippetEvent == null)
            {
                throw new ArgumentNullException(nameof(whippetEvent));
            }
            else if(!(whippetEvent is WhippetDomainEvent))
            {
                throw new ArgumentException(LocalizedStringResourceLoader.GetException<WhippetDomainEventBus>(ExceptionResourceIndex.InvalidEventType, new object[] { typeof(WhippetDomainEvent).FullName }), nameof(whippetEvent));
            }
            else
            {
                PublishEvent((WhippetDomainEvent)(whippetEvent));
            }
        }

        /// <summary>
        /// Publishes a collection of events to the event bus.
        /// </summary>
        /// <param name="whippetEvents"><see cref="IEnumerable{T}"/> colleciton of <see cref="WhippetEvent"/> objects to publish.</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        void IWhippetEventBus.PublishEvents(IEnumerable<WhippetEvent> whippetEvents)
        {
            if(whippetEvents == null)
            {
                throw new ArgumentNullException(nameof(whippetEvents));
            }
            else if((from we in whippetEvents where !(we is WhippetDomainEvent) select we).Any())
            {
                throw new ArgumentException(LocalizedStringResourceLoader.GetException<WhippetDomainEventBus>(ExceptionResourceIndex.InvalidEventType, new object[] { typeof(WhippetDomainEvent).FullName }), nameof(whippetEvents));
            }
            else
            {
                List<WhippetDomainEvent> events = new List<WhippetDomainEvent>(whippetEvents.Count());

                foreach(WhippetEvent we in whippetEvents)
                {
                    events.Add((WhippetDomainEvent)(we));
                }

                PublishEvents(events);
            }
        }

        /// <summary>
        /// Internal class for invoking <see cref="WhippetDomainEvent"/> objects. This class cannot be inherited.
        /// </summary>
        private sealed class EventHandlerInvoker
        {
            private List<Type> _eventTypes;

            /// <summary>
            /// Gets or sets the internal <see cref="IWhippetServiceContext"/> used to locate event handlers.
            /// </summary>
            private IWhippetServiceContext EventHandlerServiceLocator
            { get; set; }

            /// <summary>
            /// Gets or sets the domain event type.
            /// </summary>
            private Type DomainEventType
            { get; set; }

            /// <summary>
            /// Gets the internal <see cref="List{T}"/> of event handler types. This property is read-only.
            /// </summary>
            private List<Type> EventHandlerTypes
            { 
                get
                {
                    if(_eventTypes == null)
                    {
                        _eventTypes = new List<Type>();
                    }

                    return _eventTypes;
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="EventHandlerInvoker"/> class with no arguments.
            /// </summary>
            private EventHandlerInvoker()
            { }

            /// <summary>
            /// Initializes a new instance of the <see cref="EventHandlerInvoker"/> class with the specified parameters.
            /// </summary>
            /// <param name="eventHandlerServiceLocator"><see cref="IWhippetServiceContext"/> service locator.</param>
            /// <param name="domainEventType">Type of domain events to handle.</param>
            /// <exception cref="ArgumentNullException"></exception>
            public EventHandlerInvoker(IWhippetServiceContext eventHandlerServiceLocator, Type domainEventType)
                : this()
            {
                if(eventHandlerServiceLocator == null)
                {
                    throw new ArgumentNullException(nameof(eventHandlerServiceLocator));
                }
                else if(domainEventType == null)
                {
                    throw new ArgumentNullException(nameof(domainEventType));
                }
                else
                {
                    EventHandlerServiceLocator = eventHandlerServiceLocator;
                    DomainEventType = domainEventType;
                }
            }

            /// <summary>
            /// Adds the specified event handler type.
            /// </summary>
            /// <param name="eventHandlerType">Event handler type to handle.</param>
            /// <exception cref="ArgumentNullException" />
            public void AddEventHandlerType(Type eventHandlerType)
            {
                if (eventHandlerType == null)
                {
                    throw new ArgumentNullException(nameof(eventHandlerType));
                }
                else
                {
                    if (!EventHandlerTypes.Contains(eventHandlerType))
                    {
                        EventHandlerTypes.Add(eventHandlerType);
                    }
                }
            }

            /// <summary>
            /// Attempts to publish the specified event onto the event bus.
            /// </summary>
            /// <param name="domainEvent"><see cref="WhippetDomainEvent"/> object to publish.</param>
            /// <exception cref="ArgumentNullException"></exception>
            /// <exception cref="MissingMethodException"></exception>
            public void Publish(WhippetDomainEvent domainEvent)
            {
                if (domainEvent == null)
                {
                    throw new ArgumentNullException(nameof(domainEvent));
                }
                else
                {
                    object eventHandler = null;
                    MethodInfo handleMethod = typeof(IWhippetDomainEventHandler<>).MakeGenericType(DomainEventType).GetMethod(nameof(IWhippetDomainEventHandler<WhippetDomainEvent>.Handle));

                    if (handleMethod == null)
                    {
                        throw new MissingMethodException(typeof(IWhippetDomainEventHandler<>).FullName, nameof(IWhippetDomainEventHandler<WhippetDomainEvent>.Handle));
                    }
                    else
                    {
                        foreach (Type eventHandlerType in EventHandlerTypes)
                        {
                            eventHandler = EventHandlerServiceLocator.GetService(eventHandlerType);
                            handleMethod.Invoke(eventHandler, new object[] { domainEvent });
                        }
                    }
                }
            }
        }
    }
}
