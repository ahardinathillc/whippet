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
    /// Represents a data repository for managing <see cref="SalesforceContact"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class SalesforceContactRepository : SalesforceRepository<SalesforceContact>, ISalesforceContactRepository
    {
        private ISalesforceContact _contact;

        /// <summary>
        /// Gets or sets an internal <see cref="ISalesforceContact"/> object used for generating mappings.
        /// </summary>
        private ISalesforceContact Contact
        {
            get
            {
                if (_contact == null)
                {
                    _contact = new SalesforceContact();
                }

                return _contact;
            }
            set
            {
                _contact = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceContactRepository"/> class with the specified <see cref="ISalesforceClient"/> object.
        /// </summary>
        /// <param name="client"><see cref="ISalesforceClient"/> object to initialize with.</param>
        /// <param name="contact"><see cref="ISalesforceContact"/> object used for generating object maps.</param>
        /// <exception cref="ArgumentNullException" />
        public SalesforceContactRepository(ISalesforceClient client, ISalesforceContact contact = null)
            : base(client)
        {
            Contact = contact;
        }

        /// <summary>
        /// Retrieves the <see cref="SalesforceContact"/> with the specified object ID from the Salesforce instance.
        /// </summary>
        /// <param name="key">Salesforce object ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<WhippetResultContainer<SalesforceContact>> GetAsync(SalesforceReference key, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<SalesforceContact> result = null;
            WhippetDataRowImportMap map = Contact.CreateImportMap();

            List<SalesforceContact> contacts = new List<SalesforceContact>();

            SalesforceContact contact = null;

            QueryResult<dynamic> results = null;

            string statement = GenerateSelect() + GenerateWhereEquals(nameof(Contact.ObjectID), key);

            try
            {
                results = await Client.QueryAsync<dynamic>(statement);

                if (results != null)
                {
                    foreach (dynamic acct in results.Records)
                    {
                        contact = new SalesforceContact();

                        contact.ObjectID = ((JToken)(acct.Id)).Value<string>();
                        contact.ImportJsonObject(acct, AvailableProperties);

                        contacts.Add(contact);
                    }
                }

                result = new WhippetResultContainer<SalesforceContact>(WhippetResult.Success, contacts.FirstOrDefault());
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<SalesforceContact>(new WhippetResult(e), null);
            }

            return result;
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceContact"/> objects in the Salesforce instance.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<WhippetResultContainer<IEnumerable<SalesforceContact>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<IEnumerable<SalesforceContact>> result = null;
            WhippetDataRowImportMap map = Contact.CreateImportMap();

            List<SalesforceContact> contacts = new List<SalesforceContact>();

            SalesforceContact contact = null;

            QueryResult<dynamic> results = null;

            string statement = GenerateSelect();

            try
            {
                results = await Client.QueryAsync<dynamic>(statement);

                if (results != null)
                {
                    foreach (dynamic acct in results.Records)
                    {
                        contact = new SalesforceContact();

                        contact.ObjectID = ((JToken)(acct.Id)).Value<string>();
                        contact.ImportJsonObject(acct, AvailableProperties);

                        contacts.Add(contact);
                    }
                }

                result = new WhippetResultContainer<IEnumerable<SalesforceContact>>(WhippetResult.Success, contacts);
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<SalesforceContact>>(new WhippetResult(e), null);
            }

            return result;
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceContact"/> objects for the specified <see cref="ISalesforceAccount"/>.
        /// </summary>
        /// <param name="account"><see cref="ISalesforceAccount"/> object to get all <see cref="SalesforceContact"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public WhippetResultContainer<IEnumerable<SalesforceContact>> GetAllForAccount(ISalesforceAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            else
            {
                return Task.Run(() => GetAllForAccountAsync(account)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceContact"/> objects for the specified <see cref="ISalesforceAccount"/>.
        /// </summary>
        /// <param name="account"><see cref="ISalesforceAccount"/> object to get all <see cref="SalesforceContact"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public async Task<WhippetResultContainer<IEnumerable<SalesforceContact>>> GetAllForAccountAsync(ISalesforceAccount account, CancellationToken? cancellationToken = null)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesforceContact>> result = null;
                WhippetDataRowImportMap map = Contact.CreateImportMap();

                List<SalesforceContact> contacts = new List<SalesforceContact>();

                SalesforceContact contact = null;

                QueryResult<dynamic> results = null;

                string statement = GenerateSelect() + GenerateWhereEquals(map[nameof(Contact.AccountID)].Column, account.ObjectID);

                try
                {
                    results = await Client.QueryAsync<dynamic>(statement);

                    if (results != null)
                    {
                        foreach (dynamic acct in results.Records)
                        {
                            contact = new SalesforceContact();

                            contact.ObjectID = ((JToken)(acct.Id)).Value<string>();
                            contact.ImportJsonObject(acct, AvailableProperties);

                            contacts.Add(contact);
                        }
                    }

                    result = new WhippetResultContainer<IEnumerable<SalesforceContact>>(WhippetResult.Success, contacts);
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<SalesforceContact>>(new WhippetResult(e), null);
                }

                return result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceContact"/> objects for the specified <see cref="ISalesforceAccount"/> based on the <see cref="SalesforceContact.LastName"/> value.
        /// </summary>
        /// <param name="account"><see cref="ISalesforceAccount"/> object to get all <see cref="SalesforceContact"/> objects for.</param>
        /// <param name="lastName"><see cref="SalesforceContact.LastName"/> value to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public WhippetResultContainer<IEnumerable<SalesforceContact>> GetByLastName(ISalesforceAccount account, string lastName)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            else if (String.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }
            else
            {
                return Task.Run(() => GetByLastNameAsync(account, lastName)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceContact"/> objects for the specified <see cref="ISalesforceAccount"/> based on the <see cref="SalesforceContact.LastName"/> value.
        /// </summary>
        /// <param name="account"><see cref="ISalesforceAccount"/> object to get all <see cref="SalesforceContact"/> objects for.</param>
        /// <param name="lastName"><see cref="SalesforceContact.LastName"/> value to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public async Task<WhippetResultContainer<IEnumerable<SalesforceContact>>> GetByLastNameAsync(ISalesforceAccount account, string lastName, CancellationToken? cancellationToken = null)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesforceContact>> result = null;
                WhippetDataRowImportMap map = Contact.CreateImportMap();

                List<SalesforceContact> contacts = new List<SalesforceContact>();

                SalesforceContact contact = null;

                QueryResult<dynamic> results = null;

                string statement = GenerateSelect() + GenerateWhereEquals(map[nameof(Contact.AccountID)].Column, account.ObjectID) + GenerateAndEquals(map[nameof(Contact.LastName)].Column, lastName);

                try
                {
                    results = await Client.QueryAsync<dynamic>(statement);

                    if (results != null)
                    {
                        foreach (dynamic acct in results.Records)
                        {
                            contact = new SalesforceContact();

                            contact.ObjectID = ((JToken)(acct.Id)).Value<string>();
                            contact.ImportJsonObject(acct, AvailableProperties);

                            contacts.Add(contact);
                        }
                    }

                    result = new WhippetResultContainer<IEnumerable<SalesforceContact>>(WhippetResult.Success, contacts);
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<SalesforceContact>>(new WhippetResult(e), null);
                }

                return result;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="SalesforceContact"/> object with the specified first and last name for the given <see cref="ISalesforceAccount"/>.
        /// </summary>
        /// <param name="account"><see cref="ISalesforceAccount"/> object.</param>
        /// <param name="firstName">First name.</param>
        /// <param name="lastName">Last name.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public WhippetResultContainer<IEnumerable<SalesforceContact>> GetByName(ISalesforceAccount account, string firstName, string lastName)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            else
            {
                return Task.Run(() => GetByNameAsync(account, firstName, lastName)).Result;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="SalesforceContact"/> object with the specified first and last name for the given <see cref="ISalesforceAccount"/>.
        /// </summary>
        /// <param name="account"><see cref="ISalesforceAccount"/> object.</param>
        /// <param name="firstName">First name.</param>
        /// <param name="lastName">Last name.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public async Task<WhippetResultContainer<IEnumerable<SalesforceContact>>> GetByNameAsync(ISalesforceAccount account, string firstName, string lastName, CancellationToken? cancellationToken = null)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesforceContact>> result = null;
                WhippetDataRowImportMap map = Contact.CreateImportMap();

                List<SalesforceContact> contacts = new List<SalesforceContact>();

                SalesforceContact contact = null;

                QueryResult<dynamic> results = null;

                string statement = GenerateSelect() + GenerateWhereEquals(map[nameof(Contact.AccountID)].Column, account.ObjectID) + GenerateAndEquals(map[nameof(Contact.LastName)].Column, lastName);

                try
                {
                    results = await Client.QueryAsync<dynamic>(statement);

                    if (results != null)
                    {
                        foreach (dynamic acct in results.Records)
                        {
                            contact = new SalesforceContact();

                            contact.ObjectID = ((JToken)(acct.Id)).Value<string>();
                            contact.ImportJsonObject(acct, AvailableProperties);

                            contacts.Add(contact);
                        }
                    }

                    result = new WhippetResultContainer<IEnumerable<SalesforceContact>>(WhippetResult.Success, contacts);
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<SalesforceContact>>(new WhippetResult(e), null);
                }

                return result;
            }

        }

        /// <summary>
        /// Creates a new <see cref="SalesforceContact"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforceContact"/> object to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> CreateAsync(SalesforceContact item, CancellationToken? cancellationToken = null)
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
                    response = await Client.CreateAsync(((ISalesforceContact)(item)).ExternalTableName, CreateDynamicViewModel(item, DefaultIgnoreFields.Append("Name"), new[] { "FirstName", "LastName" }));

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
        /// Updates an existing <see cref="SalesforceContact"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforceContact"/> object to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> UpdateAsync(SalesforceContact item, CancellationToken? cancellationToken = null)
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
                    response = await Client.UpdateAsync(((ISalesforceContact)(item)).ExternalTableName, item.ObjectID.GetValueOrDefault(), CreateDynamicViewModel(item));

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
        /// Deletes an existing <see cref="SalesforceContact"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforceContact"/> object to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> DeleteAsync(SalesforceContact item, CancellationToken? cancellationToken = null)
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
                    await Client.DeleteAsync(((ISalesforceContact)(item)).ExternalTableName, item.ObjectID.GetValueOrDefault());
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

