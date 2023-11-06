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
    /// Service manager for <see cref="ISalesforcePriceBookEntry"/> domain objects.
    /// </summary>
    public class SalesforcePriceBookEntryServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="ISalesforcePriceBookEntryRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual ISalesforcePriceBookEntryRepository PriceBookEntryRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforcePriceBookEntryServiceManager"/> class with the specified <see cref="ISalesforcePriceBookEntryRepository"/> object.
        /// </summary>
        /// <param name="priceBookEntryRepository"><see cref="ISalesforcePriceBookEntryRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesforcePriceBookEntryServiceManager(ISalesforcePriceBookEntryRepository priceBookEntryRepository)
            : base()
        {
            if (priceBookEntryRepository == null)
            {
                throw new ArgumentNullException(nameof(priceBookEntryRepository));
            }
            else
            {
                PriceBookEntryRepository = priceBookEntryRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforcePriceBookEntryServiceManager"/> class with the specified <see cref="ISalesforcePriceBookEntryRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="priceBookEntryRepository"><see cref="ISalesforcePriceBookEntryRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesforcePriceBookEntryServiceManager(IWhippetServiceContext serviceLocator, ISalesforcePriceBookEntryRepository priceBookEntryRepository)
            : base(serviceLocator)
        {
            if (priceBookEntryRepository == null)
            {
                throw new ArgumentNullException(nameof(priceBookEntryRepository));
            }
            else
            {
                PriceBookEntryRepository = priceBookEntryRepository;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="ISalesforcePriceBookEntry"/> objects for a specific <see cref="ISalesforcePriceBook"/>.
        /// </summary>
        /// <param name="priceBook"><see cref="ISalesforcePriceBook"/> object to get the <see cref="ISalesforcePriceBookEntry"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<ISalesforcePriceBookEntry>>> GetSalesforcePriceBookEntries(ISalesforcePriceBook priceBook)
        {
            if (priceBook == null)
            {
                throw new ArgumentNullException(nameof(priceBook));
            }
            else
            {
                ISalesforcePriceBookEntryQueryHandler<GetAllSalesforcePriceBookEntriesForPriceBookQuery> handler = new GetAllSalesforcePriceBookEntriesForPriceBookQueryHandler(PriceBookEntryRepository);
                WhippetResultContainer<IEnumerable<SalesforcePriceBookEntry>> result = await handler.HandleAsync(new GetAllSalesforcePriceBookEntriesForPriceBookQuery(priceBook.ObjectID.GetValueOrDefault()));

                return new WhippetResultContainer<IEnumerable<ISalesforcePriceBookEntry>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Retrieves the <see cref="ISalesforcePriceBookEntry"/> object with the specified ID.
        /// </summary>
        /// <param name="id">Composite ID of the <see cref="ISalesforcePriceBookEntry"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ISalesforcePriceBookEntry>> GetSalesforcePriceBookEntry(SalesforcePriceBookEntryKey id)
        {
            ISalesforcePriceBookEntryQueryHandler<GetSalesforcePriceBookEntryByIdQuery> handler = new GetSalesforcePriceBookEntryByIdQueryHandler(PriceBookEntryRepository);
            WhippetResultContainer<IEnumerable<SalesforcePriceBookEntry>> result = await handler.HandleAsync(new GetSalesforcePriceBookEntryByIdQuery(id));

            return new WhippetResultContainer<ISalesforcePriceBookEntry>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Creates a new Salesforce client price book entry.
        /// </summary>
        /// <param name="priceBookEntry"><see cref="ISalesforcePriceBookEntry"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ISalesforcePriceBookEntry"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforcePriceBookEntry> CreateSalesforcePriceBookEntry(ISalesforcePriceBookEntry priceBookEntry)
        {
            return Task<WhippetResultContainer<ISalesforcePriceBookEntry>>.Run(() => CreateSalesforcePriceBookEntryAsync(priceBookEntry)).Result;
        }

        /// <summary>
        /// Creates a new Salesforce client price book entry.
        /// </summary>
        /// <param name="priceBookEntry"><see cref="ISalesforcePriceBookEntry"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ISalesforcePriceBookEntry"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforcePriceBookEntry>> CreateSalesforcePriceBookEntryAsync(ISalesforcePriceBookEntry priceBookEntry)
        {
            if (priceBookEntry == null)
            {
                throw new ArgumentNullException(nameof(priceBookEntry));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateSalesforcePriceBookEntryCommand> handler = new CreateSalesforcePriceBookEntryCommandHandler(PriceBookEntryRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateSalesforcePriceBookEntryCommand(priceBookEntry.ToSalesforcePriceBookEntry()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforcePriceBookEntry, SalesforceReference>)(PriceBookEntryRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforcePriceBookEntry>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforcePriceBookEntry>(result, priceBookEntry);
            }
        }

        /// <summary>
        /// Updates an existing Salesforce client price book entry.
        /// </summary>
        /// <param name="priceBookEntry"><see cref="ISalesforcePriceBookEntry"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated <see cref="ISalesforcePriceBookEntry"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforcePriceBookEntry> UpdateSalesforcePriceBookEntry(ISalesforcePriceBookEntry priceBookEntry)
        {
            return Task<WhippetResultContainer<ISalesforcePriceBookEntry>>.Run(() => UpdateSalesforcePriceBookEntryAsync(priceBookEntry)).Result;
        }

        /// <summary>
        /// Updates an existing Salesforce client price book entry.
        /// </summary>
        /// <param name="priceBookEntry"><see cref="ISalesforcePriceBookEntry"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated <see cref="ISalesforcePriceBookEntry"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforcePriceBookEntry>> UpdateSalesforcePriceBookEntryAsync(ISalesforcePriceBookEntry priceBookEntry)
        {
            if (priceBookEntry == null)
            {
                throw new ArgumentNullException(nameof(priceBookEntry));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateSalesforcePriceBookEntryCommand> handler = new UpdateSalesforcePriceBookEntryCommandHandler(PriceBookEntryRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateSalesforcePriceBookEntryCommand(priceBookEntry.ToSalesforcePriceBookEntry()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforcePriceBookEntry, SalesforceReference>)(PriceBookEntryRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforcePriceBookEntry>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforcePriceBookEntry>(result, priceBookEntry);
            }
        }

        /// <summary>
        /// Deletes an existing Salesforce client price book entry.
        /// </summary>
        /// <param name="priceBookEntry"><see cref="ISalesforcePriceBookEntry"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted <see cref="ISalesforcePriceBookEntry"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforcePriceBookEntry> DeleteSalesforcePriceBookEntry(ISalesforcePriceBookEntry priceBookEntry)
        {
            return Task<WhippetResultContainer<ISalesforcePriceBookEntry>>.Run(() => DeleteSalesforcePriceBookEntryAsync(priceBookEntry)).Result;
        }

        /// <summary>
        /// Deletes an existing Salesforce client price book entry.
        /// </summary>
        /// <param name="priceBookEntry"><see cref="ISalesforcePriceBookEntry"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted <see cref="ISalesforcePriceBookEntry"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforcePriceBookEntry>> DeleteSalesforcePriceBookEntryAsync(ISalesforcePriceBookEntry priceBookEntry)
        {
            if (priceBookEntry == null)
            {
                throw new ArgumentNullException(nameof(priceBookEntry));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteSalesforcePriceBookEntryCommand> handler = new DeleteSalesforcePriceBookEntryCommandHandler(PriceBookEntryRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteSalesforcePriceBookEntryCommand(priceBookEntry.ToSalesforcePriceBookEntry()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforcePriceBookEntry, SalesforceReference>)(PriceBookEntryRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforcePriceBookEntry>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforcePriceBookEntry>(result, priceBookEntry);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (PriceBookEntryRepository != null)
            {
                PriceBookEntryRepository.Dispose();
                PriceBookEntryRepository = null;
            }

            base.Dispose();
        }
    }
}
