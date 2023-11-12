using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Directory.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="Country"/> entity objects.
    /// </summary>
    public interface ICountryRepository : IWhippetRestRepository<Country, WhippetNonNullableString>, IWhippetExternalQueryRepository<Country, WhippetNonNullableString>
    { }
}