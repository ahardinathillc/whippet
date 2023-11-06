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
    /// Service manager for <see cref="WhippetPasswordBlacklist"/> domain objects.
    /// </summary>
    public class WhippetPasswordBlacklistServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IWhippetPasswordBlacklistRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IWhippetPasswordBlacklistRepository PasswordBlacklistRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPasswordBlacklistServiceManager"/> class with the specified <see cref="IWhippetPasswordBlacklistRepository"/> object.
        /// </summary>
        /// <param name="passwordBlacklistRepository"><see cref="IWhippetPasswordBlacklistRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetPasswordBlacklistServiceManager(IWhippetPasswordBlacklistRepository passwordBlacklistRepository)
            : base()
        {
            if (passwordBlacklistRepository == null)
            {
                throw new ArgumentNullException(nameof(passwordBlacklistRepository));
            }
            else
            {
                PasswordBlacklistRepository = passwordBlacklistRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPasswordBlacklistServiceManager"/> class with the specified <see cref="IWhippetPasswordBlacklistRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="passwordBlacklistRepository"><see cref="IWhippetPasswordBlacklistRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetPasswordBlacklistServiceManager(IWhippetServiceContext serviceLocator, IWhippetPasswordBlacklistRepository passwordBlacklistRepository)
            : base(serviceLocator)
        {
            if (passwordBlacklistRepository == null)
            {
                throw new ArgumentNullException(nameof(passwordBlacklistRepository));
            }
            else
            {
                PasswordBlacklistRepository = passwordBlacklistRepository;
            }
        }

        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IWhippetPasswordBlacklist>> GetPasswordBlacklist()
        {
            GetWhippetPasswordBlacklistQueryHandler handler = new GetWhippetPasswordBlacklistQueryHandler(PasswordBlacklistRepository);
            WhippetResultContainer<IEnumerable<WhippetPasswordBlacklist>> result = await handler.HandleAsync(new GetWhippetPasswordBlacklistQuery(null, null));

            return new WhippetResultContainer<IWhippetPasswordBlacklist>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Gets the <see cref="IWhippetPasswordBlacklist"/> entry that matches the specified password and tenant.
        /// </summary>
        /// <param name="password">Password to search for.</param>
        /// <param name="tenant">Tenant that the blacklist applies to.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IWhippetPasswordBlacklist>> GetPasswordBlacklistForTenant(string password, IWhippetTenant tenant)
        {
            if (String.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password));
            }
            else if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                GetWhippetPasswordBlacklistQueryHandler handler = new GetWhippetPasswordBlacklistQueryHandler(PasswordBlacklistRepository);
                WhippetResultContainer<IEnumerable<WhippetPasswordBlacklist>> result = await handler.HandleAsync(new GetWhippetPasswordBlacklistQuery(password, tenant));

                return new WhippetResultContainer<IWhippetPasswordBlacklist>(result.Result, result.Item.FirstOrDefault());
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (PasswordBlacklistRepository != null)
            {
                PasswordBlacklistRepository.Dispose();
                PasswordBlacklistRepository = null;
            }

            base.Dispose();
        }
    }
}
