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
    /// Provides a Fluent mapping for <see cref="WhippetUserTenantAssignment"/> objects.
    /// </summary>
    public class WhippetUserTenantAssignmentMap : WhippetFluentMap<WhippetUserTenantAssignment>
    {
        private const string TABLE_NAME = "[System.Tenants.Users]";

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserTenantAssignmentMap"/> class with no arguments.
        /// </summary>
        public WhippetUserTenantAssignmentMap()
            : base(TABLE_NAME)
        {
            References<WhippetTenant>(t => t.Tenant).Not.Nullable().LazyLoad(Laziness.False);
            References<WhippetUser>(t => t.User).Not.Nullable().LazyLoad(Laziness.False);
        }
    }
}
