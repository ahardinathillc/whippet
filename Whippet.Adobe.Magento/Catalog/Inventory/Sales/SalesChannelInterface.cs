using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Inventory.Sales
{
    /// <summary>
    /// Provides information about a sales channel in Magento.
    /// </summary>
    public class SalesChannelInterface : IExtensionInterface, IExtensionAttributes<SalesChannelExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the sales channel type.
        /// </summary>
        [JsonProperty("type")]
        public string Type
        { get; set; }
        
        /// <summary>
        /// Gets or sets the sales channel code.
        /// </summary>
        [JsonProperty("code")]
        public string Code
        { get; set; }
        
        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public SalesChannelExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesChannelInterface"/> class with no arguments.
        /// </summary>
        public SalesChannelInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesChannelInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="type">Type nam.e</param>
        /// <param name="code">Channel code.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public SalesChannelInterface(string type, string code, SalesChannelExtensionInterface extensionAttributes)
            : this()
        {
            Type = type;
            Code = code;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
