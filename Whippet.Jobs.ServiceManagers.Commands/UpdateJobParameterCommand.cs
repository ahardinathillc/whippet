using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Jobs.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <typeparamref name="TJobParameter"/> object in the data store.
    /// </summary>
    public class UpdateJobParameterCommand<TJobParameter, TJob> : JobParameterCommandBase<TJobParameter, TJob>, IJobParameterCommand
        where TJob : JobBase, IJob, new()
        where TJobParameter : JobParameterBase<TJob>, IJobParameter, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateJobParameterCommand{TJobParameter, TJob}"/> class with no arguments.
        /// </summary>
        private UpdateJobParameterCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateJobParameterCommand{TJobParameter, TJob}"/> class with the specified <typeparamref name="TJobParameter"/>.
        /// </summary>
        /// <param name="job"><typeparamref name="TJobParameter"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateJobParameterCommand(TJobParameter job)
            : base(job)
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }
        }
    }
}
