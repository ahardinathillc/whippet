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
    /// Query handler for <see cref="GetMultichannelOrderManagerPostalCodesByStateProvinceQuery"/> objects.
    /// </summary>
    public class GetMultichannelOrderManagerPostalCodesByStateProvinceQueryHandler : MultichannelOrderManagerPostalCodeQueryHandlerBase<GetMultichannelOrderManagerPostalCodesByStateProvinceQuery>, IMultichannelOrderManagerPostalCodeQueryHandler<GetMultichannelOrderManagerPostalCodesByStateProvinceQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerPostalCodesByStateProvinceQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetMultichannelOrderManagerPostalCodesByStateProvinceQueryHandler(IWhippetQueryRepository<MultichannelOrderManagerPostalCode> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>>> HandleAsync(GetMultichannelOrderManagerPostalCodesByStateProvinceQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>> result = await Repository.GetPostalCodesAsync(query.StateProvince);
                return new WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>>(result.Result, result.Item);
            }
        }
    }
}
