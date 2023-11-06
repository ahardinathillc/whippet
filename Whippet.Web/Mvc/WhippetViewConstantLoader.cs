using System;
using Athi.Whippet.ResourceManagement;

namespace Athi.Whippet.Web.Mvc
{
    /// <summary>
    /// Resource loader for loading view constants. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetViewConstantLoader : ResourceLoader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewConstantLoader"/> class with no arguments.
        /// </summary>
        private WhippetViewConstantLoader()
            : base()
        { }

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
                return StringResourceLoader.GetResource(resourceFile, resourceName, parameters);
            }
        }
    }
}

