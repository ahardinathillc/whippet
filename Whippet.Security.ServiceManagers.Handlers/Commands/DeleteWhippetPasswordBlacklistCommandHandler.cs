using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.ServiceManagers.Commands;
using Athi.Whippet.Security.Repositories;

namespace Athi.Whippet.Security.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="DeleteWhippetPasswordBlacklistCommand"/> objects.
    /// </summary>
    public class DeleteWhippetPasswordBlacklistCommandHandler : WhippetPasswordBlacklistCommandHandlerBase<DeleteWhippetPasswordBlacklistCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhippetPasswordBlacklistCommandHandler"/> class with the specified <see cref="IWhippetPasswordBlacklistRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetPasswordBlacklistRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public DeleteWhippetPasswordBlacklistCommandHandler(IWhippetPasswordBlacklistRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(DeleteWhippetPasswordBlacklistCommand command)
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
                    result = await Repository.DeleteAsync(command.Password);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="DeleteWhippetPasswordBlacklistCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="DeleteWhippetPasswordBlacklistCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(DeleteWhippetPasswordBlacklistCommand command)
        {
            WhippetResult result = WhippetResult.Success;

            if (command == null || command.Password == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }
            else
            {
                if (String.IsNullOrWhiteSpace(command.Password.Password))
                {
                    result = new WhippetResult(new ArgumentNullException(nameof(command.Password.Password)));
                }
            }

            return result;
        }
    }
}
