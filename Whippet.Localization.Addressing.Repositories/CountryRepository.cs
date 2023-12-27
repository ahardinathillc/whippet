using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Athi.Whippet.Data;
using Athi.Whippet.Data.NHibernate.Extensions;
using Athi.Whippet.Localization.Addressing.EntityMappings;

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

        /// <summary>
        /// Updates the specified <see cref="Country"/> object with the new ID.
        /// </summary>
        /// <param name="country"><see cref="Country"/> object to update.</param>
        /// <param name="newId"><see cref="Guid"/> that represents the new ID to assign.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual WhippetResultContainer<Country> Update(Country country, Guid newId)
        {
            ArgumentNullException.ThrowIfNull(country);
            return Task.Run(() => UpdateAsync(country, newId)).Result;
        }

        /// <summary>
        /// Updates the specified <see cref="Country"/> object with the new ID.
        /// </summary>
        /// <param name="country"><see cref="Country"/> object to update.</param>
        /// <param name="newId"><see cref="Guid"/> that represents the new ID to assign.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual async Task<WhippetResultContainer<Country>> UpdateAsync(Country country, Guid newId, CancellationToken? cancellationToken = null)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            else
            {
                const string PARAM_ID = "@id";
                const string PARAM_OLD_ID = "@oldId";

                WhippetResultContainer<Country> result = null;
                
                try
                {
                    await Context.ExecuteRawUpdateAsync(String.Format("UPDATE {0} SET {1}={2} WHERE {3}={4}", new CountryMap().FullyQualifiedTableName, nameof(Country.ID), PARAM_ID, nameof(Country.ID), PARAM_OLD_ID),
                        new Dictionary<string, object>() { { PARAM_ID, newId }, { PARAM_OLD_ID, country.ID } });

                    country.ID = newId;

                    result = new WhippetResultContainer<Country>(WhippetResult.Success, country);
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<Country>(e);
                }

                return result;
            }
        }
    }
}
