using System;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;

namespace Athi.Whippet.Adobe.Magento.Directory.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="Region"/> objects.
    /// </summary>
    public class RegionMap : MagentoFluentMap<Region>
    {
        private const string TABLE_NAME = "directory_country_region";

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionMap"/> class with no arguments.
        /// </summary>
        public RegionMap()
            : base(TABLE_NAME)
        {
            Id(r => r.ID).GeneratedBy.Increment().Column("region_id").Not.Nullable();
            Map(r => r.CountryID).Column("country_id").Not.Nullable().Default("0").Length(4);
            Map(r => r.Code).Column("code").Nullable().Length(32);
            Map(r => r.Name).Column("default_name").Nullable().Length(255);
        }
    }
}
