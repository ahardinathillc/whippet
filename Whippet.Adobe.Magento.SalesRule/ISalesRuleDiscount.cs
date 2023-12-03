using System;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.SalesRule
{
    /// <summary>
    /// Represents a discount that can be applied to a Magento product or SKU.
    /// </summary>
    public interface ISalesRuleDiscount : IMagentoEntity, IEqualityComparer<ISalesRuleDiscount>, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the rule label.
        /// </summary>
        string Label
        { get; set; }
        
        /// <summary>
        /// Gets or sets the discount data.
        /// </summary>
        IEnumerable<SalesRuleDiscountData> Discounts
        { get; set; }
    }
}
