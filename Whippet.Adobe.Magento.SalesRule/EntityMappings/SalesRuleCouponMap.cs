using System;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Data.NHibernate.UserTypes.NodaTime;
using Athi.Whippet.Data.NHibernate.UserTypes.Adobe.Magento;

namespace Athi.Whippet.Adobe.Magento.SalesRule.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="SalesRuleCoupon"/> objects.
    /// </summary>
    public class SalesRuleCouponMap : MagentoFluentMap<SalesRuleCoupon>
    {
        private const string TABLE_NAME = "salesrule_coupon";

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleCouponMap"/> class with no arguments.
        /// </summary>
        public SalesRuleCouponMap()
            : base(TABLE_NAME)
        {
            Id(src => src.CouponID).GeneratedBy.Increment().Column("coupon_id");
            Map(src => src.Code).Not.Nullable().Length(255).Column("code");
            Map(src => src.UsageLimit).Nullable().Column("usage_limit");
            Map(src => src.UsagePerCustomerLimit).Nullable().Column("usage_per_customer");
            Map(src => src.TimesUsed).Not.Nullable().Column("times_used");
            Map(src => src.ExpirationDate).Nullable().CustomType<NullableInstantUserType>().Column("expiration_date");
            Map(src => src.IsPrimary).Nullable().Column("is_primary");
            Map(src => src.CreatedAt).Nullable().CustomType<NullableInstantUserType>().Column("created_at");
            Map(src => src.Type).Nullable().Column("type");
            Map(src => src.GeneratedByDotMailerIndicator).Nullable().Column("generated_by_dotmailer");
            //Map(src => src.Rule).Not.Nullable().CustomType<SalesRuleShallowObjectUserType>().Column("rule_id");
            Map(src => src.RuleID).Not.Nullable().Column("rule_id");
        }
    }
}

