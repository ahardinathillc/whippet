using System;
using System.Runtime.Serialization;

namespace Athi.Whippet.Collections
{
    /// <summary>
    /// Exception that is thrown when one or more items are attempted to be added to a collection with a constraint, typically being a member of a parent object grouping or a range. This class cannot be inherited.
    /// </summary>
    public sealed class CollectionRestrictionViolationException : WhippetException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionRestrictionViolationException"/> class with no arguments.
        /// </summary>
        public CollectionRestrictionViolationException()
            : base(LocalizeString(nameof(CollectionRestrictionViolationException), culture: CurrentCulture))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionRestrictionViolationException"/> class with the specified error message.
        /// </summary>
        /// <param name="message">Message to display.</param>
        public CollectionRestrictionViolationException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionRestrictionViolationException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception or <see langword="null"/> if no inner exception is specified.</param>
        public CollectionRestrictionViolationException(string message, Exception innerException)
            : base(String.IsNullOrWhiteSpace(message) ? LocalizeString(nameof(CollectionRestrictionViolationException), culture: CurrentCulture) : message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionRestrictionViolationException"/> class with serialized data.
        /// </summary>
        /// <param name="serializationInfo">The <see cref="SerializationInfo"/> object that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="SerializationException" />
        public CollectionRestrictionViolationException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        { }
    }
}
