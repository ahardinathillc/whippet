using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Jobs.ServiceManagers.Commands
{
    /// <summary>
    /// Provides support for all commands that act upon <see cref="IJobCategory"/> objects.
    /// </summary>
    public interface IJobCategoryCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="IJobCategory"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IJobCategory Category
        { get; }
    }
}
