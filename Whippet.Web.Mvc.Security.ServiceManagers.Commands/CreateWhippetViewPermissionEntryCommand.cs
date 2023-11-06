using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Web.Mvc.Security.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="WhippetViewPermissionEntry"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateWhippetViewPermissionEntryCommand : WhippetViewPermissionEntryCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWhippetViewPermissionEntryCommand"/> class with no arguments.
        /// </summary>
        private CreateWhippetViewPermissionEntryCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWhippetViewPermissionEntryCommand"/> class with the specified <see cref="WhippetViewPermissionEntry"/>.
        /// </summary>
        /// <param name="permission"><see cref="WhippetViewPermissionEntry"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateWhippetViewPermissionEntryCommand(WhippetViewPermissionEntry permission)
            : base(permission)
        {
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }
        }
    }
}
