using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.EventManagement;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Represents a "point-in-time" status for a <see cref="WhippetDomainEvent"/> object. This class must be inherited.
    /// </summary>
    public class WhippetDomainEventSnapshot : WhippetEventSnapshot
    {
        /// <summary>
        /// Gets or sets the aggregate root ID of the snapshot.
        /// </summary>
        public Guid AggregateRootID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDomainEventSnapshot"/> class with no arguments.
        /// </summary>
        public WhippetDomainEventSnapshot()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDomainEventSnapshot"/> class with the specified aggregate root ID and last event sequence number.
        /// </summary>
        /// <param name="aggregateRootId">Aggregate root ID.</param>
        /// <param name="lastEventSequence">Last event sequence number.</param>
        public WhippetDomainEventSnapshot(Guid aggregateRootId, int lastEventSequence)
            : base(lastEventSequence)
        {
            AggregateRootID = aggregateRootId;
        }
    }
}
