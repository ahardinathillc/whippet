using System;
using Athi.Whippet.Data.Database.Microsoft.Extensions;
using Athi.Whippet.SuperDuper.EntityMappings;
using Athi.Whippet.SuperDuper.Data.NHibernate.FluentNHibernate;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="LegacyDigitalLibrarySubscriptionLevel"/> objects.
    /// </summary>
    public class LegacyDigitalLibrarySubscriptionLevelMap : SuperDuperLegacyFluentMap<LegacyDigitalLibrarySubscriptionLevel>
    {
        private const string TABLE_NAME = "library_subscriptionLevel";
        
        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyDigitalLibrarySubscriptionLevelMap"/> class with no arguments.
        /// </summary>
        public LegacyDigitalLibrarySubscriptionLevelMap()
            : base(TABLE_NAME)
        {
            Map(p => p.Name).Length(50).Not.Nullable();
        }
    }
}
