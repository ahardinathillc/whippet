using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Networking.Smtp.Repositories;

namespace Athi.Whippet.Networking.Smtp.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Base class for all <see cref="IWhippetQuery{TEntity}"/> handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TQuery">Type of query the handler intercepts.</typeparam>
    public abstract class WhippetSmtpServerProfileQueryHandlerBase<TQuery> : WhippetQueryHandler<WhippetSmtpServerProfile>, IWhippetQueryHandler<TQuery, WhippetSmtpServerProfile>, IWhippetSmtpServerProfileQueryHandler<TQuery>
        where TQuery : IWhippetQuery<WhippetSmtpServerProfile>
    {
        /// <summary>
        /// Gets the <see cref="IWhippetSmtpServerProfileRepository"/> that the queries are executed against. This property is read-only.
        /// </summary>
        protected new IWhippetSmtpServerProfileRepository Repository
        {
            get
            {
                return base.Repository as IWhippetSmtpServerProfileRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSmtpServerProfileQueryHandlerBase{TQuery}"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        protected WhippetSmtpServerProfileQueryHandlerBase(IWhippetQueryRepository<WhippetSmtpServerProfile> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously. This method must be overridden.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<IEnumerable<WhippetSmtpServerProfile>>> HandleAsync(TQuery query);

        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<WhippetSmtpServerProfile>> Handle(TQuery query)
        {
            return Task.Run(() => HandleAsync(query)).Result;
        }
    }
}
