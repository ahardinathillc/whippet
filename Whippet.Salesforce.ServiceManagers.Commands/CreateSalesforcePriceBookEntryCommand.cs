using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="SalesforcePriceBookEntry"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateSalesforcePriceBookEntryCommand : SalesforcePriceBookEntryCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSalesforcePriceBookEntryCommand"/> class with no arguments.
        /// </summary>
        private CreateSalesforcePriceBookEntryCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSalesforcePriceBookEntryCommand"/> class with the specified <see cref="SalesforcePriceBookEntry"/>.
        /// </summary>
        /// <param name="entry"><see cref="SalesforcePriceBookEntry"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateSalesforcePriceBookEntryCommand(SalesforcePriceBookEntry entry)
            : base(entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }
        }
    }
}
