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
    /// Handles commands for <see cref="ICountry"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="ICountryCommand"/> object to handle.</typeparam>
    public interface ICountryCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : ICountryCommand
    { }
}
