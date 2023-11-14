using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento
{
    /// <summary>
    /// Provides support to Magento interface objects that support custom attributes.
    /// </summary>
    public interface ICustomAttributes
    {
        /// <summary>
        /// Gets or sets the custom attributes of the current instance.
        /// </summary>
        [JsonProperty("custom_attributes")]
         CustomAttributeInterface[] CustomAttributes
        { get; set; }
    }
}
