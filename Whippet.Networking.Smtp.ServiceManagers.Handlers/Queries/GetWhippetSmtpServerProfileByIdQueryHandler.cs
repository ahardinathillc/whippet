using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Networking.Smtp.ServiceManagers.Queries;

namespace Athi.Whippet.Networking.Smtp.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetWhippetSmtpServerProfileByIdQuery"/> objects.
    /// </summary>
    public class GetWhippetSmtpServerProfileByIdQueryHandler : WhippetSmtpServerProfileQueryHandlerBase<GetWhippetSmtpServerProfileByIdQuery>, IWhippetSmtpServerProfileQueryHandler<GetWhippetSmtpServerProfileByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetSmtpServerProfileByIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetWhippetSmtpServerProfileByIdQueryHandler(IWhippetQueryRepository<WhippetSmtpServerProfile> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<WhippetSmtpServerProfile>>> HandleAsync(GetWhippetSmtpServerProfileByIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<WhippetSmtpServerProfile> queryResult = await Repository.GetAsync(query.ID);
                return queryResult.ToEnumerableResult();
            }
        }
    }
}
