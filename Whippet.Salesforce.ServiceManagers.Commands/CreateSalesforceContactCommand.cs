using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="SalesforceContact"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateSalesforceContactCommand : SalesforceContactCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSalesforceContactCommand"/> class with no arguments.
        /// </summary>
        private CreateSalesforceContactCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSalesforceContactCommand"/> class with the specified <see cref="SalesforceContact"/>.
        /// </summary>
        /// <param name="contact"><see cref="SalesforceContact"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateSalesforceContactCommand(SalesforceContact contact)
            : base(contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }
        }
    }
}
