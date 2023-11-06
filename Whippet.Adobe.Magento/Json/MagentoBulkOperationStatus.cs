using System;
namespace Athi.Whippet.Adobe.Magento.Json
{
    /// <summary>
    /// Represents the status code of an asynchronous bulk operation in Magento.
    /// </summary>
    /// <remarks>See <a href="https://developer.adobe.com/commerce/webapi/rest/use-rest/operation-status-search/">Search for the status of a bulk operation</a> from Adobe Developer for more information.</remarks>
    public enum MagentoBulkOperationStatus
    {
        /// <summary>
        /// The status is currently unavailable.
        /// </summary>
        Unavailable = 0,
        /// <summary>
        /// The operation is complete.
        /// </summary>
        Complete = 1,
        /// <summary>
        /// The operation failed, but you can try to perform it again.
        /// </summary>
        OperationFailed_Retry = 2,
        /// <summary>
        /// The operation failed. You must change something to retry it.
        /// </summary>
        OperationFailed_Change = 3,
        /// <summary>
        /// The operation is currently open.
        /// </summary>
        Open = 4,
        /// <summary>
        /// The operation has been rejected.
        /// </summary>
        Rejected = 5
    }
}

