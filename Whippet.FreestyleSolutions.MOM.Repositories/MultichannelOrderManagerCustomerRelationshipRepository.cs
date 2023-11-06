using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Data;
using System.Linq;
using NHibernate;
using NodaTime;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using Dynamitey;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Data.Database.Microsoft.Extensions;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;
using Athi.Whippet.Localization.Addressing;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="MultichannelOrderManagerCustomerRelationship"/> entity objects.
    /// </summary>
    public class MultichannelOrderManagerCustomerRelationshipRepository : MultichannelOrderManagerRepositoryBase<MultichannelOrderManagerCustomerRelationship, long>, IMultichannelOrderManagerCustomerRelationshipRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCustomerRelationshipRepository"/> class with the specified <see cref="IDbConnection"/> object.
        /// </summary>
        /// <param name="connection"><see cref="IDbConnection"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerCustomerRelationshipRepository(IDbConnection connection)
            : base(connection)
        { }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCustomerRelationship"/> objects for the specified relationship IDs.
        /// </summary>
        /// <param name="relationshipIds"><see cref="MultichannelOrderManagerCustomerRelationship"/> IDs of the objects to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>> GetCustomerRelationships(IEnumerable<long> relationshipIds)
        {
            return Task.Run(() => GetCustomerRelationshipsAsync(relationshipIds)).Result;
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCustomerRelationship"/> objects for the specified relationship IDs.
        /// </summary>
        /// <param name="relationshipIds"><see cref="MultichannelOrderManagerCustomerRelationship"/> IDs of the objects to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>>> GetCustomerRelationshipsAsync(IEnumerable<long> relationshipIds, CancellationToken? cancellationToken = null)
        {
            QueryFactory context = null;
            Query query = null;

            WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>> result = null;

            WhippetDataRowImportMap map = InternalObject.CreateImportMap();

            IEnumerable<dynamic> results = null;

            try
            {
                context = CreateQueryFactory<SqlServerCompiler>();
                query = (relationshipIds == null || !relationshipIds.Any()) ? context.Query(TableName) : context.Query(TableName).WhereIn(map[nameof(InternalObject.RelationshipId)].Column, relationshipIds);

                results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>>(new WhippetResult(e), null);
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
        /// Gets all <see cref="MultichannelOrderManagerCustomerRelationship"/> objects for the specified parent <see cref="MultichannelOrderManagerCustomer.CustomerId"/>.
        /// </summary>
        /// <param name="parentCustomerId">Parent <see cref="MultichannelOrderManagerCustomer.CustomerId"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>> GetCustomerRelationshipsForParentCustomer(long parentCustomerId)
        {
            return Task.Run(() => GetCustomerRelationshipsForParentCustomerAsync(parentCustomerId)).Result;
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCustomerRelationship"/> objects for the specified parent <see cref="MultichannelOrderManagerCustomer.CustomerId"/>.
        /// </summary>
        /// <param name="parentCustomerId">Parent <see cref="MultichannelOrderManagerCustomer.CustomerId"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>>> GetCustomerRelationshipsForParentCustomerAsync(long parentCustomerId, CancellationToken? cancellationToken = null)
        {
            QueryFactory context = null;
            Query query = null;

            WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>> result = null;

            WhippetDataRowImportMap map = InternalObject.CreateImportMap();

            IEnumerable<dynamic> results = null;

            try
            {
                context = CreateQueryFactory<SqlServerCompiler>();
                query = context.Query(TableName).Where(map[nameof(InternalObject.ParentCustomerId)].Column, parentCustomerId);

                results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>>(new WhippetResult(e), null);
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
        /// Gets all <see cref="MultichannelOrderManagerCustomerRelationship"/> objects for the specified child <see cref="MultichannelOrderManagerCustomer.CustomerId"/>.
        /// </summary>
        /// <param name="childCustomerId">Child <see cref="MultichannelOrderManagerCustomer.CustomerId"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>> GetCustomerRelationshipsForChildCustomer(long childCustomerId)
        {
            return Task.Run(() => GetCustomerRelationshipsForChildCustomerAsync(childCustomerId)).Result;
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCustomerRelationship"/> objects for the specified child <see cref="MultichannelOrderManagerCustomer.CustomerId"/>.
        /// </summary>
        /// <param name="childCustomerId">Child <see cref="MultichannelOrderManagerCustomer.CustomerId"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>>> GetCustomerRelationshipsForChildCustomerAsync(long childCustomerId, CancellationToken? cancellationToken = null)
        {
            QueryFactory context = null;
            Query query = null;

            WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>> result = null;

            WhippetDataRowImportMap map = InternalObject.CreateImportMap();

            IEnumerable<dynamic> results = null;

            try
            {
                context = CreateQueryFactory<SqlServerCompiler>();
                query = context.Query(TableName).Where(map[nameof(InternalObject.ChildCustomerId)].Column, childCustomerId);

                results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>>(new WhippetResult(e), null);
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
        /// This method is not implemented.
        /// </summary>
        /// <param name="key">Unique key of the record to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        WhippetResultContainer<MultichannelOrderManagerCustomerRelationship> IWhippetRepository<MultichannelOrderManagerCustomerRelationship, Guid>.Get(System.Guid key)
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
        Task<WhippetResultContainer<MultichannelOrderManagerCustomerRelationship>> IWhippetRepository<MultichannelOrderManagerCustomerRelationship, Guid>.GetAsync(Guid key, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
