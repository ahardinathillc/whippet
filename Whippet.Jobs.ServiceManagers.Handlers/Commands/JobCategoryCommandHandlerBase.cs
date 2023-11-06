using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Jobs.ServiceManagers.Commands;
using Athi.Whippet.Jobs.Repositories;

namespace Athi.Whippet.Jobs.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Base class for <see cref="IJobCategory"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IJobCategory"/> type to handle.</typeparam>
    public abstract class JobCategoryCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IJobCategoryCommandHandler<TCommand>
        where TCommand : IJobCategoryCommand
    {
        /// <summary>
        /// Gets the internal <see cref="IJobCategoryRepository"/> to execute the commands against. This property is read-only.
        /// </summary>
        protected IJobCategoryRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobCategoryCommandHandlerBase{TCommand}"/> class with the specified <see cref="IJobCategoryRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IJobCategoryRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public JobCategoryCommandHandlerBase(IJobCategoryRepository repository)
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

            if (command == null || command.Category == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }

            return result;
        }
    }
}
