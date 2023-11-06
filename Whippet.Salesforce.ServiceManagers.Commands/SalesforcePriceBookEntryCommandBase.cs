using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="SalesforcePriceBookEntry"/> objects. This class must be inherited.
    /// </summary>
    public abstract class SalesforcePriceBookEntryCommandBase : WhippetCommand, IWhippetCommand, ISalesforcePriceBookEntryCommand
    {
        /// <summary>
        /// Gets the <see cref="SalesforcePriceBookEntry"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public SalesforcePriceBookEntry PriceBookEntry
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="ISalesforcePriceBookEntry"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        ISalesforcePriceBookEntry ISalesforcePriceBookEntryCommand.PriceBookEntry
        {
            get
            {
                return PriceBookEntry;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforcePriceBookEntryCommandBase"/> class with no arguments.
        /// </summary>
        protected SalesforcePriceBookEntryCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforcePriceBookEntryCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="entry"><see cref="SalesforcePriceBookEntry"/> instance to create or act upon in the data store.</param>
        protected SalesforcePriceBookEntryCommandBase(SalesforcePriceBookEntry entry)
            : base()
        {
            PriceBookEntry = entry;
        }
    }
}
