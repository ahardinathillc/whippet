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
    /// <summary>
    /// Base class for <see cref="IInvariantAddressCommand"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IInvariantAddressCommand"/> type to handle.</typeparam>
    public abstract class InvariantAddressCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IInvariantAddressCommandHandler<TCommand>
        where TCommand : IInvariantAddressCommand
    {
        /// <summary>
        /// Gets the internal <see cref="IInvariantAddressRepository"/> to execute the commands against. This property is read-only.
        /// </summary>
        protected IInvariantAddressRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvariantAddressCommandHandlerBase{TCommand}"/> class with the specified <see cref="IInvariantAddressRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IInvariantAddressRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public InvariantAddressCommandHandlerBase(IInvariantAddressRepository repository)
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

            if (command == null || command.Address == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }

            return result;
        }
    }
}
