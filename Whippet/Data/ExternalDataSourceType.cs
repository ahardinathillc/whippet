using System;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Categorizes the type of an external data source profile.
    /// </summary>
    [Flags]
    public enum ExternalDataSourceType : byte
    {
        /// <summary>
        /// Indicates that the data source profile is a database connection.
        /// </summary>
        Database = 1,
        /// <summary>
        /// Indicates that the data source profile is a REST connection.
        /// </summary>
        REST = 2
    }
}

