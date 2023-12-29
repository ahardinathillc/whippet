using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Resources.NetStandard;
using Athi.Whippet.Services;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Geography;
using Athi.Whippet.Localization.Addressing.Extensions;
using Athi.Whippet.Localization.Addressing.Repositories;
using Athi.Whippet.Localization.Addressing.ServiceManagers.Queries;
using Athi.Whippet.Localization.Addressing.ServiceManagers.Commands;
using Athi.Whippet.Localization.Addressing.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Localization.Addressing.ServiceManagers.Handlers.Commands;
using Newtonsoft.Json;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IPostalCode"/> domain objects.
    /// </summary>
    public class PostalCodeServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IPostalCodeRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IPostalCodeRepository PostalCodeRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostalCodeServiceManager"/> class with the specified <see cref="IPostalCodeRepository"/> object.
        /// </summary>
        /// <param name="postalCodeRepository"><see cref="IPostalCodeRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public PostalCodeServiceManager(IPostalCodeRepository postalCodeRepository)
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
        /// Initializes a new instance of the <see cref="PostalCodeServiceManager"/> class with the specified <see cref="IPostalCodeRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="postalCodeRepository"><see cref="IPostalCodeRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public PostalCodeServiceManager(IWhippetServiceContext serviceLocator, IPostalCodeRepository postalCodeRepository)
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
        /// Retrieves all <see cref="IPostalCode"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IPostalCode>>> GetAllPostalCodes()
        {
            IPostalCodeQueryHandler<GetAllPostalCodesQuery> handler = new GetAllPostalCodesQueryHandler(PostalCodeRepository);
            WhippetResultContainer<IEnumerable<PostalCode>> result = await handler.HandleAsync(new GetAllPostalCodesQuery());
            return new WhippetResultContainer<IEnumerable<IPostalCode>>(result.Result, result.Item);
        }

        /// <summary>
        /// Retrieves all <see cref="IPostalCode"/> objects registered in the data store for the specified <see cref="ICity"/>.
        /// </summary>
        /// <param name="city"><see cref="ICity"/> to retrieve postal codes for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IPostalCode>>> GetPostalCodes(ICity city)
        {
            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }
            else
            {
                IPostalCodeQueryHandler<GetAllPostalCodesForCityQuery> handler = new GetAllPostalCodesForCityQueryHandler(PostalCodeRepository);
                WhippetResultContainer<IEnumerable<PostalCode>> result = await handler.HandleAsync(new GetAllPostalCodesForCityQuery(city));
                return new WhippetResultContainer<IEnumerable<IPostalCode>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Retrieves all <see cref="IPostalCode"/> object(s) that match the specified value.
        /// </summary>
        /// <param name="postalCodeValue"><see cref="IPostalCode"/> value to search for.</param>
        /// <param name="city">Optional <see cref="ICity"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IPostalCode>>> GetPostalCodes(string postalCodeValue, ICity city = null)
        {
            if (String.IsNullOrWhiteSpace(postalCodeValue))
            {
                throw new ArgumentNullException(nameof(postalCodeValue));
            }
            else
            {
                IPostalCodeQueryHandler<GetPostalCodesQuery> handler = new GetPostalCodesQueryHandler(PostalCodeRepository);
                WhippetResultContainer<IEnumerable<PostalCode>> result = await handler.HandleAsync(new GetPostalCodesQuery(postalCodeValue, city));
                return new WhippetResultContainer<IEnumerable<IPostalCode>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Creates a new postalCode entry.
        /// </summary>
        /// <param name="server"><see cref="IPostalCode"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IPostalCode"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IPostalCode> CreatePostalCode(IPostalCode postalCode)
        {
            return Task<WhippetResultContainer<IPostalCode>>.Run(() => CreatePostalCodeAsync(postalCode)).Result;
        }

        /// <summary>
        /// Creates a new postalCode entry.
        /// </summary>
        /// <param name="postalCode"><see cref="IPostalCode"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IPostalCode"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IPostalCode>> CreatePostalCodeAsync(IPostalCode postalCode)
        {
            if (postalCode == null)
            {
                throw new ArgumentNullException(nameof(postalCode));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreatePostalCodeCommand> handler = new CreatePostalCodeCommandHandler(PostalCodeRepository);

                try
                {
                    result = await handler.HandleAsync(new CreatePostalCodeCommand(postalCode.ToPostalCode()));

                    if (result.IsSuccess)
                    {
                        await PostalCodeRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IPostalCode>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IPostalCode>(result, postalCode);
            }
        }

        /// <summary>
        /// Updates an existing postalCode.
        /// </summary>
        /// <param name="postalCode"><see cref="IPostalCode"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IPostalCode"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IPostalCode> UpdatePostalCode(IPostalCode postalCode)
        {
            return Task<WhippetResultContainer<IPostalCode>>.Run(() => UpdatePostalCodeAsync(postalCode)).Result;
        }

        /// <summary>
        /// Updates an existing postalCode.
        /// </summary>
        /// <param name="postalCode"><see cref="IPostalCode"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IPostalCode"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IPostalCode>> UpdatePostalCodeAsync(IPostalCode postalCode)
        {
            if (postalCode == null)
            {
                throw new ArgumentNullException(nameof(postalCode));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdatePostalCodeCommand> handler = new UpdatePostalCodeCommandHandler(PostalCodeRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdatePostalCodeCommand(postalCode.ToPostalCode()));

                    if (result.IsSuccess)
                    {
                        await PostalCodeRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IPostalCode>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IPostalCode>(result, postalCode);
            }
        }

        /// <summary>
        /// Deletes an existing postalCode.
        /// </summary>
        /// <param name="postalCode"><see cref="IPostalCode"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IPostalCode"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IPostalCode> DeletePostalCode(IPostalCode postalCode)
        {
            return Task<WhippetResultContainer<IPostalCode>>.Run(() => DeletePostalCodeAsync(postalCode)).Result;
        }

        /// <summary>
        /// Deletes an existing postalCode.
        /// </summary>
        /// <param name="postalCode"><see cref="IPostalCode"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IPostalCode"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IPostalCode>> DeletePostalCodeAsync(IPostalCode postalCode)
        {
            if (postalCode == null)
            {
                throw new ArgumentNullException(nameof(postalCode));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeletePostalCodeCommand> handler = new DeletePostalCodeCommandHandler(PostalCodeRepository);

                try
                {
                    result = await handler.HandleAsync(new DeletePostalCodeCommand(postalCode.ToPostalCode()));

                    if (result.IsSuccess)
                    {
                        await PostalCodeRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IPostalCode>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IPostalCode>(result, postalCode);
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
        
        /// <summary>
        /// Service manager that seeds <see cref="PostalCode"/> objects. This class cannot be inherited.
        /// </summary>
        public sealed class PostalCodeSeedServiceManager : PostalCodeServiceManager, IServiceManager, ISeedServiceManager, IDisposable
        {
            private const string RESOURCE_CITY = "_Cities_PostalCodes";

            private const byte INDEX_ABBR = 0;
            
            private IReadOnlyList<ICity> _cities;
            
            private readonly Func<IEnumerable<ICity>> _LoadCities;
            
            /// <summary>
            /// Represents all <see cref="ICity"/> objects in the system. This property is read-only.
            /// </summary>
            private IEnumerable<ICity> Cities
            {
                get
                {
                    if (_cities == null || ((_cities != null) && (_cities.Count == 0)))
                    {
                        _cities = new ReadOnlyCollection<ICity>(_LoadCities().ToList());
                    }

                    return _cities;
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="PostalCodeServiceManager.PostalCodeSeedServiceManager"/> class with the specified <see cref="IPostalCodeRepository"/> object.
            /// </summary>
            /// <param name="postalCodeRepository"><see cref="IPostalCodeRepository"/> to initialize with.</param>
            /// <param name="cities"><see cref="IEnumerable{T}"/> list of <see cref="ICity"/> objects to load cities for.</param>
            /// <exception cref="ArgumentNullException"></exception>
            public PostalCodeSeedServiceManager(IPostalCodeRepository postalCodeRepository, Func<IEnumerable<ICity>> cities)
                : base(postalCodeRepository)
            {
                ArgumentNullException.ThrowIfNull(cities);
                _LoadCities = cities;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="PostalCodeServiceManager.PostalCodeSeedServiceManager"/> class with the specified <see cref="IPostalCodeRepository"/> object.
            /// </summary>
            /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
            /// <param name="postalCodeRepository"><see cref="IPostalCodeRepository"/> object to initialize with.</param>
            /// <param name="cities"><see cref="IEnumerable{T}"/> list of <see cref="ICity"/> objects to load cities for.</param>
            /// <exception cref="ArgumentNullException"></exception>
            public PostalCodeSeedServiceManager(IWhippetServiceContext serviceLocator, IPostalCodeRepository postalCodeRepository, Func<IEnumerable<ICity>> cities)
                : base(serviceLocator, postalCodeRepository)
            {
                ArgumentNullException.ThrowIfNull(cities);
                _LoadCities = cities;
            }

            /// <summary>
            /// Seeds the backing data store for one or more entities.
            /// </summary>
            /// <param name="reportProgress"><see cref="ProgressDelegate"/> that reports the current status to an external caller.</param>
            /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
            public WhippetResult Seed(ProgressDelegate reportProgress = null)
            {
                WhippetResult result = WhippetResult.Success;

                List<KeyValuePair<ICountry, _AddressingJsonModel>> countryCityJson = null;
                List<KeyValuePair<ICity, IPostalCode>> postalCodesToCreate = null;
                
                IEnumerable<ICountry> countries = null;
                IEnumerable<IStateProvince> states = null;
                
                IStateProvince currentState = null;
                ICountry currentCountry = null;
                ICity currentCity = null;
                IPostalCode postalCode = null;

                WhippetResultContainer<IPostalCode> newPostalCode = null;
                
                WhippetResultContainer<IEnumerable<ICity>> existingCities = null;
                WhippetResultContainer<IEnumerable<IPostalCode>> existingPostalCodes = null;
                
                ResXResourceReader resxReader = null;

                _AddressingJsonModel[] models = null;

                string[] keyPieces = null;
                
                Func<ICity, _AddressingJsonModel, IPostalCode> _ConstructPostalCode = (city, model) =>
                {
                    if (model == null)
                    {
                        throw new ArgumentNullException(nameof(model));
                    }
                    else
                    {
                        return new PostalCode(null, model.postal_code, city.ToCity(), new LatitudeLongitudeCoordinate(Convert.ToDouble(model.latitude.GetValueOrDefault()), Convert.ToDouble(model.longitude.GetValueOrDefault())));
                    }
                };

                Func<_AddressingJsonModel, IStateProvince, bool> _StateProvinceEquals = (model, state) =>
                {
                    if (model == null)
                    {
                        throw new ArgumentNullException(nameof(model));
                    }
                    else if (state == null)
                    {
                        throw new ArgumentNullException(nameof(state));
                    }
                    else
                    {
                        bool equals = false;

                        if (String.IsNullOrWhiteSpace(model.state_code))
                        {
                            equals = String.Equals(model.state?.Trim(), state.Abbreviation, StringComparison.InvariantCultureIgnoreCase) || String.Equals(model.state?.Trim(), state.Name, StringComparison.InvariantCultureIgnoreCase);
                        }
                        else
                        {
                            equals = (String.Equals(model.state?.Trim(), state.Abbreviation, StringComparison.InvariantCultureIgnoreCase) || String.Equals(model.state?.Trim(), state.Name, StringComparison.InvariantCultureIgnoreCase))
                                     || (String.Equals(model.state_code?.Trim(), state.Abbreviation, StringComparison.InvariantCultureIgnoreCase) || String.Equals(model.state_code?.Trim(), state.Name, StringComparison.InvariantCultureIgnoreCase));
                        }

                        return equals;
                    }
                };

                Func<_AddressingJsonModel, ICity, bool> _CityEquals = (model, city) =>
                {
                    if (model == null)
                    {
                        throw new ArgumentNullException(nameof(model));
                    }
                    else if (city == null)
                    {
                        throw new ArgumentNullException(nameof(city));
                    }
                    else
                    {
                        bool equals = _StateProvinceEquals(model, city.StateProvince);

                        if (equals)
                        {
                            equals = String.Equals(model.city?.Trim(), city.Name, StringComparison.InvariantCultureIgnoreCase)
                                     && LatitudeLongitudeCoordinate.Null.Equals(city.Coordinates, new LatitudeLongitudeCoordinate(Convert.ToDouble(model.latitude.GetValueOrDefault()), Convert.ToDouble(model.longitude.GetValueOrDefault())))
                                     && String.Equals(city.StateProvince.Country.Abbreviation, model.country_code?.Trim(), StringComparison.InvariantCultureIgnoreCase);
                        }

                        return equals;
                    }
                };
                
                try
                {
                    resxReader = new ResXResourceReader(ResourceFileIndex.Addressing_Cities_PostalCodes);
                    countries = Cities.Select(c => c.StateProvince.Country).DistinctBy(c => c.Abbreviation).Where(c => !String.IsNullOrWhiteSpace(c.Abbreviation) && !String.IsNullOrWhiteSpace(c.Name));
                    countryCityJson = new List<KeyValuePair<ICountry, _AddressingJsonModel>>();
                    
                    foreach (DictionaryEntry d in resxReader)
                    {
                        existingPostalCodes = null;
                        currentCountry = null;

                        if (d.Key.ToString().EndsWith(RESOURCE_CITY, StringComparison.InvariantCultureIgnoreCase))
                        {
                            keyPieces = d.Key.ToString().Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                            if (keyPieces != null && keyPieces.Length > 1) // should have at least two
                            {
                                if (!String.IsNullOrWhiteSpace(keyPieces[INDEX_ABBR]) && keyPieces[INDEX_ABBR].Length == 2) // abbreviation is two digits long
                                {
                                    currentCountry = (from c in countries where String.Equals(c.Abbreviation, keyPieces[INDEX_ABBR], StringComparison.InvariantCultureIgnoreCase) select c).FirstOrDefault();
                                }
                            }

                            if (currentCountry != null)
                            {
                                models = JsonConvert.DeserializeObject<_AddressingJsonModel[]>(d.Value.ToString());

                                if (models != null && models.Length > 0)
                                {
                                    countryCityJson.AddRange(models.Select(m => new KeyValuePair<ICountry, _AddressingJsonModel>(currentCountry, m)));
                                }

                                if (countryCityJson != null && countryCityJson.Count > 0)
                                {
                                    foreach (_AddressingJsonModel model in countryCityJson.Where(ccj => ccj.Key.Equals(currentCountry)).Select(ccj => ccj.Value))
                                    {
                                        if (currentCity == null || ((currentCity != null) && !_CityEquals(model, currentCity)))
                                        {
                                            currentCity = (
                                                from c in Cities 
                                                where _CityEquals(model, c)
                                                select c).FirstOrDefault();

                                            if (currentCity != null)
                                            {
                                                existingPostalCodes = Task.Run(() => GetPostalCodes(currentCity)).Result;
                                                existingPostalCodes.ThrowIfFailed();
                                            }
                                        }
                                        
                                        if (currentCity != null)
                                        {
                                            if ((existingPostalCodes != null) && (existingPostalCodes.HasItem && existingPostalCodes.Item.Any()))
                                            {
                                                if (!(from epc in existingPostalCodes.Item
                                                        where String.Equals(epc.Value, model.postal_code?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                                            && _CityEquals(model, epc.City)
                                                        select epc).Any()
                                                   )
                                                {
                                                    postalCodesToCreate.Add(new KeyValuePair<ICity, IPostalCode>(currentCity, _ConstructPostalCode(currentCity, model)));
                                                }
                                            }
                                            else
                                            {
                                                postalCodesToCreate.Add(new KeyValuePair<ICity, IPostalCode>(currentCity, _ConstructPostalCode(currentCity, model)));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                    if (postalCodesToCreate != null && postalCodesToCreate.Count > 0)
                    {
                        foreach (KeyValuePair<ICity, IPostalCode> entry in postalCodesToCreate)
                        {
                            newPostalCode = CreatePostalCode(entry.Value);
                            newPostalCode.ThrowIfFailed();
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
