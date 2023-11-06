using System;
using Athi.Whippet.Adobe.Magento.Extensions;

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
        /// <param name="salesRule"><see cref="ISalesRule"/> object to convert.</param>
        /// <returns><see cref="SalesRule"/> object.</returns>
        public static SalesRule ToSalesRule(this ISalesRule salesRule)
        {
            SalesRule sr = null;

            if (salesRule != null)
            {
                if (salesRule is SalesRule)
                {
                    sr = (SalesRule)(salesRule);
                }
                else
                {
                    sr = new SalesRule();
                    sr.Active = salesRule.Active;
                    sr.ApplyToShipping = salesRule.ApplyToShipping;
                    sr.CreatedIn = salesRule.CreatedIn;
                    sr.Description = salesRule.Description;
                    sr.DiscountAmount = salesRule.DiscountAmount;
                    sr.DiscountQuantity = salesRule.DiscountQuantity;
                    sr.DiscountStep = salesRule.DiscountStep;
                    sr.FromDate = salesRule.FromDate;
                    sr.ID = salesRule.ID;
                    sr.IsAdvanced = salesRule.IsAdvanced;
                    sr.IsCouponType = salesRule.IsCouponType;
                    sr.IsRSS = salesRule.IsRSS;
                    sr.IsSimpleFreeShipping = salesRule.IsSimpleFreeShipping;
                    sr.Name = salesRule.Name;
                    sr.ProductIDs = salesRule.ProductIDs;
                    sr.RowID = salesRule.RowID;
                    sr.RuleID = salesRule.RuleID;
                    sr.SerializedActions = salesRule.SerializedActions;
                    sr.SerializedConditions = salesRule.SerializedConditions;
                    sr.Server = salesRule.Server.ToMagentoServer();
                    sr.SimpleAction = salesRule.SimpleAction;
                    sr.SortOrder = salesRule.SortOrder;
                    sr.StopProcessingRules = salesRule.StopProcessingRules;
                    sr.TimesUsed = salesRule.TimesUsed;
                    sr.ToDate = salesRule.ToDate;
                    sr.UpdatedIn = salesRule.UpdatedIn;
                    sr.UseAutoGeneration = salesRule.UseAutoGeneration;
                    sr.UseCouponOnHighestPricedItem = salesRule.UseCouponOnHighestPricedItem;
                    sr.UseCouponOnHighestPricedItem2 = salesRule.UseCouponOnHighestPricedItem2;
                    sr.UseCustomCouponText = salesRule.UseCustomCouponText;
                    sr.UsesPerCoupon = salesRule.UsesPerCoupon;
                    sr.UsesPerCustomer = salesRule.UsesPerCustomer;
                }
            }

            return sr;
        }
    }
}

