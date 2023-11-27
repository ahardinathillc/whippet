using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.Catalog;

namespace Athi.Whippet.Adobe.Magento.Categories
{
    /// <summary>
    /// Interface that provides information about a Magento store's category when querying all categories.
    /// </summary>
    public class CategoryAbstractInterface: IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the category ID.
        /// </summary>
        [JsonProperty("id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the parent category ID.
        /// </summary>
        [JsonProperty("parent_id")]
        public int ParentID
        { get; set; }

        /// <summary>
        /// Gets or sets the category name.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        { get; set; }

        /// <summary>
        /// Specifies whether the category is active.
        /// </summary>
        [JsonProperty("active")]
        public bool Active
        { get; set; }

        /// <summary>
        /// Gets or sets the category position.
        /// </summary>
        [JsonProperty("position")]
        public int Position
        { get; set; }

        /// <summary>
        /// Gets or sets the category level.
        /// </summary>
        [JsonProperty("level")]
        public int Level
        { get; set; }

        /// <summary>
        /// Gets or sets the number of products currently listed in the category.
        /// </summary>
        [JsonProperty("product_count")]
        public int ProductCount
        { get; set; }
        
        /// <summary>
        /// Gets or sets the children data of the current category.
        /// </summary>
        [JsonProperty("children_data")]
        public CatalogCategoryTreeInterface[] ChildrenData
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryAbstractInterface"/> class with no arguments.
        /// </summary>
        public CategoryAbstractInterface()
        { }
    }
}
