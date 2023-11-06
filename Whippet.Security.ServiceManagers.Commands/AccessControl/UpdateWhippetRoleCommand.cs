using System;
using Athi.Whippet.Security.AccessControl;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="WhippetRole"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateWhippetRoleCommand : WhippetRoleCommandBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetRoleCommand"/> class with no arguments.
        /// </summary>
        private UpdateWhippetRoleCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetRoleCommand"/> class with the specified <see cref="WhippetRole"/>.
        /// </summary>
        /// <param name="role"><see cref="WhippetRole"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateWhippetRoleCommand(WhippetRole role)
            : base(role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
        }
    }
}

