using System;
using Athi.Whippet.Data;
using Athi.Whippet.SuperDuper.Legacy.Repositories;
using Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Commands;

namespace Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="CreateLegacySuperDuperAccountCommand"/> objects.
    /// </summary>
    public class CreateLegacySuperDuperAccountCommandHandler : LegacySuperDuperAccountCommandHandlerBase<CreateLegacySuperDuperAccountCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLegacySuperDuperAccountCommandHandler"/> class with the specified <see cref="ILegacySuperDuperAccountRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ILegacySuperDuperAccountRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public CreateLegacySuperDuperAccountCommandHandler(ILegacySuperDuperAccountRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="CreateLegacySuperDuperAccountCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(CreateLegacySuperDuperAccountCommand command)
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
                    result = await ((IWhippetRepository<LegacySuperDuperAccount, int>)(Repository)).CreateAsync(command.Account);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="CreateLegacySuperDuperAccountCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="CreateLegacySuperDuperAccountCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(CreateLegacySuperDuperAccountCommand command)
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
