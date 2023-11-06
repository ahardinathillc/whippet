using System;
using Athi.Whippet.Security.AccessControl;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="WhippetRoleUserAssignment"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateWhippetRoleUserAssignmentCommand : WhippetRoleUserAssignmentCommandBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetRoleUserAssignmentCommand"/> class with no arguments.
        /// </summary>
        private UpdateWhippetRoleUserAssignmentCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetRoleUserAssignmentCommand"/> class with the specified <see cref="WhippetRoleUserAssignment"/>.
        /// </summary>
        /// <param name="role"><see cref="WhippetRoleUserAssignment"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateWhippetRoleUserAssignmentCommand(WhippetRoleUserAssignment role)
            : base(role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
        }
    }
}

