using System;
using System.Collections;
using System.Resources.NetStandard;
using Newtonsoft.Json;
using Athi.Whippet.Services;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Geography;
using Athi.Whippet.Localization.Addressing.Extensions;
using Athi.Whippet.Localization.Addressing.Repositories;
using Athi.Whippet.Localization.Addressing.ServiceManagers.Queries;
using Athi.Whippet.Localization.Addressing.ServiceManagers.Commands;
using Athi.Whippet.Localization.Addressing.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Localization.Addressing.ServiceManagers.Handlers.Commands;
using FluentNHibernate.Conventions;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="ICity"/> domain objects.
    /// </summary>
    public class CityServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="ICityRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual ICityRepository CityRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CityServiceManager"/> class with the specified <see cref="ICityRepository"/> object.
        /// </summary>
        /// <param name="cityRepository"><see cref="ICityRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CityServiceManager(ICityRepository cityRepository)
            : base()
        {
            if (cityRepository == null)
            {
                throw new ArgumentNullException(nameof(cityRepository));
            }
            else
            {
                CityRepository = cityRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CityServiceManager"/> class with the specified <see cref="ICityRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="cityRepository"><see cref="ICityRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CityServiceManager(IWhippetServiceContext serviceLocator, ICityRepository cityRepository)
            : base(serviceLocator)
        {
            if (cityRepository == null)
            {
                throw new ArgumentNullException(nameof(cityRepository));
            }
            else
            {
                CityRepository = cityRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="ICity"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="ICity"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ICity>> GetCity(Guid id)
        {
            ICityQueryHandler<GetCityByIdQuery> handler = new GetCityByIdQueryHandler(CityRepository);
            WhippetResultContainer<IEnumerable<City>> result = await handler.HandleAsync(new GetCityByIdQuery(id));
            return new WhippetResultContainer<ICity>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves the <see cref="ICity"/> object with the specified name and parent <see cref="IStateProvince"/>.
        /// </summary>
        /// <param name="name">Name of the city to retrieve.</param>
        /// <param name="stateProvince"><see cref="IStateProvince"/> the city belongs to.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ICity>> GetCity(string name, IStateProvince stateProvince)
        {
            ICityQueryHandler<GetCitiesByNameAndStateProvinceQuery> handler = new GetCitiesByNameAndStateProvinceQueryHandler(CityRepository);
            WhippetResultContainer<IEnumerable<City>> result = await handler.HandleAsync(new GetCitiesByNameAndStateProvinceQuery(name, stateProvince));
            return new WhippetResultContainer<ICity>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="ICity"/> objects that belong to the specified <see cref="IStateProvince"/>.
        /// </summary>
        /// <param name="stateProvince"><see cref="IStateProvince"/> to get the <see cref="ICity"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<ICity>>> GetCitiesForStateProvince(IStateProvince stateProvince)
        {
            if (stateProvince == null)
            {
                throw new ArgumentNullException(nameof(stateProvince));
            }
            else
            {
                ICityQueryHandler<GetCitiesForStateProvinceQuery> handler = new GetCitiesForStateProvinceQueryHandler(CityRepository);
                WhippetResultContainer<IEnumerable<City>> result = await handler.HandleAsync(new GetCitiesForStateProvinceQuery(stateProvince));
                return new WhippetResultContainer<IEnumerable<ICity>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Creates a new city entry.
        /// </summary>
        /// <param name="server"><see cref="ICity"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ICity"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ICity> CreateCity(ICity city)
        {
            return Task<WhippetResultContainer<ICity>>.Run(() => CreateCityAsync(city)).Result;
        }

        /// <summary>
        /// Creates a new city entry.
        /// </summary>
        /// <param name="city"><see cref="ICity"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ICity"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ICity>> CreateCityAsync(ICity city)
        {
            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateCityCommand> handler = new CreateCityCommandHandler(CityRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateCityCommand(city.ToCity()));

                    if (result.IsSuccess)
                    {
                        await CityRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ICity>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ICity>(result, city);
            }
        }

        /// <summary>
        /// Updates an existing city.
        /// </summary>
        /// <param name="city"><see cref="ICity"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="ICity"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ICity> UpdateCity(ICity city)
        {
            return Task<WhippetResultContainer<ICity>>.Run(() => UpdateCityAsync(city)).Result;
        }

        /// <summary>
        /// Updates an existing city.
        /// </summary>
        /// <param name="city"><see cref="ICity"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="ICity"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ICity>> UpdateCityAsync(ICity city)
        {
            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateCityCommand> handler = new UpdateCityCommandHandler(CityRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateCityCommand(city.ToCity()));

                    if (result.IsSuccess)
                    {
                        await CityRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ICity>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ICity>(result, city);
            }
        }

        /// <summary>
        /// Deletes an existing city.
        /// </summary>
        /// <param name="city"><see cref="ICity"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="ICity"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ICity> DeleteCity(ICity city)
        {
            return Task<WhippetResultContainer<ICity>>.Run(() => DeleteCityAsync(city)).Result;
        }

        /// <summary>
        /// Deletes an existing city.
        /// </summary>
        /// <param name="city"><see cref="ICity"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="ICity"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ICity>> DeleteCityAsync(ICity city)
        {
            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteCityCommand> handler = new DeleteCityCommandHandler(CityRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteCityCommand(city.ToCity()));

                    if (result.IsSuccess)
                    {
                        await CityRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ICity>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ICity>(result, city);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (CityRepository != null)
            {
                CityRepository.Dispose();
                CityRepository = null;
            }

            base.Dispose();
        }
        
        /// <summary>
        /// Service manager that seeds <see cref="StateProvince"/> objects. This class cannot be inherited.
        /// </summary>
        public sealed class CitySeedServiceManager : CityServiceManager, IServiceManager, ISeedServiceManager, IDisposable
        {
            private const string RESOURCE_CITY = "_Cities_PostalCodes";
            
            /// <summary>
            /// Gets or sets all <see cref="IStateProvince"/> objects in the system.
            /// </summary>
            private IEnumerable<IStateProvince> States
            { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="CityServiceManager.CitySeedServiceManager"/> class with the specified <see cref="ICityRepository"/> object.
            /// </summary>
            /// <param name="cityRepository"><see cref="ICityRepository"/> to initialize with.</param>
            /// <param name="states"><see cref="IEnumerable{T}"/> list of <see cref="IStateProvince"/> objects to load cities for.</param>
            /// <exception cref="ArgumentNullException"></exception>
            public CitySeedServiceManager(ICityRepository cityRepository, Func<IEnumerable<IStateProvince>> states)
                : base(cityRepository)
            {
                ArgumentNullException.ThrowIfNull(states);
                States = states();
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="CityServiceManager.CitySeedServiceManager"/> class with the specified <see cref="ICityRepository"/> object.
            /// </summary>
            /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
            /// <param name="cityRepository"><see cref="ICityRepository"/> object to initialize with.</param>
            /// <param name="states"><see cref="IEnumerable{T}"/> list of <see cref="IStateProvince"/> objects to load cities for.</param>
            /// <exception cref="ArgumentNullException"></exception>
            public CitySeedServiceManager(IWhippetServiceContext serviceLocator, ICityRepository cityRepository, Func<IEnumerable<IStateProvince>> states)
                : base(serviceLocator, cityRepository)
            {
                ArgumentNullException.ThrowIfNull(states);
                States = states();
            }

            /// <summary>
            /// Seeds the backing data store for one or more entities.
            /// </summary>
            /// <param name="reportProgress"><see cref="ProgressDelegate"/> that reports the current status to an external caller.</param>
            /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
            public WhippetResult Seed(ProgressDelegate reportProgress = null)
            {
                WhippetResult result = WhippetResult.Success;

                Dictionary<IStateProvince, string> availableCities = null;

                List<KeyValuePair<ICountry, _AddressingJsonModel>> countryCityJson = null;
                List<KeyValuePair<IStateProvince, ICity>> citiesToCreate = null;
                
                IEnumerable<ICountry> countries = null;

                IStateProvince currentState = null;
                ICountry currentCountry = null;
                ICity city = null;

                WhippetResultContainer<ICity> newCity = null;
                WhippetResultContainer<IEnumerable<ICity>> existingCities = null;

                ResXResourceReader resxReader = null;

                _AddressingJsonModel[] models = null;

                Func<IStateProvince, _AddressingJsonModel, ICity> _ConstructCity = (state, model) =>
                {
                    if (model == null)
                    {
                        throw new ArgumentNullException(nameof(model));
                    }
                    else
                    {
                        return new City(null, model.city?.Trim(), state.ToStateProvince(), new LatitudeLongitudeCoordinate(Convert.ToDecimal(model.latitude.GetValueOrDefault()), Convert.ToDecimal(model.longitude.GetValueOrDefault())));
                    }
                };
                
                try
                {
                    availableCities = new Dictionary<IStateProvince, string>();

                    resxReader = new ResXResourceReader(ResourceFileIndex.Addressing_Cities_PostalCodes);

                    countries = States.Select(s => s.Country).DistinctBy(c => c.Abbreviation).Where(c => !String.IsNullOrWhiteSpace(c.Abbreviation) && !String.IsNullOrWhiteSpace(c.Name));

                    countryCityJson = new List<KeyValuePair<ICountry, _AddressingJsonModel>>();
                    citiesToCreate = new List<KeyValuePair<IStateProvince, ICity>>();
                    
                    foreach (DictionaryEntry d in resxReader)
                    {
                        existingCities = null;
                        currentCountry = null;
                        currentState = null;
                        
                        if (d.Key.ToString().EndsWith(RESOURCE_CITY, StringComparison.InvariantCultureIgnoreCase))
                        {
                            models = JsonConvert.DeserializeObject<_AddressingJsonModel[]>(d.Value.ToString());

                            if (models != null && models.Length > 0)
                            {
                                foreach (_AddressingJsonModel model in models)
                                {
                                    if (currentCountry == null || !String.Equals(model.country_code, currentCountry.Abbreviation, StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        currentCountry = (from c in countries where String.Equals(c.Abbreviation, model.country_code, StringComparison.InvariantCultureIgnoreCase) select c).FirstOrDefault();
                                    }

                                    if (currentCountry != null)
                                    {
                                        countryCityJson.Add(new KeyValuePair<ICountry, _AddressingJsonModel>(currentCountry, model));
                                    }
                                }
                            }

                            if (countryCityJson != null && countryCityJson.Count > 0)
                            {
                                foreach (_AddressingJsonModel model in countryCityJson.Select(ccj => ccj.Value))
                                {
                                    if (currentState == null || !String.Equals(model.state_code?.Trim(), currentState.Abbreviation, StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        currentState = (from s in States where String.Equals(model.state_code?.Trim(), s.Abbreviation, StringComparison.InvariantCultureIgnoreCase) && String.Equals(s.Country.Abbreviation, model.country_code?.Trim(), StringComparison.InvariantCultureIgnoreCase) select s).FirstOrDefault();

                                        if (currentState != null)
                                        {
                                            existingCities = Task.Run(() => GetCitiesForStateProvince(currentState)).Result;
                                            existingCities.ThrowIfFailed();
                                        }
                                    }

                                    if (currentState != null)
                                    {
                                        if ((existingCities != null) && (existingCities.HasItem && existingCities.Item.Any()))
                                        {
                                            if (!existingCities.Item.Where(city => String.Equals(model.city?.Trim(), city.Name, StringComparison.InvariantCultureIgnoreCase) && String.Equals(model.state_code?.Trim(), city.StateProvince.Abbreviation, StringComparison.InvariantCultureIgnoreCase)).Any())
                                            {
                                                citiesToCreate.Add(new KeyValuePair<IStateProvince, ICity>(currentState, _ConstructCity(currentState, model)));
                                            }
                                        }
                                        else
                                        {
                                            citiesToCreate.Add(new KeyValuePair<IStateProvince, ICity>(currentState, _ConstructCity(currentState, model)));
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                    if (citiesToCreate != null && citiesToCreate.Count > 0)
                    {
                        foreach (KeyValuePair<IStateProvince, ICity> entry in citiesToCreate)
                        {
                            newCity = CreateCity(entry.Value);
                            newCity.ThrowIfFailed();
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
        
    }
}
