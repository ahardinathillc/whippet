using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using NodaTime;
using Athi.Whippet;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Queries;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories;
using Athi.Whippet.Localization.Addressing;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IMultichannelOrderManagerOrder"/> domain objects.
    /// </summary>
    public class MultichannelOrderManagerCustomerRelationshipServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerCustomerRelationshipRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IMultichannelOrderManagerCustomerRelationshipRepository CustomerRelationshipRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCustomerRelationshipServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerOrderItemRepository"/>.
        /// </summary>
        /// <param name="customerRepository"><see cref="IMultichannelOrderManagerOrder"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerCustomerRelationshipServiceManager(IMultichannelOrderManagerCustomerRelationshipRepository customerRepository)
            : base()
        {
            if (customerRepository == null)
            {
                throw new ArgumentNullException(nameof(customerRepository));
            }
            else
            {
                CustomerRelationshipRepository = customerRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCustomerRelationshipServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerCustomerRelationshipRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="customerRepository"><see cref="IMultichannelOrderManagerCustomerRelationshipRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerCustomerRelationshipServiceManager(IWhippetServiceContext serviceLocator, IMultichannelOrderManagerCustomerRelationshipRepository customerRepository)
            : base(serviceLocator)
        {
            if (customerRepository == null)
            {
                throw new ArgumentNullException(nameof(customerRepository));
            }
            else
            {
                CustomerRelationshipRepository = customerRepository;
            }
        }

        /// <summary>
        /// Gets all <see cref="IMultichannelOrderManagerCustomerRelationship"/> objects that correspond to the specified IDs.
        /// </summary>
        /// <param name="customerIds">Collection of <see cref="IMultichannelOrderManagerCustomerRelationship.CustomerRelationshipId"/> values to query by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomerRelationship>>> GetCustomerRelationships(IEnumerable<long> customerIds = null)
        {
            if (customerIds == null)
            {
                throw new ArgumentNullException(nameof(customerIds));
            }
            else
            {
                IMultichannelOrderManagerCustomerRelationshipQueryHandler<GetMultichannelOrderManagerCustomerRelationshipsByIdsQuery> handler = new GetMultichannelOrderManagerCustomerRelationshipsByIdsQueryHandler(CustomerRelationshipRepository);
                WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>> result = await handler.HandleAsync(new GetMultichannelOrderManagerCustomerRelationshipsByIdsQuery(customerIds));
                return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomerRelationship>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Gets all <see cref="IMultichannelOrderManagerCustomerRelationship"/> objects for the specified parent <see cref="IMultichannelOrderManagerCustomer"/> ID.
        /// </summary>
        /// <param name="parentCustomerId">Parent <see cref="IMultichannelOrderManagerCustomer"/> ID to get all child relationships for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomerRelationship>>> GetCustomerRelationshipsForParent(long parentCustomerId)
        {
            IMultichannelOrderManagerCustomerRelationshipQueryHandler<GetMultichannelOrderManagerCustomerRelationshipsForParentCustomerIdQuery> handler = new GetMultichannelOrderManagerCustomerRelationshipsForParentCustomerIdQueryHandler(CustomerRelationshipRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>> result = await handler.HandleAsync(new GetMultichannelOrderManagerCustomerRelationshipsForParentCustomerIdQuery(parentCustomerId));
            return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomerRelationship>>(result.Result, result.Item);
        }

        /// <summary>
        /// Gets all <see cref="IMultichannelOrderManagerCustomerRelationship"/> objects for the specified child <see cref="IMultichannelOrderManagerCustomer"/> ID.
        /// </summary>
        /// <param name="childCustomerId">Child <see cref="IMultichannelOrderManagerCustomer"/> ID to get all parent relationships for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomerRelationship>>> GetCustomerRelationshipsForChild(long childCustomerId)
        {
            IMultichannelOrderManagerCustomerRelationshipQueryHandler<GetMultichannelOrderManagerCustomerRelationshipsForChildCustomerIdQuery> handler = new GetMultichannelOrderManagerCustomerRelationshipsForChildCustomerIdQueryHandler(CustomerRelationshipRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>> result = await handler.HandleAsync(new GetMultichannelOrderManagerCustomerRelationshipsForChildCustomerIdQuery(childCustomerId));
            return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomerRelationship>>(result.Result, result.Item);
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (CustomerRelationshipRepository != null)
            {
                CustomerRelationshipRepository.Dispose();
                CustomerRelationshipRepository = null;
            }

            base.Dispose();
        }
    }
}