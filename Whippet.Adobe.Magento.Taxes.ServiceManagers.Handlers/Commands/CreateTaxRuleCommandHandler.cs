using System;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands;
using Athi.Whippet.Adobe.Magento.Taxes.Repositories;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="CreateTaxRuleCommand"/> objects.
    /// </summary>
    public class CreateTaxRuleCommandHandler : TaxRuleCommandHandlerBase<CreateTaxRuleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTaxRuleCommandHandler"/> class with the specified <see cref="ITaxRuleRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ITaxRuleRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public CreateTaxRuleCommandHandler(ITaxRuleRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="ITaxRuleCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(CreateTaxRuleCommand command)
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
                    result = await ((IWhippetRepository<TaxRule, uint>)(Repository)).CreateAsync(command.TaxRule);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="CreateTaxRuleCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="CreateTaxRuleCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(CreateTaxRuleCommand command)
        {
            WhippetResult result = WhippetResult.Success;

            if (command == null || command.TaxRule == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }

            return result;
        }
    }
}