using System;
using Athi.Whippet.Security;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Web.Mvc.Security.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IWhippetViewPermissionEntry"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IWhippetViewPermissionEntryExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IWhippetViewPermissionEntry"/> object to a <see cref="WhippetViewPermissionEntry"/>.
        /// </summary>
        /// <param name="permissionEntry"><see cref="IWhippetViewPermissionEntry"/> object to convert.</param>
        /// <returns><see cref="WhippetViewPermissionEntry"/> object.</returns>
        public static WhippetViewPermissionEntry ToWhippetViewPermissionEntry(this IWhippetViewPermissionEntry permissionEntry)
        {
            WhippetViewPermissionEntry entry = null;

            if (permissionEntry != null)
            {
                entry = new WhippetViewPermissionEntry(
                    permissionEntry.ID,
                    permissionEntry.Permission == null ? null : permissionEntry.Permission.Clone<WhippetMvcSecurityPermission>(),
                    permissionEntry.Principal == null ? null : permissionEntry.Principal.Clone<IWhippetPrincipalObject>(),
                    permissionEntry.Tenant == null ? null : permissionEntry.Tenant.Clone<IWhippetTenant>().ToWhippetTenant(),
                    permissionEntry.CreatedDateTime,
                    permissionEntry.CreatedBy,
                    permissionEntry.LastModifiedDateTime,
                    permissionEntry.LastModifiedBy,
                    permissionEntry.Deleted
                ) ;
            }

            return entry;
        }
    }
}

