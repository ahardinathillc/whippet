using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Orders.Taxes
{
    /// <summary>
    /// Interface that provides information about taxes that are applied to an entity in Magento.
    /// </summary>
    public class SalesOrderAppliedTaxTaxInterface : IExtensionInterface, IExtensionAttributes<SalesOrderAppliedTaxTaxExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the tax code.
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
        /// Gets or sets the tax amount.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount in base currency.
        /// </summary>
        [JsonProperty("base_amount")]
        public decimal AmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public SalesOrderAppliedTaxTaxExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderAppliedTaxTaxInterface"/> class with no arguments.
        /// </summary>
        public SalesOrderAppliedTaxTaxInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderAppliedTaxTaxInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="code">Tax code.</param>
        /// <param name="title">Tax rate title.</param>
        /// <param name="percent">Tax rate percentage.</param>
        /// <param name="amount">Tax amount.</param>
        /// <param name="amountBase">Tax amount in base currency.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public SalesOrderAppliedTaxTaxInterface(string code, string title, decimal percent, decimal amount, decimal amountBase, SalesOrderAppliedTaxTaxExtensionInterface extensionAttributes)
            : this()
        {
            Code = code;
            Title = title;
            Percent = percent;
            Amount = amount;
            AmountBase = amountBase;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
