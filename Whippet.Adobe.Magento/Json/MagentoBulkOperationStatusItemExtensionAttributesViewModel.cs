using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Json
{
    /// <summary>
    /// View model for extension attributes that are stored in the <see cref="MagentoBulkOperationStatusItemViewModel"/>. This class cannot be inherited.
    /// </summary>
    public sealed class MagentoBulkOperationStatusItemExtensionAttributesViewModel
    {
        /// <summary>
        /// Gets or sets the start time of the bulk operation.
        /// </summary>
        [JsonProperty("start_time")]
        public DateTime? StartTime
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoBulkOperationStatusItemExtensionAttributesViewModel"/> class with no arguments.
        /// </summary>
        public MagentoBulkOperationStatusItemExtensionAttributesViewModel()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoBulkOperationStatusItemExtensionAttributesViewModel"/> class with the specified start time.
        /// </summary>
        /// <param name="startTime">Start timestamp of the operation.</param>
        public MagentoBulkOperationStatusItemExtensionAttributesViewModel(DateTime? startTime)
            : this()
        {
            StartTime = startTime;
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return StartTime.HasValue ? StartTime.Value.ToString() : base.ToString();
        }
    }
}

