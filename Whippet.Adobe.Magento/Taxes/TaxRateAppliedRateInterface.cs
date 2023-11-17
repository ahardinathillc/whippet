using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// Interface that provides information about a tax rate as it is applied to an entity in Magento.
    /// </summary>
    public class TaxRateAppliedRateInterface : IExtensionInterface, IExtensionAttributes<TaxRateAppliedRateExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the tax rate code.
        /// </summary>
        [JsonProperty("code")]
        public string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rate title.
        /// </summary>
        [JsonProperty("title")]
        public string Title
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rate percentage.
        /// </summary>
        [JsonProperty("percent")]
        public decimal Percent
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public TaxRateAppliedRateExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateAppliedRateInterface"/> class with no arguments.
        /// </summary>
        public TaxRateAppliedRateInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateAppliedRateInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="code">Tax rate code.</param>
        /// <param name="title">Tax rate title.</param>
        /// <param name="percent">Tax rate percentage.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public TaxRateAppliedRateInterface(string code, string title, decimal percent, TaxRateAppliedRateExtensionInterface extensionAttributes)
            : this()
        {
            Code = code;
            Title = title;
            Percent = percent;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
