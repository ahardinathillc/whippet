using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.ParadoxLabs.Magento.Subscriptions.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="Subscription"/> entity objects.
    /// </summary>
    public interface ISubscriptionRepository : IWhippetRepository<Subscription, int>, IWhippetExternalQueryRepository<Subscription, int>, IMagentoEntityRepository<Subscription>
    { }
}
