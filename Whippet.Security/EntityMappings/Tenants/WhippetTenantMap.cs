using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Security.EntityMappings.Tenants
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="WhippetTenant"/> objects.
    /// </summary>
    public class WhippetTenantMap : WhippetAuditableFluentMap<WhippetTenant>
    {
        private const string TABLE_NAME = "[System.Tenants]";

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetTenantMap"/> class with no arguments.
        /// </summary>
        public WhippetTenantMap()
            : base(TABLE_NAME)
        {
            
            Map(t => t.IsRootTenant).Not.Nullable().Default("0");
            Map(t => t.Name).Not.Nullable().Length(ObjectExtensionMethods.GetDefaultEntityNameMaxLength());
            Map(t => t.URL).Not.Nullable().Length(ObjectExtensionMethods.GetMaximumGoogleUrlLength());
            Map(t => t.Active).Not.Nullable();
            Map(t => t.Deleted).Not.Nullable();
        }
    }
}
