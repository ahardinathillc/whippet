using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Security.Tenants.ServiceManagers.Commands
{
    /// <summary>
    /// Represents a command that acts upon <see cref="IWhippetTenant"/> objects.
    /// </summary>
    public interface IWhippetTenantCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="IWhippetTenantCommand"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IWhippetTenant Tenant
        { get; }
    }
}
