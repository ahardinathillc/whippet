using System;
using Athi.Whippet;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Exports.Repositories;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Exports.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Base class for all <see cref="IWhippetQuery{TEntity}"/> handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TQuery">Type of query the handler intercepts.</typeparam>
    public abstract class MultichannelOrderManagerFlattenedTaxRateExportQueryHandlerBase<TQuery> : WhippetQueryHandler<MultichannelOrderManagerFlattenedTaxRateExport>, IWhippetQueryHandler<TQuery, MultichannelOrderManagerFlattenedTaxRateExport>, IMultichannelOrderManagerFlattenedTaxRateExportQueryHandler<TQuery>
        where TQuery : IWhippetQuery<MultichannelOrderManagerFlattenedTaxRateExport>
    {
        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerFlattenedTaxRateExportRepository"/> that the queries are executed against. This property is read-only.
        /// </summary>
        protected new IMultichannelOrderManagerFlattenedTaxRateExportRepository Repository
        {
            get
            {
                return base.Repository as IMultichannelOrderManagerFlattenedTaxRateExportRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerFlattenedTaxRateExportQueryHandlerBase{TQuery}"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        protected MultichannelOrderManagerFlattenedTaxRateExportQueryHandlerBase(IWhippetQueryRepository<MultichannelOrderManagerFlattenedTaxRateExport> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously. This method must be overridden.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>> HandleAsync(TQuery query);

        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>> Handle(TQuery query)
        {
            return Task.Run(() => HandleAsync(query)).Result;
        }
    }
}
