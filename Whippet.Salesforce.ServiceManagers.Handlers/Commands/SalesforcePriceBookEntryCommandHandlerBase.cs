using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Salesforce.ServiceManagers.Commands;
using Athi.Whippet.Salesforce.Repositories;

namespace Athi.Whippet.Salesforce.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Base class for <see cref="ISalesforcePriceBookEntryCommand"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="ISalesforcePriceBookEntryCommand"/> type to handle.</typeparam>
    public abstract class SalesforcePriceBookEntryCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, ISalesforcePriceBookEntryCommandHandler<TCommand>
        where TCommand : ISalesforcePriceBookEntryCommand
    {
        /// <summary>
        /// Gets the internal <see cref="ISalesforcePriceBookEntryRepository"/> to execute the commands against. This property is read-only.
        /// </summary>
        protected ISalesforcePriceBookEntryRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforcePriceBookEntryCommandHandlerBase{TCommand}"/> class with the specified <see cref="ISalesforcePriceBookEntryRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ISalesforcePriceBookEntryRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesforcePriceBookEntryCommandHandlerBase(ISalesforcePriceBookEntryRepository repository)
            : base()
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            else
            {
                Repository = repository;
            }
        }

        /// <summary>
        /// Validates the specified <typeparamref name="TCommand"/> object.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(TCommand command)
        {
            WhippetResult result = WhippetResult.Success;

            if (command == null || command.PriceBookEntry == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }
            else if (String.IsNullOrWhiteSpace(command.PriceBookEntry.Name))
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command.PriceBookEntry.Name)));
            }
            else if (String.IsNullOrWhiteSpace(command.PriceBookEntry.PriceBookID))
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command.PriceBookEntry.PriceBookID)));
            }
            else if (String.IsNullOrWhiteSpace(command.PriceBookEntry.ProductID))
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command.PriceBookEntry.ProductID)));
            }

            return result;
        }
    }
}
