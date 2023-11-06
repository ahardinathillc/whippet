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
    /// Base class for <see cref="ISalesforceProductCommand"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="ISalesforceProductCommand"/> type to handle.</typeparam>
    public abstract class SalesforceProductCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, ISalesforceProductCommandHandler<TCommand>
        where TCommand : ISalesforceProductCommand
    {
        /// <summary>
        /// Gets the internal <see cref="ISalesforceProductRepository"/> to execute the commands against. This property is read-only.
        /// </summary>
        protected ISalesforceProductRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceProductCommandHandlerBase{TCommand}"/> class with the specified <see cref="ISalesforceProductRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ISalesforceProductRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesforceProductCommandHandlerBase(ISalesforceProductRepository repository)
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

            if (command == null || command.Product == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }
            else if (String.IsNullOrWhiteSpace(command.Product.Name))
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command.Product.Name)));
            }

            return result;
        }
    }
}
