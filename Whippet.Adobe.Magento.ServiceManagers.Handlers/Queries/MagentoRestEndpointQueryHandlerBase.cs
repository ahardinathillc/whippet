using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Base class for all <see cref="IWhippetQuery{TEntity}"/> handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TQuery">Type of query the handler intercepts.</typeparam>
    public abstract class MagentoRestEndpointQueryHandlerBase<TQuery> : WhippetQueryHandler<MagentoRestEndpoint>, IWhippetQueryHandler<TQuery, MagentoRestEndpoint>, IMagentoRestEndpointQueryHandler<TQuery>
        where TQuery : IWhippetQuery<MagentoRestEndpoint>
    {
        /// <summary>
        /// Gets the <see cref="IMagentoRestEndpointRepository"/> that the queries are executed against. This property is read-only.
        /// </summary>
        protected new IMagentoRestEndpointRepository Repository
        {
            get
            {
                return base.Repository as IMagentoRestEndpointRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoRestEndpointQueryHandlerBase{TQuery}"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        protected MagentoRestEndpointQueryHandlerBase(IWhippetQueryRepository<MagentoRestEndpoint> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously. This method must be overridden.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<IEnumerable<MagentoRestEndpoint>>> HandleAsync(TQuery query);

        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<MagentoRestEndpoint>> Handle(TQuery query)
        {
            return Task.Run(() => HandleAsync(query)).Result;
        }
    }
}
