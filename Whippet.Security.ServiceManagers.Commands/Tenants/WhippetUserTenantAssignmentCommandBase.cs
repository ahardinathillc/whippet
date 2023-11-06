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
    /// Base class for all <see cref="IWhippetUserTenantAssignmentCommand"/> objects. This class must be inherited.
    /// </summary>
    public abstract class WhippetUserTenantAssignmentCommandBase : WhippetCommand, IWhippetCommand, IWhippetUserTenantAssignmentCommand
    {
        /// <summary>
        /// Gets the <see cref="WhippetUserTenantAssignment"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public WhippetUserTenantAssignment Assignment
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IWhippetUser"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IWhippetUserTenantAssignment IWhippetUserTenantAssignmentCommand.Assignment
        {
            get
            {
                return Assignment;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserTenantAssignmentCommandBase"/> class with no arguments.
        /// </summary>
        protected WhippetUserTenantAssignmentCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserTenantAssignmentCommandBase"/> class.
        /// </summary>
        /// <param name="record"><see cref="WhippetUserTenantAssignment"/> instance to create or act upon in the data store.</param>
        protected WhippetUserTenantAssignmentCommandBase(WhippetUserTenantAssignment record)
            : base()
        {
            Assignment = record;
        }
    }
}
