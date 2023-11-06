using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Tools.DatabaseManager
{
    /// <summary>
    /// Represents a known <see cref="WhippetDatabaseType"/> in Whippet.
    /// </summary>
    public enum WhippetDatabaseKnownType
    {
        /// <summary>
        /// The database type is known.
        /// </summary>
        Unknown,
        /// <summary>
        /// Microsoft SQL Server.
        /// </summary>
        SqlServer = 1
    }
}
