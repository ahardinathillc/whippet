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
    /// Provides a Fluent mapping for <see cref="WhippetPasswordBlacklist"/> objects.
    /// </summary>
    public class WhippetPasswordBlacklistMap : WhippetFluentMap<WhippetPasswordBlacklist>
    {
        private const string TABLE_NAME = "PasswordBlacklist";

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPasswordBlacklistMap"/> class with no arguments.
        /// </summary>
        public WhippetPasswordBlacklistMap()
            : base(TABLE_NAME)
        {
            Map(u => u.Password).Length(ObjectExtensionMethods.GetMaximumStringLength()).Not.Nullable();

            References<WhippetTenant>(u => u.Tenant).Not.Nullable();
        }
    }
}
