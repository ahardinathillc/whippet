using System;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands;
using Athi.Whippet.Adobe.Magento.Taxes.Repositories;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="DeleteTaxClassCommand"/> objects.
    /// </summary>
    public class DeleteTaxClassCommandHandler : TaxClassCommandHandlerBase<DeleteTaxClassCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTaxClassCommandHandler"/> class with the specified <see cref="ITaxClassRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ITaxClassRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public DeleteTaxClassCommandHandler(ITaxClassRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="ITaxClassCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(DeleteTaxClassCommand command)
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
                    result = await ((IWhippetRepository<TaxClass, short>)(Repository)).DeleteAsync(command.TaxClass);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="DeleteTaxClassCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="DeleteTaxClassCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(DeleteTaxClassCommand command)
        {
            WhippetResult result = WhippetResult.Success;

            if (command == null || command.TaxClass == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }

            return result;
        }
    }
}