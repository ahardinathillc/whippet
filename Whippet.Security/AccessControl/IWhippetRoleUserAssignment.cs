using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Extensions;
using Athi.Whippet.Security.AccessControl.Extensions;

namespace Athi.Whippet.Security.AccessControl
{
    /// <summary>
    /// <see cref="IWhippetUser"/> role assignment to a respective <see cref="IWhippetRole"/>.
    /// </summary>
    public interface IWhippetRoleUserAssignment : IWhippetEntity, IWhippetSoftDeleteEntity, IWhippetAuditableEntity, IWhippetActiveEntity, IEqualityComparer<IWhippetRoleUserAssignment>
    {
        /// <summary>
        /// <see cref="IWhippetUser"/> who is assigned to the <see cref="IWhippetRole"/>. This property is read-only.
        /// </summary>
        IWhippetUser User
        { get; }

        /// <summary>
        /// <see cref="IWhippetRole"/> that is assigned to the <see cref="IWhippetUser"/>. This property is read-only.
        /// </summary>
        IWhippetRole Role
        { get; }
    }
}

