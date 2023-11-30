using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.EAV;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Interface that provides metadata about a Magento product.
    /// </summary>
    public class ProductAttributeInterface : IExtensionInterface, IExtensionAttributes<AttributeExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public AttributeExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Specifies whether What You See Is What You Get (WYSIWYG) is enabled.
        /// </summary>
        [JsonProperty("is_wysiwyg_enabled")]
        public bool WYSIWYG
        { get; set; }
        
        /// <summary>
        /// Specifies whether HTML is allowed on the frontend.
        /// </summary>
        [JsonProperty("is_html_allowed_on_front")]
        public bool AllowHTML
        { get; set; }
        
        public bool UsedForSortBy
        
    }
}
