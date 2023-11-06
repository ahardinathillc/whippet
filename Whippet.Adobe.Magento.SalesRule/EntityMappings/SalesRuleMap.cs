using System;
using FluentNHibernate.Mapping;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Data.NHibernate.UserTypes.NodaTime;

namespace Athi.Whippet.Adobe.Magento.SalesRule.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="SalesRule"/> objects.
    /// </summary>
    public class SalesRuleMap : MagentoFluentMap<SalesRule>
    {
        private const string TABLE_NAME = "salesrule";

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleMap"/> class with no arguments.
        /// </summary>
        public SalesRuleMap()
            : base(TABLE_NAME)
        {
            Id(sr => sr.RowID).GeneratedBy.Increment().Column("row_id");
            Map(sr => sr.RuleID).Not.Nullable().Column("rule_id");
            Map(sr => sr.Name).Nullable().Length(255).Column("name");
            Map(sr => sr.Description).Nullable().Length(this.GetMaximumStringLength()).Column("description");
            Map(sr => sr.FromDate).Nullable().CustomType<NullableInstantUserType>().Column("from_date");
            Map(sr => sr.ToDate).Nullable().CustomType<NullableInstantUserType>().Column("to_date");
            Map(sr => sr.UsesPerCustomer).Not.Nullable().Column("uses_per_customer");
            Map(sr => sr.Active).Not.Nullable().Column("is_active");
            Map(sr => sr.SerializedConditions).Nullable().Length(this.GetMaximumStringLength()).Column("conditions_serialized");
            Map(sr => sr.SerializedActions).Nullable().Length(this.GetMaximumStringLength()).Column("actions_serialized");
            Map(sr => sr.StopProcessingRules).Not.Nullable().Column("stop_rules_processing");
            Map(sr => sr.IsAdvanced).Not.Nullable().Column("is_advanced");
            Map(sr => sr.ProductIDs).Nullable().Length(this.GetMaximumStringLength()).Column("product_ids");
            Map(sr => sr.SortOrder).Not.Nullable().Column("sort_order");
            Map(sr => sr.SimpleAction).Nullable().Length(32).Column("simple_action");
            Map(sr => sr.DiscountAmount).Not.Nullable().Column("discount_amount");
            Map(sr => sr.DiscountQuantity).Nullable().Column("discount_qty");
            Map(sr => sr.DiscountStep).Not.Nullable().Column("discount_step");
            Map(sr => sr.ApplyToShipping).Not.Nullable().Column("apply_to_shipping");
            Map(sr => sr.TimesUsed).Not.Nullable().Column("times_used");
            Map(sr => sr.IsRSS).Not.Nullable().Column("is_rss");
            Map(sr => sr.IsCouponType).Not.Nullable().Column("coupon_type");
            Map(sr => sr.UseAutoGeneration).Not.Nullable().Column("use_auto_generation");
            Map(sr => sr.UsesPerCoupon).Not.Nullable().Column("uses_per_coupon");
            Map(sr => sr.IsSimpleFreeShipping).Not.Nullable().Column("simple_free_shipping");
            Map(sr => sr.CreatedIn).Not.Nullable().Column("created_in");
            Map(sr => sr.UpdatedIn).Not.Nullable().Column("updated_in");
            Map(sr => sr.UseCustomCouponText).Not.Nullable().Column("use_custom_coupon_text");
            Map(sr => sr.UseCouponOnHighestPricedItem).Not.Nullable().Column("use_coupon_highest_priced");
            Map(sr => sr.UseCouponOnHighestPricedItem2).Not.Nullable().Column("use_coupon_item_highest_price");
        }
    }
}

