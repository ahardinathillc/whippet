using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Athi.Whippet.ApplicationConfiguration;

namespace Athi.Whippet.Oswald
{
    /// <summary>
    /// Provides configuration settings for Oswald.
    /// </summary>
    public class OswaldConfiguration : ConfigurationSectionBase
    {
        private const string SECTION_NAME = "Oswald";

        /// <summary>
        /// Initializes a new instance of the <see cref="OswaldConfiguration"/> class.
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/> object that contains the section to read.</param>
        /// <exception cref="ArgumentNullException" />
        public OswaldConfiguration(IConfiguration configuration)
            : this(configuration, SECTION_NAME)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OswaldConfiguration"/> class.
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/> object that contains the section to read.</param>
        /// <param name="sectionName">Section name.</param>
        protected OswaldConfiguration(IConfiguration configuration, string sectionName)
            : base(configuration, PrependSectionName(SECTION_NAME, sectionName))
        { }

        /// <summary>
        /// Prepends the section name with the specified value.
        /// </summary>
        /// <param name="value">Value to prepend.</param>
        /// <param name="sectionName">Section name.</param>
        /// <returns>Prepended section name.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected static string PrependSectionName(string value, string sectionName)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            else
            {
                value = value.Trim();

                if (String.IsNullOrWhiteSpace(sectionName))
                {
                    sectionName = value;
                }
                else if (!String.IsNullOrWhiteSpace(sectionName))
                {
                    if (!String.Equals(sectionName.Trim(), value, StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (!sectionName.Trim().StartsWith(value + ':'))
                        {
                            sectionName = value + ":" + sectionName;
                        }
                    }
                }

                return sectionName;
            }
        }
    }
}

