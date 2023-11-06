using System;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Data.NHibernate.FluentNHibernate.Extensions;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Adobe.Magento.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="MagentoRestEndpoint"/> objects.
    /// </summary>
    public class MagentoRestEndpointMap : WhippetAuditableFluentMap<MagentoRestEndpoint>
    {
        private const string TABLE_NAME = "Adobe__Magento__RestEndpoint";

        private const string COL_USERNAME = "RestUsername";
        private const string COL_PASSWORD = "RestPassword";

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoRestEndpointMap"/> class with no arguments.
        /// </summary>
        public MagentoRestEndpointMap()
            : base(TABLE_NAME)
        {
            Map(m => m.Name).Not.Nullable().Length(this.GetDefaultStringLength());
            Map(m => m.Username).Column(COL_USERNAME).Not.Nullable().Length(this.GetDefaultStringLength());
            Map(m => m.Password).Column(COL_PASSWORD).Not.Nullable().Length(this.GetDefaultStringLength());
            Map(m => m.URL).Not.Nullable().Length(this.GetMaximumGoogleUrlLength());

            this.MapActiveEntity();
            this.MapDeletedEntity();

            References<WhippetTenant>(m => m.Tenant).Not.Nullable().LazyLoad(Laziness.False);
        }
    }
}
