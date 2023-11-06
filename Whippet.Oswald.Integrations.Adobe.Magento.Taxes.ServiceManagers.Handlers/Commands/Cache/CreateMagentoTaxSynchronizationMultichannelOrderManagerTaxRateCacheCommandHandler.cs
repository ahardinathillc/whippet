using System;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Repositories;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand"/> objects.
    /// </summary>
    public class CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommandHandler : MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommandHandlerBase<CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommandHandler"/> class with the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommandHandler(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand command)
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
                    result = await Repository.CreateAsync(command.Cache);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand command)
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
