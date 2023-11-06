using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="SalesforceContact"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateSalesforceContactCommand : SalesforceContactCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSalesforceContactCommand"/> class with no arguments.
        /// </summary>
        private UpdateSalesforceContactCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSalesforceContactCommand"/> class with the specified <see cref="SalesforceContact"/>.
        /// </summary>
        /// <param name="contact"><see cref="SalesforceContact"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateSalesforceContactCommand(SalesforceContact contact)
            : base(contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }
        }
    }
}
