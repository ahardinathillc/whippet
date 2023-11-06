using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Exception that is thrown when a change is attempted on an entity that is immutable. This class cannot be inherited.
    /// </summary>
    public sealed class EntityIsReadOnlyException : UnlocalizedException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityIsReadOnlyException"/> class with the default error message.
        /// </summary>
        public EntityIsReadOnlyException()
            : base("Cannot change entity value. Entity is read-only.")
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityIsReadOnlyException"/> class with the specified entity type and property/method name that invoked the exception.
        /// </summary>
        /// <param name="entityType">Entity type.</param>
        /// <param name="propertyOrMethodName">Property or method name that invoked the exception.</param>
        public EntityIsReadOnlyException(Type entityType, string propertyOrMethodName)
            : base("Cannot change entity value for " + (entityType != null ? entityType.FullName : typeof(object).FullName) + " on " + 
                  (String.IsNullOrWhiteSpace(propertyOrMethodName) ? "property/method" : propertyOrMethodName) + ". Entity is read-only.")
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityIsReadOnlyException"/> class with serialized data.
        /// </summary>
        /// <param name="serializationInfo">The <see cref="SerializationInfo"/> object that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="SerializationException" />
        public EntityIsReadOnlyException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        { }
    }
}
