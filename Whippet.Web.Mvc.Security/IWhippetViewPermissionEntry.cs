using System;
using Athi.Whippet.Data;
using Athi.Whippet.Security;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Web.Mvc.Security
{
    /// <summary>
    /// Represents a permission entry for an <see cref="IWhippetPrincipalObject"/> for a specific <see cref="WhippetViewProfile"/>.
    /// </summary>
    public interface IWhippetViewPermissionEntry : IWhippetEntity, IWhippetAuditableEntity, IWhippetSoftDeleteEntity, IEqualityComparer<IWhippetViewPermissionEntry>, IWhippetCloneable
    {
        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> that the principal is assigned to.
        /// </summary>
        IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="WhippetMvcSecurityPermission"/> that is stored in the entry.
        /// </summary>
        WhippetMvcSecurityPermission Permission
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetPrincipalObject"/> that <see cref="Permission"/> applies to.
        /// </summary>
        IWhippetPrincipalObject Principal
        { get; set; }
    }
}

