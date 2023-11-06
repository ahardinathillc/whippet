using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="SalesforceOpportunity"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateSalesforceOpportunityCommand : SalesforceOpportunityCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSalesforceOpportunityCommand"/> class with no arguments.
        /// </summary>
        private CreateSalesforceOpportunityCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSalesforceOpportunityCommand"/> class with the specified <see cref="SalesforceOpportunity"/>.
        /// </summary>
        /// <param name="opportunity"><see cref="SalesforceOpportunity"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateSalesforceOpportunityCommand(SalesforceOpportunity opportunity)
            : base(opportunity)
        {
            if (opportunity == null)
            {
                throw new ArgumentNullException(nameof(opportunity));
            }
        }
    }
}
