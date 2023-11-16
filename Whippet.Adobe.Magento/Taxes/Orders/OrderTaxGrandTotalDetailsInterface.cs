using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Taxes.Orders
{
    /// <summary>
    /// Interface that provides information about tax rates and the subsequent taxed amount for Magento orders.
    /// </summary>
    public class OrderTaxGrandTotalDetailsInterface : IExtensionInterface
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
        public OrderTaxGrandTotalRatesInterface OrderTax
        { get; set; }

        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        [JsonProperty("group_id")]
        public int GroupID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderTaxGrandTotalDetailsInterface"/> class with no arguments.
        /// </summary>
        public OrderTaxGrandTotalDetailsInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderTaxGrandTotalDetailsInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="amount">Tax amount value.</param>
        /// <param name="orderTax">Tax rates information.</param>
        /// <param name="groupId">Group identifier.</param>
        public OrderTaxGrandTotalDetailsInterface(decimal amount, OrderTaxGrandTotalRatesInterface orderTax, int groupId)
            : this()
        {
            Amount = amount;
            OrderTax = orderTax;
            GroupID = groupId;
        }
    }
}
