using System;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands;
using Athi.Whippet.Adobe.Magento.Taxes.Repositories;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="CreateTaxRateCommand"/> objects.
    /// </summary>
    public class CreateTaxRateCommandHandler : TaxRateCommandHandlerBase<CreateTaxRateCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTaxRateCommandHandler"/> class with the specified <see cref="ITaxRateRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ITaxRateRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public CreateTaxRateCommandHandler(ITaxRateRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="ITaxRateCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(CreateTaxRateCommand command)
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
                    result = await ((IWhippetRepository<TaxRate, int>)(Repository)).CreateAsync(command.TaxRate);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="CreateTaxRateCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="CreateTaxRateCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(CreateTaxRateCommand command)
        {
            WhippetResult result = WhippetResult.Success;

            if (command == null || command.TaxRate == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }

            return result;
        }
    }
}