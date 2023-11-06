using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Jobs.ServiceManagers.Commands;

namespace Athi.Whippet.Jobs.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Handles commands for <see cref="IJobCategory"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IJobCategory"/> object to handle.</typeparam>
    public interface IJobCategoryCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : IJobCategoryCommand
    { }
}
