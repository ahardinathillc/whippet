using System;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Data.NHibernate.FluentNHibernate.Extensions;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="MultichannelOrderManagerRestEndpoint"/> objects.
    /// </summary>
    public class MultichannelOrderManagerRestEndpointMap : WhippetAuditableFluentMap<MultichannelOrderManagerRestEndpoint>
    {
        private const string TABLE_NAME = "FreestyleSolutions__MultichannelOrderManager__RestEndpoint";

        private const string COL_USERNAME = "RestUsername";
        private const string COL_PASSWORD = "RestPassword";

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerRestEndpointMap"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerRestEndpointMap()
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