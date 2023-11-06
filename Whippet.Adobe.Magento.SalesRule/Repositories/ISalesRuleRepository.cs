using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.SalesRule.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="SalesRule"/> entity objects.
    /// </summary>
    public interface ISalesRuleRepository : IWhippetEntityRepository<SalesRule, uint>, IWhippetExternalQueryRepository<SalesRule, uint>, IMagentoRowNumberEntityRepository<SalesRule>
    { }
}
