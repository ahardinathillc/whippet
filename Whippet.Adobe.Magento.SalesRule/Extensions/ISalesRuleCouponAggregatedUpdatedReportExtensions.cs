using System;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.EAV.Extensions;

namespace Athi.Whippet.Adobe.Magento.SalesRule.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ISalesRuleCouponAggregatedUpdatedReport"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ISalesRuleCouponAggregatedUpdatedReportExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ISalesRuleCouponAggregatedUpdatedReport"/> object to a <see cref="SalesRuleCouponAggregatedUpdatedReport"/> object.
        /// </summary>
        /// <param name="report"><see cref="ISalesRuleCouponAggregatedUpdatedReport"/> object to convert.</param>
        /// <returns><see cref="SalesRuleCouponAggregatedUpdatedReport"/> object.</returns>
        public static SalesRuleCouponAggregatedUpdatedReport ToSalesRuleCouponAggregatedUpdatedReport(this ISalesRuleCouponAggregatedUpdatedReport report)
        {
            SalesRuleCouponAggregatedUpdatedReport srcar = null;

            if (report != null)
            {
                if (report is SalesRuleCouponAggregatedUpdatedReport)
                {
                    srcar = (SalesRuleCouponAggregatedUpdatedReport)(report);
                }
                else
                {
                    srcar = new SalesRuleCouponAggregatedUpdatedReport();
                    srcar.CouponCode = report.CouponCode;
                    srcar.CouponUses = report.CouponUses;
                    srcar.Discount = report.Discount;
                    srcar.Discount_Actual = report.Discount_Actual;
                    srcar.OrderStatus = report.OrderStatus;
                    srcar.Period = report.Period;
                    srcar.ReportEntryID = report.ReportEntryID;
                    srcar.RuleName = report.RuleName;
                    srcar.Server = report.Server.ToMagentoServer();
                    srcar.Store = report.Store.ToStore();
                    srcar.Subtotal = report.Subtotal;
                    srcar.Subtotal_Actual = report.Subtotal_Actual;
                    srcar.Total = report.Total;
                    srcar.Total_Actual = report.Total_Actual;
                }
            }

            return srcar;
        }
    }
}

