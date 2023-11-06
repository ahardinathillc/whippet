using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="MultichannelOrderManagerServer"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class DeleteMultichannelOrderManagerServerCommand : MultichannelOrderManagerServerCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMultichannelOrderManagerServerCommand"/> class with no arguments.
        /// </summary>
        private DeleteMultichannelOrderManagerServerCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMultichannelOrderManagerServerCommand"/> class with the specified <see cref="MultichannelOrderManagerServer"/>.
        /// </summary>
        /// <param name="server"><see cref="MultichannelOrderManagerServer"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DeleteMultichannelOrderManagerServerCommand(MultichannelOrderManagerServer server)
            : base(server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }
        }
    }
}
