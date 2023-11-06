using System;
using System.Data;
using System.Runtime.Serialization;
using Athi.Whippet;
using Athi.Whippet.Localization;
using Athi.Whippet.Data.ResourceFiles;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Exception that is thrown when a <see cref="DataTable"/> contains a composite key instead of an individual primary key. This class cannot be inherited.
    /// </summary>
    public sealed class CompositeKeyException : WhippetException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeKeyException"/> class with no arguments.
        /// </summary>
        public CompositeKeyException()
            : this(String.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeKeyException"/> class with the specified message.
        /// </summary>
        /// <param name="message">Message to display or <see langword="null"/> to use the default message.</param>
        public CompositeKeyException(string message)
            : this(message, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeKeyException"/> class with the specified message and inner exception.
        /// </summary>
        /// <param name="message">Message to display or <see langword="null"/> to use the default message.</param>
        /// <param name="innerException"><see cref="Exception"/> that was encountered prior to the current exception being thrown.</param>
        public CompositeKeyException(string message, Exception innerException)
            : base(String.IsNullOrWhiteSpace(message) ? LocalizedStringResourceLoader.GetException<CompositeKeyException>(ExceptionResourceIndex.CompositeKeyException) : message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeKeyException"/> class with serialized data.
        /// </summary>
        /// <param name="serializationInfo">The <see cref="SerializationInfo"/> object that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="SerializationException" />
        internal CompositeKeyException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        { }
    }
}

