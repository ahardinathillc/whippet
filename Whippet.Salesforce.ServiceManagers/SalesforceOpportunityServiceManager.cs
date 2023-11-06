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
    /// Service manager for <see cref="ISalesforceOpportunity"/> domain objects.
    /// </summary>
    public class SalesforceOpportunityServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="ISalesforceOpportunityRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual ISalesforceOpportunityRepository OpportunityRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceOpportunityServiceManager"/> class with the specified <see cref="ISalesforceOpportunityRepository"/> object.
        /// </summary>
        /// <param name="opportunityRepository"><see cref="ISalesforceOpportunityRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesforceOpportunityServiceManager(ISalesforceOpportunityRepository opportunityRepository)
            : base()
        {
            if (opportunityRepository == null)
            {
                throw new ArgumentNullException(nameof(opportunityRepository));
            }
            else
            {
                OpportunityRepository = opportunityRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceOpportunityServiceManager"/> class with the specified <see cref="ISalesforceOpportunityRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="opportunityRepository"><see cref="ISalesforceOpportunityRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesforceOpportunityServiceManager(IWhippetServiceContext serviceLocator, ISalesforceOpportunityRepository opportunityRepository)
            : base(serviceLocator)
        {
            if (opportunityRepository == null)
            {
                throw new ArgumentNullException(nameof(opportunityRepository));
            }
            else
            {
                OpportunityRepository = opportunityRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="ISalesforceOpportunity"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="ISalesforceOpportunity"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ISalesforceOpportunity>> GetSalesforceOpportunity(SalesforceReference id)
        {
            ISalesforceOpportunityQueryHandler<GetSalesforceOpportunityByIdQuery> handler = new GetSalesforceOpportunityByIdQueryHandler(OpportunityRepository);
            WhippetResultContainer<IEnumerable<SalesforceOpportunity>> result = await handler.HandleAsync(new GetSalesforceOpportunityByIdQuery(id));

            return new WhippetResultContainer<ISalesforceOpportunity>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves the <see cref="ISalesforceOpportunity"/> object with the specified name.
        /// </summary>
        /// <param name="opportunityName">Name of the <see cref="ISalesforceOpportunity"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ISalesforceOpportunity>> GetSalesforceOpportunityByName(string opportunityName)
        {
            ISalesforceOpportunityQueryHandler<GetSalesforceOpportunityByNameQuery> handler = new GetSalesforceOpportunityByNameQueryHandler(OpportunityRepository);
            WhippetResultContainer<IEnumerable<SalesforceOpportunity>> result = await handler.HandleAsync(new GetSalesforceOpportunityByNameQuery(opportunityName));

            return new WhippetResultContainer<ISalesforceOpportunity>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Creates a new Salesforce client opportunity entry.
        /// </summary>
        /// <param name="opportunity"><see cref="ISalesforceOpportunity"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ISalesforceOpportunity"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforceOpportunity> CreateSalesforceOpportunity(ISalesforceOpportunity opportunity)
        {
            return Task<WhippetResultContainer<ISalesforceOpportunity>>.Run(() => CreateSalesforceOpportunityAsync(opportunity)).Result;
        }

        /// <summary>
        /// Creates a new Salesforce client opportunity entry.
        /// </summary>
        /// <param name="opportunity"><see cref="ISalesforceOpportunity"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ISalesforceOpportunity"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforceOpportunity>> CreateSalesforceOpportunityAsync(ISalesforceOpportunity opportunity)
        {
            if (opportunity == null)
            {
                throw new ArgumentNullException(nameof(opportunity));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateSalesforceOpportunityCommand> handler = new CreateSalesforceOpportunityCommandHandler(OpportunityRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateSalesforceOpportunityCommand(opportunity.ToSalesforceOpportunity()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforceOpportunity, SalesforceReference>)(OpportunityRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforceOpportunity>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforceOpportunity>(result, opportunity);
            }
        }

        /// <summary>
        /// Updates an existing Salesforce client opportunity entry.
        /// </summary>
        /// <param name="opportunity"><see cref="ISalesforceOpportunity"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated <see cref="ISalesforceOpportunity"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforceOpportunity> UpdateSalesforceOpportunity(ISalesforceOpportunity opportunity)
        {
            return Task<WhippetResultContainer<ISalesforceOpportunity>>.Run(() => UpdateSalesforceOpportunityAsync(opportunity)).Result;
        }

        /// <summary>
        /// Updates an existing Salesforce client opportunity entry.
        /// </summary>
        /// <param name="opportunity"><see cref="ISalesforceOpportunity"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated <see cref="ISalesforceOpportunity"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforceOpportunity>> UpdateSalesforceOpportunityAsync(ISalesforceOpportunity opportunity)
        {
            if (opportunity == null)
            {
                throw new ArgumentNullException(nameof(opportunity));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateSalesforceOpportunityCommand> handler = new UpdateSalesforceOpportunityCommandHandler(OpportunityRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateSalesforceOpportunityCommand(opportunity.ToSalesforceOpportunity()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforceOpportunity, SalesforceReference>)(OpportunityRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforceOpportunity>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforceOpportunity>(result, opportunity);
            }
        }

        /// <summary>
        /// Deletes an existing Salesforce client opportunity entry.
        /// </summary>
        /// <param name="opportunity"><see cref="ISalesforceOpportunity"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted <see cref="ISalesforceOpportunity"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforceOpportunity> DeleteSalesforceOpportunity(ISalesforceOpportunity opportunity)
        {
            return Task<WhippetResultContainer<ISalesforceOpportunity>>.Run(() => DeleteSalesforceOpportunityAsync(opportunity)).Result;
        }

        /// <summary>
        /// Deletes an existing Salesforce client opportunity entry.
        /// </summary>
        /// <param name="opportunity"><see cref="ISalesforceOpportunity"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted <see cref="ISalesforceOpportunity"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforceOpportunity>> DeleteSalesforceOpportunityAsync(ISalesforceOpportunity opportunity)
        {
            if (opportunity == null)
            {
                throw new ArgumentNullException(nameof(opportunity));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteSalesforceOpportunityCommand> handler = new DeleteSalesforceOpportunityCommandHandler(OpportunityRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteSalesforceOpportunityCommand(opportunity.ToSalesforceOpportunity()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforceOpportunity, SalesforceReference>)(OpportunityRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforceOpportunity>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforceOpportunity>(result, opportunity);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (OpportunityRepository != null)
            {
                OpportunityRepository.Dispose();
                OpportunityRepository = null;
            }

            base.Dispose();
        }
    }
}
