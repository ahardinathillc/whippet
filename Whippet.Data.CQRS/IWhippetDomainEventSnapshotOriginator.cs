using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.EventManagement;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Provides support to aggregate entities that can provides snapshots of their current state.
    /// </summary>
    public interface IWhippetDomainEventSnapshotOriginator : IWhippetEventSnapshotOriginator
    {
        /// <summary>
        /// Gets a snapshot of the current entity.
        /// </summary>
        /// <returns><see cref="WhippetDomainEventSnapshot"/> object.</returns>
        new WhippetDomainEventSnapshot GetSnapshot();

        /// <summary>
        /// Loads the specified <see cref="WhippetDomainEventSnapshot"/> and applies it to the entity.
        /// </summary>
        /// <param name="snapshot"><see cref="WhippetDomainEventSnapshot"/> object to load.</param>
        /// <exception cref="ArgumentNullException" />
        void LoadSnapshot(WhippetDomainEventSnapshot snapshot);

        /// <summary>
        /// Indicates whether the current entity should load the specified <see cref="WhippetDomainEventSnapshot"/>.
        /// </summary>
        /// <param name="previousSnapshot">Previous <see cref="WhippetDomainEventSnapshot"/> object that was captured.</param>
        /// <returns><see langword="true"/> if the current entity should load the specified snapshot; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        bool ShouldTakeSnapshot(WhippetDomainEventSnapshot previousSnapshot);
    }
}
