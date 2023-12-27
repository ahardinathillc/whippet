using System;
using NHibernate;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Provides seed functionality for any <see cref="IWhippetEntity"/> type. Seed data is used to insert default data when instantiating a new, empty data store or adding a new feature.
    /// </summary>
    [Obsolete("This interface is obsolete and will be removed in a future version.", false)]
    public interface IWhippetEntitySeed
    {
        /// <summary>
        /// Seeds the current data store provided by NHibernate.
        /// </summary>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResult Seed();

        /// <summary>
        /// Seeds the current data store provided by NHibernate.
        /// </summary>
        /// <param name="statusUpdater"><see cref="Delegate"/> that provides real-time updates to each record being updated.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResult Seed(ProgressDelegate statusUpdater);

        /// <summary>
        /// Seeds the current data store provided by NHibernate. This method is intended to invoke the specific seed operation with a given repository.
        /// </summary>
        /// <param name="context">Context for the current NHibernate session.</param>
        /// <param name="statusUpdater"><see cref="Delegate"/> that provides real-time updates to each record being updated.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResult Seed(ISession context, ProgressDelegate statusUpdater = null);
    }
}
