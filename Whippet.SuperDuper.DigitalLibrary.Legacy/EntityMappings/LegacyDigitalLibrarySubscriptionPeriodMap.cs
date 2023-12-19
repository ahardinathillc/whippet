using System;
using Athi.Whippet.Data.Database.Microsoft.Extensions;
using Athi.Whippet.SuperDuper.EntityMappings;
using Athi.Whippet.SuperDuper.Data.NHibernate.FluentNHibernate;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="LegacyDigitalLibrarySubscriptionPeriod"/> objects.
    /// </summary>
    public class LegacyDigitalLibrarySubscriptionPeriodMap : SuperDuperLegacyFluentMap<LegacyDigitalLibrarySubscriptionPeriod>
    {
        private const string TABLE_NAME = "library_subscriptionPeriod";
        
        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyDigitalLibrarySubscriptionPeriodMap"/> class with no arguments.
        /// </summary>
        public LegacyDigitalLibrarySubscriptionPeriodMap()
            : base(TABLE_NAME)
        {
            Map(p => p.Name).Length(50).Not.Nullable();
        }
    }
}
