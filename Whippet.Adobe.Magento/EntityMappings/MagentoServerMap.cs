using System;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Data.NHibernate.FluentNHibernate.Extensions;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Adobe.Magento.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="MagentoServer"/> objects.
    /// </summary>
    public class MagentoServerMap : WhippetAuditableFluentMap<MagentoServer>
    {
        private const string TABLE_NAME = "Adobe__Magento__Server";

        private const string COL_DBUSERNAME = "MySql__Username";
        private const string COL_DBPASSWORD = "MySql__Password";
        private const string COL_DBSCHEMA = "MySql__Schema";

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoServerMap"/> class with no arguments.
        /// </summary>
        public MagentoServerMap()
            : base(TABLE_NAME)
        {
            Map(m => m.Name).Not.Nullable().Length(this.GetDefaultStringLength());
            Map(m => m.ConnectionString).Nullable().Length(this.GetMaximumStringLength());
            Map(m => m.Username).Column(COL_DBUSERNAME).Nullable().Length(this.GetDefaultStringLength());
            Map(m => m.Password).Column(COL_DBPASSWORD).Nullable().Length(this.GetDefaultStringLength());
            Map(m => m.Schema).Column(COL_DBSCHEMA).Nullable().Length(this.GetDefaultStringLength());

            this.MapActiveEntity();
            this.MapDeletedEntity();

            References<WhippetTenant>(m => m.Tenant).Not.Nullable().LazyLoad(Laziness.False);
            References<MagentoRestEndpoint>(m => m.AssociatedEndpoint).Nullable().LazyLoad(Laziness.False);
        }
    }
}
