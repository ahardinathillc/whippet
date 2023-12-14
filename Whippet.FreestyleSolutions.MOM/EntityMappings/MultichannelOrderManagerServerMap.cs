using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data;
using Athi.Whippet.Data.NHibernate.UserTypes.NodaTime;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Data.NHibernate.FluentNHibernate.Extensions;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Security;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="MultichannelOrderManagerServer"/> objects.
    /// </summary>
    public class MultichannelOrderManagerServerMap : WhippetAuditableFluentMap<MultichannelOrderManagerServer>
    {
        private const string TABLE_NAME = "FreestyleSolutions__MultichannelOrderManager_Server";

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerServerMap"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerServerMap()
            : base(TABLE_NAME)
        {
            Map(mc => mc.ConnectionString).Nullable().Length(this.GetMaximumStringLength());
            Map(mc => mc.Name).Not.Nullable().Length(this.GetMaximumStringLength());
            Map(mc => mc.Username).Nullable().Length(this.GetMaximumStringLength());
            Map(mc => mc.Password).Nullable().Length(this.GetMaximumStringLength());
            Map(mc => mc.Schema, "DB_Schema").Nullable().Length(this.GetMaximumStringLength());
            Map(mc => mc.CustomDatabase).Not.Nullable();

            this.MapActiveEntity();
            this.MapDeletedEntity();

            References<WhippetTenant>(mc => mc.Tenant).Not.Nullable();
            References<MultichannelOrderManagerRestEndpoint>(mc => mc.AssociatedEndpoint).Nullable().LazyLoad(Laziness.False).ReadOnly();
        }
    }
}
