using System;
using NHibernate;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.SuperDuper.Data;

namespace Athi.Whippet.SuperDuper.Legacy.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="LegacySuperDuperAccount"/> entity objects.
    /// </summary>
    public class LegacySuperDuperAccountRepository : SuperDuperLegacyEntityRepository<LegacySuperDuperAccount>, ILegacySuperDuperAccountRepository, ISuperDuperLegacyEntityRepository<LegacySuperDuperAccount>, IWhippetQueryRepository<LegacySuperDuperAccount>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LegacySuperDuperAccountRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public LegacySuperDuperAccountRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacySuperDuperAccountRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public LegacySuperDuperAccountRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// gets the <see cref="LegacySuperDuperAccount"/> object with the specified customer number.
        /// </summary>
        /// <param name="customerNumber">Customer number.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual WhippetResultContainer<LegacySuperDuperAccount> GetByCustomerNumber(int customerNumber)
        {
            return Task.Run(() => GetByCustomerNumberAsync(customerNumber)).Result;
        }

        /// <summary>
        /// Gets the <see cref="LegacySuperDuperAccount"/> object with the specified customer number.
        /// </summary>
        /// <param name="customerNumber">Customer number.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual async Task<WhippetResultContainer<LegacySuperDuperAccount>> GetByCustomerNumberAsync(int customerNumber, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<LegacySuperDuperAccount> result = null;
            IList<LegacySuperDuperAccount> queryResults = null;

            try
            {
                queryResults = await Context.QueryOver<LegacySuperDuperAccount>()
                    .Where(account => account.CustomerNumber == customerNumber)
                    .JoinQueryOver<LegacySuperDuperAccountOccupation>(account => account.SuperDuperAccountOccupation)
                    .ListAsync(cancellationToken.GetValueOrDefault());

                result = new WhippetResultContainer<LegacySuperDuperAccount>(WhippetResult.Success, queryResults.FirstOrDefault());
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<LegacySuperDuperAccount>(e);
            }

            return result;
        }

        /// <summary>
        /// Gets the <see cref="LegacySuperDuperAccount"/> object with the specified UUID (<see cref="Guid"/>).
        /// </summary>
        /// <param name="id"><see cref="Guid"/> which represents the UUID value.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual WhippetResultContainer<LegacySuperDuperAccount> Get(Guid id)
        {
            return Task.Run(() => GetAsync(id)).Result;
        }

        /// <summary>
        /// Gets the <see cref="LegacySuperDuperAccount"/> object with the specified UUID (<see cref="Guid"/>).
        /// </summary>
        /// <param name="id"><see cref="Guid"/> which represents the UUID value.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual async Task<WhippetResultContainer<LegacySuperDuperAccount>> GetAsync(Guid id, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<LegacySuperDuperAccount> result = null;
            IList<LegacySuperDuperAccount> queryResults = null;

            try
            {
                queryResults = await Context.QueryOver<LegacySuperDuperAccount>()
                    .Where(account => account.UUID == id)
                    .JoinQueryOver<LegacySuperDuperAccountOccupation>(account => account.SuperDuperAccountOccupation)
                    .ListAsync(cancellationToken.GetValueOrDefault());

                result = new WhippetResultContainer<LegacySuperDuperAccount>(WhippetResult.Success, queryResults.FirstOrDefault());
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<LegacySuperDuperAccount>(e);
            }

            return result;
        }
    }
}
