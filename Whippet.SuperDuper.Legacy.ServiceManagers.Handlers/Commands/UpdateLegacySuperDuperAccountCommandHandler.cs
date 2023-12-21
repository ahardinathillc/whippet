using System;
using Athi.Whippet.Data;
using Athi.Whippet.SuperDuper.Legacy.Repositories;
using Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Commands;

namespace Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="UpdateLegacySuperDuperAccountCommand"/> objects.
    /// </summary>
    public class UpdateLegacySuperDuperAccountCommandHandler : LegacySuperDuperAccountCommandHandlerBase<UpdateLegacySuperDuperAccountCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateLegacySuperDuperAccountCommandHandler"/> class with the specified <see cref="ILegacySuperDuperAccountRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ILegacySuperDuperAccountRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public UpdateLegacySuperDuperAccountCommandHandler(ILegacySuperDuperAccountRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="UpdateLegacySuperDuperAccountCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(UpdateLegacySuperDuperAccountCommand command)
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
                    result = await ((IWhippetRepository<LegacySuperDuperAccount, int>)(Repository)).UpdateAsync(command.Account);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="UpdateLegacySuperDuperAccountCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="UpdateLegacySuperDuperAccountCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(UpdateLegacySuperDuperAccountCommand command)
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
