using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Persister.Entity;

namespace Athi.Whippet.Data.NHibernate.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ISession"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ISessionExtensions
    {
        /// <summary>
        /// Gets the mapped column of the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">Entity to get column for.</typeparam>
        /// <param name="session"><see cref="ISession"/> object.</param>
        /// <param name="property">Name of the column to get.</param>
        /// <returns>Column name.</returns>
        /// <remarks>See <a href="https://iarovyi.com/2017/10/03/safe-raw-sql-queries-with-nhibernate/">Safe raw SQL queries with NHibernate</a> for more information.</remarks>
        public static string Column<TEntity>(this ISession session, Expression<Func<TEntity, object>> property) =>
            ((AbstractEntityPersister)session.SessionFactory.GetClassMetadata(typeof(TEntity)))
            .GetPropertyColumnNames(property.GetName())
            .Single();

        /// <summary>
        /// Gets the table of the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">Entity to get table for.</typeparam>
        /// <param name="session"><see cref="ISession"/> object.</param>
        /// <returns>Table name.</returns>
        /// <remarks>See <a href="https://iarovyi.com/2017/10/03/safe-raw-sql-queries-with-nhibernate/">Safe raw SQL queries with NHibernate</a> for more information.</remarks>
        public static string Table<TEntity>(this ISession session) =>
            ((ILockable)session.GetSessionImplementation()
                .GetEntityPersister(null, Activator.CreateInstance(typeof(TEntity), true)))
            .RootTableName;

        /// <summary>
        /// Gets the name of the property for the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">Entity to get property name for.</typeparam>
        /// <param name="property">Property expression to parse.</param>
        /// <returns>Property name or value.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <remarks>See <a href="https://iarovyi.com/2017/10/03/safe-raw-sql-queries-with-nhibernate/">Safe raw SQL queries with NHibernate</a> for more information.</remarks>
        private static string GetName<TEntity>(this Expression<Func<TEntity, object>> property)
        {
            var memberExpression = property.Body as MemberExpression
                                   ?? ((UnaryExpression)property.Body).Operand as MemberExpression;

            return memberExpression?.Member.Name ?? throw new ArgumentException(nameof(property));
        }

        /// <summary>
        /// Executes a raw SQL UPDATE or DELETE statement against the specified context.
        /// </summary>
        /// <param name="session"><see cref="ISession"/> object representing the context in which the query should take place.</param>
        /// <param name="query">Query to execute.</param>
        /// <param name="parameters">Parameters to load in the query.</param>
        /// <returns>Number of rows updated.</returns>
        /// <exception cref="ArgumentNullException" />
        public static int ExecuteRawUpdate(this ISession session, string query, IDictionary<string, object> parameters = null)
        {
            ArgumentNullException.ThrowIfNull(session);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(query);

            return Task.Run(() => ExecuteRawUpdateAsync(session, query, parameters)).Result;
        }

        /// <summary>
        /// Executes a raw SQL UPDATE or DELETE statement against the specified context.
        /// </summary>
        /// <param name="session"><see cref="ISession"/> object representing the context in which the query should take place.</param>
        /// <param name="query">Query to execute.</param>
        /// <param name="parameters">Parameters to load in the query.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Number of rows updated.</returns>
        /// <exception cref="ArgumentNullException" />
        public static async Task<int> ExecuteRawUpdateAsync(this ISession session, string query, IDictionary<string, object> parameters = null, CancellationToken? cancellationToken = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            else if (String.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                DbConnection connection = session.Connection;
                DbCommand command = connection.CreateCommand();
                DbParameter param = null;

                bool closeConnection = true;

                int rowsUpdated = 0;

                command.CommandText = query;
                command.CommandType = CommandType.Text;

                if (parameters != null)
                {
                    foreach (KeyValuePair<string, object> p in parameters)
                    {
                        param = command.CreateParameter();
                        param.ParameterName = p.Key;
                        param.Value = p.Value;

                        command.Parameters.Add(param);
                    }
                }

                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        //connection.Open();

                        if (cancellationToken.HasValue)
                        {
                            await connection.OpenAsync(cancellationToken.Value);
                        }
                        else
                        {
                            await connection.OpenAsync();
                        }
                    }
                    else
                    {
                        closeConnection = false;
                    }

                    if (cancellationToken.HasValue)
                    {
                        rowsUpdated = await command.ExecuteNonQueryAsync();
                    }
                    else
                    {
                        rowsUpdated = await command.ExecuteNonQueryAsync(cancellationToken.GetValueOrDefault());
                    }
                }
                finally
                {
                    if (closeConnection)
                    {
                        await connection.CloseAsync();
                    }

                    if (command != null)
                    {
                        await command.DisposeAsync();
                        command = null;
                    }
                }

                return rowsUpdated;
            }
        }
    }
}
