using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="MultichannelOrderManagerRestEndpoint"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface IMultichannelOrderManagerRestEndpointQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, MultichannelOrderManagerRestEndpoint> where TQuery : IWhippetQuery<MultichannelOrderManagerRestEndpoint>
    { }
}
