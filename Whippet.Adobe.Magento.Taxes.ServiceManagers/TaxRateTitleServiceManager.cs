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
    /// Service manager for <see cref="ITaxRateTitle"/> domain objects.
    /// </summary>
    public class TaxRateTitleServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="ITaxRateTitleRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual ITaxRateTitleRepository TaxRateTitleRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateTitleServiceManager"/> class with the specified <see cref="ITaxRateTitleRepository"/> object.
        /// </summary>
        /// <param name="taxRepository"><see cref="ITaxRateTitleRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public TaxRateTitleServiceManager(ITaxRateTitleRepository taxRepository)
            : base()
        {
            if (taxRepository == null)
            {
                throw new ArgumentNullException(nameof(taxRepository));
            }
            else
            {
                TaxRateTitleRepository = taxRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateTitleServiceManager"/> class with the specified <see cref="ITaxRateTitleRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="taxRepository"><see cref="ITaxRateTitleRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public TaxRateTitleServiceManager(IWhippetServiceContext serviceLocator, ITaxRateTitleRepository taxRepository)
            : base(serviceLocator)
        {
            if (taxRepository == null)
            {
                throw new ArgumentNullException(nameof(taxRepository));
            }
            else
            {
                TaxRateTitleRepository = taxRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="ITaxRateTitle"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="ITaxRateTitle"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ITaxRateTitle>> GetTaxRateTitle(int id)
        {
            ITaxRateTitleQueryHandler<GetTaxRateTitleByIdQuery> handler = new GetTaxRateTitleByIdQueryHandler(TaxRateTitleRepository);
            WhippetResultContainer<IEnumerable<TaxRateTitle>> result = await handler.HandleAsync(new GetTaxRateTitleByIdQuery(id));
            return new WhippetResultContainer<ITaxRateTitle>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="ITaxRateTitle"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ITaxRateTitle>>> GetTaxRateTitles()
        {
            ITaxRateTitleQueryHandler<GetAllTaxRateTitlesQuery> handler = new GetAllTaxRateTitlesQueryHandler(TaxRateTitleRepository);
            WhippetResultContainer<IEnumerable<TaxRateTitle>> result = await handler.HandleAsync(new GetAllTaxRateTitlesQuery());
            return new WhippetResultContainer<IEnumerable<ITaxRateTitle>>(result.Result, result.Item);
        }

        /// <summary>
        /// Creates a new Magento tax class entry.
        /// </summary>
        /// <param name="taxRate"><see cref="ITaxRateTitle"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ITaxRateTitle"/> object.</returns>
        public virtual WhippetResultContainer<ITaxRateTitle> CreateTaxRateTitle(ITaxRateTitle taxRate)
        {
            return Task<WhippetResultContainer<ITaxRateTitle>>.Run(() => CreateTaxRateTitleAsync(taxRate)).Result;
        }

        /// <summary>
        /// Creates a new Magento tax class entry.
        /// </summary>
        /// <param name="taxRate"><see cref="ITaxRateTitle"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ITaxRateTitle"/> object.</returns>
        public virtual async Task<WhippetResultContainer<ITaxRateTitle>> CreateTaxRateTitleAsync(ITaxRateTitle taxRate)
        {
            if (taxRate == null)
            {
                throw new ArgumentNullException(nameof(taxRate));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateTaxRateTitleCommand> handler = new CreateTaxRateTitleCommandHandler(TaxRateTitleRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateTaxRateTitleCommand(taxRate.ToTaxRateTitle()));

                    if (result.IsSuccess)
                    {
                        if (TaxRateTitleRepository is IWhippetRepository<ITaxRateTitle, int>)
                        {
                            await ((IWhippetRepository<ITaxRateTitle, int>)(TaxRateTitleRepository)).CommitAsync();
                        }
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ITaxRateTitle>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ITaxRateTitle>(result, taxRate);
            }
        }

        /// <summary>
        /// Updates an existing Magento tax class entry.
        /// </summary>
        /// <param name="taxRate"><see cref="ITaxRateTitle"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ITaxRateTitle"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ITaxRateTitle> UpdateTaxRateTitle(ITaxRateTitle taxRate)
        {
            return Task<WhippetResultContainer<ITaxRateTitle>>.Run(() => UpdateTaxRateTitleAsync(taxRate)).Result;
        }

        /// <summary>
        /// Updates an existing Magento tax class entry.
        /// </summary>
        /// <param name="taxRate"><see cref="ITaxRateTitle"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ITaxRateTitle"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ITaxRateTitle>> UpdateTaxRateTitleAsync(ITaxRateTitle taxRate)
        {
            if (taxRate == null)
            {
                throw new ArgumentNullException(nameof(taxRate));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateTaxRateTitleCommand> handler = new UpdateTaxRateTitleCommandHandler(TaxRateTitleRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateTaxRateTitleCommand(taxRate.ToTaxRateTitle()));

                    if (result.IsSuccess)
                    {
                        if (TaxRateTitleRepository is IWhippetRepository<ITaxRateTitle, int>)
                        {
                            await ((IWhippetRepository<ITaxRateTitle, int>)(TaxRateTitleRepository)).CommitAsync();
                        }
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ITaxRateTitle>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ITaxRateTitle>(result, taxRate);
            }
        }

        /// <summary>
        /// Deletes an existing Magento tax class entry.
        /// </summary>
        /// <param name="taxRate"><see cref="ITaxRateTitle"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="ITaxRateTitle"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ITaxRateTitle> DeleteTaxRateTitle(ITaxRateTitle taxRate)
        {
            return Task.Run(() => DeleteTaxRateTitleAsync(taxRate)).Result;
        }

        /// <summary>
        /// Deletes an existing Magento tax class entry.
        /// </summary>
        /// <param name="taxRate"><see cref="ITaxRateTitle"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="ITaxRateTitle"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ITaxRateTitle>> DeleteTaxRateTitleAsync(ITaxRateTitle taxRate)
        {
            if (taxRate == null)
            {
                throw new ArgumentNullException(nameof(taxRate));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteTaxRateTitleCommand> handler = new DeleteTaxRateTitleCommandHandler(TaxRateTitleRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteTaxRateTitleCommand(taxRate.ToTaxRateTitle()));

                    if (result.IsSuccess)
                    {
                        if (TaxRateTitleRepository is IWhippetRepository<ITaxRateTitle, int>)
                        {
                            await ((IWhippetRepository<ITaxRateTitle, int>)(TaxRateTitleRepository)).CommitAsync();
                        }
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ITaxRateTitle>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ITaxRateTitle>(result, taxRate);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (TaxRateTitleRepository != null)
            {
                if (TaxRateTitleRepository is IDisposable)
                {
                    ((IDisposable)(TaxRateTitleRepository)).Dispose();
                }

                TaxRateTitleRepository = null;
            }

            base.Dispose();
        }
    }
}
