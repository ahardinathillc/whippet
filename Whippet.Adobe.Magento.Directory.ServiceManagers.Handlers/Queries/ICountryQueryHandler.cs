using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Directory.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="Country"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface ICountryQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, Country> where TQuery : IWhippetQuery<Country>
    { }
}
