using System;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;

namespace Athi.Whippet.Adobe.Magento.Taxes.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="TaxRate"/> objects.
    /// </summary>
    public class TaxRateMap : MagentoFluentMap<TaxRate>
    {
        private const string TABLE_NAME = "tax_calculation_rate";

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateMap"/> class with no arguments.
        /// </summary>
        public TaxRateMap()
            : base(TABLE_NAME)
        {
            Id(tr => tr.ID).GeneratedBy.Increment().Column("tax_calculation_rate_id");
            Map(tr => tr.Code).Column("code").Not.Nullable().Length(255);
            Map(tr => tr.Rate).Column("rate").Not.Nullable();
            Map(tr => tr.CountryID).Column("tax_country_id").Not.Nullable().Length(2);
            Map(tr => tr.PostalCode).Column("tax_postcode").Nullable().Length(21);
            Map(tr => tr.RegionID).Column("tax_region_id").Not.Nullable();
            Map(tr => tr.ZipFromInternal).Column("zip_from").Nullable();
            Map(tr => tr.ZipIsRangeInternal).Column("zip_is_range").Nullable();
            Map(tr => tr.ZipToInternal).Column("zip_to").Nullable();
        }
    }
}