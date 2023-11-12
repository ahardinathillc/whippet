using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="TaxClass"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface ITaxClassQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, TaxClass> where TQuery : IWhippetQuery<TaxClass>
    {
    }
}