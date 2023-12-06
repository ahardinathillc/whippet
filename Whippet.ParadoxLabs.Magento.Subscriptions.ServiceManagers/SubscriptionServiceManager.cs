using System;
using System.Collections.Generic;
using System.Text;
using Athi.Whippet.Services;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.ParadoxLabs.Magento.Subscriptions.Repositories;
using Athi.Whippet.ParadoxLabs.Magento.Subscriptions.ServiceManagers.Queries;
using Athi.Whippet.ParadoxLabs.Magento.Subscriptions.ServiceManagers.Handlers.Queries;
    
namespace Athi.Whippet.ParadoxLabs.Magento.Subscriptions.ServiceManagers
{
    /// <summary>
    /// Service manager for Paradox Labs Magento subscription operations.
    /// </summary>
    public class SubscriptionServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="ISubscriptionRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual ISubscriptionRepository SubscriptionRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionServiceManager"/> class with the specified <see cref="ISubscriptionRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ISubscriptionRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SubscriptionServiceManager(ISubscriptionRepository repository)
            : base()
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            else
            {
                SubscriptionRepository = repository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionServiceManager"/> class with the specified <see cref="ISubscriptionRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="repository"><see cref="ISubscriptionRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SubscriptionServiceManager(IWhippetServiceContext serviceLocator, ISubscriptionRepository repository)
            : base(serviceLocator)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            else
            {
                SubscriptionRepository = repository;
            }
        }

        /// <summary>
        /// Gets an <see cref="ISubscription"/> object with the specified entity ID.
        /// </summary>
        /// <param name="subscriptionId">Entity ID of the <see cref="ISubscription"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        public virtual async Task<WhippetResultContainer<ISubscription>> GetSubscription(int subscriptionId)
        {
            GetSubscriptionByIdQueryHandler handler = new GetSubscriptionByIdQueryHandler(SubscriptionRepository);
            WhippetResultContainer<IEnumerable<Subscription>> result = await handler.HandleAsync(new GetSubscriptionByIdQuery(subscriptionId));
            return new WhippetResultContainer<ISubscription>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (SubscriptionRepository != null)
            {
                SubscriptionRepository.Dispose();
                SubscriptionRepository = null;
            }
        }
    }
}
