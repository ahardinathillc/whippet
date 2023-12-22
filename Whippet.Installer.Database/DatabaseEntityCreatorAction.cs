using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Athi.Whippet.Data.Database;

namespace Athi.Whippet.Installer.Database
{
    public abstract class DatabaseEntityCreatorAction : InstallerAction, IDisposable
    {
        /// <summary>
        /// Gets the name of the entity being installed. This property is read-only.
        /// </summary>
        public string EntityName
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="WhippetDatabaseConnection"/> which contains the connection string to the destination database or <see langword="null"/> if a connection string is not used or supplied separately. This property is read-only.
        /// </summary>
        protected WhippetDatabaseConnection DatabaseConnection
        { get; private set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseEntityCreatorAction"/> class with the specified action title.
        /// </summary>
        /// <param name="actionTitle">Short descriptive title of the installer action that is being executed.</param>
        /// <param name="actionReporter"><see cref="Action{T}"/> that reports the current status of the operation.</param>
        /// <param name="entityName">Name of the entity being installed.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected DatabaseEntityCreatorAction(string actionTitle, Action<string> actionReporter, string entityName)
            : this(actionTitle, actionReporter, entityName, null)
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseEntityCreatorAction"/> class with the specified action title.
        /// </summary>
        /// <param name="actionTitle">Short descriptive title of the installer action that is being executed.</param>
        /// <param name="actionReporter"><see cref="Action{T}"/> that reports the current status of the operation.</param>
        /// <param name="entityName">Name of the entity being installed.</param>
        /// <param name="databaseConnection"><see cref="WhippetDatabaseConnection"/> that contains the connection string to the destination database.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected DatabaseEntityCreatorAction(string actionTitle, Action<string> actionReporter, string entityName, WhippetDatabaseConnection databaseConnection)
            : base(actionTitle, actionReporter)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(entityName);
            EntityName = entityName;
            DatabaseConnection = databaseConnection;
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return "[Entity: " + EntityName?.Trim() + "]";
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public virtual void Dispose()
        {
            if (DatabaseConnection != null)
            {
                DatabaseConnection.Dispose();
                DatabaseConnection = null;
            }
        }
    }
}
