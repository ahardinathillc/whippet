using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Represents a command that is executed in Whippet against a command handler to update an entity's state.
    /// </summary>
    public interface IWhippetCommand
    {
        /// <summary>
        /// Gets the unique ID of the command that was generated upon the object's instantiation. This property is read-only.
        /// </summary>
        Guid ID
        { get; }

        /// <summary>
        /// Gets the instant that the command was generated upon the object's instantiation. This property is read-only.
        /// </summary>
        Instant CreatedTimestamp
        { get; }
    }
}
