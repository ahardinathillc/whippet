using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Exports.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface IMultichannelOrderManagerFlattenedTaxRateExportQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, MultichannelOrderManagerFlattenedTaxRateExport> where TQuery : IWhippetQuery<MultichannelOrderManagerFlattenedTaxRateExport>
    { }
}
