using System;
using Athi.Whippet.Networking.Smtp.Repositories;
using Athi.Whippet.Networking.Smtp.ServiceManagers.Commands;

namespace Athi.Whippet.Networking.Smtp.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="DeleteWhippetSmtpServerProfileCommand"/> objects.
    /// </summary>
    public class DeleteWhippetSmtpServerProfileCommandHandler : WhippetSmtpServerProfileCommandHandlerBase<DeleteWhippetSmtpServerProfileCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhippetSmtpServerProfileCommandHandler"/> class with the specified <see cref="IWhippetSmtpServerProfileRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetSmtpServerProfileRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public DeleteWhippetSmtpServerProfileCommandHandler(IWhippetSmtpServerProfileRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="IWhippetSmtpServerProfileCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(DeleteWhippetSmtpServerProfileCommand command)
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
                    result = await Repository.DeleteAsync(command.ServerProfile);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="DeleteWhippetSmtpServerProfileCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="DeleteWhippetSmtpServerProfileCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(DeleteWhippetSmtpServerProfileCommand command)
        {
            WhippetResult result = WhippetResult.Success;

            if (command == null || command.ServerProfile == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }

            return result;
        }
    }
}
