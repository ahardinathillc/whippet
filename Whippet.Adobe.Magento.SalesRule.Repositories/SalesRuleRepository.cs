using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.SalesRule.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="SalesRule"/> entity objects.
    /// </summary>
    public class SalesRuleRepository : MagentoEntityRepository<SalesRule>, ISalesRuleRepository, IMagentoRowNumberEntityRepository<SalesRule>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public SalesRuleRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public SalesRuleRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="ruleId">Unique ID of the entity.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override WhippetResultContainer<SalesRule> Get(uint ruleId)
        {
            return Task.Run(() => GetAsync(ruleId)).Result;
        }

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="ruleId">Unique ID of the entity.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override async Task<WhippetResultContainer<SalesRule>> GetAsync(uint ruleId, CancellationToken? cancellationToken = null)
        {
            IList<SalesRule> queryResults = await Context.QueryOver<SalesRule>()
                .Where(sr => sr.RuleID == ruleId)
                .OrderBy(sr => sr.RowID).Desc
                .Take(1)
                .ListAsync();

            return new WhippetResultContainer<SalesRule>(WhippetResult.Success, queryResults.FirstOrDefault());
        }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="rowNumber">Row number of the entity.</param>
        /// <param name="ruleId">Unique ID of the entity.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public virtual WhippetResultContainer<SalesRule> Get(uint rowNumber, uint ruleId)
        {
            return Task.Run(() => GetAsync(rowNumber, ruleId)).Result;
        }

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="rowNumber">Row number of the entity.</param>
        /// <param name="ruleId">Unique ID of the entity.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public virtual async Task<WhippetResultContainer<SalesRule>> GetAsync(uint rowNumber, uint ruleId, CancellationToken? cancellationToken = null)
        {
            IList<SalesRule> queryResults = await Context.QueryOver<SalesRule>()
                .Where(sr => sr.RuleID == ruleId && sr.RowID == rowNumber)
                .ListAsync();

            return new WhippetResultContainer<SalesRule>(WhippetResult.Success, queryResults.FirstOrDefault());
        }
    }
}
