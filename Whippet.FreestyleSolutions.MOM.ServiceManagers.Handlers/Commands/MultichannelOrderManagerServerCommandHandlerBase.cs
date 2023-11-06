using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Commands;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Commands
{
    public abstract class MultichannelOrderManagerServerCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IMultichannelOrderManagerServerCommandHandler<TCommand>
        where TCommand : IMultichannelOrderManagerServerCommand
    {
        /// <summary>
        /// Gets the internal <see cref="IAthiDomainAccountRepository"/> to execute the commands against. This property is read-only.
        /// </summary>
        protected IMultichannelOrderManagerServerRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerServerCommandHandlerBase{TCommand}"/> class with the specified <see cref="IMultichannelOrderManagerServerRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMultichannelOrderManagerServerRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerServerCommandHandlerBase(IMultichannelOrderManagerServerRepository repository)
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

            if (command == null || command.Server == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }

            return result;
        }
    }
}
