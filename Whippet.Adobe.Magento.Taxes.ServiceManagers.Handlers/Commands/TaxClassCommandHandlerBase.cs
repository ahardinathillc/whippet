using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands;
using Athi.Whippet.Adobe.Magento.Taxes.Repositories;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Base class for <see cref="ITaxClass"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="ITaxClass"/> type to handle.</typeparam>
    public abstract class TaxClassCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, ITaxClassCommandHandler<TCommand>
        where TCommand : ITaxClassCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="ITaxClassRepository"/> to execute the commands against.
        /// </summary>
        protected ITaxClassRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxClassCommandHandlerBase{TCommand}"/> class with the specified <see cref="ITaxClass"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ITaxClassRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected TaxClassCommandHandlerBase(ITaxClassRepository repository)
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