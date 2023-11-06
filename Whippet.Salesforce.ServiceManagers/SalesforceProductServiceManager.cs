using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using NodaTime;
using Salesforce.Common;
using Salesforce.Force;
using Athi.Whippet;
using Athi.Whippet.Services;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.Salesforce.ServiceManagers.Queries;
using Athi.Whippet.Salesforce.ServiceManagers.Commands;
using Athi.Whippet.Salesforce.ServiceManagers.Handlers.Commands;
using Athi.Whippet.Salesforce.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Salesforce.Repositories;
using Athi.Whippet.Salesforce.Extensions;
using Athi.Whippet.Data;

namespace Athi.Whippet.Salesforce.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="ISalesforceProduct"/> domain objects.
    /// </summary>
    public class SalesforceProductServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="ISalesforceProductRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual ISalesforceProductRepository ProductRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceProductServiceManager"/> class with the specified <see cref="ISalesforceProductRepository"/> object.
        /// </summary>
        /// <param name="productRepository"><see cref="ISalesforceProductRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesforceProductServiceManager(ISalesforceProductRepository productRepository)
            : base()
        {
            if (productRepository == null)
            {
                throw new ArgumentNullException(nameof(productRepository));
            }
            else
            {
                ProductRepository = productRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceProductServiceManager"/> class with the specified <see cref="ISalesforceProductRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="productRepository"><see cref="ISalesforceProductRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesforceProductServiceManager(IWhippetServiceContext serviceLocator, ISalesforceProductRepository productRepository)
            : base(serviceLocator)
        {
            if (productRepository == null)
            {
                throw new ArgumentNullException(nameof(productRepository));
            }
            else
            {
                ProductRepository = productRepository;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="ISalesforceProduct"/> objects.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISalesforceProduct>>> GetSalesforceProducts()
        {
            ISalesforceProductQueryHandler<GetAllSalesforceProductsQuery> handler = new GetAllSalesforceProductsQueryHandler(ProductRepository);
            WhippetResultContainer<IEnumerable<SalesforceProduct>> result = await handler.HandleAsync(new GetAllSalesforceProductsQuery());

            return new WhippetResultContainer<IEnumerable<ISalesforceProduct>>(result.Result, result.Item);
        }

        /// <summary>
        /// Retrieves the <see cref="ISalesforceProduct"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="ISalesforceProduct"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ISalesforceProduct>> GetSalesforceProduct(SalesforceReference id)
        {
            ISalesforceProductQueryHandler<GetSalesforceProductByIdQuery> handler = new GetSalesforceProductByIdQueryHandler(ProductRepository);
            WhippetResultContainer<IEnumerable<SalesforceProduct>> result = await handler.HandleAsync(new GetSalesforceProductByIdQuery(id));

            return new WhippetResultContainer<ISalesforceProduct>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves the <see cref="ISalesforceProduct"/> objects with the specified name.
        /// </summary>
        /// <param name="productName">Name of the <see cref="ISalesforceProduct"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISalesforceProduct>>> GetSalesforceProductsByName(string productName)
        {
            ISalesforceProductQueryHandler<GetSalesforceProductByNameQuery> handler = new GetSalesforceProductByNameQueryHandler(ProductRepository);
            WhippetResultContainer<IEnumerable<SalesforceProduct>> result = await handler.HandleAsync(new GetSalesforceProductByNameQuery(productName));

            return new WhippetResultContainer<IEnumerable<ISalesforceProduct>>(result.Result, result.Item);
        }

        /// <summary>
        /// Retrieves all <see cref="ISalesforceProduct"/> objects with the specified SKU.
        /// </summary>
        /// <param name="sku">SKU of the <see cref="ISalesforceProduct"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISalesforceProduct>>> GetSalesforceProductsByStockKeepingUnit(string sku)
        {
            ISalesforceProductQueryHandler<GetSalesforceProductByStockKeepingUnitQuery> handler = new GetSalesforceProductByStockKeepingUnitQueryHandler(ProductRepository);
            WhippetResultContainer<IEnumerable<SalesforceProduct>> result = await handler.HandleAsync(new GetSalesforceProductByStockKeepingUnitQuery(sku));

            return new WhippetResultContainer<IEnumerable<ISalesforceProduct>>(result.Result, result.Item);
        }

        /// <summary>
        /// Retrieves all <see cref="ISalesforceProduct"/> objects with the specified external ID.
        /// </summary>
        /// <param name="externalID">External ID of the <see cref="ISalesforceProduct"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISalesforceProduct>>> GetSalesforceProductsByExternalID(string externalID)
        {
            ISalesforceProductQueryHandler<GetSalesforceProductByExternalIdQuery> handler = new GetSalesforceProductByExternalIdQueryHandler(ProductRepository);
            WhippetResultContainer<IEnumerable<SalesforceProduct>> result = await handler.HandleAsync(new GetSalesforceProductByExternalIdQuery(externalID));

            return new WhippetResultContainer<IEnumerable<ISalesforceProduct>>(result.Result, result.Item);
        }

        /// <summary>
        /// Creates a new Salesforce client product entry.
        /// </summary>
        /// <param name="product"><see cref="ISalesforceProduct"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ISalesforceProduct"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforceProduct> CreateSalesforceProduct(ISalesforceProduct product)
        {
            return Task<WhippetResultContainer<ISalesforceProduct>>.Run(() => CreateSalesforceProductAsync(product)).Result;
        }

        /// <summary>
        /// Creates a new Salesforce client product entry.
        /// </summary>
        /// <param name="product"><see cref="ISalesforceProduct"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ISalesforceProduct"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforceProduct>> CreateSalesforceProductAsync(ISalesforceProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateSalesforceProductCommand> handler = new CreateSalesforceProductCommandHandler(ProductRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateSalesforceProductCommand(product.ToSalesforceProduct()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforceProduct, SalesforceReference>)(ProductRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforceProduct>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforceProduct>(result, product);
            }
        }

        /// <summary>
        /// Updates an existing Salesforce client product entry.
        /// </summary>
        /// <param name="product"><see cref="ISalesforceProduct"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated <see cref="ISalesforceProduct"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforceProduct> UpdateSalesforceProduct(ISalesforceProduct product)
        {
            return Task<WhippetResultContainer<ISalesforceProduct>>.Run(() => UpdateSalesforceProductAsync(product)).Result;
        }

        /// <summary>
        /// Updates an existing Salesforce client product entry.
        /// </summary>
        /// <param name="product"><see cref="ISalesforceProduct"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated <see cref="ISalesforceProduct"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforceProduct>> UpdateSalesforceProductAsync(ISalesforceProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateSalesforceProductCommand> handler = new UpdateSalesforceProductCommandHandler(ProductRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateSalesforceProductCommand(product.ToSalesforceProduct()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforceProduct, SalesforceReference>)(ProductRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforceProduct>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforceProduct>(result, product);
            }
        }

        /// <summary>
        /// Deletes an existing Salesforce client product entry.
        /// </summary>
        /// <param name="product"><see cref="ISalesforceProduct"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted <see cref="ISalesforceProduct"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforceProduct> DeleteSalesforceProduct(ISalesforceProduct product)
        {
            return Task<WhippetResultContainer<ISalesforceProduct>>.Run(() => DeleteSalesforceProductAsync(product)).Result;
        }

        /// <summary>
        /// Deletes an existing Salesforce client product entry.
        /// </summary>
        /// <param name="product"><see cref="ISalesforceProduct"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted <see cref="ISalesforceProduct"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforceProduct>> DeleteSalesforceProductAsync(ISalesforceProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteSalesforceProductCommand> handler = new DeleteSalesforceProductCommandHandler(ProductRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteSalesforceProductCommand(product.ToSalesforceProduct()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforceProduct, SalesforceReference>)(ProductRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforceProduct>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforceProduct>(result, product);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (ProductRepository != null)
            {
                ProductRepository.Dispose();
                ProductRepository = null;
            }

            base.Dispose();
        }
    }
}
