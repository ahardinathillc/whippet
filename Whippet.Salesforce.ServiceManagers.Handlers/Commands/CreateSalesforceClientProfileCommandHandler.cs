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
    /// Command handler for <see cref="CreateSalesforceClientProfileCommand"/> objects.
    /// </summary>
    public class CreateSalesforceClientProfileCommandHandler : SalesforceClientProfileCommandHandlerBase<CreateSalesforceClientProfileCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSalesforceClientProfileCommandHandler"/> class with the specified <see cref="ISalesForceClientProfileRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ISalesforceClientProfileRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public CreateSalesforceClientProfileCommandHandler(ISalesforceClientProfileRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="CreateSalesforceClientProfileCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(CreateSalesforceClientProfileCommand command)
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
                    result = await Repository.CreateAsync(command.Profile);
                }

                return result;
            }
        }
    }
}
