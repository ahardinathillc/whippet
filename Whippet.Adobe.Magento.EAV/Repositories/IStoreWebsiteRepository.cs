using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.EAV.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="StoreWebsite"/> entity objects.
    /// </summary>
    public interface IStoreWebsiteRepository : IWhippetEntityRepository<StoreWebsite, ushort>, IWhippetExternalQueryRepository<StoreWebsite, ushort>
    { }
}
