using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Directory.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="Region"/> entity objects.
    /// </summary>
    public interface IRegionRepository : IWhippetRepository<Region, int>, IWhippetExternalQueryRepository<Region, int>, IMagentoEntityRepository<Region>
    { }
}
