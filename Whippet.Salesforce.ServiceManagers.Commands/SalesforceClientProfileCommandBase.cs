using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="SalesforceClientProfile"/> objects. This class must be inherited.
    /// </summary>
    public abstract class SalesforceClientProfileCommandBase : WhippetCommand, IWhippetCommand, ISalesforceClientProfileCommand
    {
        /// <summary>
        /// Gets the <see cref="SalesforceClientProfile"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public SalesforceClientProfile Profile
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="ISalesforceClientProfile"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        ISalesforceClientProfile ISalesforceClientProfileCommand.Profile
        {
            get
            {
                return Profile;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceClientProfileCommandBase"/> class with no arguments.
        /// </summary>
        protected SalesforceClientProfileCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceClientProfileCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="server"><see cref="SalesforceClientProfile"/> instance to create or act upon in the data store.</param>
        protected SalesforceClientProfileCommandBase(SalesforceClientProfile profile)
            : base()
        {
            Profile = profile;
        }
    }
}
