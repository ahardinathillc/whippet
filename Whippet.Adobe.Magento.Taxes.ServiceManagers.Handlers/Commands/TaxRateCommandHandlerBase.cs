using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands;
using Athi.Whippet.Adobe.Magento.Taxes.Repositories;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Base class for <see cref="ITaxRate"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="ITaxRate"/> type to handle.</typeparam>
    public abstract class TaxRateCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, ITaxRateCommandHandler<TCommand>
        where TCommand : ITaxRateCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="ITaxRateRepository"/> to execute the commands against.
        /// </summary>
        protected ITaxRateRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateCommandHandlerBase{TCommand}"/> class with the specified <see cref="ITaxRate"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ITaxRateRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected TaxRateCommandHandlerBase(ITaxRateRepository repository)
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
