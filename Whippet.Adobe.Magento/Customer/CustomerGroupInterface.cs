using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Customer
{
    /// <summary>
    /// Interface that provides information about a Magento customer group.
    /// </summary>
    public class CustomerGroupInterface : IExtensionInterface, IExtensionAttributes<CustomerGroupExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the customer group ID.
        /// </summary>
        [JsonProperty("id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the customer group code.
        /// </summary>
        [JsonProperty("code")]
        public string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the tax class ID.
        /// </summary>
        [JsonProperty("tax_class_id")]
        public int TaxClassID
        { get; set; }

        /// <summary>
        /// Gets or sets the tax class name.
        /// </summary>
        [JsonProperty("tax_class_name")]
        public string TaxClassName
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CustomerGroupExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerGroupInterface"/> class with no arguments.
        /// </summary>
        public CustomerGroupInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerGroupInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Customer group ID.</param>
        /// <param name="code">Customer group code.</param>
        /// <param name="taxClassId">Tax class ID.</param>
        /// <param name="taxClassName">Tax class name.</param>
        /// <param name="extensionAttributes">Extension attributes of the current instance.</param>
        public CustomerGroupInterface(int id, string code, int taxClassId, string taxClassName, CustomerGroupExtensionInterface extensionAttributes)
            : this()
        {
            ID = id;
            Code = code;
            TaxClassID = taxClassId;
            TaxClassName = taxClassName;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
