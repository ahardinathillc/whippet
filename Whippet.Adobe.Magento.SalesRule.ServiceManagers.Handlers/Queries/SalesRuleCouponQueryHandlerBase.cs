using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.SalesRule.Repositories;

namespace Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Base class for all <see cref="IWhippetQuery{TEntity}"/> handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TQuery">Type of query the handler intercepts.</typeparam>
    public abstract class SalesRuleCouponQueryHandlerBase<TQuery> : WhippetQueryHandler<SalesRuleCoupon>, IWhippetQueryHandler<TQuery, SalesRuleCoupon>, ISalesRuleCouponQueryHandler<TQuery>
        where TQuery : IWhippetQuery<SalesRuleCoupon>
    {
        /// <summary>
        /// Gets the <see cref="ISalesRuleCouponRepository"/> that the queries are executed against. This property is read-only.
        /// </summary>
        protected new ISalesRuleCouponRepository Repository
        {
            get
            {
                return base.Repository as ISalesRuleCouponRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleCouponQueryHandlerBase{TQuery}"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        protected SalesRuleCouponQueryHandlerBase(IWhippetQueryRepository<SalesRuleCoupon> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously. This method must be overridden.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<IEnumerable<SalesRuleCoupon>>> HandleAsync(TQuery query);

        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<SalesRuleCoupon>> Handle(TQuery query)
        {
            return Task.Run(() => HandleAsync(query)).Result;
        }
    }
}
