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
    /// Query handler for <see cref="GetDefaultWhippetSmtpServerProfileQuery"/> objects.
    /// </summary>
    public class GetDefaultWhippetSmtpServerProfileQueryHandler : WhippetSmtpServerProfileQueryHandlerBase<GetDefaultWhippetSmtpServerProfileQuery>, IWhippetSmtpServerProfileQueryHandler<GetDefaultWhippetSmtpServerProfileQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetDefaultWhippetSmtpServerProfileQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetDefaultWhippetSmtpServerProfileQueryHandler(IWhippetQueryRepository<WhippetSmtpServerProfile> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<WhippetSmtpServerProfile>>> HandleAsync(GetDefaultWhippetSmtpServerProfileQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<WhippetSmtpServerProfile> queryResult = await Repository.GetDefaultProfileAsync(query.Tenant);
                return queryResult.ToEnumerableResult();
            }
        }
    }
}
