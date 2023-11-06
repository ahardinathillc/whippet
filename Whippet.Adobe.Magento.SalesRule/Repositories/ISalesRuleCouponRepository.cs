using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.SalesRule.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="SalesRuleCoupon"/> entity objects.
    /// </summary>
    public interface ISalesRuleCouponRepository : IWhippetEntityRepository<SalesRuleCoupon, uint>, IWhippetExternalQueryRepository<SalesRuleCoupon, uint>
    {
        /// <summary>
        /// Retrieves all <see cref="SalesRuleCoupon"/> objects for the specified <see cref="ISalesRule"/>.
        /// </summary>
        /// <param name="rule"><see cref="ISalesRule"/> object to get associated <see cref="SalesRuleCoupon"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<SalesRuleCoupon>> GetForRule(ISalesRule rule);

        /// <summary>
        /// Retrieves all <see cref="SalesRuleCoupon"/> objects for the specified <see cref="ISalesRule"/>.
        /// </summary>
        /// <param name="rule"><see cref="ISalesRule"/> object to get associated <see cref="SalesRuleCoupon"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<SalesRuleCoupon>>> GetForRuleAsync(ISalesRule rule, CancellationToken? cancellationToken = null);
    }
}
