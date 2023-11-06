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
    /// Base class for <see cref="ISalesforcePriceBookCommand"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="ISalesforcePriceBookCommand"/> type to handle.</typeparam>
    public abstract class SalesforcePriceBookCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, ISalesforcePriceBookCommandHandler<TCommand>
        where TCommand : ISalesforcePriceBookCommand
    {
        /// <summary>
        /// Gets the internal <see cref="ISalesforcePriceBookRepository"/> to execute the commands against. This property is read-only.
        /// </summary>
        protected ISalesforcePriceBookRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforcePriceBookCommandHandlerBase{TCommand}"/> class with the specified <see cref="ISalesforcePriceBookRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ISalesforcePriceBookRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesforcePriceBookCommandHandlerBase(ISalesforcePriceBookRepository repository)
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

            if (command == null || command.PriceBook == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }
            else if (String.IsNullOrWhiteSpace(command.PriceBook.Name))
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command.PriceBook.Name)));
            }

            return result;
        }
    }
}
