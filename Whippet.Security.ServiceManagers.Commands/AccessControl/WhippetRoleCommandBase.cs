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
    /// Base class for all commands that act upon <see cref="WhippetRole"/> objects. This class must be inherited.
    /// </summary>
    public abstract class WhippetRoleCommandBase : WhippetCommand, IWhippetCommand, IWhippetRoleCommand
    {
        /// <summary>
        /// Gets the <see cref="WhippetRole"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public WhippetRole Role
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IWhippetRole"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IWhippetRole IWhippetRoleCommand.Role
        {
            get
            {
                return Role;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRoleCommandBase"/> class with no arguments.
        /// </summary>
        protected WhippetRoleCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRoleCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="role"><see cref="WhippetRole"/> instance to create or act upon in the data store.</param>
        protected WhippetRoleCommandBase(WhippetRole role)
            : base()
        {
            Role = role;
        }
    }
}
