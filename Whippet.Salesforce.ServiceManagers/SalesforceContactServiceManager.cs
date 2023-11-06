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
    /// Service manager for <see cref="ISalesforceContact"/> domain objects.
    /// </summary>
    public class SalesforceContactServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="ISalesforceContactRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual ISalesforceContactRepository ContactRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceContactServiceManager"/> class with the specified <see cref="ISalesforceContactRepository"/> object.
        /// </summary>
        /// <param name="contactRepository"><see cref="ISalesforceContactRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesforceContactServiceManager(ISalesforceContactRepository contactRepository)
            : base()
        {
            if (contactRepository == null)
            {
                throw new ArgumentNullException(nameof(contactRepository));
            }
            else
            {
                ContactRepository = contactRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceContactServiceManager"/> class with the specified <see cref="ISalesforceContactRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="contactRepository"><see cref="ISalesforceContactRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesforceContactServiceManager(IWhippetServiceContext serviceLocator, ISalesforceContactRepository contactRepository)
            : base(serviceLocator)
        {
            if (contactRepository == null)
            {
                throw new ArgumentNullException(nameof(contactRepository));
            }
            else
            {
                ContactRepository = contactRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="ISalesforceContact"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="ISalesforceContact"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ISalesforceContact>> GetSalesforceContact(SalesforceReference id)
        {
            ISalesforceContactQueryHandler<GetSalesforceContactByIdQuery> handler = new GetSalesforceContactByIdQueryHandler(ContactRepository);
            WhippetResultContainer<IEnumerable<SalesforceContact>> result = await handler.HandleAsync(new GetSalesforceContactByIdQuery(id));

            return new WhippetResultContainer<ISalesforceContact>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrives all <see cref="ISalesforceContact"/> objects for the specified <see cref="ISalesforceAccount"/> instance.
        /// </summary>
        /// <param name="account"><see cref="ISalesforceAccount"/> to retrieve all <see cref="ISalesforceContact"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISalesforceContact>>> GetSalesforceContactsForAccount(ISalesforceAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            else
            {
                ISalesforceContactQueryHandler<GetAllSalesforceContactsForAccountQuery> handler = new GetAllSalesforceContactsForAccountQueryHandler(ContactRepository);
                WhippetResultContainer<IEnumerable<SalesforceContact>> result = await handler.HandleAsync(new GetAllSalesforceContactsForAccountQuery(account));

                return new WhippetResultContainer<IEnumerable<ISalesforceContact>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Retrives the <see cref="ISalesforceContact"/> object for the specified <see cref="ISalesforceAccount"/> instance that match the given first and last names.
        /// </summary>
        /// <param name="account"><see cref="ISalesforceAccount"/> to retrieve the <see cref="ISalesforceContact"/> object for.</param>
        /// <param name="firstName">First name to filter by.</param>
        /// <param name="lastName">Last name to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<ISalesforceContact>> GetSalesforceContactByName(ISalesforceAccount account, string firstName, string lastName)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            else if (String.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }
            else if (String.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }
            else
            {
                ISalesforceContactQueryHandler<GetSalesforceContactByNameQuery> handler = new GetSalesforceContactByNameQueryHandler(ContactRepository);
                WhippetResultContainer<IEnumerable<SalesforceContact>> result = await handler.HandleAsync(new GetSalesforceContactByNameQuery(account, firstName, lastName));

                return new WhippetResultContainer<ISalesforceContact>(result.Result, result.Item.FirstOrDefault());
            }
        }

        /// <summary>
        /// Creates a new Salesforce client contact entry.
        /// </summary>
        /// <param name="contact"><see cref="ISalesforceContact"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ISalesforceContact"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforceContact> CreateSalesforceContact(ISalesforceContact contact)
        {
            return Task<WhippetResultContainer<ISalesforceContact>>.Run(() => CreateSalesforceContactAsync(contact)).Result;
        }

        /// <summary>
        /// Creates a new Salesforce client contact entry.
        /// </summary>
        /// <param name="contact"><see cref="ISalesforceContact"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ISalesforceContact"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforceContact>> CreateSalesforceContactAsync(ISalesforceContact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateSalesforceContactCommand> handler = new CreateSalesforceContactCommandHandler(ContactRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateSalesforceContactCommand(contact.ToSalesforceContact()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforceContact, SalesforceReference>)(ContactRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforceContact>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforceContact>(result, contact);
            }
        }

        /// <summary>
        /// Updates an existing Salesforce client contact entry.
        /// </summary>
        /// <param name="contact"><see cref="ISalesforceContact"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated <see cref="ISalesforceContact"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforceContact> UpdateSalesforceContact(ISalesforceContact contact)
        {
            return Task<WhippetResultContainer<ISalesforceContact>>.Run(() => UpdateSalesforceContactAsync(contact)).Result;
        }

        /// <summary>
        /// Updates an existing Salesforce client contact entry.
        /// </summary>
        /// <param name="contact"><see cref="ISalesforceContact"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated <see cref="ISalesforceContact"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforceContact>> UpdateSalesforceContactAsync(ISalesforceContact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateSalesforceContactCommand> handler = new UpdateSalesforceContactCommandHandler(ContactRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateSalesforceContactCommand(contact.ToSalesforceContact()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforceContact, SalesforceReference>)(ContactRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforceContact>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforceContact>(result, contact);
            }
        }

        /// <summary>
        /// Deletes an existing Salesforce client contact entry.
        /// </summary>
        /// <param name="contact"><see cref="ISalesforceContact"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted <see cref="ISalesforceContact"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforceContact> DeleteSalesforceContact(ISalesforceContact contact)
        {
            return Task<WhippetResultContainer<ISalesforceContact>>.Run(() => DeleteSalesforceContactAsync(contact)).Result;
        }

        /// <summary>
        /// Deletes an existing Salesforce client contact entry.
        /// </summary>
        /// <param name="contact"><see cref="ISalesforceContact"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted <see cref="ISalesforceContact"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforceContact>> DeleteSalesforceContactAsync(ISalesforceContact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteSalesforceContactCommand> handler = new DeleteSalesforceContactCommandHandler(ContactRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteSalesforceContactCommand(contact.ToSalesforceContact()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforceContact, SalesforceReference>)(ContactRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforceContact>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforceContact>(result, contact);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (ContactRepository != null)
            {
                ContactRepository.Dispose();
                ContactRepository = null;
            }

            base.Dispose();
        }
    }
}
