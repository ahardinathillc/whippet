using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.AccessControl.Repositories;
using Athi.Whippet.Security.AccessControl.ServiceManagers.Commands;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="DeleteWhippetRoleCommand"/> objects.
    /// </summary>
    public class DeleteWhippetRoleCommandHandler : WhippetRoleCommandHandlerBase<DeleteWhippetRoleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhippetRoleCommandHandler"/> class with the specified <see cref="IWhippetRoleRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetRoleRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public DeleteWhippetRoleCommandHandler(IWhippetRoleRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(DeleteWhippetRoleCommand command)
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
                    result = await Repository.DeleteAsync(command.Role);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="DeleteWhippetRoleCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="DeleteWhippetRoleCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(DeleteWhippetRoleCommand command)
        {
            WhippetResult result = WhippetResult.Success;

            if (command == null || command.Role == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }

            return result;
        }
    }
}
