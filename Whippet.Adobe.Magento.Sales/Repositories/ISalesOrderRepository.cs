using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Repositories;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Sales.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="SalesOrder"/> entity objects.
    /// </summary>
    public interface ISalesOrderRepository : IWhippetRepository<SalesOrder, int>, IWhippetExternalQueryRepository<SalesOrder, int>, IMagentoEntityRepository<SalesOrder>
    { }
}
