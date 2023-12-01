using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Categories
{
    /// <summary>
    /// Interface that provides information about a Magento category link.
    /// </summary>
    public class CategoryLinkInterface : IExtensionInterface, IExtensionAttributes<CategoryLinkExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the position of the link.
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
        public CategoryLinkExtensionInterface ExtensionAttributes
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryLinkInterface"/> class with no arguments.
        /// </summary>
        public CategoryLinkInterface()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryLinkInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="position">Position of the link.</param>
        /// <param name="categoryId">Category ID.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public CategoryLinkInterface(int position, string categoryId, CategoryLinkExtensionInterface extensionAttributes)
            : this()
        {
            Position = position;
            CategoryID = categoryId;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
