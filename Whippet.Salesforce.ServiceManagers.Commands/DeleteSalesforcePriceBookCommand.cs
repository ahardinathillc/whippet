using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="SalesforcePriceBook"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class DeleteSalesforcePriceBookCommand : SalesforcePriceBookCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSalesforcePriceBookCommand"/> class with no arguments.
        /// </summary>
        private DeleteSalesforcePriceBookCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSalesforcePriceBookCommand"/> class with the specified <see cref="SalesforcePriceBook"/>.
        /// </summary>
        /// <param name="priceBook"><see cref="SalesforcePriceBook"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DeleteSalesforcePriceBookCommand(SalesforcePriceBook priceBook)
            : base(priceBook)
        {
            if (priceBook == null)
            {
                throw new ArgumentNullException(nameof(priceBook));
            }
        }
    }
}
