using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Exception that is thrown when an <see cref="IWhippetEvent"/> is supplied to an event handler or aggregate that is not supported. This class cannot be inherited.
    /// </summary>
    public sealed class EventNotSupportedException : WhippetException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventNotSupportedException"/> class with no arguments.
        /// </summary>
        public EventNotSupportedException()
            : base(LocalizeString(nameof(EventNotSupportedException), culture: CurrentCulture))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventNotSupportedException"/> class with the specified error message.
        /// </summary>
        /// <param name="message">Message to display.</param>
        public EventNotSupportedException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventNotSupportedException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception or <see langword="null"/> if no inner exception is specified.</param>
        public EventNotSupportedException(string message, Exception innerException)
            : base(String.IsNullOrWhiteSpace(message) ? LocalizeString(nameof(EventNotSupportedException), culture: CurrentCulture) : message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventNotSupportedException"/> class with serialized data.
        /// </summary>
        /// <param name="serializationInfo">The <see cref="SerializationInfo"/> object that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="SerializationException" />
        public EventNotSupportedException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        { }
    }

}
