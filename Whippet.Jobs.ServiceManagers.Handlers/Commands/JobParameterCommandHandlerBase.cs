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
    /// Base class for <see cref="IJobParameter"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand">Type of <see cref="IJobParameterCommand"/> to handle.</typeparam>
    /// <typeparam name="TJobParameter"><see cref="IJobParameter"/> type that the handler receives.</typeparam>
    /// <typeparam name="TJob"><see cref="IJob"/> type that the <typeparamref name="TJobParameter"/> is for.</typeparam>
    public abstract class JobParameterCommandHandlerBase<TCommand, TJobParameter, TJob> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IJobParameterCommandHandler<TCommand>
        where TCommand : IJobParameterCommand
        where TJob : JobBase, IJob, new()
        where TJobParameter : JobParameterBase<TJob>, IJobParameter, new()
    {
        /// <summary>
        /// Gets the internal <see cref="IJobParameterRepository{TJobParameter, TJob}"/> to execute the commands against. This property is read-only.
        /// </summary>
        protected IJobParameterRepository<TJobParameter, TJob> Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobParameterCommandHandlerBase{TCommand, TJobParameter, TJob}"/> class with the specified <see cref="IJobParameterRepository{TJobParameter, TJob}"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IJobParameterRepository{TJobParameter, TJob}"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public JobParameterCommandHandlerBase(IJobParameterRepository<TJobParameter, TJob> repository)
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

            if (command == null || command.Parameter == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }

            return result;
        }
    }
}
