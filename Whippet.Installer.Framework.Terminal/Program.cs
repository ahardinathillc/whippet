using System;
using System.Reflection;
using Spectre.Console;
using Athi.Whippet.Data.Database;
using Athi.Whippet.Installer.Framework.Database;

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

            WhippetResultContainer<WhippetDatabaseConnection> connectionResult = null;

            DatabaseInstaller installer = null;
            
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
                    connectionResult = GetDatabaseConnection();

                    if (connectionResult.IsSuccess)
                    {
                        installer = DatabaseInstaller.CreateInstaller(connectionResult.Item);
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
        /// Creates a <see cref="WhippetDatabaseConnection"/> based on a selected user option.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        private static WhippetResultContainer<WhippetDatabaseConnection> GetDatabaseConnection()
        {
            WhippetResultContainer<WhippetDatabaseConnection> connectionResult = null;

            SelectionPrompt<string> menu = null;
            TextPrompt<string> prompt = null;
            
            string connectionString = String.Empty;
            string selectedOption = String.Empty;

            Type connectionType = null;

            WhippetDatabaseConnection connectionInstance = null;

            MethodInfo factoryMethod = null;
            
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
            
            return connectionResult;
        }
    }
}
