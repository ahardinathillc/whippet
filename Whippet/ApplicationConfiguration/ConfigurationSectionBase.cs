using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Athi.Whippet.ApplicationConfiguration
{
    /// <summary>
    /// Base class for all configuration section classes that map to a configuration element in an appsettings.json file. This class must be inherited.
    /// </summary>
    public abstract class ConfigurationSectionBase : IConfigurationSection, IConfiguration
    {
	    /// <summary>
	    /// Gets or sets a configuration value.
	    /// </summary>
	    /// <param name="key">The configuration key.</param>
	    /// <returns>The configuration value.</returns>
        public virtual string this[string key]
        {
            get
            {
                return Section[key];
            }
            set
            {
                Section[key] = value;
            }
        }

        /// <summary>
        /// Gets the key this section occupies in its parent. This property is read-only.
        /// </summary>
        public virtual string Key
        {
            get
            {
                return Section.Key;
            }
        }

        /// <summary>
        /// Gets the full path to this section within the <see cref="IConfiguration" />. This property is read-only.
        /// </summary>
        public virtual string Path
        {
            get
            {
                return Section.Path;
            }
        }

        /// <summary>
        /// Gets or sets the section value.
        /// </summary>
        public virtual string Value
        {
            get
            {
                return Section.Value;
            }
            set
            {
                Section.Value = value;
            }
        }

        /// <summary>
        /// Gets the name of the section as specified in the appsettings.config file. This property is read-only. 
        /// </summary>
        public string SectionName
        { get; private set; }

        /// <summary>
        /// Gets or sets the internal <see cref="IConfiguration"/> object which was read.
        /// </summary>
        private IConfiguration Configuration
        { get; set; }

        /// <summary>
        /// Gets the immediate descendant configuration sub-sections. This property is read-only.
        /// </summary>
        public virtual IEnumerable<IConfigurationSection> Children
        {
            get
            {
                return ((IConfiguration)(this)).GetChildren();
            }
        }

        /// <summary>
        /// Gets the <see cref="IConfigurationSection"/> that represents the configuration section associated with the current object. This property is read-only.
        /// </summary>
        protected IConfigurationSection Section
        {
            get
            {
                return Configuration.GetSection(SectionName);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationSectionBase"/> class with no arguments.
        /// </summary>
        private ConfigurationSectionBase()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationSectionBase"/> class with the specified section name.
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/> object that contains the section to read.</param>
        /// <param name="sectionName">Name of the section in the appsettings.config file that the class maps to.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected ConfigurationSectionBase(IConfiguration configuration, string sectionName)
            : this()
        {
            if(configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            else if (String.IsNullOrWhiteSpace(sectionName))
            {
                throw new ArgumentNullException(sectionName);
            }
            else
            {
                SectionName = sectionName;
                Configuration = configuration;
            }
        }

        /// <summary>
        /// Gets a configuration sub-section with the specified key.
        /// </summary>
        /// <param name="key">The key of the configuration section.</param>
        /// <returns>The <see cref="IConfigurationSection" />.</returns>
        public IConfigurationSection GetSection(string key)
        {
            return Section.GetSection(key);
        }

        /// <summary>
        /// Gets the immediate descendant configuration sub-sections.
        /// </summary>
        /// <returns>The configuration sub-sections.</returns>
        IEnumerable<IConfigurationSection> IConfiguration.GetChildren()
        {
            return Section.GetChildren();
        }

        /// <summary>
        /// Returns a <see cref="IChangeToken" /> that can be used to observe when this configuration is reloaded.
        /// </summary>
        /// <returns>A <see cref="IChangeToken" />.</returns>
        public IChangeToken GetReloadToken()
        {
            return Section.GetReloadToken();
        }
    }
}
