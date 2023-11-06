using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="SalesforceLead"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateSalesforceLeadCommand : SalesforceLeadCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSalesforceLeadCommand"/> class with no arguments.
        /// </summary>
        private CreateSalesforceLeadCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSalesforceLeadCommand"/> class with the specified <see cref="SalesforceLead"/>.
        /// </summary>
        /// <param name="lead"><see cref="SalesforceLead"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateSalesforceLeadCommand(SalesforceLead lead)
            : base(lead)
        {
            if (lead == null)
            {
                throw new ArgumentNullException(nameof(lead));
            }
        }
    }
}
