using System;
using Athi.Whippet.Security.AccessControl;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="WhippetRoleUserAssignment"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateWhippetRoleUserAssignmentCommand : WhippetRoleUserAssignmentCommandBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWhippetRoleUserAssignmentCommand"/> class with no arguments.
        /// </summary>
        private CreateWhippetRoleUserAssignmentCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWhippetRoleUserAssignmentCommand"/> class with the specified <see cref="WhippetRoleUserAssignment"/>.
        /// </summary>
        /// <param name="role"><see cref="WhippetRoleUserAssignment"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateWhippetRoleUserAssignmentCommand(WhippetRoleUserAssignment role)
            : base(role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
        }
    }
}

