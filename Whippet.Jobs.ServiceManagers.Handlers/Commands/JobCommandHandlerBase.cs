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
    /// Base class for <see cref="IJob"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IJob"/> type to handle.</typeparam>
    public abstract class JobCommandHandlerBase<TCommand, TJob> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IJobCommandHandler<TCommand>
        where TCommand : IJobCommand
        where TJob : JobBase, IJob, new()
    {
        /// <summary>
        /// Gets the internal <see cref="IJobRepository{TJob}"/> to execute the commands against. This property is read-only.
        /// </summary>
        protected IJobRepository<TJob> Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobCommandHandlerBase{TCommand, TJob}"/> class with the specified <see cref="IJobRepository{TJob}"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IJobRepository{TJob}"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public JobCommandHandlerBase(IJobRepository<TJob> repository)
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

            if (command == null || command.Job == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }

            return result;
        }
    }
}
