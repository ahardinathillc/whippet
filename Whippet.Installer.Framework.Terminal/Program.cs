using System;
using System.Reflection;
using Spectre.Console;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Athi.Whippet.Data.Database;
using Athi.Whippet.Data.Database.Microsoft;
using Athi.Whippet.Data.Database.Oracle.MySQL;
using Athi.Whippet.Data.NHibernate;
using Athi.Whippet.Data.NHibernate.MappingIndex;
using Athi.Whippet.Installer.Framework.Database;
using Athi.Whippet.Installer.Framework.Database.Entities;
using Athi.Whippet.Localization.Addressing.Repositories;
using Athi.Whippet.Localization.Addressing.ServiceManagers;
using Athi.Whippet.ServiceManagers;

namespace Athi.Whippet.Installer.Framework.Terminal
{
    /// <summary>
    /// Object that serves as the entry point of the application. This class cannot be inherited.
    /// </summary>
    /// <remarks>https://spectreconsole.net/markup</remarks>
    public static class Program
    {
        private const string LAYOUT_ROOT = "Root";
        private const string LAYOUT_BAR_TITLE = "_Bar_Title";
        private const string LAYOUT_CONTENT = "_Content";

        private const string ACTION_INSTALL_DATABASE = "Install Database";
        private const string ACTION_QUIT = "Quit";

        private const string DEFAULT_DB_NAME = "Whippet";
        
