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
    /// Base class for all <see cref="IWhippetQuery{TEntity}"/> handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TQuery">Type of query the handler intercepts.</typeparam>
    public abstract class SalesforceCampaignQueryHandlerBase<TQuery> : WhippetQueryHandler<SalesforceCampaign>, IWhippetQueryHandler<TQuery, SalesforceCampaign>, ISalesforceCampaignQueryHandler<TQuery>
        where TQuery : IWhippetQuery<SalesforceCampaign>
    {
        /// <summary>
        /// Gets the <see cref="ISalesforceCampaignRepository"/> that the queries are executed against. This property is read-only.
        /// </summary>
        protected new ISalesforceCampaignRepository Repository
        {
            get
            {
                return base.Repository as ISalesforceCampaignRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceCampaignQueryHandlerBase{TQuery}"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        protected SalesforceCampaignQueryHandlerBase(IWhippetQueryRepository<SalesforceCampaign> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously. This method must be overridden.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<IEnumerable<SalesforceCampaign>>> HandleAsync(TQuery query);

        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<SalesforceCampaign>> Handle(TQuery query)
        {
            return Task.Run(() => HandleAsync(query)).Result;
        }
    }
}
