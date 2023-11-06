using System;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;

namespace Athi.Whippet.Adobe.Magento.EAV.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="StoreGroup"/> objects.
    /// </summary>
    public class StoreGroupMap : MagentoFluentMap<StoreGroup>
    {
        private const string TABLE_NAME = "store_group";

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreGroupMap"/> class with no arguments.
        /// </summary>
        public StoreGroupMap()
            : base(TABLE_NAME)
        {
            Id(sg => sg.GroupID).GeneratedBy.Increment().Column("group_id");
            Map(sg => sg.Name).Not.Nullable().Length(255).Column("name");
            Map(sg => sg.RootCategoryID).Not.Nullable().Column("root_category_id");
            Map(sg => sg.DefaultStoreID).Not.Nullable().Column("default_store_id");
            Map(sg => sg.Code).Nullable().Length(32).Column("code");

            References<StoreWebsite>(sg => sg.Website).Not.Nullable().Column("website_id");
        }
    }
}
