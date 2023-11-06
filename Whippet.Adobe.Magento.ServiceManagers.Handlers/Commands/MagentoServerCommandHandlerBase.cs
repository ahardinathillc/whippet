using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.ServiceManagers.Commands;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Base class for <see cref="IMagentoServer"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IMagentoServer"/> type to handle.</typeparam>
    public abstract class MagentoServerCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IMagentoServerCommandHandler<TCommand>
        where TCommand : IMagentoServerCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="IMagentoServerRepository"/> to execute the commands against.
        /// </summary>
        protected IMagentoServerRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoServerCommandHandlerBase{TCommand}"/> class with the specified <see cref="IMagentoServer"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMagentoServerRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected MagentoServerCommandHandlerBase(IMagentoServerRepository repository)
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
