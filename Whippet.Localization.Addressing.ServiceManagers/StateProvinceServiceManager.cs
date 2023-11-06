using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using NodaTime;
using Athi.Whippet;
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
    }
}
