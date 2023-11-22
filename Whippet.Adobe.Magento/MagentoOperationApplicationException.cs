using System;
using Athi.Whippet.Localization;
using Athi.Whippet.Adobe.Magento.ResourceFiles;
using System.Runtime.Serialization;

namespace Athi.Whippet.Adobe.Magento
{
    /// <summary>
    /// Exception that is thrown when a Magento operation cannot be completed via the API (typically REST) and must be completed via the Magento application itself. This class cannot be inherited.
    /// </summary>
    public sealed class MagentoOperationApplicationException : WhippetException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoOperationApplicationException"/> class with no arguments.
        /// </summary>
        public MagentoOperationApplicationException()
            : base(LocalizedStringResourceLoader.GetException<MagentoOperationApplicationException>(ExceptionResourceIndex.MagentoOperationApplicationException))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoOperationApplicationException"/> class with serialized data.
        /// </summary>
        /// <param name="serializationInfo">The <see cref="SerializationInfo"/> object that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="SerializationException" />
        public MagentoOperationApplicationException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        { }
    }
}
