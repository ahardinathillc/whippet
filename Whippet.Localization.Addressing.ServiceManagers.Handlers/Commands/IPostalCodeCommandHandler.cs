using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Localization.Addressing.ServiceManagers.Commands;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Handles commands for <see cref="IPostalCode"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IPostalCodeCommand"/> object to handle.</typeparam>
    public interface IPostalCodeCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : IPostalCodeCommand
    { }
}
