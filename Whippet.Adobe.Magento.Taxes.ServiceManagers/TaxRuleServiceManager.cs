using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.Adobe.Magento.Taxes.Extensions;
using Athi.Whippet.Adobe.Magento.Taxes.Repositories;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Queries;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Commands;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="ITaxRule"/> domain objects.
    /// </summary>
    public class TaxRuleServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="ITaxRuleRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual ITaxRuleRepository TaxRuleRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRuleServiceManager"/> class with the specified <see cref="ITaxRuleRepository"/> object.
        /// </summary>
        /// <param name="taxRepository"><see cref="ITaxRuleRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public TaxRuleServiceManager(ITaxRuleRepository taxRepository)
            : base()
        {
            if (taxRepository == null)
            {
                throw new ArgumentNullException(nameof(taxRepository));
            }
            else
            {
                TaxRuleRepository = taxRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRuleServiceManager"/> class with the specified <see cref="ITaxRuleRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="taxRepository"><see cref="ITaxRuleRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public TaxRuleServiceManager(IWhippetServiceContext serviceLocator, ITaxRuleRepository taxRepository)
            : base(serviceLocator)
        {
            if (taxRepository == null)
            {
                throw new ArgumentNullException(nameof(taxRepository));
            }
            else
            {
                TaxRuleRepository = taxRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="ITaxRule"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="ITaxRule"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ITaxRule>> GetTaxRule(int id)
        {
            ITaxRuleQueryHandler<GetTaxRuleByIdQuery> handler = new GetTaxRuleByIdQueryHandler(TaxRuleRepository);
            WhippetResultContainer<IEnumerable<TaxRule>> result = await handler.HandleAsync(new GetTaxRuleByIdQuery(id));
            return new WhippetResultContainer<ITaxRule>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="ITaxRule"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ITaxRule>>> GetTaxRules()
        {
            ITaxRuleQueryHandler<GetAllTaxRulesQuery> handler = new GetAllTaxRulesQueryHandler(TaxRuleRepository);
            WhippetResultContainer<IEnumerable<TaxRule>> result = await handler.HandleAsync(new GetAllTaxRulesQuery());
            return new WhippetResultContainer<IEnumerable<ITaxRule>>(result.Result, result.Item);
        }

        /// <summary>
        /// Creates a new Magento tax rule entry.
        /// </summary>
        /// <param name="taxRule"><see cref="ITaxRule"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ITaxRule"/> object.</returns>
        public virtual WhippetResultContainer<ITaxRule> CreateTaxRule(ITaxRule taxRule)
        {
            return Task<WhippetResultContainer<ITaxRule>>.Run(() => CreateTaxRuleAsync(taxRule)).Result;
        }

        /// <summary>
        /// Creates a new Magento tax rule entry.
        /// </summary>
        /// <param name="taxRule"><see cref="ITaxRule"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ITaxRule"/> object.</returns>
        public virtual async Task<WhippetResultContainer<ITaxRule>> CreateTaxRuleAsync(ITaxRule taxRule)
        {
            if (taxRule == null)
            {
                throw new ArgumentNullException(nameof(taxRule));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateTaxRuleCommand> handler = new CreateTaxRuleCommandHandler(TaxRuleRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateTaxRuleCommand(taxRule.ToTaxRule()));

                    if (result.IsSuccess)
                    {
                        if (TaxRuleRepository is IWhippetRepository<ITaxRule, short>)
                        {
                            await ((IWhippetRepository<ITaxRule, short>)(TaxRuleRepository)).CommitAsync();
                        }
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ITaxRule>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ITaxRule>(result, taxRule);
            }
        }

        /// <summary>
        /// Updates an existing Magento tax rule entry.
        /// </summary>
        /// <param name="taxRule"><see cref="ITaxRule"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ITaxRule"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ITaxRule> UpdateTaxRule(ITaxRule taxRule)
        {
            return Task<WhippetResultContainer<ITaxRule>>.Run(() => UpdateTaxRuleAsync(taxRule)).Result;
        }

        /// <summary>
        /// Updates an existing Magento tax rule entry.
        /// </summary>
        /// <param name="taxRule"><see cref="ITaxRule"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ITaxRule"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ITaxRule>> UpdateTaxRuleAsync(ITaxRule taxRule)
        {
            if (taxRule == null)
            {
                throw new ArgumentNullException(nameof(taxRule));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateTaxRuleCommand> handler = new UpdateTaxRuleCommandHandler(TaxRuleRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateTaxRuleCommand(taxRule.ToTaxRule()));

                    if (result.IsSuccess)
                    {
                        if (TaxRuleRepository is IWhippetRepository<ITaxRule, short>)
                        {
                            await ((IWhippetRepository<ITaxRule, short>)(TaxRuleRepository)).CommitAsync();
                        }
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ITaxRule>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ITaxRule>(result, taxRule);
            }
        }

        /// <summary>
        /// Deletes an existing Magento tax rule entry.
        /// </summary>
        /// <param name="taxRule"><see cref="ITaxRule"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="ITaxRule"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ITaxRule> DeleteTaxRule(ITaxRule taxRule)
        {
            return Task.Run(() => DeleteTaxRuleAsync(taxRule)).Result;
        }

        /// <summary>
        /// Deletes an existing Magento tax rule entry.
        /// </summary>
        /// <param name="taxRule"><see cref="ITaxRule"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="ITaxRule"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ITaxRule>> DeleteTaxRuleAsync(ITaxRule taxRule)
        {
            if (taxRule == null)
            {
                throw new ArgumentNullException(nameof(taxRule));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteTaxRuleCommand> handler = new DeleteTaxRuleCommandHandler(TaxRuleRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteTaxRuleCommand(taxRule.ToTaxRule()));

                    if (result.IsSuccess)
                    {
                        if (TaxRuleRepository is IWhippetRepository<ITaxRule, short>)
                        {
                            await ((IWhippetRepository<ITaxRule, short>)(TaxRuleRepository)).CommitAsync();
                        }
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ITaxRule>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ITaxRule>(result, taxRule);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (TaxRuleRepository != null)
            {
                if (TaxRuleRepository is IDisposable)
                {
                    ((IDisposable)(TaxRuleRepository)).Dispose();
                }

                TaxRuleRepository = null;
            }

            base.Dispose();
        }
    }
}
