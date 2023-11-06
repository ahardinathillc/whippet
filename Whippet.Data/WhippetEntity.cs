using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Base class for all domain objets in Whippet. This class must be inherited.
    /// </summary>
    /// <remarks>This is the equivalent to an Aggregate base class. See <a href="http://www.andreavallotti.tech/en/2018/01/event-sourcing-and-cqrs-in-c/">Event Sourcing and CQRS in C#</a> for more information.</remarks>
    [JsonObject]
    public abstract class WhippetEntity : IWhippetEntity, IJsonObject, IJsonSerializableObject
    {
        /// <summary>
        /// Unique ID of the entity.
        /// </summary>
        [JsonRequired]
        public virtual Guid ID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetEntity"/> class with no arguments.
        /// </summary>
        protected WhippetEntity()
        {
            ID = Guid.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetEntity"/> class with the specified <see cref="Guid"/>.
        /// </summary>
        /// <param name="id"><see cref="Guid"/> value that represents the unique identifier of the entity.</param>
        protected WhippetEntity(Guid id)
            : this()
        {
            ID = id;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be overridden.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public abstract string ToJson<T>() where T : IJsonSerializableObject;
    }
}
