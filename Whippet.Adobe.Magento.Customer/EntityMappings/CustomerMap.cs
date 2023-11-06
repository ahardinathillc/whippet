using System;
using FluentNHibernate.Mapping;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Data.NHibernate.UserTypes.NodaTime;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Taxes;
using Athi.Whippet.Adobe.Magento.EAV;

namespace Athi.Whippet.Adobe.Magento.Customer.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="Customer"/> objects.
    /// </summary>
    public class CustomerMap : MagentoFluentMap<Customer>
    {
        private const string TABLE_NAME = "customer_entity";

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerMap"/> class with no arguments.
        /// </summary>
        public CustomerMap()
            : base(TABLE_NAME)
        {
            Id(cs => cs.EntityID).GeneratedBy.Increment().Column("entity_id");
            Map(cs => cs.Confirmation).Nullable().Length(64).Column("confirmation");
            Map(cs => cs.CreatedAt).Not.Nullable().CustomType<InstantUserType>().Column("created_at");
            Map(cs => cs.CreatedIn).Nullable().Length(255).Column("created_in");
            References<CustomerAddress>(cs => cs.DefaultBillingAddress).Nullable().Column("default_billing");
            References<CustomerAddress>(cs => cs.DefaultShippingAddress).Nullable().Column("default_shipping");
            Map(cs => cs.DisableAutoGroupChange).Not.Nullable().Column("disable_auto_group_change");
            Map(cs => cs.DateOfBirth).Nullable().CustomType<InstantUserType>().Column("dob");
            Map(cs => cs.Email).Nullable().Length(255).Column("email");
            Map(cs => cs.FailedLoginAttempts).Nullable().Column("failures_num");
            Map(cs => cs.FirstFailedLoginAttempt).Nullable().CustomType<InstantUserType>().Column("first_failure");
            Map(cs => cs.FirstName).Nullable().Length(255).Column("firstname");
            Map(cs => cs.Gender).Nullable().Column("gender");
            References<CustomerGroup>(cs => cs.Group).Not.Nullable().Column("group_id");
            Map(cs => cs.IncrementID).Nullable().Length(50).Column("increment_id");
            Map(cs => cs.Active).Not.Nullable().Column("is_active");
            Map(cs => cs.LastName).Nullable().Length(255).Column("lastname");
            Map(cs => cs.LegacyCustomerNumber).Nullable().Column("legacy_customer_number");
            Map(cs => cs.LockExpiration).Nullable().CustomType<InstantUserType>().Column("lock_expires");
            Map(cs => cs.MiddleName).Nullable().Length(255).Column("middlename");
            Map(cs => cs.PasswordHash).Nullable().Length(128).Column("password_hash");
            Map(cs => cs.Prefix).Nullable().Length(40).Column("prefix");
            Map(cs => cs.ResetPasswordToken).Nullable().Length(128).Column("rp_token");
            Map(cs => cs.ResetPasswordTokenCreated).Nullable().CustomType<InstantUserType>().Column("rp_token_created_at");
            Map(cs => cs.SessionCutoff).Nullable().CustomType<InstantUserType>().Column("session_cutoff");
            References<Store>(cs => cs.Store).Nullable().Column("store_id");
            Map(cs => cs.Suffix).Nullable().Length(40).Column("suffix");
            Map(cs => cs.ValueAddedTax).Nullable().Length(50).Column("taxvat");
            Map(cs => cs.UpdatedAt).Not.Nullable().CustomType<InstantUserType>().Column("updated_at");
            References<StoreWebsite>(cs => cs.Website).Nullable().Column("website_id");
        }
    }
}
