using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NHibernate;
using Athi.Whippet.Data.NHibernate.Extensions;
using Athi.Whippet.Data;
using Athi.Whippet.Localization.Addressing.EntityMappings;
using Athi.Whippet.Localization;
using Athi.Whippet.Localization.Addressing.Repositories;
using Athi.Whippet.Localization.Addressing.Installer.ResourceFiles;

namespace Athi.Whippet.Localization.Addressing.Installer
{
    /// <summary>
    /// Provides seeding functionality for <see cref="StateProvince"/> objects. This class cannot be inherited.
    /// </summary>
    internal sealed class StateProvinceSeed : WhippetEntitySeed<StateProvince>, IWhippetEntitySeed, IWhippetEntitySeed<StateProvince>, IStateProvinceSeed
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StateProvinceSeed"/> class with no arguments.
        /// </summary>
        private StateProvinceSeed()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateProvinceSeed"/> class.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> that provides context for the data store.</param>
        /// <param name="statusUpdater"><see cref="ProgressDelegate"/> used to report the status of the operation.</param>
        /// <exception cref="ArgumentNullException" />
        public StateProvinceSeed(ISession context, ProgressDelegate statusUpdater = null)
            : base(context, statusUpdater)
        { }

        /// <summary>
        /// Seeds the current data store provided by NHibernate given the specified <see cref="ISession"/>.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> that provides context for the data store.</param>
        /// <param name="statusUpdater"><see cref="ProgressDelegate"/> used to report the status of the operation.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override WhippetResult Seed(ISession context, ProgressDelegate statusUpdater = null)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;
                Exception exceptionEncountered = null;
                IEnumerable<WhippetResultContainer<StateProvince>> resultContainers = null;

                try
                {
                    resultContainers = Seed(new StateProvinceRepository(context), statusUpdater);

                    if (resultContainers != null)
                    {
                        if (resultContainers.Any(rc => !rc.IsSuccess))
                        {
                            exceptionEncountered = resultContainers.Where(rc => rc.Exception != null && !rc.IsSuccess).FirstOrDefault()?.Exception;
                            result = new WhippetResult(WhippetResultSeverity.Failure, exception: exceptionEncountered, resultObject: resultContainers);
                        }
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResult(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Seeds the current data store provided by NHibernate given the specified <see cref="ISession"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetEntityRepository{TEntity, TKey}"/> that is the backing data store where the <see cref="StateProvince"/> entities will be stored.</param>
        /// <param name="statusUpdater"><see cref="Delegate"/> that provides real-time updates to each record being updated.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the seed action with each <see cref="IWhippetEntity"/> object(s).</returns>
        /// <exception cref="ArgumentNullException" />
        public override IEnumerable<WhippetResultContainer<StateProvince>> Seed(IWhippetEntityRepository<StateProvince, Guid> repository, ProgressDelegate statusUpdater = null)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            else
            {
                ProgressDelegateManager stateProvinceStatusManager = null;
                ProgressDelegateManager countryStatusManager = null;

                List<WhippetResultContainer<StateProvince>> results = null;
                List<StateProvince> existingStateProvinces = null;

                WhippetResultContainer<IEnumerable<Country>> countryResults = null;
                WhippetResultContainer<IEnumerable<StateProvince>> stateProvinceResults = null;

                WhippetResult result = WhippetResult.Success;

                ICountryRepository countryRepo = null;

                IEnumerable<string> countryResourceFiles = null;

                Dictionary<string, string> stateProvinces = null;

                string resourceFile = null;

                StateProvince state = null;

                ITransaction transaction = null;

                // first, we need to load all the countries

                try
                {
                    transaction = repository.BeginTransaction();

                    existingStateProvinces = new List<StateProvince>();
                    results = new List<WhippetResultContainer<StateProvince>>();

                    countryRepo = new CountryRepository(Context);   // use the default context provided upon initialization
                    countryResults = countryRepo.GetAll();

                    if (countryResults.IsSuccess)
                    {
                        if (countryResults.HasItem)
                        {
                            countryStatusManager = new ProgressDelegateManager(0, countryResults.Item.Count(), statusUpdater);

                            foreach (Country country in countryResults.Item)
                            {
                                stateProvinces = null;

                                countryStatusManager.Advance(LocalizedStringResourceLoader.GetResource(GetType(), ResourceIndex.ReadStatesForCountry, new object[] { country.Name }));
                                countryResourceFiles = AddressingResourceFileUtility.GetCountryResourceFiles(country);

                                if (countryResourceFiles != null && countryResourceFiles.Any())
                                {
                                    // only load all state provinces if it hasn't been initialized yet
                                    if (stateProvinceResults == null)
                                    {
                                        stateProvinceResults = repository.GetAll();

                                        if (stateProvinceResults.IsSuccess)
                                        {
                                            existingStateProvinces = new List<StateProvince>(stateProvinceResults.Item);
                                        }
                                        else
                                        {
                                            throw stateProvinceResults.Exception;
                                        }
                                    }

                                    // load the state/province resource file for the country

                                    resourceFile = AddressingResourceFileUtility.GetCountryStateProvinceResourceFile(country);

                                    if (!String.IsNullOrWhiteSpace(resourceFile))
                                    {
                                        if (Path.GetExtension(resourceFile).Equals(".json", StringComparison.InvariantCultureIgnoreCase))
                                        {
                                            stateProvinces = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(resourceFile));
                                        }
                                        else
                                        {
                                            throw new NotSupportedException();
                                        }
                                    }

                                    if (stateProvinces != null && stateProvinces.Any())
                                    {
                                        stateProvinceStatusManager = new ProgressDelegateManager(0, stateProvinces.Count, statusUpdater);

                                        // always indexed by abbreviation

                                        foreach (KeyValuePair<string, string> entry in stateProvinces)
                                        {
                                            state = new StateProvince(null, entry.Value, entry.Key, country);

                                            // check for existing state/province and, if exists, skip to next one

                                            if (existingStateProvinces.Where(sp => String.Equals(sp.Name, state.Name, StringComparison.InvariantCultureIgnoreCase) || String.Equals(sp.Abbreviation, state.Abbreviation, StringComparison.InvariantCultureIgnoreCase)).Any())
                                            {
                                                stateProvinceStatusManager.Advance(LocalizedStringResourceLoader.GetResource(GetType(), ResourceIndex.StateExists, new object[] { state.Name }));
                                                continue;
                                            }

                                            results.Add(new WhippetResultContainer<StateProvince>(repository.Create(state), state));
                                            existingStateProvinces.Add(state);

                                            stateProvinceStatusManager.Advance(state.Name);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        throw countryResults.Exception;
                    }

                    repository.Commit();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    results = new List<WhippetResultContainer<StateProvince>>(new[] { new WhippetResultContainer<StateProvince>(new WhippetResult(e), null) });

                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                }
                finally
                {
                    if (transaction != null)
                    {
                        transaction.Dispose();
                        transaction = null;
                    }
                }

                return results;
            }
        }
    }
}
