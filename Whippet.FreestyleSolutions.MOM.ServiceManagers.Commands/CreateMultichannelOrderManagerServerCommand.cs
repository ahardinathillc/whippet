using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="MultichannelOrderManagerServer"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateMultichannelOrderManagerServerCommand : MultichannelOrderManagerServerCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMultichannelOrderManagerServerCommand"/> class with no arguments.
        /// </summary>
        private CreateMultichannelOrderManagerServerCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMultichannelOrderManagerServerCommand"/> class with the specified <see cref="MultichannelOrderManagerServer"/>.
        /// </summary>
        /// <param name="server"><see cref="MultichannelOrderManagerServer"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateMultichannelOrderManagerServerCommand(MultichannelOrderManagerServer server)
            : base(server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }
        }
    }
}
