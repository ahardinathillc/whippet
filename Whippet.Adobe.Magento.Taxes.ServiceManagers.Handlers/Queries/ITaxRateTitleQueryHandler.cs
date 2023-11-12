using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="TaxRateTitle"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface ITaxRateTitleQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, TaxRateTitle> where TQuery : IWhippetQuery<TaxRateTitle>
    {
    }
}