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
    /// Service manager for <see cref="ISalesforcePriceBook"/> domain objects.
    /// </summary>
    public class SalesforcePriceBookServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="ISalesforcePriceBookRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual ISalesforcePriceBookRepository PriceBookRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforcePriceBookServiceManager"/> class with the specified <see cref="ISalesforcePriceBookRepository"/> object.
        /// </summary>
        /// <param name="priceBookRepository"><see cref="ISalesforcePriceBookRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesforcePriceBookServiceManager(ISalesforcePriceBookRepository priceBookRepository)
            : base()
        {
            if (priceBookRepository == null)
            {
                throw new ArgumentNullException(nameof(priceBookRepository));
            }
            else
            {
                PriceBookRepository = priceBookRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforcePriceBookServiceManager"/> class with the specified <see cref="ISalesforcePriceBookRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="priceBookRepository"><see cref="ISalesforcePriceBookRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesforcePriceBookServiceManager(IWhippetServiceContext serviceLocator, ISalesforcePriceBookRepository priceBookRepository)
            : base(serviceLocator)
        {
            if (priceBookRepository == null)
            {
                throw new ArgumentNullException(nameof(priceBookRepository));
            }
            else
            {
                PriceBookRepository = priceBookRepository;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="ISalesforcePriceBook"/> objects.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISalesforcePriceBook>>> GetSalesforcePriceBooks()
        {
            ISalesforcePriceBookQueryHandler<GetAllSalesforcePriceBooksQuery> handler = new GetAllSalesforcePriceBooksQueryHandler(PriceBookRepository);
            WhippetResultContainer<IEnumerable<SalesforcePriceBook>> result = await handler.HandleAsync(new GetAllSalesforcePriceBooksQuery());

            return new WhippetResultContainer<IEnumerable<ISalesforcePriceBook>>(result.Result, result.Item);
        }

        /// <summary>
        /// Retrieves the <see cref="ISalesforcePriceBook"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="ISalesforcePriceBook"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ISalesforcePriceBook>> GetSalesforcePriceBook(SalesforceReference id)
        {
            ISalesforcePriceBookQueryHandler<GetSalesforcePriceBookByIdQuery> handler = new GetSalesforcePriceBookByIdQueryHandler(PriceBookRepository);
            WhippetResultContainer<IEnumerable<SalesforcePriceBook>> result = await handler.HandleAsync(new GetSalesforcePriceBookByIdQuery(id));

            return new WhippetResultContainer<ISalesforcePriceBook>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves the <see cref="ISalesforcePriceBook"/> object with the specified name.
        /// </summary>
        /// <param name="priceBookName">Name of the <see cref="ISalesforcePriceBook"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ISalesforcePriceBook>> GetSalesforcePriceBookByName(string priceBookName)
        {
            ISalesforcePriceBookQueryHandler<GetSalesforcePriceBookByNameQuery> handler = new GetSalesforcePriceBookByNameQueryHandler(PriceBookRepository);
            WhippetResultContainer<IEnumerable<SalesforcePriceBook>> result = await handler.HandleAsync(new GetSalesforcePriceBookByNameQuery(priceBookName));

            return new WhippetResultContainer<ISalesforcePriceBook>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves the <see cref="ISalesforcePriceBook"/> object that is the standard price book for the Salesforce organization.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ISalesforcePriceBook>> GetStandardSalesforcePriceBook()
        {
            WhippetResultContainer<IEnumerable<ISalesforcePriceBook>> result = await GetSalesforcePriceBooks();
            return new WhippetResultContainer<ISalesforcePriceBook>(result.Result, result.Item.Where(pb => pb.IsStandard).FirstOrDefault());
        }

        /// <summary>
        /// Creates a new Salesforce client priceBook entry.
        /// </summary>
        /// <param name="priceBook"><see cref="ISalesforcePriceBook"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ISalesforcePriceBook"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforcePriceBook> CreateSalesforcePriceBook(ISalesforcePriceBook priceBook)
        {
            return Task<WhippetResultContainer<ISalesforcePriceBook>>.Run(() => CreateSalesforcePriceBookAsync(priceBook)).Result;
        }

        /// <summary>
        /// Creates a new Salesforce client priceBook entry.
        /// </summary>
        /// <param name="priceBook"><see cref="ISalesforcePriceBook"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ISalesforcePriceBook"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforcePriceBook>> CreateSalesforcePriceBookAsync(ISalesforcePriceBook priceBook)
        {
            if (priceBook == null)
            {
                throw new ArgumentNullException(nameof(priceBook));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateSalesforcePriceBookCommand> handler = new CreateSalesforcePriceBookCommandHandler(PriceBookRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateSalesforcePriceBookCommand(priceBook.ToSalesforcePriceBook()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforcePriceBook, SalesforceReference>)(PriceBookRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforcePriceBook>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforcePriceBook>(result, priceBook);
            }
        }

        /// <summary>
        /// Updates an existing Salesforce client priceBook entry.
        /// </summary>
        /// <param name="priceBook"><see cref="ISalesforcePriceBook"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated <see cref="ISalesforcePriceBook"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforcePriceBook> UpdateSalesforcePriceBook(ISalesforcePriceBook priceBook)
        {
            return Task<WhippetResultContainer<ISalesforcePriceBook>>.Run(() => UpdateSalesforcePriceBookAsync(priceBook)).Result;
        }

        /// <summary>
        /// Updates an existing Salesforce client priceBook entry.
        /// </summary>
        /// <param name="priceBook"><see cref="ISalesforcePriceBook"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated <see cref="ISalesforcePriceBook"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforcePriceBook>> UpdateSalesforcePriceBookAsync(ISalesforcePriceBook priceBook)
        {
            if (priceBook == null)
            {
                throw new ArgumentNullException(nameof(priceBook));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateSalesforcePriceBookCommand> handler = new UpdateSalesforcePriceBookCommandHandler(PriceBookRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateSalesforcePriceBookCommand(priceBook.ToSalesforcePriceBook()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforcePriceBook, SalesforceReference>)(PriceBookRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforcePriceBook>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforcePriceBook>(result, priceBook);
            }
        }

        /// <summary>
        /// Deletes an existing Salesforce client priceBook entry.
        /// </summary>
        /// <param name="priceBook"><see cref="ISalesforcePriceBook"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted <see cref="ISalesforcePriceBook"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforcePriceBook> DeleteSalesforcePriceBook(ISalesforcePriceBook priceBook)
        {
            return Task<WhippetResultContainer<ISalesforcePriceBook>>.Run(() => DeleteSalesforcePriceBookAsync(priceBook)).Result;
        }

        /// <summary>
        /// Deletes an existing Salesforce client priceBook entry.
        /// </summary>
        /// <param name="priceBook"><see cref="ISalesforcePriceBook"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted <see cref="ISalesforcePriceBook"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforcePriceBook>> DeleteSalesforcePriceBookAsync(ISalesforcePriceBook priceBook)
        {
            if (priceBook == null)
            {
                throw new ArgumentNullException(nameof(priceBook));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteSalesforcePriceBookCommand> handler = new DeleteSalesforcePriceBookCommandHandler(PriceBookRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteSalesforcePriceBookCommand(priceBook.ToSalesforcePriceBook()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforcePriceBook, SalesforceReference>)(PriceBookRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforcePriceBook>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforcePriceBook>(result, priceBook);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (PriceBookRepository != null)
            {
                PriceBookRepository.Dispose();
                PriceBookRepository = null;
            }

            base.Dispose();
        }
    }
}
