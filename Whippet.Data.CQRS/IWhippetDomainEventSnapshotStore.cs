using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.EventManagement;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Represents a data store for <see cref="WhippetDomainEventSnapshot"/> objects.
    /// </summary>
    public interface IWhippetDomainEventSnapshotStore : IWhippetEventSnapshotStore
    {
        /// <summary>
        /// Gets the <see cref="WhippetDomainEventSnapshot"/> object with the specified aggregate root ID.
        /// </summary>
        /// <param name="aggregateRootId">Aggregate root ID.</param>
        /// <returns><see cref="WhippetDomainEventSnapshot"/> object.</returns>
        WhippetDomainEventSnapshot GetSnapshot(Guid aggregateRootId);
    }
}
