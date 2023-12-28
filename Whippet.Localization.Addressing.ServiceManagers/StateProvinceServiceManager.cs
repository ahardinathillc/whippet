using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Resources.NetStandard;
using Athi.Whippet.Services;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Localization.Addressing.Extensions;
using Athi.Whippet.Localization.Addressing.Repositories;
using Athi.Whippet.Localization.Addressing.ServiceManagers.Queries;
using Athi.Whippet.Localization.Addressing.ServiceManagers.Commands;
using Athi.Whippet.Localization.Addressing.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Localization.Addressing.ServiceManagers.Handlers.Commands;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IStateProvince"/> domain objects.
    /// </summary>
    public class StateProvinceServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IStateProvinceRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IStateProvinceRepository StateRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateProvinceServiceManager"/> class with the specified <see cref="IStateProvinceRepository"/> object.
        /// </summary>
        /// <param name="stateRepository"><see cref="IStateProvinceRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public StateProvinceServiceManager(IStateProvinceRepository stateRepository)
            : base()
        {
            if (stateRepository == null)
            {
                throw new ArgumentNullException(nameof(stateRepository));
            }
            else
            {
                StateRepository = stateRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateProvinceServiceManager"/> class with the specified <see cref="IStateProvinceRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="stateRepository"><see cref="IStateProvinceRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public StateProvinceServiceManager(IWhippetServiceContext serviceLocator, IStateProvinceRepository stateRepository)
            : base(serviceLocator)
        {
            if (stateRepository == null)
            {
                throw new ArgumentNullException(nameof(stateRepository));
            }
            else
            {
                StateRepository = stateRepository;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="IStateProvince"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IStateProvince>>> GetAllStateProvinces()
        {
            IStateProvinceQueryHandler<GetAllStateProvincesQuery> handler = new GetAllStateProvincesQueryHandler(StateRepository);
            WhippetResultContainer<IEnumerable<StateProvince>> result = await handler.HandleAsync(new GetAllStateProvincesQuery());
            return new WhippetResultContainer<IEnumerable<IStateProvince>>(result.Result, result.Item);
        }

        /// <summary>
        /// Retrieves the <see cref="IStateProvince"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IStateProvince"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IStateProvince>> GetStateProvince(Guid id)
        {
            IStateProvinceQueryHandler<GetStateProvinceByIdQuery> handler = new GetStateProvinceByIdQueryHandler(StateRepository);
            WhippetResultContainer<IEnumerable<StateProvince>> result = await handler.HandleAsync(new GetStateProvinceByIdQuery(id));
            return new WhippetResultContainer<IStateProvince>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="IStateProvince"/> objects that belong to the specified <see cref="ICountry"/>.
        /// </summary>
        /// <param name="country"><see cref="ICountry"/> to get the <see cref="IStateProvince"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IStateProvince>>> GetStateProvincesForCountry(ICountry country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            else
            {
                IStateProvinceQueryHandler<GetAllStateProvincesForCountryQuery> handler = new GetAllStateProvincesForCountryQueryHandler(StateRepository);
                WhippetResultContainer<IEnumerable<StateProvince>> result = await handler.HandleAsync(new GetAllStateProvincesForCountryQuery(country));
                return new WhippetResultContainer<IEnumerable<IStateProvince>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Retrieves the <see cref="IStateProvince"/> object with the specified name.
        /// </summary>
        /// <param name="name">Name of the <see cref="IStateProvince"/> to retrieve.</param>
        /// <param name="country"><see cref="ICountry"/> where the <see cref="IStateProvince"/> is located.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IStateProvince>> GetStateProvinceByName(string name, ICountry country)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            else
            {
                IStateProvinceQueryHandler<GetStateProvinceByNameQuery> handler = new GetStateProvinceByNameQueryHandler(StateRepository);
                WhippetResultContainer<IEnumerable<StateProvince>> result = await handler.HandleAsync(new GetStateProvinceByNameQuery(name, country));
                return new WhippetResultContainer<IStateProvince>(result.Result, result.Item?.FirstOrDefault());
            }
        }

        /// <summary>
        /// Retrieves the <see cref="IStateProvince"/> object with the specified abbreviation.
        /// </summary>
        /// <param name="abbreviation">Abbreviation of the <see cref="IStateProvince"/> to retrieve.</param>
        /// <param name="country"><see cref="ICountry"/> where the <see cref="IStateProvince"/> is located.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IStateProvince>> GetStateProvinceByAbbreviation(string abbreviation, ICountry country)
        {
            if (String.IsNullOrWhiteSpace(abbreviation))
            {
                throw new ArgumentNullException(nameof(abbreviation));
            }
            else if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            else
            {
                WhippetResultContainer<IEnumerable<IStateProvince>> result = await GetStateProvincesForCountry(country);
                WhippetResultContainer<IStateProvince> toReturn = null;

                if (result.IsSuccess)
                {
                    toReturn = new WhippetResultContainer<IStateProvince>(result.Result, result.HasItem ? result.Item.Where(s => String.Equals(s.Abbreviation, abbreviation, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault() : null);
                }
                else
                {
                    toReturn = new WhippetResultContainer<IStateProvince>(result.Result, null);
                }

                return toReturn;
            }
        }

        /// <summary>
        /// Creates a new state/province entry.
        /// </summary>
        /// <param name="server"><see cref="IStateProvince"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IStateProvince"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IStateProvince> CreateStateProvince(IStateProvince state)
        {
            return Task<WhippetResultContainer<IStateProvince>>.Run(() => CreateStateProvinceAsync(state)).Result;
        }

        /// <summary>
        /// Creates a new state/province entry.
        /// </summary>
        /// <param name="state"><see cref="IStateProvince"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IStateProvince"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IStateProvince>> CreateStateProvinceAsync(IStateProvince state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateStateProvinceCommand> handler = new CreateStateProvinceCommandHandler(StateRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateStateProvinceCommand(state.ToStateProvince()));

                    if (result.IsSuccess)
                    {
                        await StateRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IStateProvince>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IStateProvince>(result, state);
            }
        }

        /// <summary>
        /// Updates an existing state/province.
        /// </summary>
        /// <param name="state"><see cref="IStateProvince"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IStateProvince"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IStateProvince> UpdateStateProvince(IStateProvince state)
        {
            return Task<WhippetResultContainer<IStateProvince>>.Run(() => UpdateStateProvinceAsync(state)).Result;
        }

        /// <summary>
        /// Updates an existing state/province.
        /// </summary>
        /// <param name="state"><see cref="IStateProvince"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IStateProvince"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IStateProvince>> UpdateStateProvinceAsync(IStateProvince state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateStateProvinceCommand> handler = new UpdateStateProvinceCommandHandler(StateRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateStateProvinceCommand(state.ToStateProvince()));

                    if (result.IsSuccess)
                    {
                        await StateRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IStateProvince>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IStateProvince>(result, state);
            }
        }

        /// <summary>
        /// Deletes an existing state/province.
        /// </summary>
        /// <param name="state"><see cref="IStateProvince"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IStateProvince"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IStateProvince> DeleteStateProvince(IStateProvince state)
        {
            return Task<WhippetResultContainer<IStateProvince>>.Run(() => DeleteStateProvinceAsync(state)).Result;
        }

        /// <summary>
        /// Deletes an existing state/province.
        /// </summary>
        /// <param name="state"><see cref="IStateProvince"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IStateProvince"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IStateProvince>> DeleteStateProvinceAsync(IStateProvince state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteStateProvinceCommand> handler = new DeleteStateProvinceCommandHandler(StateRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteStateProvinceCommand(state.ToStateProvince()));

                    if (result.IsSuccess)
                    {
                        await StateRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IStateProvince>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IStateProvince>(result, state);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (StateRepository != null)
            {
                StateRepository.Dispose();
                StateRepository = null;
            }

            base.Dispose();
        }
        
        /// <summary>
        /// Service manager that seeds <see cref="StateProvince"/> objects. This class cannot be inherited.
        /// </summary>
        public sealed class StateProvinceSeedServiceManager : StateProvinceServiceManager, IServiceManager, ISeedServiceManager, IDisposable
        {
            private const string RESOURCE_STATEPROVINCE = "_StateProvinces";
            
            /// <summary>
            /// Gets or sets all <see cref="ICountry"/> objects in the system.
            /// </summary>
            private IEnumerable<ICountry> Countries
            { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="StateProvinceServiceManager.StateProvinceSeedServiceManager"/> class with the specified <see cref="IStateProvinceRepository"/> object.
            /// </summary>
            /// <param name="stateRepository"><see cref="IStateProvinceRepository"/> to initialize with.</param>
            /// <param name="countries"><see cref="IEnumerable{T}"/> list of <see cref="ICountry"/> objects to load states for.</param>
            /// <exception cref="ArgumentNullException"></exception>
            public StateProvinceSeedServiceManager(IStateProvinceRepository stateRepository, Func<IEnumerable<ICountry>> countries)
                : base(stateRepository)
            {
                ArgumentNullException.ThrowIfNull(countries);
                Countries = countries();
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="StateProvinceServiceManager.StateProvinceSeedServiceManager"/> class with the specified <see cref="IStateProvinceRepository"/> object.
            /// </summary>
            /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
            /// <param name="stateRepository"><see cref="IStateProvinceRepository"/> object to initialize with.</param>
            /// <param name="countries"><see cref="IEnumerable{T}"/> list of <see cref="ICountry"/> objects to load states for.</param>
            /// <exception cref="ArgumentNullException"></exception>
            public StateProvinceSeedServiceManager(IWhippetServiceContext serviceLocator, IStateProvinceRepository stateRepository, Func<IEnumerable<ICountry>> countries)
                : base(serviceLocator, stateRepository)
            {
                ArgumentNullException.ThrowIfNull(countries);
                Countries = countries();
            }

            /// <summary>
            /// Seeds the backing data store for one or more entities.
            /// </summary>
            /// <param name="reportProgress"><see cref="ProgressDelegate"/> that reports the current status to an external caller.</param>
            /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
            public WhippetResult Seed(ProgressDelegate reportProgress = null)
            {
                const byte INDEX_ABBR = 0;
                const byte INDEX_NAME = 1;

                WhippetResult result = WhippetResult.Success;

                Dictionary<string, string> availableStateProvinces = null;

                ICountry currentCountry = null;
                IStateProvince stateProvince = null;

                WhippetResultContainer<IStateProvince> newState = null;
                WhippetResultContainer<IEnumerable<IStateProvince>> existingStates = null;

                string[] lines = null;
                string[] pieces = null;

                ResXResourceReader resxReader = null;

                try
                {
                    availableStateProvinces = new Dictionary<string, string>();
                    
                    resxReader = new ResXResourceReader(ResourceFileIndex.Addressing_StateProvinces);
                    
                    foreach (DictionaryEntry d in resxReader)
                    {
                        if (d.Key.ToString().EndsWith(RESOURCE_STATEPROVINCE, StringComparison.InvariantCultureIgnoreCase))
                        {
                            availableStateProvinces.Add(d.Key.ToString().Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)[0], d.Value.ToString());
                        }
                    }

                    if (availableStateProvinces != null && availableStateProvinces.Count > 0)
                    {
                        // the countries are listed by their ISO-2 code with an underscore

                        foreach (KeyValuePair<string, string> entry in availableStateProvinces)
                        {
                            currentCountry = (from c in Countries where String.Equals(c.Abbreviation, entry.Key.Substring(0, 2), StringComparison.InvariantCultureIgnoreCase) select c).FirstOrDefault();

                            if (currentCountry != null)
                            {
                                existingStates = Task.Run(() => GetStateProvincesForCountry(currentCountry)).Result;
                                existingStates.ThrowIfFailed();

                                lines = entry.Value.Split(new char[] { ',' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

                                if (lines != null && lines.Length > 0)
                                {
                                    for (int i = 0; i < lines.Length; i++)
                                    {
                                        if (reportProgress != null)
                                        {
                                            reportProgress(Convert.ToInt32(Convert.ToDouble(i) / Convert.ToDouble(lines.Length)), "Creating states", WhippetResultSeverity.Info);
                                        }
                                        
                                        lines[i] = lines[i].Replace('"', ' ');
                                        lines[i] = lines[i].Trim();

                                        pieces = lines[i].Split(new char[] { ':' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

                                        stateProvince = new StateProvince(null, pieces[INDEX_NAME], pieces[INDEX_ABBR], currentCountry.ToCountry());

                                        if (!existingStates.HasItem || (existingStates.HasItem && !existingStates.Item.Where(s => String.Equals(s.Name, stateProvince.Name, StringComparison.InvariantCultureIgnoreCase)).Any()))
                                        {
                                            newState = CreateStateProvince(stateProvince);
                                            newState.ThrowIfFailed();
                                        }
                                    }
                                }
                            }
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
