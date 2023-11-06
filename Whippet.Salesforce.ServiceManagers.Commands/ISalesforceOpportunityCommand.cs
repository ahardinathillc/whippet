using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Provides support for all commands that act upon <see cref="ISalesforceOpportunityCommand"/> objects.
    /// </summary>
    public interface ISalesforceOpportunityCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="ISalesforceOpportunity"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public ISalesforceOpportunity Opportunity
        { get; }
    }
}
