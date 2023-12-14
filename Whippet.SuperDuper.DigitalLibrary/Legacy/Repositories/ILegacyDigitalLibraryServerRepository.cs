using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="LegacyDigitalLibraryServer"/> entity objects.
    /// </summary>
    public interface ILegacyDigitalLibraryServerRepository : IWhippetTenantRepositoryFilter<LegacyDigitalLibraryServer, Guid>, IWhippetEntityRepository<LegacyDigitalLibraryServer, Guid>, IWhippetRepository<LegacyDigitalLibraryServer, Guid>, IWhippetQueryRepository<LegacyDigitalLibraryServer>
    { }
}
