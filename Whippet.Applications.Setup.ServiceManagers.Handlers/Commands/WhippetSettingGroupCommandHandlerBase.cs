using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Applications.Setup.ServiceManagers.Commands;
using Athi.Whippet.Applications.Setup.Repositories;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Base command class for all <see cref="IWhippetSettingGroupCommand"/> handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetSettingGroupCommand"/> command type to handle.</typeparam>
    public abstract class WhippetSettingGroupCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IWhippetSettingGroupCommandHandler<TCommand>
        where TCommand : IWhippetSettingGroupCommand
    {
        /// <summary>
        /// Gets the internal <see cref="IWhippetSettingGroupRepository"/> to execute the commands against. This property is read-only.
        /// </summary>
        protected IWhippetSettingGroupRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSettingGroupCommandHandlerBase{TCommand}"/> class with the specified <see cref="IWhippetSettingGroupRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetSettingGroupRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetSettingGroupCommandHandlerBase(IWhippetSettingGroupRepository repository)
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

        /// <summary>
        /// Validates the specified <typeparamref name="TCommand"/> object.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(TCommand command)
        {
            WhippetResult result = WhippetResult.Success;

            if (command == null || command.Group == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }

            return result;
        }
    }
}
