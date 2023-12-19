using System;
using NHibernate;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.SuperDuper.Data;

namespace Athi.Whippet.SuperDuper.Legacy.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="LegacySuperDuperAccountAddress"/> entity objects.
    /// </summary>
    public class LegacySuperDuperAccountAddressRepository : SuperDuperLegacyEntityRepository<LegacySuperDuperAccountAddress>, ILegacySuperDuperAccountAddressRepository, ISuperDuperLegacyEntityRepository<LegacySuperDuperAccountAddress>, IWhippetQueryRepository<LegacySuperDuperAccountAddress>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LegacySuperDuperAccountAddressRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public LegacySuperDuperAccountAddressRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacySuperDuperAccountAddressRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public LegacySuperDuperAccountAddressRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Gets all <see cref="LegacySuperDuperAccountAddress"/> objects for the specified account.
        /// </summary>
        /// <param name="account"><see cref="ILegacySuperDuperAccount"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual WhippetResultContainer<IEnumerable<LegacySuperDuperAccountAddress>> GetByAccount(ILegacySuperDuperAccount account)
        {
            ArgumentNullException.ThrowIfNull(account);
            return Task.Run(() => GetByAccountAsync(account)).Result;
        }

        /// <summary>
        /// Gets all <see cref="LegacySuperDuperAccountAddress"/> objects for the specified account.
        /// </summary>
        /// <param name="account"><see cref="ILegacySuperDuperAccount"/> object to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<LegacySuperDuperAccountAddress>>> GetByAccountAsync(ILegacySuperDuperAccount account, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<IEnumerable<LegacySuperDuperAccountAddress>> result = null;
            IList<LegacySuperDuperAccountAddress> queryResults = null;

            try
            {
                queryResults = await Context.QueryOver<LegacySuperDuperAccountAddress>()
                    .JoinQueryOver<LegacySuperDuperAccount>(address => address.Account)
                    .Where(addressAccount => addressAccount.ID == account.ID)
                    .ListAsync(cancellationToken.GetValueOrDefault());

                result = new WhippetResultContainer<IEnumerable<LegacySuperDuperAccountAddress>>(WhippetResult.Success, queryResults);
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<LegacySuperDuperAccountAddress>>(e);
            }

            return result;
        }
        
        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotSupportedException"></exception>
        public WhippetResultContainer<LegacySuperDuperAccountAddress> Get(Guid id)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public async Task<WhippetResultContainer<LegacySuperDuperAccountAddress>> GetAsync(Guid id, CancellationToken? cancellationToken = null)
        {
            throw new NotSupportedException();
        }
    }
}
