using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryPack;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Provides binary serialization for <see cref="WhippetDomainEvent"/> objects.
    /// </summary>
    public class WhippetDomainEventBinarySerializer : IWhippetDomainEventSerializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDomainEventBinarySerializer"/> class with no arguments.
        /// </summary>
        public WhippetDomainEventBinarySerializer()
        { }

        /// <summary>
        /// Serializes the specified <see cref="WhippetDomainEvent"/> object.
        /// </summary>
        /// <param name="domainEvent"><see cref="WhippetDomainEvent"/> object to serialize.</param>
        /// <returns>Serialized string that represents the <see cref="WhippetDomainEvent"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        public string Serialize(WhippetDomainEvent domainEvent)
        {
            if (domainEvent == null)
            {
                throw new ArgumentNullException(nameof(domainEvent));
            }
            else
            {
                MemoryStream memoryStream = null;
                string streamContents;

                try
                {
                    memoryStream = new MemoryStream();
                    BinaryConverter.Serialize(domainEvent, memoryStream);

                    memoryStream.Flush();
                    memoryStream.Position = 0;

                    streamContents = Convert.ToBase64String(memoryStream.ToArray());
                }
                finally
                {
                    if(memoryStream != null)
                    {
                        memoryStream.Dispose();
                        memoryStream = null;
                    }
                }

                return streamContents;
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
            if (targetType == null)
            {
                throw new ArgumentNullException(nameof(targetType));
            }
            else if (String.IsNullOrWhiteSpace(serializedDomainEvent))
            {
                throw new ArgumentNullException(nameof(serializedDomainEvent));
            }
            else
            {
                MemoryStream memoryStream = null;
                WhippetDomainEvent domainEvent = null;

                try
                {
                    memoryStream = new MemoryStream(Convert.FromBase64String(serializedDomainEvent));
                    domainEvent = BinaryConverter.Deserialize<WhippetDomainEvent>(memoryStream);
                }
                finally
                {
                    if (memoryStream != null)
                    {
                        memoryStream.Dispose();
                        memoryStream = null;
                    }
                }

                return domainEvent;
            }
        }
    }
}
