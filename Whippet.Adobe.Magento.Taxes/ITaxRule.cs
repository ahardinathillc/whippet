using System;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// Represents a tax rule in Magento.
    /// </summary>
    public interface ITaxRule : IMagentoEntity, IEqualityComparer<ITaxRule>, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the tax rule code.
        /// </summary>
        string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        int Priority
        { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        int Position
        { get; set; }

        /// <summary>
        /// Gets or sets the customer tax classes.
        /// </summary>
        IEnumerable<ITaxClass> CustomerTaxClasses
        { get; set; }

        /// <summary>
        /// Gets or sets the product tax classes.
        /// </summary>
        IEnumerable<ITaxClass> ProductTaxClasses
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rates that the rule applies.
        /// </summary>
        IEnumerable<ITaxRate> TaxRates
        { get; set; }

        /// <summary>
        /// Specifies whether the subtotal should be calculated for the rule.
        /// </summary>
        bool CalculateSubtotal
        { get; set; }        
    }
}
