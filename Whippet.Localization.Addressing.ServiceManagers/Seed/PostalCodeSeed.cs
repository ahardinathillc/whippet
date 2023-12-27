// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Newtonsoft.Json;
// using NHibernate;
// using Athi.Whippet.Geography;
// using Athi.Whippet.Data;
// using Athi.Whippet.Localization.Addressing.Repositories;
// using Athi.Whippet.Localization.Addressing.ResourceFiles;
//
// namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Seed
// {
//     /// <summary>
//     /// Provides seeding functionality for <see cref="PostalCode"/> objects. This class cannot be inherited.
//     /// </summary>
//     internal sealed class PostalCodeSeed : WhippetEntitySeed<PostalCode>, IWhippetEntitySeed, IWhippetEntitySeed<PostalCode>, IPostalCodeSeed
//     {
//         /// <summary>
//         /// Initializes a new instance of the <see cref="PostalCodeSeed"/> class with no arguments.
//         /// </summary>
//         private PostalCodeSeed()
//             : base()
//         { }
//
//         /// <summary>
//         /// Initializes a new instance of the <see cref="PostalCodeSeed"/> class.
//         /// </summary>
//         /// <param name="context"><see cref="ISession"/> that provides context for the data store.</param>
//         /// <param name="statusUpdater"><see cref="ProgressDelegate"/> used to report the status of the operation.</param>
//         /// <exception cref="ArgumentNullException" />
//         public PostalCodeSeed(ISession context, ProgressDelegate statusUpdater = null)
//             : base(context, statusUpdater)
//         { }
//
//         /// <summary>
//         /// Seeds the current data store provided by NHibernate given the specified <see cref="ISession"/>.
//         /// </summary>
//         /// <param name="context"><see cref="ISession"/> that provides context for the data store.</param>
//         /// <param name="statusUpdater"><see cref="ProgressDelegate"/> used to report the status of the operation.</param>
//         /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
//         /// <exception cref="ArgumentNullException"></exception>
//         public override WhippetResult Seed(ISession context, ProgressDelegate statusUpdater = null)
//         {
//             if (context == null)
//             {
//                 throw new ArgumentNullException(nameof(context));
//             }
//             else
//             {
//                 WhippetResult result = WhippetResult.Success;
//                 Exception exceptionEncountered = null;
//                 IEnumerable<WhippetResultContainer<PostalCode>> resultContainers = null;
//
//                 try
//                 {
//                     resultContainers = Seed(new PostalCodeRepository(context), statusUpdater);
//
//                     if (resultContainers != null)
//                     {
//                         if (resultContainers.Any(rc => !rc.IsSuccess))
//                         {
//                             exceptionEncountered = resultContainers.Where(rc => rc.Exception != null && !rc.IsSuccess).FirstOrDefault()?.Exception;
//                             result = new WhippetResult(WhippetResultSeverity.Failure, exception: exceptionEncountered, resultObject: resultContainers);
//                         }
//                     }
//                 }
//                 catch (Exception e)
//                 {
//                     result = new WhippetResult(e);
//                 }
//
//                 return result;
//             }
//         }
//
//         /// <summary>
//         /// Seeds the current data store provided by NHibernate given the specified <see cref="ISession"/>.
//         /// </summary>
//         /// <param name="repository"><see cref="IWhippetEntityRepository{TEntity, TKey}"/> that is the backing data store where the <see cref="PostalCode"/> entities will be stored.</param>
//         /// <param name="statusUpdater"><see cref="Delegate"/> that provides real-time updates to each record being updated.</param>
//         /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the seed action with each <see cref="IWhippetEntity"/> object(s).</returns>
//         /// <exception cref="ArgumentNullException" />
//         public override IEnumerable<WhippetResultContainer<PostalCode>> Seed(IWhippetEntityRepository<PostalCode, Guid> repository, ProgressDelegate statusUpdater = null)
//         {
//             if (repository == null)
//             {
//                 throw new ArgumentNullException(nameof(repository));
//             }
//             else
//             {
//                 ProgressDelegateManager cityStatusManager = null;
//                 ProgressDelegateManager stateProvinceStatusManager = null;
//                 ProgressDelegateManager postalCodeStatusManager = null;
//
//                 List<WhippetResultContainer<PostalCode>> results = null;
//                 List<City> existingCities = null;
//                 List<City> readCities = null;
//                 List<PostalCode> existingPostalCodes = null;
//
//                 Dictionary<City, List<PostalCode>> cityPostalCodes = null;
//
//                 WhippetResultContainer<IEnumerable<StateProvince>> stateProvinceResults = null;
//                 WhippetResultContainer<IEnumerable<City>> cityResults = null;
//                 WhippetResultContainer<IEnumerable<PostalCode>> postalCodeResults = null;
//
//                 WhippetResult result = WhippetResult.Success;
//
//                 IStateProvinceRepository stateProvinceRepo = null;
//                 ICityRepository cityRepo = null;
//
//                 IEnumerable<string> stateProvinceResourceFiles = null;
//                 IEnumerable<AddressingJsonObject> addresses = null;
//                 IEnumerable<AddressingJsonObject> filteredAddresses = null;
//                 IEnumerable<AddressingJsonObject> filteredPostalCodes = null;
//
//                 ITransaction transaction = null;
//
//                 City currentCity = null;
//
//                 string resourceFile = null;
//
//                 // first, we need to load all the state/provinces
//
//                 try
//                 {
//                     transaction = repository.BeginTransaction();
//
//                     existingCities = new List<City>();
//                     results = new List<WhippetResultContainer<PostalCode>>();
//
//                     stateProvinceRepo = new StateProvinceRepository(Context);   // use the default context provided upon initialization
//                     stateProvinceResults = stateProvinceRepo.GetAll();
//
//                     cityRepo = new CityRepository(Context);
//                     cityResults = cityRepo.GetAll();
//
//                     postalCodeResults = repository.GetAll();
//
//                     if (stateProvinceResults.IsSuccess && cityResults.IsSuccess && postalCodeResults.IsSuccess)
//                     {
//                         cityPostalCodes = new Dictionary<City, List<PostalCode>>();
//
//                         if (stateProvinceResults.HasItem)
//                         {
//                             stateProvinceStatusManager = new ProgressDelegateManager(0, stateProvinceResults.Item.Count(), statusUpdater);
//
//                             foreach (StateProvince stateProvince in stateProvinceResults.Item)
//                             {
//                                 readCities = null;
//
//                                 stateProvinceStatusManager.Advance(LocalizedStringResourceLoader.GetResource(typeof(CitySeed), ResourceIndex.ReadCitiesForStateProvince, new object[] { stateProvince.Name }));
//                                 stateProvinceResourceFiles = AddressingResourceFileUtility.GetCountryResourceFiles(stateProvince.Country);
//
//                                 if (!cityResults.HasItem)
//                                 {
//                                     existingCities = new List<City>();
//                                 }
//                                 else
//                                 {
//                                     existingCities = cityResults.Item.Where(c => c.StateProvince.ID.Equals(stateProvince.ID)).ToList();
//                                 }
//
//                                 if (!postalCodeResults.HasItem)
//                                 {
//                                     existingPostalCodes = new List<PostalCode>();
//                                 }
//                                 else
//                                 {
//                                     existingPostalCodes = postalCodeResults.Item.Where(pc => pc.City.StateProvince.ID.Equals(stateProvince.ID)).ToList();
//                                 }
//
//                                 if (stateProvinceResourceFiles != null && stateProvinceResourceFiles.Any())
//                                 {
//                                     stateProvinceResourceFiles = AddressingResourceFileUtility.GetCountryResourceFiles(stateProvince.Country);
//
//                                     if (stateProvinceResourceFiles != null && stateProvinceResourceFiles.Any())
//                                     {
//                                         // filter based on geojson or json files
//
//                                         resourceFile = stateProvinceResourceFiles.Where(rf => rf.EndsWith("-cities-zip.json", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
//
//                                         if (!String.IsNullOrWhiteSpace(resourceFile))
//                                         {
//                                             using (StreamReader rawReader = File.OpenText(resourceFile))
//                                             {
//                                                 addresses = JsonConvert.DeserializeObject<IEnumerable<AddressingJsonObject>>(rawReader.ReadToEnd());
//                                             }
//
//                                             if (addresses != null && addresses.Any())
//                                             {
//                                                 filteredAddresses = addresses.Where(a => String.Equals(a.state?.Trim(), stateProvince.Abbreviation, StringComparison.InvariantCultureIgnoreCase) ||
//                                                     String.Equals(a.state?.Trim(), stateProvince.Name, StringComparison.InvariantCultureIgnoreCase)).AsParallel().ToList();
//
//                                                 if (filteredAddresses != null && filteredAddresses.Any())
//                                                 {
//                                                     readCities = new List<City>(filteredAddresses.Select(a => new City(null, a.city?.Trim().ToUpper(), stateProvince, null)).ToList());
//                                                 }
//                                             }
//                                         }
//                                     }
//                                 }
//
//                                 if (readCities != null && readCities.Any())
//                                 {
//                                     readCities = readCities.DistinctBy(c => c.Name).ToList();
//
//                                     cityStatusManager = new ProgressDelegateManager(0, readCities.Count, statusUpdater);
//
//                                     foreach (City readCity in readCities)
//                                     {
//                                         cityStatusManager.Advance(LocalizedStringResourceLoader.GetResource(typeof(CitySeed), ResourceIndex.ReadCity, new object[] { readCity.Name }));
//
//                                         currentCity = existingCities.Where(c => String.Equals(readCity.Name, c.Name, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
//
//                                         if (currentCity != null)
//                                         {
//                                             cityPostalCodes.Add(currentCity, new List<PostalCode>());     // add each city to the city/postal code collection
//
//                                             filteredPostalCodes = filteredAddresses.Where(fa => String.Equals(fa.city?.Trim(), currentCity.Name, StringComparison.CurrentCultureIgnoreCase)
//                                                 && (String.Equals(fa?.state?.Trim(), currentCity.StateProvince.Abbreviation, StringComparison.InvariantCultureIgnoreCase)
//                                                         || String.Equals(fa?.state?.Trim(), currentCity.StateProvince.Name, StringComparison.InvariantCultureIgnoreCase)));
//
//                                             if (filteredPostalCodes != null && filteredPostalCodes.Any())
//                                             {
//                                                 postalCodeStatusManager = new ProgressDelegateManager(0, filteredPostalCodes.Count(), statusUpdater);
//                                                 postalCodeStatusManager.Advance(LocalizedStringResourceLoader.GetResource(GetType(), ResourceIndex.ReadPostalCodesForCity, new object[] { currentCity.ToString() }));
//
//                                                 // now load the postal codes
//                                                 cityPostalCodes[currentCity].AddRange(filteredPostalCodes.Select(a => new PostalCode(null, a.postal_code, currentCity, new LatitudeLongitudeCoordinate(Convert.ToDecimal(a.latitude.GetValueOrDefault()), Convert.ToDecimal(a.longitude.GetValueOrDefault())))).ToList());
//                                             }
//                                         }
//                                     }
//
//                                     if (cityPostalCodes.Any())
//                                     {
//                                         postalCodeStatusManager = new ProgressDelegateManager(0, cityPostalCodes.Count, statusUpdater);
//
//                                         foreach (KeyValuePair<City, List<PostalCode>> pcPairs in cityPostalCodes)
//                                         {
//                                             foreach (PostalCode postalCode in pcPairs.Value)
//                                             {
//                                                 if (postalCode.City.StateProvince.ID.Equals(stateProvince.ID))
//                                                 {
//                                                     if (existingPostalCodes.Where(pc => String.Equals(pc.Value, postalCode.Value, StringComparison.InvariantCultureIgnoreCase)).Any())
//                                                     {
//                                                         postalCodeStatusManager.Advance(LocalizedStringResourceLoader.GetResource(GetType(), ResourceIndex.PostalCodeExists, new object[] { postalCode.ToString() }));
//                                                     }
//                                                     else
//                                                     {
//                                                         postalCodeStatusManager.Advance(LocalizedStringResourceLoader.GetResource(GetType(), ResourceIndex.SavePostalCode, new object[] { postalCode.ToString() }));
//                                                         result = repository.Create(postalCode);
//
//                                                         if (!result.IsSuccess)
//                                                         {
//                                                             throw result.Exception;
//                                                         }
//                                                         else
//                                                         {
//                                                             existingPostalCodes.Add(postalCode);
//                                                         }
//                                                     }
//                                                 }
//                                             }
//                                         }
//                                     }
//                                 }
//                             }
//                         }
//                     }
//                     else
//                     {
//                         if (!stateProvinceResults.IsSuccess)
//                         {
//                             throw stateProvinceResults.Exception;
//                         }
//                         else
//                         {
//                             throw cityResults.Exception;
//                         }
//                     }
//
//                     repository.Commit();
//                     transaction.Commit();
//                 }
//                 catch (Exception e)
//                 {
//                     results = new List<WhippetResultContainer<PostalCode>>(new[] { new WhippetResultContainer<PostalCode>(new WhippetResult(e), null) });
//
//                     if (transaction != null)
//                     {
//                         transaction.Rollback();
//                     }
//                 }
//                 finally
//                 {
//                     if (transaction != null)
//                     {
//                         transaction.Dispose();
//                         transaction = null;
//                     }
//                 }
//
//                 return results;
//             }
//         }
//     }
// }
