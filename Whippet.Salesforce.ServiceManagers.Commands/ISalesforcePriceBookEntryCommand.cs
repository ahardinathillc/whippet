using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Provides support for all commands that act upon <see cref="ISalesforcePriceBookEntryCommand"/> objects.
    /// </summary>
    public interface ISalesforcePriceBookEntryCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="ISalesforcePriceBookEntry"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public ISalesforcePriceBookEntry PriceBookEntry
        { get; }
    }
}

