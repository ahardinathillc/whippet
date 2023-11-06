using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.ServiceManagers.Queries;

namespace Athi.Whippet.Security.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetWhippetUserByIdQuery"/> objects.
    /// </summary>
    public class GetWhippetUserByIdQueryHandler : WhippetUserQueryHandlerBase<GetWhippetUserByIdQuery>, IWhippetUserQueryHandler<GetWhippetUserByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserByIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetWhippetUserByIdQueryHandler(IWhippetQueryRepository<WhippetUser> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<WhippetUser>>> HandleAsync(GetWhippetUserByIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<WhippetUser> queryResult = await Repository.GetAsync(query.UserId);
                return new WhippetResultContainer<IEnumerable<WhippetUser>>(queryResult.Result, new[] { queryResult.Item });
            }
        }
    }
}
