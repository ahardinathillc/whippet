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
    /// Base class for <see cref="IWhippetUserTenantAssignmentCommand"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetUserTenantAssignmentCommand"/> type to handle.</typeparam>
    public abstract class WhippetUserTenantAssignmentCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IWhippetUserTenantAssignmentCommandHandler<TCommand>
        where TCommand : IWhippetUserTenantAssignmentCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="IWhippetUserTenantAssignmentRepository"/> to execute the commands against.
        /// </summary>
        protected IWhippetUserTenantAssignmentRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserTenantAssignmentCommandHandlerBase{TCommand}"/> class with the specified <see cref="IWhippetUserTenantAssignmentRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetUserTenantAssignmentRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetUserTenantAssignmentCommandHandlerBase(IWhippetUserTenantAssignmentRepository repository)
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

            if (command.Assignment == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command.Assignment)));
            }

            return result;
        }
    }
}
