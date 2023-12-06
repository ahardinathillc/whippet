using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.ParadoxLabs.Magento.Subscriptions.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="Subscription"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface ISubscriptionQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, Subscription> where TQuery : IWhippetQuery<Subscription>
    { }
}
