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
    /// Service manager for <see cref="ITaxClass"/> domain objects.
    /// </summary>
    public class TaxClassServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="ITaxClassRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual ITaxClassRepository TaxClassRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxClassServiceManager"/> class with the specified <see cref="ITaxClassRepository"/> object.
        /// </summary>
        /// <param name="taxRepository"><see cref="ITaxClassRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public TaxClassServiceManager(ITaxClassRepository taxRepository)
            : base()
        {
            if (taxRepository == null)
            {
                throw new ArgumentNullException(nameof(taxRepository));
            }
            else
            {
                TaxClassRepository = taxRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxClassServiceManager"/> class with the specified <see cref="ITaxClassRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="taxRepository"><see cref="ITaxClassRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public TaxClassServiceManager(IWhippetServiceContext serviceLocator, ITaxClassRepository taxRepository)
            : base(serviceLocator)
        {
            if (taxRepository == null)
            {
                throw new ArgumentNullException(nameof(taxRepository));
            }
            else
            {
                TaxClassRepository = taxRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="ITaxClass"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="ITaxClass"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ITaxClass>> GetTaxClass(short id)
        {
            ITaxClassQueryHandler<GetTaxClassByIdQuery> handler = new GetTaxClassByIdQueryHandler(TaxClassRepository);
            WhippetResultContainer<IEnumerable<TaxClass>> result = await handler.HandleAsync(new GetTaxClassByIdQuery(id));
            return new WhippetResultContainer<ITaxClass>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="ITaxClass"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ITaxClass>>> GetTaxClasses()
        {
            ITaxClassQueryHandler<GetAllTaxClassesQuery> handler = new GetAllTaxClassesQueryHandler(TaxClassRepository);
            WhippetResultContainer<IEnumerable<TaxClass>> result = await handler.HandleAsync(new GetAllTaxClassesQuery());
            return new WhippetResultContainer<IEnumerable<ITaxClass>>(result.Result, result.Item);
        }

        /// <summary>
        /// Creates a new Magento tax class entry.
        /// </summary>
        /// <param name="taxClass"><see cref="ITaxClass"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ITaxClass"/> object.</returns>
        public virtual WhippetResultContainer<ITaxClass> CreateTaxClass(ITaxClass taxClass)
        {
            return Task<WhippetResultContainer<ITaxClass>>.Run(() => CreateTaxClassAsync(taxClass)).Result;
        }

        /// <summary>
        /// Creates a new Magento tax class entry.
        /// </summary>
        /// <param name="taxClass"><see cref="ITaxClass"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ITaxClass"/> object.</returns>
        public virtual async Task<WhippetResultContainer<ITaxClass>> CreateTaxClassAsync(ITaxClass taxClass)
        {
            if (taxClass == null)
            {
                throw new ArgumentNullException(nameof(taxClass));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateTaxClassCommand> handler = new CreateTaxClassCommandHandler(TaxClassRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateTaxClassCommand(taxClass.ToTaxClass()));

                    if (result.IsSuccess)
                    {
                        if (TaxClassRepository is IWhippetRepository<ITaxClass, short>)
                        {
                            await ((IWhippetRepository<ITaxClass, short>)(TaxClassRepository)).CommitAsync();
                        }
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ITaxClass>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ITaxClass>(result, taxClass);
            }
        }

        /// <summary>
        /// Updates an existing Magento tax class entry.
        /// </summary>
        /// <param name="taxClass"><see cref="ITaxClass"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ITaxClass"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ITaxClass> UpdateTaxClass(ITaxClass taxClass)
        {
            return Task<WhippetResultContainer<ITaxClass>>.Run(() => UpdateTaxClassAsync(taxClass)).Result;
        }

        /// <summary>
        /// Updates an existing Magento tax class entry.
        /// </summary>
        /// <param name="taxClass"><see cref="ITaxClass"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ITaxClass"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ITaxClass>> UpdateTaxClassAsync(ITaxClass taxClass)
        {
            if (taxClass == null)
            {
                throw new ArgumentNullException(nameof(taxClass));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateTaxClassCommand> handler = new UpdateTaxClassCommandHandler(TaxClassRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateTaxClassCommand(taxClass.ToTaxClass()));

                    if (result.IsSuccess)
                    {
                        if (TaxClassRepository is IWhippetRepository<ITaxClass, short>)
                        {
                            await ((IWhippetRepository<ITaxClass, short>)(TaxClassRepository)).CommitAsync();
                        }
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ITaxClass>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ITaxClass>(result, taxClass);
            }
        }

        /// <summary>
        /// Deletes an existing Magento tax class entry.
        /// </summary>
        /// <param name="taxClass"><see cref="ITaxClass"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="ITaxClass"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ITaxClass> DeleteTaxClass(ITaxClass taxClass)
        {
            return Task.Run(() => DeleteTaxClassAsync(taxClass)).Result;
        }

        /// <summary>
        /// Deletes an existing Magento tax class entry.
        /// </summary>
        /// <param name="taxClass"><see cref="ITaxClass"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="ITaxClass"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ITaxClass>> DeleteTaxClassAsync(ITaxClass taxClass)
        {
            if (taxClass == null)
            {
                throw new ArgumentNullException(nameof(taxClass));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteTaxClassCommand> handler = new DeleteTaxClassCommandHandler(TaxClassRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteTaxClassCommand(taxClass.ToTaxClass()));

                    if (result.IsSuccess)
                    {
                        if (TaxClassRepository is IWhippetRepository<ITaxClass, short>)
                        {
                            await ((IWhippetRepository<ITaxClass, short>)(TaxClassRepository)).CommitAsync();
                        }
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ITaxClass>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ITaxClass>(result, taxClass);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (TaxClassRepository != null)
            {
                if (TaxClassRepository is IDisposable)
                {
                    ((IDisposable)(TaxClassRepository)).Dispose();
                }

                TaxClassRepository = null;
            }

            base.Dispose();
        }
    }
}
