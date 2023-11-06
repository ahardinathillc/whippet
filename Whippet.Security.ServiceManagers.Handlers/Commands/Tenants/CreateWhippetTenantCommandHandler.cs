using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants.ServiceManagers.Commands;
using Athi.Whippet.Security.Tenants.Repositories;

namespace Athi.Whippet.Security.Tenants.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="CreateWhippetTenantCommand"/> objects.
    /// </summary>
    public class CreateWhippetTenantCommandHandler : WhippetTenantCommandHandlerBase<CreateWhippetTenantCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhippetUserCommandHandler"/> class with the specified <see cref="IWhippetTenantRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetTenantRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public CreateWhippetTenantCommandHandler(IWhippetTenantRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(CreateWhippetTenantCommand command)
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
                    result = await Repository.CreateAsync(command.Tenant);
                }

                return result;
            }
        }
    }
}
