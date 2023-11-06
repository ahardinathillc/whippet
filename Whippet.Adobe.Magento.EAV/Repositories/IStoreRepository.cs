using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.EAV.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="Store"/> entity objects.
    /// </summary>
    public interface IStoreRepository : IWhippetEntityRepository<Store, ushort>, IWhippetExternalQueryRepository<Store, ushort>
    { }
}
