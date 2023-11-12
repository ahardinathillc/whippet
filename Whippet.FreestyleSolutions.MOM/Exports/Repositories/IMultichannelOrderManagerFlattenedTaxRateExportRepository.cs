using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Exports.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> entity objects.
    /// </summary>
    public interface IMultichannelOrderManagerFlattenedTaxRateExportRepository : IWhippetEntityRepository<MultichannelOrderManagerFlattenedTaxRateExport, MultichannelOrderManagerFlattenedTaxRateExportSearchCriteria>, IWhippetQueryRepository<MultichannelOrderManagerFlattenedTaxRateExport>, IWhippetExternalQueryRepository<MultichannelOrderManagerFlattenedTaxRateExport, MultichannelOrderManagerFlattenedTaxRateExportSearchCriteria>
    { }
}