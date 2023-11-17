using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// Interface that provides information about a Magento tax class.
    /// </summary>
    public class TaxClassInterface : IExtensionInterface, IExtensionAttributes<TaxClassExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the tax class ID.
        /// </summary>
        [JsonProperty("class_id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the tax class name.
        /// </summary>
        [JsonProperty("class_name")]
        public string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the tax class type.
        /// </summary>
        [JsonProperty("class_type")]
        public string Type
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance. 
        /// </summary>
        [JsonProperty("extension_attributes")]
        public TaxClassExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxClassInterface"/> class with no arguments.
        /// </summary>
        public TaxClassInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxClassInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Tax class ID.</param>
        /// <param name="name">Tax class name.</param>
        /// <param name="type">Tax class type.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public TaxClassInterface(int id, string name, string type, TaxClassExtensionInterface extensionAttributes)
            : this()
        {
            ID = id;
            Name = name;
            Type = type;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
