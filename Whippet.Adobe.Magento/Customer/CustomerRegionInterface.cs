using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Customer
{
    /// <summary>
    /// Interface that provides information about a Magento customer's region.
    /// </summary>
    public class CustomerRegionInterface : IExtensionInterface, IExtensionAttributes<CustomerRegionExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the region ID.
        /// </summary>
        [JsonProperty("region_id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the region code.
        /// </summary>
        [JsonProperty("region_code")]
        public string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the region name.
        /// </summary>
        [JsonProperty("region")]
        public string Region
        { get; set; }
        
        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        public CustomerRegionExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRegionInterface"/> class with no arguments.
        /// </summary>
        public CustomerRegionInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRegionInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Region ID.</param>
        /// <param name="code">Region code.</param>
        /// <param name="region">Region name.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public CustomerRegionInterface(int id, string code, string region, CustomerRegionExtensionInterface extensionAttributes)
            : this()
        {
            ID = id;
            Code = code;
            Region = region;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
