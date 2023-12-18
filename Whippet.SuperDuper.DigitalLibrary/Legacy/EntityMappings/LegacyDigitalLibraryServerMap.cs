using System;
using Athi.Whippet.Data.Database.Microsoft.Extensions;
using Athi.Whippet.SuperDuper.EntityMappings;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="LegacyDigitalLibraryServer"/> objects.
    /// </summary>
    public class LegacyDigitalLibraryServerMap : SuperDuperServerMap<LegacyDigitalLibraryServer>
    {
        private const string TABLE_NAME = "LegacyServers";

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyDigitalLibraryServerMap"/> class with no arguments.
        /// </summary>
        public LegacyDigitalLibraryServerMap()
            : base(PrefixTableName(FluentEntityMapper.TABLE_PREFIX, TABLE_NAME))
        {
            this.MapNHibernateColumns(MakeReservedWordColumnName);
        }
    }
}
