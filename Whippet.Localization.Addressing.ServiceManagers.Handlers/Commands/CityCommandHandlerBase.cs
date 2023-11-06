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
    /// Base class for <see cref="ICityCommand"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="ICityCommand"/> type to handle.</typeparam>
    public abstract class CityCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, ICityCommandHandler<TCommand>
        where TCommand : ICityCommand
    {
        /// <summary>
        /// Gets the internal <see cref="ICityRepository"/> to execute the commands against. This property is read-only.
        /// </summary>
        protected ICityRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CityCommandHandlerBase{TCommand}"/> class with the specified <see cref="ICityRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ICityRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CityCommandHandlerBase(ICityRepository repository)
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

            if (command == null || command.City == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }

            return result;
        }
    }
}
