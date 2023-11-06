using System;
using Athi.Whippet.Security.AccessControl;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="WhippetRoleUserAssignment"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class DeleteWhippetRoleUserAssignmentCommand : WhippetRoleUserAssignmentCommandBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhippetRoleUserAssignmentCommand"/> class with no arguments.
        /// </summary>
        private DeleteWhippetRoleUserAssignmentCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhippetRoleUserAssignmentCommand"/> class with the specified <see cref="WhippetRoleUserAssignment"/>.
        /// </summary>
        /// <param name="role"><see cref="WhippetRoleUserAssignment"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DeleteWhippetRoleUserAssignmentCommand(WhippetRoleUserAssignment role)
            : base(role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
        }
    }
}

