using System;
using Newtonsoft.Json;
using System.Linq;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// Represents a tax rule in Magento.
    /// </summary>
    public interface ITaxRule : IMagentoEntity, IEqualityComparer<ITaxRule>
    {
        /// <summary>
        /// Specifies whether the subtotal of the order should be calculated with respect to the rule.
        /// </summary>
        bool CalculateSubtotal
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rule code.
        /// </summary>
        string Code
        { get; set; }

        /// <summary>
        /// Gets the customer tax classes that the rule applies to. This property is read-only.
        /// </summary>
        IEnumerable<ITaxClass> CustomerTaxClasses
        { get; }

        /// <summary>
        /// Gets or sets the customer tax class IDs that the rule applies to. Setting this property will reset all entries in <see cref="CustomerTaxClasses"/>.
        /// </summary>
        IEnumerable<int> CustomerTaxClassIDs
        { get; set; }

        /// <summary>
        /// Specifies the order in which the tax rule is applied.
        /// </summary>
        int SortOrder
        { get; set; }

        /// <summary>
        /// Specifies the priority of the tax rule.
        /// </summary>
        int Priority
        { get; set; }

        /// <summary>
        /// Gets the product tax classes that the rule applies to. This property is read-only.
        /// </summary>
        IEnumerable<ITaxClass> ProductTaxClasses
        { get; }

        /// <summary>
        /// Gets or sets the product tax class IDs that the rule applies to. Setting this property will reset all entries in <see cref="ProductTaxClasses"/>.
        /// </summary>
        IEnumerable<int> ProductTaxClassIDs
        { get; set; }

        /// <summary>
        /// Gets the tax rates that are applied in the rule. This property is read-only.
        /// </summary>
        IEnumerable<ITaxRate> TaxRates
        { get; }

        /// <summary>
        /// Gets or sets the product tax rate IDs that are applied in the rule. Setting this property will reset all entries in <see cref="TaxRates"/>.
        /// </summary>
        IEnumerable<int> TaxRateIDs
        { get; set; }
    }
}

