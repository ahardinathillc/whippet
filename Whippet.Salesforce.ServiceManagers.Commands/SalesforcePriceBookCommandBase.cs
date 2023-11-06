using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="SalesforcePriceBook"/> objects. This class must be inherited.
    /// </summary>
    public abstract class SalesforcePriceBookCommandBase : WhippetCommand, IWhippetCommand, ISalesforcePriceBookCommand
    {
        /// <summary>
        /// Gets the <see cref="SalesforcePriceBook"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public SalesforcePriceBook PriceBook
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="ISalesforcePriceBook"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        ISalesforcePriceBook ISalesforcePriceBookCommand.PriceBook
        {
            get
            {
                return PriceBook;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforcePriceBookCommandBase"/> class with no arguments.
        /// </summary>
        protected SalesforcePriceBookCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforcePriceBookCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="priceBook"><see cref="SalesforcePriceBook"/> instance to create or act upon in the data store.</param>
        protected SalesforcePriceBookCommandBase(SalesforcePriceBook priceBook)
            : base()
        {
            PriceBook = priceBook;
        }
    }
}
