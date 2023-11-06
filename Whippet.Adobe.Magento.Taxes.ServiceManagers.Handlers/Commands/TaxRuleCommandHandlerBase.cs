using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands;
using Athi.Whippet.Adobe.Magento.Taxes.Repositories;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Base class for <see cref="ITaxRule"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="ITaxRule"/> type to handle.</typeparam>
    public abstract class TaxRuleCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, ITaxRuleCommandHandler<TCommand>
        where TCommand : ITaxRuleCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="ITaxRuleRepository"/> to execute the commands against.
        /// </summary>
        protected ITaxRuleRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRuleCommandHandlerBase{TCommand}"/> class with the specified <see cref="ITaxRule"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ITaxRuleRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected TaxRuleCommandHandlerBase(ITaxRuleRepository repository)
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
    }
}
