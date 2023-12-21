using System;
using Athi.Whippet.Data;
using Athi.Whippet.SuperDuper.Legacy.Repositories;
using Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Commands;

namespace Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="DeleteLegacySuperDuperAccountCommand"/> objects.
    /// </summary>
    public class DeleteLegacySuperDuperAccountCommandHandler : LegacySuperDuperAccountCommandHandlerBase<DeleteLegacySuperDuperAccountCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteLegacySuperDuperAccountCommandHandler"/> class with the specified <see cref="ILegacySuperDuperAccountRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ILegacySuperDuperAccountRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public DeleteLegacySuperDuperAccountCommandHandler(ILegacySuperDuperAccountRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="DeleteLegacySuperDuperAccountCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(DeleteLegacySuperDuperAccountCommand command)
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
                    result = await ((IWhippetRepository<LegacySuperDuperAccount, int>)(Repository)).DeleteAsync(command.Account);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="DeleteLegacySuperDuperAccountCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="DeleteLegacySuperDuperAccountCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(DeleteLegacySuperDuperAccountCommand command)
        {
            WhippetResult result = WhippetResult.Success;

            if (command == null || command.Account == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }

            return result;
        }        
    }
}
