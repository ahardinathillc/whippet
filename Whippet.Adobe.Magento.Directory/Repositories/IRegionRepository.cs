using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Directory.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="Region"/> entity objects.
    /// </summary>
    public interface IRegionRepository : IWhippetRestRepository<Region, uint>, IWhippetExternalQueryRepository<Region, uint>
    { }
}
