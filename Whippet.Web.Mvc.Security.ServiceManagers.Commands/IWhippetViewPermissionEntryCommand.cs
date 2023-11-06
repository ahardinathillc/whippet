using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Web.Mvc.Security.ServiceManagers.Commands
{
    /// <summary>
    /// Represents a command that acts upon <see cref="IWhippetViewPermissionEntry"/> objects.
    /// </summary>
    public interface IWhippetViewPermissionEntryCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="IWhippetViewPermissionEntry"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IWhippetViewPermissionEntry PermissionEntry
        { get; }
    }
}
