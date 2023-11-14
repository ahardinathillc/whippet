using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.TaxRates
{
    /// <summary>
    /// Interface that provides information about tax rates and the subsequent taxed amount for Magento orders.
    /// </summary>
    public class GrandTotalDetailsInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the tax amount.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rates information.
        /// </summary>
        [JsonProperty("rates")]
        public GrandTotalRatesInterface TaxRates
        { get; set; }

        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        [JsonProperty("group_id")]
        public int GroupID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GrandTotalDetailsInterface"/> class with no arguments.
        /// </summary>
        public GrandTotalDetailsInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GrandTotalDetailsInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="amount">Tax amount value.</param>
        /// <param name="taxRates">Tax rates information.</param>
        /// <param name="groupId">Group identifier.</param>
        public GrandTotalDetailsInterface(decimal amount, GrandTotalRatesInterface taxRates, int groupId)
            : this()
        {
            Amount = amount;
            TaxRates = taxRates;
            GroupID = groupId;
        }
    }
}
