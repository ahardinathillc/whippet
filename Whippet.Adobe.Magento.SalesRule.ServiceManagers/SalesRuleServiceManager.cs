using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.Adobe.Magento.SalesRule.Repositories;
using Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Queries;
using Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Handlers.Queries;

namespace Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="ISalesRule"/> domain objects.
    /// </summary>
    public class SalesRuleServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="ISalesRuleRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual ISalesRuleRepository RuleRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleServiceManager"/> class with the specified <see cref="ISalesRuleRepository"/> object.
        /// </summary>
        /// <param name="ruleRepository"><see cref="ISalesRuleRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesRuleServiceManager(ISalesRuleRepository ruleRepository)
            : base()
        {
            if (ruleRepository == null)
            {
                throw new ArgumentNullException(nameof(ruleRepository));
            }
            else
            {
                RuleRepository = ruleRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleServiceManager"/> class with the specified <see cref="ISalesRuleRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="ruleRepository"><see cref="ISalesRuleRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesRuleServiceManager(IWhippetServiceContext serviceLocator, ISalesRuleRepository ruleRepository)
            : base(serviceLocator)
        {
            if (ruleRepository == null)
            {
                throw new ArgumentNullException(nameof(ruleRepository));
            }
            else
            {
                RuleRepository = ruleRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="ISalesRule"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="ISalesRule"/> object to retrieve.</param>
        /// <param name="rowId">Associated row ID to query by in conjunction with <paramref name="id"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ISalesRule>> GetRule(uint id, uint? rowId = null)
        {
            ISalesRuleQueryHandler<GetSalesRuleByIdQuery> handler = new GetSalesRuleByIdQueryHandler(RuleRepository);
            WhippetResultContainer<IEnumerable<SalesRule>> result = await handler.HandleAsync(new GetSalesRuleByIdQuery(id, rowId));
            return new WhippetResultContainer<ISalesRule>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="ISalesRule"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISalesRule>>> GetRules()
        {
            ISalesRuleQueryHandler<GetAllSalesRulesQuery> handler = new GetAllSalesRulesQueryHandler(RuleRepository);
            WhippetResultContainer<IEnumerable<SalesRule>> result = await handler.HandleAsync(new GetAllSalesRulesQuery());
            return new WhippetResultContainer<IEnumerable<ISalesRule>>(result.Result, result.Item);
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (RuleRepository != null)
            {
                RuleRepository.Dispose();
                RuleRepository = null;
            }

            base.Dispose();
        }
    }
}
