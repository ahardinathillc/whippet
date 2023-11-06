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
    /// Represents a data repository for managing <see cref="SalesforcePriceBook"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class SalesforcePriceBookRepository : SalesforceRepository<SalesforcePriceBook>, ISalesforcePriceBookRepository
    {
        private ISalesforcePriceBook _priceBook;

        /// <summary>
        /// Gets or sets an internal <see cref="ISalesforcePriceBook"/> object used for generating mappings.
        /// </summary>
        private ISalesforcePriceBook PriceBook
        {
            get
            {
                if (_priceBook == null)
                {
                    _priceBook = new SalesforcePriceBook();
                }

                return _priceBook;
            }
            set
            {
                _priceBook = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforcePriceBookRepository"/> class with the specified <see cref="ISalesforceClient"/> object.
        /// </summary>
        /// <param name="client"><see cref="ISalesforceClient"/> object to initialize with.</param>
        /// <param name="priceBook"><see cref="ISalesforcePriceBook"/> object used for generating object maps.</param>
        /// <exception cref="ArgumentNullException" />
        public SalesforcePriceBookRepository(ISalesforceClient client, ISalesforcePriceBook priceBook = null)
            : base(client)
        {
            PriceBook = priceBook;
        }

        /// <summary>
        /// Retrieves the <see cref="SalesforcePriceBook"/> with the specified object ID from the Salesforce instance.
        /// </summary>
        /// <param name="key">Salesforce object ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<WhippetResultContainer<SalesforcePriceBook>> GetAsync(SalesforceReference key, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<SalesforcePriceBook> result = null;
            WhippetDataRowImportMap map = PriceBook.CreateImportMap();

            List<SalesforcePriceBook> priceBooks = new List<SalesforcePriceBook>();

            SalesforcePriceBook priceBook = null;

            QueryResult<dynamic> results = null;

            string statement = GenerateSelect() + GenerateWhereEquals(nameof(PriceBook.ObjectID), key);

            try
            {
                results = await Client.QueryAsync<dynamic>(statement);

                if (results != null)
                {
                    foreach (dynamic book in results.Records)
                    {
                        priceBook = new SalesforcePriceBook();

                        priceBook.ObjectID = ((JToken)(book.Id)).Value<string>();
                        priceBook.ImportJsonObject(book, AvailableProperties);

                        priceBooks.Add(priceBook);
                    }
                }

                result = new WhippetResultContainer<SalesforcePriceBook>(WhippetResult.Success, priceBooks.FirstOrDefault());
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<SalesforcePriceBook>(new WhippetResult(e), null);
            }

            return result;
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforcePriceBook"/> objects in the Salesforce instance.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<WhippetResultContainer<IEnumerable<SalesforcePriceBook>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<IEnumerable<SalesforcePriceBook>> result = null;
            WhippetDataRowImportMap map = PriceBook.CreateImportMap();

            List<SalesforcePriceBook> priceBooks = new List<SalesforcePriceBook>();

            SalesforcePriceBook priceBook = null;

            QueryResult<dynamic> results = null;

            string statement = GenerateSelect();

            try
            {
                results = await Client.QueryAsync<dynamic>(statement);

                if (results != null)
                {
                    foreach (dynamic book in results.Records)
                    {
                        priceBook = new SalesforcePriceBook();

                        priceBook.ObjectID = ((JToken)(book.Id)).Value<string>();
                        priceBook.ImportJsonObject(book, AvailableProperties);

                        priceBooks.Add(priceBook);
                    }
                }

                result = new WhippetResultContainer<IEnumerable<SalesforcePriceBook>>(WhippetResult.Success, priceBooks);
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<SalesforcePriceBook>>(new WhippetResult(e), null);
            }

            return result;
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforcePriceBook"/> objects with the specified priceBook name.
        /// </summary>
        /// <param name="priceBookName">PriceBook name of the <see cref="SalesforcePriceBook"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public WhippetResultContainer<IEnumerable<SalesforcePriceBook>> GetByName(string priceBookName)
        {
            if (String.IsNullOrWhiteSpace(priceBookName))
            {
                throw new ArgumentNullException(nameof(priceBookName));
            }
            else
            {
                return Task.Run(() => GetByNameAsync(priceBookName)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforcePriceBook"/> objects with the specified priceBook name.
        /// </summary>
        /// <param name="priceBookName">PriceBook name of the <see cref="SalesforcePriceBook"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public async Task<WhippetResultContainer<IEnumerable<SalesforcePriceBook>>> GetByNameAsync(string priceBookName, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(priceBookName))
            {
                throw new ArgumentNullException(nameof(priceBookName));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesforcePriceBook>> result = null;
                WhippetDataRowImportMap map = PriceBook.CreateImportMap();

                List<SalesforcePriceBook> priceBooks = new List<SalesforcePriceBook>();

                SalesforcePriceBook priceBook = null;

                QueryResult<dynamic> results = null;

                string statement = GenerateSelect() + GenerateWhereEquals(nameof(PriceBook.Name), priceBookName);

                try
                {
                    results = await Client.QueryAsync<dynamic>(statement);

                    if (results != null)
                    {
                        foreach (dynamic book in results.Records)
                        {
                            priceBook = new SalesforcePriceBook();

                            priceBook.ObjectID = ((JToken)(book.Id)).Value<string>();
                            priceBook.ImportJsonObject(book, AvailableProperties);

                            priceBooks.Add(priceBook);
                        }
                    }

                    result = new WhippetResultContainer<IEnumerable<SalesforcePriceBook>>(WhippetResult.Success, priceBooks);
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<SalesforcePriceBook>>(new WhippetResult(e), null);
                }

                return result;
            }
        }

        /// <summary>
        /// Creates a new <see cref="SalesforcePriceBook"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforcePriceBook"/> object to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> CreateAsync(SalesforcePriceBook item, CancellationToken? cancellationToken = null)
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
                    response = await Client.CreateAsync(((ISalesforcePriceBook)(item)).ExternalTableName, CreateDynamicViewModel(item, DefaultIgnoreFields));

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
        /// Updates an existing <see cref="SalesforcePriceBook"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforcePriceBook"/> object to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> UpdateAsync(SalesforcePriceBook item, CancellationToken? cancellationToken = null)
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
                    response = await Client.UpdateAsync(((ISalesforcePriceBook)(item)).ExternalTableName, item.ObjectID.GetValueOrDefault(), CreateDynamicViewModel(item, DefaultIgnoreFields));

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
        /// Deletes an existing <see cref="SalesforcePriceBook"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforcePriceBook"/> object to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> DeleteAsync(SalesforcePriceBook item, CancellationToken? cancellationToken = null)
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
                    await Client.DeleteAsync(((ISalesforcePriceBook)(item)).ExternalTableName, item.ObjectID.GetValueOrDefault());
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

