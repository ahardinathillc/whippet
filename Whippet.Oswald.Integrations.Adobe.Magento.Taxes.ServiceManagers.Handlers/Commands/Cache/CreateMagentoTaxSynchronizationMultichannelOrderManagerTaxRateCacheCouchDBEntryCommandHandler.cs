using System;
using Athi.Whippet.Data;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Repositories;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand"/> objects.
    /// </summary>
    public class CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommandHandler : MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommandHandlerBase<CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommandHandler"/> class with the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommandHandler(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand command)
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
                    result = await ((IWhippetRepository<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry, WhippetNonNullableString>)(Repository)).CreateAsync(command.Entry);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand command)
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