using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet;
using Athi.Whippet.Salesforce.Repositories;

namespace Athi.Whippet.Salesforce.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="SalesforceOpportunity"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface ISalesforceOpportunityQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, SalesforceOpportunity> where TQuery : IWhippetQuery<SalesforceOpportunity>
    { }
}
