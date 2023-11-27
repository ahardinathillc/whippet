using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Data;
using Athi.Whippet.Net.Rest;
using Athi.Whippet.Net.Rest.Extensions;
using Athi.Whippet.Adobe.Magento.Directory.Models;

namespace Athi.Whippet.Adobe.Magento.Directory.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="Country"/> entity objects.
    /// </summary>
    public class CountryRepository : MagentoEntityRestRepository<Country>, ICountryRepository
    {
        private const string DIRECTORY_BASE_URL = "directory/countries";
        private const string DIRECTORY_COUNTRY_URL = DIRECTORY_BASE_URL + "/{0}";

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryRepository"/> class with the specified <see cref="IWhippetRestClient"/>.
        /// </summary>
        /// <param name="restClient"><see cref="IWhippetRestClient"/> object used to marshall the REST requests.</param>
        /// <param name="bearerToken">Authorization bearer token for making requests.</param>
        /// <exception cref="ArgumentNullException" />
        public CountryRepository(IWhippetRestClient restClient, string bearerToken)
            : base(restClient, bearerToken)
        { }

        /// <summary>
        /// Gets the <see cref="Country"/> object with the specified <see cref="Country.CountryID"/>.
        /// </summary>
        /// <param name="key"><see cref="Country.CountryID"/> value to search for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        public virtual WhippetResultContainer<Country> Get(WhippetNonNullableString key)
        {
            return Task.Run(() => GetAsync(key)).Result;
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="key">Entity ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Task<WhippetResultContainer<Country>> GetAsync(uint key, CancellationToken? cancellationToken = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the <see cref="Country"/> object with the specified <see cref="Country.CountryID"/>.
        /// </summary>
        /// <param name="key"><see cref="Country.CountryID"/> value to search for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public virtual async Task<WhippetResultContainer<Country>> GetAsync(WhippetNonNullableString key, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<Country> result = null;
            WhippetResultContainer<CountryDataModel> dataModelResult = null;

            RestRequest request = null;
            RestResponse response = null;

            try
            {
                request = CreateRequest(CreateEndpointUrl(String.Format(DIRECTORY_COUNTRY_URL, key)), Method.Get);
                response = await Client.ExecuteAsync(request);

                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    dataModelResult = new WhippetResultContainer<CountryDataModel>(WhippetResult.Success, JsonConvert.DeserializeObject<CountryDataModel>(response.Content));
                    result = new WhippetResultContainer<Country>(dataModelResult.Result, dataModelResult.Item == null ? null : dataModelResult.Item.ToCountry());
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<Country>(e);
            }

            return result;
        }

        /// <summary>
        /// Asynchronously retrieves all <see cref="Country"/> objects in Magento.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public override async Task<WhippetResultContainer<IEnumerable<Country>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<IEnumerable<Country>> result = null;
            WhippetResultContainer<IEnumerable<CountryDataModel>> dataModelResult = null;

            RestRequest request = null;
            RestResponse response = null;

            try
            {
                request = CreateRequest(CreateEndpointUrl(DIRECTORY_BASE_URL), Method.Get);
                response = await Client.ExecuteAsync(request);

                response.ThrowIfError();

                if (response.IsOkStatus())
                {
                    dataModelResult = new WhippetResultContainer<IEnumerable<CountryDataModel>>(WhippetResult.Success, JsonConvert.DeserializeObject<List<CountryDataModel>>(response.Content));
                    result = new WhippetResultContainer<IEnumerable<Country>>(dataModelResult.Result, dataModelResult.Item == null ? null : dataModelResult.Item.Select(c => c.ToCountry()));
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<Country>>(e);
            }

            return result;
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="item"><see cref="Country"/> object to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="InvalidOperationException" />
        public override Task<WhippetResult> CreateAsync(Country item, CancellationToken? cancellationToken = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="item"><see cref="Country"/> object to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="InvalidOperationException" />
        public override Task<WhippetResult> UpdateAsync(Country item, CancellationToken? cancellationToken = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="item"><see cref="Country"/> object to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Task<WhippetResult> DeleteAsync(Country item, CancellationToken? cancellationToken = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="key">Unique ID of the <see cref="Country"/> object.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<WhippetResultContainer<Country>> IWhippetRepository<Country, Guid>.GetAsync(Guid key, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="key">Unique ID of the <see cref="Country"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        WhippetResultContainer<Country> IWhippetRepository<Country, Guid>.Get(Guid key)
        {
            throw new NotImplementedException();
        }
    }
}
