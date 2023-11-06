using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Repositories;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Base class for <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand"/> type to handle.</typeparam>
    public abstract class MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommandHandler<TCommand>
        where TCommand : IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository"/> to execute the commands against.
        /// </summary>
        protected IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommandHandlerBase{TCommand}"/> class with the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommandHandlerBase(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository repository)
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
