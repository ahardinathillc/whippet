using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="SalesforceProduct"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class DeleteSalesforceProductCommand : SalesforceProductCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSalesforceProductCommand"/> class with no arguments.
        /// </summary>
        private DeleteSalesforceProductCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSalesforceProductCommand"/> class with the specified <see cref="SalesforceProduct"/>.
        /// </summary>
        /// <param name="product"><see cref="SalesforceProduct"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DeleteSalesforceProductCommand(SalesforceProduct product)
            : base(product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
        }
    }
}
