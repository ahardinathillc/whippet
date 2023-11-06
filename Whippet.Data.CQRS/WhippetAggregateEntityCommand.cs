using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Represents a command that is executed in Whippet against a command handler to update an aggregate entity's state. This class must be inherited.
    /// </summary>
    public abstract class WhippetAggregateEntityCommand : WhippetCommand, IWhippetCommand, IWhippetAggregateEntityCommand
    {
        /// <summary>
        /// Gets the aggregate root ID of the entity the command is executed against. This property is read-only.
        /// </summary>
        public Guid AggregateRootID
        { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAggregateEntityCommand"/> class with no arguments.
        /// </summary>
        protected WhippetAggregateEntityCommand()
            : this(Guid.NewGuid())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAggregateEntityCommand"/> class with the specified aggregate root ID.
        /// </summary>
        /// <param name="aggregateRootId">Aggregate root ID.</param>
        protected WhippetAggregateEntityCommand(Guid aggregateRootId)
            : base()
        {
            AggregateRootID = aggregateRootId;
        }
    }
}
