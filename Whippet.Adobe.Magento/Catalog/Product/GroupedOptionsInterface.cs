using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Product
{
    /// <summary>
    /// Interface that provides information about grouped Magento products.
    /// </summary>
    public class GroupedOptionsInterface : IExtensionInterface, IExtensionAttributes<GroupedOptionsExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the associated product ID.
        /// </summary>
        [JsonProperty("id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the associated product quantity.
        /// </summary>
        [JsonProperty("qty")]
        public int Quantity
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current object.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public GroupedOptionsExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupedOptionsInterface"/> class with no arguments.
        /// </summary>
        public GroupedOptionsInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupedOptionsInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Associated product ID.</param>
        /// <param name="quantity">Associated product quantity.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public GroupedOptionsInterface(int id, int quantity, GroupedOptionsExtensionInterface extensionAttributes)
            : this()
        {
            ID = id;
            Quantity = quantity;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
