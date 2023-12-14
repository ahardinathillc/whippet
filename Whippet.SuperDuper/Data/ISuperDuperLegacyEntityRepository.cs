using System;
using System.Data;
using NHibernate;
using Athi.Whippet.Data;

namespace Athi.Whippet.SuperDuper.Data
{
    /// <summary>
    /// Represents a generic repository that is independent of the backing data store for <see cref="SuperDuperLegacyEntity"/> objects. This class must be inherited.
    /// </summary>
    /// <typeparam name="TEntity">Type of <see cref="SuperDuperLegacyEntity"/> object to store in the repository.</typeparam>
    public interface ISuperDuperLegacyEntityRepository<TEntity> : IWhippetEntityRepository<TEntity, int>, IWhippetRepository<TEntity, int>, IDisposable
        where TEntity : SuperDuperLegacyEntity
    {
        /// <summary>
        /// Gets the <see cref="ISession"/> instance that provides access to the current application NHibernate connection. This property is read-only.
        /// </summary>
        ISession Context
        { get; }

        /// <summary>
        /// Gets the <see cref="IStatelessSession"/> instance that provides a cacheless level of override to the current application NHibernate connection. This property is read-only.
        /// </summary>
        IStatelessSession StatelessContext
        { get; }

        /// <summary>
        /// Indicates whether <see cref="StatelessContext"/> has been configured for this instance. This property is read-only.
        /// </summary>
        bool StatelessContextConfigured
        { get; }
    }
}
