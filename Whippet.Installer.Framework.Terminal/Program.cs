using System;
using System.Reflection;
using Spectre.Console;
using CommandLine;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Athi.Whippet.Data.Database;
using Athi.Whippet.Data.NHibernate;
using Athi.Whippet.Data.NHibernate.MappingIndex;
using Athi.Whippet.Installer.Framework.Database;
using Athi.Whippet.Installer.Framework.Database.Entities;
using Athi.Whippet.Installer.Framework.Core;

namespace Athi.Whippet.Installer.Framework.Terminal
{
    /// <summary>
    /// Object that serves as the entry point of the application. This class cannot be inherited.
    /// </summary>
    /// <remarks>https://spectreconsole.net/markup</remarks>
    public static class Program
    {
        private const string _TEST_DB = "Server=localhost;TrustServerCertificate=true;MultipleActiveResultSets=True;Integrated Security=False;User Id=sa;Password=<YourStrong@Passw0rd>;docker_container=true";
        
        private const string STATUS_MESSAGE = "{0} ({1}%)";
        
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
        public static void Main(params string[] args)
        {
            Parser.Default.ParseArguments<InstallerTerminalOptions>(args)
                .WithParsed(o => InitScreen(o));
        }

        /// <summary>
        /// Renders the screen with the optional command-line arguments supplied by an <see cref="InstallerTerminalOptions"/> object.
        /// </summary>
        /// <param name="options"><see cref="InstallerTerminalOptions"/> object that contains the parsed command-line arguments.</param>
        private static void InitScreen(InstallerTerminalOptions options = null)
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

                    if (connectionResult.Severity == WhippetResultSeverity.Info)    // reserved for aborting the screen
                    {
                        AnsiConsole.Clear();
                    }
                    else if (!connectionResult.IsSuccess)
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

                AnsiConsole.Status()
                    .Start("Installing Database...", ctx =>
                    {
                        dbInstaller = DatabaseInstaller.CreateInstaller(
                            connection, 
                            databaseName,
                            updateStatusAndProgressPercentage: (action, percentage) =>
                            {
                                ctx.Status(String.Format(STATUS_MESSAGE, action, Convert.ToInt32(percentage * Convert.ToDouble(100.0))));
                            },
                            errorHandler: DisplayException
                        );
                        
                        installResult = dbInstaller.Install();
                    });

                if (installResult.IsSuccess)
                {
                    try
                    {
                        connection.ChangeDatabase(databaseName, true);

                        configOptions = NHibernateConfigurationOptionsFactory.CreateNHibernateConfiguration(connection.DockerConnectionString, connection.GetType());
                        WhippetNHibernateMappingIndex.ConfigureMappings(configOptions);

                        configOptions.NHibernateConfiguration = new Action<Configuration>(config =>
                        {
                            SchemaUpdate schema = new SchemaUpdate(config);
                            AggregateException exceptionTree = null;
                            IEnumerable<Exception> errors = null;

                            schema.Execute(false, true);
                            
                            if (schema.Exceptions != null && schema.Exceptions.Count > 0)
                            {
                                // filter out all exceptions that just report the object exists...
                                errors = schema.Exceptions.Distinct().Where(e => !e.ToString().Contains("there is already an object named", StringComparison.InvariantCultureIgnoreCase));

                                if (errors != null && errors.Any())
                                {
                                    exceptionTree = new AggregateException(errors);
                                    throw exceptionTree;
                                }
                            }
                        });

                        AnsiConsole.Progress()
                            .Start(ctx =>
                            {
                                ProgressTask actionTask = null;

                                try
                                {
                                    entityInstaller = EntityInstaller.CreateInstaller(
                                        configOptions,
                                        EntitySeedIndex.GetSeeds(configOptions),
                                        updateStatusAndProgressPercentage: (action, percentage) =>
                                        {
                                            if (actionTask == null)
                                            {
                                                actionTask = ctx.AddTask(action);
                                                actionTask.StartTask();
                                            }
                                            else
                                            {
                                                actionTask.Description = action;
                                            }

                                            actionTask.Value(Convert.ToInt32(percentage * Convert.ToDouble(100.0)));
                                        },
                                        errorHandler: DisplayException);

                                    installResult = entityInstaller.Install();
                                }
                                catch (Exception e)
                                {
                                    if (actionTask != null)
                                    {
                                        if (actionTask.IsStarted)
                                        {
                                            actionTask.StopTask();
                                        }
                                    }

                                    installResult = new WhippetResultContainer<object>(e);
                                }
                            });
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
        /// Displays an exception that was caught.
        /// </summary>
        /// <param name="e"><see cref="Exception"/> that was caught.</param>
        private static void DisplayException(Exception e)
        {
            if (e != null)
            {
                AnsiConsole.WriteException(e);
                AnsiConsole.Console.Input.ReadKey(true);
            }
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

            prompt = new TextPrompt<string>("Enter database connection string (or press [Enter] to cancel):")
                .AllowEmpty();
            
            selectedOption = AnsiConsole.Prompt(menu);

            connectionType = DatabaseConnectionFactory.AvailableConnectionTypes.Where(db => String.Equals(db.Value, selectedOption, StringComparison.InvariantCultureIgnoreCase)).First().Key;
            connectionString = AnsiConsole.Prompt(prompt);

            // now create the connection

            if (!String.IsNullOrWhiteSpace(connectionString))
            {
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
            }
            else
            {
                connectionResult = new WhippetResultContainer<WhippetDatabaseConnection>(new WhippetResult(WhippetResultSeverity.Info), null);
            }

            return connectionResult;
        }
    }
}
