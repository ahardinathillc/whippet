using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.Adobe.Magento.Json;
using Athi.Whippet.Adobe.Magento.Taxes.Extensions;
using Athi.Whippet.Adobe.Magento.Taxes.Repositories;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Queries;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Commands;
using Athi.Whippet.Adobe.Magento.ServiceManagers;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="ITaxRate"/> domain objects.
    /// </summary>
    public class TaxRateServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="ITaxRateRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual ITaxRateRepository TaxRateRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateServiceManager"/> class with the specified <see cref="ITaxRateRepository"/> object.
        /// </summary>
        /// <param name="taxRepository"><see cref="ITaxRateRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public TaxRateServiceManager(ITaxRateRepository taxRepository)
            : base()
        {
            if (taxRepository == null)
            {
                throw new ArgumentNullException(nameof(taxRepository));
            }
            else
            {
                TaxRateRepository = taxRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateServiceManager"/> class with the specified <see cref="ITaxRateRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="taxRepository"><see cref="ITaxRateRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public TaxRateServiceManager(IWhippetServiceContext serviceLocator, ITaxRateRepository taxRepository)
            : base(serviceLocator)
        {
            if (taxRepository == null)
            {
                throw new ArgumentNullException(nameof(taxRepository));
            }
            else
            {
                TaxRateRepository = taxRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="ITaxRate"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="ITaxRate"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ITaxRate>> GetTaxRate(int id)
        {
            ITaxRateQueryHandler<GetTaxRateByIdQuery> handler = new GetTaxRateByIdQueryHandler(TaxRateRepository);
            WhippetResultContainer<IEnumerable<TaxRate>> result = await handler.HandleAsync(new GetTaxRateByIdQuery(id));
            return new WhippetResultContainer<ITaxRate>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="ITaxRate"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ITaxRate>>> GetTaxRates()
        {
            ITaxRateQueryHandler<GetAllTaxRatesQuery> handler = new GetAllTaxRatesQueryHandler(TaxRateRepository);
            WhippetResultContainer<IEnumerable<TaxRate>> result = await handler.HandleAsync(new GetAllTaxRatesQuery());
            return new WhippetResultContainer<IEnumerable<ITaxRate>>(result.Result, result.Item);
        }

        /// <summary>
        /// Creates a new Magento tax class entry.
        /// </summary>
        /// <param name="taxRate"><see cref="ITaxRate"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ITaxRate"/> object.</returns>
        public virtual WhippetResultContainer<ITaxRate> CreateTaxRate(ITaxRate taxRate)
        {
            return Task<WhippetResultContainer<ITaxRate>>.Run(() => CreateTaxRateAsync(taxRate)).Result;
        }

        /// <summary>
        /// Creates a new Magento tax class entry.
        /// </summary>
        /// <param name="taxRate"><see cref="ITaxRate"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ITaxRate"/> object.</returns>
        public virtual async Task<WhippetResultContainer<ITaxRate>> CreateTaxRateAsync(ITaxRate taxRate)
        {
            if (taxRate == null)
            {
                throw new ArgumentNullException(nameof(taxRate));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateTaxRateCommand> handler = new CreateTaxRateCommandHandler(TaxRateRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateTaxRateCommand(taxRate.ToTaxRate()));

                    if (result.IsSuccess)
                    {
                        if (TaxRateRepository is IWhippetRepository<ITaxRate, int>)
                        {
                            await ((IWhippetRepository<ITaxRate, int>)(TaxRateRepository)).CommitAsync();
                        }
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ITaxRate>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ITaxRate>(result, taxRate);
            }
        }

        /// <summary>
        /// Creates multiple tax rates using Magento's bulk API.
        /// </summary>
        /// <param name="taxRates"><see cref="ITaxRate"/> objects to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<MagentoBulkOperationResponseViewModel> CreateTaxRates(IEnumerable<ITaxRate> taxRates)
        {
            if (taxRates == null)
            {
                throw new ArgumentNullException(nameof(taxRates));
            }
            else
            {
                return Task.Run(() => CreateTaxRatesAsync(taxRates)).Result;
            }
        }

        /// <summary>
        /// Creates multiple tax rates using Magento's bulk API.
        /// </summary>
        /// <param name="taxRates"><see cref="ITaxRate"/> objects to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<MagentoBulkOperationResponseViewModel>> CreateTaxRatesAsync(IEnumerable<ITaxRate> taxRates)
        {
            if (taxRates == null)
            {
                throw new ArgumentNullException(nameof(taxRates));
            }
            else
            {
                WhippetResultContainer<MagentoBulkOperationResponseViewModel> bulkResult = null;
                WhippetResult result = null;
                
                ITaxRateBulkCommandHandler<CreateTaxRateBulkCommand> handler = null;
                    
                handler = new CreateTaxRateBulkCommandHandler(TaxRateRepository);
                result = await handler.HandleAsync(new CreateTaxRateBulkCommand(taxRates.Select(r => r.ToTaxRate())));

                if (result.ResultObject is MagentoBulkOperationResponseViewModel)
                {
                    bulkResult = new WhippetResultContainer<MagentoBulkOperationResponseViewModel>(result, (MagentoBulkOperationResponseViewModel)(result.ResultObject));
                }
                else
                {
                    bulkResult = new WhippetResultContainer<MagentoBulkOperationResponseViewModel>(result, null);
                }
                
                return bulkResult;
            }
        }

        /// <summary>
        /// Updates an existing Magento tax class entry.
        /// </summary>
        /// <param name="taxRate"><see cref="ITaxRate"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ITaxRate"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ITaxRate> UpdateTaxRate(ITaxRate taxRate)
        {
            return Task<WhippetResultContainer<ITaxRate>>.Run(() => UpdateTaxRateAsync(taxRate)).Result;
        }

        /// <summary>
        /// Updates an existing Magento tax class entry.
        /// </summary>
        /// <param name="taxRate"><see cref="ITaxRate"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ITaxRate"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ITaxRate>> UpdateTaxRateAsync(ITaxRate taxRate)
        {
            if (taxRate == null)
            {
                throw new ArgumentNullException(nameof(taxRate));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateTaxRateCommand> handler = new UpdateTaxRateCommandHandler(TaxRateRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateTaxRateCommand(taxRate.ToTaxRate()));

                    if (result.IsSuccess)
                    {
                        if (TaxRateRepository is IWhippetRepository<ITaxRate, int>)
                        {
                            await ((IWhippetRepository<ITaxRate, int>)(TaxRateRepository)).CommitAsync();
                        }
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ITaxRate>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ITaxRate>(result, taxRate);
            }
        }

        /// <summary>
        /// Deletes an existing Magento tax class entry.
        /// </summary>
        /// <param name="taxRate"><see cref="ITaxRate"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="ITaxRate"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ITaxRate> DeleteTaxRate(ITaxRate taxRate)
        {
            return Task.Run(() => DeleteTaxRateAsync(taxRate)).Result;
        }

        /// <summary>
        /// Deletes an existing Magento tax class entry.
        /// </summary>
        /// <param name="taxRate"><see cref="ITaxRate"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="ITaxRate"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ITaxRate>> DeleteTaxRateAsync(ITaxRate taxRate)
        {
            if (taxRate == null)
            {
                throw new ArgumentNullException(nameof(taxRate));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteTaxRateCommand> handler = new DeleteTaxRateCommandHandler(TaxRateRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteTaxRateCommand(taxRate.ToTaxRate()));

                    if (result.IsSuccess)
                    {
                        if (TaxRateRepository is IWhippetRepository<ITaxRate, int>)
                        {
                            await ((IWhippetRepository<ITaxRate, int>)(TaxRateRepository)).CommitAsync();
                        }
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ITaxRate>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ITaxRate>(result, taxRate);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (TaxRateRepository != null)
            {
                if (TaxRateRepository is IDisposable)
                {
                    ((IDisposable)(TaxRateRepository)).Dispose();
                }

                TaxRateRepository = null;
            }

            base.Dispose();
        }
    }
}
