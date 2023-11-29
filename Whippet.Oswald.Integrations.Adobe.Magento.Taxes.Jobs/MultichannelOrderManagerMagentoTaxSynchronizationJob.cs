using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Nito.AsyncEx;
using Nito.AsyncEx.Synchronous;
using Athi.Whippet.Data.Extensions;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Data;
using Athi.Whippet.Jobs;
using Athi.Whippet.Adobe.Magento;
using Athi.Whippet.Adobe.Magento.ServiceManagers;
using Athi.Whippet.Adobe.Magento.Taxes;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers;
using Athi.Whippet.Adobe.Magento.Directory;
using Athi.Whippet.Adobe.Magento.Directory.ServiceManagers;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Exports.ServiceManagers;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.ServiceManagers;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Models;
using PostalCodeServiceManager = Athi.Whippet.Localization.Addressing.ServiceManagers.PostalCodeServiceManager;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Models;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs
{
    /// <summary>
    /// Job that synchronizes tax rates and rules between Multichannel Order Manager and Magento.
    /// </summary>
    public class MultichannelOrderManagerMagentoTaxSynchronizationJob : JobBase, IJob, IWhippetEntity, ICloneable, IWhippetCloneable
    {
        private const string ENGLISH_NAME = "Multichannel Order Manager Tax Synchronization";
        private const string ENGLISH_DESC = "Synchronizes the tax rates and rules from a Multichannel Order Manager instance with Magento.";

        private readonly AsyncLock _Mutex = new AsyncLock();

        /// <summary>
        /// Gets a standard ID for the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> that identifies the job across tenants. This property is read-only.
        /// </summary>
        public override Guid FixedJobID
        {
            get
            {
                return new Guid("0ee0be41-28b8-42a6-985a-2cddac6e7ac8");
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Func{T, TResult}"/> that loads an <see cref="IMultichannelOrderManagerServer"/> based on the server's unique identifier.
        /// </summary>
        public virtual Func<Guid, WhippetResultContainer<IMultichannelOrderManagerServer>> MultichannelOrderManagerServerDelegate
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Func{T1, T2, TResult}"/> that loads an <see cref="IMagentoServer"/> based on the server's unique identifier.
        /// </summary>
        public virtual Func<MagentoServerServiceManager, Guid, WhippetResultContainer<IMagentoServer>> MagentoServerDelegate
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Func{TResult}"/> that loads a <see cref="MagentoServerServiceManager"/>.
        /// </summary>
        public virtual Func<WhippetResultContainer<MagentoServerServiceManager>> MagentoServerServiceManagerDelegate
        { get; set; }

        /// <summary>
        /// Gets or setse the <see cref="Func{T, TResult}"/> that loads a <see cref="MagentoRestClient"/> based on the specified <see cref="IMagentoServer"/>.
        /// </summary>
        public virtual Func<IMagentoServer, WhippetResultContainer<Tuple<MagentoRestClient, string>>> MagentoRestClientDelegate
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Func{T, TResult}"/> that loads a <see cref="TaxRateServiceManager"/> based on the specified <see cref="MagentoRestClient"/>.
        /// </summary>
        public virtual Func<Tuple<MagentoRestClient, string>, WhippetResultContainer<TaxRateServiceManager>> MagentoTaxRateServiceManagerDelegate
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Func{T, TResult}"/> that loads a <see cref="TaxRuleServiceManager"/> based on the specified <see cref="MagentoRestClient"/>.
        /// </summary>
        public virtual Func<Tuple<MagentoRestClient, string>, WhippetResultContainer<TaxRuleServiceManager>> MagentoTaxRuleServiceManagerDelegate
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Func{T, TResult}"/> that loads a <see cref="TaxClassServiceManager"/> based on the specified <see cref="MagentoRestClient"/>.
        /// </summary>
        public virtual Func<Tuple<MagentoRestClient, string>, WhippetResultContainer<TaxClassServiceManager>> MagentoTaxClassServiceManagerDelegate
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Func{T, TResult}"/> that loads a <see cref="CountryServiceManager"/> based on the specified <see cref="MagentoRestClient"/>.
        /// </summary>
        public virtual Func<Tuple<MagentoRestClient, string>, WhippetResultContainer<CountryServiceManager>> MagentoCountryServiceManagerDelegate
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Func{T1, T2, T3, T4, T5, TResult}"/> that loads a <see cref="MagentoTaxSynchronizationServiceManager"/> based on the specified parameters.
        /// </summary>
        public virtual Func<MagentoServerServiceManager, TaxRateServiceManager, TaxRuleServiceManager, TaxClassServiceManager, CountryServiceManager, WhippetResultContainer<MagentoTaxSynchronizationServiceManager>> MagentoTaxSynchronizationServiceManagerDelegate
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Func{T1, T2, TResult}"/> that loads a <see cref="MultichannelOrderManagerFlattenedTaxRateExportServiceManager"/> based on the specified parameters.
        /// </summary>
        public virtual Func<string, string, WhippetResultContainer<MultichannelOrderManagerFlattenedTaxRateExportServiceManager>> MultichannelOrderManagerFlattenedTaxRateExportServiceManagerDelegate
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Func{T1, TResult}"/> that loads a <see cref="MultichannelOrderManagerCountryServiceManager"/> based on the specified parameters.
        /// </summary>
        public virtual Func<string, WhippetResultContainer<MultichannelOrderManagerCountryServiceManager>> MultichannelOrderManagerCountryServiceManagerDelegate
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Func{T1, TResult}"/> that loads a <see cref="MultichannelOrderManagerStateProvinceServiceManager"/> based on the specified parameters.
        /// </summary>
        public virtual Func<string, WhippetResultContainer<MultichannelOrderManagerStateProvinceServiceManager>> MultichannelOrderManagerStateProvinceServiceManagerDelegate
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Func{T1, TResult}"/> that loads a <see cref="MultichannelOrderManagerPostalCodeServiceManager"/> based on the specified parameters.
        /// </summary>
        public virtual Func<string, WhippetResultContainer<MultichannelOrderManagerPostalCodeServiceManager>> MultichannelOrderManagerPostalCodeServiceManagerDelegate
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Func{T, TResult}"/> that loads a <see cref="PostalCodeServiceManager"/> based on the specified parameters.
        /// </summary>
        public virtual Func<string, WhippetResultContainer<PostalCodeServiceManager>> PostalCodeServiceManagerDelegate
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerMagentoTaxSynchronizationJob()
            : base(Guid.Empty, ENGLISH_NAME, ENGLISH_DESC, null, null, default(bool), new MagentoTaxSynchronizationJobCategory())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobBase"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="schedule">Job's cron schedule.</param>
        /// <param name="active">Specifies whether the job is currently active and running.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> that the job is registered with.</param>
        /// <param name="logger"><see cref="ILogger"/> used to log the job activity or <see langword="null"/> to use no logger.</param>
        public MultichannelOrderManagerMagentoTaxSynchronizationJob(Guid id, CronTabSchedule schedule, WhippetTenant tenant, bool active, ILogger logger)
            : base(id, ENGLISH_NAME, ENGLISH_DESC, schedule, active, tenant, new MagentoTaxSynchronizationJobCategory(), logger)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobBase"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="schedule">Job's cron schedule.</param>
        /// <param name="active">Specifies whether the job is currently active and running.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> that the job is registered with.</param>
        /// <param name="localizedCategory">Localized <see cref="MagentoTaxSynchronizationJobCategory"/> object.</param>
        /// <param name="logger"><see cref="ILogger"/> used to log the job activity or <see langword="null"/> to use no logger.</param>
        public MultichannelOrderManagerMagentoTaxSynchronizationJob(Guid id, CronTabSchedule schedule, WhippetTenant tenant, bool active, MagentoTaxSynchronizationJobCategory localizedCategory, ILogger logger)
            : this(id, ENGLISH_NAME, ENGLISH_DESC, schedule, tenant, active, localizedCategory, logger)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobBase"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="jobName">Name of the job.</param>
        /// <param name="jobDescription">Job description.</param>
        /// <param name="schedule">Job's cron schedule.</param>
        /// <param name="active">Specifies whether the job is currently active and running.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> that the job is registered with.</param>
        /// <param name="logger"><see cref="ILogger"/> used to log the job activity or <see langword="null"/> to use no logger.</param>
        public MultichannelOrderManagerMagentoTaxSynchronizationJob(Guid id, string jobName, string jobDescription, CronTabSchedule schedule, WhippetTenant tenant, bool active, ILogger logger)
            : this(id, jobName, jobDescription, schedule, tenant, active, null, logger)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobBase"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="jobName">Name of the job.</param>
        /// <param name="jobDescription">Job description.</param>
        /// <param name="schedule">Job's cron schedule.</param>
        /// <param name="active">Specifies whether the job is currently active and running.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> that the job is registered with.</param>
        /// <param name="localizedCategory">Localized <see cref="MagentoTaxSynchronizationJobCategory"/> object.</param>
        /// <param name="logger"><see cref="ILogger"/> used to log the job activity or <see langword="null"/> to use no logger.</param>
        public MultichannelOrderManagerMagentoTaxSynchronizationJob(Guid id, string jobName, string jobDescription, CronTabSchedule schedule, WhippetTenant tenant, bool active, MagentoTaxSynchronizationJobCategory localizedCategory, ILogger logger)
            : base(id, jobName, jobDescription, schedule, active, tenant, localizedCategory, logger)
        {
            if (String.IsNullOrWhiteSpace(jobName))
            {
                throw new ArgumentNullException(nameof(jobName));
            }
            else if (String.IsNullOrWhiteSpace(jobDescription))
            {
                throw new ArgumentNullException(nameof(jobDescription));
            }
            else if (schedule == null)
            {
                throw new ArgumentNullException(nameof(schedule));
            }
        }

        /// <summary>
        /// Creates a duplicate instance of the current object with the optional <see cref="Guid"/> that represents the user ID of the user who instantiated the new instance. This method must be overridden.
        /// </summary>
        /// <typeparam name="TObject">Type of object to return from the operation.</typeparam>
        /// <param name="createdBy"><see cref="Guid"/> ID of the user who instantiated the new instance.</param>
        /// <returns>Object of type <typeparamref name="TObject"/>.</returns>
        public override TObject Clone<TObject>(Guid? createdBy = null)
        {
            return (TObject)((object)(new MultichannelOrderManagerMagentoTaxSynchronizationJob(ID, JobName, JobDescription, Schedule.Clone<CronTabSchedule>(), Tenant.Clone<WhippetTenant>(), Active, Logger)));
        }

        /// <summary>
        /// Executes the job.
        /// </summary>
        /// <param name="parameters"><see cref="IJobParameter"/> object(s) that provide additional information the job needs in order to run (if any).</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="MissingParameterException" />
        public override void Execute(params IJobParameter[] parameters)
        {
            ExecuteAsync(parameters).WaitAndUnwrapException();
        }

        /// <summary>
        /// Executes the job asynchronously. Override this method to add an asynchronous implementation of <see cref="Execute(IJobParameter[])"/>.
        /// </summary>
        /// <param name="parameters"><see cref="IJobParameter"/> object(s) that provide additional information the job needs in order to run (if any).</param>
        /// <returns><see cref="Task"/> object.</returns>
        public override async Task ExecuteAsync(params IJobParameter[] parameters)
        {
            MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter sourceParameter = null;
            MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter destinationParameter = null;
            MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter reportParameter = null;

            // search for the parameters

            foreach (IJobParameter p in parameters)
            {
                if (p is MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter)
                {
                    sourceParameter = (MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter)(p);
                }
                else if (p is MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter)
                {
                    destinationParameter = (MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter)(p);
                }
                else if (p is MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter)
                {
                    reportParameter = (MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter)(p);
                }
                else if ((sourceParameter != null) && (destinationParameter != null) && (reportParameter != null))
                {
                    // found the parameters we need; stop processing more arguments
                    break;
                }
            }

            if ((sourceParameter != null) && (destinationParameter != null) && (reportParameter != null))
            {
                await ExecuteInternal(sourceParameter, destinationParameter, reportParameter);
            }
            else
            {
                if ((sourceParameter == null) && (destinationParameter == null) && (reportParameter == null))
                {
                    throw new MissingParameterException(new[] { typeof(MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter), typeof(MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter), typeof(MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter) });
                }
                else if (sourceParameter == null)
                {
                    throw new MissingParameterException(new[] { typeof(MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter) });
                }
                else if (destinationParameter == null)
                {
                    throw new MissingParameterException(new[] { typeof(MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter) });
                }
                else
                {
                    throw new MissingParameterException(new[] { typeof(MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter) });
                }
            }
        }

        /// <summary>
        /// Executes the job.
        /// </summary>
        /// <param name="sourceParameter">Parameter that contains the source server to execute.</param>
        /// <param name="destinationParameter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotSupportedException" />
        protected virtual async Task ExecuteInternal(MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter sourceParameter, MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter destinationParameter, MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter reportParameter)
        {
            if (sourceParameter == null)
            {
                throw new ArgumentNullException(nameof(sourceParameter));
            }
            else if (destinationParameter == null)
            {
                throw new ArgumentNullException(nameof(destinationParameter));
            }
            else if (reportParameter == null)
            {
                throw new ArgumentNullException(nameof(reportParameter));
            }
            else if (!sourceParameter.SourceServerID.HasValue)
            {
                throw new ArgumentNullException(nameof(sourceParameter.SourceServerID));
            }
            else if (!destinationParameter.MagentoServerID.HasValue)
            {
                throw new ArgumentNullException(nameof(destinationParameter.MagentoServerID));
            }
            else if (!reportParameter.ReportServerID.HasValue)
            {
                throw new ArgumentNullException(nameof(reportParameter.ReportServerID));
            }
            else if (String.IsNullOrWhiteSpace(reportParameter.TableViewName))
            {
                throw new ArgumentNullException(nameof(reportParameter.TableViewName));
            }
            else if (sourceParameter.SourceServerType == null || (sourceParameter.SourceServerType.GetInterfaces() == null) || !sourceParameter.SourceServerType.GetInterfaces().Contains(typeof(IMultichannelOrderManagerServer)))
            {
                throw new NotSupportedException();
            }
            else if (destinationParameter.MagentoServerType == null || (destinationParameter.MagentoServerType.GetInterfaces() == null) || !destinationParameter.MagentoServerType.GetInterfaces().Contains(typeof(IMagentoServer)))
            {
                throw new NotSupportedException();
            }
            else if (reportParameter.ReportServerType == null || (reportParameter.ReportServerType.GetInterfaces() == null) || !sourceParameter.SourceServerType.GetInterfaces().Contains(typeof(IMultichannelOrderManagerServer)))
            {
                throw new NotSupportedException();
            }
            else
            {
                const string MISSING_COUNTRY_ID = "MissingCountry";

                WhippetResultContainer<IMultichannelOrderManagerServer> momServer = null;
                WhippetResultContainer<IMultichannelOrderManagerServer> momReportServer = null;

                WhippetResultContainer<MultichannelOrderManagerFlattenedTaxRateExportServiceManager> momTaxRateSM = null;
                WhippetResultContainer<MultichannelOrderManagerCountryServiceManager> momCountrySM = null;
                WhippetResultContainer<MultichannelOrderManagerStateProvinceServiceManager> momStateProvinceSM = null;
                WhippetResultContainer<MultichannelOrderManagerPostalCodeServiceManager> momPostalCodeSM = null;

                WhippetResultContainer<IMagentoServer> magentoServer = null;

                WhippetResultContainer<MagentoServerServiceManager> magentoServerSM = null;
                WhippetResultContainer<TaxRateServiceManager> magentoTaxRateSM = null;
                WhippetResultContainer<TaxRuleServiceManager> magentoTaxRuleSM = null;
                WhippetResultContainer<TaxClassServiceManager> magentoTaxClassSM = null;
                WhippetResultContainer<MagentoTaxSynchronizationServiceManager> magentoTaxSM = null;
                WhippetResultContainer<CountryServiceManager> magentoCountrySM = null;
                WhippetResultContainer<Tuple<MagentoRestClient, string>> magentoRestClient = null;

                WhippetResultContainer<PostalCodeServiceManager> postalCodeSM = null;

                WhippetResultContainer<Tuple<IEnumerable<MagentoSalesTaxRateSynchronizationRecordDataModel>, IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryModel>>> magentoSyncModels = null;

                WhippetResultContainer<ITaxRate> individualSyncResult = null;

                List<IDisposable> disposables = null;

                try
                {
                    disposables = new List<IDisposable>();

                    momServer = MultichannelOrderManagerServerDelegate(sourceParameter.SourceServerID.GetValueOrDefault());
                    momServer.ThrowIfFailed();
                    momServer.ThrowIfObjectNotFound(sourceParameter.SourceServerID.GetValueOrDefault());

                    momReportServer = MultichannelOrderManagerServerDelegate(reportParameter.ReportServerID.GetValueOrDefault());
                    momReportServer.ThrowIfFailed();
                    momReportServer.ThrowIfObjectNotFound(reportParameter.ReportServerID.GetValueOrDefault());

                    magentoServerSM = MagentoServerServiceManagerDelegate();
                    magentoServerSM.ThrowIfFailed();

                    disposables.Add(magentoServerSM.Item);

                    magentoServer = MagentoServerDelegate(magentoServerSM.Item, destinationParameter.MagentoServerID.GetValueOrDefault());
                    magentoServer.ThrowIfFailed();
                    magentoServer.ThrowIfObjectNotFound(destinationParameter.MagentoServerID.GetValueOrDefault());

                    magentoRestClient = MagentoRestClientDelegate(magentoServer.Item);
                    magentoRestClient.ThrowIfFailed();

                    magentoTaxRateSM = MagentoTaxRateServiceManagerDelegate(magentoRestClient.Item);
                    magentoTaxRateSM.ThrowIfFailed();

                    disposables.Add(magentoTaxRateSM.Item);

                    magentoTaxRuleSM = MagentoTaxRuleServiceManagerDelegate(magentoRestClient.Item);
                    magentoTaxRuleSM.ThrowIfFailed();

                    disposables.Add(magentoTaxRuleSM.Item);

                    magentoTaxClassSM = MagentoTaxClassServiceManagerDelegate(magentoRestClient.Item);
                    magentoTaxClassSM.ThrowIfFailed();

                    disposables.Add(magentoTaxClassSM.Item);

                    magentoCountrySM = MagentoCountryServiceManagerDelegate(magentoRestClient.Item);
                    magentoCountrySM.ThrowIfFailed();

                    disposables.Add(magentoCountrySM.Item);

                    momTaxRateSM = MultichannelOrderManagerFlattenedTaxRateExportServiceManagerDelegate(momReportServer.Item.ConnectionString, reportParameter.TableViewName);
                    momTaxRateSM.ThrowIfFailed();

                    disposables.Add(momTaxRateSM.Item);

                    momCountrySM = MultichannelOrderManagerCountryServiceManagerDelegate(momServer.Item.ConnectionString);
                    momCountrySM.ThrowIfFailed();

                    disposables.Add(momCountrySM.Item);

                    momStateProvinceSM = MultichannelOrderManagerStateProvinceServiceManagerDelegate(momServer.Item.ConnectionString);
                    momStateProvinceSM.ThrowIfFailed();

                    disposables.Add(momStateProvinceSM.Item);

                    momPostalCodeSM = MultichannelOrderManagerPostalCodeServiceManagerDelegate(momServer.Item.ConnectionString);
                    momPostalCodeSM.ThrowIfFailed();

                    disposables.Add(momPostalCodeSM.Item);

                    magentoTaxSM = MagentoTaxSynchronizationServiceManagerDelegate(magentoServerSM.Item, magentoTaxRateSM.Item, magentoTaxRuleSM.Item, magentoTaxClassSM.Item, magentoCountrySM.Item);
                    magentoTaxSM.ThrowIfFailed();

                    disposables.Add(magentoTaxSM.Item);

                    postalCodeSM = PostalCodeServiceManagerDelegate(momServer.Item.ConnectionString);
                    postalCodeSM.ThrowIfFailed();

                    disposables.Add(postalCodeSM.Item);

                    // FIX THIS LATER
                    magentoSyncModels = await magentoTaxSM.Item.GetMagentoTaxRatesToUpdate(magentoServer.Item, destinationParameter.TaxExemptCode, destinationParameter.PreserveExistingTaxExemptRates, momTaxRateSM.Item, momCountrySM.Item, momStateProvinceSM.Item, momPostalCodeSM.Item, null, null, postalCodeSM.Item, null, null, null, null, null, null, MISSING_COUNTRY_ID);
                    magentoSyncModels.ThrowIfFailed();

                    //if (magentoServer.Item.ServerType.HasFlag(ExternalDataSourceType.REST))
                    //{
                    //    if (magentoSyncModels.HasItem && magentoSyncModels.Item.Any())
                    //    {
                    //        if (!destinationParameter.UseBulkImport)
                    //        {
                    //            individualSyncResult = await DoIndividualSync(magentoSyncModels.Item, magentoTaxRateSM.Item, magentoCountrySM.Item);
                    //            individualSyncResult.ThrowIfFailed();
                    //        }
                    //        else
                    //        {
                    //            // to do
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    throw new NotSupportedException();
                    //}
                }
                finally
                {
                    if (disposables != null && (disposables.Count > 0))
                    {
                        foreach (IDisposable obj in disposables)
                        {
                            if (obj != null)
                            {
                                obj.Dispose();
                            }
                        }

                        disposables = null;
                    }
                }
            }
        }

        /// <summary>
        /// Performs a synchronization for each individual <see cref="ITaxRate"/> and associated objects.
        /// </summary>
        /// <param name="syncModels"><see cref="IEnumerable{T}"/> collection of <see cref="MagentoSalesTaxRateSynchronizationRecordDataModel"/> objects.</param>
        /// <param name="magentoTaxRateSM"><see cref="TaxRateServiceManager"/> object.</param>
        /// <param name="magentoCountrySM"><see cref="CountryServiceManager"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation. If the operation fails, will contain the <see cref="ITaxRate"/> which caused the failure.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected virtual async Task<WhippetResultContainer<ITaxRate>> DoIndividualSync(IEnumerable<MagentoSalesTaxRateSynchronizationRecordDataModel> syncModels, TaxRateServiceManager magentoTaxRateSM, CountryServiceManager magentoCountrySM)
        {
            if (syncModels == null)
            {
                throw new ArgumentNullException(nameof(syncModels));
            }
            else if (magentoTaxRateSM == null)
            {
                throw new ArgumentNullException(nameof(magentoTaxRateSM));
            }
            else if (magentoCountrySM == null)
            {
                throw new ArgumentNullException(nameof(magentoCountrySM));
            }
            else
            {
                WhippetResultContainer<ITaxRate> result = null;
                WhippetResultContainer<ICountry> magentoCountry = null;

                try
                {
                    foreach (MagentoSalesTaxRateSynchronizationRecordDataModel syncModel in syncModels)
                    {
                        //magentoCountry = await magentoCountrySM.Get(syncModel.Rate.CountryID);
                        magentoCountry.ThrowIfFailed();

                        if (magentoCountry.HasItem)
                        {
                            //syncModel.Rate.Country = new CountryDataModel(magentoCountry.Item);
                        }

                        if (syncModel.DeleteRate)
                        {
                            result = await magentoTaxRateSM.DeleteTaxRateAsync(syncModel.Rate);
                        }
                        else
                        {
                            // check to see if the rate exists first

                            result = await magentoTaxRateSM.GetTaxRate(syncModel.Rate.ID);
                            result.ThrowIfFailed();

                            if (result.HasItem)
                            {
                                result = await magentoTaxRateSM.UpdateTaxRateAsync(syncModel.Rate);
                            }
                            else
                            {
                                result = await magentoTaxRateSM.CreateTaxRateAsync(syncModel.Rate);
                            }
                        }

                        result.ThrowIfFailed();
                    }

                    result = new WhippetResultContainer<ITaxRate>(WhippetResult.Success, null);
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ITaxRate>(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be inherited.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public override string ToJson<T>()
        {
            return this.SerializeJson(this);
        }
    }
}
