using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants.ServiceManagers.Commands;
using Athi.Whippet.Security.Tenants.Repositories;

namespace Athi.Whippet.Security.Tenants.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Base class for <see cref="IWhippetTenantCommand"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetTenantCommand"/> type to handle.</typeparam>
    public abstract class WhippetTenantCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IWhippetTenantCommandHandler<TCommand>
        where TCommand : IWhippetTenantCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="IWhippetTenantRepository"/> to execute the commands against.
        /// </summary>
        protected IWhippetTenantRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetTenantCommandHandlerBase{TCommand}"/> class with the specified <see cref="IWhippetTenantRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetTenantRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetTenantCommandHandlerBase(IWhippetTenantRepository repository)
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
        /// Validates the specified <typeparamref name="TCommand"/> before execution.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> containing the validation result.</returns>
        protected override WhippetResult Validate(TCommand command)
        {
            WhippetResult result = WhippetResult.Success;

            if (command.Tenant == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command.Tenant)));
            }

            return result;
        }
    }
}
