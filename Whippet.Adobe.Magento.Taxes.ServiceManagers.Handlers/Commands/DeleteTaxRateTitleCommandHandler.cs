using System;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands;
using Athi.Whippet.Adobe.Magento.Taxes.Repositories;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="DeleteTaxRateTitleCommand"/> objects.
    /// </summary>
    public class DeleteTaxRateTitleCommandHandler : TaxRateTitleCommandHandlerBase<DeleteTaxRateTitleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTaxRateTitleCommandHandler"/> class with the specified <see cref="ITaxRateTitleRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ITaxRateTitleRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public DeleteTaxRateTitleCommandHandler(ITaxRateTitleRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="ITaxRateTitleCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(DeleteTaxRateTitleCommand command)
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
                    result = await ((IWhippetRepository<TaxRateTitle, int>)(Repository)).DeleteAsync(command.TaxRateTitle);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="DeleteTaxRateTitleCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="DeleteTaxRateTitleCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(DeleteTaxRateTitleCommand command)
        {
            WhippetResult result = WhippetResult.Success;

            if (command == null || command.TaxRateTitle == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }

            return result;
        }
    }
}