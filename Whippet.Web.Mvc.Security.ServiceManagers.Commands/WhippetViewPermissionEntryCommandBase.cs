using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Web.Mvc.Security.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="WhippetViewPermissionEntry"/> objects. This class must be inherited.
    /// </summary>
    public abstract class WhippetViewPermissionEntryCommandBase : WhippetCommand, IWhippetCommand, IWhippetViewPermissionEntryCommand
    {
        /// <summary>
        /// Gets the <see cref="WhippetViewPermissionEntry"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public WhippetViewPermissionEntry PermissionEntry
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IWhippetViewPermissionEntry"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IWhippetViewPermissionEntry IWhippetViewPermissionEntryCommand.PermissionEntry
        {
            get
            {
                return PermissionEntry;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewPermissionEntryCommandBase"/> class with no arguments.
        /// </summary>
        protected WhippetViewPermissionEntryCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewPermissionEntryCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="permission"><see cref="WhippetViewPermissionEntry"/> instance to create or act upon in the data store.</param>
        protected WhippetViewPermissionEntryCommandBase(WhippetViewPermissionEntry permission)
            : base()
        {
            PermissionEntry = permission;
        }
    }
}
