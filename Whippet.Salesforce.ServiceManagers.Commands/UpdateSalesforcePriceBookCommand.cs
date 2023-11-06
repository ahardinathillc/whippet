using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="SalesforcePriceBook"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateSalesforcePriceBookCommand : SalesforcePriceBookCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSalesforcePriceBookCommand"/> class with no arguments.
        /// </summary>
        private UpdateSalesforcePriceBookCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSalesforcePriceBookCommand"/> class with the specified <see cref="SalesforcePriceBook"/>.
        /// </summary>
        /// <param name="priceBook"><see cref="SalesforcePriceBook"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateSalesforcePriceBookCommand(SalesforcePriceBook priceBook)
            : base(priceBook)
        {
            if (priceBook == null)
            {
                throw new ArgumentNullException(nameof(priceBook));
            }
        }
    }
}
