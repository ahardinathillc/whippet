using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Represents a command that is executed in Whippet against a command handler to update an entity's state. This class must be inherited.
    /// </summary>
    public abstract class WhippetCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the unique ID of the command that was generated upon the object's instantiation. This property is read-only.
        /// </summary>
        public Guid ID
        { get; private set; }

        /// <summary>
        /// Gets the instant that the command was generated upon the object's instantiation. This property is read-only.
        /// </summary>
        public Instant CreatedTimestamp
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCommand"/> class with no arguments.
        /// </summary>
        protected WhippetCommand()
        {
            ID = Guid.NewGuid();
            CreatedTimestamp = Instant.FromDateTimeUtc(DateTime.UtcNow);
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return ID.ToString() + " - " + CreatedTimestamp.ToString();
        }
    }
}
