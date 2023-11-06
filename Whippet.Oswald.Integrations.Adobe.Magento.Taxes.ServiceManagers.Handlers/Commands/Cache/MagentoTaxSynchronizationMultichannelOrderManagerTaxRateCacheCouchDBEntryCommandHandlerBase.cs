using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Repositories;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Base class for <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand"/> type to handle.</typeparam>
    public abstract class MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommandHandler<TCommand>
        where TCommand : IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository"/> to execute the commands against.
        /// </summary>
        protected IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommandHandlerBase{TCommand}"/> class with the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommandHandlerBase(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository repository)
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
