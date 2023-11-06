using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Provides serialization support to <see cref="WhippetDomainEvent"/> objects.
    /// </summary>
    public interface IWhippetDomainEventSerializer
    {
        /// <summary>
        /// Serializes the specified <see cref="WhippetDomainEvent"/> object.
        /// </summary>
        /// <param name="domainEvent"><see cref="WhippetDomainEvent"/> object to serialize.</param>
        /// <returns>Serialized string that represents the <see cref="WhippetDomainEvent"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        string Serialize(WhippetDomainEvent domainEvent);

        /// <summary>
        /// Deserializes the specified <see cref="WhippetDomainEvent"/> object.
        /// </summary>
        /// <param name="targetType">Target type to deserialize to.</param>
        /// <param name="serializedDomainEvent">Serialized <see cref="WhippetDomainEvent"/> object.</param>
        /// <returns><see cref="WhippetDomainEvent"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetDomainEvent Deserialize(Type targetType, string serializedDomainEvent);
    }
}
