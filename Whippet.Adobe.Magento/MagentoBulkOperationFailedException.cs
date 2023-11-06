using System;
using Athi.Whippet.Localization;
using Athi.Whippet.Adobe.Magento.ResourceFiles;
using System.Runtime.Serialization;

namespace Athi.Whippet.Adobe.Magento
{
    /// <summary>
    /// Exception that is thrown when a Magento bulk operation API operation encounters an error. This class cannot be inherited.
    /// </summary>
    public sealed class MagentoBulkOperationFailedException : WhippetException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoBulkOperationFailedException"/> class with no arguments.
        /// </summary>
        private MagentoBulkOperationFailedException()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoBulkOperationFailedException"/> class with the specified bulk operation ID.
        /// </summary>
        /// <param name="bulkId">Bulk operation ID.</param>
        public MagentoBulkOperationFailedException(Guid bulkId)
            : base(LocalizedStringResourceLoader.GetException<MagentoBulkOperationFailedException>(ExceptionResourceIndex.MagentoBulkOperationFailedException, new object[] { bulkId }))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoBulkOperationFailedException"/> class with serialized data.
        /// </summary>
        /// <param name="serializationInfo">The <see cref="SerializationInfo"/> object that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="SerializationException" />
        public MagentoBulkOperationFailedException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        { }
    }
}

