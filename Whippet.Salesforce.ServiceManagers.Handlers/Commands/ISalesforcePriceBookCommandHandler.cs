using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Salesforce.ServiceManagers.Commands;

namespace Athi.Whippet.Salesforce.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Handles commands for <see cref="ISalesforcePriceBookCommand"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="ISalesforcePriceBookCommand"/> object to handle.</typeparam>
    public interface ISalesforcePriceBookCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : ISalesforcePriceBookCommand
    { }
}
