using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Data;
using System.Linq;
using System.Text;
using NHibernate;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using Athi.Whippet.Data;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="MultichannelOrderManagerCountry"/> entity objects.
    /// </summary>
    public class MultichannelOrderManagerCountryRepository : MultichannelOrderManagerRepositoryBase<MultichannelOrderManagerCountry, long>, IMultichannelOrderManagerCountryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCountryRepository"/> class with the specified <see cref="IDbConnection"/> object.
        /// </summary>
        /// <param name="connection"><see cref="IDbConnection"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerCountryRepository(IDbConnection connection)
            : base(connection)
        { }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCountry"/> objects.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerCountry>> GetCountries()
        {
            return Task.Run(() => GetCountriesAsync()).Result;
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCountry"/> objects.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCountry>>> GetCountriesAsync(CancellationToken? cancellationToken = null)
        {
            QueryFactory context = null;
            Query query = null;

            WhippetResultContainer<IEnumerable<MultichannelOrderManagerCountry>> result = null;

            WhippetDataRowImportMap map = InternalObject.CreateImportMap();

            IEnumerable<dynamic> results = null;

            try
            {
                context = CreateQueryFactory<SqlServerCompiler>();
                query = context.Query(TableName);

                results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCountry>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCountry>>(new WhippetResult(e), null);
            }
            finally
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerCountry"/> object with the specified abbreviation.
        /// </summary>
        /// <param name="abbreviation">Two-letter ISO abbreviation of the country.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<MultichannelOrderManagerCountry> GetCountryByAbbreviation(string abbreviation)
        {
            if (String.IsNullOrWhiteSpace(abbreviation))
            {
                throw new ArgumentNullException(nameof(abbreviation));
            }
            else
            {
                return Task.Run(() => GetCountryByAbbreviationAsync(abbreviation)).Result;
            }
        }

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerCountry"/> object with the specified abbreviation.
        /// </summary>
        /// <param name="abbreviation">Two-letter ISO abbreviation of the country.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<MultichannelOrderManagerCountry>> GetCountryByAbbreviationAsync(string abbreviation, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(abbreviation))
            {
                throw new ArgumentNullException(nameof(abbreviation));
            }
            else
            {
                QueryFactory context = null;
                Query query = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerCountry>> result = null;

                WhippetDataRowImportMap map = InternalObject.CreateImportMap();

                IEnumerable<dynamic> results = null;

                try
                {
                    context = CreateQueryFactory<SqlServerCompiler>();

                    if (abbreviation.Length == 2)
                    {
                        query = context.Query(TableName).Where(map[nameof(InternalObject.ISO2)].Column, "=", abbreviation.ToUpperInvariant());
                    }
                    else
                    {
                        query = context.Query(TableName).Where(map[nameof(InternalObject.ISO3)].Column, "=", abbreviation.ToUpperInvariant());
                    }

                    results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCountry>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCountry>>(new WhippetResult(e), null);
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                        context = null;
                    }
                }

                return new WhippetResultContainer<MultichannelOrderManagerCountry>(result.Result, result.Item.FirstOrDefault());
            }
        }

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerCountry"/> object with the specified three digit code.
        /// </summary>
        /// <param name="countryCode">Three-digit country code of the country.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<MultichannelOrderManagerCountry> GetCountryByCode(string countryCode)
        {
            if (String.IsNullOrWhiteSpace(countryCode))
            {
                throw new ArgumentNullException(nameof(countryCode));
            }
            else
            {
                return Task.Run(() => GetCountryByCodeAsync(countryCode)).Result;
            }
        }

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerCountry"/> object with the specified three digit code.
        /// </summary>
        /// <param name="countryCode">Three-digit country code of the country.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<MultichannelOrderManagerCountry>> GetCountryByCodeAsync(string countryCode, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(countryCode))
            {
                throw new ArgumentNullException(nameof(countryCode));
            }
            else
            {
                QueryFactory context = null;
                Query query = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerCountry>> result = null;

                WhippetDataRowImportMap map = InternalObject.CreateImportMap();

                IEnumerable<dynamic> results = null;

                try
                {
                    context = CreateQueryFactory<SqlServerCompiler>();
                    query = context.Query(TableName).Where(map[nameof(InternalObject.CountryCode)].Column, "=", countryCode);

                    results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCountry>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCountry>>(new WhippetResult(e), null);
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                        context = null;
                    }
                }

                return new WhippetResultContainer<MultichannelOrderManagerCountry>(result.Result, result.Item.FirstOrDefault());
            }
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="key">Unique key of the record to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        WhippetResultContainer<MultichannelOrderManagerCountry> IWhippetRepository<MultichannelOrderManagerCountry, Guid>.Get(System.Guid key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="key">Unique key of the record to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<WhippetResultContainer<MultichannelOrderManagerCountry>> IWhippetRepository<MultichannelOrderManagerCountry, Guid>.GetAsync(Guid key, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}