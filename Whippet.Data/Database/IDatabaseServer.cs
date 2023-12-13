using System;
using System.Collections.Generic;

namespace Athi.Whippet.Data.Database
{
    /// <summary>
    /// Represents an <see cref="IDataServer"/> that connects to a database.
    /// </summary>
    /// <typeparam name="TConnection">Type of <see cref="WhippetDatabaseConnection"/> that the database server uses.</typeparam>
    public interface IDatabaseServer<TConnection> : IDataServer where TConnection : WhippetDatabaseConnection, new()
    {
        /// <summary>
        /// Gets a <see cref="DatabaseConnectionPropertyVisibilityMask"/> that specifies which properties are to be used in building the connection string called by <see cref="CreateConnection()"/>. By default, all properties are set to <see langword="true"/>. This property is read-only. 
        /// </summary>
        DatabaseConnectionPropertyVisibilityMask ConnectionPropertyMask
        { get; }
            
        /// <summary>
        /// Creates a new <typeparamref name="TConnection"/> object based on the current instance's properties.
        /// </summary>
        /// <returns><typeparamref name="TConnection"/> object.</returns>
        TConnection CreateConnection();
    }
}
