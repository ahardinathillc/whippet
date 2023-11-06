using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.ServiceManagers.Commands;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Base class for <see cref="IMagentoRestEndpoint"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IMagentoRestEndpoint"/> type to handle.</typeparam>
    public abstract class MagentoRestEndpointCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IMagentoRestEndpointCommandHandler<TCommand>
        where TCommand : IMagentoRestEndpointCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="IMagentoRestEndpointRepository"/> to execute the commands against.
        /// </summary>
        protected IMagentoRestEndpointRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoRestEndpointCommandHandlerBase{TCommand}"/> class with the specified <see cref="IMagentoRestEndpoint"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMagentoRestEndpointRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected MagentoRestEndpointCommandHandlerBase(IMagentoRestEndpointRepository repository)
            : base()
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            else
            {
                Repository = repository;
            }
        }
    }
}
