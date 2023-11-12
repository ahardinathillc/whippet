using System;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands;
using Athi.Whippet.Adobe.Magento.Taxes.Repositories;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="CreateTaxRateTitleCommand"/> objects.
    /// </summary>
    public class CreateTaxRateTitleCommandHandler : TaxRateTitleCommandHandlerBase<CreateTaxRateTitleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTaxRateTitleCommandHandler"/> class with the specified <see cref="ITaxRateTitleRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ITaxRateTitleRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public CreateTaxRateTitleCommandHandler(ITaxRateTitleRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="ITaxRateTitleCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(CreateTaxRateTitleCommand command)
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
                    result = await ((IWhippetRepository<TaxRateTitle, int>)(Repository)).CreateAsync(command.TaxRateTitle);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="CreateTaxRateTitleCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="CreateTaxRateTitleCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(CreateTaxRateTitleCommand command)
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