using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Athi.Whippet.ApplicationConfiguration;

namespace Athi.Whippet.Web
{
    /// <summary>
    /// Represents the "Hosting" configuration section of the appsettings.json file.
    /// </summary>
    public class WhippetHostingConfiguration : ConfigurationSectionBase
    {
        private const string SECTION_NAME = "WhippetHostingSettings";
        
        /// <summary>
        /// Indicates whether Kestrel should be used on a Windows environment instead of IIS. This property is read-only.
        /// </summary>
        public bool UseKestrelOnWindowsPlatform
        {
            get
            {
                bool useKestrelOnWindows = false;
                string entry = Section[nameof(UseKestrelOnWindowsPlatform)];

                if (!String.IsNullOrWhiteSpace(entry))
                {
                    if (!Boolean.TryParse(entry, out useKestrelOnWindows))
                    {
                        useKestrelOnWindows = false;    // default to IIS
                    }
                }

                return useKestrelOnWindows;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetHostingConfiguration"/> class.
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/> object that contains the section to read.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetHostingConfiguration(IConfiguration configuration)
            : base(configuration, SECTION_NAME)
        { }
    }
}
