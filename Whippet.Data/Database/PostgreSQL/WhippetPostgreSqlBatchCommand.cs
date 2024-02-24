using System;
using System.Data;
using System.Data.Common;
using Npgsql;
using StatementType = Npgsql.StatementType;

namespace Athi.Whippet.Data.Database.PostgreSQL
{
    /// <summary>
    /// Represents a single command within a <see cref="WhippetPostgreSqlBatch"/>. A batch can be executed against a data source in a single round trip. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetPostgreSqlBatchCommand : DbBatchCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="NpgsqlBatchCommand"/> object.
        /// </summary>
        private NpgsqlBatchCommand InternalCommand
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the text command to run against the data source.
        /// </summary>
        public override string CommandText
        {
            get
            {
                return InternalCommand.CommandText;
            }
            set
            {
                InternalCommand.CommandText = value;
            }
        }

        /// <summary>
        /// Gets or sets how the <see cref="CommandText"/> property is interpreted.
        /// </summary>
        public override CommandType CommandType
        {
            get
            {
                return InternalCommand.CommandType;
            }
            set
            {
                InternalCommand.CommandType = value;
            }
        }

        /// <summary>
        /// Gets the collection of <see cref="WhippetPostgreSqlParameter"/> objects associated with the batch command. This property is read-only.
        /// </summary>
        protected override DbParameterCollection DbParameterCollection
        {
            get
            {
                return Parameters;
            }
        }
        
        /// <summary>
        /// Gets the collection of <see cref="WhippetPostgreSqlParameter"/> objects associated with the batch command. This property is read-only.
        /// </summary>
        public new WhippetPostgreSqlParameterCollection Parameters
        {
            get
            {
                return InternalCommand.Parameters;
            }
        }

        /// <summary>
        /// Indicates whether the <see cref="CreateParameter"/> method is implemented. This property is read-only.
        /// </summary>
        public new bool CanCreateParameter
        {
            get
            {
                return InternalCommand.CanCreateParameter;
            }
        }

        /// <summary>
        /// Appends an error barrier after this batch command. Defaults to the value of <see cref="WhippetPostgreSqlBatch.EnableErrorBarriers"/> on the batch.
        /// </summary>
        public bool? AppendErrorBarrier
        {
            get
            {
                return InternalCommand.AppendErrorBarrier;
            }
            set
            {
                InternalCommand.AppendErrorBarrier = value;
            }
        }

        /// <summary>
        /// Gets the number of rows affected or retrieved. This property is read-only.
        /// </summary>
        public ulong Rows
        {
            get
            {
                return InternalCommand.Rows;
            }
        }

        /// <summary>
        /// Gets the number of rows changed, inserted, or deleted by execution of this specific <see cref="WhippetPostgreSqlBatchCommand"/>. This property is read-only.
        /// </summary>
        public override int RecordsAffected
        {
            get
            {
                return InternalCommand.RecordsAffected;
            }
        }

        /// <summary>
        /// Indicates the type of query (e.g., SELECT). This property is read-only.
        /// </summary>
        public StatementType StatementType
        {
            get
            {
                return InternalCommand.StatementType;
            }
        }

        /// <summary>
        /// For an INSERT, the object ID of the inserted row if <see cref="RecordsAffected"/> is one (1) and the target table has OIDs; otherwise, zero (0). This property is read-only.
        /// </summary>
        public uint OID
        {
            get
            {
                return InternalCommand.OID;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlBatchCommand"/> class with no arguments.
        /// </summary>
        public WhippetPostgreSqlBatchCommand()
            : this(new NpgsqlBatchCommand())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlBatchCommand"/> class with the specified <see cref="NpgsqlBatchCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="NpgsqlBatchCommand"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetPostgreSqlBatchCommand(NpgsqlBatchCommand command)
            : base()
        {
            ArgumentNullException.ThrowIfNull(command);
            InternalCommand = command;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlBatchCommand"/> class.
        /// </summary>
        /// <param name="commandText">The text of the <see cref="WhippetPostgreSqlBatchCommand"/>.</param>
        public WhippetPostgreSqlBatchCommand(string commandText)
            : this(new NpgsqlBatchCommand(commandText))
        { }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return InternalCommand.ToString();
        }

        public static implicit operator WhippetPostgreSqlBatchCommand(NpgsqlBatchCommand command)
        {
            return (command == null) ? null : new WhippetPostgreSqlBatchCommand(command);
        }

        public static implicit operator NpgsqlBatchCommand(WhippetPostgreSqlBatchCommand command)
        {
            return (command == null) ? null : command.InternalCommand;
        }
    }
}

