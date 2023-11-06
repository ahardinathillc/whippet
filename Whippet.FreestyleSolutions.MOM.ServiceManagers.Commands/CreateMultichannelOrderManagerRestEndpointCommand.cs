using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="MultichannelOrderManagerRestEndpoint"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateMultichannelOrderManagerRestEndpointCommand : MultichannelOrderManagerRestEndpointCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMultichannelOrderManagerRestEndpointCommand"/> class with no arguments.
        /// </summary>
        private CreateMultichannelOrderManagerRestEndpointCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMultichannelOrderManagerRestEndpointCommand"/> class with the specified <see cref="MultichannelOrderManagerRestEndpoint"/>.
        /// </summary>
        /// <param name="endpoint"><see cref="MultichannelOrderManagerRestEndpoint"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateMultichannelOrderManagerRestEndpointCommand(MultichannelOrderManagerRestEndpoint endpoint)
            : base(endpoint)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
        }
    }
}
