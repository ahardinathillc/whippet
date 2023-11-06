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
    /// Command handler for <see cref="DeleteJobParameterCommand{TJobParameter, TJob}"/> objects.
    /// </summary>
    public class DeleteJobParameterCommandHandler<TJobParameter, TJob> : JobParameterCommandHandlerBase<DeleteJobParameterCommand<TJobParameter, TJob>, TJobParameter, TJob>
        where TJob : JobBase, IJob, new()
        where TJobParameter : JobParameterBase<TJob>, IJobParameter, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteJobParameterCommandHandler{TJobParameter, TJob}"/> class with the specified <see cref="IJobParameterRepository{TJobParameter, TJob}"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IJobParameterRepository{TJobParameter, TJob}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public DeleteJobParameterCommandHandler(IJobParameterRepository<TJobParameter, TJob> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="IJobCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(DeleteJobParameterCommand<TJobParameter, TJob> command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            else
            {
                WhippetResult result = Validate(command);

                if (result.IsSuccess)
                {
                    result = await Repository.DeleteAsync(command.Parameter);
                }

                return result;
            }
        }
    }
}
