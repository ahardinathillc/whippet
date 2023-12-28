using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NHibernateConfiguration = NHibernate.Cfg.Configuration;
using MappingConfiguration = FluentNHibernate.Cfg.MappingConfiguration;
using Athi.Whippet.Collections.Extensions;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Database.Microsoft;
using Athi.Whippet.Data.NHibernate;
using Athi.Whippet.Data.NHibernate.MappingIndex;
using Athi.Whippet.ResourceManagement;
using Athi.Whippet.Tools.Installer.ResourceFiles;

namespace Athi.Whippet.Tools.Installer
{
    /// <summary>
    /// Install runner that installs and seeds Whippet entities.
    /// </summary>
    [Obsolete("This component is deprecated and will be removed in a future version.")]
    public class WhippetEntityInstallRunner : WhippetInstallRunner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetEntityInstallRunner"/> class.
        /// </summary>
        /// <param name="connectionString">Connection string to the data store.</param>
        /// <param name="installerName">Name of the product or application the installer implements.</param>
        /// <param name="installerDescription">Installer description.</param>
        /// <param name="skipSeed">If <see langword="true"/>, will skip any entity seeding routine and instead just perform schema updates.</param>
        /// <param name="externalMappings">External entities that need to be mapped. Required by NHibernate.</param>
        /// <param name="externalEntities">External entities to install.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetEntityInstallRunner(string connectionString, string installerName, string installerDescription, bool skipSeed, Action<MappingConfiguration> externalMappings = null, SortedList<int, IWhippetEntitySeed> externalEntities = null)
            : base(connectionString, installerName, installerDescription)
        {
            InstallActions.Enqueue(new __InstallAction_Entities(StringResourceLoader.GetResource(GetType(), ResourceIndex.InstallAction_Entity_Name), StringResourceLoader.GetResource(GetType(), ResourceIndex.InstallAction_Entity_Description), connectionString, skipSeed, externalMappings, externalEntities));
        }

        /// <summary>
        /// Installer action for Whippet entities. This class cannot be inherited.
        /// </summary>
        private sealed class __InstallAction_Entities : InstallActionBase
        {
            /// <summary>
            /// Specifies whether all seed actions should be ignored and only schema updates will be performed.
            /// </summary>
            private bool SkipSeed
            { get; set; }

            /// <summary>
            /// Gets or sets the current SQL Server connection string.
            /// </summary>
            private string ConnectionString
            { get; set; }

            /// <summary>
            /// Gets or sets the internal list of external entities to install.
            /// </summary>
            private SortedList<int, IWhippetEntitySeed> ExternalEntities
            { get; set; }

            /// <summary>
            /// Gets or sets the internal <see cref="Action{T1}"/> for mapping external entities. Required by NHibernate.
            /// </summary>
            private Action<MappingConfiguration> ExternalMappings
            { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="__InstallAction_Entities"/> class with the specified connection string.
            /// </summary>
            /// <param name="name">Action name.</param>
            /// <param name="description">Installer description.</param>
            /// <param name="connectionString">Connection string to the SQL Server database where the Whippet database resides.</param>
            /// <param name="externalMappings">External entities that need to be mapped. Required by NHibernate.</param>
            /// <param name="externalEntities">External entities to install.</param>
            /// <exception cref="ArgumentNullException" />
            public __InstallAction_Entities(string name, string description, string connectionString, Action<MappingConfiguration> externalMappings = null, SortedList<int, IWhippetEntitySeed> externalEntities = null)
                : this(name, description, connectionString, false, externalMappings, externalEntities)
            { }

            /// <summary>
            /// Initializes a new instance of the <see cref="__InstallAction_Entities"/> class with the specified connection string.
            /// </summary>
            /// <param name="name">Action name.</param>
            /// <param name="description">Installer description.</param>
            /// <param name="connectionString">Connection string to the SQL Server database where the Whippet database resides.</param>
            /// <param name="skipSeed">If <see langword="true"/>, will skip any entity seeding routine and instead just perform schema updates.</param>
            /// <param name="externalMappings">External entities that need to be mapped. Required by NHibernate.</param>
            /// <param name="externalEntities">External entities to install.</param>
            /// <exception cref="ArgumentNullException" />
            public __InstallAction_Entities(string name, string description, string connectionString, bool skipSeed, Action<MappingConfiguration> externalMappings = null, SortedList<int, IWhippetEntitySeed> externalEntities = null)
                : base(name, description)
            {
                if (String.IsNullOrWhiteSpace(connectionString))
                {
                    throw new ArgumentNullException(nameof(connectionString));
                }
                else
                {
                    SkipSeed = skipSeed;
                    ExternalEntities = externalEntities;
                    ConnectionString = WhippetSqlServerConnection.RemoveUnsupportedKeywords(connectionString);
                    ExternalMappings = externalMappings;
                }
            }

            /// <summary>
            /// Creates and opens a new <see cref="ISession"/> context for SQL Server based on the specified connection string.
            /// </summary>
            /// <param name="connectionString">Connection string to define the context with.</param>
            /// <returns><see cref="ISession"/> object.</returns>
            /// <exception cref="ArgumentNullException" />
            private ISession CreateSqlServerSession(string connectionString, Action<MappingConfiguration> externalMappings)
            {
                if (String.IsNullOrWhiteSpace(connectionString))
                {
                    throw new ArgumentNullException(nameof(connectionString));
                }
                else
                {
                    ISessionFactory factory = null;
                    ISession session = null;

                    NHibernateConfigurationOptions options = new NHibernateConfigurationOptions();

                    WhippetSqlServerConnectionStringBuilder builder = new WhippetSqlServerConnectionStringBuilder(connectionString);

                    builder.InitialCatalog = "Whippet";                 // make sure to set this to the Whippet database! Do not change!

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

                    connectionString = builder.ToString();

                    NHibernateConfigurationHelper.ConfigureForSqlServerWithConnectionString(options, connectionString);

                    WhippetNHibernateMappingIndex.ConfigureMicrosoftSqlServerMappings(options, externalMappings);

                    options.NHibernateConfiguration = new Action<NHibernateConfiguration>(config =>
                    {
                        new SchemaUpdate(config).Execute(false, true);
                    });

                    factory = DefaultNHibernateSessionFactory.Create(options);
                    session = factory.OpenSession();

                    return session;
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
                ISession session = CreateSqlServerSession(ConnectionString, ExternalMappings);

                SortedList<int, IWhippetEntitySeed> toInstall = new SortedList<int, IWhippetEntitySeed>();

                // Get all indexes first -- use fully qualified namespace name to prevent clashes
                Athi.Whippet.Localization.Addressing.Installer.AddressingInstallerIndex aiIndex = new Localization.Addressing.Installer.AddressingInstallerIndex(session, SkipSeed, pDelegate);

                // then append the objects in the order they are to be installed
                toInstall.Append(aiIndex.GetObjects());

                // then append external entities (if any)
                if (ExternalEntities != null && ExternalEntities.Any())
                {
                    toInstall.Append(ExternalEntities);
                }

                // Begin installation

                foreach (KeyValuePair<int, IWhippetEntitySeed> seed in toInstall)
                {
                    result = seed.Value.Seed(pDelegate);

                    if (!result.IsSuccess)
                    {
                        break;
                    }
                }

                return result;
            }
        }
    }
}
