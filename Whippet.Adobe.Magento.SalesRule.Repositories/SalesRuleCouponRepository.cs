using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.SqlCommand;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.SalesRule.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="SalesRuleCoupon"/> entity objects.
    /// </summary>
    public class SalesRuleCouponRepository : MagentoEntityRepository<SalesRuleCoupon>, ISalesRuleCouponRepository
    {
        /// <summary>
        /// Provides a way to load <see cref="SalesRule"/> objects based on their rule ID. See remarks for more information.
        /// </summary>
        /// <remarks>
        /// Note form Adam (3/2/23):
        /// 
        /// Magento's MySQL database has a primary key of [row_id] on the [salesrule] table. Because of this, I had a hard time trying to get the QueryOver function to work properly as the
        /// only key method was [row_id] and Fluently screamed about the composite key that I tried to make in the mapping ([salesrule_coupon] knows nothing of the [row_id] in [salesrule]).
        /// That being said, I added a "helper" property to the concrete implementation of the SalesRuleCoupon object itself which is the SalesRuleID property. Using this, we can create an 
        /// INNER JOIN correctly on the appropriate tables. However, this also means that the SalesRule object that it's associated with inside the object will be "shallow" (only have the
        /// ID property set). To work around this and prevent a leaky abstraction, I am adding this helper delegate that will allow the methods to populate the associated SalesRule objects.
        /// It sucks, I hate it, but it's what we've got to work with.
        /// </remarks>
        protected virtual Func<IEnumerable<uint>, IEnumerable<SalesRule>> SalesRuleLoader
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleCouponRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="salesRuleLoaderDelegate">Delegate that provides an external way of loading <see cref="SalesRule"/> objects. If <see langword="null"/>, only the <see cref="SalesRule.RuleID"/> property will be populated.</param>
        /// <exception cref="ArgumentNullException" />
        public SalesRuleCouponRepository(ISession context, Func<IEnumerable<uint>, IEnumerable<SalesRule>> salesRuleLoaderDelegate = null)
            : base(context)
        {
            SalesRuleLoader = salesRuleLoaderDelegate;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleCouponRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <param name="salesRuleLoaderDelegate">Delegate that provides an external way of loading <see cref="SalesRule"/> objects. If <see langword="null"/>, only the <see cref="SalesRule.RuleID"/> property will be populated.</param>
        /// <exception cref="ArgumentNullException" />
        public SalesRuleCouponRepository(ISession context, IStatelessSession statelessContext, Func<IEnumerable<uint>, IEnumerable<SalesRule>> salesRuleLoaderDelegate = null)
            : base(context, statelessContext)
        {
            SalesRuleLoader = salesRuleLoaderDelegate;
        }

        /// <summary>
        /// Loads all <see cref="SalesRule"/> objects for the specified <see cref="SalesRuleCoupon"/> collection if <see cref="SalesRuleLoader"/> is not <see langword="null"/>.
        /// </summary>
        /// <param name="queryResults"><see cref="IEnumerable{T}"/> collection of <see cref="SalesRuleCoupon"/> objects.</param>
        /// <returns><see cref="IList{T}"/> of <see cref="SalesRuleCoupon"/> objects.</returns>
        private IList<SalesRuleCoupon> LoadSalesRules(IEnumerable<SalesRuleCoupon> queryResults)
        {
            IEnumerable<SalesRule> rules = null;

            if (queryResults != null && queryResults.Any())
            {
                if (SalesRuleLoader != null)
                {
                    rules = SalesRuleLoader(queryResults.Select(sr => sr.RuleID).Distinct());

                    if (rules != null && rules.Any())
                    {
                        foreach (SalesRuleCoupon coupon in queryResults)
                        {
                            coupon.Rule = (from rule in rules where rule.RuleID == coupon.RuleID select rule).FirstOrDefault();
                        }
                    }
                }
            }

            return new List<SalesRuleCoupon>(queryResults);
        }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="couponId">Unique ID of the entity.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override WhippetResultContainer<SalesRuleCoupon> Get(uint couponId)
        {
            return Task.Run(() => GetAsync(couponId)).Result;
        }

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="couponId">Unique ID of the entity.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override async Task<WhippetResultContainer<SalesRuleCoupon>> GetAsync(uint couponId, CancellationToken? cancellationToken = null)
        {
            SalesRuleCoupon couponAlias = null;
            SalesRule ruleAlias = null;

            IList<SalesRuleCoupon> queryResults = await Context.QueryOver<SalesRuleCoupon>(() => couponAlias)
                .JoinEntityAlias(
                    () => ruleAlias,
                    () => couponAlias.RuleID == ruleAlias.RuleID,
                    JoinType.InnerJoin)
                .Where(() => couponAlias.CouponID == couponId)
                .OrderBy(() => ruleAlias.RowID).Desc
                .Take(1)
                .ListAsync();

            queryResults = LoadSalesRules(queryResults);

            return new WhippetResultContainer<SalesRuleCoupon>(WhippetResult.Success, queryResults.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="SalesRuleCoupon"/> objects in the system.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public override async Task<WhippetResultContainer<IEnumerable<SalesRuleCoupon>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            IList<SalesRuleCoupon> queryResults = await Context.QueryOver<SalesRuleCoupon>().ListAsync();

            queryResults = LoadSalesRules(queryResults);

            return new WhippetResultContainer<IEnumerable<SalesRuleCoupon>>(WhippetResult.Success, queryResults);
        }

        /// <summary>
        /// Retrieves all <see cref="SalesRuleCoupon"/> objects for the specified <see cref="ISalesRule"/>.
        /// </summary>
        /// <param name="rule"><see cref="ISalesRule"/> object to get associated <see cref="SalesRuleCoupon"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<SalesRuleCoupon>> GetForRule(ISalesRule rule)
        {
            if (rule == null)
            {
                throw new ArgumentNullException(nameof(rule));
            }
            else
            {
                return Task.Run(() => GetForRuleAsync(rule)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="SalesRuleCoupon"/> objects for the specified <see cref="ISalesRule"/>.
        /// </summary>
        /// <param name="rule"><see cref="ISalesRule"/> object to get associated <see cref="SalesRuleCoupon"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<SalesRuleCoupon>>> GetForRuleAsync(ISalesRule rule, CancellationToken? cancellationToken = null)
        {
            if (rule == null)
            {
                throw new ArgumentNullException(nameof(rule));
            }
            else
            {
                SalesRuleCoupon couponAlias = null;
                SalesRule ruleAlias = null;

                IList<SalesRuleCoupon> queryResults = await Context.QueryOver<SalesRuleCoupon>(() => couponAlias)
                    .JoinEntityAlias(
                        () => ruleAlias,
                        () => couponAlias.RuleID == ruleAlias.RuleID,
                        JoinType.InnerJoin)
                    .Where(() => ruleAlias.RuleID == rule.RuleID)
                    .OrderBy(ca => ca.CouponID).Asc
                    .ListAsync();

                queryResults = LoadSalesRules(queryResults.DistinctBy(src => src.CouponID));

                return new WhippetResultContainer<IEnumerable<SalesRuleCoupon>>(WhippetResult.Success, queryResults);
            }
        }
    }
}
