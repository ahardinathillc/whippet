using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NHibernate;
using Athi.Whippet.Geography;
using Athi.Whippet.Data.NHibernate.Extensions;
using Athi.Whippet.Data;
using Athi.Whippet.Localization.Addressing.EntityMappings;
using Athi.Whippet.Localization;
using Athi.Whippet.Localization.Addressing.Repositories;
using Athi.Whippet.Localization.Addressing.Installer.ResourceFiles;
using Athi.Whippet.Localization.Addressing.Installer.JsonObjects;

namespace Athi.Whippet.Localization.Addressing.Installer
{
    /// <summary>
    /// Provides seeding functionality for <see cref="City"/> objects. This class cannot be inherited.
    /// </summary>
    internal sealed class CitySeed : WhippetEntitySeed<City>, IWhippetEntitySeed, IWhippetEntitySeed<City>, ICitySeed
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CitySeed"/> class with no arguments.
        /// </summary>
        private CitySeed()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CitySeed"/> class.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> that provides context for the data store.</param>
        /// <param name="statusUpdater"><see cref="ProgressDelegate"/> used to report the status of the operation.</param>
        /// <exception cref="ArgumentNullException" />
        public CitySeed(ISession context, ProgressDelegate statusUpdater = null)
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
                IEnumerable<WhippetResultContainer<City>> resultContainers = null;

                try
                {
                    resultContainers = Seed(new CityRepository(context), statusUpdater);

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
        /// <param name="repository"><see cref="IWhippetEntityRepository{TEntity, TKey}"/> that is the backing data store where the <see cref="City"/> entities will be stored.</param>
        /// <param name="statusUpdater"><see cref="Delegate"/> that provides real-time updates to each record being updated.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the seed action with each <see cref="IWhippetEntity"/> object(s).</returns>
        /// <exception cref="ArgumentNullException" />
        public override IEnumerable<WhippetResultContainer<City>> Seed(IWhippetEntityRepository<City, Guid> repository, ProgressDelegate statusUpdater = null)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            else
            {
                ProgressDelegateManager cityStatusManager = null;
                ProgressDelegateManager stateProvinceStatusManager = null;

                List<WhippetResultContainer<City>> results = null;
                List<City> existingCities = null;
                List<City> readCities = null;

                WhippetResultContainer<IEnumerable<StateProvince>> stateProvinceResults = null;
                WhippetResultContainer<IEnumerable<City>> cityResults = null;

                WhippetResult result = WhippetResult.Success;

                IStateProvinceRepository stateProvinceRepo = null;

                IEnumerable<string> stateProvinceResourceFiles = null;
                IEnumerable<AddressingJsonObject> addresses = null;
                IEnumerable<AddressingJsonObject> filteredAddresses = null;

                ITransaction transaction = null;

                string resourceFile = null;

                // first, we need to load all the state/provinces

                try
                {
                    transaction = repository.BeginTransaction();

                    existingCities = new List<City>();
                    results = new List<WhippetResultContainer<City>>();

                    stateProvinceRepo = new StateProvinceRepository(Context);   // use the default context provided upon initialization
                    stateProvinceResults = stateProvinceRepo.GetAll();

                    cityResults = repository.GetAll();

                    if (stateProvinceResults.IsSuccess && cityResults.IsSuccess)
                    {
                        if (stateProvinceResults.HasItem)
                        {
                            stateProvinceStatusManager = new ProgressDelegateManager(0, stateProvinceResults.Item.Count(), statusUpdater);

                            foreach (StateProvince stateProvince in stateProvinceResults.Item)
                            {
                                if (stateProvince.Name.Contains("ontario", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    bool stop = true;
                                }

                                readCities = null;

                                stateProvinceStatusManager.Advance(LocalizedStringResourceLoader.GetResource(GetType(), ResourceIndex.ReadCitiesForStateProvince, new object[] { stateProvince.Name }));
                                stateProvinceResourceFiles = AddressingResourceFileUtility.GetCountryResourceFiles(stateProvince.Country);

                                if (!cityResults.HasItem)
                                {
                                    existingCities = new List<City>();
                                }
                                else
                                {
                                    existingCities = cityResults.Item.Where(c => c.StateProvince.ID.Equals(stateProvince.ID)).ToList();
                                }

                                if (stateProvinceResourceFiles != null && stateProvinceResourceFiles.Any())
                                {
                                    stateProvinceResourceFiles = AddressingResourceFileUtility.GetCountryResourceFiles(stateProvince.Country);

                                    if (stateProvinceResourceFiles != null && stateProvinceResourceFiles.Any())
                                    {
                                        // filter based on geojson or json files

                                        resourceFile = stateProvinceResourceFiles.Where(rf => rf.EndsWith("-cities-zip.json", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                                        if (!String.IsNullOrWhiteSpace(resourceFile))
                                        {
                                            using (StreamReader rawReader = File.OpenText(resourceFile))
                                            {
                                                addresses = JsonConvert.DeserializeObject<IEnumerable<AddressingJsonObject>>(rawReader.ReadToEnd());
                                            }

                                            if (addresses != null && addresses.Any())
                                            {
                                                filteredAddresses = addresses.Where(a => String.Equals(a.state?.Trim(), stateProvince.Abbreviation, StringComparison.InvariantCultureIgnoreCase) ||
                                                    String.Equals(a.state?.Trim(), stateProvince.Name, StringComparison.InvariantCultureIgnoreCase)).AsParallel().ToList();

                                                if (filteredAddresses != null && filteredAddresses.Any())
                                                {
                                                    readCities = new List<City>(filteredAddresses.Select(a => new City(null, a.city?.Trim().ToUpper(), stateProvince, new LatitudeLongitudeCoordinate(Convert.ToDecimal(a.latitude.GetValueOrDefault()), Convert.ToDecimal(a.longitude.GetValueOrDefault())))).ToList());

                                                    if (readCities != null && readCities.Any())
                                                    {
                                                        readCities = readCities.DistinctBy(c => c.Name).ToList();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                if (readCities != null && readCities.Any())
                                {
                                    cityStatusManager = new ProgressDelegateManager(0, readCities.Count, statusUpdater);

                                    foreach (City readCity in readCities)
                                    {
                                        cityStatusManager.Advance(LocalizedStringResourceLoader.GetResource(GetType(), ResourceIndex.ReadCity, new object[] { readCity.Name }));

                                        if (!existingCities.Where(c => String.Equals(readCity.Name, c.Name, StringComparison.InvariantCultureIgnoreCase)).Any())
                                        {
                                            result = repository.Create(readCity);

                                            if (!result.IsSuccess)
                                            {
                                                throw result.Exception;
                                            }
                                            else
                                            {
                                                existingCities.Add(readCity);
                                            }
                                        }
                                        else
                                        {
                                            cityStatusManager.Advance(LocalizedStringResourceLoader.GetResource(GetType(), ResourceIndex.CityExists, new object[] { readCity.Name }));
                                        }

                                        results.Add(new WhippetResultContainer<City>(WhippetResult.Success, readCity));
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!stateProvinceResults.IsSuccess)
                        {
                            throw stateProvinceResults.Exception;
                        }
                        else
                        {
                            throw cityResults.Exception;
                        }
                    }

                    repository.Commit();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    results = new List<WhippetResultContainer<City>>(new[] { new WhippetResultContainer<City>(new WhippetResult(e), null) });

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
