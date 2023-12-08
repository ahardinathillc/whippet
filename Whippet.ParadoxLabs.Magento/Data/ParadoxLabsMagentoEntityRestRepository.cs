using System;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Net.Rest;

namespace Athi.Whippet.ParadoxLabs.Magento.Data
{
    /// <summary>
    /// Represents a generic repository that is independent of the backing data store for <see cref="IParadoxLabsMagentoRestEntity"/> objects accessible by a RESTful interface. This class must be inherited.
    /// </summary>
    /// <typeparam name="TEntity">Type of <see cref="IParadoxLabsMagentoRestEntity"/> object to store in the repository.</typeparam>
    public abstract class ParadoxLabsMagentoEntityRestRepository<TEntity> : MagentoEntityRestRepository<TEntity>, IDisposable, IMagentoEntityRepository<TEntity>
        where TEntity : MagentoEntity, IMagentoEntity, IParadoxLabsMagentoRestEntity, new()
    {
        private const string URL_SUBSCRIPTION = "subscription";
            
        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoEntityRestRepository{TEntity}"/> class with the specified <see cref="IWhippetRestClient"/>.
        /// </summary>
        /// <param name="restClient"><see cref="IWhippetRestClient"/> object used to marshall the REST requests.</param>
        /// <param name="bearerToken">Authorization bearer token for making requests.</param>
        /// <exception cref="ArgumentNullException" />
        protected ParadoxLabsMagentoEntityRestRepository(IWhippetRestClient restClient, string bearerToken)
            : this(restClient, bearerToken, URL_SUBSCRIPTION)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoEntityRestRepository{TEntity}"/> class with the specified <see cref="IWhippetRestClient"/>.
        /// </summary>
        /// <param name="restClient"><see cref="IWhippetRestClient"/> object used to marshall the REST requests.</param>
        /// <param name="bearerToken">Authorization bearer token for making requests.</param>
        /// <param name="baseUrl">Base URL of the request (e.g., &quot;orders/&quot;).</param>
        /// <exception cref="ArgumentNullException" />
        protected ParadoxLabsMagentoEntityRestRepository(IWhippetRestClient restClient, string bearerToken, string baseUrl = null)
            : base(restClient, bearerToken, String.IsNullOrWhiteSpace(baseUrl) ? URL_SUBSCRIPTION : baseUrl)
        {
            if (String.IsNullOrWhiteSpace(bearerToken))
            {
                throw new ArgumentNullException(nameof(bearerToken));
            }
        }
    }
}
