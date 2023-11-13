using System;
using NodaTime;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Provides look up fields for an <see cref="IMultichannelOrderManagerEntity"/> object.
    /// </summary>
    public interface IMultichannelOrderManagerLookup : IMultichannelOrderManagerEntity
    {
        /// <summary>
        /// Gets or sets the username of who last looked up the record.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string LookupBy
        { get; set; }

        /// <summary>
        /// Date and time the record was last accessed.
        /// </summary>
        Instant? LookupOn
        { get; set; }
    }
}
