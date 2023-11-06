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
    /// Command handler for <see cref="CreateWhippetUserRegistrationVerificationRecordCommand"/> objects.
    /// </summary>
    public class CreateWhippetUserRegistrationVerificationRecordCommandHandler : WhippetUserRegistrationVerificationRecordCommandHandlerBase<CreateWhippetUserRegistrationVerificationRecordCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWhippetUserRegistrationVerificationRecordCommandHandler"/> class with the specified <see cref="IWhippetUserRegistrationVerificationRecordRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetUserRegistrationVerificationRecordRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public CreateWhippetUserRegistrationVerificationRecordCommandHandler(IWhippetUserRegistrationVerificationRecordRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(CreateWhippetUserRegistrationVerificationRecordCommand command)
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
                    result = await Repository.CreateAsync(command.VerificationRecord);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="CreateWhippetUserRegistrationVerificationRecordCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="CreateWhippetUserRegistrationVerificationRecordCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(CreateWhippetUserRegistrationVerificationRecordCommand command)
        {
            WhippetResult result = WhippetResult.Success;

            if (command == null || command.VerificationRecord == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }
            else
            {
                if(String.IsNullOrWhiteSpace(command.VerificationRecord.UserName))
                {
                    result = new WhippetResult(new ArgumentNullException(nameof(command.VerificationRecord.UserName)));
                }
                else if(String.IsNullOrWhiteSpace(command.VerificationRecord.AuthenticationKey))
                {
                    result = new WhippetResult(new ArgumentNullException(nameof(command.VerificationRecord.AuthenticationKey)));
                }
                else if (String.IsNullOrWhiteSpace(command.VerificationRecord.AuthenticationUrl))
                {
                    result = new WhippetResult(new ArgumentNullException(nameof(command.VerificationRecord.AuthenticationUrl)));
                }
            }

            return result;
        }
    }
}
