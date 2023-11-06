using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Security.AccessControl
{
    /// <summary>
    /// Represents a role that is assigned to an <see cref="IWhippetUser"/>. Roles are used to restrict access to application functionality and areas.
    /// </summary>
    public interface IWhippetRole : IWhippetEntity, IWhippetSoftDeleteEntity, IWhippetAuditableEntity, IWhippetActiveEntity, IEqualityComparer<IWhippetRole>, IWhippetPrincipalObject
    {
        /// <summary>
        /// Name of the role.
        /// </summary>
        new string Name
        { get; set; }

        /// <summary>
        /// Description of the role (if any).
        /// </summary>
        string Description
        { get; set; }

        /// <summary>
        /// If <see langword="true"/>, the <see cref="IWhippetRole"/> spans across all tenants in the Whippet ecosystem. No two system roles can have the same name or ID.
        /// </summary>
        bool IsSystem
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> that the <see cref="IWhippetRole"/> is assigned to.
        /// </summary>
        IWhippetTenant Tenant
        { get; set; }
    }
}
