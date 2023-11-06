using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Exports.ServiceManagers.Queries;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Exports.ServiceManagers.Handlers.Queries
{
    public class GetAllMultichannelOrderManagerFlattenedTaxRateExportsQueryHandler : MultichannelOrderManagerFlattenedTaxRateExportQueryHandlerBase<GetAllMultichannelOrderManagerFlattenedTaxRateExportsQuery>, IMultichannelOrderManagerFlattenedTaxRateExportQueryHandler<GetAllMultichannelOrderManagerFlattenedTaxRateExportsQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllMultichannelOrderManagerFlattenedTaxRateExportsQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetAllMultichannelOrderManagerFlattenedTaxRateExportsQueryHandler(IWhippetQueryRepository<MultichannelOrderManagerFlattenedTaxRateExport> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>> HandleAsync(GetAllMultichannelOrderManagerFlattenedTaxRateExportsQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>> result = await ((IWhippetExternalQueryRepository<MultichannelOrderManagerFlattenedTaxRateExport, MultichannelOrderManagerFlattenedTaxRateExportSearchCriteria>)(Repository)).GetAllAsync();
                return new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(result.Result, result.Item);
            }
        }
    }
}
