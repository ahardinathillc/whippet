using System;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.SalesRule.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ISalesRuleDiscount"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ISalesRuleDiscountExtensions
    {
        public static SalesRuleDiscount ToSalesRuleDiscount(this ISalesRuleDiscount discount)
        {
            SalesRuleDiscount srd = null;

            if (discount is SalesRuleDiscount)
            {
                srd = (SalesRuleDiscount)(discount);
            }
            else if (discount != null)
            {
                srd = new SalesRuleDiscount();
                srd.ID = discount.ID;
                srd.Discounts = (discount.Discounts == null) ? null : discount.Discounts.Select(d => d);
                srd.Label = discount.Label;
                srd.RestEndpoint = discount.RestEndpoint.ToMagentoRestEndpoint();
                srd.Server = discount.Server.ToMagentoServer();
            }

            return srd;
        }
    }
}
