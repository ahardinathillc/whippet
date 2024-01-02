using System;
using Spectre.Console;

namespace Athi.Whippet.Testing.Infrastructure
{
    /// <summary>
    /// Base class for all unit tests in Whippet. This class must be inherited.
    /// </summary>
    public abstract class WhippetUnitTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUnitTestBase"/> class with no arguments.
        /// </summary>
        protected WhippetUnitTestBase()
        { }

        /// <summary>
        /// Writes an exception to the console.
        /// </summary>
        /// <param name="e"><see cref="Exception"/> to write.</param>
        protected virtual void WriteException(Exception e)
        {
            if (e != null)
            {
                AnsiConsole.WriteException(e);
            }
        }

        /// <summary>
        /// Writes a warning message to the console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        protected virtual void WriteWarning(string message)
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                AnsiConsole.Console.WriteLine("WARNING: " + message, new Style(Color.Yellow, null, Decoration.Bold));
            }
        }
    }
}
