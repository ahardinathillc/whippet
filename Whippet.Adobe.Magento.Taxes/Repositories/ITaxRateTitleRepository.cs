using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Repositories;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Taxes.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="TaxRateTitle"/> entity objects.
    /// </summary>
    public interface ITaxRateTitleRepository : IWhippetRepository<TaxRateTitle, int>, IWhippetExternalQueryRepository<TaxRateTitle, int>, IMagentoBulkSupport<TaxRateTitle>, IMagentoEntityRepository<TaxRateTitle>
    { }
}
