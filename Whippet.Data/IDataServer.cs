using System;
using System.Collections.Generic;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Represents a server that serves as a data connection, such as GraphQL, REST, or database.
    /// </summary>
    public interface IDataServer
    {
        /// <summary>
        /// Gets or sets the server address (URL, host name, IP address, or network share).
        /// </summary>
        string DataSource
        { get; set; }
        
        /// <summary>
        /// Gets or sets the (encrypted) username to access the server, if any.
        /// </summary>
        string Username
        { get; set; }

        /// <summary>
        /// Gets or sets the (encrypted) password to access the server, if any.
        /// </summary>
        string Password
        { get; set; }

        /// <summary>
        /// Indicates the type of the current <see cref="IDataServer"/>. This property is read-only.
        /// </summary>
        ExternalDataSourceType ServerType
        { get; }
    }
}
