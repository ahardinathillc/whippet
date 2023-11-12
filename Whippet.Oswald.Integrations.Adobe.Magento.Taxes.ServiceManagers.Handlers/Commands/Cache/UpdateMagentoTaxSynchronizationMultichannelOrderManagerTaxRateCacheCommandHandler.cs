using System;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Repositories;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand"/> objects.
    /// </summary>
    public class UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommandHandler : MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommandHandlerBase<UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommandHandler"/> class with the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommandHandler(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand command)
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
                    result = await Repository.UpdateAsync(command.Cache);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand command)
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