using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Security.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="WhippetUser"/> objects. This class must be inherited.
    /// </summary>
    public abstract class WhippetUserCommandBase : WhippetCommand, IWhippetCommand, IWhippetUserCommand
    {
        /// <summary>
        /// Gets the <see cref="WhippetUser"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public WhippetUser User
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IWhippetUser"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IWhippetUser IWhippetUserCommand.User
        {
            get
            {
                return User;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserCommandBase"/> class with no arguments.
        /// </summary>
        protected WhippetUserCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="user"><see cref="WhippetUser"/> instance to create or act upon in the data store.</param>
        protected WhippetUserCommandBase(WhippetUser user)
            : base()
        {
            User = user;
        }
    }
}
