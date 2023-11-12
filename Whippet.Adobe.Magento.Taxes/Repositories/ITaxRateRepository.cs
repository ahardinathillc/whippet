using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Repositories;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Taxes.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="TaxRate"/> entity objects.
    /// </summary>
    public interface ITaxRateRepository : IWhippetRepository<TaxRate, int>, IWhippetExternalQueryRepository<TaxRate, int>, IMagentoBulkSupport<TaxRate>, IMagentoEntityRepository<TaxRate>
    { }
}