        /// <summary>
        /// Main entry point of the application.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the application.</param>
        /// <returns>Exit code.</returns>
        public static void Main(params string[] args)
        {
            Layout layout = null;
            
            Panel titlePanel = null;
            Panel contentPanel = null;

            layout = new Layout(LAYOUT_ROOT);
            layout = layout.SplitRows(new Layout(LAYOUT_BAR_TITLE), new Layout(LAYOUT_CONTENT));

            layout[LAYOUT_BAR_TITLE].Size = 3;

            titlePanel = new Panel(Align.Center(new Markup(String.Format("[bold red]Whippet[/] Framework Installer - Version {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString())), VerticalAlignment.Middle));
            titlePanel.Border = BoxBorder.Square;
            titlePanel.BorderColor(Color.White);

            contentPanel = new Panel(Align.Center(new Markup("This program will install the Whippet Framework\n\n\nPress any key to continue..."), VerticalAlignment.Middle));
            contentPanel.Border = BoxBorder.None;
            contentPanel.Expand();
            
            layout[LAYOUT_BAR_TITLE].Update(titlePanel);
            layout[LAYOUT_CONTENT].Update(contentPanel);

            // Render the layout
            AnsiConsole.Write(layout);
            AnsiConsole.Console.Input.ReadKey(true);

            RenderMenu();
        }

        /// <summary>
        /// Renders the installation menu.
        /// </summary>
        private static void RenderMenu()
        {
            SelectionPrompt<string> menu = null;

            Rule menuRule = null;

            string selectedOption = String.Empty;
            string databaseName = String.Empty;
            
            WhippetResultContainer<object> installResult = null;
            WhippetResultContainer<WhippetDatabaseConnection> connectionResult = null;
            
            while (true)
            {
                menuRule = new Rule(String.Format("[bold red]Whippet[/] Framework Installer - Version {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString()));
                menuRule.Style = new Style(Color.White);

                menu = new SelectionPrompt<string>()
                    .Title("Select Install Action")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                    .HighlightStyle(new Style(Color.Red, null, Decoration.Bold))
                    .AddChoices(new[] { ACTION_INSTALL_DATABASE, ACTION_QUIT });

                AnsiConsole.Clear();
                AnsiConsole.Write(menuRule);
                selectedOption = AnsiConsole.Prompt(menu);

                if (String.Equals(ACTION_INSTALL_DATABASE, selectedOption, StringComparison.InvariantCultureIgnoreCase))
                {
                    connectionResult = GetDatabaseConnection(out databaseName);
                    
                    if (!connectionResult.IsSuccess)
                    {
                        AnsiConsole.WriteException(connectionResult.Exception);
                        AnsiConsole.Console.Input.ReadKey(true);
                    }
                    else
                    {
                        installResult = InstallDatabase(connectionResult.Item, databaseName);
                    }
                }
                else // default exit
                {
                    AnsiConsole.Clear();
                    return;
                }
            }
        }

        /// <summary>
        /// Installs the database and any seed data.
        /// </summary>
        /// <param name="connection"><see cref="WhippetDatabaseConnection"/> object.</param>
        /// <param name="databaseName">Whippet database to execute updates on.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        private static WhippetResultContainer<object> InstallDatabase(WhippetDatabaseConnection connection, string databaseName = DEFAULT_DB_NAME)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            else
            {
                WhippetResultContainer<object> installResult = null;

                DatabaseInstaller dbInstaller = null;
                EntityInstaller entityInstaller = null;
                
                NHibernateConfigurationOptions configOptions = null;

                dbInstaller = DatabaseInstaller.CreateInstaller(connection, databaseName);
                installResult = dbInstaller.Install();

                if (installResult.IsSuccess)
                {
                    try
                    {
                        connection.ChangeDatabase(databaseName, true);
                        
                        configOptions = CreateNHibernateConfiguration(connection.DockerConnectionString, connection.GetType());
                        WhippetNHibernateMappingIndex.ConfigureMappings(configOptions);

                        configOptions.NHibernateConfiguration = new Action<Configuration>(config =>
                        {
                            SchemaUpdate schema = new SchemaUpdate(config);
                            AggregateException exceptionTree = null;

                            schema.Execute(true, true);

                            if (schema.Exceptions != null && schema.Exceptions.Count > 0)
                            {
                                exceptionTree = new AggregateException(schema.Exceptions.Distinct());
                                throw exceptionTree;
                            }
                        });

                        entityInstaller = EntityInstaller.CreateInstaller(configOptions, GetSeeds(configOptions));
                    }
                    catch (Exception e)
                    {
                        installResult = new WhippetResultContainer<object>(e);
                    }
                }
                
                return installResult;
            }
        }

        /// <summary>
        /// Gets all entities that are to be seeded in the data store.
        /// </summary>
        /// <param name="options"><see cref="NHibernateConfigurationOptions"/> options.</param>
        /// <returns><see cref="SortedList{TKey,TValue}"/> of all entities to be seeded in the order to be executed.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        private static SortedList<int, ISeedServiceManager> GetSeeds(NHibernateConfigurationOptions options)
        {
            ArgumentNullException.ThrowIfNull(options);
            
            SortedList<int, ISeedServiceManager> seeds = new SortedList<int, ISeedServiceManager>();
            ISessionFactory factory = DefaultNHibernateSessionFactory.Create(options);
            ISession session = factory.OpenSession();
            
            seeds.Add(0, new CountryServiceManager.CountrySeedServiceManager(new CountryRepository(session)));
            
            return seeds;
        }
        
        /// <summary>
        /// Creates a <see cref="WhippetDatabaseConnection"/> based on a selected user option.
        /// </summary>
        /// <param name="databaseName">Database name that was chosen. Default is <b>Whippet</b>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        private static WhippetResultContainer<WhippetDatabaseConnection> GetDatabaseConnection(out string databaseName)
        {
            WhippetResultContainer<WhippetDatabaseConnection> connectionResult = null;

            SelectionPrompt<string> menu = null;
            TextPrompt<string> prompt = null;
            
            string connectionString = String.Empty;
            string selectedOption = String.Empty;
            
            Type connectionType = null;

            WhippetDatabaseConnection connectionInstance = null;

            MethodInfo factoryMethod = null;

            TextPrompt<string> dbNamePrompt = null;
            
            databaseName = DEFAULT_DB_NAME;
            
            menu = new SelectionPrompt<string>()
                .Title("Select database type")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .HighlightStyle(new Style(Color.Red, null, Decoration.Bold))
                .AddChoices(DatabaseConnectionFactory.AvailableConnectionTypes.Select(db => db.Value));

            selectedOption = AnsiConsole.Prompt(menu);

            connectionType = DatabaseConnectionFactory.AvailableConnectionTypes.Where(db => String.Equals(db.Value, selectedOption, StringComparison.InvariantCultureIgnoreCase)).First().Key;
            connectionString = AnsiConsole.Prompt((new TextPrompt<string>("Enter database connection string:")));
            
            // now create the connection

            try
            {
                factoryMethod = typeof(DatabaseConnectionFactory).GetMethod(nameof(DatabaseConnectionFactory.CreateConnection));
                factoryMethod = factoryMethod.MakeGenericMethod(connectionType);

                connectionInstance = (WhippetDatabaseConnection)(factoryMethod.Invoke(null, new object[] { connectionString }));

                if (connectionInstance == null)
                {
                    throw new Exception("Failed to create database instance for type " + connectionType.FullName);
                }
                else
                {
                    connectionResult = new WhippetResultContainer<WhippetDatabaseConnection>(WhippetResult.Success, connectionInstance);
                }
            }
            catch (Exception e)
            {
                connectionResult = new WhippetResultContainer<WhippetDatabaseConnection>(e);
                
                AnsiConsole.WriteException(e, ExceptionFormats.ShortenEverything);
                AnsiConsole.Console.Input.ReadKey(true);
            }

            if (connectionResult.IsSuccess)
            {
                dbNamePrompt = new TextPrompt<string>("Enter database name:");
                dbNamePrompt.DefaultValue(DEFAULT_DB_NAME);
                dbNamePrompt.ShowDefaultValue = true;

                databaseName = AnsiConsole.Prompt(dbNamePrompt);
            }
            
            return connectionResult;
        }
        
        /// <summary>
        /// Creates a new <see cref="NHibernateConfigurationOptions"/> instance based on the specified connection string.
        /// </summary>
        /// <param name="connectionString">Connection string used to connect to the data store.</param>
        /// <param name="dbType"><see cref="Type"/> that describes which vendor to use.</param>
        /// <returns><see cref="NHibernateConfigurationOptions"/> object that was created.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static NHibernateConfigurationOptions CreateNHibernateConfiguration(string connectionString, Type dbType)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            else if (dbType == null)
            {
                throw new ArgumentNullException(nameof(dbType));
            }
            else
            {
                NHibernateConfigurationOptions options = new NHibernateConfigurationOptions();
                
                if (dbType.Equals(typeof(WhippetSqlServerConnection)))
                {
                    NHibernateConfigurationHelper.ConfigureForSqlServerWithConnectionString(options, WhippetSqlServerConnectionStringBuilder.EnsureDockerCompatibility(connectionString));
                }
                else if (dbType.Equals(typeof(WhippetMySqlConnection)))
                {
                    NHibernateConfigurationHelper.ConfigureForMySqlWithConnectionString(options, connectionString);
                }
                else
                {
                    throw new ArgumentException("Database connection of type " + dbType.FullName + " is not supported.");
                }
                
                return options;
            }
        }
    }
}
