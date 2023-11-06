using System;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Repositories;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand"/> objects.
    /// </summary>
    public class DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommandHandler : MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommandHandlerBase<DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommandHandler"/> class with the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommandHandler(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            else
            {
                WhippetResult result = Validate(command);

                if (result.IsSuccess)
                {
                    result = await Repository.DeleteAsync(command.Entry);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand command)
        {
            WhippetResult result = WhippetResult.Success;

            if (command == null || command.Entry == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }

            return result;
        }
    }
}
