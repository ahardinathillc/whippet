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
    /// Base class for all commands that act upon <see cref="WhippetGroupUserAssignment"/> objects. This class must be inherited.
    /// </summary>
    public abstract class WhippetGroupUserAssignmentCommandBase : WhippetCommand, IWhippetCommand, IWhippetGroupUserAssignmentCommand
    {
        /// <summary>
        /// Gets the <see cref="WhippetGroupUserAssignment"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public WhippetGroupUserAssignment GroupUserAssignment
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IWhippetGroupUserAssignment"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IWhippetGroupUserAssignment IWhippetGroupUserAssignmentCommand.GroupUserAssignment
        {
            get
            {
                return GroupUserAssignment;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetGroupUserAssignmentCommandBase"/> class with no arguments.
        /// </summary>
        protected WhippetGroupUserAssignmentCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetGroupUserAssignmentCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="group"><see cref="WhippetGroupUserAssignment"/> instance to create or act upon in the data store.</param>
        protected WhippetGroupUserAssignmentCommandBase(WhippetGroupUserAssignment group)
            : base()
        {
            GroupUserAssignment = group;
        }
    }
}
