using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog
{
    /// <summary>
    /// Interface that provides information about a Magento catalog item's custom options.
    /// </summary>
    public class CatalogCustomOptionInterface : IExtensionInterface, IExtensionAttributes<CatalogCustomOptionExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the option ID.
        /// </summary>
        [JsonProperty("option_id")]
        public string OptionID
        { get; set; }

        /// <summary>
        /// Gets or sets the option value.
        /// </summary>
        [JsonProperty("option_value")]
        public string OptionValue
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CatalogCustomOptionExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogCustomOptionInterface"/> with no arguments.
        /// </summary>
        public CatalogCustomOptionInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogCustomOptionInterface"/> with the specified parameters.
        /// </summary>
        /// <param name="optionId">Option ID.</param>
        /// <param name="optionValue">Option value.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public CatalogCustomOptionInterface(string optionId, string optionValue, CatalogCustomOptionExtensionInterface extensionAttributes)
            : this()
        {
            OptionID = optionId;
            OptionValue = optionValue;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
