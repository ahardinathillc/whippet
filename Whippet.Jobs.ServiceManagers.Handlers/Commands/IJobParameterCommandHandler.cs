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
    /// Handles commands for <see cref="IJobParameter"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IJobParameter"/> object to handle.</typeparam>
    public interface IJobParameterCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : IJobParameterCommand
    { }
}
