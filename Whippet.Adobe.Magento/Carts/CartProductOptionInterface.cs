using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that provides information about a Magento cart's product options.
    /// </summary>
    public class CartProductOptionInterface : IExtensionInterface, IExtensionAttributes<CartProductOptionExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CartProductOptionExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CartProductOptionInterface"/> class with no arguments.
        /// </summary>
        public CartProductOptionInterface()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CartProductOptionInterface"/> class with no arguments.
        /// </summary>
        /// <param name="extensionAttributes">Extension attributes of the object.</param>
        public CartProductOptionInterface(CartProductOptionExtensionInterface extensionAttributes)
            : this()
        { }
    }
}
