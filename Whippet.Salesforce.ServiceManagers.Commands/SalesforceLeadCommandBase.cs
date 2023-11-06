using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="SalesforceLead"/> objects. This class must be inherited.
    /// </summary>
    public abstract class SalesforceLeadCommandBase : WhippetCommand, IWhippetCommand, ISalesforceLeadCommand
    {
        /// <summary>
        /// Gets the <see cref="SalesforceLead"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public SalesforceLead Lead
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="ISalesforceLead"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        ISalesforceLead ISalesforceLeadCommand.Lead
        {
            get
            {
                return Lead;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceLeadCommandBase"/> class with no arguments.
        /// </summary>
        protected SalesforceLeadCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceLeadCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="server"><see cref="SalesforceLead"/> instance to create or act upon in the data store.</param>
        protected SalesforceLeadCommandBase(SalesforceLead contact)
            : base()
        {
            Lead = contact;
        }
    }
}
