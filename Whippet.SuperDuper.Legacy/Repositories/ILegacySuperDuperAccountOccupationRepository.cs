using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.SuperDuper.Data;

namespace Athi.Whippet.SuperDuper.Legacy.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="LegacySuperDuperAccountOccupation"/> entity objects.
    /// </summary>
    public interface ILegacySuperDuperAccountOccupationRepository : ISuperDuperLegacyEntityRepository<LegacySuperDuperAccountOccupation>, IWhippetQueryRepository<LegacySuperDuperAccountOccupation>
    { }
}
