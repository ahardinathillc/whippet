using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Sales.Taxes
{
    /// <summary>
    /// Interface that provides information about tax rates and the subsequent taxed amount for Magento orders.
    /// </summary>
    public class SalesOrderTaxGrandTotalDetailsInterface : IExtensionInterface
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
        public SalesOrderTaxGrandTotalRatesInterface OrderTax
        { get; set; }

        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        [JsonProperty("group_id")]
        public int GroupID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderTaxGrandTotalDetailsInterface"/> class with no arguments.
        /// </summary>
        public SalesOrderTaxGrandTotalDetailsInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderTaxGrandTotalDetailsInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="amount">Tax amount value.</param>
        /// <param name="orderTax">Tax rates information.</param>
        /// <param name="groupId">Group identifier.</param>
        public SalesOrderTaxGrandTotalDetailsInterface(decimal amount, SalesOrderTaxGrandTotalRatesInterface orderTax, int groupId)
            : this()
        {
            Amount = amount;
            OrderTax = orderTax;
            GroupID = groupId;
        }
    }
}
