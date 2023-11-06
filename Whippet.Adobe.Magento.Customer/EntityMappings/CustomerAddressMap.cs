using System;
using FluentNHibernate.Mapping;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Data.NHibernate.UserTypes.NodaTime;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Customer.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="CustomerAddress"/> objects.
    /// </summary>
    public class CustomerAddressMap : MagentoFluentMap<CustomerAddress>
    {
        private const string TABLE_NAME = "customer_address_entity";

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerMap"/> class with no arguments.
        /// </summary>
        public CustomerAddressMap()
            : base(TABLE_NAME)
        {
            Id(ca => ca.EntityID).GeneratedBy.Increment().Column("entity_id");
            Map(ca => ca.City).Not.Nullable().Length(255).Column("city");
            Map(ca => ca.Company).Nullable().Length(255).Column("company");
            Map(ca => ca.CountryID).Not.Nullable().Length(255).Column("country_id");
            Map(ca => ca.CreatedAt).Not.Nullable().CustomType<InstantUserType>().Column("created_at");
            Map(ca => ca.Fax).Nullable().Length(255).Column("fax");
            Map(ca => ca.FirstName).Not.Nullable().Length(255).Column("firstname");
            Map(ca => ca.IncrementID).Nullable().Length(50).Column("increment_id");
            Map(ca => ca.Active).Not.Nullable().Column("is_active");
            Map(ca => ca.LastName).Not.Nullable().Length(255).Column("lastname");
            Map(ca => ca.MiddleName).Nullable().Length(255).Column("middlename");
            References<Customer>(ca => ca.Customer).Nullable().Column("parent_id");
            Map(ca => ca.PostalCode).Nullable().Length(255).Column("postcode");
            Map(ca => ca.Prefix).Nullable().Length(40).Column("prefix");
            Map(ca => ca.Region).Nullable().Length(255).Column("region");
            Map(ca => ca.RegionID).Nullable().Column("region_id");
            Map(ca => ca.Street).Not.Nullable().Length(this.GetMaximumStringLength()).Column("street");
            Map(ca => ca.Suffix).Nullable().Length(40).Column("suffix");
            Map(ca => ca.Telephone).Nullable().Length(255).Column("telephone");
            Map(ca => ca.UpdatedAt).Not.Nullable().CustomType<InstantUserType>().Column("updated_at");
            Map(ca => ca.ValueAddedTaxID).Nullable().Length(255).Column("vat_id");
            Map(ca => ca.ValueAddedTaxValid).Nullable().Column("vat_is_valid");
            Map(ca => ca.ValueAddedTaxRequestDate).Nullable().Length(255).Column("vat_request_date");
            Map(ca => ca.ValueAddedTaxRequestID).Nullable().Length(255).Column("vat_request_id");
            Map(ca => ca.ValueAddedTaxRequestSuccess).Nullable().Column("vat_request_success");
        }
    }
}
