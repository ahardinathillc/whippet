using System;
using System.ComponentModel;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Repositories;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Base class for <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand"/> type to handle.</typeparam>
    public abstract class MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommandHandler<TCommand>
        where TCommand : IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository"/> to execute the commands against.
        /// </summary>
        protected IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommandHandlerBase{TCommand}"/> class with the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommandHandlerBase(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository repository)
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
