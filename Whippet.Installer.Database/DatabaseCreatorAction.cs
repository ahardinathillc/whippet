using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Athi.Whippet.Data.Database;

namespace Athi.Whippet.Installer.Database
{
    /// <summary>
    /// Base class for all <see cref="InstallerAction"/> objects that handle database creation. This class must be inherited.
    /// </summary>
    public abstract class DatabaseCreatorAction : InstallerAction, IDisposable
    {
        /// <summary>
        /// Gets the database script files to execute in the order that they are to be executed. This property is read-only.
        /// </summary>
        protected IReadOnlyDictionary<int, FileInfo> ScriptFiles
        { get; private set; }
        
        /// <summary>
        /// Gets the database connection that is used to connect to the server to create the database. This property is read-only.
        /// </summary>
        protected virtual WhippetDatabaseConnection Connection
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseCreatorAction"/> class with the specified action title.
        /// </summary>
        /// <param name="actionTitle">Short descriptive title of the installer action that is being executed.</param>
        /// <param name="actionReporter"><see cref="Action{T}"/> that reports the current status of the operation.</param>
        /// <param name="connection"><see cref="WhippetDatabaseConnection"/> used to connect to the server to create the database.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected DatabaseCreatorAction(string actionTitle, Action<string> actionReporter, WhippetDatabaseConnection connection, IEnumerable<KeyValuePair<int, FileInfo>> scriptFiles = null)
            : base(actionTitle, actionReporter)
        {
            ArgumentNullException.ThrowIfNull(connection);

            Connection = connection;
            
            if (scriptFiles != null)
            {
                ScriptFiles = new ReadOnlyDictionary<int, FileInfo>(new SortedList<int, FileInfo>(scriptFiles is IDictionary<int, FileInfo> ? (IDictionary<int, FileInfo>)(scriptFiles) : new Dictionary<int, FileInfo>(scriptFiles)));
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public void Dispose()
        {
            if (Connection != null)
            {
                Connection.Dispose();
                Connection = null;
            }
        }
    }
}
