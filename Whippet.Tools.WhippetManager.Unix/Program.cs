using System;
using System.Xml;
using Athi.Whippet;
using Athi.Whippet.Environment;
using Athi.Whippet.Tools.Installer;

namespace Athi.Whippet.Tools.WhippetManager.Unix
{
    public static class Program
    {
        /// <summary>
        /// Entry point for the program.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public static void Main(params string[] args)
        {
            InstallLauncher.AttemptLaunch(Console.Write, WriteOperation, null, args);
        }

        private static void WriteOperation(int percentage, string desc, WhippetResultSeverity? severity)
        {
            if (!String.IsNullOrWhiteSpace(desc))
            {
                WhippetBootstrapperConsole.WriteOperation(desc + "... " + percentage + "%", severity);
            }
        }
   }
}
