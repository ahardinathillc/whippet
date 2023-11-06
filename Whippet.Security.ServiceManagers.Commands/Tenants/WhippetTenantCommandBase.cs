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
    /// Base class for all <see cref="IWhippetTenantCommand"/> objects. This class must be inherited.
    /// </summary>
    public abstract class WhippetTenantCommandBase : WhippetCommand, IWhippetCommand, IWhippetTenantCommand
    {
        /// <summary>
        /// Gets the <see cref="WhippetTenant"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public WhippetTenant Tenant
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IWhippetUser"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IWhippetTenant IWhippetTenantCommand.Tenant
        {
            get
            {
                return Tenant;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetTenantCommandBase"/> class with no arguments.
        /// </summary>
        protected WhippetTenantCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetTenantCommandBase"/> class.
        /// </summary>
        /// <param name="record"><see cref="WhippetTenant"/> instance to create or act upon in the data store.</param>
        protected WhippetTenantCommandBase(WhippetTenant record)
            : base()
        {
            Tenant = record;
        }
    }
}
