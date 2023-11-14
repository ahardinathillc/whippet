using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.TaxRates;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that provides information about an individual dynamically calculated total line item in Magento.
    /// </summary>
    public class CartTotalSegmentInterface : IExtensionInterface, IExtensionAttributes<CartTotalSegmentExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the code of the segment.
        /// </summary>
        [JsonProperty("code")]
        public string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the total title.
        /// </summary>
        [JsonProperty("title")]
        public string Title
        { get; set; }

        /// <summary>
        /// Gets or sets the total value.
        /// </summary>
        [JsonProperty("value")]
        public decimal Value
        { get; set; }

        /// <summary>
        /// Gets or sets the display area code.
        /// </summary>
        [JsonProperty("area")]
        public string Area
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CartTotalSegmentExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CartTotalSegmentInterface"/> class with no arguments. 
        /// </summary>
        public CartTotalSegmentInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CartTotalSegmentInterface"/> class with the specified parameters. 
        /// </summary>
        /// <param name="code">Segment code.</param>
        /// <param name="title">Total title.</param>
        /// <param name="value">Total value.</param>
        /// <param name="area">Display area code.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public CartTotalSegmentInterface(string code, string title, decimal value, string area, CartTotalSegmentExtensionInterface extensionAttributes)
            : this()
        {
            Code = code;
            Title = title;
            Value = value;
            Area = area;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
