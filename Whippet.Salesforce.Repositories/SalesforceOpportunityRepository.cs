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
    /// Represents a data repository for managing <see cref="SalesforceOpportunity"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class SalesforceOpportunityRepository : SalesforceRepository<SalesforceOpportunity>, ISalesforceOpportunityRepository
    {
        private ISalesforceOpportunity _opportunity;

        /// <summary>
        /// Gets or sets an internal <see cref="ISalesforceOpportunity"/> object used for generating mappings.
        /// </summary>
        private ISalesforceOpportunity Opportunity
        {
            get
            {
                if (_opportunity == null)
                {
                    _opportunity = new SalesforceOpportunity();
                }

                return _opportunity;
            }
            set
            {
                _opportunity = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceOpportunityRepository"/> class with the specified <see cref="ISalesforceClient"/> object.
        /// </summary>
        /// <param name="client"><see cref="ISalesforceClient"/> object to initialize with.</param>
        /// <param name="opportunity"><see cref="ISalesforceOpportunity"/> object used for generating object maps.</param>
        /// <exception cref="ArgumentNullException" />
        public SalesforceOpportunityRepository(ISalesforceClient client, ISalesforceOpportunity opportunity = null)
            : base(client)
        {
            Opportunity = opportunity;
        }

        /// <summary>
        /// Retrieves the <see cref="SalesforceOpportunity"/> with the specified object ID from the Salesforce instance.
        /// </summary>
        /// <param name="key">Salesforce object ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<WhippetResultContainer<SalesforceOpportunity>> GetAsync(SalesforceReference key, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<SalesforceOpportunity> result = null;
            WhippetDataRowImportMap map = Opportunity.CreateImportMap();

            List<SalesforceOpportunity> opportunitys = new List<SalesforceOpportunity>();

            SalesforceOpportunity opportunity = null;

            QueryResult<dynamic> results = null;

            string statement = GenerateSelect() + GenerateWhereEquals(nameof(Opportunity.ObjectID), key);

            try
            {
                results = await Client.QueryAsync<dynamic>(statement);

                if (results != null)
                {
                    foreach (dynamic acct in results.Records)
                    {
                        opportunity = new SalesforceOpportunity();

                        opportunity.ObjectID = ((JToken)(acct.Id)).Value<string>();
                        opportunity.ImportJsonObject(acct, AvailableProperties);

                        opportunitys.Add(opportunity);
                    }
                }

                result = new WhippetResultContainer<SalesforceOpportunity>(WhippetResult.Success, opportunitys.FirstOrDefault());
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<SalesforceOpportunity>(new WhippetResult(e), null);
            }

            return result;
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceOpportunity"/> objects in the Salesforce instance.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<WhippetResultContainer<IEnumerable<SalesforceOpportunity>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<IEnumerable<SalesforceOpportunity>> result = null;
            WhippetDataRowImportMap map = Opportunity.CreateImportMap();

            List<SalesforceOpportunity> opportunitys = new List<SalesforceOpportunity>();

            SalesforceOpportunity opportunity = null;

            QueryResult<dynamic> results = null;

            string statement = GenerateSelect();

            try
            {
                results = await Client.QueryAsync<dynamic>(statement);

                if (results != null)
                {
                    foreach (dynamic acct in results.Records)
                    {
                        opportunity = new SalesforceOpportunity();

                        opportunity.ObjectID = ((JToken)(acct.Id)).Value<string>();
                        opportunity.ImportJsonObject(acct, AvailableProperties);

                        opportunitys.Add(opportunity);
                    }
                }

                result = new WhippetResultContainer<IEnumerable<SalesforceOpportunity>>(WhippetResult.Success, opportunitys);
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<SalesforceOpportunity>>(new WhippetResult(e), null);
            }

            return result;
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceOpportunity"/> objects with the specified opportunity name.
        /// </summary>
        /// <param name="opportunityName">Opportunity name of the <see cref="SalesforceOpportunity"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public WhippetResultContainer<IEnumerable<SalesforceOpportunity>> GetByName(string opportunityName)
        {
            if (String.IsNullOrWhiteSpace(opportunityName))
            {
                throw new ArgumentNullException(nameof(opportunityName));
            }
            else
            {
                return Task.Run(() => GetByNameAsync(opportunityName)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceOpportunity"/> objects with the specified opportunity name.
        /// </summary>
        /// <param name="opportunityName">Opportunity name of the <see cref="SalesforceOpportunity"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public async Task<WhippetResultContainer<IEnumerable<SalesforceOpportunity>>> GetByNameAsync(string opportunityName, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(opportunityName))
            {
                throw new ArgumentNullException(nameof(opportunityName));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesforceOpportunity>> result = null;
                WhippetDataRowImportMap map = Opportunity.CreateImportMap();

                List<SalesforceOpportunity> opportunitys = new List<SalesforceOpportunity>();

                SalesforceOpportunity opportunity = null;

                QueryResult<dynamic> results = null;

                string statement = GenerateSelect() + GenerateWhereEquals(nameof(Opportunity.Name), opportunityName);

                try
                {
                    results = await Client.QueryAsync<dynamic>(statement);

                    if (results != null)
                    {
                        foreach (dynamic acct in results.Records)
                        {
                            opportunity = new SalesforceOpportunity();

                            opportunity.ObjectID = ((JToken)(acct.Id)).Value<string>();
                            opportunity.ImportJsonObject(acct, AvailableProperties);

                            opportunitys.Add(opportunity);
                        }
                    }

                    result = new WhippetResultContainer<IEnumerable<SalesforceOpportunity>>(WhippetResult.Success, opportunitys);
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<SalesforceOpportunity>>(new WhippetResult(e), null);
                }

                return result;
            }
        }

        /// <summary>
        /// Creates a new <see cref="SalesforceOpportunity"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforceOpportunity"/> object to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> CreateAsync(SalesforceOpportunity item, CancellationToken? cancellationToken = null)
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
                    response = await Client.CreateAsync(((ISalesforceOpportunity)(item)).ExternalTableName,
                        CreateDynamicViewModel(item,
                            DefaultIgnoreFields
                                .Append("HasOpportunityLineItem")
                                .Append("IsWon")
                                .Append("IsClosed")
                                .Append("Fiscal")));

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
        /// Updates an existing <see cref="SalesforceOpportunity"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforceOpportunity"/> object to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> UpdateAsync(SalesforceOpportunity item, CancellationToken? cancellationToken = null)
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
                    response = await Client.UpdateAsync(((ISalesforceOpportunity)(item)).ExternalTableName, item.ObjectID.GetValueOrDefault(),
                        CreateDynamicViewModel(item,
                            DefaultIgnoreFields
                                .Append("HasOpportunityLineItem")
                                .Append("IsWon")
                                .Append("IsClosed")
                                .Append("Fiscal")));

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
        /// Deletes an existing <see cref="SalesforceOpportunity"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforceOpportunity"/> object to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> DeleteAsync(SalesforceOpportunity item, CancellationToken? cancellationToken = null)
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
                    await Client.DeleteAsync(((ISalesforceOpportunity)(item)).ExternalTableName, item.ObjectID.GetValueOrDefault());
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

