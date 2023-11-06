using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Jobs.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <typeparamref name="TJobParameter"/> objects. This class must be inherited.
    /// </summary>
    public abstract class JobParameterCommandBase<TJobParameter, TJob> : WhippetCommand, IWhippetCommand, IJobParameterCommand
        where TJobParameter : JobParameterBase<TJob>, IJobParameter, new()
        where TJob : JobBase, IJob, new()
    {
        /// <summary>
        /// Gets the <typeparamref name="TJobParameter"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public TJobParameter Parameter
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IJobParameter"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IJobParameter IJobParameterCommand.Parameter
        {
            get
            {
                return Parameter;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobParameterCommandBase{TJobParameter, TJob}"/> class with no arguments.
        /// </summary>
        protected JobParameterCommandBase()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobParameterCommandBase{TJobParameter, TJob}"/> class with the specified <typeparamref name="TJobParameter"/> object.
        /// </summary>
        /// <param name="parameter"><typeparamref name="TJobParameter"/> object to initialize with.</param>
        protected JobParameterCommandBase(TJobParameter parameter)
            : this()
        {
            Parameter = parameter;
        }
    }
}
