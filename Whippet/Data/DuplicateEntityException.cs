using System;
using System.Runtime.Serialization;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Exception that is thrown when an entity is attempted to be added to a data store and encounters an existing instance with the same foreign identifier, such as a tenant or ID. This class cannot be inherited.
    /// </summary>
    public sealed class DuplicateEntityException : WhippetException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateEntityException"/> class with no arguments.
        /// </summary>
        public DuplicateEntityException()
            : this(LocalizeString(nameof(DuplicateEntityException), culture: CurrentCulture))
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public DuplicateEntityException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateEntityException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception or <see langword="null"/> if no inner exception is specified.</param>
        public DuplicateEntityException(string message, Exception innerException)
            : base(String.IsNullOrWhiteSpace(message) ? LocalizeString(nameof(DuplicateEntityException), culture: CurrentCulture) : message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateEntityException"/> class with serialized data.
        /// </summary>
        /// <param name="serializationInfo">The <see cref="SerializationInfo"/> object that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="SerializationException" />
        public DuplicateEntityException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        { }
    }
}
