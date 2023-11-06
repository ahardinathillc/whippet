using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.ServiceManagers.Commands;
using Athi.Whippet.Security.Repositories;

namespace Athi.Whippet.Security.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Base class for <see cref="IWhippetUserRegistrationVerificationRecordCommand"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetUserRegistrationVerificationRecordCommand"/> type to handle.</typeparam>
    public abstract class WhippetUserRegistrationVerificationRecordCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IWhippetUserRegistrationVerificationRecordCommandHandler<TCommand>
        where TCommand : IWhippetUserRegistrationVerificationRecordCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="IWhippetUserRegistrationVerificationRecordRepository"/> to execute the commands against.
        /// </summary>
        protected IWhippetUserRegistrationVerificationRecordRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserRegistrationVerificationRecordCommandHandlerBase{TCommand}"/> class with the specified <see cref="IWhippetUserRegistrationVerificationRecordRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetUserRegistrationVerificationRecordRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetUserRegistrationVerificationRecordCommandHandlerBase(IWhippetUserRegistrationVerificationRecordRepository repository)
            : base()
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            else
            {
                Repository = repository;
            }
        }
    }
}
