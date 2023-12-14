using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.Repositories;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Base class for all <see cref="IWhippetQuery{TEntity}"/> handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TQuery">Type of query the handler intercepts.</typeparam>
    public abstract class LegacyDigitalLibraryServerQueryHandlerBase<TQuery> : WhippetQueryHandler<LegacyDigitalLibraryServer>, IWhippetQueryHandler<TQuery, LegacyDigitalLibraryServer>, ILegacyDigitalLibraryServerQueryHandler<TQuery>
        where TQuery : IWhippetQuery<LegacyDigitalLibraryServer>
    {
        /// <summary>
        /// Gets the <see cref="ILegacyDigitalLibraryServerRepository"/> that the queries are executed against. This property is read-only.
        /// </summary>
        protected new ILegacyDigitalLibraryServerRepository Repository
        {
            get
            {
                return base.Repository as ILegacyDigitalLibraryServerRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyDigitalLibraryServerQueryHandlerBase{TQuery}"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        protected LegacyDigitalLibraryServerQueryHandlerBase(IWhippetQueryRepository<LegacyDigitalLibraryServer> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously. This method must be overridden.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<IEnumerable<LegacyDigitalLibraryServer>>> HandleAsync(TQuery query);

        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<LegacyDigitalLibraryServer>> Handle(TQuery query)
        {
            return Task.Run(() => HandleAsync(query)).Result;
        }        
    }
}
