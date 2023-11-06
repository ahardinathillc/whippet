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
    /// Base class for all resource loaders in Whippet. This class must be inherited.
    /// </summary>
    public abstract class ResourceLoader
    {
        protected const string DIRECTORY = "ResourceFiles";

        private static CultureInfo _culture;

        /// <summary>
        /// Gets the default culture to fall back on if the appropriate culture was not found. This property is read-only.
        /// </summary>
        /// <remarks>
        /// Defaults to invariant English. See https://docs.microsoft.com/en-us/openspecs/windows_protocols/ms-lcid/70feba9f-294e-491e-b6eb-56532684c37f for more information.
        /// </remarks>
        protected static CultureInfo DefaultCulture
        {
            get
            {
                return CultureInfo.GetCultureInfo(0x0009);
            }
        }

        /// <summary>
        /// Gets or sets the current culture to use. If no culture specified, will default to invariant English.
        /// </summary>
        public static CultureInfo Culture
        {
            get
            {
                if (_culture == null)
                {
                    _culture = DefaultCulture;
                }

                return _culture;
            }
            set
            {
                _culture = value;
            }
        }

        /// <summary>
        /// Gets the resource file root directory name. This property is read-only.
        /// </summary>
        public static string ResourceFileRootDirectory
        {
            get
            {
                return DIRECTORY;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceLoader"/> class with no arguments.
        /// </summary>
        protected ResourceLoader()
        { }

        /// <summary>
        /// Prepends the specified file name with <see cref="ResourceFileRootDirectory"/>.
        /// </summary>
        /// <param name="fileName">File name of the resource file.</param>
        /// <returns>Resource file directory and path to <paramref name="fileName"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string CreateResourcePath(string fileName)
        {
            if (String.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            else
            {
                return Path.Combine(ResourceFileRootDirectory, fileName);
            }
        }
    }
}
