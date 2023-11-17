using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Store
{
    /// <summary>
    /// Interface that provides information about a Magento store's website.
    /// </summary>
    public class StoreWebsiteInterface : IExtensionInterface, IExtensionAttributes<StoreWebsiteExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the store ID.
        /// </summary>
        [JsonProperty("id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the website code.
        /// </summary>
        [JsonProperty("code")]
        public string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the website name.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the store group ID.
        /// </summary>
        [JsonProperty("default_group_id")]
        public int DefaultGroupID
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public StoreWebsiteExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreWebsiteInterface"/> class with no arguments.
        /// </summary>
        public StoreWebsiteInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreWebsiteInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Website ID.</param>
        /// <param name="code">Website code.</param>
        /// <param name="name">Website name.</param>
        /// <param name="defaultGroupId">Default store group ID.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public StoreWebsiteInterface(int id, string code, string name, int defaultGroupId, StoreWebsiteExtensionInterface extensionAttributes)
            : this()
        {
            ID = id;
            Code = code;
            Name = name;
            DefaultGroupID = defaultGroupId;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
