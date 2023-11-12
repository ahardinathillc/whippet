using System;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Taxes.Repositories;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="CreateTaxRateBulkCommand"/> objects.
    /// </summary>
    public class CreateTaxRateBulkCommandHandler : TaxRateBulkCommandHandlerBase<CreateTaxRateBulkCommand>, ITaxRateBulkCommandHandler<CreateTaxRateBulkCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTaxRateBulkCommandHandler"/> class with the specified <see cref="ITaxRateRepository"/>.
        /// </summary>
        /// <param name="repository"><see cref="ITaxRateRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateTaxRateBulkCommandHandler(ITaxRateRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="CreateTaxRateBulkCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(CreateTaxRateBulkCommand command)
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
                    result = await Repository.BulkAddAsync(command.Entities);
                }

                return result;
            }
        }
        
        /// <summary>
        /// Validates the specified <see cref="CreateTaxRateBulkCommand"/> for errors before executing.
        /// </summary>
        /// <param name="command"><see cref="CreateTaxRateBulkCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> that contains the result of the validation.</returns>
        /// <exception cref="ArgumentNullException" />
        protected virtual WhippetResult Validate(CreateTaxRateBulkCommand command)
        {
            WhippetResult result = WhippetResult.Success;

            if (command == null || command.Entities == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }

            return result;
        }

    }
}
