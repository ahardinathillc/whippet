using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Salesforce.ServiceManagers.Commands;
using Athi.Whippet.Salesforce.Repositories;

namespace Athi.Whippet.Salesforce.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="DeleteSalesforceClientProfileCommand"/> objects.
    /// </summary>
    public class DeleteSalesforceClientProfileCommandHandler : SalesforceClientProfileCommandHandlerBase<DeleteSalesforceClientProfileCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSalesforceClientProfileCommandHandler"/> class with the specified <see cref="ISalesForceClientProfileRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ISalesforceClientProfileRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public DeleteSalesforceClientProfileCommandHandler(ISalesforceClientProfileRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="DeleteSalesforceClientProfileCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(DeleteSalesforceClientProfileCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            else
            {
                WhippetResult result = Validate(command);

                if (result.IsSuccess)
                {
                    result = await Repository.DeleteAsync(command.Profile);
                }

                return result;
            }
        }
    }
}
