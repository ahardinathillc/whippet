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
    /// Command handler for <see cref="UpdateSalesforceOpportunityCommand"/> objects.
    /// </summary>
    public class UpdateSalesforceOpportunityCommandHandler : SalesforceOpportunityCommandHandlerBase<UpdateSalesforceOpportunityCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSalesforceOpportunityCommandHandler"/> class with the specified <see cref="ISalesforceOpportunityRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ISalesforceOpportunityRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public UpdateSalesforceOpportunityCommandHandler(ISalesforceOpportunityRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="UpdateSalesforceOpportunityCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(UpdateSalesforceOpportunityCommand command)
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
                    result = await ((IWhippetRepository<SalesforceOpportunity, SalesforceReference>)(Repository)).UpdateAsync(command.Opportunity);
                }

                return result;
            }
        }
    }
}
