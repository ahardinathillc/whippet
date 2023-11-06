using System;
using System.Text;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Salesforce.Common.Models.Json;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Extensions;
using Athi.Whippet.Salesforce.Extensions;

namespace Athi.Whippet.Salesforce.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="SalesforceCampaign"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class SalesforceCampaignRepository : SalesforceRepository<SalesforceCampaign>, ISalesforceCampaignRepository
    {
        private ISalesforceCampaign _campaign;

        /// <summary>
        /// Gets or sets an internal <see cref="ISalesforceCampaign"/> object used for generating mappings.
        /// </summary>
        private ISalesforceCampaign Campaign
        {
            get
            {
                if (_campaign == null)
                {
                    _campaign = new SalesforceCampaign();
                }

                return _campaign;
            }
            set
            {
                _campaign = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceCampaignRepository"/> class with the specified <see cref="ISalesforceClient"/> object.
        /// </summary>
        /// <param name="client"><see cref="ISalesforceClient"/> object to initialize with.</param>
        /// <param name="campaign"><see cref="ISalesforceCampaign"/> object used for generating object maps.</param>
        /// <exception cref="ArgumentNullException" />
        public SalesforceCampaignRepository(ISalesforceClient client, ISalesforceCampaign campaign = null)
            : base(client)
        {
            Campaign = campaign;
        }

        /// <summary>
        /// Retrieves the <see cref="SalesforceCampaign"/> with the specified object ID from the Salesforce instance.
        /// </summary>
        /// <param name="key">Salesforce object ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<WhippetResultContainer<SalesforceCampaign>> GetAsync(SalesforceReference key, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<SalesforceCampaign> result = null;
            WhippetDataRowImportMap map = Campaign.CreateImportMap();

            List<SalesforceCampaign> campaigns = new List<SalesforceCampaign>();

            SalesforceCampaign campaign = null;

            QueryResult<dynamic> results = null;

            string statement = GenerateSelect() + GenerateWhereEquals(nameof(Campaign.ObjectID), key);

            try
            {
                results = await Client.QueryAsync<dynamic>(statement);

                if (results != null)
                {
                    foreach (dynamic acct in results.Records)
                    {
                        campaign = new SalesforceCampaign();

                        campaign.ObjectID = ((JToken)(acct.Id)).Value<string>();
                        campaign.ImportJsonObject(acct, AvailableProperties);

                        campaigns.Add(campaign);
                    }
                }

                result = new WhippetResultContainer<SalesforceCampaign>(WhippetResult.Success, campaigns.FirstOrDefault());
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<SalesforceCampaign>(new WhippetResult(e), null);
            }

            return result;
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceCampaign"/> objects in the Salesforce instance.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<WhippetResultContainer<IEnumerable<SalesforceCampaign>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<IEnumerable<SalesforceCampaign>> result = null;
            WhippetDataRowImportMap map = Campaign.CreateImportMap();

            List<SalesforceCampaign> campaigns = new List<SalesforceCampaign>();

            SalesforceCampaign campaign = null;

            QueryResult<dynamic> results = null;

            string statement = GenerateSelect();

            try
            {
                results = await Client.QueryAsync<dynamic>(statement);

                if (results != null)
                {
                    foreach (dynamic acct in results.Records)
                    {
                        campaign = new SalesforceCampaign();

                        campaign.ObjectID = ((JToken)(acct.Id)).Value<string>();
                        campaign.ImportJsonObject(acct, AvailableProperties);

                        campaigns.Add(campaign);
                    }
                }

                result = new WhippetResultContainer<IEnumerable<SalesforceCampaign>>(WhippetResult.Success, campaigns);
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<SalesforceCampaign>>(new WhippetResult(e), null);
            }

            return result;
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceCampaign"/> objects with the specified campaign name.
        /// </summary>
        /// <param name="campaignName">Campaign name of the <see cref="SalesforceCampaign"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public WhippetResultContainer<IEnumerable<SalesforceCampaign>> GetByName(string campaignName)
        {
            if (String.IsNullOrWhiteSpace(campaignName))
            {
                throw new ArgumentNullException(nameof(campaignName));
            }
            else
            {
                return Task.Run(() => GetByNameAsync(campaignName)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceCampaign"/> objects with the specified campaign name.
        /// </summary>
        /// <param name="campaignName">Campaign name of the <see cref="SalesforceCampaign"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public async Task<WhippetResultContainer<IEnumerable<SalesforceCampaign>>> GetByNameAsync(string campaignName, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(campaignName))
            {
                throw new ArgumentNullException(nameof(campaignName));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesforceCampaign>> result = null;
                WhippetDataRowImportMap map = Campaign.CreateImportMap();

                List<SalesforceCampaign> campaigns = new List<SalesforceCampaign>();

                SalesforceCampaign campaign = null;

                QueryResult<dynamic> results = null;

                string statement = GenerateSelect() + GenerateWhereEquals(nameof(Campaign.Name), campaignName);

                try
                {
                    results = await Client.QueryAsync<dynamic>(statement);

                    if (results != null)
                    {
                        foreach (dynamic acct in results.Records)
                        {
                            campaign = new SalesforceCampaign();

                            campaign.ObjectID = ((JToken)(acct.Id)).Value<string>();
                            campaign.ImportJsonObject(acct, AvailableProperties);

                            campaigns.Add(campaign);
                        }
                    }

                    result = new WhippetResultContainer<IEnumerable<SalesforceCampaign>>(WhippetResult.Success, campaigns);
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<SalesforceCampaign>>(new WhippetResult(e), null);
                }

                return result;
            }
        }

        /// <summary>
        /// Creates a new <see cref="SalesforceCampaign"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforceCampaign"/> object to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> CreateAsync(SalesforceCampaign item, CancellationToken? cancellationToken = null)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;
                SuccessResponse response = null;

                dynamic accontViewModel = new ExpandoObject();

                try
                {
                    response = await Client.CreateAsync(((ISalesforceCampaign)(item)).ExternalTableName, CreateDynamicViewModel(item));

                    if (response.Success)
                    {
                        item.ObjectID = response.Id;
                    }
                    else
                    {
                        result = new WhippetResult(WhippetResultSeverity.Failure, resultObject: response.Errors);
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResult(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Updates an existing <see cref="SalesforceCampaign"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforceCampaign"/> object to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> UpdateAsync(SalesforceCampaign item, CancellationToken? cancellationToken = null)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;
                SuccessResponse response = null;

                dynamic accontViewModel = new ExpandoObject();

                try
                {
                    response = await Client.UpdateAsync(((ISalesforceCampaign)(item)).ExternalTableName, item.ObjectID.GetValueOrDefault(), CreateDynamicViewModel(item));

                    if (response.Success)
                    {
                        item.ObjectID = response.Id;
                    }
                    else
                    {
                        result = new WhippetResult(WhippetResultSeverity.Failure, resultObject: response.Errors);
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResult(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Deletes an existing <see cref="SalesforceCampaign"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforceCampaign"/> object to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> DeleteAsync(SalesforceCampaign item, CancellationToken? cancellationToken = null)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                try
                {
                    await Client.DeleteAsync(((ISalesforceCampaign)(item)).ExternalTableName, item.ObjectID.GetValueOrDefault());
                }
                catch (Exception e)
                {
                    result = new WhippetResult(e);
                }

                return result;
            }
        }
    }
}

