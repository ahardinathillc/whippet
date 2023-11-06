using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="SalesforceProduct"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateSalesforceProductCommand : SalesforceProductCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSalesforceProductCommand"/> class with no arguments.
        /// </summary>
        private CreateSalesforceProductCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSalesforceProductCommand"/> class with the specified <see cref="SalesforceProduct"/>.
        /// </summary>
        /// <param name="product"><see cref="SalesforceProduct"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateSalesforceProductCommand(SalesforceProduct product)
            : base(product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
        }
    }
}
