using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Commands;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Base class for <see cref="IMultichannelOrderManagerRestEndpoint"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IMultichannelOrderManagerRestEndpoint"/> type to handle.</typeparam>
    public abstract class MultichannelOrderManagerRestEndpointCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IMultichannelOrderManagerRestEndpointCommandHandler<TCommand>
        where TCommand : IMultichannelOrderManagerRestEndpointCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="IMultichannelOrderManagerRestEndpointRepository"/> to execute the commands against.
        /// </summary>
        protected IMultichannelOrderManagerRestEndpointRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerRestEndpointCommandHandlerBase{TCommand}"/> class with the specified <see cref="IMultichannelOrderManagerRestEndpoint"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMultichannelOrderManagerRestEndpointRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected MultichannelOrderManagerRestEndpointCommandHandlerBase(IMultichannelOrderManagerRestEndpointRepository repository)
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
