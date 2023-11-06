using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Repositories;
using Athi.Whippet.Web.Mvc.Security.Repositories;
using Athi.Whippet.Web.Mvc.Security.ServiceManagers.Commands;

namespace Athi.Whippet.Web.Mvc.Security.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="DeleteWhippetViewPermissionEntryCommand"/> objects.
    /// </summary>
    public class DeleteWhippetViewPermissionEntryCommandHandler : WhippetViewPermissionEntryCommandHandlerBase<DeleteWhippetViewPermissionEntryCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhippetViewPermissionEntryCommandHandler"/> class with the specified <see cref="IWhippetViewPermissionEntryRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetViewPermissionEntryRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public DeleteWhippetViewPermissionEntryCommandHandler(IWhippetViewPermissionEntryRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(DeleteWhippetViewPermissionEntryCommand command)
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
                    result = await Repository.DeleteAsync(command.PermissionEntry);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="DeleteWhippetViewPermissionEntryCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="DeleteWhippetViewPermissionEntryCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(DeleteWhippetViewPermissionEntryCommand command)
        {
            WhippetResult result = WhippetResult.Success;

            if (command == null || command.PermissionEntry == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }

            return result;
        }
    }
}
