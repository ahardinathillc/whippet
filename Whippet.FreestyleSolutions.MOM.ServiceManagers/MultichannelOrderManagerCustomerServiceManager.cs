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
using System.Net.Mail;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IMultichannelOrderManagerOrder"/> domain objects.
    /// </summary>
    public class MultichannelOrderManagerCustomerServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerCustomerRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IMultichannelOrderManagerCustomerRepository CustomerRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCustomerServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerOrderItemRepository"/>.
        /// </summary>
        /// <param name="customerRepository"><see cref="IMultichannelOrderManagerOrder"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerCustomerServiceManager(IMultichannelOrderManagerCustomerRepository customerRepository)
            : base()
        {
            if (customerRepository == null)
            {
                throw new ArgumentNullException(nameof(customerRepository));
            }
            else
            {
                CustomerRepository = customerRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCustomerServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerCustomerRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="customerRepository"><see cref="IMultichannelOrderManagerCustomerRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerCustomerServiceManager(IWhippetServiceContext serviceLocator, IMultichannelOrderManagerCustomerRepository customerRepository)
            : base(serviceLocator)
        {
            if (customerRepository == null)
            {
                throw new ArgumentNullException(nameof(customerRepository));
            }
            else
            {
                CustomerRepository = customerRepository;
            }
        }

        /// <summary>
        /// Gets all <see cref="IMultichannelOrderManagerCustomer"/> objects that are for companies only (the properties <see cref="IMultichannelOrderManagerCustomer.FirstName"/> and <see cref="IMultichannelOrderManagerCustomer.LastName"/> are blank).
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomer>>> GetCompanies()
        {
            IMultichannelOrderManagerCustomerQueryHandler<GetMultichannelOrderManagerCustomerCompaniesOnlyQuery> handler = new GetMultichannelOrderManagerCustomerCompaniesOnlyQueryHandler(CustomerRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> result = await handler.HandleAsync(new GetMultichannelOrderManagerCustomerCompaniesOnlyQuery());
            return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomer>>(result.Result, result.Item);
        }

        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerCustomer"/> object with the specified ID.
        /// </summary>
        /// <param name="customerId">ID of the <see cref="IMultichannelOrderManagerCustomer"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IMultichannelOrderManagerCustomer>> GetCustomer(long customerId)
        {
            IMultichannelOrderManagerCustomerQueryHandler<GetMultichannelOrderManagerCustomerByIdQuery> handler = new GetMultichannelOrderManagerCustomerByIdQueryHandler(CustomerRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> result = await handler.HandleAsync(new GetMultichannelOrderManagerCustomerByIdQuery(customerId));
            return new WhippetResultContainer<IMultichannelOrderManagerCustomer>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Gets all <see cref="IMultichannelOrderManagerCustomer"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomer>>> GetCustomers()
        {
            IMultichannelOrderManagerCustomerQueryHandler<GetMultichannelOrderManagerCustomersQuery> handler = new GetMultichannelOrderManagerCustomersQueryHandler(CustomerRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> result = await handler.HandleAsync(new GetMultichannelOrderManagerCustomersQuery());
            return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomer>>(result.Result, result.Item);
        }

        /// <summary>
        /// Gets all <see cref="IMultichannelOrderManagerCustomer"/> objects that correspond to the specified IDs.
        /// </summary>
        /// <param name="customerIds">Collection of <see cref="IMultichannelOrderManagerCustomer.CustomerId"/> values to query by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomer>>> GetCustomers(IEnumerable<long> customerIds)
        {
            if (customerIds == null)
            {
                throw new ArgumentNullException(nameof(customerIds));
            }
            else
            {
                IMultichannelOrderManagerCustomerQueryHandler<GetMultichannelOrderManagerCustomersByIdsQuery> handler = new GetMultichannelOrderManagerCustomersByIdsQueryHandler(CustomerRepository);
                WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> result = await handler.HandleAsync(new GetMultichannelOrderManagerCustomersByIdsQuery(customerIds));
                return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomer>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Gets all <see cref="IMultichannelOrderManagerCustomer"/> objects based on the specified search parameters.
        /// </summary>
        /// <param name="lastName">Last name to filter by.</param>
        /// <param name="firstName">First name to filter by.</param>
        /// <param name="company">Company name to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomer>>> GetCustomers(string lastName, string firstName, string company)
        {
            IMultichannelOrderManagerCustomerQueryHandler<GetMultichannelOrderManagerCustomersForCompanyQuery> companyHandler = null;
            IMultichannelOrderManagerCustomerQueryHandler<GetMultichannelOrderManagerCustomersByFirstNameQuery> firstNameHandler = null;
            IMultichannelOrderManagerCustomerQueryHandler<GetMultichannelOrderManagerCustomersByLastNameQuery> lastNameHandler = null;
            IMultichannelOrderManagerCustomerQueryHandler<GetMultichannelOrderManagerCustomersByFirstNameAndLastNameQuery> firstNameAndLastNameHandler = null;

            WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> result = null;
            WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomer>> toReturn = null;

            if (!String.IsNullOrWhiteSpace(company))
            {
                companyHandler = new GetMultichannelOrderManagerCustomersForCompanyQueryHandler(CustomerRepository);
                result = await companyHandler.HandleAsync(new GetMultichannelOrderManagerCustomersForCompanyQuery(company));

                if (result.IsSuccess)
                {
                    if (result.Item != null && result.Item.Any())
                    {
                        if (!String.IsNullOrWhiteSpace(lastName))
                        {
                            result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>(result.Result, result.Item.Where(i => (i != null) && !String.IsNullOrWhiteSpace(i.LastName) && i.LastName.StartsWith(lastName, StringComparison.InvariantCultureIgnoreCase)));
                        }

                        if (!String.IsNullOrWhiteSpace(firstName))
                        {
                            result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>(result.Result, result.Item.Where(i => (i != null) && !String.IsNullOrWhiteSpace(i.FirstName) && i.FirstName.StartsWith(firstName, StringComparison.InvariantCultureIgnoreCase)));
                        }
                    }

                    toReturn = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomer>>(result.Result, result.Item);
                }
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(lastName) && !String.IsNullOrWhiteSpace(firstName))
                {
                    firstNameAndLastNameHandler = new GetMultichannelOrderManagerCustomersByFirstNameAndLastNameQueryHandler(CustomerRepository);
                    result = await firstNameAndLastNameHandler.HandleAsync(new GetMultichannelOrderManagerCustomersByFirstNameAndLastNameQuery(firstName, lastName));

                    toReturn = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomer>>(result.Result, result.Item);
                }
                else if (!String.IsNullOrWhiteSpace(lastName))
                {
                    lastNameHandler = new GetMultichannelOrderManagerCustomersByLastNameQueryHandler(CustomerRepository);
                    result = await lastNameHandler.HandleAsync(new GetMultichannelOrderManagerCustomersByLastNameQuery(lastName));

                    toReturn = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomer>>(result.Result, result.Item);
                }
                else if (!String.IsNullOrWhiteSpace(firstName))
                {
                    firstNameHandler = new GetMultichannelOrderManagerCustomersByFirstNameQueryHandler(CustomerRepository);
                    result = await firstNameHandler.HandleAsync(new GetMultichannelOrderManagerCustomersByFirstNameQuery(firstName));

                    toReturn = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomer>>(result.Result, result.Item);
                }
                else
                {
                    toReturn = await GetCustomers();
                }
            }

            return toReturn;
        }

        /// <summary>
        /// Gets all <see cref="IMultichannelOrderManagerCustomer"/> objects associated with the specified postal code.
        /// </summary>
        /// <param name="postalCode">Postal code to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomer>>> GetCustomersByPostalCode(string postalCode)
        {
            if (String.IsNullOrWhiteSpace(postalCode))
            {
                throw new ArgumentNullException(nameof(postalCode));
            }
            else
            {
                IMultichannelOrderManagerCustomerQueryHandler<GetMultichannelOrderManagerCustomersByPostalCodeQuery> handler = new GetMultichannelOrderManagerCustomersByPostalCodeQueryHandler(CustomerRepository);
                WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> result = await handler.HandleAsync(new GetMultichannelOrderManagerCustomersByPostalCodeQuery(postalCode));
                return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomer>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Gets all <see cref="IMultichannelOrderManagerCustomer"/> objects associated with the specified e-mail address.
        /// </summary>
        /// <param name="emailAddress">E-mail address to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomer>>> GetCustomersByEmailAddress(string emailAddress)
        {
            if (String.IsNullOrWhiteSpace(emailAddress))
            {
                throw new ArgumentNullException(nameof(emailAddress));
            }
            else
            {
                IMultichannelOrderManagerCustomerQueryHandler<GetMultichannelOrderManagerCustomersByEmailQuery> handler = new GetMultichannelOrderManagerCustomersByEmailQueryHandler(CustomerRepository);
                WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> result = await handler.HandleAsync(new GetMultichannelOrderManagerCustomersByEmailQuery(emailAddress));
                return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomer>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Gets the total number of active customers for the specified date range.
        /// </summary>
        /// <param name="fromDate">Starting date range of the query.</param>
        /// <param name="toDate">Ending date range of the query.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<long>> GetActiveCustomersCount(Instant? fromDate = null, Instant? toDate = null)
        {
            IMultichannelOrderManagerCustomerQueryHandler<GetMultichannelOrderManagerCustomerActiveCountQuery> handler = new GetMultichannelOrderManagerCustomerActiveCountQueryHandler(CustomerRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> result = await handler.HandleAsync(new GetMultichannelOrderManagerCustomerActiveCountQuery(fromDate, toDate));
            return new WhippetResultContainer<long>(result.Result, result.HasItem ? result.Item.LongCount() : 0);
        }

        /// <summary>
        /// Gets all active <see cref="IMultichannelOrderManagerCustomer"/> objects that are active and have been active for the specified date range.
        /// </summary>
        /// <param name="fromDate">Starting date range of the query.</param>
        /// <param name="toDate">Ending date range of the query.</param>
        /// <param name="customerNumbersOnly">Specifies whether only the individual customer record IDs should be loaded instead of the whole object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomer>>> GetActiveCustomers(Instant? fromDate = null, Instant? toDate = null, bool customerNumbersOnly = false)
        {
            IMultichannelOrderManagerCustomerQueryHandler<GetMultichannelOrderManagerCustomersActiveOnlyQuery> handler = new GetMultichannelOrderManagerCustomersActiveOnlyQueryHandler(CustomerRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> result = await handler.HandleAsync(new GetMultichannelOrderManagerCustomersActiveOnlyQuery(fromDate, toDate, customerNumbersOnly));
            return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCustomer>>(result.Result, result.Item);
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (CustomerRepository != null)
            {
                CustomerRepository.Dispose();
                CustomerRepository = null;
            }

            base.Dispose();
        }
    }
}