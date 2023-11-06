using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Queries;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories;
using Nito.AsyncEx;
using Athi.Whippet.Threading.Tasks.Extensions;
using System.Collections.Concurrent;
using Athi.Whippet.Localization.Addressing;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IMultichannelOrderManagerCountry"/> domain objects.
    /// </summary>
    public class MultichannelOrderManagerCountryServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerCountryRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IMultichannelOrderManagerCountryRepository CountryRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCountryServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerOrderItemRepository"/>.
        /// </summary>
        /// <param name="countryRepository"><see cref="IMultichannelOrderManagerOrder"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerCountryServiceManager(IMultichannelOrderManagerCountryRepository countryRepository)
            : base()
        {
            if (countryRepository == null)
            {
                throw new ArgumentNullException(nameof(countryRepository));
            }
            else
            {
                CountryRepository = countryRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCountryServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerCountryRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="countryRepository"><see cref="IMultichannelOrderManagerCountryRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerCountryServiceManager(IWhippetServiceContext serviceLocator, IMultichannelOrderManagerCountryRepository countryRepository)
            : base(serviceLocator)
        {
            if (countryRepository == null)
            {
                throw new ArgumentNullException(nameof(countryRepository));
            }
            else
            {
                CountryRepository = countryRepository;
            }
        }

        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerCountry"/> object based on the specified ID.
        /// </summary>
        /// <param name="countryId">ID of the <see cref="IMultichannelOrderManagerCountry"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IMultichannelOrderManagerCountry>> GetCountry(long countryId)
        {
            IMultichannelOrderManagerCountryQueryHandler<GetMultichannelOrderManagerCountryByIdQuery> handler = new GetMultichannelOrderManagerCountryByIdQueryHandler(CountryRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerCountry>> result = await handler.HandleAsync(new GetMultichannelOrderManagerCountryByIdQuery(countryId));
            return new WhippetResultContainer<IMultichannelOrderManagerCountry>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Gets all <see cref="IMultichannelOrderManagerCountry"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCountry>>> GetCountries()
        {
            IMultichannelOrderManagerCountryQueryHandler<GetAllMultichannelOrderManagerCountriesQuery> handler = new GetAllMultichannelOrderManagerCountriesQueryHandler(CountryRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerCountry>> result = await handler.HandleAsync(new GetAllMultichannelOrderManagerCountriesQuery());
            return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCountry>>(result.Result, result.Item);
        }

        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerCountry"/> object with the specified ISO-2/ISO-3 abbreviation.
        /// </summary>
        /// <param name="abbreviation">ISO-2/ISO-3 abbreviation of the country to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMultichannelOrderManagerCountry>> GetCountryByAbbreviation(string abbreviation)
        {
            if (String.IsNullOrWhiteSpace(abbreviation))
            {
                throw new ArgumentNullException(nameof(abbreviation));
            }
            else
            {
                IMultichannelOrderManagerCountryQueryHandler<GetMultichannelOrderManagerCountryByAbbreviationQuery> handler = new GetMultichannelOrderManagerCountryByAbbreviationQueryHandler(CountryRepository);
                WhippetResultContainer<IEnumerable<MultichannelOrderManagerCountry>> result = await handler.HandleAsync(new GetMultichannelOrderManagerCountryByAbbreviationQuery(abbreviation));
                return new WhippetResultContainer<IMultichannelOrderManagerCountry>(result.Result, result.Item.FirstOrDefault());
            }
        }

        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerCountry"/> object with the specified three digit country code.
        /// </summary>
        /// <param name="code">Three digit country code of the country to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMultichannelOrderManagerCountry>> GetCountryByCode(string code)
        {
            if (String.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException(nameof(code));
            }
            else
            {
                IMultichannelOrderManagerCountryQueryHandler<GetMultichannelOrderManagerCountryByCodeQuery> handler = new GetMultichannelOrderManagerCountryByCodeQueryHandler(CountryRepository);
                WhippetResultContainer<IEnumerable<MultichannelOrderManagerCountry>> result = await handler.HandleAsync(new GetMultichannelOrderManagerCountryByCodeQuery(code));
                return new WhippetResultContainer<IMultichannelOrderManagerCountry>(result.Result, result.Item.FirstOrDefault());
            }
        }

        /// <summary>
        /// Assigns <see cref="IMultichannelOrderManagerWarehouse"/> objects to the provided collection of <see cref="IMultichannelOrderManagerCountry"/> objects.
        /// </summary>
        /// <param name="countries"><see cref="IMultichannelOrderManagerCountry"/> collection.</param>
        /// <param name="warehouses"><see cref="IMultichannelOrderManagerWarehouse"/> collection.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation and populated <see cref="IMultichannelOrderManagerWarehouse"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCountry>>> AssignWarehouses(IEnumerable<IMultichannelOrderManagerCountry> countries, IEnumerable<IMultichannelOrderManagerWarehouse> warehouses)
        {
            if (countries == null)
            {
                throw new ArgumentNullException(nameof(countries));
            }
            else if (warehouses == null)
            {
                throw new ArgumentNullException(nameof(warehouses));
            }
            else
            {
                WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCountry>> result = null;

                ConcurrentBag<IMultichannelOrderManagerCountry> concurrentCountries = new ConcurrentBag<IMultichannelOrderManagerCountry>();
                AsyncCollection<IMultichannelOrderManagerCountry> asyncCountries = new AsyncCollection<IMultichannelOrderManagerCountry>(concurrentCountries);

                ParallelOptions pOptions = new ParallelOptions();
                pOptions = pOptions.DetermineOptimalCoreCount();

                if (warehouses.Any() && countries.Any())
                {
                    countries = new SortedSet<IMultichannelOrderManagerCountry>(countries, IMultichannelOrderManagerCountryComparer.Instance);

                    try
                    {
                        await Parallel.ForEachAsync<IMultichannelOrderManagerCountry>(countries, pOptions, async (country, cancellationToken) =>
                        {
                            IMultichannelOrderManagerWarehouse warehouse = null;
                            IMultichannelOrderManagerCountry newCountry = country.Clone<IMultichannelOrderManagerCountry>();

                            if ((country.Warehouse != null) && ((country.Warehouse.WarehouseID != 0) || !String.IsNullOrWhiteSpace(country.Warehouse.Code)))
                            {
                                if (country.Warehouse.WarehouseID != 0)
                                {
                                    warehouse = warehouses.Where(w => w.WarehouseID == country.Warehouse.WarehouseID).FirstOrDefault();
                                }
                                else
                                {
                                    warehouse = warehouses.Where(w => String.Equals(w.Code?.Trim(), country.Warehouse.Code?.Trim(), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                                }
                            }

                            if (warehouse == null)
                            {
                                // default to the first warehouse for that country or, if null, default to first warehouse

                                warehouse = warehouses.Where(w => !String.IsNullOrWhiteSpace(w.Country) && String.Equals(w.Country?.Trim(), country.CountryCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                                if (warehouse == null)
                                {
                                    warehouse = warehouses.First();
                                }
                            }

                            newCountry.Warehouse = warehouse;

                            await asyncCountries.AddAsync(newCountry);     // no warehouse is a valid entry
                        });
                    }
                    catch (Exception e)
                    {
                        result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCountry>>(e);
                    }
                }

                if (result == null)
                {
                    result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCountry>>(WhippetResult.Success, concurrentCountries);
                }

                return result;
            }
        }

        /// <summary>
        /// Fixes up <see cref="IMultichannelOrderManagerCountry"/> objects that are missing the country code.
        /// </summary>
        /// <param name="countries"><see cref="IEnumerable{T}"/> collection of <see cref="IMultichannelOrderManagerCountry"/> objects to check.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCountry>>> FixUpMissingCountryCodes(IEnumerable<IMultichannelOrderManagerCountry> countries)
        {
            if (countries == null)
            {
                throw new ArgumentNullException(nameof(countries));
            }
            else
            {
                WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCountry>> result = null;
                WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCountry>> allCountriesResult = null;
                
                ConcurrentBag<IMultichannelOrderManagerCountry> concurrentCountries = new ConcurrentBag<IMultichannelOrderManagerCountry>();
                AsyncCollection<IMultichannelOrderManagerCountry> asyncCountries = new AsyncCollection<IMultichannelOrderManagerCountry>(concurrentCountries);

                List<IMultichannelOrderManagerCountry> existingCountries = null;
                List<IMultichannelOrderManagerCountry> missingCountries = null;
                
                ParallelOptions pOptions = new ParallelOptions();

                try
                {
                    if (countries.Any() && (countries.Where(c => String.IsNullOrWhiteSpace(c.CountryCode)).Any()))
                    {
                        pOptions = pOptions.DetermineOptimalCoreCount();

                        allCountriesResult = await GetCountries();
                        allCountriesResult.ThrowIfFailed();

                        existingCountries = countries.Where(c => !String.IsNullOrWhiteSpace(c.CountryCode)).ToList();
                        missingCountries = countries.Where(c => String.IsNullOrWhiteSpace((c.CountryCode))).ToList();

                        await Parallel.ForEachAsync<IMultichannelOrderManagerCountry>(missingCountries, pOptions, async (country, cancellationToken) =>
                        {
                            country.CountryCode = (from c in allCountriesResult.Item where c.ID == country.ID select c.CountryCode).FirstOrDefault();

                            if (String.IsNullOrWhiteSpace(country.CountryCode))
                            {
                                country.CountryCode = (from c in allCountriesResult.Item where String.Equals(c.Name?.Trim(), country.Name?.Trim(), StringComparison.InvariantCultureIgnoreCase) select c.CountryCode).FirstOrDefault();
                            }

                            await asyncCountries.AddAsync(country);
                        });
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCountry>>(e);
                }

                if (result == null)
                {
                    result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCountry>>(WhippetResult.Success, existingCountries.Concat(concurrentCountries));
                }

                return result;
            }
        }
        
        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (CountryRepository != null)
            {
                CountryRepository.Dispose();
                CountryRepository = null;
            }

            base.Dispose();
        }
    }
}
