using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Nito.AsyncEx;
using NodaTime;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Threading.Tasks.Extensions;
using Athi.Whippet.Collections.Concurrent.Extensions;
using Athi.Whippet.Security;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.Security.Extensions;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Exports;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Exports.ServiceManagers;
using Athi.Whippet.Adobe.Magento;
using Athi.Whippet.Adobe.Magento.ServiceManagers;
using Athi.Whippet.Adobe.Magento.Taxes;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers;
using Athi.Whippet.Adobe.Magento.Directory;
using Athi.Whippet.Adobe.Magento.Directory.Extensions;
using Athi.Whippet.Adobe.Magento.Directory.ServiceManagers;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Models;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Models;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers;
using WhippetPostalCodeServiceManager = Athi.Whippet.Localization.Addressing.ServiceManagers.PostalCodeServiceManager;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.ServiceManagers
{
    /// <summary>
    /// Service manager for Magento tax synchronization operations.
    /// </summary>
    public class MagentoTaxSynchronizationServiceManager : ServiceManager, IDisposable
    {
        private const string COUNTRY_CODE_USA = "001";

        /// <summary>
        /// Gets the <see cref="MagentoServerServiceManager"/> instance. This property is read-only.
        /// </summary>
        protected virtual MagentoServerServiceManager MagentoServerManager
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="TaxRateServiceManager"/> instance. This property is read-only.
        /// </summary>
        protected virtual TaxRateServiceManager MagentoTaxRateManager
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="TaxRuleServiceManager"/> instance. This property is read-only.
        /// </summary>
        protected virtual TaxRuleServiceManager MagentoTaxRuleServiceManager
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="TaxClassServiceManager"/> instance. This property is read-only.
        /// </summary>
        protected virtual TaxClassServiceManager MagentoTaxClassServiceManager
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="CountryServiceManager"/> instance. This property is read-only.
        /// </summary>
        protected virtual CountryServiceManager MagentoCountryServiceManager
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="ILogger"/> used for tracking events within the service manager. This property is read-only.
        /// </summary>
        protected virtual ILogger Logger
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationServiceManager"/> class with no arguments.
        /// </summary>
        protected MagentoTaxSynchronizationServiceManager()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationServiceManager"/> class with the specified service managers.
        /// </summary>
        /// <param name="magentoServerSM"><see cref="MagentoServerServiceManager"/> object.</param>
        /// <param name="magentoTaxRateSM"><see cref="TaxRateServiceManager"/> object.</param>
        /// <param name="magentoTaxRuleSM"><see cref="TaxRuleServiceManager"/> object.</param>
        /// <param name="magentoTaxClassSM"><see cref="TaxClassServiceManager"/> object.</param>
        /// <param name="magentoCountrySM"><see cref="CountryServiceManager"/> object.</param>
        /// <exception cref="ArgumentNullException" />
        public MagentoTaxSynchronizationServiceManager(MagentoServerServiceManager magentoServerSM, TaxRateServiceManager magentoTaxRateSM, TaxRuleServiceManager magentoTaxRuleSM, TaxClassServiceManager magentoTaxClassSM, CountryServiceManager magentoCountrySM)
            : this(magentoServerSM, magentoTaxRateSM, magentoTaxRuleSM, magentoTaxClassSM, magentoCountrySM, NullLogger<MagentoTaxSynchronizationServiceManager>.Instance)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationServiceManager"/> class with the specified service managers.
        /// </summary>
        /// <param name="magentoServerSM"><see cref="MagentoServerServiceManager"/> object.</param>
        /// <param name="magentoTaxRateSM"><see cref="TaxRateServiceManager"/> object.</param>
        /// <param name="magentoTaxRuleSM"><see cref="TaxRuleServiceManager"/> object.</param>
        /// <param name="magentoTaxClassSM"><see cref="TaxClassServiceManager"/> object.</param>
        /// <param name="magentoCountrySM"><see cref="CountryServiceManager"/> object.</param>
        /// <param name="logger"><see cref="ILogger"/> used to log activity within the service manager.</param>
        /// <exception cref="ArgumentNullException" />
        public MagentoTaxSynchronizationServiceManager(MagentoServerServiceManager magentoServerSM, TaxRateServiceManager magentoTaxRateSM, TaxRuleServiceManager magentoTaxRuleSM, TaxClassServiceManager magentoTaxClassSM, CountryServiceManager magentoCountrySM, ILogger logger)
            : this()
        {
            ArgumentNullException.ThrowIfNull(magentoServerSM);
            ArgumentNullException.ThrowIfNull(magentoTaxRateSM);
            ArgumentNullException.ThrowIfNull(magentoTaxRuleSM);
            ArgumentNullException.ThrowIfNull(magentoTaxClassSM);
            ArgumentNullException.ThrowIfNull(logger);

            MagentoServerManager = magentoServerSM;
            MagentoTaxRateManager = magentoTaxRateSM;
            MagentoTaxRuleServiceManager = magentoTaxRuleSM;
            MagentoTaxClassServiceManager = magentoTaxClassSM;
            MagentoCountryServiceManager = magentoCountrySM;
            Logger = logger;
        }

        /// <summary>
        /// Assigns the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to the specified collection of entries.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to assign.</param>
        /// <param name="entries"><see cref="Tuple{T1, T2}"/> of an <see cref="IEnumerable{T}"/> collection of <see cref="MagentoSalesTaxRateSynchronizationRecordDataModel"/> objects and an <see cref="IEnumerable{T}"/> collection of <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel"/> objects.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<Tuple<IEnumerable<MagentoSalesTaxRateSynchronizationRecordDataModel>, IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel>>>> AssignCache(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, Tuple<IEnumerable<MagentoSalesTaxRateSynchronizationRecordDataModel>, IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel>> entries)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                WhippetResultContainer<Tuple<IEnumerable<MagentoSalesTaxRateSynchronizationRecordDataModel>, IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel>>> result = null;
                ParallelOptions pOptions = null;

                Tuple<IEnumerable<MagentoSalesTaxRateSynchronizationRecordDataModel>, IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel>> updatedEntries = null;

                ConcurrentBag<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel> models = null;

                AsyncCollection<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel> asyncModels = null;

                int count = 0;

                if (entries != null && (entries.Item2 != null && entries.Item2.Any()))
                {
                    try
                    {
                        if (!entries.Item2.TryGetNonEnumeratedCount(out count))
                        {
                            count = entries.Item2.Count();
                        }

                        models = new ConcurrentBag<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel>();
                        asyncModels = new AsyncCollection<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel>(models, count);

                        pOptions = pOptions.DetermineOptimalCoreCount();

                        await Parallel.ForEachAsync<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel>(entries.Item2, pOptions, async (cacheEntry, cancellationToken) =>
                        {
                            if (cacheEntry != null)
                            {
                                cacheEntry.CacheID = cache.ID;
                                await asyncModels.AddAsync(cacheEntry);
                            }
                        });

                        updatedEntries = new Tuple<IEnumerable<MagentoSalesTaxRateSynchronizationRecordDataModel>, IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel>>(entries.Item1, models);
                        result = new WhippetResultContainer<Tuple<IEnumerable<MagentoSalesTaxRateSynchronizationRecordDataModel>, IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel>>>(WhippetResult.Success, updatedEntries);
                    }
                    catch (Exception e)
                    {
                        result = new WhippetResultContainer<Tuple<IEnumerable<MagentoSalesTaxRateSynchronizationRecordDataModel>, IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel>>>(e);
                    }
                }
                else
                {
                    result = new WhippetResultContainer<Tuple<IEnumerable<MagentoSalesTaxRateSynchronizationRecordDataModel>, IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel>>>(WhippetResult.Success, entries);
                }

                return result;
            }
        }

        /// <summary>
        /// Retrieves all Magento sales tax rates to update based on the synchronization results with Multichannel Order Management's tax rates. <see cref="IDisposable"/> objects will not be disposed; it is up to the caller to dispose of them properly.
        /// </summary>
        /// <param name="magentoServer"><see cref="IMagentoServer"/> that serves as the destination server.</param>
        /// <param name="magentoExemptTaxRateCode">Tax rate code that marks the jurisdiction as tax-exempt.</param>
        /// <param name="preserveMagentoExemptTaxRates">If <see langword="true"/>, Magento tax-exempt rates will not be overridden.</param>
        /// <param name="momTaxRateSM"><see cref="MultichannelOrderManagerFlattenedTaxRateExportServiceManager"/> instance.</param>
        /// <param name="momCountrySM"><see cref="MultichannelOrderManagerCountryServiceManager"/> instance.</param>
        /// <param name="momStateProvinceSM"><see cref="MultichannelOrderManagerStateProvinceServiceManager"/> instance.</param>
        /// <param name="momPostalCodeSM"><see cref="MultichannelOrderManagerPostalCodeServiceManager"/> instance.</param>
        /// <param name="postalCodeSM"><see cref="WhippetPostalCodeServiceManager"/> instance.</param>
        /// <param name="momCountySM"><see cref="MultichannelOrderManagerCountyServiceManager"/> instance.</param>
        /// <param name="momWarehouseSM"><see cref="MultichannelOrderManagerWarehouseServiceManager"/> instance.</param>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> instance.</param>
        /// <param name="cacheEntrySM"><see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryServiceManager"/> instance.</param>
        /// <param name="cacheCouchDBEntrySM"><see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryServiceManager"/> instance.</param>
        /// <param name="primaryMomServer"><see cref="IMultichannelOrderManagerServer"/> where the primary addressing data is stored.</param>
        /// <param name="momExportServer"><see cref="IMultichannelOrderManagerServer"/> where the export data was retrieved from.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object.</param>
        /// <param name="missingCountryIdentifier">Identifier that is used to mark records that are missing the country portion of the tax rate.</param>
        /// <param name="user"><see cref="IWhippetUser"/> that is making the request or <see langword="null"/> to use the system account.</param>
        /// <param name="eventId">Event ID to assign to the log entries or <see langword="null"/> to use <see cref="Int32.MaxValue"/>.</param>
        /// <param name="refreshCache">If <see langword="true"/>, will refresh any caches used to store tax rate information.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<Tuple<IEnumerable<MagentoSalesTaxRateSynchronizationRecordDataModel>, IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel>>>> GetMagentoTaxRatesToUpdate(IMagentoServer magentoServer, string magentoExemptTaxRateCode, bool preserveMagentoExemptTaxRates, MultichannelOrderManagerFlattenedTaxRateExportServiceManager momTaxRateSM, MultichannelOrderManagerCountryServiceManager momCountrySM, MultichannelOrderManagerStateProvinceServiceManager momStateProvinceSM, MultichannelOrderManagerPostalCodeServiceManager momPostalCodeSM, MultichannelOrderManagerCountyServiceManager momCountySM, MultichannelOrderManagerWarehouseServiceManager momWarehouseSM, WhippetPostalCodeServiceManager postalCodeSM, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryServiceManager cacheEntrySM, MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryServiceManager cacheCouchDBEntrySM, IMultichannelOrderManagerServer primaryMomServer, IMultichannelOrderManagerServer momExportServer, IWhippetTenant tenant, string missingCountryIdentifier, IWhippetUser user = null, int? eventId = null, bool refreshCache = true)
        {
            const string EVENT_TITLE__DATA_LOADING = "Data Loading";
            const string EVENT_TITLE__TAX_IMPORT = "Multichannel Order Manager Tax Rate Import";

            const string LOADING_RATES__MAGENTO = "Loading Magento tax rates requested by {User}.";
            const string LOADING_RATES__MOM = "Loading Multichannel Order Manager tax rates requested by {User}.";
            const string LOADING_RULES__MAGENTO = "Loading Magento tax rules requested by {User}.";
            const string LOADING_CLASSES__MAGENTO = "Loading Magento tax classes requested by {User}.";
            const string LOADING_GEOGRAPHIC__MOM = "Loading Multichannel Order Manager geographic data requested by {User}.";

            const string LOADED_RATES__MAGENTO = "Magento tax rates loaded by {User}.";
            const string LOADED_RULES__MAGENTO = "Magento tax rules loaded by {User}.";
            const string LOADED_CLASSES__MAGENTO = "Magento tax classes loaded by {User}.";
            const string LOADED_GEOGRAPHIC__MOM = "Multichannel Order Manager geographic data loaded by {User}.";

            const string PROCESSING_GEOGRAPHIC__MOM = "Assigning Multichannel Order Manager geographic data to tax rates loaded by {User}.";

            const string EVENT_MISSING = "Magento tax rate missing for country {CountryID} region {RegionName} postal code {PostalCode}. {User} is requesting this be created.";
            const string EVENT_DELETE = "No matching rate found for Magento tax rate {RateID}. Marked for deletion by {User}.";
            const string EVENT_UPDATE = "Magento tax rate {Country}-{State}-{PostalCode} does not match corresponding Multichannel Order Manager rate. Marked for update by {User}.";

            ArgumentNullException.ThrowIfNull(magentoServer);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(magentoExemptTaxRateCode);
            ArgumentNullException.ThrowIfNull(momTaxRateSM);
            ArgumentNullException.ThrowIfNull(momCountrySM);
            ArgumentNullException.ThrowIfNull(momStateProvinceSM);
            ArgumentNullException.ThrowIfNull(momPostalCodeSM);
            ArgumentNullException.ThrowIfNull(postalCodeSM);
            ArgumentNullException.ThrowIfNull(momCountySM);
            ArgumentNullException.ThrowIfNull(momWarehouseSM);
            ArgumentNullException.ThrowIfNull(cache);
            ArgumentNullException.ThrowIfNull(cacheEntrySM);
            ArgumentNullException.ThrowIfNull(primaryMomServer);
            ArgumentNullException.ThrowIfNull(momExportServer);
            ArgumentNullException.ThrowIfNull(tenant);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(missingCountryIdentifier);
            ArgumentNullException.ThrowIfNull(cacheCouchDBEntrySM);

            int _EventID = Int32.MaxValue;
            int exportCount = 0;

            bool skipProcessing = false;        // only true if recursively calling itself

            WhippetResultContainer<Tuple<IEnumerable<MagentoSalesTaxRateSynchronizationRecordDataModel>, IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel>>> result = null;

            WhippetResultContainer<IEnumerable<ITaxRate>> magentoTaxRates = null;
            WhippetResultContainer<IEnumerable<ITaxRule>> magentoTaxRules = null;
            WhippetResultContainer<IEnumerable<ITaxClass>> magentoTaxClasses = null;
            WhippetResultContainer<IEnumerable<ICountry>> magentoCountries = null;
            WhippetResultContainer<IEnumerable<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> magentoCacheEntries = null;
            WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache> magentoDeletedCache = null;

            WhippetResultContainer<long> magentoCacheEntriesDeleteOperation = null;
            WhippetResultContainer<int> magentoCacheCouchDBEntriesDeleteOperation = null;

            WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>> momTaxRates = null;
            WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCountry>> momCountries = null;
            WhippetResultContainer<IEnumerable<IMultichannelOrderManagerStateProvince>> momStates = null;
            WhippetResultContainer<IEnumerable<IMultichannelOrderManagerPostalCode>> momPostalCodes = null;
            WhippetResultContainer<IEnumerable<IMultichannelOrderManagerCounty>> momCounties = null;
            WhippetResultContainer<IEnumerable<IMultichannelOrderManagerWarehouse>> momWarehouses = null;

            ConcurrentBag<MultichannelOrderManagerFlattenedTaxRateExport> cachedExportModels = null;
            ConcurrentBag<MagentoSalesTaxRateSynchronizationRecordDataModel> rateViewModels = null;
            ConcurrentBag<MagentoSalesTaxRateSynchronizationRecordDataModel> missingRateViewModels = null;
            ConcurrentBag<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel> taxCacheEntryModels = null;

            ConcurrentDictionary<ICountry, IEnumerable<MagentoSalesTaxRateSynchronizationRecordDataModel>> rateFixUpViewModels = null;

            AsyncCollection<MultichannelOrderManagerFlattenedTaxRateExport> asyncCachedExportModels = null;
            AsyncCollection<MagentoSalesTaxRateSynchronizationRecordDataModel> asyncRateViewModels = null;
            AsyncCollection<MagentoSalesTaxRateSynchronizationRecordDataModel> asyncMissingRateViewModels = null;
            AsyncCollection<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel> asyncTaxCacheEntryModels = null;

            MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache taxCache = null;

            ParallelOptions pOptions = null;

            Func<MultichannelOrderManagerFlattenedTaxRateExport, IEnumerable<ICountry>, Region> regionFactory = (momRate, magentoCountries) =>
            {
                Region region = null;
                ICountry country = null;

                if ((momRate.Country != null) && (momRate.Country != null) && !String.IsNullOrWhiteSpace(momRate.Country.ISO2) && (magentoCountries != null) && magentoCountries.Any())
                {
                    region = new Region();

                    country = (
                        from magentoCountry in magentoCountries
                        where !String.IsNullOrWhiteSpace(magentoCountry.ISO2)
                            && String.Equals(magentoCountry.ISO2, momRate.Country.ISO2.Trim(), StringComparison.InvariantCultureIgnoreCase)
                        select magentoCountry
                    ).FirstOrDefault();

                    if (country != null)
                    {
                        //region.Country = country.ToCountry();

                        if ((momRate.StateProvince != null) && !String.IsNullOrWhiteSpace(momRate.StateProvince.Abbreviation))
                        {
                            region.ID = (from availableRegion in country.AvailableRegions where String.Equals(availableRegion.Code, momRate.StateProvince.Abbreviation.Trim(), StringComparison.InvariantCultureIgnoreCase) select availableRegion.ID).FirstOrDefault();

                            if (region.ID > 0)
                            {
                                region.Code = momRate.StateProvince.Abbreviation.Trim().ToUpperInvariant();
                                region.Name = momRate.StateProvince.Abbreviation.Trim().ToUpperInvariant();
                            }
                        }
                        else
                        {
                            region.Code = "*";
                        }
                    }
                }

                return region;
            };

            Func<string, string, Task<WhippetResultContainer<IMultichannelOrderManagerCounty>>> countyLocatorFactory = async (countyCode, stateAbbreviation) =>
            {
                if (String.IsNullOrWhiteSpace(countyCode))
                {
                    throw new ArgumentNullException(nameof(countyCode));
                }
                else if (String.IsNullOrWhiteSpace(stateAbbreviation))
                {
                    throw new ArgumentNullException(nameof(stateAbbreviation));
                }
                else
                {
                    return await momCountySM.GetCountyByCode(countyCode.Trim(), stateAbbreviation.Trim());
                }
            };

            try
            {
                if (user == null)
                {
                    user = user.CreateNonInteractiveSystemUser();   // if no user, default to SYSTEM
                }

                if (eventId.HasValue)
                {
                    _EventID = eventId.Value;
                }

                pOptions = new ParallelOptions();
                pOptions = pOptions.DetermineOptimalCoreCount();

                // MOM activity - begin /////////////////////////////////////////////////////////////////////////////////////////////

                Logger.LogDebug(new EventId(_EventID, EVENT_TITLE__DATA_LOADING), LOADING_RATES__MOM, user.UserName);

                // check to see if the cache needs to be refreshed

                if (cache.ExpirationDate <= Instant.FromDateTimeUtc(DateTime.UtcNow) || refreshCache)
                {
                    magentoCacheEntriesDeleteOperation = await cacheEntrySM.DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntries(cache);
                    magentoCacheEntriesDeleteOperation.ThrowIfFailed();
                    
                    magentoCacheCouchDBEntriesDeleteOperation = await cacheCouchDBEntrySM.DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesAsync(cache);
                    magentoCacheCouchDBEntriesDeleteOperation.ThrowIfFailed();

                    refreshCache = true;
                }
                
                if (refreshCache)
                {
                    taxCache = new MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache(Guid.NewGuid(), tenant.ToWhippetTenant(), primaryMomServer.ToMultichannelOrderManagerServer(), Instant.FromDateTimeUtc(DateTime.UtcNow), MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache.CalculateExpirationDate(Instant.FromDateTimeUtc(DateTime.UtcNow)));

                    momTaxRates = await momTaxRateSM.GetTaxRates();
                    momTaxRates.ThrowIfFailed();

                    momCountries = await momCountrySM.GetCountries();
                    momCountries.ThrowIfFailed();

                    momCounties = await momCountySM.GetCounties();
                    momCounties.ThrowIfFailed();

                    momPostalCodes = await momPostalCodeSM.GetPostalCodes();
                    momPostalCodes.ThrowIfFailed();

                    momStates = await momStateProvinceSM.GetStateProvinces();
                    momStates.ThrowIfFailed();
                    
                    momStates = await momStateProvinceSM.AssignCountries(momStates.Item, momCountries.Item);
                    momStates.ThrowIfFailed();

                    momWarehouses = await momWarehouseSM.GetWarehouses();
                    momWarehouses.ThrowIfFailed();

                    momCounties = await momCountySM.AssignStatesAndCountries(momCounties.Item, momStates.Item, momCountries.Item);
                    momCounties.ThrowIfFailed();

                    momPostalCodes = await momPostalCodeSM.AssignCountries(momPostalCodes.Item, momCountries.Item);
                    momPostalCodes.ThrowIfFailed();

                    momPostalCodes = await momPostalCodeSM.AssignStates(momPostalCodes.Item, momStates.Item);
                    momPostalCodes.ThrowIfFailed();

                    momPostalCodes = await momPostalCodeSM.AssignCounties(momPostalCodes.Item, momCounties.Item, countyLocatorFactory);
                    momPostalCodes.ThrowIfFailed();

                    momWarehouses = await momWarehouseSM.AssignCountries(momWarehouses.Item, momCountries.Item, momPostalCodes.Item);
                    momWarehouses.ThrowIfFailed();

                    // assign warehouses to everybody for serialization requirements

                    momPostalCodes = await momPostalCodeSM.AssignWarehouses(momPostalCodes.Item, momWarehouses.Item);
                    momPostalCodes.ThrowIfFailed();

                    momCounties = await momCountySM.AssignWarehouses(momCounties.Item, momWarehouses.Item);
                    momCounties.ThrowIfFailed();

                    momStates = await momStateProvinceSM.AssignWarehouses(momStates.Item, momWarehouses.Item);
                    momStates.ThrowIfFailed();

                    momCountries = await momCountrySM.AssignWarehouses(momCountries.Item, momWarehouses.Item);
                    momCountries.ThrowIfFailed();

                    // fix up the postal codes with the new warehouse data

                    Logger.LogInformation(new EventId(_EventID, EVENT_TITLE__DATA_LOADING), LOADED_GEOGRAPHIC__MOM, user.UserName);
                    Logger.LogDebug(new EventId(_EventID, EVENT_TITLE__DATA_LOADING), PROCESSING_GEOGRAPHIC__MOM, user.UserName);

                    momTaxRates = await momTaxRateSM.AssignGeographicData(momTaxRates.Item, momPostalCodes.Item); // somethings screwing up in here
                    momTaxRates.ThrowIfFailed();

                    momTaxRates = await momTaxRateSM.AssignServer(momTaxRates.Item, primaryMomServer, momExportServer);
                    momTaxRates.ThrowIfFailed();

                    // before comparing, we need to fix up MOM exports

                    momTaxRates = await momTaxRateSM.FixUpWarehouses(momTaxRates.Item, momCountries.Item, momStates.Item, momCounties.Item, momPostalCodes.Item, momWarehouses.Item.OrderBy(w => w.WarehouseID).FirstOrDefault());
                    momTaxRates.ThrowIfFailed();

                    momTaxRates = await momTaxRateSM.FixUpMissingCountryData(momTaxRates.Item, momCountries.Item, momStates.Item, momCounties.Item, momPostalCodes.Item, MultichannelOrderManagerCountry.DefaultCountry);
                    momTaxRates.ThrowIfFailed();

                    momTaxRates = await momTaxRateSM.FixUpMissingCityData(momTaxRates.Item, momPostalCodeSM, postalCodeSM);
                    momTaxRates.ThrowIfFailed();

                    momTaxRates = await momTaxRateSM.FixUpMissingCountyData(momTaxRates.Item, momPostalCodeSM, momCountySM);
                    momTaxRates.ThrowIfFailed();

                    momTaxRates = await momTaxRateSM.FixUpMissingStateData(momTaxRates.Item, momStateProvinceSM);
                    momTaxRates.ThrowIfFailed();
                    
                    // fix up state/province names

                    //momStates = await momStateProvinceSM.FixUpMissingStateProvinceCodes(momStates.Item);
                    //momStates.ThrowIfFailed();
                    
                    // now add the results to the cache

                    if (momTaxRates.HasItem && momTaxRates.Item.Any())
                    {
                        if (!momTaxRates.Item.TryGetNonEnumeratedCount(out exportCount))
                        {
                            exportCount = momTaxRates.Item.Count();
                        }

                        taxCacheEntryModels = new ConcurrentBag<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel>();
                        asyncTaxCacheEntryModels = new AsyncCollection<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel>(taxCacheEntryModels, exportCount);

                        await Parallel.ForEachAsync<MultichannelOrderManagerFlattenedTaxRateExport>(momTaxRates.Item, pOptions, async (export, cancellationToken) =>
                        {
                            MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry entry = new MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry(Guid.NewGuid(), taxCache, export, Instant.FromDateTimeUtc(DateTime.UtcNow));

                            await asyncTaxCacheEntryModels.AddAsync(new MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel(entry));
                        });

                        skipProcessing = true;

                        result = new WhippetResultContainer<Tuple<IEnumerable<MagentoSalesTaxRateSynchronizationRecordDataModel>, IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel>>>(
                            WhippetResult.Success,
                            new Tuple<IEnumerable<MagentoSalesTaxRateSynchronizationRecordDataModel>, IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel>>(
                                    Enumerable.Empty<MagentoSalesTaxRateSynchronizationRecordDataModel>(),
                                    taxCacheEntryModels
                                )
                            );
                    }
                }
                else
                {
                    magentoCacheEntries = await cacheEntrySM.GetEntries(cache);
                    magentoCacheEntries.ThrowIfFailed();

                    if (magentoCacheEntries.HasItem && magentoCacheEntries.Item.Any())
                    {
                        if (!magentoCacheEntries.Item.TryGetNonEnumeratedCount(out exportCount))
                        {
                            exportCount = magentoCacheEntries.Item.Count();
                        }

                        cachedExportModels = new ConcurrentBag<MultichannelOrderManagerFlattenedTaxRateExport>();
                        asyncCachedExportModels = new AsyncCollection<MultichannelOrderManagerFlattenedTaxRateExport>(cachedExportModels, exportCount);

                        await Parallel.ForEachAsync<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(magentoCacheEntries.Item, pOptions, async (cachedExport, cancellationToken) =>
                        {
                            await asyncCachedExportModels.AddAsync(cachedExport.ToTaxRateExport());
                        });

                        momTaxRates = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(WhippetResult.Success, cachedExportModels);
                    }
                    else
                    {
                        // if for some reason we don't have entries, refresh the cache by recursively calling it and passing true for refresh option

                        result = await GetMagentoTaxRatesToUpdate(
                            magentoServer,
                            magentoExemptTaxRateCode,
                            preserveMagentoExemptTaxRates,
                            momTaxRateSM,
                            momCountrySM,
                            momStateProvinceSM,
                            momPostalCodeSM,
                            momCountySM,
                            momWarehouseSM,
                            postalCodeSM,
                            cache,
                            cacheEntrySM,
                            cacheCouchDBEntrySM,
                            primaryMomServer,
                            momExportServer,
                            tenant,
                            missingCountryIdentifier,
                            user,
                            eventId,
                            true
                        );

                        skipProcessing = true;
                    }
                }

                // MOM activity - end /////////////////////////////////////////////////////////////////////////////////////////////

                if (!skipProcessing)
                {
                    Logger.LogDebug(new EventId(_EventID, EVENT_TITLE__DATA_LOADING), LOADING_RATES__MAGENTO, user.UserName);
                    magentoTaxRates = await MagentoTaxRateManager.GetTaxRates();
                    magentoTaxRates.ThrowIfFailed();
                    Logger.LogInformation(new EventId(_EventID, EVENT_TITLE__DATA_LOADING), LOADED_RATES__MAGENTO, user.UserName);


                    Logger.LogDebug(new EventId(_EventID, EVENT_TITLE__DATA_LOADING), LOADING_RULES__MAGENTO, user.UserName);

                    magentoTaxRules = await MagentoTaxRuleServiceManager.GetTaxRules();
                    magentoTaxRules.ThrowIfFailed();

                    Logger.LogInformation(new EventId(_EventID, EVENT_TITLE__DATA_LOADING), LOADED_RULES__MAGENTO, user.UserName);
                    Logger.LogDebug(new EventId(_EventID, EVENT_TITLE__DATA_LOADING), LOADING_CLASSES__MAGENTO, user.UserName);

                    magentoTaxClasses = await MagentoTaxClassServiceManager.GetTaxClasses();
                    magentoTaxClasses.ThrowIfFailed();

                    Logger.LogInformation(new EventId(_EventID, EVENT_TITLE__DATA_LOADING), LOADED_CLASSES__MAGENTO, user.UserName);
                    Logger.LogDebug(new EventId(_EventID, EVENT_TITLE__DATA_LOADING), LOADING_GEOGRAPHIC__MOM, user.UserName);

                    magentoCountries = await MagentoCountryServiceManager.GetCountries();
                    magentoCountries.ThrowIfFailed();

                    // we now have all data loaded from both sources, start comparing

                    rateViewModels = new ConcurrentBag<MagentoSalesTaxRateSynchronizationRecordDataModel>();
                    missingRateViewModels = new ConcurrentBag<MagentoSalesTaxRateSynchronizationRecordDataModel>();

                    rateFixUpViewModels = new ConcurrentDictionary<ICountry, IEnumerable<MagentoSalesTaxRateSynchronizationRecordDataModel>>();

                    asyncRateViewModels = new AsyncCollection<MagentoSalesTaxRateSynchronizationRecordDataModel>(rateViewModels);
                    asyncMissingRateViewModels = new AsyncCollection<MagentoSalesTaxRateSynchronizationRecordDataModel>(missingRateViewModels);

                    if ((magentoTaxRates.Item == null) || (magentoTaxRates.Item != null && !magentoTaxRates.Item.Any()) || !magentoTaxClasses.HasItem)
                    {
                        // there are no magento tax rates present, so import all the MOM rates

                        await Parallel.ForEachAsync<MultichannelOrderManagerFlattenedTaxRateExport>(momTaxRates.Item, pOptions, async (momRate, cancellationToken) =>
                        {
                            Region region = new Region();
                            ITaxRate rate = new TaxRate();

                            MagentoSalesTaxRateSynchronizationRecordDataModel syncViewModel = null;

                            StringBuilder codeBuilder = new StringBuilder();

                            // code = US-CA-*-Rate 1

                            if (momRate.Country != null && !String.IsNullOrWhiteSpace(momRate.Country.ISO2))
                            {
                                // rate.BuildCode(
                                //     momRate.Country.ISO2,
                                //     momRate.StateProvince != null && !String.IsNullOrWhiteSpace(momRate.StateProvince.Abbreviation) ? momRate.StateProvince.Abbreviation : null,
                                //     momRate.PostalCode != null && !String.IsNullOrWhiteSpace(momRate.PostalCode.PostalCode) ? momRate.PostalCode.PostalCode : null
                                // );
                            }
                            else
                            {
                                codeBuilder.Append(missingCountryIdentifier + Guid.NewGuid().ToString("N"));
                            }

                            if (String.IsNullOrWhiteSpace(rate.Code))
                            {
                                rate.Code = codeBuilder.ToString();
                            }

                            // build Region

                            region = regionFactory(momRate, magentoCountries.Item);

                            // if we cannot build the region, then skip

                            if (region != null)
                            {
                                rate.Server = magentoServer;
                                rate.Region = region;
                                // rate.Country = region.Country;
                                // rate.CountryID = region.CountryID;
                                rate.PostalCode = ((momRate.PostalCode == null) || String.IsNullOrWhiteSpace(momRate.PostalCode.PostalCode)) ? "*" : momRate.PostalCode.PostalCode.Trim();
                                rate.Rate = momRate.TaxRate;

                                syncViewModel = new MagentoSalesTaxRateSynchronizationRecordDataModel(rate, magentoServer.ID);

                                //Logger.LogDebug(new EventId(_EventID, EVENT_TITLE__TAX_IMPORT), EVENT_MISSING, rate.CountryID, rate.Region.Code, rate.PostalCode, user.UserName);

                                await asyncRateViewModels.AddAsync(syncViewModel);
                            }
                        });
                    }
                    else
                    {
                        await Parallel.ForEachAsync<ITaxRate>(magentoTaxRates.Item, pOptions, async (magentoRate, cancellationToken) =>
                        {
                            IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport> matchingMomRates = null;

                            MagentoSalesTaxRateSynchronizationRecordDataModel syncViewModel = null;

                            int count = 0;

                            // if the code is an exempt tax rate but do not preserve magento exempt rates
                            // - or -
                            // if the code is not an exempt tax rate

                            if (String.IsNullOrWhiteSpace(magentoRate.Code) || (String.Equals(magentoRate.Code?.Trim(), magentoExemptTaxRateCode.Trim(), StringComparison.InvariantCultureIgnoreCase) && !preserveMagentoExemptTaxRates) || !String.Equals(magentoRate.Code?.Trim(), magentoExemptTaxRateCode.Trim(), StringComparison.InvariantCultureIgnoreCase))
                            {
                                // Note from Adam (8/28/23):
                                //
                                // Don't parallelize this as it just causes more overhead and slows the query down

                                // check country first

                                matchingMomRates =
                                    from sourceTaxRate in momTaxRates.Item
                                    where (sourceTaxRate.Country != null)
                                        && !String.IsNullOrWhiteSpace(sourceTaxRate.Country.ISO2)
                                        //&& !String.IsNullOrWhiteSpace(magentoRate.CountryID)
                                        //&& String.Equals(sourceTaxRate.Country?.ISO2?.Trim(), magentoRate.CountryID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                    select sourceTaxRate;

                                if (matchingMomRates.Any())
                                {
                                    // do we have a region?

                                    if (magentoRate.Region != null && !String.IsNullOrWhiteSpace(magentoRate.Region.Code))
                                    {
                                        // matchingMomRates =
                                        //     from sourceTaxRate in matchingMomRates
                                        //     where String.Equals(sourceTaxRate.Country?.ISO2?.Trim(), magentoRate.CountryID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                        //         && (sourceTaxRate.StateProvince != null)
                                        //         && !String.IsNullOrWhiteSpace(sourceTaxRate.StateProvince.Abbreviation)
                                        //         && String.Equals(sourceTaxRate.StateProvince.Abbreviation.Trim(), magentoRate.Region.Code.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                        //     select sourceTaxRate;

                                        if (matchingMomRates.Any())
                                        {
                                            if (String.Equals(magentoRate.PostalCode, "*", StringComparison.InvariantCultureIgnoreCase))
                                            {
                                                // rate applies to all postal codes in region... we need to see if there are any specific postal codes from MOM. If there is, delete this rate and the new ones will be picked up later

                                                // matchingMomRates =
                                                //     from sourceTaxRate in matchingMomRates
                                                //     where String.Equals(sourceTaxRate.Country?.ISO2?.Trim(), magentoRate.CountryID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                                //         && String.Equals(sourceTaxRate.StateProvince.Abbreviation.Trim(), magentoRate.Region.Code.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                                //         && (sourceTaxRate.PostalCode != null)
                                                //         && !String.IsNullOrWhiteSpace(sourceTaxRate.PostalCode.PostalCode)
                                                //     select sourceTaxRate;

                                                if (matchingMomRates.Any())
                                                {
                                                    if (!matchingMomRates.TryGetNonEnumeratedCount(out count))
                                                    {
                                                        count = matchingMomRates.Count();
                                                    }

                                                    if (count > 1)
                                                    {
                                                        Logger.LogDebug(new EventId(_EventID, EVENT_TITLE__TAX_IMPORT), EVENT_DELETE, magentoRate.ID, user.UserName);
                                                        syncViewModel = new MagentoSalesTaxRateSynchronizationRecordDataModel(magentoRate, magentoServer.ID, true);
                                                    }
                                                    else if (!matchingMomRates.ElementAt(0).TaxRate.Equals(magentoRate.Rate) || String.Equals(magentoRate.PostalCode, "*", StringComparison.InvariantCultureIgnoreCase))
                                                    {
                                                        //Logger.LogDebug(new EventId(_EventID, EVENT_TITLE__TAX_IMPORT), EVENT_UPDATE, magentoRate.CountryID, (magentoRate.Region == null || String.IsNullOrWhiteSpace(magentoRate.Region.Code)) ? "*" : magentoRate.Region.Code, magentoRate.PostalCode, user.UserName);

                                                        magentoRate.PostalCode = matchingMomRates.ElementAt(0).PostalCode.PostalCode;
                                                        syncViewModel = new MagentoSalesTaxRateSynchronizationRecordDataModel(magentoRate, magentoServer.ID);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                // search for MOM rates via postal code

                                                // matchingMomRates =
                                                //     from sourceTaxRate in matchingMomRates
                                                //     where String.Equals(sourceTaxRate.Country?.ISO2?.Trim(), magentoRate.CountryID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                                //         && String.Equals(sourceTaxRate.StateProvince.Abbreviation.Trim(), magentoRate.Region.Code.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                                //         && (sourceTaxRate.PostalCode != null)
                                                //         && !String.IsNullOrWhiteSpace(sourceTaxRate.PostalCode.PostalCode)
                                                //         && String.Equals(sourceTaxRate.PostalCode.PostalCode.Trim(), magentoRate.PostalCode, StringComparison.InvariantCultureIgnoreCase)
                                                //     select sourceTaxRate;

                                                if (matchingMomRates.Any())
                                                {
                                                    if (!matchingMomRates.ElementAt(0).TaxRate.Equals(magentoRate.Rate))
                                                    {
                                                        //Logger.LogDebug(new EventId(_EventID, EVENT_TITLE__TAX_IMPORT), EVENT_UPDATE, magentoRate.CountryID, (magentoRate.Region == null || String.IsNullOrWhiteSpace(magentoRate.Region.Code)) ? "*" : magentoRate.Region.Code, magentoRate.PostalCode, user.UserName);

                                                        magentoRate.Rate = matchingMomRates.ElementAt(0).TaxRate;
                                                        syncViewModel = new MagentoSalesTaxRateSynchronizationRecordDataModel(magentoRate, magentoServer.ID);
                                                    }
                                                }
                                                else
                                                {
                                                    Logger.LogDebug(new EventId(_EventID, EVENT_TITLE__TAX_IMPORT), EVENT_DELETE, magentoRate.ID, user.UserName);
                                                    syncViewModel = new MagentoSalesTaxRateSynchronizationRecordDataModel(magentoRate, magentoServer.ID, true);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Logger.LogDebug(new EventId(_EventID, EVENT_TITLE__TAX_IMPORT), EVENT_DELETE, magentoRate.ID, user.UserName);
                                            syncViewModel = new MagentoSalesTaxRateSynchronizationRecordDataModel(magentoRate, magentoServer.ID, true);
                                        }
                                    }
                                    else if (!String.IsNullOrWhiteSpace(magentoRate.PostalCode) && !String.Equals(magentoRate.PostalCode, "*", StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        matchingMomRates =
                                            from sourceTaxRate in matchingMomRates
                                            where (sourceTaxRate.PostalCode != null)
                                                && !String.IsNullOrWhiteSpace(sourceTaxRate.PostalCode.PostalCode)
                                                && String.Equals(sourceTaxRate.PostalCode.PostalCode.Trim(), magentoRate.PostalCode.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                            select sourceTaxRate;

                                        if (matchingMomRates.Any())
                                        {
                                            if (!matchingMomRates.ElementAt(0).TaxRate.Equals(magentoRate.Rate))
                                            {
                                                //Logger.LogDebug(new EventId(_EventID, EVENT_TITLE__TAX_IMPORT), EVENT_UPDATE, magentoRate.CountryID, (magentoRate.Region == null || String.IsNullOrWhiteSpace(magentoRate.Region.Code)) ? "*" : magentoRate.Region.Code, magentoRate.PostalCode, user.UserName);

                                                syncViewModel = new MagentoSalesTaxRateSynchronizationRecordDataModel(magentoRate, magentoServer.ID);
                                            }
                                        }
                                        else
                                        {
                                            Logger.LogDebug(new EventId(_EventID, EVENT_TITLE__TAX_IMPORT), EVENT_DELETE, magentoRate.ID, user.UserName);
                                            syncViewModel = new MagentoSalesTaxRateSynchronizationRecordDataModel(magentoRate, magentoServer.ID, true);
                                        }
                                    }
                                    else
                                    {
                                        Logger.LogDebug(new EventId(_EventID, EVENT_TITLE__TAX_IMPORT), EVENT_DELETE, magentoRate.ID, user.UserName);
                                        syncViewModel = new MagentoSalesTaxRateSynchronizationRecordDataModel(magentoRate, magentoServer.ID, true);
                                    }
                                }
                                else
                                {
                                    // couldn't filter by country, which is required, so delete it

                                    Logger.LogDebug(new EventId(_EventID, EVENT_TITLE__TAX_IMPORT), EVENT_DELETE, magentoRate.ID, user.UserName);
                                    syncViewModel = new MagentoSalesTaxRateSynchronizationRecordDataModel(magentoRate, magentoServer.ID, true);
                                }

                                // if (syncViewModel != null && syncViewModel.CreateOrUpdateRate && ((syncViewModel.Rate.RegionID == 0 || String.IsNullOrWhiteSpace(syncViewModel.Rate.Region.Code)) || String.IsNullOrWhiteSpace(syncViewModel.Rate.PostalCode)))
                                // {
                                //     // couldn't find the region, which is required, so delete it
                                //
                                //     syncViewModel.DeleteRate = true;
                                // }

                                await asyncRateViewModels.AddAsync(syncViewModel);
                            }
                        });

                        await Parallel.ForEachAsync<MultichannelOrderManagerFlattenedTaxRateExport>(momTaxRates.Item, pOptions, async (momRate, cancellationToken) =>
                        {
                            IEnumerable<MagentoSalesTaxRateSynchronizationRecordDataModel> filterMatches = null;
                            ITaxRate rate = new TaxRate();
                            Region region = null;

                            MagentoSalesTaxRateSynchronizationRecordDataModel syncViewModel = null;

                            region = regionFactory(momRate, magentoCountries.Item);

                            // only add the rate if it has a region; otherwise, skip it

                            if (region != null)
                            {
                                rate.Region = region;

                                syncViewModel = new MagentoSalesTaxRateSynchronizationRecordDataModel(rate, magentoServer.ID);

                                // we have to check specific fields manually as the Equals(...) method does a deep compare and will return FALSE

                                // determine which route to take!

                                //if (!String.IsNullOrWhiteSpace(rate.CountryID))         // we have a country
                                if (true)
                                {
                                    // filterMatches =
                                    //     from r in rateViewModels
                                    //     where String.Equals(r.Rate.CountryID, rate.CountryID, StringComparison.InvariantCultureIgnoreCase)
                                    //         && (String.Equals(r.Rate.Code?.Trim(), magentoExemptTaxRateCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                    //             && !preserveMagentoExemptTaxRates) || !String.Equals(rate.Code?.Trim(), magentoExemptTaxRateCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                    //     select r;

                                    if (!filterMatches.Any())
                                    {
                                        await asyncMissingRateViewModels.AddAsync(syncViewModel);
                                    }
                                    else
                                    {
                                        // filter by region?

                                        if (!String.IsNullOrWhiteSpace(rate.Region.Code))
                                        {
                                            filterMatches =
                                                from r in rateViewModels
                                                where String.Equals(r.Rate.Region.Code, rate.Region.Code, StringComparison.InvariantCultureIgnoreCase)
                                                    && (String.Equals(r.Rate.Code?.Trim(), magentoExemptTaxRateCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                                        && !preserveMagentoExemptTaxRates) || !String.Equals(rate.Code?.Trim(), magentoExemptTaxRateCode.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                                select r;

                                            if ((!filterMatches.Any() && !String.IsNullOrWhiteSpace(rate.PostalCode)) || filterMatches.Any())
                                            {
                                                // no matches in the filter but we have a postal code -OR- we have matches on the region so we need to filter by postal code

                                                if (!String.IsNullOrWhiteSpace(rate.PostalCode))
                                                {
                                                    filterMatches =
                                                        from r in rateViewModels
                                                        where String.Equals(r.Rate.PostalCode, rate.PostalCode, StringComparison.InvariantCultureIgnoreCase)
                                                            && (String.Equals(r.Rate.Code?.Trim(), magentoExemptTaxRateCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                                            && !preserveMagentoExemptTaxRates) || !String.Equals(rate.Code?.Trim(), magentoExemptTaxRateCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                                        select r;

                                                    if (!filterMatches.Any())
                                                    {
                                                        await asyncMissingRateViewModels.AddAsync(syncViewModel);
                                                    }
                                                }
                                                else
                                                {
                                                    await asyncMissingRateViewModels.AddAsync(syncViewModel);
                                                }
                                            }
                                            else if (!filterMatches.Any() && String.IsNullOrWhiteSpace(rate.PostalCode))
                                            {
                                                // no matches in the filter and no postal code

                                                await asyncMissingRateViewModels.AddAsync(syncViewModel);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    // filter by region?

                                    if (!String.IsNullOrWhiteSpace(rate.Region.Code))
                                    {
                                        filterMatches =
                                            from r in rateViewModels
                                            where String.Equals(r.Rate.Region.Code, rate.Region.Code, StringComparison.InvariantCultureIgnoreCase)
                                                && (String.Equals(r.Rate.Code?.Trim(), magentoExemptTaxRateCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                                    && !preserveMagentoExemptTaxRates) || !String.Equals(rate.Code?.Trim(), magentoExemptTaxRateCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                            select r;

                                        if ((!filterMatches.Any() && !String.IsNullOrWhiteSpace(rate.PostalCode)) || filterMatches.Any())
                                        {
                                            // no matches in the filter but we have a postal code -OR- we have matches on the region so we need to filter by postal code

                                            if (!String.IsNullOrWhiteSpace(rate.PostalCode))
                                            {
                                                filterMatches =
                                                    from r in rateViewModels
                                                    where String.Equals(r.Rate.PostalCode, rate.PostalCode, StringComparison.InvariantCultureIgnoreCase)
                                                        && (String.Equals(r.Rate.Code?.Trim(), magentoExemptTaxRateCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                                            && !preserveMagentoExemptTaxRates) || !String.Equals(rate.Code?.Trim(), magentoExemptTaxRateCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                                    select r;

                                                if (!filterMatches.Any())
                                                {
                                                    await asyncMissingRateViewModels.AddAsync(syncViewModel);
                                                }
                                            }
                                            else
                                            {
                                                await asyncMissingRateViewModels.AddAsync(syncViewModel);
                                            }
                                        }
                                        else if (!filterMatches.Any() && String.IsNullOrWhiteSpace(rate.PostalCode))
                                        {
                                            // no matches in the filter and no postal code

                                            await asyncMissingRateViewModels.AddAsync(syncViewModel);
                                        }
                                    }
                                    else
                                    {
                                        if (!String.IsNullOrWhiteSpace(rate.PostalCode))
                                        {
                                            // no matches in the filter but we have a postal code -OR- we have matches on the region so we need to filter by postal code

                                            filterMatches =
                                                from r in rateViewModels
                                                where String.Equals(r.Rate.PostalCode, rate.PostalCode, StringComparison.InvariantCultureIgnoreCase)
                                                    && (String.Equals(r.Rate.Code?.Trim(), magentoExemptTaxRateCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                                        && !preserveMagentoExemptTaxRates) || !String.Equals(rate.Code?.Trim(), magentoExemptTaxRateCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                                select r;

                                            if (!filterMatches.Any())
                                            {
                                                await asyncMissingRateViewModels.AddAsync(syncViewModel);
                                            }
                                        }
                                        else
                                        {
                                            await asyncMissingRateViewModels.AddAsync(syncViewModel);
                                        }
                                    }
                                }
                            }
                        });

                        if (missingRateViewModels.Any())
                        {
                            rateViewModels.AddRange(missingRateViewModels);
                        }

                        Logger.LogInformation(new EventId(_EventID, EVENT_TITLE__TAX_IMPORT), "{User} has completed a sales tax import from Multichannel Order Manager at {Timestamp} server time.", user.UserName, DateTime.Now.ToString());

                        result = new WhippetResultContainer<Tuple<IEnumerable<MagentoSalesTaxRateSynchronizationRecordDataModel>, IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel>>>(
                            WhippetResult.Success,
                            new Tuple<IEnumerable<MagentoSalesTaxRateSynchronizationRecordDataModel>, IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel>>(
                                    rateViewModels,
                                    Enumerable.Empty<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel>()
                            )
                        );
                    }
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<Tuple<IEnumerable<MagentoSalesTaxRateSynchronizationRecordDataModel>, IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel>>>(e);
                Logger.LogError(new EventId(_EventID, "Magento Sales Tax Import"), e, "Sales tax import from Multichannel Order Manager requested by {User} has failed at {Timestamp} server time.", user.UserName, DateTime.Now.ToString());
            }

            if (result.IsSuccess && !skipProcessing)
            {
                // for some reason, there's a bug here where the export server is not being assigned correctly. This janky hack fixes that...   --ATH 10/19/23

                pOptions = pOptions.DetermineOptimalCoreCount();

                Parallel.ForEach(result.Item.Item2, pOptions, (export, cancellationToken) =>
                {
                    export.MultichannelOrderManagerSourceServer = momExportServer;
                });

                // now assign the cache

                result = await AssignCache(cache, result.Item);
            }

            return result;
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();

            if (MagentoServerManager != null)
            {
                MagentoServerManager.Dispose();
                MagentoServerManager = null;
            }

            if (MagentoTaxRateManager != null)
            {
                MagentoTaxRateManager.Dispose();
                MagentoTaxRateManager = null;
            }

            if (MagentoTaxRuleServiceManager != null)
            {
                MagentoTaxRuleServiceManager.Dispose();
                MagentoTaxRuleServiceManager = null;
            }

            if (MagentoTaxClassServiceManager != null)
            {
                MagentoTaxClassServiceManager.Dispose();
                MagentoTaxClassServiceManager = null;
            }
        }
    }
}
