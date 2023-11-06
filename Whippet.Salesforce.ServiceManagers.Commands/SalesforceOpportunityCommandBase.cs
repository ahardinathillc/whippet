using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="SalesforceOpportunity"/> objects. This class must be inherited.
    /// </summary>
    public abstract class SalesforceOpportunityCommandBase : WhippetCommand, IWhippetCommand, ISalesforceOpportunityCommand
    {
        /// <summary>
        /// Gets the <see cref="SalesforceOpportunity"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public SalesforceOpportunity Opportunity
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="ISalesforceOpportunity"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        ISalesforceOpportunity ISalesforceOpportunityCommand.Opportunity
        {
            get
            {
                return Opportunity;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceOpportunityCommandBase"/> class with no arguments.
        /// </summary>
        protected SalesforceOpportunityCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceOpportunityCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="server"><see cref="SalesforceOpportunity"/> instance to create or act upon in the data store.</param>
        protected SalesforceOpportunityCommandBase(SalesforceOpportunity opportunity)
            : base()
        {
            Opportunity = opportunity;
        }
    }
}
