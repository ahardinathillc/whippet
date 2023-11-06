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
    /// Represents a data repository for managing <see cref="SalesforcePriceBookEntry"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class SalesforcePriceBookEntryRepository : SalesforceRepository<SalesforcePriceBookEntry>, ISalesforcePriceBookEntryRepository
    {
        private ISalesforcePriceBookEntry _entry;

        /// <summary>
        /// Gets or sets an internal <see cref="ISalesforcePriceBookEntry"/> object used for generating mappings.
        /// </summary>
        private ISalesforcePriceBookEntry PriceBookEntry
        {
            get
            {
                if (_entry == null)
                {
                    _entry = new SalesforcePriceBookEntry();
                }

                return _entry;
            }
            set
            {
                _entry = value;
            }
        }

        /// <summary>
        /// Gets the default fields that are ignored in CREATE statements. This property is read-only.
        /// </summary>
        protected override IEnumerable<string> DefaultIgnoreFields
        {
            get
            {
                WhippetDataRowImportMap map = PriceBookEntry.CreateImportMap();

                return base.DefaultIgnoreFields.Concat(new[]
                {
                    map[nameof(PriceBookEntry.ObjectID)].Column,
                    map[nameof(PriceBookEntry.Name)].Column,
                    map[nameof(PriceBookEntry.ProductCode)].Column
                });
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforcePriceBookEntryRepository"/> class with the specified <see cref="ISalesforceClient"/> object.
        /// </summary>
        /// <param name="client"><see cref="ISalesforceClient"/> object to initialize with.</param>
        /// <param name="entry"><see cref="ISalesforcePriceBookEntry"/> object used for generating object maps.</param>
        /// <exception cref="ArgumentNullException" />
        public SalesforcePriceBookEntryRepository(ISalesforceClient client, ISalesforcePriceBookEntry entry = null)
            : base(client)
        {
            PriceBookEntry = entry;
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforcePriceBookEntry"/> objects with the specified <see cref="ISalesforcePriceBook"/> ID.
        /// </summary>
        /// <param name="priceBookId"><see cref="ISalesforcePriceBook"/> ID.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public WhippetResultContainer<IEnumerable<SalesforcePriceBookEntry>> GetForPriceBook(SalesforceReference priceBookId)
        {
            return Task.Run(() => GetForPriceBookAsync(priceBookId)).Result;
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforcePriceBookEntry"/> objects with the specified <see cref="ISalesforcePriceBook"/> ID.
        /// </summary>
        /// <param name="priceBookId"><see cref="ISalesforcePriceBook"/> ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public async Task<WhippetResultContainer<IEnumerable<SalesforcePriceBookEntry>>> GetForPriceBookAsync(SalesforceReference priceBookId, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<IEnumerable<SalesforcePriceBookEntry>> result = null;
            WhippetDataRowImportMap map = PriceBookEntry.CreateImportMap();

            List<SalesforcePriceBookEntry> entries = new List<SalesforcePriceBookEntry>();

            SalesforcePriceBookEntry entry = null;

            QueryResult<dynamic> results = null;

            string statement = GenerateSelect() + GenerateWhereEquals(map[nameof(SalesforcePriceBookEntry.PriceBookID)].Column, priceBookId);

            try
            {
                results = await Client.QueryAsync<dynamic>(statement);

                if (results != null)
                {
                    foreach (dynamic bookEntry in results.Records)
                    {
                        entry = new SalesforcePriceBookEntry();

                        ((ISalesforceObject)(entry)).ObjectID = ((JToken)(bookEntry.Id)).Value<string>();
                        entry.ImportJsonObject(bookEntry, AvailableProperties);

                        entries.Add(entry);
                    }
                }

                result = new WhippetResultContainer<IEnumerable<SalesforcePriceBookEntry>>(WhippetResult.Success, entries);
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<SalesforcePriceBookEntry>>(new WhippetResult(e), null);
            }

            return result;
        }

        /// <summary>
        /// Retrieves the <see cref="SalesforcePriceBookEntry"/> with the specified object ID from the Salesforce instance.
        /// </summary>
        /// <param name="key">Salesforce composite ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="MissingPrimaryKeyException" />
        public override async Task<WhippetResultContainer<SalesforcePriceBookEntry>> GetAsync(SalesforceReference key, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<SalesforcePriceBookEntry> result = null;
            WhippetDataRowImportMap map = PriceBookEntry.CreateImportMap();

            List<SalesforcePriceBookEntry> entries = new List<SalesforcePriceBookEntry>();

            SalesforcePriceBookEntry entry = null;

            QueryResult<dynamic> results = null;

            StringBuilder whereClause = new StringBuilder();

            string statement = GenerateSelect();

            bool generatedFirstWhere = false;

            if (((ISalesforceCompositeReference)(key)).CompositeValue != null && ((ISalesforceCompositeReference)(key)).CompositeValue.Any())
            {
                foreach (KeyValuePair<string, SalesforceReference> compositeEntry in ((ISalesforceCompositeReference)(key)).CompositeValue)
                {
                    whereClause.Append(generatedFirstWhere ? GenerateAndEquals(compositeEntry.Key, compositeEntry.Value) : GenerateWhereEquals(compositeEntry.Key, compositeEntry.Value));
                    generatedFirstWhere = true;
                }
            }
            else
            {
                throw new MissingPrimaryKeyException();
            }
                //SalesforceReference
            try
            {
                results = await Client.QueryAsync<dynamic>(statement + whereClause.ToString());

                if (results != null)
                {
                    foreach (dynamic bookEntry in results.Records)
                    {
                        entry = new SalesforcePriceBookEntry();

                        //entry.ObjectID = ((JToken)(bookEntry.Id)).Value<string>();
                        entry.ImportJsonObject(bookEntry, AvailableProperties);

                        entries.Add(entry);
                    }
                }

                result = new WhippetResultContainer<SalesforcePriceBookEntry>(WhippetResult.Success, entries.FirstOrDefault());
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<SalesforcePriceBookEntry>(new WhippetResult(e), null);
            }

            return result;
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforcePriceBookEntry"/> objects in the Salesforce instance.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<WhippetResultContainer<IEnumerable<SalesforcePriceBookEntry>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<IEnumerable<SalesforcePriceBookEntry>> result = null;
            WhippetDataRowImportMap map = PriceBookEntry.CreateImportMap();

            List<SalesforcePriceBookEntry> entries = new List<SalesforcePriceBookEntry>();

            SalesforcePriceBookEntry entry = null;

            QueryResult<dynamic> results = null;

            string statement = GenerateSelect();

            try
            {
                results = await Client.QueryAsync<dynamic>(statement);

                if (results != null)
                {
                    foreach (dynamic bookEntry in results.Records)
                    {
                        entry = new SalesforcePriceBookEntry();

                        ((ISalesforceObject)(entry)).ObjectID = ((JToken)(bookEntry.Id)).Value<string>();
                        entry.ImportJsonObject(bookEntry, AvailableProperties);

                        entries.Add(entry);
                    }
                }

                result = new WhippetResultContainer<IEnumerable<SalesforcePriceBookEntry>>(WhippetResult.Success, entries);
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<SalesforcePriceBookEntry>>(new WhippetResult(e), null);
            }

            return result;
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforcePriceBookEntry"/> objects with the specified entry name.
        /// </summary>
        /// <param name="entryName">PriceBookEntry name of the <see cref="SalesforcePriceBookEntry"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public WhippetResultContainer<IEnumerable<SalesforcePriceBookEntry>> GetByName(string entryName)
        {
            if (String.IsNullOrWhiteSpace(entryName))
            {
                throw new ArgumentNullException(nameof(entryName));
            }
            else
            {
                return Task.Run(() => GetByNameAsync(entryName)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforcePriceBookEntry"/> objects with the specified entry name.
        /// </summary>
        /// <param name="entryName">PriceBookEntry name of the <see cref="SalesforcePriceBookEntry"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public async Task<WhippetResultContainer<IEnumerable<SalesforcePriceBookEntry>>> GetByNameAsync(string entryName, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(entryName))
            {
                throw new ArgumentNullException(nameof(entryName));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesforcePriceBookEntry>> result = null;
                WhippetDataRowImportMap map = PriceBookEntry.CreateImportMap();

                List<SalesforcePriceBookEntry> entries = new List<SalesforcePriceBookEntry>();

                SalesforcePriceBookEntry entry = null;

                QueryResult<dynamic> results = null;

                string statement = GenerateSelect() + GenerateWhereEquals(nameof(PriceBookEntry.Name), entryName);

                try
                {
                    results = await Client.QueryAsync<dynamic>(statement);

                    if (results != null)
                    {
                        foreach (dynamic bookEntry in results.Records)
                        {
                            entry = new SalesforcePriceBookEntry();

                            ((ISalesforceObject)(entry)).ObjectID = ((JToken)(bookEntry.Id)).Value<string>();
                            entry.ImportJsonObject(bookEntry, AvailableProperties);

                            entries.Add(entry);
                        }
                    }

                    result = new WhippetResultContainer<IEnumerable<SalesforcePriceBookEntry>>(WhippetResult.Success, entries);
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<SalesforcePriceBookEntry>>(new WhippetResult(e), null);
                }

                return result;
            }
        }

        /// <summary>
        /// Creates a new <see cref="SalesforcePriceBookEntry"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforcePriceBookEntry"/> object to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> CreateAsync(SalesforcePriceBookEntry item, CancellationToken? cancellationToken = null)
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
                    response = await Client.CreateAsync(((ISalesforcePriceBookEntry)(item)).ExternalTableName, CreateDynamicViewModel(item, DefaultIgnoreFields));

                    if (response.Success)
                    {
                        ((ISalesforceObject)(item)).ObjectID = response.Id;
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
        /// Updates an existing <see cref="SalesforcePriceBookEntry"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforcePriceBookEntry"/> object to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> UpdateAsync(SalesforcePriceBookEntry item, CancellationToken? cancellationToken = null)
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

                WhippetDataRowImportMap map = item.CreateImportMap();

                try
                {
                    // updates to price book entries require deleting the existing entry and creating a new one

                    response = await Client.UpdateAsync(((ISalesforcePriceBookEntry)(item)).ExternalTableName, item.ObjectID.GetValueOrDefault(), CreateDynamicViewModel(item, DefaultIgnoreFields.Concat(new[]
                    {
                        map[nameof(PriceBookEntry.ProductID)].Column,
                        map[nameof(PriceBookEntry.PriceBookID)].Column
                    })));

                    if (!response.Success)
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
        /// Deletes an existing <see cref="SalesforcePriceBookEntry"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforcePriceBookEntry"/> object to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> DeleteAsync(SalesforcePriceBookEntry item, CancellationToken? cancellationToken = null)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;
                WhippetDataRowImportMap map = item.CreateImportMap();

                try
                {
                    await Client.DeleteAsync(((ISalesforcePriceBookEntry)(item)).ExternalTableName, ((ISalesforceObject)(item)).ObjectID.GetValueOrDefault());
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

