using System;
using System.Runtime.Serialization;
using Athi.Whippet.Localization;
using Athi.Whippet.Adobe.Magento.Categories.ResourceFiles;

namespace Athi.Whippet.Adobe.Magento.Categories
{
    /// <summary>
    /// Exception that is thrown when a duplicate <see cref="ICategory"/> is encountered in a <see cref="CategoryCollection"/> instance.
    /// </summary>
    public sealed class DuplicateCategoryException : WhippetException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateCategoryException"/> class with no arguments.
        /// </summary>
        public DuplicateCategoryException()
            : this(String.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateCategoryException"/> class with the specified message.
        /// </summary>
        /// <param name="message">Message to display or <see langword="null"/> to use the default message.</param>
        public DuplicateCategoryException(string message)
            : this(message, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateCategoryException"/> class with the specified message and inner exception.
        /// </summary>
        /// <param name="message">Message to display or <see langword="null"/> to use the default message.</param>
        /// <param name="innerException"><see cref="Exception"/> that was encountered prior to the current exception being thrown.</param>
        public DuplicateCategoryException(string message, Exception innerException)
            : base(String.IsNullOrWhiteSpace(message) ? LocalizedStringResourceLoader.GetException<DuplicateCategoryException>(ExceptionResourceIndex.DuplicateCategoryException) : message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateCategoryException"/> class with serialized data.
        /// </summary>
        /// <param name="serializationInfo">The <see cref="SerializationInfo"/> object that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="SerializationException" />
        internal DuplicateCategoryException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        { }    
    }
}
