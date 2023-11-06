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
    /// Base class for all commands that act upon <see cref="WhippetGroup"/> objects. This class must be inherited.
    /// </summary>
    public abstract class WhippetGroupCommandBase : WhippetCommand, IWhippetCommand, IWhippetGroupCommand
    {
        /// <summary>
        /// Gets the <see cref="WhippetGroup"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public WhippetGroup Group
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IWhippetGroup"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IWhippetGroup IWhippetGroupCommand.Group
        {
            get
            {
                return Group;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetGroupCommandBase"/> class with no arguments.
        /// </summary>
        protected WhippetGroupCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetGroupCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="group"><see cref="WhippetGroup"/> instance to create or act upon in the data store.</param>
        protected WhippetGroupCommandBase(WhippetGroup group)
            : base()
        {
            Group = group;
        }
    }
}
