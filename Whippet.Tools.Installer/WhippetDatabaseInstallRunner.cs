using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernateConfiguration = NHibernate.Cfg.Configuration;
using NHibernate.Tool.hbm2ddl;
using MappingConfiguration = FluentNHibernate.Cfg.MappingConfiguration;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Database.Microsoft;
using Athi.Whippet.Data.NHibernate.MappingIndex;
using Athi.Whippet.ResourceManagement;
using Athi.Whippet.Tools.Installer.ResourceFiles;
using Athi.Whippet.Data.NHibernate;

namespace Athi.Whippet.Tools.Installer
{
    /// <summary>
    /// Handles the installation and configuration of the Whippet database.
    /// </summary>
    [Obsolete("This component is deprecated and will be removed in a future version.")]
    public class WhippetDatabaseInstallRunner : WhippetInstallRunner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDatabaseInstallRunner"/> class.
        /// </summary>
        /// <param name="connectionString">Connection string to the data store.</param>
        /// <param name="installerName">Name of the product or application the installer implements.</param>
        /// <param name="installerDescription">Installer description.</param>
        /// <param name="schemaUpdateStdOut">If <see langword="true"/>, will print the update statements to standard out.</param>
        /// <param name="updateSchema">If <see langword="true"/>, will update existing schemas to match their current implementations.</param>
        /// <param name="externalMappings">External schema mappings to configure during setup.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetDatabaseInstallRunner(string connectionString, string installerName, string installerDescription, bool schemaUpdateStdOut = false, bool updateSchema = true, Action<MappingConfiguration> externalMappings = null)
            : base(connectionString, installerName, installerDescription)
        {
            InstallActions.Enqueue(new __InstallAction_Database(StringResourceLoader.GetResource(GetType(), ResourceIndex.InstallAction_Database_Name), StringResourceLoader.GetResource(GetType(), ResourceIndex.InstallAction_Database_Description), ConnectionString));
            InstallActions.Enqueue(new __InstallAction_Database_Schema(StringResourceLoader.GetResource(GetType(), ResourceIndex.InstallAction_Schema), StringResourceLoader.GetResource(GetType(), ResourceIndex.InstallAction_Schema_Description), ConnectionString, schemaUpdateStdOut, updateSchema, externalMappings));
        }

        /// <summary>
        /// Installation action for installing the Whippet database schemas. This class cannot be inherited.
        /// </summary>
        private sealed class __InstallAction_Database_Schema : InstallActionBase
        {
            /// <summary>
            /// Gets or sets the <see cref="Action{T}"/> that maps external entities during setup.
            /// </summary>
            private Action<MappingConfiguration> ExternalMappings
            { get; set; }

            /// <summary>
            /// Gets or sets the internal <see cref="WhippetSqlServerConnection"/> connection string object.
            /// </summary>
            private string ConnectionString
            { get; set; }

            /// <summary>
            /// If <see langword="true"/>, will print the update statements to standard out.
            /// </summary>
            private bool UseStdOut
            { get; set; }

