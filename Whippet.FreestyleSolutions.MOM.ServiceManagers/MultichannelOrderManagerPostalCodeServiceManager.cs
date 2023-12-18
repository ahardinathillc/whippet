using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Concurrent;
using Nito.AsyncEx;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Queries;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories;
using Athi.Whippet.Threading.Tasks.Extensions;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IMultichannelOrderManagerPostalCode"/> domain objects.
    /// </summary>
    public class MultichannelOrderManagerPostalCodeServiceManager : ServiceManager, IDisposable
    {
        private const string STATE_PALAU = "PW";
        private const string STATE_MARIANA = "MP";
        private const string STATE_TINIAN = "MP";
        private const string STATE_SAIPAN = "MP";
        private const string STATE_ROTA = "MP";
        private const string STATE_HAWAII = "AS";
        private const string STATE_MARSHALL_ISLANDS = "MH";
        private const string STATE_MICRONESIA = "FM";
        private const string STATE_SAMOA = "AS";
        private const string STATE_GUAM = "GU";

        private const string USA_ISO3 = "USA";

        /// <summary>
        /// Gets all state abbreviations that are mapped to the state of Guam. This property is read-only.
        /// </summary>
        protected IEnumerable<string> StatesMappedToGuam
        {
            get
            {
                return new[]
                {
                    STATE_PALAU,
                    STATE_MARIANA,
                    STATE_TINIAN,
                    STATE_SAIPAN,
                    STATE_ROTA,
                    STATE_HAWAII,
                    STATE_MARSHALL_ISLANDS,
                    STATE_MICRONESIA,
                    STATE_SAMOA
                };
            }
        }

        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerPostalCodeRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IMultichannelOrderManagerPostalCodeRepository PostalCodeRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerPostalCodeServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerOrderItemRepository"/>.
        /// </summary>
        /// <param name="postalCodeRepository"><see cref="IMultichannelOrderManagerOrder"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerPostalCodeServiceManager(IMultichannelOrderManagerPostalCodeRepository postalCodeRepository)
            : base()
        {
            if (postalCodeRepository == null)
            {
                throw new ArgumentNullException(nameof(postalCodeRepository));
            }
            else
            {
                PostalCodeRepository = postalCodeRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerPostalCodeServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerPostalCodeRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="postalCodeRepository"><see cref="IMultichannelOrderManagerPostalCodeRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerPostalCodeServiceManager(IWhippetServiceContext serviceLocator, IMultichannelOrderManagerPostalCodeRepository postalCodeRepository)
            : base(serviceLocator)
        {
            if (postalCodeRepository == null)
            {
                throw new ArgumentNullException(nameof(postalCodeRepository));
            }
            else
            {
                PostalCodeRepository = postalCodeRepository;
            }
        }

        /// <summary>
        /// Maps the specified state abbreviation to Guam. If the state is not mapped, the original value is returned.
        /// </summary>
        /// <param name="stateAbbreviation">State abbreviation.</param>
        /// <returns>Guam state abbreviation or the original value supplied to method.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected virtual string MapStateToGuam(string stateAbbreviation)
        {
            if (String.IsNullOrWhiteSpace(stateAbbreviation))
            {
                throw new ArgumentNullException(nameof(stateAbbreviation));
            }
            else
            {
                if (StatesMappedToGuam.Contains(stateAbbreviation.Trim().ToUpperInvariant()))
                {
                    stateAbbreviation = STATE_GUAM;
                }

                return stateAbbreviation;
            }
        }

        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerPostalCode"/> with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IMultichannelOrderManagerPostalCode"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IMultichannelOrderManagerPostalCode>> GetPostalCode(long id)
        {
            IMultichannelOrderManagerPostalCodeQueryHandler<GetMultichannelOrderManagerPostalCodeByIdQuery> handler = new GetMultichannelOrderManagerPostalCodeByIdQueryHandler(PostalCodeRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>> result = await handler.HandleAsync(new GetMultichannelOrderManagerPostalCodeByIdQuery(id));
            return new WhippetResultContainer<IMultichannelOrderManagerPostalCode>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Gets all <see cref="IMultichannelOrderManagerPostalCode"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>>> GetPostalCodes()
        {
            IMultichannelOrderManagerPostalCodeQueryHandler<GetAllMultichannelOrderManagerPostalCodesQuery> handler = new GetAllMultichannelOrderManagerPostalCodesQueryHandler(PostalCodeRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>> result = await handler.HandleAsync(new GetAllMultichannelOrderManagerPostalCodesQuery());
            return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>>(result.Result, result.Item);
        }

        /// <summary>
        /// Gets all <see cref="IMultichannelOrderManagerPostalCode"/> objects that belong to the specified <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="country"><see cref="IMultichannelOrderManagerCountry"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>>> GetPostalCodes(IMultichannelOrderManagerCountry country)
        {
            ArgumentNullException.ThrowIfNull(country);

            IMultichannelOrderManagerPostalCodeQueryHandler<GetMultichannelOrderManagerPostalCodesByCountryQuery> handler = new GetMultichannelOrderManagerPostalCodesByCountryQueryHandler(PostalCodeRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>> result = await handler.HandleAsync(new GetMultichannelOrderManagerPostalCodesByCountryQuery(country));
            return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>>(result.Result, result.Item);
        }

        /// <summary>
        /// Gets all <see cref="IMultichannelOrderManagerPostalCode"/> objects that belong to the specified <see cref="IMultichannelOrderManagerStateProvince"/>.
        /// </summary>
        /// <param name="stateProvince"><see cref="IMultichannelOrderManagerStateProvince"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>>> GetPostalCodes(IMultichannelOrderManagerStateProvince stateProvince)
        {
            ArgumentNullException.ThrowIfNull(stateProvince);

            IMultichannelOrderManagerPostalCodeQueryHandler<GetMultichannelOrderManagerPostalCodesByStateProvinceQuery> handler = new GetMultichannelOrderManagerPostalCodesByStateProvinceQueryHandler(PostalCodeRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>> result = await handler.HandleAsync(new GetMultichannelOrderManagerPostalCodesByStateProvinceQuery(stateProvince));
            return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>>(result.Result, result.Item);
        }

        /// <summary>
        /// Gets all <see cref="IMultichannelOrderManagerPostalCode"/> objects that match the specified postal code.
        /// </summary>
        /// <param name="postalCode">Postal code value to match.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>>> GetPostalCodes(string postalCode)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(postalCode);

            IMultichannelOrderManagerPostalCodeQueryHandler<GetMultichannelOrderManagerPostalCodesByPostalCodeQuery> handler = new GetMultichannelOrderManagerPostalCodesByPostalCodeQueryHandler(PostalCodeRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>> result = await handler.HandleAsync(new GetMultichannelOrderManagerPostalCodesByPostalCodeQuery(postalCode));
            return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>>(result.Result, result.Item);
        }

        /// <summary>
        /// Assigns <see cref="IMultichannelOrderManagerStateProvince"/> objects to the provided collection of <see cref="IMultichannelOrderManagerPostalCode"/> objects.
        /// </summary>
        /// <param name="postalCodes"><see cref="IMultichannelOrderManagerPostalCode"/> collection.</param>
        /// <param name="stateProvinces"><see cref="IMultichannelOrderManagerStateProvince"/> collection.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation and populated <see cref="IMultichannelOrderManagerStateProvince"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>>> AssignStates(IEnumerable<IMultichannelOrderManagerPostalCode> postalCodes, IEnumerable<IMultichannelOrderManagerStateProvince> stateProvinces)
        {
            if (postalCodes == null)
            {
                throw new ArgumentNullException(nameof(postalCodes));
            }
            else if (stateProvinces == null)
            {
                throw new ArgumentNullException(nameof(stateProvinces));
            }
            else
            {
                WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>> result = null;

                ConcurrentBag<IMultichannelOrderManagerPostalCode> concurrentPostalCodes = new ConcurrentBag<IMultichannelOrderManagerPostalCode>();
                AsyncCollection<IMultichannelOrderManagerPostalCode> asyncPostalCodes = new AsyncCollection<IMultichannelOrderManagerPostalCode>(concurrentPostalCodes);

                ParallelOptions pOptions = new ParallelOptions();
                pOptions = pOptions.DetermineOptimalCoreCount();

                HashSet<IMultichannelOrderManagerStateProvince> stateHashSet = null;

                if (stateProvinces.Any() && postalCodes.Any())
                {
                    stateHashSet = new HashSet<IMultichannelOrderManagerStateProvince>(stateProvinces);

                    try
                    {
                        await Parallel.ForEachAsync<IMultichannelOrderManagerPostalCode>(postalCodes, pOptions, async (postalCode, cancellationToken) =>
                        {
                            if (postalCode.StateProvince != null)
                            {
                                if ((!String.IsNullOrWhiteSpace(postalCode.StateProvince.Abbreviation) || postalCode.StateProvince.ID > 0) && (postalCode.Country.CountryId > 0))
                                {
                                    if (postalCode.StateProvince.ID > 0)
                                    {
                                        foreach (IMultichannelOrderManagerStateProvince state in stateHashSet)
                                        {
                                            if (state.ID == postalCode.StateProvince.ID)
                                            {
                                                postalCode.StateProvince = state;
                                                break;
                                            }
                                        }

                                        postalCode.StateProvince = stateProvinces.Where(sp => sp.ID == postalCode.StateProvince.ID).First();    // will throw an exception if not found
                                    }
                                    else
                                    {
                                        // search based on country and abbreviation

                                        foreach (IMultichannelOrderManagerStateProvince state in stateHashSet)
                                        {
                                            // check to see if we have a map to Guam first

                                            if (!String.IsNullOrWhiteSpace(state.Abbreviation) && !String.IsNullOrWhiteSpace(postalCode.StateProvince.Abbreviation))
                                            {
                                                state.Abbreviation = MapStateToGuam(state.Abbreviation);
                                                postalCode.StateProvince.Abbreviation = MapStateToGuam(postalCode.StateProvince.Abbreviation);

                                                if (String.Equals(state.Abbreviation.Trim(), STATE_GUAM, StringComparison.InvariantCultureIgnoreCase) && String.Equals(postalCode.StateProvince.Abbreviation.Trim(), STATE_GUAM, StringComparison.InvariantCultureIgnoreCase))
                                                {
                                                    postalCode.Country.ISO3 = USA_ISO3;
                                                }

                                                if (String.Equals(state.Abbreviation.Trim(), postalCode.StateProvince.Abbreviation?.Trim(), StringComparison.InvariantCultureIgnoreCase) && String.Equals(postalCode.Country?.ISO3?.Trim(), state.Country?.ISO3?.Trim(), StringComparison.InvariantCultureIgnoreCase))
                                                {
                                                    postalCode.StateProvince = state;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            if (postalCode.StateProvince == null || postalCode.StateProvince.ID == 0)
                            {
                                throw new KeyNotFoundException();   // throw if we can't find the appropriate state/province
                            }
                            else
                            {
                                await asyncPostalCodes.AddAsync(postalCode);
                            }
                        });
                    }
                    catch (Exception e)
                    {
                        result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>>(e);
                    }
                }

                if (result == null)
                {
                    result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>>(WhippetResult.Success, concurrentPostalCodes);
                }

                foreach (var pc in result.Item.Where(p => p.StateProvince.ID == 0))
                {
                    System.Diagnostics.Debug.WriteLine(pc);
                }

                return result;
            }
        }

        /// <summary>
        /// Assigns <see cref="IMultichannelOrderManagerWarehouse"/> objects to the provided collection of <see cref="IMultichannelOrderManagerPostalCode"/> objects.
        /// </summary>
        /// <param name="postalCodes"><see cref="IMultichannelOrderManagerPostalCode"/> collection.</param>
        /// <param name="warehouses"><see cref="IMultichannelOrderManagerWarehouse"/> collection.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation and populated <see cref="IMultichannelOrderManagerWarehouse"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>>> AssignWarehouses(IEnumerable<IMultichannelOrderManagerPostalCode> postalCodes, IEnumerable<IMultichannelOrderManagerWarehouse> warehouses)
        {
            if (postalCodes == null)
            {
                throw new ArgumentNullException(nameof(postalCodes));
            }
            else if (warehouses == null)
            {
                throw new ArgumentNullException(nameof(warehouses));
            }
            else
            {
                WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>> result = null;

                ConcurrentBag<IMultichannelOrderManagerPostalCode> concurrentPostalCodes = new ConcurrentBag<IMultichannelOrderManagerPostalCode>();
                AsyncCollection<IMultichannelOrderManagerPostalCode> asyncPostalCodes = new AsyncCollection<IMultichannelOrderManagerPostalCode>(concurrentPostalCodes);

                ParallelOptions pOptions = new ParallelOptions();
                pOptions = pOptions.DetermineOptimalCoreCount();

                if (warehouses.Any() && postalCodes.Any())
                {
                    postalCodes = new SortedSet<IMultichannelOrderManagerPostalCode>(postalCodes, IMultichannelOrderManagerPostalCodeComparer.Instance);

                    try
                    {
                        await Parallel.ForEachAsync<IMultichannelOrderManagerPostalCode>(postalCodes, pOptions, async (postalCode, cancellationToken) =>
                        {
                            IMultichannelOrderManagerWarehouse warehouse = null;
                            IMultichannelOrderManagerPostalCode newPostalCode = postalCode.Clone<IMultichannelOrderManagerPostalCode>();

                            if ((postalCode.Warehouse != null) && ((postalCode.Warehouse.WarehouseID != 0) || !String.IsNullOrWhiteSpace(postalCode.Warehouse.Code)))
                            {
                                if (postalCode.Warehouse.WarehouseID != 0)
                                {
                                    warehouse = warehouses.Where(w => w.WarehouseID == postalCode.Warehouse.WarehouseID).FirstOrDefault();
                                }
                                else
                                {
                                    warehouse = warehouses.Where(w => String.Equals(w.Code?.Trim(), postalCode.Warehouse.Code?.Trim(), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                                }

                                if (warehouse != null)
                                {
                                    newPostalCode.Warehouse = warehouse;
                                }
                            }

                            if (warehouse == null)
                            {
                                // default to the first warehouse for that country or, if null, default to first warehouse

                                warehouse = warehouses.Where(w => !String.IsNullOrWhiteSpace(w.Country) && String.Equals(w.Country?.Trim(), postalCode.Country?.CountryCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                                if (warehouse == null)
                                {
                                    warehouse = warehouses.First();
                                }
                            }

                            newPostalCode.Warehouse = warehouse;

                            await asyncPostalCodes.AddAsync(newPostalCode);     // no warehouse is a valid entry
                        });
                    }
                    catch (Exception e)
                    {
                        result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>>(e);
                    }
                }

                if (result == null)
                {
                    result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>>(WhippetResult.Success, concurrentPostalCodes);
                }

                return result;
            }
        }

        /// <summary>
        /// Assigns <see cref="IMultichannelOrderManagerCounty"/> objects to the provided collection of <see cref="IMultichannelOrderManagerPostalCode"/> objects.
        /// </summary>
        /// <param name="postalCodes"><see cref="IMultichannelOrderManagerPostalCode"/> collection.</param>
        /// <param name="counties"><see cref="IMultichannelOrderManagerCounty"/> collection.</param>
        /// <param name="missingCountyLocator">Optional delegate that handles loading missing counties from the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation and populated <see cref="IMultichannelOrderManagerCounty"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>>> AssignCounties(IEnumerable<IMultichannelOrderManagerPostalCode> postalCodes, IEnumerable<IMultichannelOrderManagerCounty> counties, Func<string, string, Task<WhippetResultContainer<IMultichannelOrderManagerCounty>>> missingCountyLocator = null)
        {
            if (postalCodes == null)
            {
                throw new ArgumentNullException(nameof(postalCodes));
            }
            else if (counties == null)
            {
                throw new ArgumentNullException(nameof(counties));
            }
            else
            {
                WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>> result = null;
                WhippetResultContainer<IMultichannelOrderManagerCounty> countyResult = null;

                HashSet<IMultichannelOrderManagerCounty> countyHashSet = null;
                HashSet<IMultichannelOrderManagerPostalCode> postalCodeHashSet = null;

                ConcurrentDictionary<IMultichannelOrderManagerPostalCode, IMultichannelOrderManagerStateProvince> missingCounties = null;

                ConcurrentBag<IMultichannelOrderManagerPostalCode> concurrentPostalCodes = new ConcurrentBag<IMultichannelOrderManagerPostalCode>();
                AsyncCollection<IMultichannelOrderManagerPostalCode> asyncPostalCodes = new AsyncCollection<IMultichannelOrderManagerPostalCode>(concurrentPostalCodes);

                ParallelOptions pOptions = new ParallelOptions();

                int postalCodeCapacity = 0;

                pOptions = pOptions.DetermineOptimalCoreCount();

                if (counties.Any() && postalCodes.Any())
                {
                    if (!postalCodes.TryGetNonEnumeratedCount(out postalCodeCapacity))
                    {
                        postalCodeCapacity = postalCodes.Count();
                    }

                    countyHashSet = new HashSet<IMultichannelOrderManagerCounty>(counties.ToList());
                    postalCodeHashSet = new HashSet<IMultichannelOrderManagerPostalCode>(postalCodes.ToList());

                    missingCounties = new ConcurrentDictionary<IMultichannelOrderManagerPostalCode, IMultichannelOrderManagerStateProvince>();

                    try
                    {
                        await Parallel.ForEachAsync<IMultichannelOrderManagerPostalCode>(postalCodeHashSet, pOptions, async (postalCode, cancellationToken) =>
                        {
                            string stateAbbreviation = postalCode.StateProvince.Abbreviation;

                            if (postalCode.County != null && ((postalCode.County.CountyId != 0) || (!String.IsNullOrWhiteSpace(postalCode.County.CountyCode))))
                            {
                                if (postalCode.County.CountyId > 0)
                                {
                                    postalCode.County = countyHashSet.Where(c => c.CountyId == postalCode.County.CountyId).FirstOrDefault();
                                }
                                else
                                {
                                    foreach (IMultichannelOrderManagerCounty county in countyHashSet)
                                    {
                                        if (String.Equals(county.CountyCode?.Trim(), postalCode.County.CountyCode) && String.Equals(county.StateProvince.Abbreviation?.Trim(), postalCode.StateProvince.Abbreviation?.Trim()))
                                        {
                                            postalCode.County = county;
                                            break;
                                        }
                                    }
                                }

                                if (postalCode.County == null || postalCode.County.CountyId == 0)
                                {
                                    if (!missingCounties.TryAdd(postalCode, new MultichannelOrderManagerStateProvince() { Abbreviation = stateAbbreviation?.Trim() }))
                                    {
                                        throw new InvalidOperationException();
                                    }
                                }
                                else
                                {
                                    await asyncPostalCodes.AddAsync(postalCode);
                                }
                            }
                        });
                    }
                    catch (Exception e)
                    {
                        result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>>(e);
                    }
                }

                if (missingCounties.Count > 0 && missingCountyLocator != null)
                {
                    try
                    {
                        await Parallel.ForEachAsync<KeyValuePair<IMultichannelOrderManagerPostalCode, IMultichannelOrderManagerStateProvince>>(missingCounties, pOptions, async (entry, cancellationToken) =>
                        {
                            countyResult = await missingCountyLocator(entry.Key.County.CountyCode, entry.Value.Abbreviation);
                            countyResult.ThrowIfFailed();

                            if (countyResult.HasItem)
                            {
                                // fix up county real quick

                                countyResult.Item.Country = entry.Key.Country;
                                countyResult.Item.StateProvince = entry.Key.StateProvince;
                                countyResult.Item.Warehouse = entry.Key.Warehouse;
                                countyResult.Item.Server = entry.Key.Server;

                                entry.Key.County = countyResult.Item;
                                //concurrentPostalCodes.Add(entry.Key);
                                await asyncPostalCodes.AddAsync(entry.Key);
                            }
                        });
                    }
                    catch (Exception e)
                    {
                        result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>>(e);
                    }
                }

                if (result == null)
                {
                    result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>>(WhippetResult.Success, concurrentPostalCodes);
                }

                return result;
            }
        }

        /// <summary>
        /// Assigns <see cref="IMultichannelOrderManagerCountry"/> objects to the provided collection of <see cref="IMultichannelOrderManagerPostalCode"/> objects.
        /// </summary>
        /// <param name="postalCodes"><see cref="IMultichannelOrderManagerPostalCode"/> collection.</param>
        /// <param name="countries"><see cref="IMultichannelOrderManagerCountry"/> collection.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation and populated <see cref="IMultichannelOrderManagerCountry"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>>> AssignCountries(IEnumerable<IMultichannelOrderManagerPostalCode> postalCodes, IEnumerable<IMultichannelOrderManagerCountry> countries)
        {
            if (postalCodes == null)
            {
                throw new ArgumentNullException(nameof(postalCodes));
            }
            else if (countries == null)
            {
                throw new ArgumentNullException(nameof(countries));
            }
            else
            {
                WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>> result = null;

                ConcurrentBag<IMultichannelOrderManagerPostalCode> concurrentPostalCodes = new ConcurrentBag<IMultichannelOrderManagerPostalCode>();
                AsyncCollection<IMultichannelOrderManagerPostalCode> asyncPostalCodes = new AsyncCollection<IMultichannelOrderManagerPostalCode>(concurrentPostalCodes);

                ParallelOptions pOptions = new ParallelOptions();
                pOptions = pOptions.DetermineOptimalCoreCount();

                if (countries.Any() && postalCodes.Any())
                {
                    countries = new SortedSet<IMultichannelOrderManagerCountry>(countries, IMultichannelOrderManagerCountryComparer.Instance);
                    postalCodes = new SortedSet<IMultichannelOrderManagerPostalCode>(postalCodes, IMultichannelOrderManagerPostalCodeComparer.Instance);

                    try
                    {
                        await Parallel.ForEachAsync<IMultichannelOrderManagerPostalCode>(postalCodes, pOptions, async (postalCode, cancellationToken) =>
                        {
                            IMultichannelOrderManagerCountry country = null;
                            IMultichannelOrderManagerPostalCode newPostalCode = null;

                            if (postalCode.Country != null && ((postalCode.Country.CountryId != 0) || (!String.IsNullOrWhiteSpace(postalCode.Country.CountryCode))))
                            {
                                if (postalCode.Country.CountryId > 0)
                                {
                                    country = countries.Where(c => c.CountryId == postalCode.Country.CountryId).FirstOrDefault();
                                }
                                else
                                {
                                    country = countries.Where(c => String.Equals(c.CountryCode?.Trim(), postalCode.Country.CountryCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                                }

                                newPostalCode = postalCode.Clone<IMultichannelOrderManagerPostalCode>();
                                newPostalCode.Country = country;

                                await asyncPostalCodes.AddAsync(newPostalCode);
                            }
                        });
                    }
                    catch (Exception e)
                    {
                        result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>>(e);
                    }
                }

                if (result == null)
                {
                    result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>>(WhippetResult.Success, concurrentPostalCodes);
                }

                return result;
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (PostalCodeRepository != null)
            {
                PostalCodeRepository.Dispose();
                PostalCodeRepository = null;
            }

            base.Dispose();
        }
    }
}
