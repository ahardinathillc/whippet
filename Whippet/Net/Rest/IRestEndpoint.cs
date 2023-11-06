using System;
using System.Collections.Generic;

namespace Athi.Whippet.Net.Rest
{
    /// <summary>
    /// Represents a single instance of a remote endpoint that can be interacted with via HTTP.
    /// </summary>
    public interface IRestEndpoint : IEqualityComparer<IRestEndpoint>
    {
        /// <summary>
        /// Gets or sets the (encrypted) username to access the endpoint, if any.
        /// </summary>
        string Username
        { get; set; }

        /// <summary>
        /// Gets or sets the (encrypted) password to access the endpoint, if any.
        /// </summary>
        string Password
        { get; set; }

        /// <summary>
        /// Gets or sets the REST endpoint URL.
        /// </summary>
        string URL
        { get; set; }
    }
}

