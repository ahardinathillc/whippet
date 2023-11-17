using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Store
{
    /// <summary>
    /// Interface that provides information about a Magento store's group.
    /// </summary>
    public class StoreGroupInterface : IExtensionInterface, IExtensionAttributes<StoreGroupExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the store group ID.
        /// </summary>
        [JsonProperty("id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the store website ID.
        /// </summary>
        [JsonProperty("website_id")]
        public int WebsiteID
        { get; set; }

        /// <summary>
        /// Gets or sets the root category ID.
        /// </summary>
        [JsonProperty("root_category_id")]
        public int RootCategoryID
        { get; set; }

        /// <summary>
        /// Gets or sets the default store ID.
        /// </summary>
        [JsonProperty("default_store_id")]
        public int DefaultStoreID
        { get; set; }

        /// <summary>
        /// Gets or sets the group name.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the group code.
        /// </summary>
        [JsonProperty("code")]
        public string Code
        { get; set; }
        
        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public StoreGroupExtensionInterface ExtensionAttributes
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreGroupInterface"/> class with no arguments.
        /// </summary>
        public StoreGroupInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreGroupInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Store group ID.</param>
        /// <param name="websiteId">Group website ID.</param>
        /// <param name="rootCategoryId">Root category ID.</param>
        /// <param name="defaultStoreId">Default store ID.</param>
        /// <param name="name">Group name.</param>
        /// <param name="code">Group code.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public StoreGroupInterface(int id, int websiteId, int rootCategoryId, int defaultStoreId, string name, string code, StoreGroupExtensionInterface extensionAttributes)
            : this()
        {
            ID = id;
            WebsiteID = websiteId;
            RootCategoryID = rootCategoryId;
            DefaultStoreID = defaultStoreId;
            Name = name;
            Code = code;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
