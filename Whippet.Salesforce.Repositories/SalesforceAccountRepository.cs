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
    /// Represents a data repository for managing <see cref="SalesforceAccount"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class SalesforceAccountRepository : SalesforceRepository<SalesforceAccount>, ISalesforceAccountRepository
    {
        private ISalesforceAccount _account;

        /// <summary>
        /// Gets or sets an internal <see cref="ISalesforceAccount"/> object used for generating mappings.
        /// </summary>
        private ISalesforceAccount Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new SalesforceAccount();
                }

                return _account;
            }
            set
            {
                _account = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceAccountRepository"/> class with the specified <see cref="ISalesforceClient"/> object.
        /// </summary>
        /// <param name="client"><see cref="ISalesforceClient"/> object to initialize with.</param>
        /// <param name="account"><see cref="ISalesforceAccount"/> object used for generating object maps.</param>
        /// <exception cref="ArgumentNullException" />
        public SalesforceAccountRepository(ISalesforceClient client, ISalesforceAccount account = null)
            : base(client)
        {
            Account = account;
        }

        /// <summary>
        /// Retrieves the <see cref="SalesforceAccount"/> with the specified object ID from the Salesforce instance.
        /// </summary>
        /// <param name="key">Salesforce object ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<WhippetResultContainer<SalesforceAccount>> GetAsync(SalesforceReference key, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<SalesforceAccount> result = null;
            WhippetDataRowImportMap map = Account.CreateImportMap();

            List<SalesforceAccount> accounts = new List<SalesforceAccount>();

            SalesforceAccount account = null;

            QueryResult<dynamic> results = null;

            string statement = GenerateSelect() + GenerateWhereEquals(nameof(Account.ObjectID), key);

            try
            {
                results = await Client.QueryAsync<dynamic>(statement);

                if (results != null)
                {
                    foreach (dynamic acct in results.Records)
                    {
                        account = new SalesforceAccount();

                        account.ObjectID = ((JToken)(acct.Id)).Value<string>();
                        account.ImportJsonObject(acct, AvailableProperties);

                        accounts.Add(account);
                    }
                }

                result = new WhippetResultContainer<SalesforceAccount>(WhippetResult.Success, accounts.FirstOrDefault());
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<SalesforceAccount>(new WhippetResult(e), null);
            }

            return result;
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceAccount"/> objects in the Salesforce instance.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<WhippetResultContainer<IEnumerable<SalesforceAccount>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<IEnumerable<SalesforceAccount>> result = null;
            WhippetDataRowImportMap map = Account.CreateImportMap();

            List<SalesforceAccount> accounts = new List<SalesforceAccount>();

            SalesforceAccount account = null;

            QueryResult<dynamic> results = null;

            string statement = GenerateSelect();

            try
            {
                results = await Client.QueryAsync<dynamic>(statement);

                if (results != null)
                {
                    foreach (dynamic acct in results.Records)
                    {
                        account = new SalesforceAccount();

                        account.ObjectID = ((JToken)(acct.Id)).Value<string>();
                        account.ImportJsonObject(acct, AvailableProperties);

                        accounts.Add(account);
                    }
                }

                result = new WhippetResultContainer<IEnumerable<SalesforceAccount>>(WhippetResult.Success, accounts);
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<SalesforceAccount>>(new WhippetResult(e), null);
            }

            return result;
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceAccount"/> objects with the specified account name.
        /// </summary>
        /// <param name="accountName">Account name of the <see cref="SalesforceAccount"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public WhippetResultContainer<IEnumerable<SalesforceAccount>> GetByName(string accountName)
        {
            if (String.IsNullOrWhiteSpace(accountName))
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            else
            {
                return Task.Run(() => GetByNameAsync(accountName)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceAccount"/> objects with the specified account name.
        /// </summary>
        /// <param name="accountName">Account name of the <see cref="SalesforceAccount"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public async Task<WhippetResultContainer<IEnumerable<SalesforceAccount>>> GetByNameAsync(string accountName, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(accountName))
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesforceAccount>> result = null;
                WhippetDataRowImportMap map = Account.CreateImportMap();

                List<SalesforceAccount> accounts = new List<SalesforceAccount>();

                SalesforceAccount account = null;

                QueryResult<dynamic> results = null;

                string statement = GenerateSelect() + GenerateWhereEquals(nameof(Account.Name), accountName);

                try
                {
                    results = await Client.QueryAsync<dynamic>(statement);

                    if (results != null)
                    {
                        foreach (dynamic acct in results.Records)
                        {
                            account = new SalesforceAccount();

                            account.ObjectID = ((JToken)(acct.Id)).Value<string>();
                            account.ImportJsonObject(acct, AvailableProperties);

                            accounts.Add(account);
                        }
                    }

                    result = new WhippetResultContainer<IEnumerable<SalesforceAccount>>(WhippetResult.Success, accounts);
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<SalesforceAccount>>(new WhippetResult(e), null);
                }

                return result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceAccount"/> objects that contain the specified account name or search criteria.
        /// </summary>
        /// <param name="accountName">Account name of the <see cref="SalesforceAccount"/> or search criteria.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public WhippetResultContainer<IEnumerable<SalesforceAccount>> GetLikeName(string accountName)
        {
            if (String.IsNullOrWhiteSpace(accountName))
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            else
            {
                return Task.Run(() => GetLikeNameAsync(accountName)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceAccount"/> objects that contain the specified account name or search criteria.
        /// </summary>
        /// <param name="accountName">Account name of the <see cref="SalesforceAccount"/> or search criteria.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public async Task<WhippetResultContainer<IEnumerable<SalesforceAccount>>> GetLikeNameAsync(string accountName, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(accountName))
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesforceAccount>> result = null;
                WhippetDataRowImportMap map = Account.CreateImportMap();

                List<SalesforceAccount> accounts = new List<SalesforceAccount>();

                SalesforceAccount account = null;

                QueryResult<dynamic> results = null;

                string statement = GenerateSelect() + GenerateLike(nameof(Account.Name), accountName);

                try
                {
                    results = await Client.QueryAsync<dynamic>(statement);

                    if (results != null)
                    {
                        foreach (dynamic acct in results.Records)
                        {
                            account = new SalesforceAccount();

                            account.ObjectID = ((JToken)(acct.Id)).Value<string>();
                            account.ImportJsonObject(acct, AvailableProperties);

                            accounts.Add(account);
                        }
                    }

                    result = new WhippetResultContainer<IEnumerable<SalesforceAccount>>(WhippetResult.Success, accounts);
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<SalesforceAccount>>(new WhippetResult(e), null);
                }

                return result;
            }
        }

        /// <summary>
        /// Creates a new <see cref="SalesforceAccount"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforceAccount"/> object to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> CreateAsync(SalesforceAccount item, CancellationToken? cancellationToken = null)
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
                    response = await Client.CreateAsync(((ISalesforceAccount)(item)).ExternalTableName, CreateDynamicViewModel(item, DefaultIgnoreFields));

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
        /// Updates an existing <see cref="SalesforceAccount"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforceAccount"/> object to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> UpdateAsync(SalesforceAccount item, CancellationToken? cancellationToken = null)
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
                    response = await Client.UpdateAsync(((ISalesforceAccount)(item)).ExternalTableName, item.ObjectID.GetValueOrDefault(), CreateDynamicViewModel(item));

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
        /// Deletes an existing <see cref="SalesforceAccount"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforceAccount"/> object to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> DeleteAsync(SalesforceAccount item, CancellationToken? cancellationToken = null)
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
                    await Client.DeleteAsync(((ISalesforceAccount)(item)).ExternalTableName, item.ObjectID.GetValueOrDefault());
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

