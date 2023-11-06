using System;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.Adobe.Magento.Directory.Repositories;
using Athi.Whippet.Adobe.Magento.Directory.ServiceManagers.Queries;
using Athi.Whippet.Adobe.Magento.Directory.ServiceManagers.Handlers.Queries;

namespace Athi.Whippet.Adobe.Magento.Directory.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="ICountry"/> domain objects.
    /// </summary>
    public class CountryServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="ICountryRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual ICountryRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryServiceManager"/> class with the specified <see cref="ICountryRepository"/> object.
        /// </summary>
        /// <param name="countryRepository"><see cref="ICountryRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CountryServiceManager(ICountryRepository countryRepository)
            : base()
        {
            if (countryRepository == null)
            {
                throw new ArgumentNullException(nameof(countryRepository));
            }
            else
            {
                Repository = countryRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryServiceManager"/> class with the specified <see cref="ICountryRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="countryRepository"><see cref="ICountryRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CountryServiceManager(IWhippetServiceContext serviceLocator, ICountryRepository countryRepository)
            : base(serviceLocator)
        {
            if (countryRepository == null)
            {
                throw new ArgumentNullException(nameof(countryRepository));
            }
            else
            {
                Repository = countryRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="ICountry"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="ICountry"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ICountry>> Get(string id)
        {
            ICountryQueryHandler<GetCountryByIdQuery> handler = new GetCountryByIdQueryHandler(Repository);
            WhippetResultContainer<IEnumerable<Country>> result = await handler.HandleAsync(new GetCountryByIdQuery(id));
            return new WhippetResultContainer<ICountry>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="ICountry"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ICountry>>> GetCountries()
        {
            ICountryQueryHandler<GetAllCountriesQuery> handler = new GetAllCountriesQueryHandler(Repository);
            WhippetResultContainer<IEnumerable<Country>> result = await handler.HandleAsync(new GetAllCountriesQuery());
            return new WhippetResultContainer<IEnumerable<ICountry>>(result.Result, result.Item);
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (Repository != null)
            {
                Repository.Dispose();
                Repository = null;
            }

            base.Dispose();
        }
    }
}
