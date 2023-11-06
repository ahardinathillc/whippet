using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Athi.Whippet;
using Athi.Whippet.Data;

namespace Athi.Whippet.Localization.Addressing.Repositories
{
    /// <summary>
    /// Repository for <see cref="PostalCode"/> objects.
    /// </summary>
    public class PostalCodeRepository : WhippetEntityRepository<PostalCode>, IPostalCodeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostalCodeRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public PostalCodeRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostalCodeRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public PostalCodeRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Gets the <see cref="PostalCode"/> objects with the specified value.
        /// </summary>
        /// <param name="value">Value of the <see cref="PostalCode"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<PostalCode>> Get(string value)
        {
            return Task.Run(() => GetAsync(value)).Result;
        }

        /// <summary>
        /// Gets the <see cref="PostalCode"/> objects with the specified value.
        /// </summary>
        /// <param name="value">Value of the <see cref="PostalCode"/> object to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<PostalCode>>> GetAsync(string value, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            else
            {
                IList<PostalCode> queryResults = await Context.QueryOver<PostalCode>()
                    .Where(postalCodeAlias => postalCodeAlias.Value == value)
                    .JoinQueryOver<City>(pc => pc.City)
                    .JoinQueryOver<StateProvince>(city => city.StateProvince)
                    .JoinQueryOver<Country>(stateProvince => stateProvince.Country)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<PostalCode>>(WhippetResult.Success, queryResults);
            }
        }

        /// <summary>
        /// Gets the <see cref="PostalCode"/> objects with the specified value.
        /// </summary>
        /// <param name="value">Value of the <see cref="PostalCode"/> object to retrieve.</param>
        /// <param name="city">City that the <see cref="PostalCode"/> is assigned to.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<PostalCode>> Get(string value, ICity city)
        {
            return Task.Run(() => GetAsync(value, city)).Result;
        }

        /// <summary>
        /// Gets the <see cref="PostalCode"/> objects with the specified value.
        /// </summary>
        /// <param name="value">Value of the <see cref="PostalCode"/> object to retrieve.</param>
        /// <param name="city">City that the <see cref="PostalCode"/> is assigned to.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<PostalCode>>> GetAsync(string value, ICity city, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            else if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }
            else
            {
                IList<PostalCode> queryResults = await Context.QueryOver<PostalCode>()
                    .Where(pc => pc.Value == value)
                    .JoinQueryOver<City>(pc => pc.City)
                    .Where(c => c.ID == city.ID)
                    .JoinQueryOver<StateProvince>(city => city.StateProvince)
                    .JoinQueryOver<Country>(sp => sp.Country)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<PostalCode>>(WhippetResult.Success, queryResults);
            }
        }

        /// <summary>
        /// Gets the <see cref="PostalCode"/> objects for the specified city.
        /// </summary>
        /// <param name="city">City that the <see cref="PostalCode"/> is assigned to.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<PostalCode>> Get(ICity city)
        {
            return Task.Run(() => GetAsync(city)).Result;
        }

        /// <summary>
        /// Gets the <see cref="PostalCode"/> objects for the specified city.
        /// </summary>
        /// <param name="city">City that the <see cref="PostalCode"/> is assigned to.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<PostalCode>>> GetAsync(ICity city, CancellationToken? cancellationToken = null)
        {
            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }
            else
            {
                IList<PostalCode> queryResults = await Context.QueryOver<PostalCode>()
                    .JoinQueryOver<City>(pc => pc.City)
                    .Where(c => c.ID == city.ID)
                    .JoinQueryOver<StateProvince>(city => city.StateProvince)
                    .JoinQueryOver<Country>(sp => sp.Country)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<PostalCode>>(WhippetResult.Success, queryResults);
            }
        }

        /// <summary>
        /// Gets all <see cref="PostalCode"/> objects in the data store.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public override async Task<WhippetResultContainer<IEnumerable<PostalCode>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            IList<PostalCode> queryResults = await Context.QueryOver<PostalCode>()
                .OrderBy(pc => pc.Value).Asc
                .JoinQueryOver<City>(pc => pc.City)
                .JoinQueryOver<StateProvince>(city => city.StateProvince)
                .JoinQueryOver<Country>(sp => sp.Country)
                .ListAsync();

            return new WhippetResultContainer<IEnumerable<PostalCode>>(WhippetResult.Success, queryResults);
        }
    }
}
