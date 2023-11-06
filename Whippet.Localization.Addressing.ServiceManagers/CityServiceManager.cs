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
    }
}
