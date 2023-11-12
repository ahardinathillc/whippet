using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.ServiceManagers.Commands;
using Athi.Whippet.Adobe.Magento.Taxes.Repositories;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Base class for all bulk <see cref="ITaxRate"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="ITaxRate"/> type to handle.</typeparam>
    public abstract class TaxRateBulkCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, ITaxRateBulkCommandHandler<TCommand>
        where TCommand : IMagentoEntityBulkCommand<ITaxRate>
    {
        /// <summary>
        /// Gets or sets the internal <see cref="ITaxRateRepository"/> to execute the commands against.
        /// </summary>
        protected ITaxRateRepository Repository
        { get; private set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateBulkCommandHandlerBase{TCommand}"/> class with the specified <see cref="ITaxRateRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ITaxRateRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected TaxRateBulkCommandHandlerBase(ITaxRateRepository repository)
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
