using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Jobs.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <typeparamref name="TJob"/> objects. This class must be inherited.
    /// </summary>
    public abstract class JobCommandBase<TJob> : WhippetCommand, IWhippetCommand, IJobCommand
        where TJob : JobBase, IJob, new()
    {
        /// <summary>
        /// Gets the <typeparamref name="TJob"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public TJob Job
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IJob"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IJob IJobCommand.Job
        {
            get
            {
                return Job;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobCommandBase{TJob}"/> class with no arguments.
        /// </summary>
        protected JobCommandBase()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobCommandBase{TJob}"/> class with the specified <typeparamref name="TJob"/> object.
        /// </summary>
        /// <param name="job"><typeparamref name="TJob"/> object to initialize with.</param>
        protected JobCommandBase(TJob job)
            : this()
        {
            Job = job;
        }
    }
}
