using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Athi.Whippet;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Queries;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories;
using Nito.AsyncEx;
using Athi.Whippet.Threading.Tasks.Extensions;
using System.Collections.Concurrent;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IMultichannelOrderManagerWarehouse"/> domain objects.
    /// </summary>
    public class MultichannelOrderManagerWarehouseServiceManager : ServiceManager, IDisposable
    {
        private const string COUNTRY_CODE_USA = "001";

        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerWarehouseRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IMultichannelOrderManagerWarehouseRepository WarehouseRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerWarehouseServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerWarehouseRepository"/>.
        /// </summary>
        /// <param name="warehouseRepository"><see cref="IMultichannelOrderManagerWarehouse"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerWarehouseServiceManager(IMultichannelOrderManagerWarehouseRepository warehouseRepository)
            : base()
        {
            if (warehouseRepository == null)
            {
                throw new ArgumentNullException(nameof(warehouseRepository));
            }
            else
            {
                WarehouseRepository = warehouseRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerWarehouseServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerWarehouseRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="warehouseRepository"><see cref="IMultichannelOrderManagerWarehouseRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerWarehouseServiceManager(IWhippetServiceContext serviceLocator, IMultichannelOrderManagerWarehouseRepository warehouseRepository)
            : base(serviceLocator)
        {
            if (warehouseRepository == null)
            {
                throw new ArgumentNullException(nameof(warehouseRepository));
            }
            else
            {
                WarehouseRepository = warehouseRepository;
            }
        }

        /// <summary>
        /// Gets all <see cref="IMultichannelOrderManagerWarehouse"/> objects in the data store.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerWarehouse>>> GetWarehouses()
        {
            IMultichannelOrderManagerWarehouseQueryHandler<GetMultichannelOrderManagerWarehousesQuery> handler = new GetMultichannelOrderManagerWarehousesQueryHandler(WarehouseRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerWarehouse>> result = await handler.HandleAsync(new GetMultichannelOrderManagerWarehousesQuery());
            return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerWarehouse>>(result.Result, result.Item);
        }

        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerWarehouse"/> object with the specified ID.
        /// </summary>
        /// <param name="warehouseId">Warehouse ID.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IMultichannelOrderManagerWarehouse>> GetWarehouse(long warehouseId)
        {
            IMultichannelOrderManagerWarehouseQueryHandler<GetMultichannelOrderManagerWarehouseByIdQuery> handler = new GetMultichannelOrderManagerWarehouseByIdQueryHandler(WarehouseRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerWarehouse>> result = await handler.HandleAsync(new GetMultichannelOrderManagerWarehouseByIdQuery(warehouseId));
            return new WhippetResultContainer<IMultichannelOrderManagerWarehouse>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Assigns <see cref="IMultichannelOrderManagerCountry"/> objects to the provided collection of <see cref="IMultichannelOrderManagerWarehouse"/> objects.
        /// </summary>
        /// <param name="warehouses"><see cref="IMultichannelOrderManagerWarehouse"/> collection.</param>
        /// <param name="countries"><see cref="IMultichannelOrderManagerCountry"/> collection.</param>
        /// <param name="postalCodes"><see cref="IMultichannelOrderManagerPostalCode"/> collection.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation and populated <see cref="IMultichannelOrderManagerWarehouse"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerWarehouse>>> AssignCountries(IEnumerable<IMultichannelOrderManagerWarehouse> warehouses, IEnumerable<IMultichannelOrderManagerCountry> countries, IEnumerable<IMultichannelOrderManagerPostalCode> postalCodes)
        {
            if (warehouses == null)
            {
                throw new ArgumentNullException(nameof(warehouses));
            }
            else if (countries == null)
            {
                throw new ArgumentNullException(nameof(countries));
            }
            else if (postalCodes == null)
            {
                throw new ArgumentNullException(nameof(postalCodes));
            }
            else
            {
                WhippetResultContainer<IEnumerable<IMultichannelOrderManagerWarehouse>> result = null;

                ConcurrentBag<IMultichannelOrderManagerWarehouse> concurrentWarehouses = new ConcurrentBag<IMultichannelOrderManagerWarehouse>();
                AsyncCollection<IMultichannelOrderManagerWarehouse> asyncWarehouses = new AsyncCollection<IMultichannelOrderManagerWarehouse>(concurrentWarehouses);

                ParallelOptions pOptions = null;

                if (warehouses.Any() && countries.Any() && postalCodes.Any())
                {
                    try
                    {
                        if (warehouses != null && warehouses.Any())
                        {
                            warehouses = new SortedSet<IMultichannelOrderManagerWarehouse>(warehouses, IMultichannelOrderManagerWarehouseComparer.Instance);
                        }

                        pOptions = new ParallelOptions();
                        pOptions = pOptions.DetermineOptimalCoreCount();

                        await Parallel.ForEachAsync<IMultichannelOrderManagerWarehouse>(warehouses, pOptions, async (warehouse, cancellationToken) =>
                        {
                            IMultichannelOrderManagerCountry country = null;
                            IMultichannelOrderManagerPostalCode postalCode = null;
                            IMultichannelOrderManagerWarehouse newWarehouse = null;

                            newWarehouse = warehouse.Clone<IMultichannelOrderManagerWarehouse>();

                            if (!String.IsNullOrWhiteSpace(warehouse.ZipCode))
                            {
                                postalCode = postalCodes.Where(pc => String.Equals(pc.PostalCode?.Trim(), warehouse.ZipCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                                country = countries.Where(c => String.Equals(c.CountryCode?.Trim(), postalCode.Country?.CountryCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                                if (country != null)
                                {
                                    warehouse.Country = country.CountryCode;
                                }
                                else
                                {
                                    warehouse.Country = String.Empty;
                                }
                            }

                            if (String.IsNullOrWhiteSpace(warehouse.Country))
                            {
                                // default to USA
                                newWarehouse.Country = COUNTRY_CODE_USA;
                            }

                            await asyncWarehouses.AddAsync(newWarehouse);
                        });
                    }
                    catch (Exception e)
                    {
                        result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerWarehouse>>(e);
                    }
                }

                if (result == null)
                {
                    result = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerWarehouse>>(WhippetResult.Success, concurrentWarehouses);
                }

                return result;
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (WarehouseRepository != null)
            {
                WarehouseRepository.Dispose();
                WarehouseRepository = null;
            }

            base.Dispose();
        }
    }
}