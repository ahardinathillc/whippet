using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.SalesRule
{
    /// <summary>
    /// Interface that provides information about a Magento sales rule label.
    /// </summary>
    public class SalesRuleLabelInterface : IExtensionInterface, IExtensionAttributes<SalesRuleLabelExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the Magento store ID.
        /// </summary>
        [JsonProperty("store_id")]
        public int StoreID
        { get; set; }

        /// <summary>
        /// Gets or sets the label value.
        /// </summary>
        [JsonProperty("store_label")]
        public string Label
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        public SalesRuleLabelExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleLabelInterface"/> class with no arguments.
        /// </summary>
        public SalesRuleLabelInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleLabelInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="storeId">Magento store ID.</param>
        /// <param name="label">Label value.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public SalesRuleLabelInterface(int storeId, string label, SalesRuleLabelExtensionInterface extensionAttributes)
            : this()
        {
            StoreID = storeId;
            Label = label;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
