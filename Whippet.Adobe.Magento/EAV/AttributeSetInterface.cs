using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Interface that provides information about multiple Magento attributes.
    /// </summary>
    public class AttributeSetInterface : IExtensionInterface, IExtensionAttributes<AttributeSetExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the attribute set ID.
        /// </summary>
        [JsonProperty("attribute_set_id")]
        public int ID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the attribute set name.
        /// </summary>
        [JsonProperty("attribute_set_name")]
        public string Name
        { get; set; }
        
        /// <summary>
        /// Gets or sets the attribute set sort order index.
        /// </summary>
        [JsonProperty("sort_order")]
        public int SortOrder
        { get; set; }

        /// <summary>
        /// Gets or sets the entity type ID.
        /// </summary>
        [JsonProperty("entity_type_id")]
        public int EntityTypeID
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public AttributeSetExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeSetInterface"/> class with no arguments.
        /// </summary>
        public AttributeSetInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeSetInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Attribute set ID.</param>
        /// <param name="name">Attribute set name.</param>
        /// <param name="sortOrder">Attribute set sort order.</param>
        /// <param name="entityTypeId">Entity type ID.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public AttributeSetInterface(int id, string name, int sortOrder, int entityTypeId, AttributeSetExtensionInterface extensionAttributes)
            : this()
        {
            ID = id;
            Name = name;
            SortOrder = sortOrder;
            EntityTypeID = entityTypeId;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
