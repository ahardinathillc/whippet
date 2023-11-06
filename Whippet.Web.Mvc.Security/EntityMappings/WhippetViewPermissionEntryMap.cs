using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Data.NHibernate.FluentNHibernate.Extensions;
using Athi.Whippet.Data.NHibernate.UserTypes.Security;
using Athi.Whippet.Data.NHibernate.UserTypes.Web.Mvc.Security;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Web.Mvc.Security.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="WhippetViewPermissionEntry"/> objects.
    /// </summary>
    public class WhippetViewPermissionEntryMap : WhippetAuditableFluentMap<WhippetViewPermissionEntry>
    {
        private const string TABLE_NAME = "Permissions__WhippetView";
        private const string COL_RO_PERMISSION_ID = "ReadOnly__PermissionID";

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewPermissionEntryMap"/> class with no arguments.
        /// </summary>
        public WhippetViewPermissionEntryMap()
            : base(TABLE_NAME)
        {
            Map(wvpe => wvpe.Principal).Columns.Add(IWhippetPrincipalObjectUserType.GenerateColumns().ToArray()).CustomType<IWhippetPrincipalObjectUserType>().Not.Nullable();
            Map(wvpe => wvpe.Permission).Columns.Add(WhippetMvcSecurityPermissionUserType.GenerateColumns().ToArray()).CustomType<WhippetMvcSecurityPermissionUserType>().Not.Nullable();
            Map(wvpe => wvpe.PermissionID).Column(COL_RO_PERMISSION_ID).Not.Nullable();

            this.MapDeletedEntity();

            References<WhippetTenant>(wvpe => wvpe.Tenant).Not.Nullable().LazyLoad(Laziness.False);
        }
    }
}
