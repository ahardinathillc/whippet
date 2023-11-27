using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// Provides extra data for a <see cref="TaxRateInterface"/> instance.
    /// </summary>
    public class TaxRateTitleInterface : IExtensionInterface, IExtensionAttributes<TaxRateTitleExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the store ID.
        /// </summary>
        [JsonProperty("store_id")]
        public string StoreID
        { get; set; }

        /// <summary>
        /// Gets or sets the title value.
        /// </summary>
        [JsonProperty("value")]
        public string Value
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public TaxRateTitleExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateTitleInterface"/> class with no arguments.
        /// </summary>
        public TaxRateTitleInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateTitleInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="storeId">Store ID.</param>
        /// <param name="value">Title value.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public TaxRateTitleInterface(string storeId, string value, TaxRateTitleExtensionInterface extensionAttributes)
            : this()
        {
            StoreID = storeId;
            Value = value;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
