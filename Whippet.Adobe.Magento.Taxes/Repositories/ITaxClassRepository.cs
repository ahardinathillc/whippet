using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Repositories;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Taxes.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="TaxClass"/> entity objects.
    /// </summary>
    public interface ITaxClassRepository : IWhippetRepository<TaxClass, int>, IWhippetExternalQueryRepository<TaxClass, int>, IMagentoBulkSupport<TaxClass>, IMagentoEntityRepository<TaxClass>
    { }
}
