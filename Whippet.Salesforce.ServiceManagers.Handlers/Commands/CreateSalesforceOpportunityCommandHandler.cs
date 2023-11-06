using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Salesforce.ServiceManagers.Commands;
using Athi.Whippet.Salesforce.Repositories;
using Athi.Whippet.Data;

namespace Athi.Whippet.Salesforce.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="CreateSalesforceOpportunityCommand"/> objects.
    /// </summary>
    public class CreateSalesforceOpportunityCommandHandler : SalesforceOpportunityCommandHandlerBase<CreateSalesforceOpportunityCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSalesforceOpportunityCommandHandler"/> class with the specified <see cref="ISalesforceOpportunityRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ISalesforceOpportunityRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public CreateSalesforceOpportunityCommandHandler(ISalesforceOpportunityRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="CreateSalesforceOpportunityCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(CreateSalesforceOpportunityCommand command)
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
                    result = await ((IWhippetRepository<SalesforceOpportunity, SalesforceReference>)(Repository)).CreateAsync(command.Opportunity);
                }

                return result;
            }
        }
    }
}
