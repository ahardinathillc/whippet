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
    /// Repository for <see cref="Country"/> objects.
    /// </summary>
    public class CountryRepository : WhippetEntityRepository<Country>, ICountryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public CountryRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public CountryRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Gets the <see cref="Country"/> object with the specified name.
        /// </summary>
        /// <param name="name">Name of the <see cref="Country"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<Country> Get(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            else
            {
                return Task.Run(() => GetAsync(name)).Result;
            }
        }

        /// <summary>
        /// Gets the <see cref="Country"/> object with the specified name.
        /// </summary>
        /// <param name="name">Name of the <see cref="StateProvince"/> object to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual async Task<WhippetResultContainer<Country>> GetAsync(string name, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            else
            {
                IList<Country> queryResults = await Context.QueryOver<Country>()
                    .Where(c => c.Name == name)
                    .ListAsync();

                return new WhippetResultContainer<Country>(WhippetResult.Success, queryResults.FirstOrDefault());
            }
        }
    }
}
