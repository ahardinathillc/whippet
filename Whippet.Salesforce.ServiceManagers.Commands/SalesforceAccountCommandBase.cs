using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="SalesforceAccount"/> objects. This class must be inherited.
    /// </summary>
    public abstract class SalesforceAccountCommandBase : WhippetCommand, IWhippetCommand, ISalesforceAccountCommand
    {
        /// <summary>
        /// Gets the <see cref="SalesforceAccount"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public SalesforceAccount Account
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="ISalesforceAccount"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        ISalesforceAccount ISalesforceAccountCommand.Account
        {
            get
            {
                return Account;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceAccountCommandBase"/> class with no arguments.
        /// </summary>
        protected SalesforceAccountCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceAccountCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="server"><see cref="SalesforceAccount"/> instance to create or act upon in the data store.</param>
        protected SalesforceAccountCommandBase(SalesforceAccount account)
            : base()
        {
            Account = account;
        }
    }
}
