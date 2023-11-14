using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Product.Bundle
{
    /// <summary>
    /// Interface that provides information about a Magento bundle option.
    /// </summary>
    public class BundleOptionInterface : IExtensionInterface, IExtensionAttributes<BundleOptionExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the bundle option ID.
        /// </summary>
        [JsonProperty("option_id")]
        public int OptionID
        { get; set; }

        /// <summary>
        /// Gets or sets the bundle option quantity.
        /// </summary>
        [JsonProperty("option_qty")]
        public int OptionQuantity
        { get; set; }

        /// <summary>
        /// Gets or sets the bundle option selection IDs.
        /// </summary>
        [JsonProperty("option_selections")]
        public int[] OptionSelections
        { get; set; }

        /// <summary>
        /// Gets or sets extra data about the bundle option.
        /// </summary>
        public BundleOptionExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BundleOptionInterface"/>.
        /// </summary>
        public BundleOptionInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BundleOptionInterface"/>.
        /// </summary>
        /// <param name="optionId">Option ID.</param>
        /// <param name="optionQuantity">Bundle option quantity.</param>
        /// <param name="optionSelections">Option selections.</param>
        /// <param name="extensionAttributes">Extra data about the bundle option.</param>
        public BundleOptionInterface(int optionId, int optionQuantity, IEnumerable<int> optionSelections, BundleOptionExtensionInterface extensionAttributes)
            : this()
        {
            OptionID = optionId;
            OptionQuantity = optionQuantity;
            OptionSelections = (optionSelections == null) ? null : optionSelections.ToArray();
            ExtensionAttributes = extensionAttributes;
        }
    }
}
