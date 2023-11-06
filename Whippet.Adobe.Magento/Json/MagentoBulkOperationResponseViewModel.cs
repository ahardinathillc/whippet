using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Json
{
    /// <summary>
    /// Provides information about a bulk operation against the Magento REST API. This class cannot be inherited.
    /// </summary>
    public sealed class MagentoBulkOperationResponseViewModel
    {
        /// <summary>
        /// Gets the unique bulk operation UUID. This property is read-only.
        /// </summary>
        [JsonProperty("bulk_uuid")]
        public Guid BulkID
        { get; private set; }

        /// <summary>
        /// Gets a read-only collection of all request items that were processed in the operation. This property is read-only.
        /// </summary>
        [JsonProperty("request_items")]
        public IReadOnlyList<MagentoBulkOperationRequestItem> RequestItems
        { get; private set; }

        /// <summary>
        /// Indicates whether errors were encountered during the operation.
        /// </summary>
        [JsonProperty("errors")]
        public bool Errors
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoBulkOperationResponseViewModel"/> class with no arguments.
        /// </summary>
        private MagentoBulkOperationResponseViewModel()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoBulkOperationResponseViewModel"/> class with the specified parameters.
        /// </summary>
        /// <param name="bulkId">Unique bulk operation UUID.</param>
        /// <param name="requestItems">Request items that were processed in the operation.</param>
        /// <param name="errors">Indicates whether errors were encountered during the operation.</param>
        public MagentoBulkOperationResponseViewModel(Guid bulkId, IEnumerable<MagentoBulkOperationRequestItem> requestItems, bool errors)
            : this()
        {
            BulkID = bulkId;
            RequestItems = (requestItems == null) ? new List<MagentoBulkOperationRequestItem>().AsReadOnly() : new List<MagentoBulkOperationRequestItem>(requestItems).AsReadOnly();
            Errors = errors;
        }

        /// <summary>
        /// Represents an individual response for each item in a <see cref="MagentoBulkOperationResponseViewModel"/>. This class cannot be inherited.
        /// </summary>
        public sealed class MagentoBulkOperationRequestItem
        {
            /// <summary>
            /// Gets the unique ID of the record. This property is read-only.
            /// </summary>
            [JsonProperty("id")]
            public int ID
            { get; private set; }

            /// <summary>
            /// Gets the unique hash for the data record. This property is read-only.
            /// </summary>
            [JsonProperty("data_hash")]
            public string DataHash
            { get; private set; }

            /// <summary>
            /// Gets the status of the operation. This property is read-only.
            /// </summary>
            [JsonProperty("status")]
            public string Status
            { get; private set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="MagentoBulkOperationRequestItem"/> class with no arguments.
            /// </summary>
            private MagentoBulkOperationRequestItem()
            { }

            /// <summary>
            /// Initializes a new instance of the <see cref="MagentoBulkOperationRequestItem"/> class with the specified arguments.
            /// </summary>
            /// <param name="id">Unique ID of the record.</param>
            /// <param name="dataHash">Unique hash for the data record.</param>
            /// <param name="status">Status of the operation.</param>
            public MagentoBulkOperationRequestItem(int id, string dataHash, string status)
                : this()
            {
                ID = id;
                DataHash = dataHash;
                Status = status;
            }
        }
    }
}

