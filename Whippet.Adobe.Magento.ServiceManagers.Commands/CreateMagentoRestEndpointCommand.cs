using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="MagentoRestEndpoint"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateMagentoRestEndpointCommand : MagentoRestEndpointCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMagentoRestEndpointCommand"/> class with no arguments.
        /// </summary>
        private CreateMagentoRestEndpointCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMagentoRestEndpointCommand"/> class with the specified <see cref="MagentoRestEndpoint"/>.
        /// </summary>
        /// <param name="endpoint"><see cref="MagentoRestEndpoint"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateMagentoRestEndpointCommand(MagentoRestEndpoint endpoint)
            : base(endpoint)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
        }
    }
}
