using System;
using Athi.Whippet;
using System.Runtime.Serialization;

namespace Athi.Whippet.Reflection
{
    /// <summary>
    /// Exception that is thrown when a <see cref="Type"/> is provided that is not a <see cref="Type.IsClass"/>. This class cannot be inherited.
    /// </summary>
    public sealed class ConcreteClassTypeRequiredException : WhippetException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConcreteClassTypeRequiredException"/> class with no arguments.
        /// </summary>
        public ConcreteClassTypeRequiredException()
            : this(LocalizeString(nameof(ConcreteClassTypeRequiredException), culture: CurrentCulture))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConcreteClassTypeRequiredException"/> class with the specified error message.
        /// </summary>
        /// <param name="message">Error message to display.</param>
        public ConcreteClassTypeRequiredException(string message)
            : this(message, String.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConcreteClassTypeRequiredException"/> class with the specified error message.
        /// </summary>
        /// <param name="message">Error message to display.</param>
        /// <param name="parameterName">Parameter name that triggered the error.</param>
        public ConcreteClassTypeRequiredException(string message, string parameterName)
            : base(new ArgumentException(String.IsNullOrWhiteSpace(message) ? LocalizeString(nameof(ConcreteClassTypeRequiredException), culture: CurrentCulture) : message, parameterName).Message, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConcreteClassTypeRequiredException"/> class with the specified error message.
        /// </summary>
        /// <param name="message">Error message to display.</param>
        /// <param name="innerException">Inner <see cref="Exception"/> that was caught prior to the current instance invocation.</param>
        public ConcreteClassTypeRequiredException(string message, Exception innerException)
            : base(String.IsNullOrWhiteSpace(message) ? LocalizeString(nameof(ConcreteClassTypeRequiredException), culture: CurrentCulture) : message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConcreteClassTypeRequiredException"/> class with serialized data.
        /// </summary>
        /// <param name="serializationInfo">The <see cref="SerializationInfo"/> object that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="SerializationException" />
        public ConcreteClassTypeRequiredException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        { }
    }
}