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
    /// Service manager for <see cref="ISalesforceCampaign"/> domain objects.
    /// </summary>
    public class SalesforceCampaignServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="ISalesforceCampaignRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual ISalesforceCampaignRepository CampaignRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceCampaignServiceManager"/> class with the specified <see cref="ISalesforceCampaignRepository"/> object.
        /// </summary>
        /// <param name="campaignRepository"><see cref="ISalesforceCampaignRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesforceCampaignServiceManager(ISalesforceCampaignRepository campaignRepository)
            : base()
        {
            if (campaignRepository == null)
            {
                throw new ArgumentNullException(nameof(campaignRepository));
            }
            else
            {
                CampaignRepository = campaignRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceCampaignServiceManager"/> class with the specified <see cref="ISalesforceCampaignRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="campaignRepository"><see cref="ISalesforceCampaignRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesforceCampaignServiceManager(IWhippetServiceContext serviceLocator, ISalesforceCampaignRepository campaignRepository)
            : base(serviceLocator)
        {
            if (campaignRepository == null)
            {
                throw new ArgumentNullException(nameof(campaignRepository));
            }
            else
            {
                CampaignRepository = campaignRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="ISalesforceCampaign"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="ISalesforceCampaign"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ISalesforceCampaign>> GetSalesforceCampaign(SalesforceReference id)
        {
            ISalesforceCampaignQueryHandler<GetSalesforceCampaignByIdQuery> handler = new GetSalesforceCampaignByIdQueryHandler(CampaignRepository);
            WhippetResultContainer<IEnumerable<SalesforceCampaign>> result = await handler.HandleAsync(new GetSalesforceCampaignByIdQuery(id));

            return new WhippetResultContainer<ISalesforceCampaign>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves the <see cref="ISalesforceCampaign"/> object with the specified name.
        /// </summary>
        /// <param name="campaignName">Name of the <see cref="ISalesforceCampaign"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ISalesforceCampaign>> GetSalesforceCampaignByName(string campaignName)
        {
            ISalesforceCampaignQueryHandler<GetSalesforceCampaignByNameQuery> handler = new GetSalesforceCampaignByNameQueryHandler(CampaignRepository);
            WhippetResultContainer<IEnumerable<SalesforceCampaign>> result = await handler.HandleAsync(new GetSalesforceCampaignByNameQuery(campaignName));

            return new WhippetResultContainer<ISalesforceCampaign>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Creates a new Salesforce client campaign entry.
        /// </summary>
        /// <param name="campaign"><see cref="ISalesforceCampaign"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ISalesforceCampaign"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforceCampaign> CreateSalesforceCampaign(ISalesforceCampaign campaign)
        {
            return Task<WhippetResultContainer<ISalesforceCampaign>>.Run(() => CreateSalesforceCampaignAsync(campaign)).Result;
        }

        /// <summary>
        /// Creates a new Salesforce client campaign entry.
        /// </summary>
        /// <param name="campaign"><see cref="ISalesforceCampaign"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ISalesforceCampaign"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforceCampaign>> CreateSalesforceCampaignAsync(ISalesforceCampaign campaign)
        {
            if (campaign == null)
            {
                throw new ArgumentNullException(nameof(campaign));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateSalesforceCampaignCommand> handler = new CreateSalesforceCampaignCommandHandler(CampaignRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateSalesforceCampaignCommand(campaign.ToSalesforceCampaign()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforceCampaign, SalesforceReference>)(CampaignRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforceCampaign>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforceCampaign>(result, campaign);
            }
        }

        /// <summary>
        /// Updates an existing Salesforce client campaign entry.
        /// </summary>
        /// <param name="campaign"><see cref="ISalesforceCampaign"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated <see cref="ISalesforceCampaign"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforceCampaign> UpdateSalesforceCampaign(ISalesforceCampaign campaign)
        {
            return Task<WhippetResultContainer<ISalesforceCampaign>>.Run(() => UpdateSalesforceCampaignAsync(campaign)).Result;
        }

        /// <summary>
        /// Updates an existing Salesforce client campaign entry.
        /// </summary>
        /// <param name="campaign"><see cref="ISalesforceCampaign"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated <see cref="ISalesforceCampaign"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforceCampaign>> UpdateSalesforceCampaignAsync(ISalesforceCampaign campaign)
        {
            if (campaign == null)
            {
                throw new ArgumentNullException(nameof(campaign));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateSalesforceCampaignCommand> handler = new UpdateSalesforceCampaignCommandHandler(CampaignRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateSalesforceCampaignCommand(campaign.ToSalesforceCampaign()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforceCampaign, SalesforceReference>)(CampaignRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforceCampaign>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforceCampaign>(result, campaign);
            }
        }

        /// <summary>
        /// Deletes an existing Salesforce client campaign entry.
        /// </summary>
        /// <param name="campaign"><see cref="ISalesforceCampaign"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted <see cref="ISalesforceCampaign"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforceCampaign> DeleteSalesforceCampaign(ISalesforceCampaign campaign)
        {
            return Task<WhippetResultContainer<ISalesforceCampaign>>.Run(() => DeleteSalesforceCampaignAsync(campaign)).Result;
        }

        /// <summary>
        /// Deletes an existing Salesforce client campaign entry.
        /// </summary>
        /// <param name="campaign"><see cref="ISalesforceCampaign"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted <see cref="ISalesforceCampaign"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforceCampaign>> DeleteSalesforceCampaignAsync(ISalesforceCampaign campaign)
        {
            if (campaign == null)
            {
                throw new ArgumentNullException(nameof(campaign));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteSalesforceCampaignCommand> handler = new DeleteSalesforceCampaignCommandHandler(CampaignRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteSalesforceCampaignCommand(campaign.ToSalesforceCampaign()));

                    if (result.IsSuccess)
                    {
                        await ((IWhippetRepository<SalesforceCampaign, SalesforceReference>)(CampaignRepository)).CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforceCampaign>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforceCampaign>(result, campaign);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (CampaignRepository != null)
            {
                CampaignRepository.Dispose();
                CampaignRepository = null;
            }

            base.Dispose();
        }
    }
}
