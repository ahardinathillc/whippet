using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="TaxRate"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface ITaxRateQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, TaxRate> where TQuery : IWhippetQuery<TaxRate>
    {
    }
}
