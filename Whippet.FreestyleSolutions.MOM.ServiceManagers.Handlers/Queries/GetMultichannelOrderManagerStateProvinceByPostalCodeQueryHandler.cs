using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetMultichannelOrderManagerStateProvinceByIdQuery"/> objects.
    /// </summary>
    public class GetMultichannelOrderManagerStateProvinceByPostalCodeQueryHandler : MultichannelOrderManagerStateProvinceQueryHandlerBase<GetMultichannelOrderManagerStateProvinceByPostalCodeQuery>, IMultichannelOrderManagerStateProvinceQueryHandler<GetMultichannelOrderManagerStateProvinceByPostalCodeQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerStateProvinceByPostalCodeQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetMultichannelOrderManagerStateProvinceByPostalCodeQueryHandler(IWhippetQueryRepository<MultichannelOrderManagerStateProvince> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>>> HandleAsync(GetMultichannelOrderManagerStateProvinceByPostalCodeQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<MultichannelOrderManagerStateProvince> result = await Repository.GetStateProvinceByPostalCodeAsync(query.PostalCode);
                return new WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>>(result.Result, new[] { result.Item });
            }
        }
    }
}
