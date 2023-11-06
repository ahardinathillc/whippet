using System;

namespace Athi.Whippet.Logging
{
    /// <summary>
    /// Provides support to features that can be logged by providing a unique event ID.
    /// </summary>
    public interface IWhippetEventId
    {
        /// <summary>
        /// Gets the feature's event ID. This property is read-only.
        /// </summary>
        int EventID
        { get; }
    }
}

