using System;
using NodaTime;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Store;
using Athi.Whippet.Data;

namespace Athi.Whippet.Adobe.Magento.SalesRule
{
    /// <summary>
    /// Represents a sales rule in Magento.
    /// </summary>
    public interface ISalesRule: IMagentoEntity, IEqualityComparer<ISalesRule>, IMagentoRestEntity, IWhippetActiveEntity
    {
        /// <summary>
        /// Gets or sets the rule name.
        /// </summary>
        string Name
        { get; set; }
        
        /// <summary>
        /// Gets or sets the display labels for the sales rule.
        /// </summary>
        IEnumerable<SalesRuleLabel> StoreLabels
        { get; set; }

        /// <summary>
        /// Gets or sets the sales rule description.
        /// </summary>
        string Description
        { get; set; }

        /// <summary>
        /// Gets or sets the websites the rule applies to.
        /// </summary>
        IEnumerable<IStoreWebsite> Websites
        { get; set; }

        /// <summary>
        /// Gets or sets the effective date of the coupon.
        /// </summary>
        Instant? EffectiveDate
        { get; set; }

        /// <summary>
        /// Gets or sets the expiration date of the coupon.
        /// </summary>
        Instant? ExpirationDate
        { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of uses per customer.
        /// </summary>
        int UsesPerCustomer
        { get; set; }

        /// <summary>
        /// Gets or sets the sales rule condition.
        /// </summary>
        SalesRuleCondition Condition
        { get; set; }

        /// <summary>
        /// Gets or sets the action rule condition.
        /// </summary>
        SalesRuleCondition ActionCondition
        { get; set; }
        
        /// <summary>
        /// Specifies whether rule processing should stop once the current rule has been processed.
        /// </summary>
        bool StopRuleProcessing
        { get; set; }

        /// <summary>
        /// Specifies whether the sales rule is an advanced rule.
        /// </summary>
        bool IsAdvanced
        { get; set; }
        
        
    }
}
