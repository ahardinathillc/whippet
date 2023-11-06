using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Athi.Whippet.ApplicationConfiguration
{
    /// <summary>
    /// Provides access to the application's configuration file.
    /// </summary>
    public class WhippetConfigurationFile : IConfiguration, IEnumerable<IConfigurationSection>
    {
        private const string DEFAULT_SETTINGS_FILE = "appsettings.json";

        /// <summary>
        /// Gets the base path to the configuration file. This property is read-only.
        /// </summary>
        public string BasePath
        { get; private set; }

        /// <summary>
        /// Gets the JSON application file that was read. This property is read-only.
        /// </summary>
        public string JsonFile
        { get; private set; }

        /// <summary>
        /// Gets or sets the configuration value.
        /// </summary>
        /// <param name="key">The configuration key.</param>
        /// <returns>The configuration value.</returns>
        public string this[string key]
        {
            get
            {
                return Configuration[key];
            }
            set
            {
                Configuration[key] = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="IConfigurationRoot"/> that was build upon the class' instantiation. This property is read-only.
        /// </summary>
        public IConfigurationRoot Configuration
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetConfigurationFile"/> class with no arguments.
        /// </summary>
        private WhippetConfigurationFile()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetConfigurationFile"/> class.
        /// </summary>
        /// <param name="basePath">Base path to the configuration file.</param>
        /// <param name="jsonFile">JSON application file to read.</param>
        /// <param name="optional">Indicates whether the file is optional.</param>
        /// <param name="reloadOnChange">If <see langword="true"/>, the configuration instance will be reloaded upon the file changing to reflect the new changes.</param>
        public WhippetConfigurationFile(string basePath, string jsonFile = DEFAULT_SETTINGS_FILE, bool optional = true, bool reloadOnChange = true)
            : this()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(jsonFile, optional, reloadOnChange)
                .Build();

            BasePath = basePath;
            JsonFile = jsonFile;
        }

        /// <summary>
        /// Gets a configuration subsection with the specified key.
        /// </summary>
        /// <param name="key">The key of the configuration setction.</param>
        /// <returns><see cref="IConfigurationSection"/> object.</returns>
        public IConfigurationSection GetSection(string key)
        {
            return Configuration.GetSection(key);
        }

        /// <summary>
        /// Gets the immediate descendant configuration subsections.
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/> of the configuration subsections.</returns>
        IEnumerable<IConfigurationSection> IConfiguration.GetChildren()
        {
            return Configuration.GetChildren();
        }

        /// <summary>
        /// Gets the immediate descendant configuration subsections.
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/> of the configuration subsections.</returns>
        IEnumerator<IConfigurationSection> IEnumerable<IConfigurationSection>.GetEnumerator()
        {
            return ((IConfiguration)(this)).GetChildren()?.GetEnumerator();
        }

        /// <summary>
        /// Gets the immediate descendant configuration subsections.
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/> of the configuration subsections.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IConfiguration)(this)).GetChildren()?.GetEnumerator();
        }

        /// <summary>
        /// Returns an <see cref="IChangeToken"/> that can be used to observe when the configuration is reloaded.
        /// </summary>
        /// <returns><see cref="IChangeToken"/> object.</returns>
        public IChangeToken GetReloadToken()
        {
            return Configuration.GetReloadToken();
        }
    }
}
