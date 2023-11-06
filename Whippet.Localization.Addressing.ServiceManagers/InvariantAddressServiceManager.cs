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
    /// Service manager for <see cref="IInvariantAddress"/> domain objects.
    /// </summary>
    public class InvariantAddressServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IInvariantAddressRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IInvariantAddressRepository AddressRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvariantAddressServiceManager"/> class with the specified <see cref="IInvariantAddressRepository"/> object.
        /// </summary>
        /// <param name="addressRepository"><see cref="IInvariantAddressRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public InvariantAddressServiceManager(IInvariantAddressRepository addressRepository)
            : base()
        {
            if (addressRepository == null)
            {
                throw new ArgumentNullException(nameof(addressRepository));
            }
            else
            {
                AddressRepository = addressRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvariantAddressServiceManager"/> class with the specified <see cref="IInvariantAddressRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="addressRepository"><see cref="IInvariantAddressRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public InvariantAddressServiceManager(IWhippetServiceContext serviceLocator, IInvariantAddressRepository addressRepository)
            : base(serviceLocator)
        {
            if (addressRepository == null)
            {
                throw new ArgumentNullException(nameof(addressRepository));
            }
            else
            {
                AddressRepository = addressRepository;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="IInvariantAddress"/> objects registered in the data store for a specific <see cref="ICity"/>.
        /// </summary>
        /// <param name="city"><see cref="ICity"/> to retrieve <see cref="IInvariantAddress"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IInvariantAddress>>> GetAddresses(ICity city)
        {
            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }
            else
            {
                IInvariantAddressQueryHandler<GetInvariantAddressesForCityQuery> handler = new GetInvariantAddressesForCityQueryHandler(AddressRepository);
                WhippetResultContainer<IEnumerable<InvariantAddress>> result = await handler.HandleAsync(new GetInvariantAddressesForCityQuery(city));
                return new WhippetResultContainer<IEnumerable<IInvariantAddress>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Retrieves all <see cref="IInvariantAddress"/> objects registered in the data store for a specific <see cref="IPostalCode"/>.
        /// </summary>
        /// <param name="postalCode"><see cref="IPostalCode"/> to retrieve <see cref="IInvariantAddress"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IInvariantAddress>>> GetAddresses(IPostalCode postalCode)
        {
            if (postalCode == null)
            {
                throw new ArgumentNullException(nameof(postalCode));
            }
            else
            {
                IInvariantAddressQueryHandler<GetInvariantAddressesForPostalCodeQuery> handler = new GetInvariantAddressesForPostalCodeQueryHandler(AddressRepository);
                WhippetResultContainer<IEnumerable<InvariantAddress>> result = await handler.HandleAsync(new GetInvariantAddressesForPostalCodeQuery(postalCode));
                return new WhippetResultContainer<IEnumerable<IInvariantAddress>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Retrieves the specified <see cref="IInvariantAddress"/> object from the data store based on its ID.
        /// </summary>
        /// <param name="addressId"><see cref="IInvariantAddress"/> ID.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IInvariantAddress>> GetAddress(Guid addressId)
        {
            IInvariantAddressQueryHandler<GetInvariantAddressByIdQuery> handler = new GetInvariantAddressByIdQueryHandler(AddressRepository);
            WhippetResultContainer<IEnumerable<InvariantAddress>> result = await handler.HandleAsync(new GetInvariantAddressByIdQuery(addressId));
            return new WhippetResultContainer<IInvariantAddress>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves the specified <see cref="IInvariantAddress"/> object from the data store based on its address lines.
        /// </summary>
        /// <param name="address"><see cref="IInvariantAddress"/> to search for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IInvariantAddress>>> GetAddress(IInvariantAddress address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }
            else
            {
                IInvariantAddressQueryHandler<GetInvariantAddressQuery> handler = new GetInvariantAddressQueryHandler(AddressRepository);
                WhippetResultContainer<IEnumerable<InvariantAddress>> result = await handler.HandleAsync(new GetInvariantAddressQuery(address));
                return new WhippetResultContainer<IEnumerable<IInvariantAddress>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Creates a new address entry.
        /// </summary>
        /// <param name="server"><see cref="IInvariantAddress"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IInvariantAddress"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IInvariantAddress> CreateInvariantAddress(IInvariantAddress address)
        {
            return Task<WhippetResultContainer<IInvariantAddress>>.Run(() => CreateInvariantAddressAsync(address)).Result;
        }

        /// <summary>
        /// Creates a new address entry.
        /// </summary>
        /// <param name="address"><see cref="IInvariantAddress"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IInvariantAddress"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IInvariantAddress>> CreateInvariantAddressAsync(IInvariantAddress address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateInvariantAddressCommand> handler = new CreateInvariantAddressCommandHandler(AddressRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateInvariantAddressCommand(address.ToInvariantAddress()));

                    if (result.IsSuccess)
                    {
                        await AddressRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IInvariantAddress>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IInvariantAddress>(result, address);
            }
        }

        /// <summary>
        /// Updates an existing address.
        /// </summary>
        /// <param name="address"><see cref="IInvariantAddress"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IInvariantAddress"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IInvariantAddress> UpdateInvariantAddress(IInvariantAddress address)
        {
            return Task<WhippetResultContainer<IInvariantAddress>>.Run(() => UpdateInvariantAddressAsync(address)).Result;
        }

        /// <summary>
        /// Updates an existing address.
        /// </summary>
        /// <param name="address"><see cref="IInvariantAddress"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IInvariantAddress"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IInvariantAddress>> UpdateInvariantAddressAsync(IInvariantAddress address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateInvariantAddressCommand> handler = new UpdateInvariantAddressCommandHandler(AddressRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateInvariantAddressCommand(address.ToInvariantAddress()));

                    if (result.IsSuccess)
                    {
                        await AddressRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IInvariantAddress>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IInvariantAddress>(result, address);
            }
        }

        /// <summary>
        /// Deletes an existing address.
        /// </summary>
        /// <param name="address"><see cref="IInvariantAddress"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IInvariantAddress"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IInvariantAddress> DeleteInvariantAddress(IInvariantAddress address)
        {
            return Task<WhippetResultContainer<IInvariantAddress>>.Run(() => DeleteInvariantAddressAsync(address)).Result;
        }

        /// <summary>
        /// Deletes an existing address.
        /// </summary>
        /// <param name="address"><see cref="IInvariantAddress"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IInvariantAddress"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IInvariantAddress>> DeleteInvariantAddressAsync(IInvariantAddress address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteInvariantAddressCommand> handler = new DeleteInvariantAddressCommandHandler(AddressRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteInvariantAddressCommand(address.ToInvariantAddress()));

                    if (result.IsSuccess)
                    {
                        await AddressRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IInvariantAddress>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IInvariantAddress>(result, address);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (AddressRepository != null)
            {
                AddressRepository.Dispose();
                AddressRepository = null;
            }

            base.Dispose();
        }
    }
}
