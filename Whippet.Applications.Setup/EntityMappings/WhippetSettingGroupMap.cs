using System;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;

namespace Athi.Whippet.Applications.Setup.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="WhippetSettingGroup"/> objects.
    /// </summary>
    public class WhippetSettingGroupMap : WhippetFluentMap<WhippetSettingGroup>
    {
        private const string TABLE_NAME = "SettingGroups";

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSettingGroupMap"/> class with no arguments.
        /// </summary>
        public WhippetSettingGroupMap()
            : base(TABLE_NAME)
        {
            Map(grp => grp.SettingGroupID).Not.Nullable();
            Map(grp => grp.Name).Length(255).Not.Nullable();
            Map(grp => grp.Description).Length(1024).Nullable();

            References<WhippetApplication>(grp => grp.Application).Not.Nullable().LazyLoad(Laziness.False);
        }
    }
}
