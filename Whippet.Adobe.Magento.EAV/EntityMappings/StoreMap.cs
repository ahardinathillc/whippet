using System;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;

namespace Athi.Whippet.Adobe.Magento.EAV.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="Store"/> objects.
    /// </summary>
    public class StoreMap : MagentoFluentMap<Store>
    {
        private const string TABLE_NAME = "store";

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreMap"/> class with no arguments.
        /// </summary>
        public StoreMap()
            : base(TABLE_NAME)
        {
            Id(sm => sm.StoreID).GeneratedBy.Increment().Column("store_id");
            Map(sm => sm.Code).Nullable().Length(32).Column("code");
            Map(sm => sm.Name).Not.Nullable().Length(255).Column("name");
            Map(sm => sm.SortOrder).Not.Nullable().Column("sort_order");
            Map(sm => sm.Active).Not.Nullable().Column("is_active");

            References<StoreGroup>(sm => sm.Group).Not.Nullable().Column("group_id");
            References<StoreWebsite>(sm => sm.Website).Not.Nullable().Column("website_id");
        }
    }
}
