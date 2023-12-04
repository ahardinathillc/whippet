using System;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Adobe.Magento.Store.Extensions;

namespace Athi.Whippet.Adobe.Magento.SalesRule.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ISalesRule"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ISalesRuleExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ISalesRule"/> object to a <see cref="SalesRule"/> object.
        /// </summary>
        /// <param name="rule"><see cref="ISalesRule"/> object.</param>
        /// <returns><see cref="SalesRule"/> object.</returns>
        public static SalesRule ToSalesRule(this ISalesRule rule)
        {
            SalesRule sr = null;

            if (rule is SalesRule)
            {
                sr = (SalesRule)(rule);
            }
            else if (rule != null)
            {
                sr = new SalesRule();
                sr.Name = rule.Name;
                sr.StoreLabels = (rule.StoreLabels == null) ? null : rule.StoreLabels.Select(sl => sl);
                sr.Description = rule.Description;
                sr.Websites = (rule.Websites == null) ? null : rule.Websites.Select(w => w.ToStoreWebsite());
                sr.CustomerGroups = (rule.CustomerGroups == null) ? null : rule.CustomerGroups.Select(cg => cg.ToCustomerGroup());
                sr.EffectiveDate = rule.EffectiveDate;
                sr.ExpirationDate = rule.ExpirationDate;
                sr.UsesPerCustomer = rule.UsesPerCustomer;
                sr.Condition = rule.Condition;
                sr.ActionCondition = rule.ActionCondition;
                sr.StopRulesProcessing = rule.StopRulesProcessing;
                sr.IsAdvanced = rule.IsAdvanced;
                sr.ProductIDs = (rule.ProductIDs == null) ? null : rule.ProductIDs.Select(pid => pid);
                sr.SortOrder = rule.SortOrder;
                sr.SimpleAction = rule.SimpleAction;
                sr.DiscountAmount = rule.DiscountAmount;
                sr.DiscountQuantity = rule.DiscountQuantity;
                sr.Step = rule.Step;
                sr.AppliesToShipping = rule.AppliesToShipping;
                sr.TimesUsed = rule.TimesUsed;
                sr.IsRSS = rule.IsRSS;
                sr.CouponType = rule.CouponType;
                sr.AutoGenerateCoupon = rule.AutoGenerateCoupon;
                sr.UsesPerCoupon = rule.UsesPerCoupon;
                sr.SimpleFreeShipping = rule.SimpleFreeShipping;
                sr.RewardPointsDelta = rule.RewardPointsDelta;
            }

            return sr;
        }
    }
}
