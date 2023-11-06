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
    /// Service manager for <see cref="IMultichannelOrderManagerCounty"/> domain objects.
    /// </summary>
    public class MultichannelOrderManagerCountyServiceManager : ServiceManager, IDisposable
    {
        private const string COUNTRY_ID_USA = "001";

        private const string COUNTY_PALAU = "PALAU";
        private const string COUNTY_MARIANA = "NORTHERN MARIANA ISLANDS";
        private const string COUNTY_TINIAN = "TINIAN";
        private const string COUNTY_SAIPAN = "SAIPAN";
        private const string COUNTY_ROTA = "ROTA";
        private const string COUNTY_HAWAII = "HAWAII";
        private const string COUNTY_MARSHALL_ISLANDS = "MARSHALL ISLANDS";
        private const string COUNTY_MICRONESIA = "FEDERATED STATES OF MICRO";
        private const string COUNTY_SAMOA = "AMERICAN SAMOA";

        private const string COUNTY_CODE_PALAU = "030";
        private const string COUNTY_CODE_MARIANA = "010";
        private const string COUNTY_CODE_TINIAN = "120";
        private const string COUNTY_CODE_SAIPAN = "110";
        private const string COUNTY_CODE_ROTA = "100";
        private const string COUNTY_CODE_HAWAII = "001";
        private const string COUNTY_CODE_MARSHALL_ISLANDS = "020";
        private const string COUNTY_CODE_MICRO = "003";
        private const string COUNTY_CODE_SAMOA = "050";

        private const string STATE_GUAM = "GU";
        private const string STATE_HAWAII = "HI";
        private const string STATE_HAWAII_2 = "AS";

        private const long COUNTY_ID_HAWAII = 3234;

        private const long STATE_ID_GUAM = 54;
        private const long STATE_ID_HAWAII = 53;

        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerCountyRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IMultichannelOrderManagerCountyRepository CountyRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCountyServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerOrderItemRepository"/>.
        /// </summary>
        /// <param name="countyRepository"><see cref="IMultichannelOrderManagerOrder"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerCountyServiceManager(IMultichannelOrderManagerCountyRepository countyRepository)
            : base()
        {
            if (countyRepository == null)
            {
                throw new ArgumentNullException(nameof(countyRepository));
            }
            else
            {
                CountyRepository = countyRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCountyServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerCountyRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="countyRepository"><see cref="IMultichannelOrderManagerCountyRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerCountyServiceManager(IWhippetServiceContext serviceLocator, IMultichannelOrderManagerCountyRepository countyRepository)
            : base(serviceLocator)
        {
            if (countyRepository == null)
            {
                throw new ArgumentNullException(nameof(countyRepository));
            }
            else
            {
                CountyRepository = countyRepository;
            }
        }

        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerCounty"/> with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IMultichannelOrderManagerCounty"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IMultichannelOrderManagerCounty>> GetCounty(long id)
        {
            IMultichannelOrderManagerCountyQueryHandler<GetMultichannelOrderManagerCountyByIdQuery> handler = new GetMultichannelOrderManagerCountyByIdQueryHandler(CountyRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>> result = await handler.HandleAsync(new GetMultichannelOrderManagerCountyByIdQuery(id));
            return new WhippetResultContainer<IMultichannelOrderManagerCounty>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Gets all <see cref="IMultichannelOrderManagerCounty"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCounty>>> GetCounties()
        {
            IMultichannelOrderManagerCountyQueryHandler<GetAllMultichannelOrderManagerCountiesQuery> handler = new GetAllMultichannelOrderManagerCountiesQueryHandler(CountyRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>> result = await handler.HandleAsync(new GetAllMultichannelOrderManagerCountiesQuery());

            return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCounty>>(result.Result, result.Item);
        }

        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerCounty"/> object with the specified three digit county code.
        /// </summary>
        /// <param name="code">Three digit county code of the county to retrieve.</param>
        /// <param name="stateAbbreviation">State abbreviation.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMultichannelOrderManagerCounty>> GetCountyByCode(string code, string stateAbbreviation)
        {
            if (String.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException(nameof(code));
            }
            else
            {
                IMultichannelOrderManagerCountyQueryHandler<GetMultichannelOrderManagerCountyByCodeQuery> handler = new GetMultichannelOrderManagerCountyByCodeQueryHandler(CountyRepository);
                WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>> result = await handler.HandleAsync(new GetMultichannelOrderManagerCountyByCodeQuery(code, stateAbbreviation));
                return new WhippetResultContainer<IMultichannelOrderManagerCounty>(result.Result, result.Item.FirstOrDefault());
            }
        }

        /// <summary>
        /// Assigns <see cref="IMultichannelOrderManagerWarehouse"/> objects to the provided collection of <see cref="IMultichannelOrderManagerCounty"/> objects.
        /// </summary>
        /// <param name="counties"><see cref="IMultichannelOrderManagerCounty"/> collection.</param>
        /// <param name="warehouses"><see cref="IMultichannelOrderManagerWarehouse"/> collection.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation and populated <see cref="IMultichannelOrderManagerWarehouse"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCounty>>> AssignWarehouses(IEnumerable<IMultichannelOrderManagerCounty> counties, IEnumerable<IMultichannelOrderManagerWarehouse> warehouses)
        {
            if (counties == null)
            {
                throw new ArgumentNullException(nameof(counties));
            }
            else if (warehouses == null)
            {
                throw new ArgumentNullException(nameof(warehouses));
            }
            else
            {
                WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCounty>> result = null;

                ConcurrentBag<IMultichannelOrderManagerCounty> concurrentCounties = new ConcurrentBag<IMultichannelOrderManagerCounty>();
                AsyncCollection<IMultichannelOrderManagerCounty> asyncCounties = new AsyncCollection<IMultichannelOrderManagerCounty>(concurrentCounties);

                ParallelOptions pOptions = new ParallelOptions();
                pOptions = pOptions.DetermineOptimalCoreCount();

                if (warehouses.Any() && counties.Any())
                {
                    counties = new SortedSet<IMultichannelOrderManagerCounty>(counties, IMultichannelOrderManagerCountyComparer.Instance);

                    try
                    {
                        await Parallel.ForEachAsync<IMultichannelOrderManagerCounty>(counties, pOptions, async (county, cancellationToken) =>
                        {
                            IMultichannelOrderManagerWarehouse warehouse = null;
                            IMultichannelOrderManagerCounty newCounty = county.Clone<IMultichannelOrderManagerCounty>();

                            if ((county.Warehouse != null) && ((county.Warehouse.WarehouseID != 0) || !String.IsNullOrWhiteSpace(county.Warehouse.Code)))
                            {
                                if (county.Warehouse.WarehouseID != 0)
                                {
                                    warehouse = warehouses.Where(w => w.WarehouseID == county.Warehouse.WarehouseID).FirstOrDefault();
                                }
                                else
                                {
                                    warehouse = warehouses.Where(w => String.Equals(w.Code?.Trim(), county.Warehouse.Code?.Trim(), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                                }

                                if (warehouse != null)
                                {
                                    newCounty.Warehouse = warehouse;
                                }
                            }

                            if (warehouse == null)
                            {
                                // default to the first warehouse for that country or, if null, default to first warehouse

                                warehouse = warehouses.Where(w => !String.IsNullOrWhiteSpace(w.Country) && String.Equals(w.Country?.Trim(), county.Country?.CountryCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                                if (warehouse == null)
                                {
                                    warehouse = warehouses.First();
                                }
                            }

                            newCounty.Warehouse = warehouse;

                            await asyncCounties.AddAsync(newCounty);     // no warehouse is a valid entry
                        });
                    }
                    catch (Exception e)
                    {
                        result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCounty>>(e);
                    }
                }

                if (result == null)
                {
                    result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCounty>>(WhippetResult.Success, concurrentCounties);
                }

                return result;
            }
        }

        /// <summary>
        /// Assigns <see cref="IMultichannelOrderManagerCounty"/> objects to the provided collection of <see cref="IMultichannelOrderManagerStateProvince"/> and <see cref="IMultichannelOrderManagerCountry"/> objects.
        /// </summary>
        /// <param name="counties"><see cref="IMultichannelOrderManagerCounty"/> collection.</param>
        /// <param name="stateProvinces"><see cref="IMultichannelOrderManagerStateProvince"/> collection.</param>
        /// <param name="countries"><see cref="IMultichannelOrderManagerCountry"/> collection.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation and populated <see cref="IMultichannelOrderManagerStateProvince"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCounty>>> AssignStatesAndCountries(IEnumerable<IMultichannelOrderManagerCounty> counties, IEnumerable<IMultichannelOrderManagerStateProvince> stateProvinces, IEnumerable<IMultichannelOrderManagerCountry> countries)
        {
            if (counties == null)
            {
                throw new ArgumentNullException(nameof(counties));
            }
            else if (stateProvinces == null)
            {
                throw new ArgumentNullException(nameof(stateProvinces));
            }
            else if (countries == null)
            {
                throw new ArgumentNullException(nameof(countries));
            }
            else
            {
                WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCounty>> result = null;

                ConcurrentBag<IMultichannelOrderManagerCounty> concurrentCounties = new ConcurrentBag<IMultichannelOrderManagerCounty>();
                AsyncCollection<IMultichannelOrderManagerCounty> asyncCounties = new AsyncCollection<IMultichannelOrderManagerCounty>(concurrentCounties);

                ParallelOptions pOptions = new ParallelOptions();
                pOptions = pOptions.DetermineOptimalCoreCount();

                if (stateProvinces.Any() && counties.Any())
                {
                    stateProvinces = new SortedSet<IMultichannelOrderManagerStateProvince>(stateProvinces, IMultichannelOrderManagerStateProvinceComparer.Instance);
                    countries = new SortedSet<IMultichannelOrderManagerCountry>(countries, IMultichannelOrderManagerCountryComparer.Instance);
                    counties = new SortedSet<IMultichannelOrderManagerCounty>(counties, IMultichannelOrderManagerCountyComparer.Instance);

                    try
                    {
                        await Parallel.ForEachAsync<IMultichannelOrderManagerCounty>(counties, pOptions, async (county, cancellationToken) =>
                        {
                            IMultichannelOrderManagerStateProvince stateProvince = null;
                            IMultichannelOrderManagerCountry country = null;
                            IMultichannelOrderManagerCounty newCounty = null;

                            if (county.StateProvince != null && ((county.StateProvince.ID != 0) || ((!String.IsNullOrWhiteSpace(county.StateProvince.Abbreviation))) && county.Country != null))
                            {
                                if ((String.Equals(county.Name?.Trim(), COUNTY_PALAU, StringComparison.InvariantCultureIgnoreCase) || String.Equals(county.CountyCode?.Trim(), COUNTY_CODE_PALAU, StringComparison.InvariantCultureIgnoreCase))
                                    || (String.Equals(county.Name?.Trim(), COUNTY_MARIANA, StringComparison.InvariantCultureIgnoreCase) || String.Equals(county.CountyCode?.Trim(), COUNTY_CODE_MARIANA, StringComparison.InvariantCultureIgnoreCase))
                                    || (String.Equals(county.Name?.Trim(), COUNTY_TINIAN, StringComparison.InvariantCultureIgnoreCase) || String.Equals(county.CountyCode?.Trim(), COUNTY_CODE_TINIAN, StringComparison.InvariantCultureIgnoreCase))
                                    || (String.Equals(county.Name?.Trim(), COUNTY_SAIPAN, StringComparison.InvariantCultureIgnoreCase) || String.Equals(county.CountyCode?.Trim(), COUNTY_CODE_SAIPAN, StringComparison.InvariantCultureIgnoreCase))
                                    || (String.Equals(county.Name?.Trim(), COUNTY_ROTA, StringComparison.InvariantCultureIgnoreCase) || String.Equals(county.CountyCode?.Trim(), COUNTY_CODE_ROTA, StringComparison.InvariantCultureIgnoreCase))
                                    || (String.Equals(county.Name?.Trim(), COUNTY_MARSHALL_ISLANDS, StringComparison.InvariantCultureIgnoreCase) || String.Equals(county.CountyCode?.Trim(), COUNTY_CODE_MARSHALL_ISLANDS, StringComparison.InvariantCultureIgnoreCase))
                                    || (String.Equals(county.Name?.Trim(), COUNTY_MICRONESIA, StringComparison.InvariantCultureIgnoreCase) || String.Equals(county.CountyCode?.Trim(), COUNTY_CODE_MICRO, StringComparison.InvariantCultureIgnoreCase))
                                    || (String.Equals(county.Name?.Trim(), COUNTY_SAMOA, StringComparison.InvariantCultureIgnoreCase) || String.Equals(county.CountyCode?.Trim(), COUNTY_CODE_SAMOA, StringComparison.InvariantCultureIgnoreCase)))
                                {
                                    // These states are a special case in that we set the state to GUAM

                                    county.StateProvince.ID = STATE_ID_GUAM;
                                    county.StateProvince.Abbreviation = STATE_GUAM;
                                }
                                else if (((String.Equals(county.Name?.Trim(), COUNTY_HAWAII, StringComparison.InvariantCultureIgnoreCase) || String.Equals(county.CountyCode?.Trim(), COUNTY_CODE_HAWAII, StringComparison.InvariantCultureIgnoreCase))
                                    && String.Equals(county.StateProvince.Abbreviation?.Trim(), STATE_HAWAII_2, StringComparison.InvariantCultureIgnoreCase)) || county.CountyId == COUNTY_ID_HAWAII)
                                {
                                    // These states are a special case in that we set the state to HAWAII

                                    county.StateProvince.ID = STATE_ID_HAWAII;
                                    county.StateProvince.Abbreviation = STATE_HAWAII;
                                }

                                stateProvince =
                                    county.StateProvince.ID != 0
                                        ? stateProvinces.Where(sp => sp.ID == county.StateProvince.ID).FirstOrDefault()
                                        : stateProvinces.Where(sp => (!String.IsNullOrWhiteSpace(sp.Abbreviation)) && String.Equals(sp.Abbreviation.Trim(), county.StateProvince.Abbreviation.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                    ).FirstOrDefault();

                                if (county.Country.ID != 0 || !String.IsNullOrWhiteSpace(county.Country.CountryCode))
                                {
                                    country = countries.Where(c => String.Equals(c.CountryCode?.Trim(), county.Country.CountryCode, StringComparison.InvariantCultureIgnoreCase) || (c.CountryId == county.Country.ID)).FirstOrDefault();

                                    if (country == null)
                                    {
                                        // default to USA

                                        country = countries.Where(c => String.Equals(c.CountryCode?.Trim(), COUNTRY_ID_USA, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                                    }
                                }
                                else
                                {
                                    country = countries.Where(c => String.Equals(c.CountryCode?.Trim(), COUNTRY_ID_USA, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                                }

                                newCounty = county.Clone<IMultichannelOrderManagerCounty>();
                                newCounty.StateProvince = stateProvince;
                                newCounty.StateProvince.Country = country;
                                newCounty.Country = country;

                                await asyncCounties.AddAsync(newCounty);
                            }
                        });
                    }
                    catch (Exception e)
                    {
                        result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCounty>>(e);
                    }
                }

                if (result == null)
                {
                    result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCounty>>(WhippetResult.Success, concurrentCounties);
                }

                return result;
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (CountyRepository != null)
            {
                CountyRepository.Dispose();
                CountyRepository = null;
            }

            base.Dispose();
        }
    }
}
