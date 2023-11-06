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
    /// Represents a data repository for managing <see cref="SalesforceLead"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class SalesforceLeadRepository : SalesforceRepository<SalesforceLead>, ISalesforceLeadRepository
    {
        private ISalesforceLead _lead;

        /// <summary>
        /// Gets or sets an internal <see cref="ISalesforceLead"/> object used for generating mappings.
        /// </summary>
        private ISalesforceLead Lead
        {
            get
            {
                if (_lead == null)
                {
                    _lead = new SalesforceLead();
                }

                return _lead;
            }
            set
            {
                _lead = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceLeadRepository"/> class with the specified <see cref="ISalesforceClient"/> object.
        /// </summary>
        /// <param name="client"><see cref="ISalesforceClient"/> object to initialize with.</param>
        /// <param name="lead"><see cref="ISalesforceLead"/> object used for generating object maps.</param>
        /// <exception cref="ArgumentNullException" />
        public SalesforceLeadRepository(ISalesforceClient client, ISalesforceLead lead = null)
            : base(client)
        {
            Lead = lead;
        }

        /// <summary>
        /// Retrieves the <see cref="SalesforceLead"/> with the specified object ID from the Salesforce instance.
        /// </summary>
        /// <param name="key">Salesforce object ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<WhippetResultContainer<SalesforceLead>> GetAsync(SalesforceReference key, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<SalesforceLead> result = null;
            WhippetDataRowImportMap map = Lead.CreateImportMap();

            List<SalesforceLead> leads = new List<SalesforceLead>();

            SalesforceLead lead = null;

            QueryResult<dynamic> results = null;

            string statement = GenerateSelect() + GenerateWhereEquals(nameof(Lead.ObjectID), key);

            try
            {
                results = await Client.QueryAsync<dynamic>(statement);

                if (results != null)
                {
                    foreach (dynamic acct in results.Records)
                    {
                        lead = new SalesforceLead();

                        lead.ObjectID = ((JToken)(acct.Id)).Value<string>();
                        lead.ImportJsonObject(acct, AvailableProperties);

                        leads.Add(lead);
                    }
                }

                result = new WhippetResultContainer<SalesforceLead>(WhippetResult.Success, leads.FirstOrDefault());
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<SalesforceLead>(new WhippetResult(e), null);
            }

            return result;
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceLead"/> objects in the Salesforce instance.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<WhippetResultContainer<IEnumerable<SalesforceLead>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<IEnumerable<SalesforceLead>> result = null;
            WhippetDataRowImportMap map = Lead.CreateImportMap();

            List<SalesforceLead> leads = new List<SalesforceLead>();

            SalesforceLead lead = null;

            QueryResult<dynamic> results = null;

            string statement = GenerateSelect();

            try
            {
                results = await Client.QueryAsync<dynamic>(statement);

                if (results != null)
                {
                    foreach (dynamic acct in results.Records)
                    {
                        lead = new SalesforceLead();

                        lead.ObjectID = ((JToken)(acct.Id)).Value<string>();
                        lead.ImportJsonObject(acct, AvailableProperties);

                        leads.Add(lead);
                    }
                }

                result = new WhippetResultContainer<IEnumerable<SalesforceLead>>(WhippetResult.Success, leads);
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<SalesforceLead>>(new WhippetResult(e), null);
            }

            return result;
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceLead"/> objects based on the <see cref="SalesforceLead.LastName"/> value.
        /// </summary>
        /// <param name="lastName"><see cref="SalesforceLead.LastName"/> value to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public WhippetResultContainer<IEnumerable<SalesforceLead>> GetByLastName(string lastName)
        {
            if (String.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }
            else
            {
                return Task.Run(() => GetByLastNameAsync(lastName)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceLead"/> objects based on the <see cref="SalesforceLead.LastName"/> value.
        /// </summary>
        /// <param name="lastName"><see cref="SalesforceLead.LastName"/> value to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public async Task<WhippetResultContainer<IEnumerable<SalesforceLead>>> GetByLastNameAsync(string lastName, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }
            else
            {
                return await GetByNameAsync(null, lastName, cancellationToken);
            }
        }

        /// <summary>
        /// Retrieves the <see cref="SalesforceLead"/> object with the specified first and last name.
        /// </summary>
        /// <param name="firstName">First name.</param>
        /// <param name="lastName">Last name.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public WhippetResultContainer<IEnumerable<SalesforceLead>> GetByName(string firstName, string lastName)
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
                return Task.Run(() => GetByNameAsync(firstName, lastName)).Result;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="SalesforceLead"/> object with the specified first and last name.
        /// </summary>
        /// <param name="firstName">First name.</param>
        /// <param name="lastName">Last name.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public async Task<WhippetResultContainer<IEnumerable<SalesforceLead>>> GetByNameAsync(string firstName, string lastName, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(firstName) && String.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesforceLead>> result = null;
                WhippetDataRowImportMap map = Lead.CreateImportMap();

                List<SalesforceLead> leads = new List<SalesforceLead>();

                SalesforceLead lead = null;

                QueryResult<dynamic> results = null;

                string statement = GenerateSelect() + GenerateWhereEquals(map[nameof(Lead.LastName)].Column, lastName) + GenerateAndEquals(map[nameof(Lead.FirstName)].Column, firstName);

                try
                {
                    results = await Client.QueryAsync<dynamic>(statement);

                    if (results != null)
                    {
                        foreach (dynamic sfl in results.Records)
                        {
                            lead = new SalesforceLead();

                            lead.ObjectID = ((JToken)(sfl.Id)).Value<string>();
                            lead.ImportJsonObject(sfl, AvailableProperties);

                            leads.Add(lead);
                        }
                    }

                    result = new WhippetResultContainer<IEnumerable<SalesforceLead>>(WhippetResult.Success, leads);
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<SalesforceLead>>(new WhippetResult(e), null);
                }

                return result;
            }
        }

        /// <summary>
        /// Creates a new <see cref="SalesforceLead"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforceLead"/> object to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> CreateAsync(SalesforceLead item, CancellationToken? cancellationToken = null)
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
                    response = await Client.CreateAsync(((ISalesforceLead)(item)).ExternalTableName, CreateDynamicViewModel(item, DefaultIgnoreFields.Append("Name"), new[] { "FirstName", "LastName" }));

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
        /// Updates an existing <see cref="SalesforceLead"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforceLead"/> object to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> UpdateAsync(SalesforceLead item, CancellationToken? cancellationToken = null)
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
                    response = await Client.UpdateAsync(((ISalesforceLead)(item)).ExternalTableName, item.ObjectID.GetValueOrDefault(), CreateDynamicViewModel(item));

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
        /// Deletes an existing <see cref="SalesforceLead"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforceLead"/> object to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> DeleteAsync(SalesforceLead item, CancellationToken? cancellationToken = null)
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
                    await Client.DeleteAsync(((ISalesforceLead)(item)).ExternalTableName, item.ObjectID.GetValueOrDefault());
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

