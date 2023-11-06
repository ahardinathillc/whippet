using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Localization;
using Athi.Whippet.Extensions.Primitives;

namespace Athi.Whippet.Environment
{
    /// <summary>
    /// Installer console for Whippet. Provides standard input/output functionality for the setup bootstrapper.
    /// </summary>
    public class WhippetBootstrapperConsole : WhippetConsole
    {
        private const int TRUNCATE_LENGTH = 60;
        private const int CURSOR_LEFT_POS = 60;

        private const string RESX_SUCCESS = "Success";
        private const string RESX_FAILURE = "Failure";
        private const string RESX_WARN = "Warning";
        private const string RESX_INFO = "Information";

        private const ConsoleColor CC_BG_ERROR = ConsoleColor.Black;
        private const ConsoleColor CC_FG_ERROR = ConsoleColor.Red;

        private const ConsoleColor CC_BG_SUCCESS = ConsoleColor.Black;
        private const ConsoleColor CC_FG_SUCCESS = ConsoleColor.Green;

        private const ConsoleColor CC_BG_WARNING = ConsoleColor.Black;
        private const ConsoleColor CC_FG_WARNING = ConsoleColor.Yellow;

        private const ConsoleColor CC_BG_INFO = ConsoleColor.Black;
        private const ConsoleColor CC_FG_INFO = ConsoleColor.Cyan;

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetBootstrapperConsole"/> class with no arguments.
        /// </summary>
        protected WhippetBootstrapperConsole()
            : base()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operationName"></param>
        /// <param name="severity"></param>
        public static void WriteOperation(string operationName, WhippetResultSeverity? severity = null)
        {
            Write(operationName.Truncate(TRUNCATE_LENGTH));
            SetCursorPosition(CURSOR_LEFT_POS, CursorTop);

            if (severity.HasValue)
            {
                Write("[  ");

                switch (severity)
                {
                    case WhippetResultSeverity.Failure:
                        WriteFailure();
                        break;
                    case WhippetResultSeverity.Info:
                        WriteInformation();
                        break;
                    case WhippetResultSeverity.Success:
                        WriteSuccess();
                        break;
                    case WhippetResultSeverity.Warning:
                        WriteWarning();
                        break;
                    default:
                        break;
                }

                Write("  ]");
            }

            WriteLine();
        }

        /// <summary>
        /// Writes a success status message to the console.
        /// </summary>
        protected static void WriteSuccess()
        {
            SaveCurrentBackgroundColor();
            SaveCurrentForegroundColor();

            BackgroundColor = CC_BG_SUCCESS;
            ForegroundColor = CC_FG_SUCCESS;

            Write(LocalizedStringResourceLoader.GetResource(typeof(WhippetBootstrapperConsole), RESX_SUCCESS));

            RestoreBackgroundColor();
            RestoreForegroundColor();
        }

        /// <summary>
        /// Writes a failure status message to the console.
        /// </summary>
        protected static void WriteFailure()
        {
            SaveCurrentBackgroundColor();
            SaveCurrentForegroundColor();

            BackgroundColor = CC_BG_ERROR;
            ForegroundColor = CC_FG_ERROR;

            Write(LocalizedStringResourceLoader.GetResource(typeof(WhippetBootstrapperConsole), RESX_FAILURE));

            RestoreBackgroundColor();
            RestoreForegroundColor();
        }

        /// <summary>
        /// Writes an information status message to the console.
        /// </summary>
        protected static void WriteInformation()
        {
            SaveCurrentBackgroundColor();
            SaveCurrentForegroundColor();

            BackgroundColor = CC_BG_INFO;
            ForegroundColor = CC_FG_INFO;

            Write(LocalizedStringResourceLoader.GetResource(typeof(WhippetBootstrapperConsole), RESX_INFO));

            RestoreBackgroundColor();
            RestoreForegroundColor();
        }

        /// <summary>
        /// Writes a warning status message to the console.
        /// </summary>
        protected static void WriteWarning()
        {
            SaveCurrentBackgroundColor();
            SaveCurrentForegroundColor();

            BackgroundColor = CC_BG_WARNING;
            ForegroundColor = CC_FG_WARNING;

            Write(LocalizedStringResourceLoader.GetResource(typeof(WhippetBootstrapperConsole), RESX_WARN));

            RestoreBackgroundColor();
            RestoreForegroundColor();
        }
    }
}
