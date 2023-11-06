using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Represents a command that is executed in Whippet against a command handler to update an aggregate entity's state.
    /// </summary>
    public interface IWhippetAggregateEntityCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the aggregate root ID of the entity the command is executed against. This property is read-only.
        /// </summary>
        Guid AggregateRootID
        { get; }
    }
}
