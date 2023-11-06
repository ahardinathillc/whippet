using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Security.Tenants.ServiceManagers.Commands
{
    /// <summary>
    /// Command for updating <see cref="WhippetUserTenantAssignment"/> objects in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateWhippetUserTenantAssignmentCommand : WhippetUserTenantAssignmentCommandBase, IWhippetUserTenantAssignmentCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetUserTenantAssignmentCommand"/> class with the specified <see cref="WhippetUserTenantAssignment"/> object.
        /// </summary>
        /// <param name="assignment"><see cref="WhippetUserTenantAssignment"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public UpdateWhippetUserTenantAssignmentCommand(WhippetUserTenantAssignment assignment)
            : base(assignment)
        { }
    }
}
