using System;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.SalesRule.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ISalesRuleCoupon"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ISalesRuleCouponExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ISalesRuleCoupon"/> object to a <see cref="SalesRuleCoupon"/> object.
        /// </summary>
        /// <param name="coupon"><see cref="ISalesRuleCoupon"/> object to convert.</param>
        /// <returns><see cref="SalesRuleCoupon"/> object.</returns>
        public static SalesRuleCoupon ToSalesRuleCoupon(this ISalesRuleCoupon coupon)
        {
            SalesRuleCoupon sr = null;

            if (coupon != null)
            {
                if (coupon is SalesRuleCoupon)
                {
                    sr = (SalesRuleCoupon)(coupon);
                }
                else
                {
                    sr = new SalesRuleCoupon();
                    sr.Code = coupon.Code;
                    sr.CouponID = coupon.CouponID;
                    sr.CreatedAt = coupon.CreatedAt;
                    sr.ExpirationDate = coupon.ExpirationDate;
                    sr.GeneratedByDotMailer = coupon.GeneratedByDotMailer;
                    sr.ID = coupon.ID;
                    sr.IsPrimary = coupon.IsPrimary;
                    sr.Rule = coupon.Rule.ToSalesRule();
                    sr.Server = coupon.Server.ToMagentoServer();
                    sr.TimesUsed = coupon.TimesUsed;
                    sr.Type = coupon.Type;
                    sr.UsageLimit = coupon.UsageLimit;
                    sr.UsagePerCustomerLimit = coupon.UsagePerCustomerLimit;
                }
            }

            return sr;
        }
    }
}

