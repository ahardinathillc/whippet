using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Store
{
    /// <summary>
    /// Interface that provides information about a Magento store.
    /// </summary>
    public class StoreInterface : IExtensionInterface, IExtensionAttributes<StoreExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the store ID.
        /// </summary>
        [JsonProperty("id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the store code.
        /// </summary>
        [JsonProperty("code")]
        public string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the store name.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the website ID of the store.
        /// </summary>
        [JsonProperty("website_id")]
        public int WebsiteID
        { get; set; }

        /// <summary>
        /// Gets or sets the store group ID.
        /// </summary>
        [JsonProperty("store_group_id")]
        public int StoreGroupID
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the store is active. Values greater than zero (0) are <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("is_active")]
        public int Active
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public StoreExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreInterface"/> class with no arguments.
        /// </summary>
        public StoreInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Store ID.</param>
        /// <param name="code">Store code.</param>
        /// <param name="name">Store name.</param>
        /// <param name="websiteId">Store website ID.</param>
        /// <param name="storeGroupId">Store group ID.</param>
        /// <param name="active">Flag that indicates whether the store is active. Values greater than zero (0) are <see langword="true"/>; otherwise, <see langword="false"/>.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public StoreInterface(int id, string code, string name, int websiteId, int storeGroupId, int active, StoreExtensionInterface extensionAttributes)
            : this()
        {
            ID = id;
            Code = code;
            Name = name;
            WebsiteID = websiteId;
            StoreGroupID = storeGroupId;
            Active = active;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
