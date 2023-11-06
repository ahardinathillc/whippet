using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants.ServiceManagers.Commands;

namespace Athi.Whippet.Security.Tenants.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Handles commands for <see cref="IWhippetTenantCommand"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetTenantCommand"/> object to handle.</typeparam>
    public interface IWhippetTenantCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : IWhippetTenantCommand
    { }
}
