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
    /// Command handler for <see cref="DeleteWhippetIpAddressBlacklistCommand"/> objects.
    /// </summary>
    public class DeleteWhippetIpAddressBlacklistCommandHandler : WhippetIpAddressBlacklistCommandHandlerBase<DeleteWhippetIpAddressBlacklistCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhippetIpAddressBlacklistCommandHandler"/> class with the specified <see cref="IWhippetIpAddressBlacklistRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetIpAddressBlacklistRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public DeleteWhippetIpAddressBlacklistCommandHandler(IWhippetIpAddressBlacklistRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(DeleteWhippetIpAddressBlacklistCommand command)
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
                    result = await Repository.DeleteAsync(command.IPAddress);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="DeleteWhippetIpAddressBlacklistCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="DeleteWhippetIpAddressBlacklistCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(DeleteWhippetIpAddressBlacklistCommand command)
        {
            WhippetResult result = WhippetResult.Success;

            if (command == null || command.IPAddress == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }
            else
            {
                if (String.IsNullOrWhiteSpace(command.IPAddress.IPAddress))
                {
                    result = new WhippetResult(new ArgumentNullException(nameof(command.IPAddress.IPAddress)));
                }
            }

            return result;
        }
    }
}
