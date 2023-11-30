using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.EAV
{
    /// <summary>
    /// Interface that provides extra information to Magento attributes.
    /// </summary>
    public class AttributeExtensionInterface : IExtensionInterface
    {
        /// <summary>
        /// Specifies whether the attribute is enabled for Magento's page builder.
        /// </summary>
        [JsonProperty("is_pagebuilder_enabled")]
        public bool PageBuilderEnabled
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeExtensionInterface"/> class with no arguments.
        /// </summary>
        public AttributeExtensionInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeExtensionInterface"/> class with the specified parameter.
        /// </summary>
        /// <param name="pageBuilderEnabled">Specifies whether the attribute is enabled for Magento's page builder.</param>
        public AttributeExtensionInterface(bool pageBuilderEnabled)
            : this()
        {
            PageBuilderEnabled = pageBuilderEnabled;
        }
    }
}
