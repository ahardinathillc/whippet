using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Provides JSON serialization for <see cref="WhippetDomainEvent"/> objects.
    /// </summary>
    public class WhippetDomainEventJsonSerializer : IWhippetDomainEventSerializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDomainEventJsonSerializer"/> class with no arguments.
        /// </summary>
        public WhippetDomainEventJsonSerializer()
        { }

        /// <summary>
        /// Serializes the specified <see cref="WhippetDomainEvent"/> object.
        /// </summary>
        /// <param name="domainEvent"><see cref="WhippetDomainEvent"/> object to serialize.</param>
        /// <returns>Serialized string that represents the <see cref="WhippetDomainEvent"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        public string Serialize(WhippetDomainEvent domainEvent)
        {
            if(domainEvent == null)
            {
                throw new ArgumentNullException(nameof(domainEvent));
            }
            else
            {
                return JsonSerializer.SerializeToString(domainEvent, domainEvent.GetType());
            }
        }

        /// <summary>
        /// Deserializes the specified <see cref="WhippetDomainEvent"/> object.
        /// </summary>
        /// <param name="targetType">Target type to deserialize to.</param>
        /// <param name="serializedDomainEvent">Serialized <see cref="WhippetDomainEvent"/> object.</param>
        /// <returns><see cref="WhippetDomainEvent"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public WhippetDomainEvent Deserialize(Type targetType, string serializedDomainEvent)
        {
            if(targetType == null)
            {
                throw new ArgumentNullException(nameof(targetType));
            }
            else if(String.IsNullOrWhiteSpace(serializedDomainEvent))
            {
                throw new ArgumentNullException(nameof(serializedDomainEvent));
            }
            else
            {
                return (WhippetDomainEvent)(JsonSerializer.DeserializeFromString(serializedDomainEvent, targetType));
            }
        }
    }
}
