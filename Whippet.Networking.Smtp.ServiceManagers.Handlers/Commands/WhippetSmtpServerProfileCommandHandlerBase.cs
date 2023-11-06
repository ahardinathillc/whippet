using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Networking.Smtp.Repositories;
using Athi.Whippet.Networking.Smtp.ServiceManagers.Commands;

namespace Athi.Whippet.Networking.Smtp.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Base class for <see cref="IWhippetSmtpServerProfile"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetSmtpServerProfile"/> type to handle.</typeparam>
    public abstract class WhippetSmtpServerProfileCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IWhippetSmtpServerProfileCommandHandler<TCommand>
        where TCommand : IWhippetSmtpServerProfileCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="IWhippetSmtpServerProfileRepository"/> to execute the commands against.
        /// </summary>
        protected IWhippetSmtpServerProfileRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSmtpServerProfileCommandHandlerBase{TCommand}"/> class with the specified <see cref="IWhippetSmtpServerProfile"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetSmtpServerProfileRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetSmtpServerProfileCommandHandlerBase(IWhippetSmtpServerProfileRepository repository)
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
