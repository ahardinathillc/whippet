using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="SalesforceAccount"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateSalesforceAccountCommand : SalesforceAccountCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSalesforceAccountCommand"/> class with no arguments.
        /// </summary>
        private CreateSalesforceAccountCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSalesforceAccountCommand"/> class with the specified <see cref="SalesforceAccount"/>.
        /// </summary>
        /// <param name="account"><see cref="SalesforceAccount"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateSalesforceAccountCommand(SalesforceAccount account)
            : base(account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
        }
    }
}
