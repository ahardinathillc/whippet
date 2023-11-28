using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Directory.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="Country"/> entity objects.
    /// </summary>
    public interface ICountryRepository : IWhippetRepository<Country, WhippetNonNullableString>, IWhippetExternalQueryRepository<Country, WhippetNonNullableString>, IMagentoEntityRepository<Country>
    { }
}
