using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.EventManagement
{
    /// <summary>
    /// Represents a "point-in-time" status for a <see cref="WhippetEvent"/> object. This class must be inherited.
    /// </summary>
    public abstract class WhippetEventSnapshot
    {
        /// <summary>
        /// Gets or sets the last event sequence number.
        /// </summary>
        public virtual int LastEventSequence
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetEventSnapshot"/> class with no arguments.
        /// </summary>
        protected WhippetEventSnapshot()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetEventSnapshot"/> class with the specified last event sequence number.
        /// </summary>
        /// <param name="lastEventSequence">Last event sequence number.</param>
        protected WhippetEventSnapshot(int lastEventSequence)
            : this()
        {
            LastEventSequence = lastEventSequence;
        }
    }
}
