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
    /// <see cref="IWhippetUser"/> group assignment to a respective <see cref="IWhippetGroup"/>.
    /// </summary>
    public interface IWhippetGroupUserAssignment : IWhippetEntity, IWhippetSoftDeleteEntity, IWhippetAuditableEntity, IWhippetActiveEntity, IEqualityComparer<IWhippetGroupUserAssignment>
    {
        /// <summary>
        /// <see cref="IWhippetUser"/> who is assigned to the <see cref="IWhippetGroup"/>. This property is read-only.
        /// </summary>
        IWhippetUser User
        { get; }

        /// <summary>
        /// <see cref="IWhippetGroup"/> that is assigned to the <see cref="IWhippetUser"/>. This property is read-only.
        /// </summary>
        IWhippetGroup Group
        { get; }
    }
}

