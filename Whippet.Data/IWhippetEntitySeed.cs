using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Provides seed functionality for the specified <see cref="IWhippetEntity"/> type. Seed data is used to insert default data when instantiating a new, empty data store or adding a new feature.
    /// </summary>
    /// <typeparam name="T"><see cref="WhippetEntity"/> type that is being seeded.</typeparam>
    public interface IWhippetEntitySeed<T> : IWhippetEntitySeed
        where T : WhippetEntity, IWhippetEntity
    {
        /// <summary>
        /// Seeds the current data store provided by NHibernate given the specified <see cref="IWhippetEntityRepository{TEntity, TKey}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetEntityRepository{TEntity, TKey}"/> that is the backing data store where the entities will be stored.</param>
        /// <param name="statusUpdater"><see cref="Delegate"/> that provides real-time updates to each record being updated.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the seed action with each <see cref="IWhippetEntity"/> object(s).</returns>
        /// <exception cref="ArgumentNullException" />
        IEnumerable<WhippetResultContainer<T>> Seed(IWhippetEntityRepository<T, Guid> repository, ProgressDelegate statusUpdater = null);
    }
}
