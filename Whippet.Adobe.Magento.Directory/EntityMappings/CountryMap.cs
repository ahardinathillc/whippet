using System;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;

namespace Athi.Whippet.Adobe.Magento.Directory.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="Country"/> objects.
    /// </summary>
    public class CountryMap : MagentoFluentMap<Country>
    {
        private const string TABLE_NAME = "directory_country";

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryMap"/> class with no arguments.
        /// </summary>
        public CountryMap()
            : base(TABLE_NAME)
        {
            Id(c => c.CountryID).GeneratedBy.Assigned().Column("country_id").Not.Nullable().Length(2);
            Map(c => c.ISO2).Column("iso2_code").Nullable().Length(2);
            Map(c => c.ISO3).Column("iso3_code").Nullable().Length(3);
        }
    }
}