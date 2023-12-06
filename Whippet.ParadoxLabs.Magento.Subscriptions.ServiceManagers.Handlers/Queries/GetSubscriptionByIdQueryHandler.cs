using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.ParadoxLabs.Magento.Subscriptions.ServiceManagers.Queries;

namespace Athi.Whippet.ParadoxLabs.Magento.Subscriptions.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetSubscriptionByIdQuery"/> objects.
    /// </summary>
    public class GetSubscriptionByIdQueryHandler : SubscriptionQueryHandlerBase<GetSubscriptionByIdQuery>, ISubscriptionQueryHandler<GetSubscriptionByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSubscriptionByIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetSubscriptionByIdQueryHandler(IWhippetQueryRepository<Subscription> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<Subscription>>> HandleAsync(GetSubscriptionByIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<Subscription> queryResult = await ((IWhippetRepository<Subscription, uint>)(Repository)).GetAsync(query.ID);
                return new WhippetResultContainer<IEnumerable<Subscription>>(queryResult.Result, new[] { queryResult.Item });
            }
        }
    }
}
