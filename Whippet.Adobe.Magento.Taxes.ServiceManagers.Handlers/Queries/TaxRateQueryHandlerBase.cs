using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Taxes.Repositories;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Base class for all <see cref="IWhippetQuery{TEntity}"/> handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TQuery">Type of query the handler intercepts.</typeparam>
    public abstract class TaxRateQueryHandlerBase<TQuery> : WhippetQueryHandler<TaxRate>, IWhippetQueryHandler<TQuery, TaxRate>, ITaxRateQueryHandler<TQuery>
        where TQuery : IWhippetQuery<TaxRate>
    {
        /// <summary>
        /// Gets the <see cref="ITaxRateRepository"/> that the queries are executed against. This property is read-only.
        /// </summary>
        protected new ITaxRateRepository Repository
        {
            get
            {
                return base.Repository as ITaxRateRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateQueryHandlerBase{TQuery}"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        protected TaxRateQueryHandlerBase(IWhippetQueryRepository<TaxRate> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously. This method must be overridden.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<IEnumerable<TaxRate>>> HandleAsync(TQuery query);

        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<TaxRate>> Handle(TQuery query)
        {
            return Task.Run(() => HandleAsync(query)).Result;
        }
    }
}