using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="TaxClass"/> entity objects.
    /// </summary>
    public interface ITaxClassRepository : IWhippetRepository<TaxClass, short>, IWhippetExternalQueryRepository<TaxClass, short>
    { }
}
