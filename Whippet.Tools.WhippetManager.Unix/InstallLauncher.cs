using System;
using __Environment = System.Environment;
using System.Xml;
using Athi.Whippet;
using Athi.Whippet.Collections.Extensions;
using Athi.Whippet.Tools.Installer;

namespace Athi.Whippet.Tools.WhippetManager.Unix
{
    /// <summary>
    /// Install launcher for Whippet. This class cannot be inherited.
    /// </summary>
    public static class InstallLauncher
    {
        private const string CONNECTION_INDEX_FILE = "ConnectionIndex.xml";

        private const string ATTRIB_NAME = "name";
        private const string ATTRIB_CS = "connectionString";
        private const string ATTRIB_LINUX = "linuxContainer";

        /// <summary>
        /// Gets a read-only collection of all allowed database types. This property is read-only.
        /// </summary>
        private static IEnumerable<string> AllowedDatabaseTypes
        {
            get
            {
                return new string[]
                {
                    "sqlServer"
                };
            }
        }

        /// <summary>
        /// Attempts to launch the installer with the given parameters.
        /// </summary>
        /// <param name="outputBuffer">Buffer to write output to.</param>
        /// <param name="whippetConsoleBuffer">Installer console buffer to write output to.</param>
        /// <param name="externalRunners">External install runners to run.</param>
        /// <param name="args">Command-line arguments.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static WhippetResult AttemptLaunch(Action<string> outputBuffer, Action<int, string, WhippetResultSeverity?> whippetConsoleBuffer, SortedList<int, WhippetInstallRunner> externalRunners, params string[] args)
        {
            if (outputBuffer == null)
            {
                throw new ArgumentNullException(nameof(outputBuffer));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;
                string[] pieces = null;

                if (args == null || args.Length < 2)
                {
                    outputBuffer("\nUsage:\tUnixWhippetManager [database type] [connection string name] [/dbname:{database name}] [/update]" + __Environment.NewLine);
                    outputBuffer("\nAvailable Database Types" + __Environment.NewLine);
                    outputBuffer("------------------------" + __Environment.NewLine);

                    foreach (string dbType in AllowedDatabaseTypes)
                    {
                        outputBuffer(dbType + __Environment.NewLine);
                    }

                    outputBuffer(__Environment.NewLine);
                }
                else if (args.Length == 1)
                {
                    outputBuffer("Error: Missing connection string name." + __Environment.NewLine);
                }
                else
                {
                    SortedList<int, WhippetInstallRunner> runners = null;
                    Tuple<string, bool> connectionString = null;

                    bool skipSeed = false;

                    try
                    {
                        if (args.Length == 3)
                        {
                            if (String.Equals(args[2], "/update", StringComparison.InvariantCultureIgnoreCase))
                            {
                                skipSeed = true;
                            }
                            else if (args[2].StartsWith("/dbname:", StringComparison.InvariantCultureIgnoreCase))
                            {
                                // attempt to parse the datase name

                                pieces = args[2].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                                if (pieces.Length != 2)
                                {
                                    outputBuffer("Error: Invalid value for dbname parameter." + __Environment.NewLine);
                                }
                                else
                                {
                                    WhippetDatabaseInstallRunner.DatabaseName = pieces[pieces.Length - 1];
                                }
                            }
                            else
                            {
                                outputBuffer("Error: Invalid command line arguments." + __Environment.NewLine);
                            }
                        }

                        connectionString = GetConnectionString(args[0], args[1]);

                        WhippetInstallRunner.DatabaseIsSqlServerLinuxContainer = connectionString.Item2;

                        runners = ConfigureInstallRunners(connectionString.Item1, skipSeed, externalRunners);

                        if (runners.Any())
                        {
                            foreach (KeyValuePair<int, WhippetInstallRunner> entry in runners)
                            {
                                result = entry.Value.Run(null, new ProgressDelegate(whippetConsoleBuffer));

                                if (!result.IsSuccess)
                                {
                                    if (result.Exception != null)
                                    {
                                        whippetConsoleBuffer(100, result.Exception.ToString(), result.Severity);
                                        break;
                                    }
                                    else
                                    {
                                        throw new Exception("An error was encountered during the installation.");
                                    }
                                }
                            }

                            whippetConsoleBuffer(100, "Installation complete.", WhippetResultSeverity.Success);
                        }
                    }
                    catch (Exception e)
                    {
                        result = new WhippetResult(e);
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the connection string for the specified database type and connection string name.
        /// </summary>
        /// <param name="rdbmsType">Database system type as specified by the valid entries in <see cref="AllowedDatabaseTypes"/>.</param>
        /// <param name="connectionStringName">Name of the connection string to load.</param>
        /// <returns>Connection string value and value indicating wether the database is hosted in a Linux container.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="ArgumentException" />
        /// <exception cref="DirectoryNotFoundException" />
        /// <exception cref="IOException" />
        /// <exception cref="FormatException" />
        public static Tuple<string, bool> GetConnectionString(string rdbmsType, string connectionStringName)
        {
            if (String.IsNullOrWhiteSpace(rdbmsType))
            {
                throw new ArgumentNullException(nameof(rdbmsType));
            }
            else if (String.IsNullOrWhiteSpace(connectionStringName))
            {
                throw new ArgumentNullException(nameof(connectionStringName));
            }
            else if (!AllowedDatabaseTypes.Contains(rdbmsType, StringComparer.InvariantCultureIgnoreCase))
            {
                throw new ArgumentException("The database type " + rdbmsType + " is not supported.");
            }
            else
            {
                XmlReader xmlReader = null;

                string value = String.Empty;
                bool isLinuxContainer = false;

                if (!File.Exists(CONNECTION_INDEX_FILE))
                {
                    throw new FileNotFoundException(CONNECTION_INDEX_FILE);
                }
                else
                {
                    try
                    {
                        xmlReader = XmlReader.Create(new StreamReader(CONNECTION_INDEX_FILE));

                        while (xmlReader.Read())
                        {
                            if (String.Equals(xmlReader.Name, rdbmsType, StringComparison.InvariantCultureIgnoreCase))
                            {
                                while (xmlReader.Read())
                                {
                                    if (!String.IsNullOrWhiteSpace(xmlReader.GetAttribute(ATTRIB_NAME))
                                        && String.Equals(connectionStringName, xmlReader.GetAttribute(ATTRIB_NAME), StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        value = xmlReader.GetAttribute(ATTRIB_CS);

                                        if (!String.IsNullOrWhiteSpace(xmlReader.GetAttribute(ATTRIB_LINUX)))
                                        {
                                            isLinuxContainer = Convert.ToBoolean(xmlReader.GetAttribute(ATTRIB_LINUX));
                                        }

                                        break;
                                    }
                                    else if (!xmlReader.HasAttributes && !String.IsNullOrWhiteSpace(xmlReader.Value))
                                    {
                                        if (String.Equals(xmlReader.Name, rdbmsType, StringComparison.InvariantCultureIgnoreCase))
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (xmlReader != null)
                        {
                            xmlReader.Close();
                            xmlReader.Dispose();
                            xmlReader = null;
                        }
                    }
                }

                return new Tuple<string, bool>(value, isLinuxContainer);
            }
        }

        /// <summary>
        /// Configures all install runners to execute in the appropriate order.
        /// </summary>
        /// <param name="connectionString">Connection string to use to the data store.</param>
        /// <param name="skipSeed">If <see langword="true"/>, will skip any entity seeding routine and instead just perform schema updates.</param>
        /// <param name="externalRunners">External install runners to run.</param>
        /// <returns><see cref="SortedList{TKey, TValue}"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        private static SortedList<int, WhippetInstallRunner> ConfigureInstallRunners(string connectionString, bool skipSeed, SortedList<int, WhippetInstallRunner> externalRunners)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString), "Connection string cannot be empty.");
            }
            else
            {
                int order = 0;
                SortedList<int, WhippetInstallRunner> runners = new SortedList<int, WhippetInstallRunner>();

                runners.Add(++order, new WhippetDatabaseInstallRunner(connectionString, "Whippet", "Installs the Whippet framework for Unix"));
                runners.Add(++order, new WhippetEntityInstallRunner(connectionString, "Whippet", "Installs Whippet entities and populates necessary seed data for setup.", skipSeed));

                if (externalRunners != null && externalRunners.Any())
                {
                    runners.Append(externalRunners);
                }

                return runners;
            }
        }
    }
}

