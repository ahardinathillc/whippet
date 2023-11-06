using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using SqlKata.Execution;
using SqlKata.Compilers;
using NHibernateTransaction = NHibernate.ITransaction;
using Athi.Whippet.Data.Database;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Represents a generic repository that is independent of a backing data store. This repository is used for connecting to external data stores that are not contained within Whippet and require extra functionality in order to manipulate data. This class must be inherited.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity stored in the repository.</typeparam>
    /// <typeparam name="TKey">Type of key used to index <typeparamref name="TEntity"/> in the data store.</typeparam>
    public abstract class WhippetExternalEntityRepository<TEntity, TKey> : WhippetRepository<TEntity, TKey>, IWhippetEntityRepository<TEntity, TKey>, IDisposable
        where TEntity: WhippetEntity, IWhippetEntityExternalDataRowImportMapper, new()
        where TKey : struct
    {
        private const int DEFAULT_LIMIT = 1000;

        /// <summary>
        /// Gets the <see cref="IDbConnection"/> instance that provides access to the data store. This property is read-only.
        /// </summary>
        protected virtual IDbConnection Connection
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetExternalEntityRepository{TEntity, TKey}"/> class with no arguments.
        /// </summary>
        private WhippetExternalEntityRepository()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetExternalEntityRepository{TEntity, TKey}"/> class with the specified <see cref="IDbConnection"/> object.
        /// </summary>
        /// <param name="connection"><see cref="IDbConnection"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetExternalEntityRepository(IDbConnection connection)
            : this()
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            else
            {
                Connection = connection;
            }
        }

        /// <summary>
        /// Begins a transaction scope for the current connection.
        /// </summary>
        /// <returns><see cref="IDbTransaction"/> object that represents a handle to the transaction.</returns>
        public virtual IDbTransaction BeginTransaction()
        {
            return Connection.BeginTransaction();
        }

        /// <summary>
        /// Begins a transaction scope for the current connection.
        /// </summary>
        /// <param name="isolationLevel">Isolation level to apply to the transaction.</param>
        /// <returns><see cref="ITransaction"/> object that represents a handle to the transaction.</returns>
        public virtual IDbTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return Connection.BeginTransaction(isolationLevel);
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <returns>Nothing.</returns>
        /// <exception cref="NotImplementedException"></exception>
        NHibernateTransaction IWhippetEntityRepository<TEntity, TKey>.BeginTransaction()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="level">Isolation level of the transaction.</param>
        /// <returns>Nothing.</returns>
        /// <exception cref="NotImplementedException"></exception>
        NHibernateTransaction IWhippetEntityRepository<TEntity, TKey>.BeginTransaction(IsolationLevel level)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <returns>Nothing.</returns>
        /// <exception cref="NotImplementedException"></exception>
        NHibernateTransaction IWhippetEntityRepository<TEntity, TKey>.BeginStatelessTransaction()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="level">Isolation level of the transaction.</param>
        /// <returns>Nothing.</returns>
        /// <exception cref="NotImplementedException"></exception>
        NHibernateTransaction IWhippetEntityRepository<TEntity, TKey>.BeginStatelessTransaction(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Performs a SQL INSERT on the specified <see cref="IWhippetEntity"/>.
        /// </summary>
        /// <param name="item"><see cref="IWhippetEntity"/> to insert into the data store.</param>
        /// <returns><see cref="WhippetResult"/> of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected virtual WhippetResult PerformCreateOperation(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                DataTable itemTable = item.CreateDataTable();
                DataRow row = null;

                IDbCommand command = null;
                IDbDataParameter parameter = null;

                StringBuilder sqlBuilder = new StringBuilder();
                StringBuilder parameterBuilder = new StringBuilder();

                try
                {
                    sqlBuilder.Append("INSERT INTO ");
                    sqlBuilder.Append(DatabaseUtilities.DecorateDbObject(item.ExternalTableName));
                    sqlBuilder.Append("(");

                    foreach (DataColumn column in itemTable.Columns)
                    {
                        sqlBuilder.Append(DatabaseUtilities.DecorateDbObject(column.ColumnName));
                        sqlBuilder.Append(',');

                        parameterBuilder.Append(DatabaseUtilities.DecorateDbParameter(column.ColumnName));
                        parameterBuilder.Append(',');
                    }

                    while (sqlBuilder.ToString().EndsWith(','))
                    {
                        sqlBuilder = sqlBuilder.Remove(sqlBuilder.Length - 1, 1);
                    }

                    while (parameterBuilder.ToString().EndsWith(','))
                    {
                        parameterBuilder = parameterBuilder.Remove(parameterBuilder.Length - 1, 1);
                    }

                    sqlBuilder.Append(") VALUES(");
                    sqlBuilder.Append(parameterBuilder.ToString());
                    sqlBuilder.Append(')');

                    command = Connection.CreateCommand();
                    command.CommandText = sqlBuilder.ToString();

                    row = item.CreateDataRow();

                    foreach (DataColumn column in itemTable.Columns)
                    {
                        parameter = command.CreateParameter();
                        parameter.ParameterName = DatabaseUtilities.DecorateDbParameter(column.ColumnName);
                        parameter.DbType = DatabaseUtilities.ParseType(column);
                        parameter.Direction = ParameterDirection.Input;
                        parameter.Value = DatabaseUtilities.ParseValue(row[column]);

                        command.Parameters.Add(parameter);
                    }

                    Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    result = new WhippetResult(e);
                }
                finally
                {
                    if (command != null)
                    {
                        command.Dispose();
                        command = null;
                    }

                    if (Connection != null)
                    {
                        Connection.Close();
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Performs a SQL DELETE on the specified <see cref="IWhippetEntity"/>.
        /// </summary>
        /// <param name="item"><see cref="IWhippetEntity"/> to delete from the data store.</param>
        /// <param name="itemIdColumn">Column name of the key column to delete the record with.</param>
        /// <param name="itemId">Item ID of the <see cref="TEntity"/> to delete.</param>
        /// <returns><see cref="WhippetResult"/> of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected virtual WhippetResult PerformDeleteOperation(TEntity item, string itemIdColumn, TKey itemId)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else if (String.IsNullOrWhiteSpace(itemIdColumn))
            {
                throw new ArgumentNullException(nameof(itemIdColumn));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                DataTable itemTable = item.CreateDataTable();

                IDbCommand command = null;
                IDbDataParameter parameter = null;

                StringBuilder sqlBuilder = new StringBuilder();
                StringBuilder parameterBuilder = new StringBuilder();

                try
                {
                    sqlBuilder.Append("DELETE FROM ");
                    sqlBuilder.Append(DatabaseUtilities.DecorateDbObject(item.ExternalTableName));
                    sqlBuilder.Append(" WHERE ");
                    sqlBuilder.Append(DatabaseUtilities.DecorateDbObject(itemIdColumn));
                    sqlBuilder.Append('=');
                    sqlBuilder.Append(DatabaseUtilities.DecorateDbParameter(itemIdColumn));

                    command = Connection.CreateCommand();
                    command.CommandText = sqlBuilder.ToString();

                    parameter = command.CreateParameter();
                    parameter.ParameterName = DatabaseUtilities.DecorateDbParameter(itemIdColumn);
                    parameter.DbType = DatabaseUtilities.ParseType(itemTable.Columns[itemIdColumn]);
                    parameter.Direction = ParameterDirection.Input;
                    parameter.Value = DatabaseUtilities.ParseValue(itemId);

                    command.Parameters.Add(parameter);

                    Connection.Open();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    result = new WhippetResult(e);
                }
                finally
                {
                    if (command != null)
                    {
                        command.Dispose();
                        command = null;
                    }

                    if (Connection != null)
                    {
                        Connection.Close();
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Performs a SQL UPDATE on the specified <see cref="IWhippetEntity"/>.
        /// </summary>
        /// <param name="item"><see cref="IWhippetEntity"/> to update in the data store.</param>
        /// <param name="itemIdColumn">Column name of the key column to update the record with.</param>
        /// <param name="itemId">Item ID of the <see cref="TEntity"/> to update.</param>
        /// <returns><see cref="WhippetResult"/> of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected virtual WhippetResult PerformUpdateOperation(TEntity item, string itemIdColumn, TKey itemId)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                DataTable itemTable = item.CreateDataTable();
                DataRow row = null;

                IDbCommand command = null;
                IDbDataParameter parameter = null;

                StringBuilder sqlBuilder = new StringBuilder();
                StringBuilder parameterBuilder = new StringBuilder();

                try
                {
                    sqlBuilder.Append("UPDATE ");
                    sqlBuilder.Append(DatabaseUtilities.DecorateDbObject(item.ExternalTableName));
                    sqlBuilder.Append(" SET ");

                    foreach (DataColumn column in itemTable.Columns)
                    {
                        sqlBuilder.Append(DatabaseUtilities.DecorateDbObject(column.ColumnName));
                        sqlBuilder.Append('=');
                        sqlBuilder.Append(DatabaseUtilities.DecorateDbParameter(column.ColumnName));
                        sqlBuilder.Append(',');
                    }

                    while (sqlBuilder.ToString().EndsWith(','))
                    {
                        sqlBuilder = sqlBuilder.Remove(sqlBuilder.Length - 1, 1);
                    }

                    sqlBuilder.Append(" WHERE ");
                    sqlBuilder.Append(DatabaseUtilities.DecorateDbObject(itemIdColumn));
                    sqlBuilder.Append('=');
                    sqlBuilder.Append(DatabaseUtilities.DecorateDbParameter(itemIdColumn));

                    command = Connection.CreateCommand();
                    command.CommandText = sqlBuilder.ToString();

                    row = item.CreateDataRow();

                    foreach (DataColumn column in itemTable.Columns)
                    {
                        parameter = command.CreateParameter();
                        parameter.ParameterName = DatabaseUtilities.DecorateDbParameter(column.ColumnName);
                        parameter.DbType = DatabaseUtilities.ParseType(column);
                        parameter.Direction = ParameterDirection.Input;
                        parameter.Value = DatabaseUtilities.ParseValue(row[column]);

                        command.Parameters.Add(parameter);
                    }

                    Connection.Open();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    result = new WhippetResult(e);
                }
                finally
                {
                    if (command != null)
                    {
                        command.Dispose();
                        command = null;
                    }

                    if (Connection != null)
                    {
                        Connection.Close();
                    }
                }

                return result;
            }
        }



        /// <summary>
        /// Creates a new instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to save in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        public override WhippetResult Create(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                return PerformCreateOperation(item);
            }
        }

        /// <summary>
        /// Asynchronously creates a new instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to save in the data store.</param>
        /// <param name="cancellationToken">Flag to signal to the <see cref="Task{TResult}"/> to stop at the next earliest convenience.</param>
        /// <returns><see cref="Task{TResult}"/> object which contains the result of the domain object operation stored in a <see cref="WhippetResult"/>.</returns>
        public override Task<WhippetResult> CreateAsync(TEntity item, CancellationToken? cancellationToken = null)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                return Task.Run(() => Create(item));
            }
        }

        /// <summary>
        /// Updates an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to update in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="DataTablePrimaryKeyNotFoundException" />
        /// <exception cref="CompositeKeyException" />
        public override WhippetResult Update(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                DataTable itemTable = item.CreateDataTable();
                DataRow row = item.CreateDataRow();

                DataColumn[] primaryKeys = itemTable.PrimaryKey;

                if (primaryKeys == null)
                {
                    throw new DataTablePrimaryKeyNotFoundException();
                }
                else if (primaryKeys.Length > 1)
                {
                    throw new CompositeKeyException();
                }
                else
                {
                    return Update(item, primaryKeys[0].ColumnName, (TKey)(row[primaryKeys[0]]));
                }
            }
        }

        /// <summary>
        /// Updates an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to update in the data store.</param>
        /// <param name="itemIdColumn">Column name of the key column to update the record with.</param>
        /// <param name="itemId">Item ID of the <see cref="TEntity"/> to update.</param>
        /// <returns><see cref="WhippetResult"/> of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual WhippetResult Update(TEntity item, string itemIdColumn, TKey itemId)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else if (String.IsNullOrWhiteSpace(itemIdColumn))
            {
                throw new ArgumentNullException(nameof(itemIdColumn));
            }
            else
            {
                return PerformUpdateOperation(item, itemIdColumn, itemId);
            }
        }

        /// <summary>
        /// Asynchronously updates an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to update in the data store.</param>
        /// <returns><see cref="Task{TResult}"/> object which contains the result of the domain object operation stored in a <see cref="WhippetResult"/>.</returns>
        public override Task<WhippetResult> UpdateAsync(TEntity item, CancellationToken? cancellationToken = null)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                return Task.Run(() => Update(item)).WaitAsync(cancellationToken.GetValueOrDefault());
            }
        }

        /// <summary>
        /// Asynchronously updates an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to update in the data store.</param>
        /// <param name="itemIdColumn">Column name of the key column to update the record with.</param>
        /// <param name="itemId">Item ID of the <see cref="TEntity"/> to update.</param>
        /// <returns><see cref="Task{TResult}"/> object which contains the result of the domain object operation stored in a <see cref="WhippetResult"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual Task<WhippetResult> UpdateAsync(TEntity item, string itemIdColumn, TKey itemId, CancellationToken? cancellationToken = null)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else if (String.IsNullOrWhiteSpace(itemIdColumn))
            {
                throw new ArgumentNullException(nameof(itemIdColumn));
            }
            else
            {
                return Task.Run(() => PerformUpdateOperation(item, itemIdColumn, itemId)).WaitAsync(cancellationToken.GetValueOrDefault());
            }
        }

        /// <summary>
        /// Deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to delete in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="DataTablePrimaryKeyNotFoundException" />
        /// <exception cref="CompositeKeyException" />
        public override WhippetResult Delete(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                DataTable itemTable = item.CreateDataTable();
                DataRow row = item.CreateDataRow();

                DataColumn[] primaryKeys = itemTable.PrimaryKey;

                WhippetResult result = WhippetResult.Success;

                if (primaryKeys == null)
                {
                    throw new DataTablePrimaryKeyNotFoundException();
                }
                else if (primaryKeys.Length > 1)
                {
                    throw new CompositeKeyException();
                }
                else
                {
                    if (item is IWhippetSoftDeleteEntity)
                    {
                        ((IWhippetSoftDeleteEntity)(item)).Deleted = true;

                        if (item is IWhippetActiveEntity)
                        {
                            ((IWhippetActiveEntity)(item)).Active = false;
                        }

                        result = Update(item);
                    }
                    else
                    {
                        result = Delete(item, primaryKeys[0].ColumnName, (TKey)(row[primaryKeys[0]]));
                    }

                    return result;
                }
            }
        }

        /// <summary>
        /// Deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to delete in the data store.</param>
        /// <param name="itemIdColumn">Column name of the key column to delete the record with.</param>
        /// <param name="itemId">Item ID of the <see cref="TEntity"/> to delete.</param>
        /// <returns><see cref="WhippetResult"/> of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual WhippetResult Delete(TEntity item, string itemIdColumn, TKey itemId)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else if (String.IsNullOrWhiteSpace(itemIdColumn))
            {
                throw new ArgumentNullException(nameof(itemIdColumn));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                if (item is IWhippetSoftDeleteEntity)
                {
                    ((IWhippetSoftDeleteEntity)(item)).Deleted = true;

                    if (item is IWhippetActiveEntity)
                    {
                        ((IWhippetActiveEntity)(item)).Active = false;
                    }

                    result = Update(item, itemIdColumn, itemId);
                }
                else
                {
                    result = PerformDeleteOperation(item, itemIdColumn, itemId);
                }

                return result;
            }
        }

        /// <summary>
        /// Asynchronously deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to delete in the data store.</param>
        /// <returns><see cref="Task{TResult}"/> object which contains the result of the domain object operation stored in a <see cref="WhippetResult"/>.</returns>
        public override Task<WhippetResult> DeleteAsync(TEntity item, CancellationToken? cancellationToken = null)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                return Task.Run(() => Delete(item)).WaitAsync(cancellationToken.GetValueOrDefault());
            }
        }

        /// <summary>
        /// Asynchronously deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to delete in the data store.</param>
        /// <param name="itemIdColumn">Column name of the key column to delete the record with.</param>
        /// <param name="itemId">Item ID of the <see cref="TEntity"/> to delete.</param>
        /// <returns><see cref="Task{TResult}"/> object which contains the result of the domain object operation stored in a <see cref="WhippetResult"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual Task<WhippetResult> DeleteAsync(TEntity item, string itemIdColumn, TKey itemId, CancellationToken? cancellationToken = null)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else if (String.IsNullOrWhiteSpace(itemIdColumn))
            {
                throw new ArgumentNullException(nameof(itemIdColumn));
            }
            else
            {
                return Task.Run(() => PerformDeleteOperation(item, itemIdColumn, itemId));
            }
        }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="DataTablePrimaryKeyNotFoundException"></exception>
        /// <exception cref="CompositeKeyException"></exception>
        public override WhippetResultContainer<TEntity> Get(TKey key)
        {
            return GetSingle(key);
        }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <param name="ignoreColumns">Columns to ignore when building the query.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="DataTablePrimaryKeyNotFoundException"></exception>
        /// <exception cref="CompositeKeyException"></exception>
        protected virtual WhippetResultContainer<TEntity> GetSingle(object key, params string[] ignoreColumns)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            else
            {
                WhippetResultContainer<TEntity> result = null;

                DataTable itemTable = null;
                DataColumn[] primaryKeys = null;
                DataRow row = null;

                WhippetDataRowImportMap map = null;
                
                TEntity item = new TEntity();

                IDbCommand command = null;
                IDbDataParameter parameter = null;
                IDataReader reader = null;

                StringBuilder sqlBuilder = new StringBuilder();
                StringBuilder parameterBuilder = new StringBuilder();

                bool ignoreColumn = false;

                object defaultValue = DBNull.Value;
                
                itemTable = item.CreateDataTable();

                primaryKeys = itemTable.PrimaryKey;

                map = item.CreateImportMap();

                if (primaryKeys == null || (primaryKeys.Length == 0))
                {
                    throw new DataTablePrimaryKeyNotFoundException();
                }
                else if (primaryKeys.Length > 1)
                {
                    throw new CompositeKeyException();
                }
                else
                {
                    try
                    {
                        sqlBuilder.Append("SELECT ");

                        foreach (DataColumn column in itemTable.Columns)
                        {
                            ignoreColumn = false;
                            
                            if (ignoreColumns != null && ignoreColumns.Length > 0)
                            {
                                foreach (string ic in ignoreColumns)
                                {
                                    if (String.Equals(ic, column.ColumnName, StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        ignoreColumn = true;
                                        break;
                                    }
                                }
                            }

                            if (ignoreColumn)
                            {
                                continue;
                            }
                            else
                            {
                                sqlBuilder.Append(DatabaseUtilities.DecorateDbObject(column.ColumnName));
                                sqlBuilder.Append(',');
                            }
                        }

                        while (sqlBuilder.ToString().EndsWith(','))
                        {
                            sqlBuilder = sqlBuilder.Remove(sqlBuilder.Length - 1, 1);
                        }
                        
                        sqlBuilder.Append(" FROM ");
                        sqlBuilder.Append(DatabaseUtilities.DecorateDbObject(item.ExternalTableName));
                        sqlBuilder.Append(" ");
                        sqlBuilder.Append(DatabaseUtilities.DecorateDbObject(DatabaseUtilities.GenerateTableShortName()));
                        sqlBuilder.Append(" ");
                        sqlBuilder.Append(" WHERE ");
                        sqlBuilder.Append(DatabaseUtilities.DecorateDbObject(primaryKeys[0].ColumnName));
                        sqlBuilder.Append('=');
                        sqlBuilder.Append(DatabaseUtilities.DecorateDbParameter(primaryKeys[0].ColumnName));

                        command = Connection.CreateCommand();
                        command.CommandText = sqlBuilder.ToString();

                        parameter = command.CreateParameter();
                        parameter.ParameterName = DatabaseUtilities.DecorateDbParameter(primaryKeys[0].ColumnName);
                        parameter.DbType = DatabaseUtilities.ParseType(key.GetType());
                        parameter.Direction = ParameterDirection.Input;
                        parameter.Value = DatabaseUtilities.ParseValue(key);

                        command.Parameters.Add(parameter);

                        Connection.Open();

                        reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            row = itemTable.NewRow();

                            foreach (WhippetDataRowImportMapEntry entry in ((IEnumerable<WhippetDataRowImportMapEntry>)(map)))
                            {
                                ignoreColumn = false;
                                
                                if (ignoreColumns != null && ignoreColumns.Length > 0)
                                {
                                    foreach (string ic in ignoreColumns)
                                    {
                                        if (String.Equals(ic, entry.Column, StringComparison.InvariantCultureIgnoreCase))
                                        {
                                            ignoreColumn = true;
                                            break;
                                        }
                                    }
                                }

                                if (!ignoreColumn)
                                {
                                    row[entry.Column] = reader[entry.Column];
                                }
                                else
                                {
                                    defaultValue = Activator.CreateInstance(itemTable.Columns[entry.Column].DataType);

                                    if (defaultValue == null)
                                    {
                                        defaultValue = DBNull.Value;
                                    }

                                    row[entry.Column] = defaultValue;
                                }
                            }
                        }

                        if (row != null)
                        {
                            item.ImportDataRow(row);
                        }
                        else
                        {
                            item = null;
                        }

                        result = new WhippetResultContainer<TEntity>(WhippetResult.Success, item);
                    }
                    catch (Exception e)
                    {
                        result = new WhippetResultContainer<TEntity>(new WhippetResult(e), null);
                    }
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close();
                            reader.Dispose();
                            reader = null;
                        }

                        if (command != null)
                        {
                            command.Dispose();
                            command = null;
                        }

                        if (Connection != null)
                        {
                            Connection.Close();
                        }
                    }

                    return result;
                }
            }
        }

        /// <summary>
        /// Retrieves all items of <typeparamref name="TEntity"/> type in the data store.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding items (if any).</returns>
        public override WhippetResultContainer<IEnumerable<TEntity>> GetAll()
        {
            return GetAll(DEFAULT_LIMIT);
        }

        /// <summary>
        /// Retrieves all items of <typeparamref name="TEntity"/> type in the data store.
        /// </summary>
        /// <param name="limit">Maximum number of records to retrieve. Values less than one will be treated as unlimited.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding items (if any).</returns>
        /// <exception cref="DataTablePrimaryKeyNotFoundException"></exception>
        /// <exception cref="CompositeKeyException"></exception>
        protected virtual WhippetResultContainer<IEnumerable<TEntity>> GetAll(int limit)
        {
            WhippetResultContainer<IEnumerable<TEntity>> result = null;

            DataTable itemTable = null;

            TEntity item = new TEntity();

            itemTable = item.CreateDataTable();

            DataColumn[] primaryKeys = itemTable.PrimaryKey;

            DataRow row = null;

            WhippetDataRowImportMap map = item.CreateImportMap();

            IDbCommand command = null;
            IDataReader reader = null;

            StringBuilder sqlBuilder = new StringBuilder();
            StringBuilder parameterBuilder = new StringBuilder();

            List<TEntity> entities = null;

            IDictionary<Guid, IDictionary<string, object>> readerValues = null;

            Guid recordId;

            if (primaryKeys == null)
            {
                throw new DataTablePrimaryKeyNotFoundException();
            }
            else if (primaryKeys.Length > 1)
            {
                throw new CompositeKeyException();
            }
            else
            {
                try
                {
                    sqlBuilder.Append("SELECT ");

                    if (limit >= 1)
                    {
                        sqlBuilder.Append("TOP " + limit + " ");
                    }

                    foreach (DataColumn column in itemTable.Columns)
                    {
                        sqlBuilder.Append(DatabaseUtilities.DecorateDbObject(column.ColumnName));
                        sqlBuilder.Append(',');
                    }

                    while (sqlBuilder.ToString().EndsWith(','))
                    {
                        sqlBuilder = sqlBuilder.Remove(sqlBuilder.Length - 1, 1);
                    }

                    sqlBuilder.Append(" FROM ");
                    sqlBuilder.Append(DatabaseUtilities.DecorateDbObject(item.ExternalTableName));
                    sqlBuilder.Append(" ");
                    sqlBuilder.Append(DatabaseUtilities.DecorateDbObject(DatabaseUtilities.GenerateTableShortName()));

                    command = Connection.CreateCommand();
                    command.CommandText = sqlBuilder.ToString();

                    readerValues = new Dictionary<Guid, IDictionary<string, object>>();

                    Connection.Open();

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        recordId = Guid.NewGuid();
                        readerValues.Add(recordId, new Dictionary<string, object>());

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            readerValues[recordId].Add(reader.GetName(i), reader.GetValue(i));
                        }
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<TEntity>>(new WhippetResult(e), null);
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                        reader.Dispose();
                        reader = null;
                    }

                    if (command != null)
                    {
                        command.Dispose();
                        command = null;
                    }

                    if (Connection != null)
                    {
                        Connection.Close();
                    }
                }

                // result is null means that we didn't encounter an exception, so we can process the results
                if (result == null)
                {
                    if (readerValues.Any())
                    {
                        entities = new List<TEntity>(readerValues.Count);

                        foreach (KeyValuePair<Guid, IDictionary<string, object>> value in readerValues)
                        {
                            item = new TEntity();

                            row = itemTable.NewRow();

                            foreach (string columnName in value.Value.Keys)
                            {
                                row[columnName] = value.Value[columnName];
                            }

                            item.ImportDataRow(row);
                            entities.Add(item);
                        }
                    }

                    result = new WhippetResultContainer<IEnumerable<TEntity>>(WhippetResult.Success, entities);
                }

                return result;
            }
        }

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override Task<WhippetResultContainer<TEntity>> GetAsync(TKey key, CancellationToken? cancellationToken = null)
        {
            return Task.Run(() => Get(key)).WaitAsync(cancellationToken.GetValueOrDefault());
        }

        /// <summary>
        /// Asynchronously retrieves all items of <typeparamref name="TEntity"/> type in the data store.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override Task<WhippetResultContainer<IEnumerable<TEntity>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            return Task.Run(() => GetAll()).WaitAsync(cancellationToken.GetValueOrDefault());
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            if (Connection != null)
            {
                Connection.Close();
                Connection.Dispose();
                Connection = null;
            }
        }

        /// <summary>
        /// Commits all changes to the data store for underlying data stores that perform change queries in batches. This method is not implemented.
        /// </summary>
        /// <exception cref="NotImplementedException" />
        public override void Commit()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Commits all changes to the data store for underlying data stores that perform change queries in batches.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        /// <exception cref="NotImplementedException" />
        public override Task CommitAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates an <see cref="IEnumerable{T}"/> collection of <typeparamref name="TEntity"/> objects from the specified <see langword="dynamic"/> result set. This method must be overridden.
        /// </summary>
        /// <param name="resultSet"><see cref="IEnumerable{T}"/> result set of <see langword="dynamic"/> objects.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <typeparamref name="TEntity"/> objects.</returns>
        [Obsolete("This method has been deprecated. Use ImportFromDynamicResultSetAsync instead.", false)]
        protected virtual IEnumerable<TEntity> ImportFromDynamicResultSet(IEnumerable<dynamic> resultSet)
        {
            return Task.Run(() => ImportFromDynamicResultSetAsync(resultSet)).Result;
        }

        /// <summary>
        /// Creates an <see cref="IEnumerable{T}"/> collection of <typeparamref name="TEntity"/> objects from the specified <see langword="dynamic"/> result set. This method must be overridden.
        /// </summary>
        /// <param name="resultSet"><see cref="IEnumerable{T}"/> result set of <see langword="dynamic"/> objects.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected abstract Task<IEnumerable<TEntity>> ImportFromDynamicResultSetAsync(IEnumerable<dynamic> resultSet, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="entity">Entity to refresh.</param>
        void IWhippetRepository<TEntity, TKey>.RefreshEntityContext(TEntity entity)
        { }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="entity">Entity to refresh.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        async Task IWhippetRepository<TEntity, TKey>.RefreshEntityContextAsync(TEntity entity, CancellationToken? cancellationToken)
        {
            await Task.Run(() =>
            {
                return;
            });
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="entity">Entity to refresh.</param>
        public override void RefreshEntityContext(TEntity entity)
        { }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="entity">Entity to refresh.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        public override async Task RefreshEntityContextAsync(TEntity entity, CancellationToken? cancellationToken = null)
        {
            await Task.Run(() =>
            {
                return;
            });
        }
    }
}
