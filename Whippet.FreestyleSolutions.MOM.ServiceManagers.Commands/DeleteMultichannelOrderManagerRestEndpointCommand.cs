using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="MultichannelOrderManagerRestEndpoint"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class DeleteMultichannelOrderManagerRestEndpointCommand : MultichannelOrderManagerRestEndpointCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMultichannelOrderManagerRestEndpointCommand"/> class with no arguments.
        /// </summary>
        private DeleteMultichannelOrderManagerRestEndpointCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMultichannelOrderManagerRestEndpointCommand"/> class with the specified <see cref="MultichannelOrderManagerRestEndpoint"/>.
        /// </summary>
        /// <param name="endpoint"><see cref="MultichannelOrderManagerRestEndpoint"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DeleteMultichannelOrderManagerRestEndpointCommand(MultichannelOrderManagerRestEndpoint endpoint)
            : base(endpoint)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
        }
    }
}
