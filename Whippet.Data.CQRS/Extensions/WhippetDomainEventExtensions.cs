using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.CQRS.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="WhippetDomainEvent"/> objects. This class cannot be inherited.
    /// </summary>
    public static class WhippetDomainEventExtensions
    {
        /// <summary>
        /// Gets the event handler method name for the specified event type.
        /// </summary>
        /// <param name="wdEvent"><see cref="WhippetDomainEvent"/> object.</param>
        /// <param name="domainEventType"><see cref="Type"/> that represents the domain event type.</param>
        /// <param name="prefix">Prefix of the method name.</param>
        /// <param name="suffix">Suffix of the method name.</param>
        /// <returns>Event handler method name to invoke.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GetEventHandlerMethodName(this WhippetDomainEvent wdEvent, string prefix = "On", string suffix = "Event")
        {
            if(wdEvent == null)
            {
                throw new ArgumentNullException(nameof(wdEvent));
            }
            else
            {
                int eventIndex = wdEvent.GetType().Name.LastIndexOf(suffix, StringComparison.InvariantCultureIgnoreCase);
                return prefix + wdEvent.GetType().Name.Remove(eventIndex, suffix.Length);
            }
        }
    }
}
