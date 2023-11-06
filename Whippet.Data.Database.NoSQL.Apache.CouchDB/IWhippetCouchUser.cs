using System;
using CouchDB.Driver.Types;

namespace Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB
{
    /// <summary>
    /// Represents a <see cref="CouchUser"/> in Whippet.
    /// </summary>
    public interface IWhippetCouchUser : IWhippetCouchDocument, IWhippetEntity, IEqualityComparer<IWhippetCouchUser>
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        string Name
        { get; set; }

        /// <summary>
        /// Gets or sets all roles that are applied to the user.
        /// </summary>
        IList<string> Roles
        { get; set; }

        /// <summary>
        /// Gets or sets the user type.
        /// </summary>
        string Type
        { get; set; }

        /// <summary>
        /// Returns the current instance as a <see cref="CouchUser"/> object.
        /// </summary>
        /// <returns><see cref="CouchUser"/> object.</returns>
        CouchUser ToCouchUser();
    }
}

