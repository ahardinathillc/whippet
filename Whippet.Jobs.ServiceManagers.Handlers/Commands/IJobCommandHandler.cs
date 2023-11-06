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
    /// Handles commands for <see cref="IJob"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IJob"/> object to handle.</typeparam>
    public interface IJobCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : IJobCommand
    { }
}
