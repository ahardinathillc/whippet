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
    public class DeleteWhippetUserRegistrationVerificationRecordCommandHandler : WhippetUserRegistrationVerificationRecordCommandHandlerBase<DeleteWhippetUserRegistrationVerificationRecordCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhippetUserRegistrationVerificationRecordCommandHandler"/> class with the specified <see cref="IWhippetUserRegistrationVerificationRecordRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetUserRegistrationVerificationRecordRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public DeleteWhippetUserRegistrationVerificationRecordCommandHandler(IWhippetUserRegistrationVerificationRecordRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(DeleteWhippetUserRegistrationVerificationRecordCommand command)
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
                    command.VerificationRecord.Deleted = true;
                    result = await Repository.UpdateAsync(command.VerificationRecord);
                    //result = await Repository.DeleteAsync(command.VerificationRecord);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="DeleteWhippetUserRegistrationVerificationRecordCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="DeleteWhippetUserRegistrationVerificationRecordCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(DeleteWhippetUserRegistrationVerificationRecordCommand command)
        {
            WhippetResult result = WhippetResult.Success;

            if (command == null || command.VerificationRecord == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }

            return result;
        }
    }
}
