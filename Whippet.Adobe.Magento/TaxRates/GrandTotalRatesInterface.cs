using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.TaxRates
{
    /// <summary>
    /// Interface that provides information about tax totals and percentages for a Magento order.
    /// </summary>
    public class GrandTotalRatesInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the tax percentage value.
        /// </summary>
        [JsonProperty("percent")]
        public string Percent
        { get; set; }

        /// <summary>
        /// Gets or sets the rate title.
        /// </summary>
        [JsonProperty("title")]
        public string Title
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GrandTotalRatesInterface"/> class with no arguments.
        /// </summary>
        public GrandTotalRatesInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GrandTotalRatesInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="percent">Tax percentage value.</param>
        /// <param name="title">Rate title.</param>
        public GrandTotalRatesInterface(string percent, string title)
            : this()
        {
            Percent = percent;
            Title = title;
        }
    }
}
