using System;
using System.Runtime.Serialization;
using Athi.Whippet.Localization;

namespace Athi.Whippet.Jobs
{
    /// <summary>
    /// Exception that is thrown when multiple values are supplied to a single parameter.
    /// </summary>
    public sealed class MultipleParameterValuesException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleParameterValuesException"/> class with no arguments.
        /// </summary>
        public MultipleParameterValuesException()
            : this(LocalizedStringResourceLoader.GetException<MultipleParameterValuesException>(nameof(MultipleParameterValuesException)))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleParameterValuesException"/> class with the specified message.
        /// </summary>
        /// <param name="message">Error message to display.</param>
        public MultipleParameterValuesException(string message)
            : this(message, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleParameterValuesException"/> class with the specified message.
        /// </summary>
        /// <param name="message">Error message to display.</param>
        /// <param name="innerException"><see cref="Exception"/> that was caught prior to this instance.</param>
        public MultipleParameterValuesException(string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleParameterValuesException"/> class with the specified serialization information.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Context in which the serialization takes place.</param>
        public MultipleParameterValuesException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}

