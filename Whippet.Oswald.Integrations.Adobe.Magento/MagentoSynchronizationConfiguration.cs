using System;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Configuration;
using Athi.Whippet.Logging;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento
{
    /// <summary>
    /// Provides configuration settings for Adobe Magento synchronization within Whippet.
    /// </summary>
    public class MagentoSynchronizationConfiguration : OswaldSynchronizationConfiguration, IWhippetEventId
    {
        private const string SECTION_NAME = "Magento";

        private const int EVENT_ID = 99054;

        /// <summary>
        /// Gets the logging event ID used for the feature. This property is read-only.
        /// </summary>
        public override int EventID
        {
            get
            {
                return EventConstants.CreateEventId(EVENT_ID);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoSynchronizationConfiguration"/> class.
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/> object that contains the section to read.</param>
        /// <exception cref="ArgumentNullException" />
        public MagentoSynchronizationConfiguration(IConfiguration configuration)
            : base(configuration, SECTION_NAME)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoSynchronizationConfiguration"/> class.
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/> object that contains the section to read.</param>
        /// <param name="sectionName">Section name.</param>
        protected MagentoSynchronizationConfiguration(IConfiguration configuration, string sectionName)
            : base(configuration, PrependSectionName(SECTION_NAME, sectionName))
        { }

        /// <summary>
        /// Provides synchronization configuration options between Adobe Magento and Freestyle Solutions Multichannel Order Manager (MOM). This class cannot be inherited.
        /// </summary>
        public sealed class MultichannelOrderManagerTaxSync : MagentoSynchronizationConfiguration, IWhippetEventId
        {
            private new const int EVENT_ID = 99055;

            private new const string SECTION_NAME = "MultichannelOrderManagerTaxSync";

            private const string KEY_TABLE = "Table";

            /// <summary>
            /// Gets the logging event ID used for the feature. This property is read-only.
            /// </summary>
            public override int EventID
            {
                get
                {
                    return EventConstants.CreateEventId(EVENT_ID);
                }
            }

            /// <summary>
            /// Gets the database table or view located in the MOM database that contains the tax information to import. This property is read-only.
            /// </summary>
            public string TableName
            {
                get
                {
                    return this[KEY_TABLE];
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="MultichannelOrderManagerTaxSync"/> class.
            /// </summary>
            /// <param name="configuration"><see cref="IConfiguration"/> object that contains the section to read.</param>
            /// <exception cref="ArgumentNullException" />
            public MultichannelOrderManagerTaxSync(IConfiguration configuration)
                : base(configuration, SECTION_NAME)
            { }
        }
    }
}
