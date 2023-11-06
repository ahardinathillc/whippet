using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.EventManagement;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Represents an event bus for <see cref="WhippetEvent"/> objects.
    /// </summary>
    public interface IWhippetDomainEventBus : IWhippetEventBus
    {
        /// <summary>
        /// Publishes an event to the event bus.
        /// </summary>
        /// <param name="whippetEvent"><see cref="WhippetDomainEvent"/> object to publish.</param>
        /// <exception cref="ArgumentNullException" />
        void PublishEvent(WhippetDomainEvent whippetEvent);

        /// <summary>
        /// Publishes a collection of events to the event bus.
        /// </summary>
        /// <param name="whippetEvents"><see cref="IEnumerable{T}"/> colleciton of <see cref="WhippetDomainEvent"/> objects to publish.</param>
        /// <exception cref="ArgumentNullException" />
        void PublishEvents(IEnumerable<WhippetDomainEvent> whippetEvents);
    }
}
