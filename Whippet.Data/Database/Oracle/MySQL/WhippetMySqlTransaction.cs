using System;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Athi.Whippet.Data.Database.Oracle.MySQL
{
    /// <summary>
    /// Represents a SQL transaction to be made in a MySQL database. This class cannot be inherited.
    /// </summary>
    public class WhippetMySqlTransaction : DbTransaction, IDisposable
    {
        /// <summary>
        /// Gets or sets the internal <see cref="MySqlTransaction"/> object.
        /// </summary>
        private MySqlTransaction InternalTransaction
        { get; set; }

        /// <summary>
        /// Gets the <see cref="WhippetMySqlConnection"/> object associated with the transaction or <see langword="null"/> if the transaction is no longer valid. This property is read-only.
        /// </summary>
        public new WhippetMySqlConnection Connection
        {
            get
            {
                return InternalTransaction.Connection;
            }
        }

        /// <summary>
        /// Gets the <see cref="WhippetMySqlConnection"/> object associated with the transaction or <see langword="null"/> if the transaction is no longer valid. This property is read-only.
        /// </summary>
        protected override DbConnection DbConnection
        {
            get
            {
                return Connection;
            }
        }

        /// <summary>
        /// Gets the isolation level for the transaction. This property is read-only.
        /// </summary>
        public override IsolationLevel IsolationLevel
        {
            get
            {
                return InternalTransaction.IsolationLevel;
            }
        }

        /// <summary>
        /// Indicates whether this <see cref="DbTransaction"/> instance supports database savepoints. This property is read-only.
        /// </summary>
        public override bool SupportsSavepoints
        {
            get
            {
                return InternalTransaction.SupportsSavepoints;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlTransaction"/> class with the specified <see cref="MySqlTransaction"/> object.
        /// </summary>
        /// <param name="transaction"><see cref="MySqlTransaction"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetMySqlTransaction(MySqlTransaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }
            else
            {
                InternalTransaction = transaction;
            }
        }

        /// <summary>
        /// Commits the database transaction.
        /// </summary>
        /// <exception cref="Exception" />
        /// <exception cref="InvalidOperationException" />
        public override void Commit()
        {
            InternalTransaction.Commit();
        }

        /// <summary>
        /// Asynchronously commits the database transaction.
        /// </summary>
        /// <param name="cancellationToken">An optional token to cancel the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public override Task CommitAsync(CancellationToken cancellationToken = default)
        {
            return InternalTransaction.CommitAsync(cancellationToken);
        }

        /// <summary>
        /// Releases the unmanaged resources used and optionally releases the managed resources.
        /// </summary>
        public new void Dispose()
        {
            InternalTransaction.Dispose();
        }

        /// <summary>
        /// Asynchronously releases the unmanaged resources used and optionally releases the managed resources.
        /// </summary>
        /// <returns>A <see cref="ValueTask"/> representing the asynchronous transaction.</returns>
        public override ValueTask DisposeAsync()
        {
            return InternalTransaction.DisposeAsync();
        }

        /// <summary>
        /// Releases the unmanaged resources used and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing"><see langword="true"/> to signal that the object is being disposed; otherwise, <see langword="false"/>.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                InternalTransaction.Dispose();
            }
        }

        /// <summary>
        /// Rolls back a transaction from a pending state.
        /// </summary>
        public override void Rollback()
        {
            InternalTransaction.Rollback();
        }

        /// <summary>
        /// Rolls back a transaction from a pending state.
        /// </summary>
        /// <param name="transactionName">Name of the transaction to roll back.</param>
        /// <exception cref="Exception" />
        /// <exception cref="InvalidOperationException" />
        public new void Rollback(string transactionName)
        {
            InternalTransaction.Rollback(transactionName);
        }

        /// <summary>
        /// Rolls back a transaction from a pending state.
        /// </summary>
        /// <param name="savepointName">The name of the savepoint to roll back to.</param>
        /// <param name="cancellationToken">An optional token to cancel the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public override Task RollbackAsync(string savepointName, CancellationToken cancellationToken = default)
        {
            return InternalTransaction.RollbackAsync(savepointName, cancellationToken);
        }

        /// <summary>
        /// Rolls back a transaction from a pending state.
        /// </summary>
        /// <param name="cancellationToken">An optional token to cancel the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public override Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            return base.RollbackAsync(cancellationToken);
        }

        /// <summary>
        /// Creates a savepoint in the transaction that can be used to roll back a part of the transaction and specifies the savepoint name.
        /// </summary>
        /// <param name="savePointName">The name of the savepoint.</param>
        /// <exception cref="Exception" />
        /// <exception cref="InvalidOperationException" />
        public new void Save(string savePointName)
        {
            InternalTransaction.Save(savePointName);
        }

        /// <summary>
        /// Creates a savepoint in the transaction that can be used to roll back a part of the transaction and specifies the savepoint name.
        /// </summary>
        /// <param name="savepointName">The name of the savepoint.</param>
        /// <param name="cancellationToken">An optional token to cancel the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public override Task SaveAsync(string savepointName, CancellationToken cancellationToken = default)
        {
            return base.SaveAsync(savepointName, cancellationToken);
        }

        /// <summary>
        /// Destroys a savepoint previously defined in the current transaction. This allows the system to reclaim some resources before the transaction ends.
        /// </summary>
        /// <param name="savepointName">The name of the savepoint to release.</param>
        public override void Release(string savepointName)
        {
            InternalTransaction.Release(savepointName);
        }

        /// <summary>
        /// Destroys a savepoint previously defined in the current transaction. This allows the system to reclaim some resources before the transaction ends.
        /// </summary>
        /// <param name="savepointName">The name of the savepoint to release.</param>
        /// <param name="cancellationToken">An optional token to cancel the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public override Task ReleaseAsync(string savepointName, CancellationToken cancellationToken = default)
        {
            return InternalTransaction.ReleaseAsync(savepointName, cancellationToken);
        }

        public static implicit operator WhippetMySqlTransaction(MySqlTransaction transaction)
        {
            return (transaction == null) ? null : new WhippetMySqlTransaction(transaction);
        }

        public static implicit operator MySqlTransaction(WhippetMySqlTransaction transaction)
        {
            return (transaction == null) ? null : transaction.InternalTransaction;
        }
    }
}
