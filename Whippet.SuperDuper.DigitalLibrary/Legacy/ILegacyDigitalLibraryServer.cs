using System;
using Athi.Whippet.Data.Database;
using Athi.Whippet.Data.Database.Microsoft;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy
{
    /// <summary>
    /// Represents the database server for the legacy Super Duper Digital Library (SDDL) application.
    /// </summary>
    public interface ILegacyDigitalLibraryServer : ISuperDuperServer, IWhippetSqlServerDatabaseServer, IDatabaseServer<WhippetSqlServerConnection>
    {
        /// <summary>
        /// Gets or sets the mirror database server or <see langword="null"/> if no mirror is used.
        /// </summary>
        new ILegacyDigitalLibraryServer Mirror
        { get; set; }
    }
}
