using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.EAV
{
    /// <summary>
    /// Interface that provides display information about an attribute's frontend label.
    /// </summary>
    public class AttributeFrontendLabelInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the store ID.
        /// </summary>
        [JsonProperty("store_id")]
        public int StoreID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the option label.
        /// </summary>
        [JsonProperty("label")]
        public string Label
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeFrontendLabelInterface"/> class with no arguments.
        /// </summary>
        public AttributeFrontendLabelInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeFrontendLabelInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="storeId">Store ID.</param>
        /// <param name="label">Attribute label.</param>
        public AttributeFrontendLabelInterface(int storeId, string label)
            : this()
        {
            StoreID = storeId;
            Label = label;
        }
    }
}
