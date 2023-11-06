using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Directory.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="RegionName"/> entity objects.
    /// </summary>
    public interface IRegionNameRepository : IWhippetRestRepository<RegionName, RegionNameKey>, IWhippetExternalQueryRepository<RegionName, RegionNameKey>
    { }
}
