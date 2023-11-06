using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Security.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="WhippetPasswordBlacklist"/> objects. This class must be inherited.
    /// </summary>
    public abstract class WhippetPasswordBlacklistCommandBase : WhippetCommand, IWhippetCommand, IWhippetPasswordBlacklistCommand
    {
        /// <summary>
        /// Gets the <see cref="WhippetPasswordBlacklist"/> instance ot create or act upon in the data store. This property is read-only.
        /// </summary>
        public WhippetPasswordBlacklist Password
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IWhippetPasswordBlacklist"/> instance ot create or act upon in the data store. This property is read-only.
        /// </summary>
        IWhippetPasswordBlacklist IWhippetPasswordBlacklistCommand.Password
        {
            get
            {
                return Password;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPasswordBlacklistCommandBase"/> class with no arguments.
        /// </summary>
        protected WhippetPasswordBlacklistCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPasswordBlacklistCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="password"><see cref="WhippetPasswordBlacklist"/> instance to create or act upon in the data store.</param>
        protected WhippetPasswordBlacklistCommandBase(WhippetPasswordBlacklist password)
            : base()
        {
            Password = password;
        }
    }
}
