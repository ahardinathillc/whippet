using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="MagentoRestEndpoint"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface IMagentoRestEndpointQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, MagentoRestEndpoint> where TQuery : IWhippetQuery<MagentoRestEndpoint>
    { }
}
