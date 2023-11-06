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
    /// Repository for <see cref="City"/> objects.
    /// </summary>
    public class CityRepository : WhippetEntityRepository<City>, ICityRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CityRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public CityRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CityRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public CityRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Gets all <see cref="City"/> objects with the specified name.
        /// </summary>
        /// <param name="name">Name of the <see cref="City"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<City>> Get(string name)
        {
            return Task.Run(() => GetAsync(name)).Result;
        }

        /// <summary>
        /// Gets all <see cref="City"/> objects with the specified name.
        /// </summary>
        /// <param name="name">Name of the <see cref="City"/> object to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<City>>> GetAsync(string name, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            else
            {
                IList<City> queryResults = await Context.QueryOver<City>()
                    .Where(c => c.Name == name)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<City>>(WhippetResult.Success, queryResults);
            }
        }

        /// <summary>
        /// Gets the <see cref="City"/> object with the specified name and parent <see cref="IStateProvince"/>.
        /// </summary>
        /// <param name="name">Name of the <see cref="City"/> object to retrieve.</param>
        /// <param name="stateProvince"><see cref="IStateProvince"/> the city belongs to.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<City> Get(string name, IStateProvince stateProvince)
        {
            return Task.Run(() => GetAsync(name, stateProvince)).Result;
        }

        /// <summary>
        /// Gets the <see cref="City"/> object with the specified name and parent <see cref="IStateProvince"/>.
        /// </summary>
        /// <param name="name">Name of the <see cref="City"/> object to retrieve.</param>
        /// <param name="stateProvince"><see cref="IStateProvince"/> the city belongs to.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual async Task<WhippetResultContainer<City>> GetAsync(string name, IStateProvince stateProvince, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            else if (stateProvince == null)
            {
                throw new ArgumentNullException(nameof(stateProvince));
            }
            else
            {
                IList<City> queryResults = await Context.QueryOver<City>()
                    .Where(c => c.Name == name)
                    .JoinQueryOver<StateProvince>(c => c.StateProvince)
                    .Where(sp => sp.ID == stateProvince.ID)
                    .ListAsync();

                return new WhippetResultContainer<City>(WhippetResult.Success, queryResults?.FirstOrDefault());
            }
        }

        /// <summary>
        /// Gets all <see cref="City"/> objects that belong to the specified <see cref="IStateProvince"/>.
        /// </summary>
        /// <param name="stateProvince"><see cref="IStateProvince"/> to retrieve cities for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<City>> Get(IStateProvince stateProvince)
        {
            return Task.Run(() => GetAsync(stateProvince)).Result;
        }

        /// <summary>
        /// Gets all <see cref="City"/> objects that belong to the specified <see cref="IStateProvince"/>.
        /// </summary>
        /// <param name="stateProvince"><see cref="IStateProvince"/> to retrieve cities for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<City>>> GetAsync(IStateProvince stateProvince, CancellationToken? cancellationToken = null)
        {
            if (stateProvince == null)
            {
                throw new ArgumentNullException(nameof(stateProvince));
            }
            else
            {
                IList<City> queryResults = await Context.QueryOver<City>()
                    .JoinQueryOver<StateProvince>(c => c.StateProvince)
                    .Where(sp => sp.ID == stateProvince.ID)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<City>>(WhippetResult.Success, queryResults);
            }
        }

    }
}
