using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Nito.AsyncEx;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Queries;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories;
using Athi.Whippet.Threading.Tasks.Extensions;
using Athi.Whippet.Localization.Addressing;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IMultichannelOrderManagerStateProvince"/> domain objects.
    /// </summary>
    public class MultichannelOrderManagerStateProvinceServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerStateProvinceRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IMultichannelOrderManagerStateProvinceRepository StateProvinceRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerStateProvinceServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerOrderItemRepository"/>.
        /// </summary>
        /// <param name="stateProvinceRepository"><see cref="IMultichannelOrderManagerOrder"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerStateProvinceServiceManager(IMultichannelOrderManagerStateProvinceRepository stateProvinceRepository)
            : base()
        {
            if (stateProvinceRepository == null)
            {
                throw new ArgumentNullException(nameof(stateProvinceRepository));
            }
            else
            {
                StateProvinceRepository = stateProvinceRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerStateProvinceServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerStateProvinceRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="stateProvinceRepository"><see cref="IMultichannelOrderManagerStateProvinceRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerStateProvinceServiceManager(IWhippetServiceContext serviceLocator, IMultichannelOrderManagerStateProvinceRepository stateProvinceRepository)
            : base(serviceLocator)
        {
            if (stateProvinceRepository == null)
            {
                throw new ArgumentNullException(nameof(stateProvinceRepository));
            }
            else
            {
                StateProvinceRepository = stateProvinceRepository;
            }
        }

        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerStateProvince"/> with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IMultichannelOrderManagerStateProvince"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IMultichannelOrderManagerStateProvince>> GetStateProvince(long id)
        {
            IMultichannelOrderManagerStateProvinceQueryHandler<GetMultichannelOrderManagerStateProvinceByIdQuery> handler = new GetMultichannelOrderManagerStateProvinceByIdQueryHandler(StateProvinceRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>> result = await handler.HandleAsync(new GetMultichannelOrderManagerStateProvinceByIdQuery(id));
            return new WhippetResultContainer<IMultichannelOrderManagerStateProvince>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerStateProvince"/> that has the specified <see cref="IMultichannelOrderManagerPostalCode"/>.
        /// </summary>
        /// <param name="postalCode"><see cref="IMultichannelOrderManagerPostalCode"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IMultichannelOrderManagerStateProvince>> GetStateProvince(IMultichannelOrderManagerPostalCode postalCode)
        {
            if (postalCode == null)
            {
                throw new ArgumentNullException(nameof(postalCode));
            }
            else
            {
                IMultichannelOrderManagerStateProvinceQueryHandler<GetMultichannelOrderManagerStateProvinceByPostalCodeQuery> handler = new GetMultichannelOrderManagerStateProvinceByPostalCodeQueryHandler(StateProvinceRepository);
                WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>> result = await handler.HandleAsync(new GetMultichannelOrderManagerStateProvinceByPostalCodeQuery(postalCode));
                return new WhippetResultContainer<IMultichannelOrderManagerStateProvince>(result.Result, result.Item.FirstOrDefault());
            }
        }

        /// <summary>
        /// Gets all <see cref="IMultichannelOrderManagerStateProvince"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerStateProvince>>> GetStateProvinces()
        {
            IMultichannelOrderManagerStateProvinceQueryHandler<GetAllMultichannelOrderManagerStateProvincesQuery> handler = new GetAllMultichannelOrderManagerStateProvincesQueryHandler(StateProvinceRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>> result = await handler.HandleAsync(new GetAllMultichannelOrderManagerStateProvincesQuery());
            return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerStateProvince>>(result.Result, result.Item);
        }

        /// <summary>
        /// Assigns <see cref="IMultichannelOrderManagerWarehouse"/> objects to the provided collection of <see cref="IMultichannelOrderManagerStateProvince"/> objects.
        /// </summary>
        /// <param name="states"><see cref="IMultichannelOrderManagerStateProvince"/> collection.</param>
        /// <param name="warehouses"><see cref="IMultichannelOrderManagerWarehouse"/> collection.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation and populated <see cref="IMultichannelOrderManagerWarehouse"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerStateProvince>>> AssignWarehouses(IEnumerable<IMultichannelOrderManagerStateProvince> states, IEnumerable<IMultichannelOrderManagerWarehouse> warehouses)
        {
            if (states == null)
            {
                throw new ArgumentNullException(nameof(states));
            }
            else if (warehouses == null)
            {
                throw new ArgumentNullException(nameof(warehouses));
            }
            else
            {
                WhippetResultContainer<IEnumerable<IMultichannelOrderManagerStateProvince>> result = null;

                ConcurrentBag<IMultichannelOrderManagerStateProvince> concurrentCounties = new ConcurrentBag<IMultichannelOrderManagerStateProvince>();
                AsyncCollection<IMultichannelOrderManagerStateProvince> asyncCounties = new AsyncCollection<IMultichannelOrderManagerStateProvince>(concurrentCounties);

                ParallelOptions pOptions = new ParallelOptions();
                pOptions = pOptions.DetermineOptimalCoreCount();

                if (warehouses.Any() && states.Any())
                {
                    states = new SortedSet<IMultichannelOrderManagerStateProvince>(states, IMultichannelOrderManagerStateProvinceComparer.Instance);

                    try
                    {
                        await Parallel.ForEachAsync<IMultichannelOrderManagerStateProvince>(states, pOptions, async (state, cancellationToken) =>
                        {
                            IMultichannelOrderManagerWarehouse warehouse = null;
                            IMultichannelOrderManagerStateProvince newStateProvince = state.Clone<IMultichannelOrderManagerStateProvince>();

                            if ((state.Warehouse != null) && ((state.Warehouse.WarehouseID != 0) || !String.IsNullOrWhiteSpace(state.Warehouse.Code)))
                            {
                                if (state.Warehouse.WarehouseID != 0)
                                {
                                    warehouse = warehouses.Where(w => w.WarehouseID == state.Warehouse.WarehouseID).FirstOrDefault();
                                }
                                else
                                {
                                    warehouse = warehouses.Where(w => String.Equals(w.Code?.Trim(), state.Warehouse.Code?.Trim(), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                                }
                            }

                            if (warehouse == null)
                            {
                                // default to the first warehouse for that country or, if null, default to first warehouse

                                warehouse = warehouses.Where(w => !String.IsNullOrWhiteSpace(w.Country) && String.Equals(w.Country?.Trim(), state.Country?.CountryCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                                if (warehouse == null)
                                {
                                    warehouse = warehouses.First();
                                }
                            }

                            newStateProvince.Warehouse = warehouse;

                            await asyncCounties.AddAsync(newStateProvince);     // no warehouse is a valid entry
                        });
                    }
                    catch (Exception e)
                    {
                        result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerStateProvince>>(e);
                    }
                }

                if (result == null)
                {
                    result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerStateProvince>>(WhippetResult.Success, concurrentCounties);
                }

                return result;
            }
        }

        /// <summary>
        /// Assigns <see cref="IMultichannelOrderManagerCountry"/> objects to the provided collection of <see cref="IMultichannelOrderManagerStateProvince"/> objects.
        /// </summary>
        /// <param name="stateProvinces"><see cref="IMultichannelOrderManagerStateProvince"/> collection.</param>
        /// <param name="countries"><see cref="IMultichannelOrderManagerCountry"/> collection.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation and populated <see cref="IMultichannelOrderManagerStateProvince"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerStateProvince>>> AssignCountries(IEnumerable<IMultichannelOrderManagerStateProvince> stateProvinces, IEnumerable<IMultichannelOrderManagerCountry> countries)
        {
            if (stateProvinces == null)
            {
                throw new ArgumentNullException(nameof(stateProvinces));
            }
            else if (countries == null)
            {
                throw new ArgumentNullException(nameof(countries));
            }
            else
            {
                WhippetResultContainer<IEnumerable<IMultichannelOrderManagerStateProvince>> result = null;

                ConcurrentBag<IMultichannelOrderManagerStateProvince> concurrentStateProvinces = new ConcurrentBag<IMultichannelOrderManagerStateProvince>();
                AsyncCollection<IMultichannelOrderManagerStateProvince> asyncStateProvinces = new AsyncCollection<IMultichannelOrderManagerStateProvince>(concurrentStateProvinces);

                ParallelOptions pOptions = null;

                if (stateProvinces.Any() && countries.Any())
                {
                    try
                    {
                        if (stateProvinces != null && stateProvinces.Any())
                        {
                            stateProvinces = new SortedSet<IMultichannelOrderManagerStateProvince>(stateProvinces, IMultichannelOrderManagerStateProvinceComparer.Instance);
                        }

                        if (countries != null && countries.Any())
                        {
                            countries = new SortedSet<IMultichannelOrderManagerCountry>(countries, IMultichannelOrderManagerCountryComparer.Instance);
                        }

                        pOptions = new ParallelOptions();
                        pOptions = pOptions.DetermineOptimalCoreCount();

                        await Parallel.ForEachAsync<IMultichannelOrderManagerStateProvince>(stateProvinces, pOptions, async (stateProvince, cancellationToken) =>
                        {
                            IMultichannelOrderManagerCountry country = null;
                            IMultichannelOrderManagerStateProvince newStateProvince = null;

                            if (stateProvince.Country != null && ((stateProvince.Country.CountryId != 0) || (!String.IsNullOrWhiteSpace(stateProvince.Country.CountryCode))))
                            {
                                country = (stateProvince.Country.CountryId != 0) ? countries.Where(c => c.CountryId == stateProvince.Country.CountryId).FirstOrDefault() : countries.Where(c => String.Equals(c.CountryCode.Trim(), stateProvince.Country.CountryCode.Trim(), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                                newStateProvince = stateProvince.Clone<IMultichannelOrderManagerStateProvince>();
                                newStateProvince.Country = country;

                                await asyncStateProvinces.AddAsync(newStateProvince);
                            }
                        });
                    }
                    catch (Exception e)
                    {
                        result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerStateProvince>>(e);
                    }
                }

                if (result == null)
                {
                    result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerStateProvince>>(WhippetResult.Success, concurrentStateProvinces);
                }

                return result;
            }
        }
        
        /// <summary>
        /// Fixes up <see cref="IMultichannelOrderManagerStateProvince"/> objects that are missing the state/province name.
        /// </summary>
        /// <param name="states"><see cref="IEnumerable{T}"/> collection of <see cref="IMultichannelOrderManagerStateProvince"/> objects to check.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerStateProvince>>> FixUpMissingStateProvinceCodes(IEnumerable<IMultichannelOrderManagerStateProvince> states)
        {
            if (states == null)
            {
                throw new ArgumentNullException(nameof(states));
            }
            else
            {
                WhippetResultContainer<IEnumerable<IMultichannelOrderManagerStateProvince>> result = null;
                WhippetResultContainer<IEnumerable<IMultichannelOrderManagerStateProvince>> allStatesResult = null;
                
                ConcurrentBag<IMultichannelOrderManagerStateProvince> concurrentStates = new ConcurrentBag<IMultichannelOrderManagerStateProvince>();
                AsyncCollection<IMultichannelOrderManagerStateProvince> asyncStates = new AsyncCollection<IMultichannelOrderManagerStateProvince>(concurrentStates);

                List<IMultichannelOrderManagerStateProvince> existingStates = null;
                List<IMultichannelOrderManagerStateProvince> missingStates = null;
                
                ParallelOptions pOptions = new ParallelOptions();

                try
                {
                    if (states.Any() && (states.Where(s => String.IsNullOrWhiteSpace(s.Name)).Any()))
                    {
                        pOptions = pOptions.DetermineOptimalCoreCount();

                        allStatesResult = await GetStateProvinces();
                        allStatesResult.ThrowIfFailed();

                        existingStates = states.Where(sp => !String.IsNullOrWhiteSpace(sp.Name)).ToList();
                        missingStates = states.Where(sp => String.IsNullOrWhiteSpace((sp.Name))).ToList();

                        await Parallel.ForEachAsync<IMultichannelOrderManagerStateProvince>(missingStates, pOptions, async (state, cancellationToken) =>
                        {
                            state.Name = (from s in allStatesResult.Item where s.ID == state.ID select s.Name).FirstOrDefault();

                            if (String.IsNullOrWhiteSpace(state.Name))
                            {
                                state.Name = (
                                    from s in allStatesResult.Item 
                                    where String.Equals(s.Name?.Trim(), state.Name?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                                        && s.Country.ID == state.Country.ID
                                    select s.Name).FirstOrDefault();
                            }

                            await asyncStates.AddAsync(state); 
                        });
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerStateProvince>>(e);
                }

                if (result == null)
                {
                    result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerStateProvince>>(WhippetResult.Success, existingStates.Concat(concurrentStates));
                }

                return result;
            }
        }        

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (StateProvinceRepository != null)
            {
                StateProvinceRepository.Dispose();
                StateProvinceRepository = null;
            }

            base.Dispose();
        }
    }
}
