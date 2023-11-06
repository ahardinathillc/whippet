using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Sales.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="SalesOrder"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface ISalesOrderQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, SalesOrder> where TQuery : IWhippetQuery<SalesOrder>
    { }
}
