using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Athi.Whippet.Logging;

namespace Athi.Whippet.Oswald
{
    /// <summary>
    /// Provides configuration settings for Oswald's synchronization features.
    /// </summary>
    public class OswaldSynchronizationConfiguration : OswaldConfiguration, IWhippetEventId
    {
        private const string SECTION_NAME = "Synchronization";

        private const int EVENT_ID = 99000;

        /// <summary>
        /// Gets the feature's event ID. This property is read-only.
        /// </summary>
        public virtual int EventID
        {
            get
            {
                return EventConstants.CreateEventId(EVENT_ID);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OswaldSynchronizationConfiguration"/> class.
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/> object that contains the section to read.</param>
        /// <exception cref="ArgumentNullException" />
        public OswaldSynchronizationConfiguration(IConfiguration configuration)
            : base(configuration, SECTION_NAME)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OswaldSynchronizationConfiguration"/> class.
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/> object that contains the section to read.</param>
        /// <param name="sectionName">Section name.</param>
        protected OswaldSynchronizationConfiguration(IConfiguration configuration, string sectionName)
            : base(configuration, PrependSectionName(SECTION_NAME, sectionName))
        { }
    }
}

