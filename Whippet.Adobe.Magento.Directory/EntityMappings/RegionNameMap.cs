using System;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;

namespace Athi.Whippet.Adobe.Magento.Directory.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="RegionName"/> objects.
    /// </summary>
    public class RegionNameMap : MagentoFluentMap<RegionName>
    {
        private const string TABLE_NAME = "directory_country_region_name";

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionNameMap"/> class with no arguments.
        /// </summary>
        public RegionNameMap()
            : base(TABLE_NAME)
        {
            Map(rn => rn.Locale).Column("locale").Not.Nullable().Length(16);
            Map(rn => rn.RegionID).Column("region_id").Not.Nullable().Default("0");
            Map(rn => rn.Name).Column("name").Nullable().Length(255);
        }
    }
}