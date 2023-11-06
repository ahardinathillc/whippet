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
    /// Repository for <see cref="InvariantAddress"/> objects.
    /// </summary>
    public class InvariantAddressRepository : WhippetEntityRepository<InvariantAddress>, IInvariantAddressRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvariantAddressRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public InvariantAddressRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvariantAddressRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public InvariantAddressRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override async Task<WhippetResultContainer<InvariantAddress>> GetAsync(Guid key, CancellationToken? cancellationToken = null)
        {
            IList<InvariantAddress> queryResults = await Context.QueryOver<InvariantAddress>()
                .Where(a => a.ID == key)
                .JoinQueryOver<PostalCode>(a => a.PostalCode)
                .JoinQueryOver<City>(pcCity => pcCity.City)
                .JoinQueryOver<StateProvince>(pcStateProvince => pcStateProvince.StateProvince)
                .JoinQueryOver<Country>(pcCountry => pcCountry.Country)
                .ListAsync();

            return new WhippetResultContainer<InvariantAddress>(WhippetResult.Success, queryResults.FirstOrDefault());
        }

        /// <summary>
        /// Gets the <see cref="InvariantAddress"/> objects for the specified <see cref="IPostalCode"/>.
        /// </summary>
        /// <param name="postalCode"><see cref="IPostalCode"/> to retrieve addresses for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<InvariantAddress>> Get(IPostalCode postalCode)
        {
            return Task.Run(() => GetAsync(postalCode)).Result;
        }

        /// <summary>
        /// Gets the <see cref="InvariantAddress"/> objects for the specified <see cref="IPostalCode"/>.
        /// </summary>
        /// <param name="postalCode"><see cref="IPostalCode"/> to retrieve addresses for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<InvariantAddress>>> GetAsync(IPostalCode postalCode, CancellationToken? cancellationToken = null)
        {
            if (postalCode == null)
            {
                throw new ArgumentNullException(nameof(postalCode));
            }
            else
            {
                IList<InvariantAddress> queryResults = await Context.QueryOver<InvariantAddress>()
                    .JoinQueryOver<PostalCode>(a => a.PostalCode)
                    .Where(c => c.ID == postalCode.ID)
                    .JoinQueryOver<City>(pcCity => pcCity.City)
                    .Where(pcCity => pcCity.ID == postalCode.City.ID)
                    .JoinQueryOver<StateProvince>(pcStateProvince => pcStateProvince.StateProvince)
                    .Where(pcStateProvince => pcStateProvince.ID == postalCode.City.StateProvince.ID)
                    .JoinQueryOver<Country>(pcCountry => pcCountry.Country)
                    .Where(pcCountry => pcCountry.ID == postalCode.City.StateProvince.Country.ID)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<InvariantAddress>>(WhippetResult.Success, queryResults);
            }
        }

        /// <summary>
        /// Gets the <see cref="InvariantAddress"/> objects for the specified <see cref="ICity"/>.
        /// </summary>
        /// <param name="city"><see cref="ICity"/> to retrieve addresses for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<InvariantAddress>> Get(ICity city)
        {
            return Task.Run(() => GetAsync(city)).Result;
        }

        /// <summary>
        /// Gets the <see cref="InvariantAddress"/> objects for the specified <see cref="ICity"/>.
        /// </summary>
        /// <param name="city"><see cref="ICity"/> to retrieve addresses for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<InvariantAddress>>> GetAsync(ICity city, CancellationToken? cancellationToken = null)
        {
            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }
            else
            {
                IList<InvariantAddress> queryResults = await Context.QueryOver<InvariantAddress>()
                    .JoinQueryOver<City>(a => a.City)
                    .Where(c => c.ID == city.ID)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<InvariantAddress>>(WhippetResult.Success, queryResults);
            }
        }

        /// <summary>
        /// Gets the <see cref="InvariantAddress"/> object with the specified parameters.
        /// </summary>
        /// <param name="lineOne">First line of the address.</param>
        /// <param name="lineTwo">Second line of the address.</param>
        /// <param name="lineThree">Third line of the address.</param>
        /// <param name="lineFour">Fourth line of the address.</param>
        /// <param name="city"><see cref="ICity"/> the address belongs to.</param>
        /// <param name="postalCode"><see cref="IPostalCode"/> to retrieve addresses for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<InvariantAddress> Get(string lineOne, string lineTwo, string lineThree, string lineFour, ICity city, IPostalCode postalCode)
        {
            return Task.Run(() => GetAsync(lineOne, lineTwo, lineThree, lineFour, city, postalCode)).Result;
        }

        /// <summary>
        /// Gets the <see cref="InvariantAddress"/> object with the specified parameters.
        /// </summary>
        /// <param name="lineOne">First line of the address.</param>
        /// <param name="lineTwo">Second line of the address.</param>
        /// <param name="lineThree">Third line of the address.</param>
        /// <param name="lineFour">Fourth line of the address.</param>
        /// <param name="city"><see cref="ICity"/> the address belongs to.</param>
        /// <param name="postalCode"><see cref="IPostalCode"/> to retrieve addresses for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<InvariantAddress>> GetAsync(string lineOne, string lineTwo, string lineThree, string lineFour, ICity city, IPostalCode postalCode, CancellationToken? cancellationToken = null)
        {
            IEnumerable<InvariantAddress> queryResults = null;
            WhippetResultContainer<IEnumerable<InvariantAddress>> result = null;

            if (postalCode == null && city != null)
            {
                result = await GetAsync(city);
            }
            else if (postalCode != null && city == null)
            {
                result = await GetAsync(postalCode);
            }
            else
            {
                result = await GetAsync(postalCode);

                if (result.IsSuccess)
                {
                    queryResults = result.Item;

                    // now filter by city

                    queryResults = queryResults.Where(ia => ia.City.ID == city.ID);

                    result = new WhippetResultContainer<IEnumerable<InvariantAddress>>(result.Result, queryResults);
                }
            }

            if (result.IsSuccess)
            {
                queryResults = result.Item;

                if (queryResults != null && queryResults.Any())
                {
                    if (!String.IsNullOrWhiteSpace(lineOne))
                    {
                        queryResults = queryResults.Where(a => a.LineOne == lineOne).ToList();
                    }

                    if (!String.IsNullOrWhiteSpace(lineTwo))
                    {
                        queryResults = queryResults.Where(a => a.LineTwo == lineTwo).ToList();
                    }

                    if (!String.IsNullOrWhiteSpace(lineThree))
                    {
                        queryResults = queryResults.Where(a => a.LineThree == lineThree).ToList();
                    }

                    if (!String.IsNullOrWhiteSpace(lineFour))
                    {
                        queryResults = queryResults.Where(a => a.LineFour == lineFour).ToList();
                    }
                }

                if (queryResults == null)
                {
                    queryResults = new List<InvariantAddress>();
                }
            }

            return new WhippetResultContainer<InvariantAddress>(WhippetResult.Success, queryResults.FirstOrDefault());
        }
    }
}
