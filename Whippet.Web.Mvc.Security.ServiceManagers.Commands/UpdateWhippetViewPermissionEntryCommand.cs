using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Web.Mvc.Security.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="WhippetViewPermissionEntry"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateWhippetViewPermissionEntryCommand : WhippetViewPermissionEntryCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetViewPermissionEntryCommand"/> class with no arguments.
        /// </summary>
        private UpdateWhippetViewPermissionEntryCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetViewPermissionEntryCommand"/> class with the specified <see cref="WhippetViewPermissionEntry"/>.
        /// </summary>
        /// <param name="permission"><see cref="WhippetViewPermissionEntry"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateWhippetViewPermissionEntryCommand(WhippetViewPermissionEntry permission)
            : base(permission)
        {
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }
        }
    }
}