            /// <summary>
            /// If <see langword="true"/>, will update existing schemas to match their current implementations.
            /// </summary>
            private bool UpdateSchemas
            { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="__InstallAction_Database_Schema"/> class with the specified name and description.
            /// </summary>
            /// <param name="name">Name of the action.</param>
            /// <param name="description">Action description.</param>
            /// <param name="connectionString">Connection string that connects to the database server that will host the Whippet database.</param>
            /// <param name="schemaUpdateStdOut">If <see langword="true"/>, will print the update statements to standard out.</param>
            /// <param name="updateSchema">If <see langword="true"/>, will update existing schemas to match their current implementations.</param>
            /// <param name="externalMappings">External schema mappings to configure during setup.</param>
            /// <exception cref="ArgumentNullException" />
            public __InstallAction_Database_Schema(string name, string description, string connectionString, bool schemaUpdateStdOut = false, bool updateSchema = true, Action<MappingConfiguration> externalMappings = null)
                : base(name, description)
            {
                if (String.IsNullOrWhiteSpace(connectionString))
                {
                    throw new ArgumentNullException(nameof(connectionString));
                }
                else
                {
                    ExternalMappings = externalMappings;
                    ConnectionString = WhippetSqlServerConnection.RemoveUnsupportedKeywords(connectionString);
                    UseStdOut = schemaUpdateStdOut;
                    UpdateSchemas = updateSchema;
                }
            }

            /// <summary>
            /// Performs the installation action.
            /// </summary>
            /// <param name="pDelegate"><see cref="ProgressDelegate"/> used to measure the progress of the operation.</param>
            /// <returns><see cref="WhippetResult"/> of the operation.</returns>
            public override WhippetResult PerformAction(ProgressDelegate pDelegate = null)
            {
                WhippetResult result = WhippetResult.Success;

                NHibernateConfigurationOptions options;
                ISessionFactory factory = null;
                ISession session = null;

                WhippetSqlServerConnectionStringBuilder builder = new WhippetSqlServerConnectionStringBuilder(ConnectionString);

                ReportProgress(pDelegate, 0, StringResourceLoader.GetResource(GetType(), ResourceIndex.InstallAction_Schema));

                try
                {
                    if (!DatabaseIsSqlServerLinuxContainer)
                    {
                        // these are for development and deployment only--production machines should have a valid certificate
                        builder.TrustServerCertificate = true;
                        builder.Encrypt = false;
                    }
                    else
                    {
                        builder.Remove(nameof(builder.Encrypt));
                        builder.Remove(nameof(builder.TrustServerCertificate));
                    }

                    options = new NHibernateConfigurationOptions();

                    WhippetNHibernateMappingIndex.ConfigureMicrosoftSqlServerMappings(options, ExternalMappings);
                    WhippetSqlServerNHibernateDatabaseConfiguration.ConfigureForSqlServer(options, builder.ToString());

                    WhippetNHibernateMappingIndex.ConfigureMicrosoftSqlServerMappings(options, ExternalMappings);

                    ReportProgress(pDelegate, 50, StringResourceLoader.GetResource(GetType(), ResourceIndex.InstallAction_Schema__SchemaSetup1));

                    options.NHibernateConfiguration = new Action<NHibernateConfiguration>(config =>
                    {
                        new SchemaUpdate(config).Execute(UseStdOut, UpdateSchemas);
                    });

                    factory = DefaultNHibernateSessionFactory.Create(options);
                    session = factory.OpenSession();

                    ReportProgress(pDelegate, 100, StringResourceLoader.GetResource(GetType(), ResourceIndex.InstallAction_Schema__SchemaSetup2));
                }
                catch (Exception schemaException)
                {
                    if (schemaException.InnerException != null)
                    {
                        result = new WhippetResult(WhippetResultSeverity.Failure, schemaException.InnerException.ToString(), schemaException);
                        ReportProgress(pDelegate, 100, schemaException.InnerException.Message, WhippetResultSeverity.Failure);
                    }
                    else
                    {
                        result = new WhippetResult(schemaException);
                        ReportProgress(pDelegate, 100, schemaException.Message, WhippetResultSeverity.Failure);
                    }
                }
                finally
                {
                    if (session != null)
                    {
                        session.Close();
                        session.Dispose();
                    }

                    if (factory != null)
                    {
                        factory.Dispose();
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Installation action for installing the Whippet database. This class cannot be inherited.
        /// </summary>
        private sealed class __InstallAction_Database : InstallActionBase
        {
            /// <summary>
            /// Gets or sets the internal <see cref="WhippetSqlServerConnection"/> connection string object.
            /// </summary>
            private string ConnectionString
            { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="__InstallAction_Database"/> class with the specified name and description.
            /// </summary>
            /// <param name="name">Name of the action.</param>
            /// <param name="description">Action description.</param>
            /// <param name="connectionString">Connection string that connects to the database server that will host the Whippet database.</param>
            /// <exception cref="ArgumentNullException" />
            public __InstallAction_Database(string name, string description, string connectionString)
                : base(name, description)
            {
                if (String.IsNullOrWhiteSpace(connectionString))
                {
                    throw new ArgumentNullException(nameof(connectionString));
                }
                else
                {
                    ConnectionString = WhippetSqlServerConnection.RemoveUnsupportedKeywords(connectionString);
                }
            }

            /// <summary>
            /// Performs the installation action.
            /// </summary>
            /// <param name="pDelegate"><see cref="ProgressDelegate"/> used to measure the progress of the operation.</param>
            /// <returns><see cref="WhippetResult"/> of the operation.</returns>
            public override WhippetResult PerformAction(ProgressDelegate pDelegate = null)
            {
                WhippetResult result = WhippetResult.Success;

                WhippetSqlServerConnection connection = null;
                WhippetSqlServerCommand command = null;

                WhippetSqlServerConnectionStringBuilder builder = null;

                string sqlScript = null;

                // create account first

                ReportProgress(pDelegate, 0, StringResourceLoader.GetResource(GetType(), ResourceIndex.InstallAction_Database_Server__AccountSetup1));

                // need to change the database on ConnectionString to [master] first

                builder = new WhippetSqlServerConnectionStringBuilder(ConnectionString);
                builder.InitialCatalog = "master"; // DON'T CHANGE THIS

                try
                {
                    sqlScript = SqlScriptLoader.GetSqlScript(ResourceIndex.SqlScripts.WhippetAccount);

                    connection = new WhippetSqlServerConnection(builder.ToString());
                    command = new WhippetSqlServerCommand(sqlScript, connection);

                    connection.Open();
                    command.ExecuteSqlScript();
                }
                catch (Exception accountException)
                {
                    result = new WhippetResult(accountException);
                    ReportProgress(pDelegate, 100, accountException.Message, WhippetResultSeverity.Failure);
                }
                finally
                {
                    if (command != null)
                    {
                        command.Dispose();
                        command = null;
                    }

                    if (connection != null)
                    {
                        connection.Close();
                        connection.Dispose();
                        connection = null;
                    }
                }

                if (result.IsSuccess)
                {
                    ReportProgress(pDelegate, 50, StringResourceLoader.GetResource(GetType(), ResourceIndex.InstallAction_Database_Server__DatabaseSetup1));

                    try
                    {
                        sqlScript = SqlScriptLoader.GetSqlScript(ResourceIndex.SqlScripts.WhippetDatabase);

                        if (String.IsNullOrWhiteSpace(DatabaseName))
                        {
                            DatabaseName = DEFAULT_DB_NAME;
                        }

                        sqlScript = sqlScript.Replace("$$WHIPPET$$", DatabaseName, StringComparison.InvariantCultureIgnoreCase);

                        connection = new WhippetSqlServerConnection(builder.ToString());
                        connection.Open();

                        command = new WhippetSqlServerCommand(sqlScript, connection);
                        command.ExecuteSqlScript();
                    }
                    catch (Exception databaseException)
                    {
                        result = new WhippetResult(databaseException);
                        ReportProgress(pDelegate, 100, databaseException.Message, WhippetResultSeverity.Failure);
                    }
                    finally
                    {
                        if (command != null)
                        {
                            command.Dispose();
                            command = null;
                        }

                        if (connection != null)
                        {
                            connection.Close();
                            connection.Dispose();
                            connection = null;
                        }
                    }
                }

                if (result.IsSuccess)
                {
                    ReportProgress(pDelegate, 100, StringResourceLoader.GetResource(GetType(), ResourceIndex.InstallAction_Database_Server__DatabaseSetup2));
                }

                return result;
            }
        }
    }
}
