using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="MultichannelOrderManagerRestEndpoint"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateMultichannelOrderManagerRestEndpointCommand : MultichannelOrderManagerRestEndpointCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMultichannelOrderManagerRestEndpointCommand"/> class with no arguments.
        /// </summary>
        private UpdateMultichannelOrderManagerRestEndpointCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMultichannelOrderManagerRestEndpointCommand"/> class with the specified <see cref="MultichannelOrderManagerRestEndpoint"/>.
        /// </summary>
        /// <param name="endpoint"><see cref="MultichannelOrderManagerRestEndpoint"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateMultichannelOrderManagerRestEndpointCommand(MultichannelOrderManagerRestEndpoint endpoint)
            : base(endpoint)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
        }
    }
}
