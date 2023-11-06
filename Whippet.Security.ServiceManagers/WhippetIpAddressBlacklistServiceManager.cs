using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Services;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.ServiceManagers.Queries;
using Athi.Whippet.Security.ServiceManagers.Commands;
using Athi.Whippet.Security.ServiceManagers.Handlers.Commands;
using Athi.Whippet.Security.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Security.Cryptography;
using Athi.Whippet.Security.Extensions;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.Security.Repositories;

namespace Athi.Whippet.Security.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="WhippetIpAddressBlacklist"/> domain objects.
    /// </summary>
    public class WhippetIpAddressBlacklistServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IWhippetIpAddressBlacklistRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IWhippetIpAddressBlacklistRepository IpAddressBlacklistRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetIpAddressBlacklistServiceManager"/> class with the specified <see cref="IWhippetIpAddressBlacklistRepository"/> object.
        /// </summary>
        /// <param name="ipAddressBlacklistRepository"><see cref="IWhippetIpAddressBlacklistRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetIpAddressBlacklistServiceManager(IWhippetIpAddressBlacklistRepository ipAddressBlacklistRepository)
            : base()
        {
            if (ipAddressBlacklistRepository == null)
            {
                throw new ArgumentNullException(nameof(ipAddressBlacklistRepository));
            }
            else
            {
                IpAddressBlacklistRepository = ipAddressBlacklistRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetIpAddressBlacklistServiceManager"/> class with the specified <see cref="IWhippetIpAddressBlacklistRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="ipAddressBlacklistRepository"><see cref="IWhippetIpAddressBlacklistRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetIpAddressBlacklistServiceManager(IWhippetServiceContext serviceLocator, IWhippetIpAddressBlacklistRepository ipAddressBlacklistRepository)
            : base(serviceLocator)
        {
            if (ipAddressBlacklistRepository == null)
            {
                throw new ArgumentNullException(nameof(ipAddressBlacklistRepository));
            }
            else
            {
                IpAddressBlacklistRepository = ipAddressBlacklistRepository;
            }
        }

        /// <summary>
        /// Gets all entries in the IP address blacklist.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IWhippetIpAddressBlacklist>>> GetIpAddressBlacklist()
        {
            GetWhippetIpAddressBlacklistQueryHandler handler = new GetWhippetIpAddressBlacklistQueryHandler(IpAddressBlacklistRepository);
            WhippetResultContainer<IEnumerable<WhippetIpAddressBlacklist>> result = await handler.HandleAsync(new GetWhippetIpAddressBlacklistQuery(null, null));

            return new WhippetResultContainer<IEnumerable<IWhippetIpAddressBlacklist>>(result.Result, result.Item);
        }

        /// <summary>
        /// Gets the <see cref="IWhippetIpAddressBlacklist"/> entry that matches the specified IP address and tenant.
        /// </summary>
        /// <param name="ipAddress">IP address to search for.</param>
        /// <param name="tenant">Tenant that the blacklist applies to.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IWhippetIpAddressBlacklist>> GetIpAddressBlacklistForTenant(string ipAddress, IWhippetTenant tenant)
        {
            if (String.IsNullOrWhiteSpace(ipAddress))
            {
                throw new ArgumentNullException(nameof(ipAddress));
            }
            else
            {
                GetWhippetIpAddressBlacklistQueryHandler handler = new GetWhippetIpAddressBlacklistQueryHandler(IpAddressBlacklistRepository);
                WhippetResultContainer<IEnumerable<WhippetIpAddressBlacklist>> result = await handler.HandleAsync(new GetWhippetIpAddressBlacklistQuery(ipAddress, tenant));

                return new WhippetResultContainer<IWhippetIpAddressBlacklist>(result.Result, result.Item.FirstOrDefault());
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (IpAddressBlacklistRepository != null)
            {
                IpAddressBlacklistRepository.Dispose();
                IpAddressBlacklistRepository = null;
            }

            base.Dispose();
        }
    }
}
