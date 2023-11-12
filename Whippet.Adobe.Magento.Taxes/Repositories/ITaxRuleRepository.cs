using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="TaxRule"/> entity objects.
    /// </summary>
    public interface ITaxRuleRepository : IWhippetRepository<TaxRule, uint>, IWhippetExternalQueryRepository<TaxRule, uint>
    { }
}