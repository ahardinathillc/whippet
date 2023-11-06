using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.ServiceManagers.Queries;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Security.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetWhippetIpAddressBlacklistQuery"/> objects.
    /// </summary>
    public class GetWhippetIpAddressBlacklistQueryHandler : WhippetIpAddressBlacklistQueryHandlerBase<GetWhippetIpAddressBlacklistQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetIpAddressBlacklistQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetWhippetIpAddressBlacklistQueryHandler(IWhippetQueryRepository<WhippetIpAddressBlacklist> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<WhippetIpAddressBlacklist>>> HandleAsync(GetWhippetIpAddressBlacklistQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<WhippetIpAddressBlacklist>> result = null;

                // determine which method to call

                if (String.IsNullOrWhiteSpace(query.IPAddress))
                {
                    if(query.Tenant == null)
                    {
                        result = await Repository.GetAllAsync();
                    }
                    else
                    {
                        result = await Repository.GetAsync(null, query.Tenant);
                    }
                }
                else
                {
                    result = await Repository.GetAsync(query.IPAddress, query.Tenant);
                }

                return result;
            }
        }
    }
}
