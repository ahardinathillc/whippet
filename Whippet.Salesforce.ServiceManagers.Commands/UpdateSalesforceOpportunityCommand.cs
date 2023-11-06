using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="SalesforceOpportunity"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateSalesforceOpportunityCommand : SalesforceOpportunityCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSalesforceOpportunityCommand"/> class with no arguments.
        /// </summary>
        private UpdateSalesforceOpportunityCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSalesforceOpportunityCommand"/> class with the specified <see cref="SalesforceOpportunity"/>.
        /// </summary>
        /// <param name="opportunity"><see cref="SalesforceOpportunity"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateSalesforceOpportunityCommand(SalesforceOpportunity opportunity)
            : base(opportunity)
        {
            if (opportunity == null)
            {
                throw new ArgumentNullException(nameof(opportunity));
            }
        }
    }
}
