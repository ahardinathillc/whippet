using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Localization.Addressing.ServiceManagers.Commands;
using Athi.Whippet.Localization.Addressing.Repositories;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Handlers.Commands
{
    public abstract class StateProvinceCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IStateProvinceCommandHandler<TCommand>
        where TCommand : IStateProvinceCommand
    {
        /// <summary>
        /// Gets the internal <see cref="IStateProvinceRepository"/> to execute the commands against. This property is read-only.
        /// </summary>
        protected IStateProvinceRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateProvinceCommandHandlerBase{TCommand}"/> class with the specified <see cref="IStateProvinceRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IStateProvinceRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public StateProvinceCommandHandlerBase(IStateProvinceRepository repository)
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

            if (command == null || command.State == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }

            return result;
        }
    }
}
