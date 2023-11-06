using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Jobs.ServiceManagers.Commands
{
    /// <summary>
    /// Provides support for all commands that act upon <see cref="IJob"/> objects.
    /// </summary>
    public interface IJobCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="IJob"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IJob Job
        { get; }
    }
}
