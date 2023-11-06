using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.EAV.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="StoreGroup"/> entity objects.
    /// </summary>
    public interface IStoreGroupRepository : IWhippetEntityRepository<StoreGroup, ushort>, IWhippetExternalQueryRepository<StoreGroup, ushort>
    { }
}
