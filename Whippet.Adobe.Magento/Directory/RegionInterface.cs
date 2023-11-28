using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Directory
{
    /// <summary>
    /// Interface that provides information about a Magento country region.
    /// </summary>
    public class RegionInterface : IExtensionInterface, IExtensionAttributes<RegionExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the region ID.
        /// </summary>
        [JsonProperty("id")]
        public string ID
        { get; set; }

        /// <summary>
        /// Gets or sets the region code.
        /// </summary>
        [JsonProperty("code")]
        public string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the region name.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        public RegionExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="RegionInterface"/> class with no arguments.
        /// </summary>
        public RegionInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Region ID.</param>
        /// <param name="code">Region code.</param>
        /// <param name="name">Region name.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public RegionInterface(string id, string code, string name, RegionExtensionInterface extensionAttributes)
            : this()
        {
            ID = id;
            Code = code;
            Name = name;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
