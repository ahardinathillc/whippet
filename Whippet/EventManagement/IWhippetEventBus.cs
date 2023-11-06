using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.EventManagement
{
    /// <summary>
    /// Represents an event bus for <see cref="WhippetEvent"/> objects.
    /// </summary>
    public interface IWhippetEventBus
    {
        /// <summary>
        /// Publishes an event to the event bus.
        /// </summary>
        /// <param name="whippetEvent"><see cref="WhippetEvent"/> object to publish.</param>
        /// <exception cref="ArgumentNullException" />
        void PublishEvent(WhippetEvent whippetEvent);

        /// <summary>
        /// Publishes a collection of events to the event bus.
        /// </summary>
        /// <param name="whippetEvents"><see cref="IEnumerable{T}"/> colleciton of <see cref="WhippetEvent"/> objects to publish.</param>
        /// <exception cref="ArgumentNullException" />
        void PublishEvents(IEnumerable<WhippetEvent> whippetEvents);
    }
}
