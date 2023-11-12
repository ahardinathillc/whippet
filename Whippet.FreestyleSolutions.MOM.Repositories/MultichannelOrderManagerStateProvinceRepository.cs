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
    /// Represents a data repository for managing <see cref="MultichannelOrderManagerStateProvince"/> entity objects.
    /// </summary>
    public class MultichannelOrderManagerStateProvinceRepository : MultichannelOrderManagerRepositoryBase<MultichannelOrderManagerStateProvince, long>, IMultichannelOrderManagerStateProvinceRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerStateProvinceRepository"/> class with the specified <see cref="IDbConnection"/> object.
        /// </summary>
        /// <param name="connection"><see cref="IDbConnection"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerStateProvinceRepository(IDbConnection connection)
            : base(connection)
        { }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerStateProvince"/> objects.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>> GetStateProvinces()
        {
            return Task.Run(() => GetStateProvincesAsync()).Result;
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerStateProvince"/> objects that belong to the specified <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="country"><see cref="IMultichannelOrderManagerCountry"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>> GetStateProvinces(IMultichannelOrderManagerCountry country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            else
            {
                return Task.Run(() => GetStateProvincesAsync(country)).Result;
            }
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerStateProvince"/> objects.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>>> GetStateProvincesAsync(CancellationToken? cancellationToken = null)
        {
            QueryFactory context = null;
            Query query = null;

            WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>> result = null;

            WhippetDataRowImportMap map = InternalObject.CreateImportMap();

            IEnumerable<dynamic> results = null;

            try
            {
                context = CreateQueryFactory<SqlServerCompiler>();
                query = context.Query(TableName);

                results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>>(new WhippetResult(e), null);
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
        /// Gets all <see cref="MultichannelOrderManagerStateProvince"/> objects that belong to the specified <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="country"><see cref="IMultichannelOrderManagerCountry"/> to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>>> GetStateProvincesAsync(IMultichannelOrderManagerCountry country, CancellationToken? cancellationToken = null)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            else
            {
                QueryFactory context = null;
                Query query = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>> result = null;

                WhippetDataRowImportMap map = InternalObject.CreateImportMap();

                IEnumerable<dynamic> results = null;

                try
                {
                    context = CreateQueryFactory<SqlServerCompiler>();
                    query = context.Query(TableName).Where(map[nameof(InternalObject.Country)].Column, "=", country.CountryCode);

                    results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>>(new WhippetResult(e), null);
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
        }

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerStateProvince"/> object with the specified abbreviation.
        /// </summary>
        /// <param name="abbreviation">State/province abbreviation.</param>
        /// <param name="country"><see cref="IMultichannelOrderManagerCountry"/> the <see cref="MultichannelOrderManagerStateProvince"/> resides in.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<MultichannelOrderManagerStateProvince> GetStateProvinceByAbbreviation(string abbreviation, IMultichannelOrderManagerCountry country)
        {
            if (String.IsNullOrWhiteSpace(abbreviation))
            {
                throw new ArgumentNullException(nameof(abbreviation));
            }
            else if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            else
            {
                return Task.Run(() => GetStateProvinceByAbbreviationAsync(abbreviation, country)).Result;
            }
        }

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerStateProvince"/> object with the specified abbreviation.
        /// </summary>
        /// <param name="abbreviation">State/province abbreviation.</param>
        /// <param name="country"><see cref="IMultichannelOrderManagerCountry"/> the <see cref="MultichannelOrderManagerStateProvince"/> resides in.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<MultichannelOrderManagerStateProvince>> GetStateProvinceByAbbreviationAsync(string abbreviation, IMultichannelOrderManagerCountry country, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(abbreviation))
            {
                throw new ArgumentNullException(nameof(abbreviation));
            }
            else if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            else
            {
                QueryFactory context = null;
                Query query = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>> result = null;

                WhippetDataRowImportMap map = InternalObject.CreateImportMap();

                IEnumerable<dynamic> results = null;

                try
                {
                    context = CreateQueryFactory<SqlServerCompiler>();
                    query = context.Query(TableName)
                        .Where(map[nameof(InternalObject.Abbreviation)].Column, "=", abbreviation.ToUpperInvariant())
                        .Where(map[nameof(InternalObject.Country)].Column, "=", country.CountryCode);

                    results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>>(new WhippetResult(e), null);
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                        context = null;
                    }
                }

                return new WhippetResultContainer<MultichannelOrderManagerStateProvince>(result.Result, result.Item.FirstOrDefault());
            }
        }

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerStateProvince"/> object with the specified <see cref="IMultichannelOrderManagerPostalCode"/>.
        /// </summary>
        /// <param name="postalCode"><see cref="IMultichannelOrderManagerPostalCode"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<MultichannelOrderManagerStateProvince> GetStateProvinceByPostalCode(IMultichannelOrderManagerPostalCode postalCode)
        {
            if (postalCode == null)
            {
                throw new ArgumentNullException(nameof(postalCode));
            }
            else
            {
                return Task.Run(() => GetStateProvinceByPostalCodeAsync(postalCode)).Result;
            }
        }

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerStateProvince"/> object with the specified <see cref="IMultichannelOrderManagerPostalCode"/>.
        /// </summary>
        /// <param name="postalCode"><see cref="IMultichannelOrderManagerPostalCode"/> object to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<MultichannelOrderManagerStateProvince>> GetStateProvinceByPostalCodeAsync(IMultichannelOrderManagerPostalCode postalCode, CancellationToken? cancellationToken = null)
        {
            if (postalCode == null)
            {
                throw new ArgumentNullException(nameof(postalCode));
            }
            else
            {
                const string ALIAS_1 = "T1";
                const string ALIAS_2 = "T2";

                QueryFactory context = null;
                Query query = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>> result = null;

                WhippetDataRowImportMap map = InternalObject.CreateImportMap();
                WhippetDataRowImportMap postalCodeMap = postalCode.CreateImportMap();

                IEnumerable<dynamic> results = null;

                try
                {
                    context = CreateQueryFactory<SqlServerCompiler>();
                    query = context.Query(TableName + " AS " + ALIAS_1)
                        .Join(postalCode.ExternalTableName + " AS " + ALIAS_2, ALIAS_2 + "." + postalCodeMap[nameof(postalCode.StateProvince)].Column, ALIAS_1 + "." + map[nameof(InternalObject.Abbreviation)].Column)
                        .Where(ALIAS_2 + "." + postalCodeMap[nameof(postalCode.StateProvince)].Column, "=", postalCode.StateProvince.Abbreviation);

                    query = query.Limit(1);

                    results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>>(new WhippetResult(e), null);
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                        context = null;
                    }
                }

                return new WhippetResultContainer<MultichannelOrderManagerStateProvince>(result.Result, result.Item.FirstOrDefault());
            }
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="key">Unique key of the record to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        WhippetResultContainer<MultichannelOrderManagerStateProvince> IWhippetRepository<MultichannelOrderManagerStateProvince, Guid>.Get(System.Guid key)
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
        Task<WhippetResultContainer<MultichannelOrderManagerStateProvince>> IWhippetRepository<MultichannelOrderManagerStateProvince, Guid>.GetAsync(Guid key, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}