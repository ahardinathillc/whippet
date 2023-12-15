using System;
using Athi.Whippet.Data.Database;
using Athi.Whippet.Data.Database.Microsoft;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents a database server for a Multichannel Order Manager application instance.
    /// </summary>
    public interface IMultichannelOrderManagerDatabaseServer : IMultichannelOrderManagerServer, IWhippetSqlServerDatabaseServer, IDatabaseServer<WhippetSqlServerConnection>
    { }
}
