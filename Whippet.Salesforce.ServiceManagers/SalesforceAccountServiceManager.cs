using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using NodaTime;
using Salesforce.Common;
using Salesforce.Force;
using Athi.Whippet;
using Athi.Whippet.Services;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.Salesforce.ServiceManagers.Queries;
using Athi.Whippet.Salesforce.ServiceManagers.Commands;
using Athi.Whippet.Salesforce.ServiceManagers.Handlers.Commands;
using Athi.Whippet.Salesforce.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Salesforce.Repositories;
using Athi.Whippet.Salesforce.Extensions;
using Athi.Whippet.Data;

namespace Athi.Whippet.Salesforce.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="ISalesforceAccount"/> domain objects.
    /// </summary>
    public class SalesforceAccountServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="ISalesforceAccountRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual ISalesforceAccountRepository AccountRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceAccountServiceManager"/> class with the specified <see cref="ISalesforceAccountRepository"/> object.
        /// </summary>
        /// <param name="accountRepository"><see cref="ISalesforceAccountRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesforceAccountServiceManager(ISalesforceAccountRepository accountRepository)
            : base()
        {
            if (accountRepository == null)
            {
                throw new ArgumentNullException(nameof(accountRepository));
            }
            else
            {
                AccountRepository = accountRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceAccountServiceManager"/> class with the specified <see cref="ISalesforceAccountRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="accountRepository"><see cref="ISalesforceAccountRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesforceAccountServiceManager(IWhippetServiceContext serviceLocator, ISalesforceAccountRepository accountRepository)
            : base(serviceLocator)
        {
            if (accountRepository == null)
            {
                throw new ArgumentNullException(nameof(accountRepository));
            }
            else
            {
                AccountRepository = accountRepository;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="ISalesforceAccount"/> objects that contain the specified account name or search criteria.
        /// </summary>
        /// <param name="accountName">Account name or search criteria.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<ISalesforceAccount>>> SearchSalesforceAccounts(string accountName)
        {
            if (String.IsNullOrWhiteSpace(accountName))
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            else
            {
                ISalesforceAccountQueryHandler<GetSalesforceAccountLikeNameQuery> handler = new GetSalesforceAccountLikeNameQueryHandler(AccountRepository);
                WhippetResultContainer<IEnumerable<SalesforceAccount>> result = await handler.HandleAsync(new GetSalesforceAccountLikeNameQuery(accountName));

                return new WhippetResultContainer<IEnumerable<ISalesforceAccount>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Retrieves the <see cref="ISalesforceAccount"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="ISalesforceAccount"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ISalesforceAccount>> GetSalesforceAccount(SalesforceReference id)
        {
            ISalesforceAccountQueryHandler<GetSalesforceAccountByIdQuery> handler = new GetSalesforceAccountByIdQueryHandler(AccountRepository);
            WhippetResultContainer<IEnumerable<SalesforceAccount>> result = await handler.HandleAsync(new GetSalesforceAccountByIdQuery(id));

            return new WhippetResultContainer<ISalesforceAccount>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves the <see cref="ISalesforceAccount"/> object with the specified name.
        /// </summary>
        /// <param name="accountName">Name of the <see cref="ISalesforceAccount"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ISalesforceAccount>> GetSalesforceAccountByName(string accountName)
        {
            ISalesforceAccountQueryHandler<GetSalesforceAccountByNameQuery> handler = new GetSalesforceAccountByNameQueryHandler(AccountRepository);
            WhippetResultContainer<IEnumerable<SalesforceAccount>> result = await handler.HandleAsync(new GetSalesforceAccountByNameQuery(accountName));

            return new WhippetResultContainer<ISalesforceAccount>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Creates a new Salesforce client account entry.
        /// </summary>
        /// <param name="account"><see cref="ISalesforceAccount"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ISalesforceAccount"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforceAccount> CreateSalesforceAccount(ISalesforceAccount account)
        {
            return Task<WhippetResultContainer<ISalesforceAccount>>.Run(() => CreateSalesforceAccountAsync(account)).Result;
        }

        /// <summary>
        /// Creates a new Salesforce client account entry.
        /// </summary>
        /// <param name="account"><see cref="ISalesforceAccount"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ISalesforceAccount"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforceAccount>> CreateSalesforceAccountAsync(ISalesforceAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateSalesforceAccountCommand> handler = new CreateSalesforceAccountCommandHandler(AccountRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateSalesforceAccountCommand(account.ToSalesforceAccount()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforceAccount, SalesforceReference>)(AccountRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforceAccount>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforceAccount>(result, account);
            }
        }

        /// <summary>
        /// Updates an existing Salesforce client account entry.
        /// </summary>
        /// <param name="account"><see cref="ISalesforceAccount"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated <see cref="ISalesforceAccount"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforceAccount> UpdateSalesforceAccount(ISalesforceAccount account)
        {
            return Task<WhippetResultContainer<ISalesforceAccount>>.Run(() => UpdateSalesforceAccountAsync(account)).Result;
        }

        /// <summary>
        /// Updates an existing Salesforce client account entry.
        /// </summary>
        /// <param name="account"><see cref="ISalesforceAccount"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated <see cref="ISalesforceAccount"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforceAccount>> UpdateSalesforceAccountAsync(ISalesforceAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateSalesforceAccountCommand> handler = new UpdateSalesforceAccountCommandHandler(AccountRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateSalesforceAccountCommand(account.ToSalesforceAccount()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforceAccount, SalesforceReference>)(AccountRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforceAccount>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforceAccount>(result, account);
            }
        }

        /// <summary>
        /// Deletes an existing Salesforce client account entry.
        /// </summary>
        /// <param name="account"><see cref="ISalesforceAccount"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted <see cref="ISalesforceAccount"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforceAccount> DeleteSalesforceAccount(ISalesforceAccount account)
        {
            return Task<WhippetResultContainer<ISalesforceAccount>>.Run(() => DeleteSalesforceAccountAsync(account)).Result;
        }

        /// <summary>
        /// Deletes an existing Salesforce client account entry.
        /// </summary>
        /// <param name="account"><see cref="ISalesforceAccount"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted <see cref="ISalesforceAccount"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforceAccount>> DeleteSalesforceAccountAsync(ISalesforceAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteSalesforceAccountCommand> handler = new DeleteSalesforceAccountCommandHandler(AccountRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteSalesforceAccountCommand(account.ToSalesforceAccount()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforceAccount, SalesforceReference>)(AccountRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforceAccount>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforceAccount>(result, account);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (AccountRepository != null)
            {
                AccountRepository.Dispose();
                AccountRepository = null;
            }

            base.Dispose();
        }
    }
}
