using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Jobs.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <typeparamref name="TJob"/> object in the data store.
    /// </summary>
    public class DeleteJobCommand<TJob> : JobCommandBase<TJob>, IJobCommand
        where TJob : JobBase, IJob, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteJobCommand{TJob}"/> class with no arguments.
        /// </summary>
        private DeleteJobCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteJobCommand{TJob}"/> class with the specified <typeparamref name="TJob"/>.
        /// </summary>
        /// <param name="job"><typeparamref name="TJob"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DeleteJobCommand(TJob job)
            : base(job)
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }
        }
    }
}
