﻿using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Taxes.Orders
{
    /// <summary>
    /// Interface that provides information about tax totals and percentages for a Magento order.
    /// </summary>
    public class OrderTaxGrandTotalRatesInterface : IExtensionInterface
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
        /// Initializes a new instance of the <see cref="OrderTaxGrandTotalRatesInterface"/> class with no arguments.
        /// </summary>
        public OrderTaxGrandTotalRatesInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderTaxGrandTotalRatesInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="percent">Tax percentage value.</param>
        /// <param name="title">Rate title.</param>
        public OrderTaxGrandTotalRatesInterface(string percent, string title)
            : this()
        {
            Percent = percent;
            Title = title;
        }
    }
}