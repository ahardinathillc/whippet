using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Xml;
using System.IO;

namespace Athi.Whippet.ResourceManagement
{
    /// <summary>
    /// String resource loader used for retrieving strings from Whippet XML resource files.
    /// </summary>
    public class StringResourceLoader : ResourceLoader
    {
        protected const string TOOLTIP_PREFIX = "$$TOOLTIP$$";

        protected const string ATTRIB_NAME = "name";
        protected const string ATTRIB_VALUE = "value";

        protected const string DEFAULT_EXT = "xml";

        /// <summary>
        /// Initializes a new instance of the <see cref="StringResourceLoader"/> on the stack.
        /// </summary>
        static StringResourceLoader()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringResourceLoader"/> class with no arguments.
        /// </summary>
        protected StringResourceLoader()
            : base()
        { }

        /// <summary>
        /// Retrieves the specified SQL script file.
        /// </summary>
        /// <param name="fileName">SQL script file to load. Must have a .SQL extension.</param>
        /// <returns>SQL script file contents.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        internal static string GetSqlScript(string fileName)
        {
            if (String.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            else
            {
                if (!fileName.EndsWith(".sql", StringComparison.InvariantCultureIgnoreCase))
                {
                    fileName = fileName + ".sql";
                }

                if (!fileName.Contains('\\'))
                {
                    // we're dealing with a resource files file
                    fileName = Path.Combine(Path.GetDirectoryName(typeof(StringResourceLoader).Assembly.Location), DIRECTORY, fileName);
                }

                if (!File.Exists(fileName))
                {
                    throw new FileNotFoundException(null, nameof(fileName));
                }
                else
                {
                    return File.ReadAllText(fileName);
                }
            }
        }

        /// <summary>
        /// Retrieves a ToolTip <see cref="string"/> resource from the specified Whippet resource file. Will also apply parameters supplied (if any) via <see cref="String.Format(string, object?[])"/>.
        /// </summary>
        /// <param name="classType"><see cref="Type"/> of the class resource file to load the resource from.</param>
        /// <param name="resourceName">Name of the resource file to load from <paramref name="resourceFile"/>.</param>
        /// <param name="parameters">Parameters to apply to the resource value (if any).</param>
        /// <returns>Resource string value.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="FileNotFoundException" />
        /// <exception cref="DirectoryNotFoundException" />
        /// <exception cref="IOException" />
        /// <exception cref="FormatException" />
        public static string GetToolTip(Type classType, string resourceName, IEnumerable<object> parameters = null)
        {
            if (classType == null)
            {
                throw new ArgumentNullException(nameof(classType));
            }
            else
            {
                if (!resourceName.StartsWith(TOOLTIP_PREFIX, StringComparison.InvariantCultureIgnoreCase))
                {
                    resourceName = TOOLTIP_PREFIX + resourceName;
                }

                return GetResource(classType, resourceName, parameters);
            }
        }

        /// <summary>
        /// Retrieves a <see cref="string"/> resource from the specified Whippet resource file. Will also apply parameters supplied (if any) via <see cref="String.Format(string, object?[])"/>.
        /// </summary>
        /// <param name="classType"><see cref="Type"/> of the class resource file to load the resource from.</param>
        /// <param name="resourceName">Name of the resource file to load from <paramref name="resourceFile"/>.</param>
        /// <param name="parameters">Parameters to apply to the resource value (if any).</param>
        /// <returns>Resource string value.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="FileNotFoundException" />
        /// <exception cref="DirectoryNotFoundException" />
        /// <exception cref="IOException" />
        /// <exception cref="FormatException" />
        public static string GetResource(Type classType, string resourceName, IEnumerable<object> parameters = null)
        {
            if (classType == null)
            {
                throw new ArgumentNullException(nameof(classType));
            }
            else
            {
                string ctName = classType.FullName;

                if (classType.IsNested)
                {
                    ctName = ctName.Replace("+", "");
                }

                return GetResource(ctName + "." + DEFAULT_EXT, resourceName, parameters);
            }
        }

        /// <summary>
        /// Retrieves a ToolTip <see cref="string"/> resource from the specified Whippet resource file. Will also apply parameters supplied (if any) via <see cref="String.Format(string, object?[])"/>.
        /// </summary>
        /// <param name="resourceFile">Fully qualified name of the target resource file to load the resource from.</param>
        /// <param name="resourceName">Name of the resource file to load from <paramref name="resourceFile"/>.</param>
        /// <param name="parameters">Parameters to apply to the resource value (if any).</param>
        /// <returns>Resource string value.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="FileNotFoundException" />
        /// <exception cref="DirectoryNotFoundException" />
        /// <exception cref="IOException" />
        /// <exception cref="FormatException" />
        public static string GetToolTip(string resourceFile, string resourceName, IEnumerable<object> parameters = null)
        {
            if (String.IsNullOrWhiteSpace(resourceFile))
            {
                throw new ArgumentNullException(nameof(resourceFile));
            }
            else if (String.IsNullOrWhiteSpace(resourceName))
            {
                throw new ArgumentNullException(nameof(resourceName));
            }
            else
            {
                if (!resourceName.StartsWith(TOOLTIP_PREFIX, StringComparison.InvariantCultureIgnoreCase))
                {
                    resourceName = TOOLTIP_PREFIX + resourceName;
                }

                return GetResource(resourceFile, resourceName, parameters);
            }
        }

        /// <summary>
        /// Retrieves a <see cref="string"/> resource from the specified Whippet resource file. Will also apply parameters supplied (if any) via <see cref="String.Format(string, object?[])"/>.
        /// </summary>
        /// <param name="resourceFile">Fully qualified name of the target resource file to load the resource from.</param>
        /// <param name="resourceName">Name of the resource file to load from <paramref name="resourceFile"/>.</param>
        /// <param name="parameters">Parameters to apply to the resource value (if any).</param>
        /// <returns>Resource string value.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="FileNotFoundException" />
        /// <exception cref="DirectoryNotFoundException" />
        /// <exception cref="IOException" />
        /// <exception cref="FormatException" />
        public static string GetResource(string resourceFile, string resourceName, IEnumerable<object> parameters = null)
        {
            if (String.IsNullOrWhiteSpace(resourceFile))
            {
                throw new ArgumentNullException(nameof(resourceFile));
            }
            else if (String.IsNullOrWhiteSpace(resourceName))
            {
                throw new ArgumentNullException(nameof(resourceName));
            }
            else
            {
                XmlReader xmlReader = null;

                string value = String.Empty;

                if (!String.Equals(Path.GetExtension(resourceFile), DEFAULT_EXT, StringComparison.InvariantCultureIgnoreCase))
                {
                    resourceFile = Path.ChangeExtension(resourceFile, DEFAULT_EXT);
                }

                resourceFile = Path.Combine(Path.GetDirectoryName(typeof(StringResourceLoader).Assembly.Location), DIRECTORY, resourceFile);

                if (!File.Exists(resourceFile))
                {
                    throw new FileNotFoundException(resourceFile);
                }
                else
                {
                    try
                    {
                        xmlReader = XmlReader.Create(new StreamReader(resourceFile));

                        while (xmlReader.Read())
                        {
                            if (xmlReader.HasAttributes
                                && !String.IsNullOrWhiteSpace(xmlReader.GetAttribute(ATTRIB_NAME))
                                && String.Equals(resourceName, xmlReader.GetAttribute(ATTRIB_NAME), StringComparison.InvariantCultureIgnoreCase))
                            {
                                if (parameters != null && parameters.Any())
                                {
                                    value = String.Format(xmlReader.GetAttribute(ATTRIB_VALUE), parameters.ToArray());
                                }
                                else
                                {
                                    value = xmlReader.GetAttribute(ATTRIB_VALUE);
                                }

                                break;
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

                return value;
            }
        }
    }
}
