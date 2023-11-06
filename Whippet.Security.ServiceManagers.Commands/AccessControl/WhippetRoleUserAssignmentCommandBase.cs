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
    /// Base class for all commands that act upon <see cref="WhippetRoleUserAssignment"/> objects. This class must be inherited.
    /// </summary>
    public abstract class WhippetRoleUserAssignmentCommandBase : WhippetCommand, IWhippetCommand, IWhippetRoleUserAssignmentCommand
    {
        /// <summary>
        /// Gets the <see cref="WhippetRoleUserAssignment"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public WhippetRoleUserAssignment RoleUserAssignment
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IWhippetRoleUserAssignment"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IWhippetRoleUserAssignment IWhippetRoleUserAssignmentCommand.RoleUserAssignment
        {
            get
            {
                return RoleUserAssignment;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRoleUserAssignmentCommandBase"/> class with no arguments.
        /// </summary>
        protected WhippetRoleUserAssignmentCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRoleUserAssignmentCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="role"><see cref="WhippetRoleUserAssignment"/> instance to create or act upon in the data store.</param>
        protected WhippetRoleUserAssignmentCommandBase(WhippetRoleUserAssignment role)
            : base()
        {
            RoleUserAssignment = role;
        }
    }
}
