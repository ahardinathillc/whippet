using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands;
using Athi.Whippet.Adobe.Magento.Taxes.Repositories;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Base class for <see cref="ITaxRateTitle"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="ITaxRateTitle"/> type to handle.</typeparam>
    public abstract class TaxRateTitleCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, ITaxRateTitleCommandHandler<TCommand>
        where TCommand : ITaxRateTitleCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="ITaxRateTitleRepository"/> to execute the commands against.
        /// </summary>
        protected ITaxRateTitleRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateTitleCommandHandlerBase{TCommand}"/> class with the specified <see cref="ITaxRateTitle"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ITaxRateTitleRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected TaxRateTitleCommandHandlerBase(ITaxRateTitleRepository repository)
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
