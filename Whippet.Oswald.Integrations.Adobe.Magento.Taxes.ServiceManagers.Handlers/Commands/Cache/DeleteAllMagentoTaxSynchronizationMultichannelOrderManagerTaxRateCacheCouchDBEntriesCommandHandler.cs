using System;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Repositories;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesCommand"/> objects.
    /// </summary>
    public class DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesCommandHandler : MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommandHandlerBase<DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesCommandHandler"/> class with the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesCommandHandler(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesCommand command)
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
                    result = await ((IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository)(Repository)).DeleteAllEntriesAsync(command.Cache);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesCommand command)
        {
            WhippetResult result = WhippetResult.Success;

            if (command == null || command.Cache == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }

            return result;
        }
    }
}
