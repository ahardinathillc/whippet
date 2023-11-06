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
    /// Service manager for <see cref="ISalesforceLead"/> domain objects.
    /// </summary>
    public class SalesforceLeadServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="ISalesforceLeadRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual ISalesforceLeadRepository LeadRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceLeadServiceManager"/> class with the specified <see cref="ISalesforceLeadRepository"/> object.
        /// </summary>
        /// <param name="leadRepository"><see cref="ISalesforceLeadRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesforceLeadServiceManager(ISalesforceLeadRepository leadRepository)
            : base()
        {
            if (leadRepository == null)
            {
                throw new ArgumentNullException(nameof(leadRepository));
            }
            else
            {
                LeadRepository = leadRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceLeadServiceManager"/> class with the specified <see cref="ISalesforceLeadRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="leadRepository"><see cref="ISalesforceLeadRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesforceLeadServiceManager(IWhippetServiceContext serviceLocator, ISalesforceLeadRepository leadRepository)
            : base(serviceLocator)
        {
            if (leadRepository == null)
            {
                throw new ArgumentNullException(nameof(leadRepository));
            }
            else
            {
                LeadRepository = leadRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="ISalesforceLead"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="ISalesforceLead"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ISalesforceLead>> GetSalesforceLead(SalesforceReference id)
        {
            ISalesforceLeadQueryHandler<GetSalesforceLeadByIdQuery> handler = new GetSalesforceLeadByIdQueryHandler(LeadRepository);
            WhippetResultContainer<IEnumerable<SalesforceLead>> result = await handler.HandleAsync(new GetSalesforceLeadByIdQuery(id));

            return new WhippetResultContainer<ISalesforceLead>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrives the <see cref="ISalesforceLead"/> object that matches the given first and last names.
        /// </summary>
        /// <param name="firstName">First name to filter by.</param>
        /// <param name="lastName">Last name to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<ISalesforceLead>> GetSalesforceLeadByName(string firstName, string lastName)
        {
            if (String.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }
            else if (String.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }
            else
            {
                ISalesforceLeadQueryHandler<GetSalesforceLeadByNameQuery> handler = new GetSalesforceLeadByNameQueryHandler(LeadRepository);
                WhippetResultContainer<IEnumerable<SalesforceLead>> result = await handler.HandleAsync(new GetSalesforceLeadByNameQuery(firstName, lastName));

                return new WhippetResultContainer<ISalesforceLead>(result.Result, result.Item.FirstOrDefault());
            }
        }

        /// <summary>
        /// Creates a new Salesforce client lead entry.
        /// </summary>
        /// <param name="lead"><see cref="ISalesforceLead"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ISalesforceLead"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforceLead> CreateSalesforceLead(ISalesforceLead lead)
        {
            return Task<WhippetResultContainer<ISalesforceLead>>.Run(() => CreateSalesforceLeadAsync(lead)).Result;
        }

        /// <summary>
        /// Creates a new Salesforce client lead entry.
        /// </summary>
        /// <param name="lead"><see cref="ISalesforceLead"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ISalesforceLead"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforceLead>> CreateSalesforceLeadAsync(ISalesforceLead lead)
        {
            if (lead == null)
            {
                throw new ArgumentNullException(nameof(lead));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateSalesforceLeadCommand> handler = new CreateSalesforceLeadCommandHandler(LeadRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateSalesforceLeadCommand(lead.ToSalesforceLead()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforceLead, SalesforceReference>)(LeadRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforceLead>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforceLead>(result, lead);
            }
        }

        /// <summary>
        /// Updates an existing Salesforce client lead entry.
        /// </summary>
        /// <param name="lead"><see cref="ISalesforceLead"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated <see cref="ISalesforceLead"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforceLead> UpdateSalesforceLead(ISalesforceLead lead)
        {
            return Task<WhippetResultContainer<ISalesforceLead>>.Run(() => UpdateSalesforceLeadAsync(lead)).Result;
        }

        /// <summary>
        /// Updates an existing Salesforce client lead entry.
        /// </summary>
        /// <param name="lead"><see cref="ISalesforceLead"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated <see cref="ISalesforceLead"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforceLead>> UpdateSalesforceLeadAsync(ISalesforceLead lead)
        {
            if (lead == null)
            {
                throw new ArgumentNullException(nameof(lead));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateSalesforceLeadCommand> handler = new UpdateSalesforceLeadCommandHandler(LeadRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateSalesforceLeadCommand(lead.ToSalesforceLead()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforceLead, SalesforceReference>)(LeadRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforceLead>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforceLead>(result, lead);
            }
        }

        /// <summary>
        /// Deletes an existing Salesforce client lead entry.
        /// </summary>
        /// <param name="lead"><see cref="ISalesforceLead"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted <see cref="ISalesforceLead"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforceLead> DeleteSalesforceLead(ISalesforceLead lead)
        {
            return Task<WhippetResultContainer<ISalesforceLead>>.Run(() => DeleteSalesforceLeadAsync(lead)).Result;
        }

        /// <summary>
        /// Deletes an existing Salesforce client lead entry.
        /// </summary>
        /// <param name="lead"><see cref="ISalesforceLead"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted <see cref="ISalesforceLead"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforceLead>> DeleteSalesforceLeadAsync(ISalesforceLead lead)
        {
            if (lead == null)
            {
                throw new ArgumentNullException(nameof(lead));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteSalesforceLeadCommand> handler = new DeleteSalesforceLeadCommandHandler(LeadRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteSalesforceLeadCommand(lead.ToSalesforceLead()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforceLead, SalesforceReference>)(LeadRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforceLead>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforceLead>(result, lead);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (LeadRepository != null)
            {
                LeadRepository.Dispose();
                LeadRepository = null;
            }

            base.Dispose();
        }
    }
}
