using System;
using FluentNHibernate.Data;
using NodaTime;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="MultichannelOrderManagerWarehouse"/> entity objects.
    /// </summary>
    public interface IMultichannelOrderManagerWarehouseRepository : IWhippetEntityRepository<MultichannelOrderManagerWarehouse, long>, IWhippetQueryRepository<MultichannelOrderManagerWarehouse>, IWhippetExternalQueryRepository<MultichannelOrderManagerWarehouse, long>
    { }
}
