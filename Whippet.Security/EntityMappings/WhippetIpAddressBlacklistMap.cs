using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Data.NHibernate.FluentNHibernate.Extensions;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Security.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="WhippetIpAddressBlacklist"/> objects.
    /// </summary>
    public class WhippetIpAddressBlacklistMap : WhippetAuditableFluentMap<WhippetIpAddressBlacklist>
    {
        private const string TABLE_NAME = "[Security.IpAddressBlacklist]";

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetIpAddressBlacklistMap"/> class with no arguments.
        /// </summary>
        public WhippetIpAddressBlacklistMap()
            : base(TABLE_NAME)
        {
            Map(u => u.IPAddress).Length(ObjectExtensionMethods.GetDefaultEntityNameMaxLength()).Nullable();

            References<WhippetTenant>(u => u.Tenant).Not.Nullable();

            this.MapActiveEntity();
            this.MapDeletedEntity();
        }
    }
}
