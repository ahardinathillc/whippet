using System;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Data.NHibernate.UserTypes.NodaTime;
using Athi.Whippet.Data.NHibernate.UserTypes.Adobe.Magento;
using Athi.Whippet.Adobe.Magento.EAV;

namespace Athi.Whippet.Adobe.Magento.SalesRule.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="SalesRuleCouponAggregatedReportMap"/> objects.
    /// </summary>
    public class SalesRuleCouponAggregatedReportMap : MagentoFluentMap<SalesRuleCouponAggregatedReport>
    {
        private const string TABLE_NAME = "salesrule_coupon_aggregated";

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleCouponAggregatedReportMap"/> class with no arguments.
        /// </summary>
        public SalesRuleCouponAggregatedReportMap()
            : base(TABLE_NAME)
        {
            Id(src => src.ReportEntryID).GeneratedBy.Increment().Column("id");
            Map(src => src.Period).Not.Nullable().Column("period");
            Map(src => src.OrderStatus).Nullable().Length(50).Column("order_status");
            Map(src => src.CouponCode).Nullable().Length(50).Column("coupon_code");
            Map(src => src.CouponUses).Not.Nullable().Column("coupon_uses");
            Map(src => src.Subtotal).Not.Nullable().Column("subtotal_amount");
            Map(src => src.Discount).Not.Nullable().Column("discount_amount");
            Map(src => src.Total).Not.Nullable().Column("total_amount");
            Map(src => src.Subtotal_Actual).Not.Nullable().Column("subtotal_amount_actual");
            Map(src => src.Discount_Actual).Not.Nullable().Column("discount_amount_actual");
            Map(src => src.Total_Actual).Not.Nullable().Column("total_amount_actual");
            Map(src => src.RuleName).Nullable().Length(255).Column("rule_name");

            References<Store>(src => src.Store).Nullable().Column("store_id").LazyLoad(Laziness.False);
        }
    }
}

