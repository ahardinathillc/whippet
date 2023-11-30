using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products.Configurable
{
    /// <summary>
    /// Interface that represents configurable options that can be applied to a Magento product.
    /// </summary>
    public class ConfigurableProductOptionInterface : IExtensionInterface, IExtensionAttributes<ConfigurableProductOptionExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the option ID.
        /// </summary>
        [JsonProperty("id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the attribute ID.
        /// </summary>
        [JsonProperty("attribute_id")]
        public string AttributeID
        { get; set; }

        /// <summary>
        /// Gets or sets the option label.
        /// </summary>
        [JsonProperty("label")]
        public string Label
        { get; set; }

        /// <summary>
        /// Gets or sets the position of the option.
        /// </summary>
        [JsonProperty("position")]
        public int Position
        { get; set; }

        /// <summary>
        /// Specifies whether the option should use the default value.
        /// </summary>
        [JsonProperty("is_use_default")]
        public bool UseDefault
        { get; set; }

        /// <summary>
        /// Gets or sets the product options.
        /// </summary>
        [JsonProperty("values")]
        public ConfigurableProductOptionValueInterface[] Values
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public ConfigurableProductOptionExtensionInterface ExtensionAttributes
        { get; set; }

        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        [JsonProperty("product_id")]
        public int ProductID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurableProductOptionInterface"/> class with no arguments. 
        /// </summary>
        public ConfigurableProductOptionInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurableProductOptionInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Option ID.</param>
        /// <param name="attributeId">Attribute ID.</param>
        /// <param name="label">Option label.</param>
        /// <param name="position">Option position.</param>
        /// <param name="useDefault">Specifies whether to use the default value.</param>
        /// <param name="values">Product options.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public ConfigurableProductOptionInterface(int id, string attributeId, string label, int position, bool useDefault, IEnumerable<ConfigurableProductOptionValueInterface> values, ConfigurableProductOptionExtensionInterface extensionAttributes)
            : this()
        {
            ID = id;
            AttributeID = attributeId;
            Label = label;
            Position = position;
            UseDefault = useDefault;
            Values = (values == null) ? null : values.ToArray();
            ExtensionAttributes = extensionAttributes;
        }
    }
}
