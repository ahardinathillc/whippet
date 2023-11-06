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
    /// Represents a data repository for managing <see cref="SalesforceProduct"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class SalesforceProductRepository : SalesforceRepository<SalesforceProduct>, ISalesforceProductRepository
    {
        private ISalesforceProduct _product;

        /// <summary>
        /// Gets the default fields that are ignored in CREATE statements. This property is read-only.
        /// </summary>
        protected override IEnumerable<string> DefaultIgnoreFields
        {
            get
            {
                return base.DefaultIgnoreFields.Concat(new[]
                {
                    "StockKeepingUnit"
                });
            }
        }

        /// <summary>
        /// Gets or sets an internal <see cref="ISalesforceProduct"/> object used for generating mappings.
        /// </summary>
        private ISalesforceProduct Product
        {
            get
            {
                if (_product == null)
                {
                    _product = new SalesforceProduct();
                }

                return _product;
            }
            set
            {
                _product = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceProductRepository"/> class with the specified <see cref="ISalesforceClient"/> object.
        /// </summary>
        /// <param name="client"><see cref="ISalesforceClient"/> object to initialize with.</param>
        /// <param name="product"><see cref="ISalesforceProduct"/> object used for generating object maps.</param>
        /// <exception cref="ArgumentNullException" />
        public SalesforceProductRepository(ISalesforceClient client, ISalesforceProduct product = null)
            : base(client)
        {
            Product = product;
        }

        /// <summary>
        /// Retrieves the <see cref="SalesforceProduct"/> with the specified object ID from the Salesforce instance.
        /// </summary>
        /// <param name="key">Salesforce object ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<WhippetResultContainer<SalesforceProduct>> GetAsync(SalesforceReference key, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<SalesforceProduct> result = null;
            WhippetDataRowImportMap map = Product.CreateImportMap();

            List<SalesforceProduct> products = new List<SalesforceProduct>();

            SalesforceProduct product = null;

            QueryResult<dynamic> results = null;

            string statement = GenerateSelect() + GenerateWhereEquals(nameof(Product.ObjectID), key);

            try
            {
                results = await Client.QueryAsync<dynamic>(statement);

                if (results != null)
                {
                    foreach (dynamic prod in results.Records)
                    {
                        product = new SalesforceProduct();

                        product.ObjectID = ((JToken)(prod.Id)).Value<string>();
                        product.ImportJsonObject(prod, AvailableProperties);

                        products.Add(product);
                    }
                }

                result = new WhippetResultContainer<SalesforceProduct>(WhippetResult.Success, products.FirstOrDefault());
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<SalesforceProduct>(new WhippetResult(e), null);
            }

            return result;
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceProduct"/> objects in the Salesforce instance.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<WhippetResultContainer<IEnumerable<SalesforceProduct>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<IEnumerable<SalesforceProduct>> result = null;
            WhippetDataRowImportMap map = Product.CreateImportMap();

            List<SalesforceProduct> products = new List<SalesforceProduct>();

            SalesforceProduct product = null;

            QueryResult<dynamic> results = null;

            string statement = GenerateSelect();

            try
            {
                results = await Client.QueryAsync<dynamic>(statement);

                if (results != null)
                {
                    foreach (dynamic prod in results.Records)
                    {
                        product = new SalesforceProduct();

                        product.ObjectID = ((JToken)(prod.Id)).Value<string>();
                        product.ImportJsonObject(prod, AvailableProperties);

                        products.Add(product);
                    }
                }

                result = new WhippetResultContainer<IEnumerable<SalesforceProduct>>(WhippetResult.Success, products);
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<SalesforceProduct>>(new WhippetResult(e), null);
            }

            return result;
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceProduct"/> objects with the specified product name.
        /// </summary>
        /// <param name="productName">Product name of the <see cref="SalesforceProduct"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public WhippetResultContainer<IEnumerable<SalesforceProduct>> GetByName(string productName)
        {
            if (String.IsNullOrWhiteSpace(productName))
            {
                throw new ArgumentNullException(nameof(productName));
            }
            else
            {
                return Task.Run(() => GetByNameAsync(productName)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceProduct"/> objects with the specified product name.
        /// </summary>
        /// <param name="productName">Product name of the <see cref="SalesforceProduct"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public async Task<WhippetResultContainer<IEnumerable<SalesforceProduct>>> GetByNameAsync(string productName, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(productName))
            {
                throw new ArgumentNullException(nameof(productName));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesforceProduct>> result = null;
                WhippetDataRowImportMap map = Product.CreateImportMap();

                List<SalesforceProduct> products = new List<SalesforceProduct>();

                SalesforceProduct product = null;

                QueryResult<dynamic> results = null;

                string statement = GenerateSelect() + GenerateWhereEquals(nameof(Product.Name), productName);

                try
                {
                    results = await Client.QueryAsync<dynamic>(statement);

                    if (results != null)
                    {
                        foreach (dynamic prod in results.Records)
                        {
                            product = new SalesforceProduct();

                            product.ObjectID = ((JToken)(prod.Id)).Value<string>();
                            product.ImportJsonObject(prod, AvailableProperties);

                            products.Add(product);
                        }
                    }

                    result = new WhippetResultContainer<IEnumerable<SalesforceProduct>>(WhippetResult.Success, products);
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<SalesforceProduct>>(new WhippetResult(e), null);
                }

                return result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceProduct"/> objects with the specified price book SKU.
        /// </summary>
        /// <param name="sku">SKU of the <see cref="SalesforceProduct"/> object(s) to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public WhippetResultContainer<IEnumerable<SalesforceProduct>> GetByStockKeepingUnit(string sku)
        {
            if (String.IsNullOrWhiteSpace(sku))
            {
                throw new ArgumentNullException(nameof(sku));
            }
            else
            {
                return Task.Run(() => GetByStockKeepingUnitAsync(sku)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceProduct"/> objects with the specified price book SKU.
        /// </summary>
        /// <param name="sku">SKU of the <see cref="SalesforceProduct"/> object(s) to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public async Task<WhippetResultContainer<IEnumerable<SalesforceProduct>>> GetByStockKeepingUnitAsync(string sku, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(sku))
            {
                throw new ArgumentNullException(nameof(sku));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesforceProduct>> result = null;
                WhippetDataRowImportMap map = Product.CreateImportMap();

                List<SalesforceProduct> products = new List<SalesforceProduct>();

                SalesforceProduct product = null;

                QueryResult<dynamic> results = null;

                string statement = GenerateSelect() + GenerateWhereEquals(nameof(Product.StockKeepingUnit), sku);

                try
                {
                    results = await Client.QueryAsync<dynamic>(statement);

                    if (results != null)
                    {
                        foreach (dynamic prod in results.Records)
                        {
                            product = new SalesforceProduct();

                            product.ObjectID = ((JToken)(prod.Id)).Value<string>();
                            product.ImportJsonObject(prod, AvailableProperties);

                            products.Add(product);
                        }
                    }

                    result = new WhippetResultContainer<IEnumerable<SalesforceProduct>>(WhippetResult.Success, products);
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<SalesforceProduct>>(new WhippetResult(e), null);
                }

                return result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceProduct"/> objects with the specified product external ID.
        /// </summary>
        /// <param name="externalID">External ID of the <see cref="SalesforceProduct"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public WhippetResultContainer<IEnumerable<SalesforceProduct>> GetByExternalID(string externalID)
        {
            if (String.IsNullOrWhiteSpace(externalID))
            {
                throw new ArgumentNullException(nameof(externalID));
            }
            else
            {
                return Task.Run(() => GetByExternalID(externalID)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceProduct"/> objects with the specified product external ID.
        /// </summary>
        /// <param name="externalID">External ID of the <see cref="SalesforceProduct"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public async Task<WhippetResultContainer<IEnumerable<SalesforceProduct>>> GetByExternalIDAsync(string externalID, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(externalID))
            {
                throw new ArgumentNullException(nameof(externalID));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesforceProduct>> result = null;
                WhippetDataRowImportMap map = Product.CreateImportMap();

                List<SalesforceProduct> products = new List<SalesforceProduct>();

                SalesforceProduct product = null;

                QueryResult<dynamic> results = null;

                string statement = GenerateSelect() + GenerateWhereEquals(nameof(Product.ExternalID), externalID);

                try
                {
                    results = await Client.QueryAsync<dynamic>(statement);

                    if (results != null)
                    {
                        foreach (dynamic prod in results.Records)
                        {
                            product = new SalesforceProduct();

                            product.ObjectID = ((JToken)(prod.Id)).Value<string>();
                            product.ImportJsonObject(prod, AvailableProperties);

                            products.Add(product);
                        }
                    }

                    result = new WhippetResultContainer<IEnumerable<SalesforceProduct>>(WhippetResult.Success, products);
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<SalesforceProduct>>(new WhippetResult(e), null);
                }

                return result;
            }
        }

        /// <summary>
        /// Creates a new <see cref="SalesforceProduct"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforceProduct"/> object to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> CreateAsync(SalesforceProduct item, CancellationToken? cancellationToken = null)
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
                    response = await Client.CreateAsync(((ISalesforceProduct)(item)).ExternalTableName, CreateDynamicViewModel(item, DefaultIgnoreFields));

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
        /// Updates an existing <see cref="SalesforceProduct"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforceProduct"/> object to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> UpdateAsync(SalesforceProduct item, CancellationToken? cancellationToken = null)
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
                    response = await Client.UpdateAsync(((ISalesforceProduct)(item)).ExternalTableName, item.ObjectID.GetValueOrDefault(), CreateDynamicViewModel(item, DefaultIgnoreFields));

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
        /// Deletes an existing <see cref="SalesforceProduct"/> object.
        /// </summary>
        /// <param name="item"><see cref="SalesforceProduct"/> object to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task<WhippetResult> DeleteAsync(SalesforceProduct item, CancellationToken? cancellationToken = null)
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
                    await Client.DeleteAsync(((ISalesforceProduct)(item)).ExternalTableName, item.ObjectID.GetValueOrDefault());
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

