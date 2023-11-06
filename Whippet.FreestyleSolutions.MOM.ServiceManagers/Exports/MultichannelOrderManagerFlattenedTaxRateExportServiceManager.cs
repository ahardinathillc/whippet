using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nito.AsyncEx;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Collections.Extensions;
using Athi.Whippet.Collections.Concurrent.Extensions;
using Athi.Whippet.Services;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Exports.ServiceManagers.Queries;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Exports.ServiceManagers.Handlers.Queries;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Exports.Repositories;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers;
using Athi.Whippet.Localization.Addressing;
using Athi.Whippet.Localization.Addressing.ServiceManagers;
using Athi.Whippet.Threading.Tasks.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Exports.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> domain objects.
    /// </summary>
    public class MultichannelOrderManagerFlattenedTaxRateExportServiceManager : ServiceManager, IDisposable
    {
        private const string CITY_NOT_FOUND = nameof(CITY_NOT_FOUND);
        private const string COUNTRY_CODE_USA = "001";

        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerFlattenedTaxRateExportRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IMultichannelOrderManagerFlattenedTaxRateExportRepository FlattenedTaxRateExportRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerFlattenedTaxRateExportServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerOrderItemRepository"/>.
        /// </summary>
        /// <param name="taxRepository"><see cref="IMultichannelOrderManagerOrder"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerFlattenedTaxRateExportServiceManager(IMultichannelOrderManagerFlattenedTaxRateExportRepository taxRepository)
            : base()
        {
            if (taxRepository == null)
            {
                throw new ArgumentNullException(nameof(taxRepository));
            }
            else
            {
                FlattenedTaxRateExportRepository = taxRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerFlattenedTaxRateExportServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerFlattenedTaxRateExportRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="taxRepository"><see cref="IMultichannelOrderManagerFlattenedTaxRateExportRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerFlattenedTaxRateExportServiceManager(IWhippetServiceContext serviceLocator, IMultichannelOrderManagerFlattenedTaxRateExportRepository taxRepository)
            : base(serviceLocator)
        {
            if (taxRepository == null)
            {
                throw new ArgumentNullException(nameof(taxRepository));
            }
            else
            {
                FlattenedTaxRateExportRepository = taxRepository;
            }
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>> GetTaxRates()
        {
            IMultichannelOrderManagerFlattenedTaxRateExportQueryHandler<GetAllMultichannelOrderManagerFlattenedTaxRateExportsQuery> handler = new GetAllMultichannelOrderManagerFlattenedTaxRateExportsQueryHandler(FlattenedTaxRateExportRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>> result = await handler.HandleAsync(new GetAllMultichannelOrderManagerFlattenedTaxRateExportsQuery());
            return new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(result.Result, result.Item);
        }

        /// <summary>
        /// Assigns geographic data to the specified <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> objects.
        /// </summary>
        /// <param name="exports"><see cref="IEnumerable{T}"/> collection of <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> objects.</param>
        /// <param name="postalCodes"><see cref="IEnumerable{T}"/> colleciton of <see cref="IMultichannelOrderManagerPostalCode"/> objects.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>> AssignGeographicData(IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport> exports, IEnumerable<IMultichannelOrderManagerPostalCode> postalCodes)
        {
            if (exports == null)
            {
                throw new ArgumentNullException(nameof(exports));
            }
            else if (postalCodes == null)
            {
                throw new ArgumentNullException(nameof(postalCodes));
            }
            else
            {
                WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>> result = null;

                ConcurrentBag<MultichannelOrderManagerFlattenedTaxRateExport> concurrentExports = new ConcurrentBag<MultichannelOrderManagerFlattenedTaxRateExport>();
                AsyncCollection<MultichannelOrderManagerFlattenedTaxRateExport> asyncExports = new AsyncCollection<MultichannelOrderManagerFlattenedTaxRateExport>(concurrentExports);

                ParallelOptions pOptions = new ParallelOptions().DetermineOptimalCoreCount();

                int capacity = 0;

                if (exports.Any() && postalCodes.Any())
                {
                    if (!exports.TryGetNonEnumeratedCount(out capacity))
                    {
                        capacity = exports.Count();
                    }

                    try
                    {
                        await Parallel.ForEachAsync<MultichannelOrderManagerFlattenedTaxRateExport>(exports, pOptions, async (export, cancellationToken) =>
                        {
                            MultichannelOrderManagerFlattenedTaxRateExport newExport = new MultichannelOrderManagerFlattenedTaxRateExport();

                            if (!String.IsNullOrWhiteSpace(export.PostalCode.PostalCode))
                            {
                                newExport = export.Clone<MultichannelOrderManagerFlattenedTaxRateExport>();

                                newExport.PostalCode = (
                                    from pc in postalCodes
                                    where String.Equals(pc.PostalCode?.Trim(), export.PostalCode.PostalCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                    select pc.ToMultichannelOrderManagerPostalCode()
                                ).FirstOrDefault();

                                // if we cannot find the postal code, then skip it.
                                // no postal code = no export can be done

                                if (newExport.PostalCode != null && newExport.PostalCode.ID > 0)
                                {
                                    newExport.Country = newExport.PostalCode.Country;
                                    newExport.StateProvince = newExport.PostalCode.StateProvince;
                                    newExport.Server = newExport.Server;

                                    await asyncExports.AddAsync(newExport);
                                }
                            }
                        });
                    }
                    catch (Exception e)
                    {
                        result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(e);
                    }
                }

                if (result == null)
                {
                    if (!concurrentExports.Any() && exports.Any())
                    {
                        concurrentExports = new ConcurrentBag<MultichannelOrderManagerFlattenedTaxRateExport>(exports);
                    }

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(WhippetResult.Success, concurrentExports);
                }

                return result;
            }

        }

        /// <summary>
        /// Fixes <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> objects that are missing an <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="exports"><see cref="IEnumerable{T}"/> collection of <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> objects that were returned from the initial export.</param>
        /// <param name="countryManager"><see cref="MultichannelOrderManagerCountryServiceManager"/> object.</param>
        /// <param name="postalCodeManager"><see cref="PostalCodeServiceManager"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>> FixUpMissingCountryData(IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport> exports, MultichannelOrderManagerCountryServiceManager countryManager, PostalCodeServiceManager postalCodeManager)
        {
            if (exports == null)
            {
                throw new ArgumentNullException(nameof(exports));
            }
            else if (countryManager == null)
            {
                throw new ArgumentNullException(nameof(countryManager));
            }
            else if (postalCodeManager == null)
            {
                throw new ArgumentNullException(nameof(postalCodeManager));
            }
            else
            {
                int capacity = 0;

                ConcurrentBag<MultichannelOrderManagerFlattenedTaxRateExport> taxRates = null;
                AsyncCollection<MultichannelOrderManagerFlattenedTaxRateExport> asyncTaxRates = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>> result = null;

                WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCountry>> allCountries = null;
                WhippetResultContainer<IEnumerable<IPostalCode>> allPostalCodes = null;

                ParallelOptions pOptions = null;

                try
                {
                    if (exports.Any())
                    {
                        if (!exports.TryGetNonEnumeratedCount(out capacity))
                        {
                            capacity = exports.Count();
                        }

                        taxRates = new ConcurrentBag<MultichannelOrderManagerFlattenedTaxRateExport>();
                        asyncTaxRates = new AsyncCollection<MultichannelOrderManagerFlattenedTaxRateExport>(taxRates, capacity);

                        allCountries = await countryManager.GetCountries();
                        allCountries.ThrowIfFailed();

                        allPostalCodes = await postalCodeManager.GetAllPostalCodes();
                        allPostalCodes.ThrowIfFailed();

                        pOptions = new ParallelOptions();
                        pOptions = pOptions.DetermineOptimalCoreCount();

                        await Parallel.ForEachAsync<MultichannelOrderManagerFlattenedTaxRateExport>(exports, pOptions, async (export, cancellationToken) =>
                        {
                            IEnumerable<IPostalCode> postalCodes = null;
                            IMultichannelOrderManagerCountry country = null;
                            IPostalCode selectedPostalCode = null;

                            if (export.PostalCode != null && !String.IsNullOrWhiteSpace(export.PostalCode.PostalCode))
                            {
                                postalCodes = allPostalCodes.Item.Where(pc => String.Equals(export.PostalCode.PostalCode.Trim(), pc.Value?.Trim(), StringComparison.InvariantCultureIgnoreCase));

                                if (postalCodes != null && postalCodes.Any())
                                {
                                    if (export.StateProvince != null && !String.IsNullOrWhiteSpace(export.StateProvince.Abbreviation))
                                    {
                                        selectedPostalCode = postalCodes.Where(pc =>
                                            (pc.City != null)
                                                && (pc.City.StateProvince != null)
                                                && (String.Equals(pc.City.StateProvince.Abbreviation, export.StateProvince.Abbreviation?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                                    || String.Equals(pc.City.StateProvince.Name, export.StateProvince.Name?.Trim(), StringComparison.InvariantCultureIgnoreCase))
                                        ).FirstOrDefault();

                                        if (selectedPostalCode == null)
                                        {
                                            selectedPostalCode = postalCodes.First();
                                        }
                                    }
                                    else
                                    {
                                        selectedPostalCode = postalCodes.First();
                                    }

                                    if (selectedPostalCode != null)
                                    {
                                        if ((selectedPostalCode.City != null)
                                            && (selectedPostalCode.City.StateProvince != null)
                                            && (selectedPostalCode.City.StateProvince.Country != null)
                                            && !String.IsNullOrWhiteSpace(selectedPostalCode.City.StateProvince.Country.Abbreviation)
                                            && allCountries.HasItem)
                                        {
                                            country = allCountries.Item.Where(c =>
                                                (selectedPostalCode.City != null)
                                                    && (selectedPostalCode.City.StateProvince != null)
                                                    && (selectedPostalCode.City.StateProvince.Country != null)
                                                    && !String.IsNullOrWhiteSpace(selectedPostalCode.City.StateProvince.Country.Abbreviation)
                                                    && (selectedPostalCode.City.StateProvince.Country.Abbreviation.Length == 2)
                                                        ? String.Equals(selectedPostalCode.City.StateProvince.Country.Abbreviation, c.ISO2?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                                        : String.Equals(selectedPostalCode.City.StateProvince.Country.Abbreviation, c.ISO3?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                            ).FirstOrDefault();
                                        }
                                        else
                                        {
                                            country = null;
                                        }
                                    }
                                }

                                if (country != null)
                                {
                                    export.Country = country.ToMultichannelOrderManagerCountry();
                                    export.PostalCode.Country = country.ToMultichannelOrderManagerCountry();
                                    export.PostalCode.County.Country = country.ToMultichannelOrderManagerCountry();
                                    export.StateProvince.Country = country.ToMultichannelOrderManagerCountry();

                                    await asyncTaxRates.AddAsync(export);
                                }
                            }
                        });

                        result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(WhippetResult.Success, taxRates);
                    }
                    else
                    {
                        result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(WhippetResult.Success, Enumerable.Empty<MultichannelOrderManagerFlattenedTaxRateExport>());
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(e);
                }

                if (result != null && result.IsSuccess)
                {
                    // now add the rest

                    //taxRates.AddRange(exports.Where(e => (e.Country != null) && (e.Country.CountryId >= 1)));

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(WhippetResult.Success, taxRates);
                }

                return result;
            }
        }

        /// <summary>
        /// Fixes <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> objects that are missing an <see cref="IMultichannelOrderManagerStateProvince"/>.
        /// </summary>
        /// <param name="exports"><see cref="IEnumerable{T}"/> collection of <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> objects that were returned from the initial export.</param>
        /// <param name="stateProvinceManager"><see cref="MultichannelOrderManagerStateProvinceServiceManager"/> object.</param>
        /// <param name="momPostalCodeManager"><see cref="MultichannelOrderManagerPostalCodeServiceManager"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>> FixUpMissingStateData(IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport> exports, MultichannelOrderManagerStateProvinceServiceManager stateProvinceManager)
        {
            if (exports == null)
            {
                throw new ArgumentNullException(nameof(exports));
            }
            else if (stateProvinceManager == null)
            {
                throw new ArgumentNullException(nameof(stateProvinceManager));
            }
            else
            {
                int capacity = 0;

                ConcurrentBag<MultichannelOrderManagerFlattenedTaxRateExport> taxRates = null;
                AsyncCollection<MultichannelOrderManagerFlattenedTaxRateExport> asyncTaxRates = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>> result = null;
                WhippetResultContainer<IEnumerable<IMultichannelOrderManagerStateProvince>> momStateProvinces = null;

                ParallelOptions pOptions = null;

                try
                {
                    if (exports.Any())
                    {
                        if (!exports.TryGetNonEnumeratedCount(out capacity))
                        {
                            capacity = exports.Count();
                        }

                        taxRates = new ConcurrentBag<MultichannelOrderManagerFlattenedTaxRateExport>();
                        asyncTaxRates = new AsyncCollection<MultichannelOrderManagerFlattenedTaxRateExport>(taxRates, capacity);

                        momStateProvinces = await stateProvinceManager.GetStateProvinces();
                        momStateProvinces.ThrowIfFailed();

                        pOptions = new ParallelOptions();
                        pOptions = pOptions.DetermineOptimalCoreCount();

                        await Parallel.ForEachAsync<MultichannelOrderManagerFlattenedTaxRateExport>(exports, pOptions, async (export, cancellationToken) =>
                        {
                            if (export.StateProvince == null || export.StateProvince.ID <= 0)
                            {
                                if ((export.PostalCode.StateProvince != null) && !String.IsNullOrWhiteSpace(export.PostalCode.StateProvince.Abbreviation))
                                {
                                    export.StateProvince = (
                                        from state in momStateProvinces.Item
                                        where String.Equals(state.Abbreviation?.Trim(), export.PostalCode.StateProvince.Abbreviation?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                            && String.Equals(state.Country?.CountryCode?.Trim(), export.PostalCode.Country?.CountryCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                        select state.ToMultichannelOrderManagerStateProvince()
                                    ).FirstOrDefault();
                                }

                                if (export.StateProvince.ID > 0)
                                {
                                    export.PostalCode.StateProvince = export.StateProvince.ToMultichannelOrderManagerStateProvince();
                                    await asyncTaxRates.AddAsync(export);
                                }
                            }
                            else
                            {
                                export.PostalCode.StateProvince = export.StateProvince.ToMultichannelOrderManagerStateProvince();
                                await asyncTaxRates.AddAsync(export);       // good export
                            }
                        });

                        result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(WhippetResult.Success, taxRates);
                    }
                    else
                    {
                        result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(WhippetResult.Success, Enumerable.Empty<MultichannelOrderManagerFlattenedTaxRateExport>());
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Fixes <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> objects that are missing the <see cref="IMultichannelOrderManagerPostalCode.City"/> portion on <see cref="IMultichannelOrderManagerPostalCode"/> objects.
        /// </summary>
        /// <param name="exports"><see cref="IEnumerable{T}"/> collection of <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> objects that were returned from the initial export.</param>
        /// <param name="momPostalCodeManager"><see cref="MultichannelOrderManagerPostalCodeServiceManager"/> object.</param>
        /// <param name="postalCodeManager"><see cref="PostalCodeServiceManager"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>> FixUpMissingCityData(IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport> exports, MultichannelOrderManagerPostalCodeServiceManager momPostalCodeManager, PostalCodeServiceManager postalCodeManager)
        {
            if (exports == null)
            {
                throw new ArgumentNullException(nameof(exports));
            }
            else if (momPostalCodeManager == null)
            {
                throw new ArgumentNullException(nameof(momPostalCodeManager));
            }
            else if (postalCodeManager == null)
            {
                throw new ArgumentNullException(nameof(postalCodeManager));
            }
            else
            {
                int capacity = 0;

                ConcurrentBag<MultichannelOrderManagerFlattenedTaxRateExport> taxRates = null;
                AsyncCollection<MultichannelOrderManagerFlattenedTaxRateExport> asyncTaxRates = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>> result = null;
                WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>> momPostalCodes = null;

                WhippetResultContainer<IEnumerable<IPostalCode>> allPostalCodes = null;

                ParallelOptions pOptions = null;

                try
                {
                    if (exports.Any())
                    {
                        if (!exports.TryGetNonEnumeratedCount(out capacity))
                        {
                            capacity = exports.Count();
                        }

                        taxRates = new ConcurrentBag<MultichannelOrderManagerFlattenedTaxRateExport>();
                        asyncTaxRates = new AsyncCollection<MultichannelOrderManagerFlattenedTaxRateExport>(taxRates, capacity);

                        allPostalCodes = await postalCodeManager.GetAllPostalCodes();
                        allPostalCodes.ThrowIfFailed();

                        momPostalCodes = await momPostalCodeManager.GetPostalCodes();
                        momPostalCodes.ThrowIfFailed();

                        pOptions = new ParallelOptions();
                        pOptions = pOptions.DetermineOptimalCoreCount();

                        await Parallel.ForEachAsync<MultichannelOrderManagerFlattenedTaxRateExport>(exports, pOptions, async (export, cancellationToken) =>
                        {
                            string momCity = null;

                            if (String.IsNullOrWhiteSpace(export.PostalCode.City))
                            {
                                // check the MOM postal codes first

                                momCity = (
                                    from pc in momPostalCodes.Item
                                    where String.Equals(pc.PostalCode?.Trim(), export.PostalCode.PostalCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                        && String.Equals(pc.Country?.CountryCode?.Trim(), export.PostalCode?.Country?.CountryCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                    select pc.City
                                ).FirstOrDefault();

                                if (String.IsNullOrWhiteSpace(momCity))
                                {
                                    // couldn't find the city there, try looking in the postal codes from Whippet

                                    momCity = (
                                        from pc in allPostalCodes.Item
                                        where String.Equals(pc.Value?.Trim(), export.PostalCode.PostalCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                            && ((String.Equals(pc.City?.StateProvince?.Country?.Abbreviation?.Trim(), export.Country?.ISO2?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                                || (String.Equals(pc.City?.StateProvince?.Country?.Abbreviation?.Trim(), export.Country?.ISO3?.Trim(), StringComparison.InvariantCultureIgnoreCase))))
                                        select pc.City.Name
                                    ).FirstOrDefault();

                                    if (String.IsNullOrWhiteSpace(momCity))
                                    {
                                        // couldn't find city--default to NO_CITY

                                        momCity = CITY_NOT_FOUND;
                                    }
                                }

                                export.PostalCode.City = momCity;

                                await asyncTaxRates.AddAsync(export);
                            }
                            else
                            {
                                await asyncTaxRates.AddAsync(export);       // good export
                            }
                        });

                        result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(WhippetResult.Success, taxRates);
                    }
                    else
                    {
                        result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(WhippetResult.Success, Enumerable.Empty<MultichannelOrderManagerFlattenedTaxRateExport>());
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(e);
                }

                return result;
            }
        }
        
        /// <summary>
        /// Fixes <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> objects that are missing the <see cref="IMultichannelOrderManagerPostalCode.County"/> portion on <see cref="IMultichannelOrderManagerPostalCode"/> objects.
        /// </summary>
        /// <param name="exports"><see cref="IEnumerable{T}"/> collection of <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> objects that were returned from the initial export.</param>
        /// <param name="momPostalCodeManager"><see cref="MultichannelOrderManagerPostalCodeServiceManager"/> object.</param>
        /// <param name="momCountyManager"><see cref="MultichannelOrderManagerCountyServiceManager"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>> FixUpMissingCountyData(IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport> exports, MultichannelOrderManagerPostalCodeServiceManager momPostalCodeManager, MultichannelOrderManagerCountyServiceManager momCountyManager)
        {
            if (exports == null)
            {
                throw new ArgumentNullException(nameof(exports));
            }
            else if (momPostalCodeManager == null)
            {
                throw new ArgumentNullException(nameof(momPostalCodeManager));
            }
            else if (momCountyManager == null)
            {
                throw new ArgumentNullException(nameof(momCountyManager));
            }
            else
            {
                int capacity = 0;

                ConcurrentBag<MultichannelOrderManagerFlattenedTaxRateExport> taxRates = null;
                AsyncCollection<MultichannelOrderManagerFlattenedTaxRateExport> asyncTaxRates = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>> result = null;
                WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>> momPostalCodes = null;
                WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCounty>> momCounties = null;

                ParallelOptions pOptions = null;

                try
                {
                    if (exports.Any())
                    {
                        if (!exports.TryGetNonEnumeratedCount(out capacity))
                        {
                            capacity = exports.Count();
                        }

                        taxRates = new ConcurrentBag<MultichannelOrderManagerFlattenedTaxRateExport>();
                        asyncTaxRates = new AsyncCollection<MultichannelOrderManagerFlattenedTaxRateExport>(taxRates, capacity);

                        momPostalCodes = await momPostalCodeManager.GetPostalCodes();
                        momPostalCodes.ThrowIfFailed();

                        momCounties = await momCountyManager.GetCounties();
                        momCounties.ThrowIfFailed();

                        pOptions = new ParallelOptions();
                        pOptions = pOptions.DetermineOptimalCoreCount();

                        await Parallel.ForEachAsync<MultichannelOrderManagerFlattenedTaxRateExport>(exports, pOptions, async (export, cancellationToken) =>
                        {
                            IMultichannelOrderManagerPostalCode postalCode = momPostalCodes.Item.Where(pc => pc.ID == export.PostalCode.ID).FirstOrDefault();
                            IMultichannelOrderManagerCounty county = null;

                            if (postalCode != null)
                            {
                                if (postalCode.County.CountyId <= 0)
                                {
                                    county = momCounties.Item.Where(c => String.Equals(c.CountyCode?.Trim(), postalCode.County.CountyCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                                    if (county != null)
                                    {
                                        export.PostalCode.County = county.ToMultichannelOrderManagerCounty();
                                        await asyncTaxRates.AddAsync(export);
                                    }
                                }
                                else
                                {
                                    await asyncTaxRates.AddAsync(export);   // if county has an ID, assume it's already loaded
                                }
                            }
                        });

                        result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(WhippetResult.Success, taxRates);
                    }
                    else
                    {
                        result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(WhippetResult.Success, Enumerable.Empty<MultichannelOrderManagerFlattenedTaxRateExport>());
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Fixes up missing warehouse data in the specified <see cref="IEnumerable{T}"/> collection of <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> objects.
        /// </summary>
        /// <param name="exports"><see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> objects to fix.</param>
        /// <param name="countries"><see cref="IMultichannelOrderManagerCountry"/> collection.</param>
        /// <param name="states"><see cref="IMultichannelOrderManagerStateProvince"/> collection.</param>
        /// <param name="counties"><see cref="IMultichannelOrderManagerCounty"/> collection.</param>
        /// <param name="postalCodes"><see cref="IMultichannelOrderManagerPostalCode"/> collection.</param>
        /// <param name="defaultWarehouse">Default <see cref="IMultichannelOrderManagerWarehouse"/> to apply if no corresponding <see cref="IMultichannelOrderManagerWarehouse"/> could be located.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>> FixUpWarehouses(IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport> exports, IEnumerable<IMultichannelOrderManagerCountry> countries, IEnumerable<IMultichannelOrderManagerStateProvince> states, IEnumerable<IMultichannelOrderManagerCounty> counties, IEnumerable<IMultichannelOrderManagerPostalCode> postalCodes, IMultichannelOrderManagerWarehouse defaultWarehouse)
        {
            if (exports == null)
            {
                throw new ArgumentNullException(nameof(exports));
            }
            else if (countries == null)
            {
                throw new ArgumentNullException(nameof(countries));
            }
            else if (states == null)
            {
                throw new ArgumentNullException(nameof(states));
            }
            else if (counties == null)
            {
                throw new ArgumentNullException(nameof(counties));
            }
            else if (postalCodes == null)
            {
                throw new ArgumentNullException(nameof(postalCodes));
            }
            else if (defaultWarehouse == null)
            {
                throw new ArgumentNullException(nameof(defaultWarehouse));
            }
            else
            {
                int capacity = 0;

                ConcurrentBag<MultichannelOrderManagerFlattenedTaxRateExport> taxRates = null;
                AsyncCollection<MultichannelOrderManagerFlattenedTaxRateExport> asyncTaxRates = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>> result = null;

                ParallelOptions pOptions = null;

                IList<MultichannelOrderManagerFlattenedTaxRateExport> filteredExports = null;
                IList<MultichannelOrderManagerFlattenedTaxRateExport> goodExports = null;

                try
                {
                    if (exports.Any())
                    {
                        if (!exports.TryGetNonEnumeratedCount(out capacity))
                        {
                            capacity = exports.Count();
                        }

                        taxRates = new ConcurrentBag<MultichannelOrderManagerFlattenedTaxRateExport>();
                        asyncTaxRates = new AsyncCollection<MultichannelOrderManagerFlattenedTaxRateExport>(taxRates, capacity);

                        filteredExports = new List<MultichannelOrderManagerFlattenedTaxRateExport>(capacity);
                        goodExports = new List<MultichannelOrderManagerFlattenedTaxRateExport>(capacity);

                        pOptions = new ParallelOptions();
                        pOptions = pOptions.DetermineOptimalCoreCount();

                        // build the filtered exports

                        filteredExports.AddRange((
                            from e in exports
                            where ((e.Country.Warehouse == null) || (e.Country.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.Country.Warehouse.Description)))
                                || ((e.StateProvince.Warehouse == null) || (e.StateProvince.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.StateProvince.Warehouse.Description)))
                                || ((e.StateProvince.Country.Warehouse == null) || (e.StateProvince.Country.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.StateProvince.Country.Warehouse.Description)))
                                || ((e.PostalCode.County.Warehouse == null) || (e.PostalCode.County.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.Warehouse.Description)))
                                || ((e.PostalCode.County.StateProvince.Warehouse == null) || (e.PostalCode.County.StateProvince.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Warehouse.Description)))
                                || ((e.PostalCode.County.StateProvince.Country.Warehouse == null) || (e.PostalCode.County.StateProvince.Country.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.Warehouse.Description)))
                                || ((e.PostalCode.County.Country.Warehouse == null) || (e.PostalCode.County.Country.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.Country.Warehouse.Description)))
                                || ((e.PostalCode.Warehouse == null) || (e.PostalCode.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.Warehouse.Description)))
                            select e
                        ).AsParallel());

                        goodExports.AddRange((
                            from e in exports
                            where !(((e.Country.Warehouse == null) || (e.Country.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.Country.Warehouse.Description)))
                                || ((e.StateProvince.Warehouse == null) || (e.StateProvince.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.StateProvince.Warehouse.Description)))
                                || ((e.StateProvince.Country.Warehouse == null) || (e.StateProvince.Country.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.StateProvince.Country.Warehouse.Description)))
                                || ((e.PostalCode.County.Warehouse == null) || (e.PostalCode.County.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.Warehouse.Description)))
                                || ((e.PostalCode.County.StateProvince.Warehouse == null) || (e.PostalCode.County.StateProvince.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Warehouse.Description)))
                                || ((e.PostalCode.County.StateProvince.Country.Warehouse == null) || (e.PostalCode.County.StateProvince.Country.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.Warehouse.Description)))
                                || ((e.PostalCode.County.Country.Warehouse == null) || (e.PostalCode.County.Country.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.Country.Warehouse.Description)))
                                || ((e.PostalCode.Warehouse == null) || (e.PostalCode.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.Warehouse.Description))))
                            select e
                        ).AsParallel());

                        if (filteredExports.Count > 0)
                        {
                            await Parallel.ForEachAsync<MultichannelOrderManagerFlattenedTaxRateExport>(filteredExports, pOptions, async (export, cancellationToken) =>
                            {
                                IMultichannelOrderManagerWarehouse warehouse = null;

                                // determine which elements need a warehouse

                                if ((export.Country.Warehouse == null) || (export.Country.Warehouse.WarehouseID == 0) || String.IsNullOrWhiteSpace(export.Country.Warehouse.Description))
                                {
                                    warehouse = (from c in countries where c.CountryId == export.Country.CountryId select c.Warehouse).FirstOrDefault();

                                    if (warehouse == null)
                                    {
                                        warehouse = defaultWarehouse;
                                    }

                                    export.Country.Warehouse = warehouse.ToMultichannelOrderManagerWarehouse();
                                }

                                if ((export.PostalCode.Warehouse == null) || (export.PostalCode.Warehouse.WarehouseID == 0) || String.IsNullOrWhiteSpace(export.PostalCode.Warehouse.Description))
                                {
                                    warehouse = (from p in postalCodes where p.ID == export.PostalCode.ID select p.Warehouse).FirstOrDefault();

                                    if (warehouse == null)
                                    {
                                        warehouse = defaultWarehouse;
                                    }

                                    export.PostalCode.Warehouse = warehouse.ToMultichannelOrderManagerWarehouse();
                                }

                                // Postal code counties - start

                                if ((export.PostalCode.County.Warehouse == null) || (export.PostalCode.County.Warehouse.WarehouseID == 0) || String.IsNullOrWhiteSpace(export.PostalCode.County.Warehouse.Description))
                                {
                                    warehouse = (from p in counties where p.CountyId == export.PostalCode.County.CountyId select p.Warehouse).FirstOrDefault();

                                    if (warehouse == null)
                                    {
                                        warehouse = defaultWarehouse;
                                    }

                                    export.PostalCode.County.Warehouse = warehouse.ToMultichannelOrderManagerWarehouse();
                                }

                                if ((export.PostalCode.County.Country.Warehouse == null) || (export.PostalCode.County.Country.Warehouse.WarehouseID == 0) || String.IsNullOrWhiteSpace(export.PostalCode.County.Country.Warehouse.Description))
                                {
                                    warehouse = (from c in countries where c.CountryId == export.PostalCode.County.Country.CountryId select c.Warehouse).FirstOrDefault();

                                    if (warehouse == null)
                                    {
                                        warehouse = defaultWarehouse;
                                    }

                                    export.PostalCode.County.Country.Warehouse = warehouse.ToMultichannelOrderManagerWarehouse();
                                }

                                if ((export.PostalCode.County.StateProvince.Warehouse == null) || (export.PostalCode.County.StateProvince.Warehouse.WarehouseID == 0) || String.IsNullOrWhiteSpace(export.PostalCode.County.StateProvince.Warehouse.Description))
                                {
                                    warehouse = (from s in states where s.ID == export.PostalCode.County.StateProvince.ID select s.Warehouse).FirstOrDefault();

                                    if (warehouse == null)
                                    {
                                        warehouse = defaultWarehouse;
                                    }

                                    export.PostalCode.County.StateProvince.Warehouse = warehouse.ToMultichannelOrderManagerWarehouse();
                                }

                                if ((export.PostalCode.County.StateProvince.Country.Warehouse == null) || (export.PostalCode.County.StateProvince.Country.Warehouse.WarehouseID == 0) || String.IsNullOrWhiteSpace(export.PostalCode.County.StateProvince.Country.Warehouse.Description))
                                {
                                    warehouse = (from c in countries where c.CountryId == export.PostalCode.County.StateProvince.Country.CountryId select c.Warehouse).FirstOrDefault();

                                    if (warehouse == null)
                                    {
                                        warehouse = defaultWarehouse;
                                    }

                                    export.PostalCode.County.StateProvince.Country.Warehouse = warehouse.ToMultichannelOrderManagerWarehouse();
                                }

                                // Postal code counties - end

                                // Postal code states - start

                                if ((export.PostalCode.StateProvince.Warehouse == null) || (export.PostalCode.StateProvince.Warehouse.WarehouseID == 0) || String.IsNullOrWhiteSpace(export.PostalCode.StateProvince.Warehouse.Description))
                                {
                                    warehouse = (from p in states where p.ID == export.PostalCode.StateProvince.ID select p.Warehouse).FirstOrDefault();

                                    if (warehouse == null)
                                    {
                                        warehouse = defaultWarehouse;
                                    }

                                    export.PostalCode.StateProvince.Warehouse = warehouse.ToMultichannelOrderManagerWarehouse();
                                }

                                if ((export.PostalCode.StateProvince.Country.Warehouse == null) || (export.PostalCode.StateProvince.Country.Warehouse.WarehouseID == 0) || String.IsNullOrWhiteSpace(export.PostalCode.StateProvince.Country.Warehouse.Description))
                                {
                                    warehouse = (from c in countries where c.CountryId == export.PostalCode.StateProvince.Country.CountryId select c.Warehouse).FirstOrDefault();

                                    if (warehouse == null)
                                    {
                                        warehouse = defaultWarehouse;
                                    }

                                    export.PostalCode.StateProvince.Country.Warehouse = warehouse.ToMultichannelOrderManagerWarehouse();
                                }

                                // Postal code states - end

                                await asyncTaxRates.AddAsync(export);
                            });
                        }

                        result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(WhippetResult.Success, goodExports.Concat(taxRates));
                    }
                    else
                    {
                        result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(WhippetResult.Success, Enumerable.Empty<MultichannelOrderManagerFlattenedTaxRateExport>());
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Fixes up missing country data in the specified <see cref="IEnumerable{T}"/> collection of <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> objects.
        /// </summary>
        /// <param name="exports"><see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> objects to fix.</param>
        /// <param name="countries"><see cref="IMultichannelOrderManagerCountry"/> collection.</param>
        /// <param name="states"><see cref="IMultichannelOrderManagerStateProvince"/> collection.</param>
        /// <param name="counties"><see cref="IMultichannelOrderManagerCounty"/> collection.</param>
        /// <param name="postalCodes"><see cref="IMultichannelOrderManagerPostalCode"/> collection.</param>
        /// <param name="defaultCountry">Default <see cref="IMultichannelOrderManagerCountry"/> to assign if value could not be found.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>> FixUpMissingCountryData(IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport> exports, IEnumerable<IMultichannelOrderManagerCountry> countries, IEnumerable<IMultichannelOrderManagerStateProvince> states, IEnumerable<IMultichannelOrderManagerCounty> counties, IEnumerable<IMultichannelOrderManagerPostalCode> postalCodes, IMultichannelOrderManagerCountry defaultCountry)
        {
            if (exports == null)
            {
                throw new ArgumentNullException(nameof(exports));
            }
            else if (countries == null)
            {
                throw new ArgumentNullException(nameof(countries));
            }
            else if (states == null)
            {
                throw new ArgumentNullException(nameof(states));
            }
            else if (counties == null)
            {
                throw new ArgumentNullException(nameof(counties));
            }
            else if (postalCodes == null)
            {
                throw new ArgumentNullException(nameof(postalCodes));
            }
            else if (defaultCountry == null)
            {
                throw new ArgumentNullException(nameof(defaultCountry));
            }
            else
            {
                int capacity = 0;

                ConcurrentBag<MultichannelOrderManagerFlattenedTaxRateExport> taxRates = null;
                AsyncCollection<MultichannelOrderManagerFlattenedTaxRateExport> asyncTaxRates = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>> result = null;

                ParallelOptions pOptions = null;

                IList<MultichannelOrderManagerFlattenedTaxRateExport> filteredExports = null;
                IList<MultichannelOrderManagerFlattenedTaxRateExport> goodExports = null;
                IReadOnlyList<IMultichannelOrderManagerCountry> countriesSupportCounties = null;

                try
                {
                    if (exports.Any())
                    {
                        if (!exports.TryGetNonEnumeratedCount(out capacity))
                        {
                            capacity = exports.Count();
                        }

                        taxRates = new ConcurrentBag<MultichannelOrderManagerFlattenedTaxRateExport>();
                        asyncTaxRates = new AsyncCollection<MultichannelOrderManagerFlattenedTaxRateExport>(taxRates, capacity);

                        filteredExports = new List<MultichannelOrderManagerFlattenedTaxRateExport>(capacity);
                        goodExports = new List<MultichannelOrderManagerFlattenedTaxRateExport>(capacity);

                        pOptions = new ParallelOptions();
                        pOptions = pOptions.DetermineOptimalCoreCount();

                        // build the filtered exports

                        filteredExports.AddRange((
                            from e in exports
                            where ((e.Country == null) || (e.Country.CountryId == 0) || (String.IsNullOrWhiteSpace(e.Country.CountryCode)) || String.IsNullOrWhiteSpace(e.Country.Name) || String.IsNullOrWhiteSpace(e.Country.ISO2) || String.IsNullOrWhiteSpace(e.Country.ISO3) || String.IsNullOrWhiteSpace(e.Country.ISONumber))
                                || ((e.StateProvince.Country == null) || (e.StateProvince.Country.CountryId == 0) || (String.IsNullOrWhiteSpace(e.StateProvince.Country.CountryCode)) || String.IsNullOrWhiteSpace(e.StateProvince.Country.Name) || String.IsNullOrWhiteSpace(e.StateProvince.Country.ISO2) || String.IsNullOrWhiteSpace(e.StateProvince.Country.ISO3) || String.IsNullOrWhiteSpace(e.StateProvince.Country.ISONumber))
                                || ((e.PostalCode.Country == null) || (e.PostalCode.Country.CountryId == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.Country.CountryCode)) || String.IsNullOrWhiteSpace(e.PostalCode.Country.Name) || String.IsNullOrWhiteSpace(e.PostalCode.Country.ISO2) || String.IsNullOrWhiteSpace(e.PostalCode.Country.ISO3) || String.IsNullOrWhiteSpace(e.PostalCode.Country.ISONumber))
                                || ((e.PostalCode.County.Country == null) || (e.PostalCode.County.Country.CountryId == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.Country.CountryCode)) || String.IsNullOrWhiteSpace(e.PostalCode.County.Country.Name) || String.IsNullOrWhiteSpace(e.PostalCode.County.Country.ISO2) || String.IsNullOrWhiteSpace(e.PostalCode.County.Country.ISO3) || String.IsNullOrWhiteSpace(e.PostalCode.County.Country.ISONumber))
                                || ((e.PostalCode.County.StateProvince.Country == null) || (e.PostalCode.County.StateProvince.Country.CountryId == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.CountryCode)) || String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.Name) || String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.ISO2) || String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.ISO3) || String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.ISONumber))
                            select e
                        ).AsParallel());

                        goodExports.AddRange((
                            from e in exports
                            where !((e.Country == null) || (e.Country.CountryId == 0) || (String.IsNullOrWhiteSpace(e.Country.CountryCode)) || String.IsNullOrWhiteSpace(e.Country.Name) || String.IsNullOrWhiteSpace(e.Country.ISO2) || String.IsNullOrWhiteSpace(e.Country.ISO3) || String.IsNullOrWhiteSpace(e.Country.ISONumber))
                                || ((e.StateProvince.Country == null) || (e.StateProvince.Country.CountryId == 0) || (String.IsNullOrWhiteSpace(e.StateProvince.Country.CountryCode)) || String.IsNullOrWhiteSpace(e.StateProvince.Country.Name) || String.IsNullOrWhiteSpace(e.StateProvince.Country.ISO2) || String.IsNullOrWhiteSpace(e.StateProvince.Country.ISO3) || String.IsNullOrWhiteSpace(e.StateProvince.Country.ISONumber))
                                || ((e.PostalCode.Country == null) || (e.PostalCode.Country.CountryId == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.Country.CountryCode)) || String.IsNullOrWhiteSpace(e.PostalCode.Country.Name) || String.IsNullOrWhiteSpace(e.PostalCode.Country.ISO2) || String.IsNullOrWhiteSpace(e.PostalCode.Country.ISO3) || String.IsNullOrWhiteSpace(e.PostalCode.Country.ISONumber))
                                || ((e.PostalCode.County.Country == null) || (e.PostalCode.County.Country.CountryId == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.Country.CountryCode)) || String.IsNullOrWhiteSpace(e.PostalCode.County.Country.Name) || String.IsNullOrWhiteSpace(e.PostalCode.County.Country.ISO2) || String.IsNullOrWhiteSpace(e.PostalCode.County.Country.ISO3) || String.IsNullOrWhiteSpace(e.PostalCode.County.Country.ISONumber))
                                || ((e.PostalCode.County.StateProvince.Country == null) || (e.PostalCode.County.StateProvince.Country.CountryId == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.CountryCode)) || String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.Name) || String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.ISO2) || String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.ISO3) || String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.ISONumber))
                            select e
                        ).AsParallel());

                        if (filteredExports.Count > 0)
                        {
                            // populate the countries that support counties

                            countriesSupportCounties = new List<IMultichannelOrderManagerCountry>((from c in countries where c.SupportsCounties() select c));

                            await Parallel.ForEachAsync<MultichannelOrderManagerFlattenedTaxRateExport>(filteredExports, pOptions, async (export, cancellationToken) =>
                            {
                                IMultichannelOrderManagerPostalCode code = null;
                                IMultichannelOrderManagerCountry country = null;
                                
                                code = (from pc in postalCodes where (pc.ID == export.PostalCode.ID) || String.Equals(pc.PostalCode?.Trim(), export.PostalCode.PostalCode?.Trim(), StringComparison.InvariantCultureIgnoreCase) select pc).FirstOrDefault();

                                if (code != null)
                                {
                                    export.PostalCode = code.ToMultichannelOrderManagerPostalCode();
                                    export.PostalCode.County.Country = code.Country.ToMultichannelOrderManagerCountry();
                                    export.PostalCode.County.StateProvince.Country = code.Country.ToMultichannelOrderManagerCountry();
                                    export.Country = code.Country.ToMultichannelOrderManagerCountry();

                                    if (String.IsNullOrWhiteSpace(export.Country.ISO2)
                                        || String.IsNullOrWhiteSpace(export.Country.ISO3)
                                        || String.IsNullOrWhiteSpace(export.Country.ISONumber)
                                        || String.IsNullOrWhiteSpace(export.PostalCode.Country.ISO2) 
                                        || String.IsNullOrWhiteSpace(export.PostalCode.Country.ISO3) 
                                        || String.IsNullOrWhiteSpace(export.PostalCode.Country.ISONumber)
                                        || String.IsNullOrWhiteSpace(export.PostalCode.County.Country.ISO2)
                                        || String.IsNullOrWhiteSpace(export.PostalCode.County.Country.ISO3)
                                        || String.IsNullOrWhiteSpace(export.PostalCode.County.Country.ISONumber)
                                        || String.IsNullOrWhiteSpace(export.PostalCode.County.StateProvince.Country.ISO2)
                                        || String.IsNullOrWhiteSpace(export.PostalCode.County.StateProvince.Country.ISO3)
                                        || String.IsNullOrWhiteSpace(export.PostalCode.County.StateProvince.Country.ISONumber)
                                    )
                                    {
                                        country = (from c in countries where c.ID == export.PostalCode.Country.ID select c).FirstOrDefault();

                                        if (country != null)
                                        {
                                            export.Country.ISO2 = country.ISO2;
                                            export.Country.ISO3 = country.ISO3;
                                            export.Country.ISONumber = country.ISONumber;
                                            
                                            export.PostalCode.Country.ISO2 = country.ISO2;
                                            export.PostalCode.Country.ISO3 = country.ISO3;
                                            export.PostalCode.Country.ISONumber = country.ISONumber;
                                            
                                            export.PostalCode.County.Country.ISO2 = country.ISO2;
                                            export.PostalCode.County.Country.ISO3 = country.ISO3;
                                            export.PostalCode.County.Country.ISONumber = country.ISONumber;
                                            
                                            export.PostalCode.County.StateProvince.Country.ISO2 = country.ISO2;
                                            export.PostalCode.County.StateProvince.Country.ISO3 = country.ISO3;
                                            export.PostalCode.County.StateProvince.Country.ISONumber = country.ISONumber;
                                        }
                                    }
                                }

                                await asyncTaxRates.AddAsync(export);
                            });
                        }

                        result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(WhippetResult.Success, goodExports.Concat(taxRates));
                    }
                    else
                    {
                        result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(WhippetResult.Success, Enumerable.Empty<MultichannelOrderManagerFlattenedTaxRateExport>());
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Assigns an <see cref="IMultichannelOrderManagerServer"/> object to all <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> objects.
        /// </summary>
        /// <param name="exports"><see cref="IEnumerable{T}"/> collection of <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> objects that were returned from the initial export.</param>
        /// <param name="server"><see cref="IMultichannelOrderManagerServer"/> to assign to each object.</param>
        /// <param name="exportSourceServer"><see cref="IMultichannelOrderManagerServer"/> which generated the original <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> objects or <see langword="null"/> to use <paramref name="server"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>> AssignServer(IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport> exports, IMultichannelOrderManagerServer server, IMultichannelOrderManagerServer exportSourceServer = null)
        {
            if (exports == null)
            {
                throw new ArgumentNullException(nameof(exports));
            }
            else if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }
            else
            {
                int capacity = 0;

                ConcurrentBag<MultichannelOrderManagerFlattenedTaxRateExport> taxRates = null;
                AsyncCollection<MultichannelOrderManagerFlattenedTaxRateExport> asyncTaxRates = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>> result = null;

                ParallelOptions pOptions = null;

                MultichannelOrderManagerServer sourceServer = null;
                MultichannelOrderManagerServer reportServer = null;

                try
                {
                    if (exports.Any())
                    {
                        if (!exports.TryGetNonEnumeratedCount(out capacity))
                        {
                            capacity = exports.Count();
                        }

                        taxRates = new ConcurrentBag<MultichannelOrderManagerFlattenedTaxRateExport>();
                        asyncTaxRates = new AsyncCollection<MultichannelOrderManagerFlattenedTaxRateExport>(taxRates, capacity);

                        pOptions = new ParallelOptions();
                        pOptions = pOptions.DetermineOptimalCoreCount();

                        sourceServer = server.ToMultichannelOrderManagerServer();
                        reportServer = (exportSourceServer == null) ? sourceServer : exportSourceServer.ToMultichannelOrderManagerServer();

                        await Parallel.ForEachAsync<MultichannelOrderManagerFlattenedTaxRateExport>(exports, pOptions, async (export, cancellationToken) =>
                        {
                            export.Country.Server = sourceServer;
                            export.Country.Warehouse.Server = sourceServer;

                            // states

                            export.StateProvince.Server = sourceServer;
                            export.StateProvince.Warehouse.Server = sourceServer;
                            export.StateProvince.Country.Server = sourceServer;
                            export.StateProvince.Country.Warehouse.Server = sourceServer;

                            // postal codes

                            export.PostalCode.Warehouse.Server = sourceServer;
                            export.PostalCode.Country.Warehouse.Server = sourceServer;
                            export.PostalCode.StateProvince.Warehouse.Server = sourceServer;
                            export.PostalCode.StateProvince.Country.Warehouse.Server = sourceServer;
                            export.PostalCode.County.Warehouse.Server = sourceServer;
                            export.PostalCode.County.StateProvince.Warehouse.Server = sourceServer;
                            export.PostalCode.County.StateProvince.Country.Warehouse.Server = sourceServer;

                            export.PostalCode.Server = sourceServer;
                            export.PostalCode.Country.Server = sourceServer;
                            export.PostalCode.County.Server = sourceServer;
                            export.PostalCode.County.StateProvince.Server = sourceServer;
                            export.PostalCode.County.StateProvince.Country.Server = sourceServer;
                            export.PostalCode.County.Country.Server = sourceServer;
                            export.PostalCode.StateProvince.Server = sourceServer;
                            export.PostalCode.StateProvince.Country.Server = sourceServer;

                            export.Server = reportServer;

                            await asyncTaxRates.AddAsync(export);
                        });

                        result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(WhippetResult.Success, taxRates);
                    }
                    else
                    {
                        result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(WhippetResult.Success, Enumerable.Empty<MultichannelOrderManagerFlattenedTaxRateExport>());
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (FlattenedTaxRateExportRepository != null)
            {
                FlattenedTaxRateExportRepository.Dispose();
                FlattenedTaxRateExportRepository = null;
            }

            base.Dispose();
        }
    }
}
