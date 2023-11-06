using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="SalesforceClientProfile"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateSalesforceClientProfileCommand : SalesforceClientProfileCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSalesforceClientProfileCommand"/> class with no arguments.
        /// </summary>
        private CreateSalesforceClientProfileCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSalesforceClientProfileCommand"/> class with the specified <see cref="SalesforceClientProfile"/>.
        /// </summary>
        /// <param name="profile"><see cref="SalesforceClientProfile"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateSalesforceClientProfileCommand(SalesforceClientProfile profile)
            : base(profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException(nameof(profile));
            }
        }
    }
}
