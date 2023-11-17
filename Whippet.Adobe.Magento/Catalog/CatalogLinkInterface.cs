using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog
{
    /// <summary>
    /// Interface that provides information about a category's link in Magento.
    /// </summary>
    public class CatalogLinkInterface : IExtensionInterface, IExtensionAttributes<CatalogLinkExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the position of the link as it is displayed in the storefront.
        /// </summary>
        [JsonProperty("position")]
        public int Position
        { get; set; }

        /// <summary>
        /// Gets or sets the category ID.
        /// </summary>
        [JsonProperty("category_id")]
        public string CategoryID
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CatalogLinkExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogLinkInterface"/> class with no arguments.
        /// </summary>
        public CatalogLinkInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogLinkInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="position">Position of the link as it is displayed on the storefront.</param>
        /// <param name="categoryId">Category ID.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public CatalogLinkInterface(int position, string categoryId, CatalogLinkExtensionInterface extensionAttributes)
            : this()
        {
            Position = position;
            CategoryID = categoryId;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
