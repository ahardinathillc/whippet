using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Security.Tenants.ServiceManagers.Commands
{
    /// <summary>
    /// Represents a command that acts upon <see cref="IWhippetUserTenantAssignment"/> objects.
    /// </summary>
    public interface IWhippetUserTenantAssignmentCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="IWhippetUserTenantAssignmentCommand"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IWhippetUserTenantAssignment Assignment
        { get; }
    }
}
