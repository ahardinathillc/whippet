using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Security.AccessControl
{
    /// <summary>
    /// Represents a group that is assigned to an <see cref="IWhippetUser"/>. Groups are used to restrict access to application functionality and areas.
    /// </summary>
    public interface IWhippetGroup : IWhippetEntity, IWhippetSoftDeleteEntity, IWhippetAuditableEntity, IWhippetActiveEntity, IEqualityComparer<IWhippetGroup>, IWhippetPrincipalObject
    {
        /// <summary>
        /// Name of the group.
        /// </summary>
        new string Name
        { get; set; }

        /// <summary>
        /// Description of the group (if any).
        /// </summary>
        string Description
        { get; set; }

        /// <summary>
        /// If <see langword="true"/>, the <see cref="IWhippetGroup"/> spans across all tenants in the Whippet ecosystem. No two system groups can have the same name or ID.
        /// </summary>
        bool IsSystem
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> that the <see cref="IWhippetGroup"/> is assigned to.
        /// </summary>
        IWhippetTenant Tenant
        { get; set; }
    }
}
