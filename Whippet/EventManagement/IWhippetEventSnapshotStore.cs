using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.EventManagement
{
    /// <summary>
    /// Represents a data store for <see cref="WhippetEventSnapshot"/> objects.
    /// </summary>
    public interface IWhippetEventSnapshotStore
    {
        /// <summary>
        /// Gets the first instance of a <see cref="WhippetEventSnapshot"/> that matches the specified predicate.
        /// </summary>
        /// <typeparam name="T"><see cref="WhippetEventSnapshot"/> class type.</typeparam>
        /// <param name="filter">Filter used to specify the <see cref="WhippetEventSnapshot"/> to retrieve.</param>
        /// <returns><see cref="WhippetEventSnapshot"/> object.</returns>
        T GetSnapshot<T>(Func<T, bool> filter) where T : WhippetEventSnapshot, new();

        /// <summary>
        /// Saves the specified <see cref="WhippetEventSnapshot"/> to the store.
        /// </summary>
        /// <typeparam name="T"><see cref="WhippetEventSnapshot"/> class type.</typeparam>
        /// <param name="snapshot"><see cref="WhippetEventSnapshot"/> object to save.</param>
        /// <exception cref="ArgumentNullException" />
        void SaveSnapshot<T>(T snapshot) where T : WhippetEventSnapshot, new();
    }
}
