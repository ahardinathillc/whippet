using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="SalesRuleCoupon"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface ISalesRuleCouponQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, SalesRuleCoupon> where TQuery : IWhippetQuery<SalesRuleCoupon>
    { }
}
