using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Athi.Whippet.Localization;
using Athi.Whippet.Localization.ResourceFiles;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Provides seed functionality for the specified <see cref="IWhippetEntity"/> type. Seed data is used to insert default data when instantiating a new, empty data store or adding a new feature. This class must be inherited.
    /// </summary>
    /// <typeparam name="T"><see cref="IWhippetEntity"/> class that the seed data is for.</typeparam>
    public abstract class WhippetEntitySeed<T> : IWhippetEntitySeed, IWhippetEntitySeed<T> 
        where T : WhippetEntity, IWhippetEntity
    {
        /// <summary>
        /// Gets the NHibnerate <see cref="ISession"/> that defines the current context. This property is read-only.
        /// </summary>
        protected ISession Context
        { get; private set; }

        /// <summary>
        /// Gets the delegate that measures the current progress of the seed operation. This property is read-only.
        /// </summary>
        protected ProgressDelegate StatusUpdater
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetEntitySeed{T}"/> class with no arguments.
        /// </summary>
        protected WhippetEntitySeed()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetEntitySeed{T}"/> class with the specified <see cref="ISession"/>.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object that describes the current data context.</param>
        /// <param name="statusUpdater"><see cref="Delegate"/> that provides real-time updates to each record being updated.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetEntitySeed(ISession context, ProgressDelegate statusUpdater)
            : this()
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            else
            {
                Context = context;
                StatusUpdater = statusUpdater;
            }
        }

        /// <summary>
        /// Seeds the current data store provided by NHibernate.
        /// </summary>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResult Seed()
        {
            return Seed(Context, StatusUpdater);
        }

        /// <summary>
        /// Seeds the current data store provided by NHibernate.
        /// </summary>
        /// <param name="statusUpdater"><see cref="Delegate"/> that provides real-time updates to each record being updated.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResult Seed(ProgressDelegate statusUpdater = null)
        {
            return Seed(Context, statusUpdater ?? StatusUpdater);
        }

        /// <summary>
        /// Seeds the current data store provided by NHibernate. This method is intended to invoke the specific seed operation with a given repository.
        /// </summary>
        /// <param name="context">Context for the current NHibernate session.</param>
        /// <param name="statusUpdater"><see cref="Delegate"/> that provides real-time updates to each record being updated.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract WhippetResult Seed(ISession context, ProgressDelegate statusUpdater = null);

        /// <summary>
        /// Seeds the current data store provided by NHibernate given the specified <see cref="IWhippetEntityRepository{TEntity, TKey}"/>. This method must be overridden.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetEntityRepository{TEntity, TKey}"/> that is the backing data store where the entities will be stored.</param>
        /// <param name="statusUpdater"><see cref="Delegate"/> that provides real-time updates to each record being updated.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the seed action with each <see cref="IWhippetEntity"/> object(s).</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract IEnumerable<WhippetResultContainer<T>> Seed(IWhippetEntityRepository<T, Guid> repository, ProgressDelegate statusUpdater = null);
    }
}
