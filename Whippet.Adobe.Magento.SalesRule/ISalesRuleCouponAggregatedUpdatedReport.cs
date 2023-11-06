using System;
using NodaTime;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.EAV;

namespace Athi.Whippet.Adobe.Magento.SalesRule
{
    /// <summary>
    /// Represents an aggregated report line item for an <see cref="ISalesRuleCoupon"/> usage report.
    /// </summary>
    public interface ISalesRuleCouponAggregatedUpdatedReport : ISalesRuleCouponAggregatedReport, IEqualityComparer<ISalesRuleCouponAggregatedUpdatedReport>
    { }
}
