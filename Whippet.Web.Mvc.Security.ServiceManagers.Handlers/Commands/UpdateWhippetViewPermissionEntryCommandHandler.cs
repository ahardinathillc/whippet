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
    /// Command handler for <see cref="UpdateWhippetViewPermissionEntryCommand"/> objects.
    /// </summary>
    public class UpdateWhippetViewPermissionEntryCommandHandler : WhippetViewPermissionEntryCommandHandlerBase<UpdateWhippetViewPermissionEntryCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetViewPermissionEntryCommandHandler"/> class with the specified <see cref="IWhippetViewPermissionEntryRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetViewPermissionEntryRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public UpdateWhippetViewPermissionEntryCommandHandler(IWhippetViewPermissionEntryRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(UpdateWhippetViewPermissionEntryCommand command)
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
                    result = await Repository.UpdateAsync(command.PermissionEntry);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="UpdateWhippetViewPermissionEntryCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="UpdateWhippetViewPermissionEntryCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(UpdateWhippetViewPermissionEntryCommand command)
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
