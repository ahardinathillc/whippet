using System;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;

namespace Athi.Whippet.Adobe.Magento.EAV.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="StoreWebsite"/> objects.
    /// </summary>
    public class StoreWebsiteMap : MagentoFluentMap<StoreWebsite>
    {
        private const string TABLE_NAME = "store_website";

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreWebsiteMap"/> class with no arguments.
        /// </summary>
        public StoreWebsiteMap()
            : base(TABLE_NAME)
        {
            Id(sws => sws.WebsiteID).GeneratedBy.Increment().Column("website_id");
            Map(sws => sws.Code).Nullable().Length(32).Column("code");
            Map(sws => sws.Name).Nullable().Length(64).Column("name");
            Map(sws => sws.SortOrder).Not.Nullable().Column("sort_order");
            Map(sws => sws.DefaultGroupID).Not.Nullable().Column("default_group_id");
            Map(sws => sws.IsDefault).Nullable().Column("is_default");
        }
    }
}
