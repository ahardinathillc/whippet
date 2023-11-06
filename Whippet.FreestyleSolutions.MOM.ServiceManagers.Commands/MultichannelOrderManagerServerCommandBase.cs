using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Commands
{
    /// <summary>
    /// Provides support for all commands that act upon <see cref="IMultichannelOrderManagerServer"/> objects.
    /// </summary>
    public abstract class MultichannelOrderManagerServerCommandBase : WhippetCommand, IWhippetCommand, IMultichannelOrderManagerServerCommand
    {
        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerServer"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public MultichannelOrderManagerServer Server
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerServer"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IMultichannelOrderManagerServer IMultichannelOrderManagerServerCommand.Server
        {
            get
            {
                return Server;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerServerCommandBase"/> class with no arguments.
        /// </summary>
        protected MultichannelOrderManagerServerCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerServerCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="server"><see cref="MultichannelOrderManagerServer"/> instance to create or act upon in the data store.</param>
        protected MultichannelOrderManagerServerCommandBase(MultichannelOrderManagerServer server)
            : base()
        {
            Server = server;
        }

    }
}
