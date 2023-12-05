using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.Taxes;

namespace Athi.Whippet.Adobe.Magento.Sales.Taxes
{
    /// <summary>
    /// Interface that provides extra information to applied taxes to a Magento entity.
    /// </summary>
    public class SalesOrderAppliedTaxExtensionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the tax rates that are applied to the entity.
        /// </summary>
        [JsonProperty("rates")]
        public TaxRateAppliedRateInterface[] Rates
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderAppliedTaxInterface"/> class with no arguments.
        /// </summary>
        public SalesOrderAppliedTaxExtensionInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderAppliedTaxInterface"/> class with the specified collection of <see cref="TaxRateAppliedRateInterface"/> objects.
        /// </summary>
        /// <param name="rates"><see cref="IEnumerable{T}"/> collection of <see cref="TaxRateAppliedRateInterface"/> objects.</param>
        public SalesOrderAppliedTaxExtensionInterface(IEnumerable<TaxRateAppliedRateInterface> rates)
            : this()
        {
            Rates = (rates == null) ? null : rates.ToArray();
        }
    }
}
