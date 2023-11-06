using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="SalesforceContact"/> objects. This class must be inherited.
    /// </summary>
    public abstract class SalesforceContactCommandBase : WhippetCommand, IWhippetCommand, ISalesforceContactCommand
    {
        /// <summary>
        /// Gets the <see cref="SalesforceContact"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public SalesforceContact Contact
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="ISalesforceContact"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        ISalesforceContact ISalesforceContactCommand.Contact
        {
            get
            {
                return Contact;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceContactCommandBase"/> class with no arguments.
        /// </summary>
        protected SalesforceContactCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceContactCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="server"><see cref="SalesforceContact"/> instance to create or act upon in the data store.</param>
        protected SalesforceContactCommandBase(SalesforceContact contact)
            : base()
        {
            Contact = contact;
        }
    }
}
