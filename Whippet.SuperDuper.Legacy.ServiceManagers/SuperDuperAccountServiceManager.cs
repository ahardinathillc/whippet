using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Services;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Queries;
using Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Handlers.Queries;
using Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Commands;
using Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Handlers.Commands;
using Athi.Whippet.SuperDuper.Legacy.Repositories;
using Athi.Whippet.SuperDuper.Legacy.Extensions;

namespace Athi.Whippet.SuperDuper.Legacy.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="LegacySuperDuperAccount"/> domain objects.
    /// </summary>
    public class LegacySuperDuperAccountServiceManager : WhippetEntityServiceManager<LegacySuperDuperAccount, ILegacySuperDuperAccountRepository>, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetEntityServiceManager{TEntity, TRepository}"/> class with the specified <see cref="ILegacySuperDuperAccountRepository"/> object and the default currently-configured <see cref="IWhippetServiceContext"/>. If no context is configured, <see cref="ServiceManager.ServiceLocator"/> will not be available.
        /// </summary>
        /// <param name="repository"><see cref="ILegacySuperDuperAccountRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public LegacySuperDuperAccountServiceManager(ILegacySuperDuperAccountRepository repository)
            : base(repository)
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="LegacySuperDuperAccountServiceManager"/> class with the specified <see cref="ILegacySuperDuperAccountRepository"/> object and <see cref="IWhippetServiceContext"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ILegacySuperDuperAccountRepository"/> object to initialize with.</param>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public LegacySuperDuperAccountServiceManager(ILegacySuperDuperAccountRepository repository, IWhippetServiceContext serviceLocator)
            : base(repository, serviceLocator)
        { }

        /// <summary>
        /// Gets all <see cref="LegacySuperDuperAccount"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ILegacySuperDuperAccount>>> GetAccounts()
        {
            GetAllLegacySuperDuperAccountsQueryHandler handler = new GetAllLegacySuperDuperAccountsQueryHandler(Repository);
            WhippetResultContainer<IEnumerable<LegacySuperDuperAccount>> result = await handler.HandleAsync(new GetAllLegacySuperDuperAccountsQuery());
            return new WhippetResultContainer<IEnumerable<ILegacySuperDuperAccount>>(result.Result, result.Item);
        }
        
        /// <summary>
        /// Gets the specified <see cref="ILegacySuperDuperAccount"/> object with the given ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="ILegacySuperDuperAccount"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        public virtual async Task<WhippetResultContainer<ILegacySuperDuperAccount>> GetAccount(int id)
        {
            GetLegacySuperDuperAccountByIdQueryHandler handler = new GetLegacySuperDuperAccountByIdQueryHandler(Repository);
            WhippetResultContainer<IEnumerable<LegacySuperDuperAccount>> result = await handler.HandleAsync(new GetLegacySuperDuperAccountByIdQuery(id));
            return new WhippetResultContainer<ILegacySuperDuperAccount>(result.Result, result.EnumerableSingleResult<ILegacySuperDuperAccount>());
        }

        /// <summary>
        /// Gets the specified <see cref="ILegacySuperDuperAccount"/> object with the given UUID (<see cref="Guid"/>).
        /// </summary>
        /// <param name="id">ID of the <see cref="ILegacySuperDuperAccount"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        public virtual async Task<WhippetResultContainer<ILegacySuperDuperAccount>> GetAccount(Guid id)
        {
            GetLegacySuperDuperAccountByUUIDQueryHandler handler = new GetLegacySuperDuperAccountByUUIDQueryHandler(Repository);
            WhippetResultContainer<IEnumerable<LegacySuperDuperAccount>> result = await handler.HandleAsync(new GetLegacySuperDuperAccountByUUIDQuery(id));
            return new WhippetResultContainer<ILegacySuperDuperAccount>(result.Result, result.EnumerableSingleResult<ILegacySuperDuperAccount>());
        }

        /// <summary>
        /// Gets the specified <see cref="ILegacySuperDuperAccount"/> object with the specified customer number.
        /// </summary>
        /// <param name="customerNumber">Customer number of the <see cref="ILegacySuperDuperAccount"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        public virtual async Task<WhippetResultContainer<ILegacySuperDuperAccount>> GetAccountByCustomerNumber(int customerNumber)
        {
            GetLegacySuperDuperAccountByCustomerNumberQueryHandler handler = new GetLegacySuperDuperAccountByCustomerNumberQueryHandler(Repository);
            WhippetResultContainer<IEnumerable<LegacySuperDuperAccount>> result = await handler.HandleAsync(new GetLegacySuperDuperAccountByCustomerNumberQuery(customerNumber));
            return new WhippetResultContainer<ILegacySuperDuperAccount>(result.Result, result.EnumerableSingleResult<ILegacySuperDuperAccount>());
        }
        
        /// <summary>
        /// Creates a new legacy Digital Library server.
        /// </summary>
        /// <param name="server">Legacy server entry to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created server.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ILegacySuperDuperAccount>> CreateLegacySuperDuperAccount(ILegacySuperDuperAccount server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }
            else
            {
                WhippetResult createResult = null;
                IWhippetCommandHandler<CreateLegacySuperDuperAccountCommand> handler = new CreateLegacySuperDuperAccountCommandHandler(Repository);

                try
                {
                    createResult = await handler.HandleAsync(new CreateLegacySuperDuperAccountCommand(server.ToLegacySuperDuperAccount()));

                    if (createResult.IsSuccess)
                    {
                        await ((IWhippetRepository<LegacySuperDuperAccount, int>)(Repository)).CommitAsync();
                        createResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    createResult = new WhippetResultContainer<ILegacySuperDuperAccount>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ILegacySuperDuperAccount>(createResult, server);
            }
        }

        /// <summary>
        /// Updates an existing legacy Digital Library server.
        /// </summary>
        /// <param name="server">Legacy server to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated server.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ILegacySuperDuperAccount>> UpdateLegacySuperDuperAccount(ILegacySuperDuperAccount server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetCommandHandler<UpdateLegacySuperDuperAccountCommand> handler = new UpdateLegacySuperDuperAccountCommandHandler(Repository);

                try
                {
                    updateResult = await handler.HandleAsync(new UpdateLegacySuperDuperAccountCommand(server.ToLegacySuperDuperAccount()));

                    if (updateResult.IsSuccess)
                    {
                        await ((IWhippetRepository<LegacySuperDuperAccount, int>)(Repository)).CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<ILegacySuperDuperAccount>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ILegacySuperDuperAccount>(updateResult, server);
            }
        }

        /// <summary>
        /// Deletes an existing legacy Digital Library server.
        /// </summary>
        /// <param name="server">Legacy server to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted server.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ILegacySuperDuperAccount>> DeleteLegacySuperDuperAccount(ILegacySuperDuperAccount server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetCommandHandler<DeleteLegacySuperDuperAccountCommand> handler = new DeleteLegacySuperDuperAccountCommandHandler(Repository);

                try
                {
                    updateResult = await handler.HandleAsync(new DeleteLegacySuperDuperAccountCommand(server.ToLegacySuperDuperAccount()));

                    if (updateResult.IsSuccess)
                    {
                        await ((IWhippetRepository<LegacySuperDuperAccount, int>)(Repository)).CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<ILegacySuperDuperAccount>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ILegacySuperDuperAccount>(updateResult, server);
            }
        }        
    }
}
