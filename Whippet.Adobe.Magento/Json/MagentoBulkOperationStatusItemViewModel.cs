using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Json
{
    /// <summary>
    /// View model for individual bulk status items for bulk API request statuses in Magento. This class cannot be inherited.
    /// </summary>
    public sealed class MagentoBulkOperationStatusItemViewModel
    {
        private List<MagentoBulkOperationStatusItemExtensionAttributesViewModel> _extensionAttribs;

        /// <summary>
        /// Gets or sets the extension attributes of the operation, including start time of the operation.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public List<MagentoBulkOperationStatusItemExtensionAttributesViewModel> ExtensionAttributes
        {
            get
            {
                if (_extensionAttribs == null)
                {
                    _extensionAttribs = new List<MagentoBulkOperationStatusItemExtensionAttributesViewModel>();
                }

                return _extensionAttribs;
            }
            set
            {
                _extensionAttribs = value;
            }
        }

        /// <summary>
        /// Gets or sets the ID of the item.
        /// </summary>
        [JsonProperty("id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the bulk operation UUID.
        /// </summary>
        [JsonProperty("bulk_uuid")]
        public Guid BulkID
        { get; set; }

        /// <summary>
        /// Gets or sets the asynchronous bulk operation name.
        /// </summary>
        [JsonProperty("topic_name")]
        public string TopicName
        { get; set; }

        /// <summary>
        /// Gets the JSON serialized data that was provided to Magento.
        /// </summary>
        [JsonProperty("serialized_data")]
        public string SerializedData
        { get; set; }

        /// <summary>
        /// Gets the JSON serialized data that Magento returned from the operation.
        /// </summary>
        [JsonProperty("result_serialized_data")]
        public string ResultSerializedData
        { get; set; }

        /// <summary>
        /// Gets or sets the raw operation status code that was returned by Magento.
        /// </summary>
        [JsonProperty("status")]
        public int RawOperationStatus
        { get; set; }

        /// <summary>
        /// Gets a human-readable description of <see cref="RawOperationStatus"/>. This property is read-only.
        /// </summary>
        [JsonIgnore]
        public MagentoBulkOperationStatus OperationStatus
        {
            get
            {
                return Enum.Parse<MagentoBulkOperationStatus>(Convert.ToString(RawOperationStatus));
            }
        }

        /// <summary>
        /// Gets or sets the result message; for errors, will contain the error message.
        /// </summary>
        [JsonProperty("result_message")]
        public string ResultMessage
        { get; set; }

        /// <summary>
        /// Gets or sets the error code returned by Magento.
        /// </summary>
        [JsonProperty("error_code")]
        public int ErrorCode
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoBulkOperationStatusItemViewModel"/> class with no arguments.
        /// </summary>
        public MagentoBulkOperationStatusItemViewModel()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoBulkOperationStatusItemViewModel"/> class with the specified parameters.
        /// </summary>
        /// <param name="extensionAttributes">the extension attributes of the operation, including start time of the operation.</param>
        /// <param name="id">ID of the item.</param>
        /// <param name="bulkId">The bulk operation UUID.</param>
        /// <param name="topicName">The asynchronous bulk operation name.</param>
        /// <param name="serializedData">JSON serialized data that was provided to Magento.</param>
        /// <param name="resultSerializedData">JSON serialized data that Magento returned from the operation.</param>
        /// <param name="rawOperationStatus">Raw operation status code that was returned by Magento.</param>
        /// <param name="resultMessage">Result message; for errors, will contain the error message.</param>
        /// <param name="errorCode">Error code returned by Magento.</param>
        public MagentoBulkOperationStatusItemViewModel(List<MagentoBulkOperationStatusItemExtensionAttributesViewModel> extensionAttributes, int id, Guid bulkId, string topicName, string serializedData, string resultSerializedData, int rawOperationStatus, string resultMessage, int errorCode)
            : this()
        {
            ExtensionAttributes = extensionAttributes;
            ID = id;
            BulkID = bulkId;
            TopicName = topicName;
            SerializedData = serializedData;
            ResultSerializedData = resultSerializedData;
            RawOperationStatus = rawOperationStatus;
            ResultMessage = resultMessage;
            ErrorCode = errorCode;
        }
    }
}

