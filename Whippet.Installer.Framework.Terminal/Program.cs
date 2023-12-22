using System;
using System.Reflection;
using Spectre.Console;
using Spectre.Console.Rendering;

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
            
        }

        // private static Label[] CreateSplashLabels()
        // {
        //     Label programTitle = new Label("Whippet Framework Installer");
        //     Label programVersion = new Label("Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
        //
        //     programTitle.X = Pos.Center();
        //     programVersion.X = Pos.Center();
        //
        //     programTitle.Y = Pos.Center();
        //     programVersion.Y = programTitle.Y + 1;
        //
        //     return new[] { programTitle, programVersion };
        // }
    }
}
