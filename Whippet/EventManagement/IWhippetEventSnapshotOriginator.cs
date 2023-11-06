using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.EventManagement
{
    /// <summary>
    /// Provides support to entities that can provides snapshots of their current state.
    /// </summary>
    public interface IWhippetEventSnapshotOriginator
    {
        /// <summary>
        /// Gets a snapshot of the current entity.
        /// </summary>
        /// <returns><see cref="WhippetEventSnapshot"/> object.</returns>
        WhippetEventSnapshot GetSnapshot();

        /// <summary>
        /// Loads the specified <see cref="WhippetEventSnapshot"/> and applies it to the entity.
        /// </summary>
        /// <param name="snapshot"><see cref="WhippetEventSnapshot"/> object to load.</param>
        /// <exception cref="ArgumentNullException" />
        void LoadSnapshot(WhippetEventSnapshot snapshot);

        /// <summary>
        /// Indicates whether the current entity should load the specified <see cref="WhippetEventSnapshot"/>.
        /// </summary>
        /// <param name="previousSnapshot">Previous <see cref="WhippetEventSnapshot"/> object that was captured.</param>
        /// <returns><see langword="true"/> if the current entity should load the specified snapshot; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        bool ShouldTakeSnapshot(WhippetEventSnapshot previousSnapshot);
    }
}
