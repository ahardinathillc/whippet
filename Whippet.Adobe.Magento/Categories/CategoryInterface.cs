using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Categories
{
    /// <summary>
    /// Interface that provides information about a Magento store's category.
    /// </summary>
    public class CategoryInterface : IExtensionInterface, IExtensionAttributes<CategoryExtensionInterface>, ICustomAttributes
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
        /// Gets or sets the current category's children delimited by comma.
        /// </summary>
        [JsonProperty("children")]
        public string Children
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the category was created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the category was last updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the category's full path.
        /// </summary>
        [JsonProperty("path")]
        public string Path
        { get; set; }

        /// <summary>
        /// Gets or sets the available sort by for the category.
        /// </summary>
        [JsonProperty("available_sort_by")]
        public string[] AvailableSortBy
        { get; set; }

        /// <summary>
        /// Specifies whether the category is included in the menu.
        /// </summary>
        [JsonProperty("include_in_menu")]
        public bool IncludeInMenu
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CategoryExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Gets or sets the custom attributes for the current instance.
        /// </summary>
        [JsonProperty("custom_attributes")]
        public CustomAttributeInterface[] CustomAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryInterface"/> class with no arguments.
        /// </summary>
        public CategoryInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryInterface"/> class with the specified <see cref="CategoryAbstractInterface"/> object.
        /// </summary>
        /// <param name="category"><see cref="CategoryAbstractInterface"/> object to initialize with.</param>
        public CategoryInterface(CategoryAbstractInterface category)
            : this()
        {
            if (category != null)
            {
                ID = category.ID;
                ParentID = category.ParentID;
                Name = category.Name;
                Active = category.Active;
                Position = category.Position;
                Level = category.Level;
            }
        }
    }
}
