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
    /// Repository for <see cref="StateProvince"/> objects.
    /// </summary>
    public class StateProvinceRepository : WhippetEntityRepository<StateProvince>, IStateProvinceRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StateProvinceRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public StateProvinceRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateProvinceRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public StateProvinceRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Gets all <see cref="StateProvince"/> objects for the specified <see cref="ICountry"/>.
        /// </summary>
        /// <param name="country"><see cref="ICountry"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual WhippetResultContainer<IEnumerable<StateProvince>> GetAll(ICountry country)
        {
            return (country == null ? base.GetAll() : Task.Run(() => GetAllAsync(country)).Result);
        }

        /// <summary>
        /// Gets all <see cref="StateProvince"/> objects for the specified <see cref="ICountry"/>.
        /// </summary>
        /// <param name="country"><see cref="ICountry"/> object to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<StateProvince>>> GetAllAsync(ICountry country, CancellationToken? cancellationToken = null)
        {
            IList<StateProvince> queryResults = null;
            WhippetResultContainer<IEnumerable<StateProvince>> result = null;

            if (country == null)
            {
                result = await base.GetAllAsync(cancellationToken);
            }
            else
            {
                queryResults = await Context.QueryOver<StateProvince>()
                .JoinQueryOver(c => c.Country)
                .Where(c => c.ID == country.ID)
                .ListAsync();

                result = new WhippetResultContainer<IEnumerable<StateProvince>>(WhippetResult.Success, queryResults);
            }

            return result;
        }

        /// <summary>
        /// Gets the <see cref="StateProvince"/> object with the specified name.
        /// </summary>
        /// <param name="name">Name of the <see cref="StateProvince"/> object to retrieve.</param>
        /// <param name="country"><see cref="ICountry"/> that the <see cref="StateProvince"/> is located in.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<StateProvince> Get(string name, ICountry country)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            else if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            else
            {
                return Task.Run(() => GetAsync(name, country)).Result;
            }
        }

        /// <summary>
        /// Gets the <see cref="StateProvince"/> object with the specified name.
        /// </summary>
        /// <param name="name">Name of the <see cref="StateProvince"/> object to retrieve.</param>
        /// <param name="country"><see cref="ICountry"/> that the <see cref="StateProvince"/> is located in.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual async Task<WhippetResultContainer<StateProvince>> GetAsync(string name, ICountry country, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            else if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            else
            {
                IList<StateProvince> queryResults = await Context.QueryOver<StateProvince>()
                    .Where(s => s.Name == name)
                    .JoinQueryOver(c => c.Country)
                    .Where(c => c.ID == country.ID)
                    .ListAsync();

                return new WhippetResultContainer<StateProvince>(WhippetResult.Success, queryResults.FirstOrDefault());
            }
        }
    }
}
