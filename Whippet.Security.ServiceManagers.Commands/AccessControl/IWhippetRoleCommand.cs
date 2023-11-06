using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.AccessControl;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Commands
{
    /// <summary>
    /// Represents a command that acts upon <see cref="IWhippetRole"/> objects.
    /// </summary>
    public interface IWhippetRoleCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="IWhippetRole"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IWhippetRole Role
        { get; }
    }
}
