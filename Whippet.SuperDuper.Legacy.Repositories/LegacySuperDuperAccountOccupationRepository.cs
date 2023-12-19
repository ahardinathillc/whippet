using System;
using NHibernate;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.SuperDuper.Data;

namespace Athi.Whippet.SuperDuper.Legacy.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="LegacySuperDuperAccountOccupation"/> entity objects.
    /// </summary>
    public class LegacySuperDuperAccountOccupationRepository : SuperDuperLegacyEntityRepository<LegacySuperDuperAccountOccupation>, ILegacySuperDuperAccountOccupationRepository, ISuperDuperLegacyEntityRepository<LegacySuperDuperAccountOccupation>, IWhippetQueryRepository<LegacySuperDuperAccountOccupation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LegacySuperDuperAccountOccupationRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public LegacySuperDuperAccountOccupationRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacySuperDuperAccountOccupationRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public LegacySuperDuperAccountOccupationRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotSupportedException"></exception>
        public WhippetResultContainer<LegacySuperDuperAccountOccupation> Get(Guid id)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public async Task<WhippetResultContainer<LegacySuperDuperAccountOccupation>> GetAsync(Guid id, CancellationToken? cancellationToken = null)
        {
            throw new NotSupportedException();
        }
    }
}
