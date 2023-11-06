using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="MagentoServer"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface IMagentoServerQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, MagentoServer> where TQuery : IWhippetQuery<MagentoServer>
    { }
}
