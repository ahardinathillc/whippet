using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using NodaTime;
using Athi.Whippet.Extensions;
using Athi.Whippet.EventManagement;
using Athi.Whippet.Data.Database.Microsoft;
using Athi.Whippet.Localization;

namespace Athi.Whippet.Data.CQRS.SqlServer
{
    /// <summary>
    /// Represents a SQL Server event store for Whippet.
    /// </summary>
    public class SqlServerEventStore : IWhippetDomainEventStore, IWhippetEventStore
    {
        private const string NS = "Athi.Whippet.Data.CQRS.SqlServer.";

        private const string SP_EVENTSTORE_GET_EVENTS_P = "EventStore__get_events_by_aggregate_root_and_sequence_p";
        private const string SP_EVENTSTORE_INSERT_EVENTS_P = "EventStore__insert_event_p";
        private const string SP_EVENTSTORE_GET_EVENTS_TYPE_P = "EventStore__get_events_by_type_p";

        private const string SCRIPT_EVENTSTORE_T = NS + "EventStore_t.sql";
        private const string SCRIPT_EVENTSTORE_GET_EVENTS_P = NS + SP_EVENTSTORE_GET_EVENTS_P + ".sql";
        private const string SCRIPT_EVENTSTORE_INSERT_EVENTS_P = NS + SP_EVENTSTORE_INSERT_EVENTS_P + ".sql";
        private const string SCRIPT_EVENTSTORE_GET_EVENTS_TYPE_P = NS + SP_EVENTSTORE_GET_EVENTS_TYPE_P + ".sql";

        private const string SP_EVENTSTORE_PARAM_AGGREGATEROOTID = "@aggregateRootId";
        private const string SP_EVENTSTORE_PARAM_SEQUENCE = "@sequence";
        private const string SP_EVENTSTORE_PARAM_EVENTTYPE = "@eventType";
        private const string SP_EVENTSTORE_PARAM_DATA = "@data";
        private const string SP_EVENTSTORE_PARAM_DATE = "@eventDate";

        private const string T_EVENTSTORE_COL_EVENTTYPE = "EventType";
        private const string T_EVENTSTORE_COL_DATA = "Data";

        /// <summary>
        /// Gets or sets the <see cref="IWhippetDomainEventSerializer"/>.
        /// </summary>
        protected IWhippetDomainEventSerializer Serializer
        { get; private set; }

        /// <summary>
        /// Gets or sets the SQL Server connection string.
        /// </summary>
        protected string ConnectionString
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerEventStore"/> class with no arguments.
        /// </summary>
        private SqlServerEventStore()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerEventStore"/> class with the specified connection string and serializer.
        /// </summary>
        /// <param name="connectionString">SQL Server connection string.</param>
        /// <param name="serializer"><see cref="IWhippetDomainEventSerializer"/> serializer.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SqlServerEventStore(string connectionString, IWhippetDomainEventSerializer serializer)
            : this()
        {
            if (serializer == null)
            {
                throw new ArgumentNullException(nameof(serializer));
            }
            else if (String.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            else
            {
                Serializer = serializer;
                ConnectionString = connectionString;

                Initialize();
            }
        }

        /// <summary>
        /// Initializes the <see cref="SqlServerEventStore"/> instance.
        /// </summary>
        protected virtual void Initialize()
        {
            WhippetSqlServerConnection sqlConnection = null;
            SqlCommand sqlCommand = null;

            List<string> resourceFiles = new List<string>(new[]
            {
                SCRIPT_EVENTSTORE_T,
                SCRIPT_EVENTSTORE_GET_EVENTS_P,
                SCRIPT_EVENTSTORE_INSERT_EVENTS_P,
                SCRIPT_EVENTSTORE_GET_EVENTS_TYPE_P
            });

            foreach (string resourceFile in resourceFiles)
            {
                try
                {
                    sqlConnection = new WhippetSqlServerConnection(ConnectionString);
                    sqlCommand = sqlConnection.CreateCommand();

                    sqlCommand.CommandText = LocalizedStringResourceLoader.ReadResourceFile(resourceFile);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                finally
                {
                    if (sqlCommand != null)
                    {
                        sqlCommand.Dispose();
                        sqlCommand = null;
                    }

                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        sqlConnection.Dispose();
                        sqlConnection = null;
                    }
                }
            }
        }

        /// <summary>
        /// This method is not supported in this instance.
        /// </summary>
        /// <typeparam name="T">Type of domain events to return.</typeparam>
        /// <param name="filter">Filter to apply to the search query.</param>
        /// <param name="startSequence">Starting sequence in the event queue.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <typeparamref name="T"/> objects.</returns>
        /// <exception cref="NotSupportedException"></exception>
        IEnumerable<T> IWhippetEventStore.GetEvents<T>(Func<T, bool> filter, int startSequence)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Getse all <see cref="WhippetDomainEvent"/> objects that match the specified aggregate root ID.
        /// </summary>
        /// <param name="aggregateRootId">Aggregate root ID.</param>
        /// <param name="startSequence">Starting sequence of the events to start retrieval from.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="WhippetDomainEvent"/> objects.</returns>
        public virtual IEnumerable<WhippetDomainEvent> GetEvents(Guid aggregateRootId, int startSequence)
        {
            List<WhippetDomainEvent> events = new List<WhippetDomainEvent>();

            WhippetSqlServerConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader sqlReader = null;

            SqlParameter p_aggregateRoodId = null;
            SqlParameter p_sequence = null;

            try
            {
                sqlConnection = new WhippetSqlServerConnection(ConnectionString);
                sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = SP_EVENTSTORE_GET_EVENTS_P;
                sqlCommand.CommandType = CommandType.StoredProcedure;

                p_aggregateRoodId = sqlCommand.CreateParameter();
                p_aggregateRoodId.ParameterName = SP_EVENTSTORE_PARAM_AGGREGATEROOTID;
                p_aggregateRoodId.Direction = ParameterDirection.Input;
                p_aggregateRoodId.SqlDbType = SqlDbType.UniqueIdentifier;
                p_aggregateRoodId.Value = aggregateRootId;

                p_sequence = sqlCommand.CreateParameter();
                p_sequence.ParameterName = SP_EVENTSTORE_PARAM_SEQUENCE;
                p_sequence.Direction = ParameterDirection.Input;
                p_sequence.SqlDbType = SqlDbType.Int;
                p_sequence.Value = startSequence;

                sqlCommand.Parameters.AddRange(new[] { p_aggregateRoodId, p_sequence });

                sqlConnection.Open();

                sqlReader = sqlCommand.ExecuteReader();

                while(sqlReader.Read())
                {
                    events.Add(Serializer.Deserialize(Type.GetType(Convert.ToString(sqlReader[T_EVENTSTORE_COL_EVENTTYPE])), Convert.ToString(sqlReader[T_EVENTSTORE_COL_DATA])));
                }
            }
            finally
            {
                if(sqlReader != null)
                {
                    sqlReader.Close();
                    ((IDisposable)(sqlReader)).Dispose();
                    sqlReader = null;
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
            }

            return events.AsReadOnly();
        }

        /// <summary>
        /// Appends the specified <see cref="IEnumerable{T}"/> collection of <see cref="WhippetEvent"/> objects to the store.
        /// </summary>
        /// <param name="wEvents"><see cref="IEnumerable{T}"/> collection of <see cref="WhippetEvent"/> objects to append.</param>
        /// <exception cref="ArgumentNullException" />
        void IWhippetEventStore.Append(IEnumerable<WhippetEvent> wEvents)
        {
            ((IWhippetDomainEventStore)(this)).Append(wEvents);
        }

        /// <summary>
        /// Appends the specified <see cref="IEnumerable{T}"/> collection of <see cref="WhippetEvent"/> objects to the store.
        /// </summary>
        /// <param name="wEvents"><see cref="IEnumerable{T}"/> collection of <see cref="WhippetEvent"/> objects to append.</param>
        /// <exception cref="ArgumentNullException" />
        void IWhippetDomainEventStore.Append(IEnumerable<WhippetEvent> wEvents)
        {
            if (wEvents == null)
            {
                throw new ArgumentNullException(nameof(wEvents));
            }
            else
            {
                List<WhippetDomainEvent> dEvents = new List<WhippetDomainEvent>();

                if (wEvents.Any())
                {
                    foreach (WhippetEvent we in wEvents)
                    {
                        if (we is WhippetDomainEvent)
                        {
                            dEvents.Add((WhippetDomainEvent)(we));
                        }
                    }

                    if (dEvents.Any())
                    {
                        Append(dEvents);
                    }
                }
            }
        }

        /// <summary>
        /// Appends the specified <see cref="IEnumerable{T}"/> collection of <see cref="WhippetDomainEvent"/> objects to the store.
        /// </summary>
        /// <param name="wEvents"><see cref="IEnumerable{T}"/> collection of <see cref="WhippetDomainEvent"/> objects to append.</param>
        /// <exception cref="ArgumentNullException" />
        public virtual void Append(IEnumerable<WhippetDomainEvent> wEvents)
        {
            if(wEvents == null)
            {
                throw new ArgumentNullException(nameof(wEvents));
            }
            else
            {
                WhippetSqlServerConnection sqlConnection = null;
                SqlCommand sqlCommand = null;
                SqlDataReader sqlReader = null;

                SqlParameter p_eventType = null;
                SqlParameter p_aggregateRoodId = null;
                SqlParameter p_eventDate = null;
                SqlParameter p_sequence = null;
                SqlParameter p_data = null;

                string serializedValue = String.Empty;

                foreach (WhippetDomainEvent e in wEvents)
                {
                    try
                    {
                        serializedValue = Serializer.Serialize(e);

                        sqlConnection = new WhippetSqlServerConnection(ConnectionString);
                        sqlCommand = sqlConnection.CreateCommand();

                        sqlCommand.CommandText = SP_EVENTSTORE_INSERT_EVENTS_P;
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        p_aggregateRoodId = sqlCommand.CreateParameter();
                        p_aggregateRoodId.ParameterName = SP_EVENTSTORE_PARAM_AGGREGATEROOTID;
                        p_aggregateRoodId.Direction = ParameterDirection.Input;
                        p_aggregateRoodId.SqlDbType = SqlDbType.UniqueIdentifier;
                        p_aggregateRoodId.Value = e.AggregateRootId;

                        p_sequence = sqlCommand.CreateParameter();
                        p_sequence.ParameterName = SP_EVENTSTORE_PARAM_SEQUENCE;
                        p_sequence.Direction = ParameterDirection.Input;
                        p_sequence.SqlDbType = SqlDbType.Int;
                        p_sequence.Value = e.Sequence;

                        p_eventType = sqlCommand.CreateParameter();
                        p_eventType.ParameterName = SP_EVENTSTORE_PARAM_EVENTTYPE;
                        p_eventType.Direction = ParameterDirection.Input;
                        p_eventType.SqlDbType = SqlDbType.NVarChar;
                        p_eventType.Value = e.GetType().ToFormattedString();

                        p_eventDate = sqlCommand.CreateParameter();
                        p_eventDate.ParameterName = SP_EVENTSTORE_PARAM_DATE;
                        p_eventDate.Direction = ParameterDirection.Input;
                        p_eventDate.SqlDbType = SqlDbType.DateTime;
                        p_eventDate.Value = e.EventDate.ToDateTimeUtc();

                        p_data = sqlCommand.CreateParameter();
                        p_data.ParameterName = SP_EVENTSTORE_PARAM_DATA;
                        p_data.Direction = ParameterDirection.Input;
                        p_data.SqlDbType = SqlDbType.NVarChar;
                        p_data.Value = String.IsNullOrWhiteSpace(serializedValue) ? String.Empty : serializedValue;

                        sqlCommand.Parameters.AddRange(new[] { p_eventType, p_aggregateRoodId, p_eventDate, p_sequence, p_data });

                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                    finally
                    {
                        if (sqlReader != null)
                        {
                            sqlReader.Close();
                            ((IDisposable)(sqlReader)).Dispose();
                            sqlReader = null;
                        }

                        if (sqlCommand != null)
                        {
                            sqlCommand.Dispose();
                            sqlCommand = null;
                        }

                        if (sqlConnection != null)
                        {
                            sqlConnection.Close();
                            sqlConnection.Dispose();
                            sqlConnection = null;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves all <see cref="WhippetDomainEvent"/> objects that are of the specified type.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="WhippetDomainEvent"/> object to return.</typeparam>
        /// <param name="eventTypes"><see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects to filter on.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="WhippetDomainEvent"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual IEnumerable<WhippetDomainEvent> GetEventsByEventTypes(IEnumerable<Type> eventTypes)
        {
            return GetEventsByEventTypes(eventTypes, Guid.Empty);
        }

        /// <summary>
        /// Retrieves all <see cref="WhippetDomainEvent"/> objects that are of the specified type.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="WhippetDomainEvent"/> object to return.</typeparam>
        /// <param name="eventTypes"><see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects to filter on.</param>
        /// <param name="aggregateRootID">Aggregate root ID.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="WhippetDomainEvent"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual IEnumerable<WhippetDomainEvent> GetEventsByEventTypes(IEnumerable<Type> eventTypes, Guid aggregateRootID)
        {
            if (eventTypes == null)
            {
                throw new ArgumentNullException(nameof(eventTypes));
            }
            else
            {
                List<WhippetDomainEvent> events = new List<WhippetDomainEvent>();

                WhippetSqlServerConnection sqlConnection = null;
                SqlCommand sqlCommand = null;
                SqlDataReader sqlReader = null;

                SqlParameter p_eventType = null;
                SqlParameter p_aggregateRoodId = null;

                StringBuilder eventTypeQuery = new StringBuilder();

                foreach (Type type in eventTypes)
                {
                    eventTypeQuery.Append(type.ToFormattedString());
                    eventTypeQuery.Append(',');
                }

                try
                {
                    sqlConnection = new WhippetSqlServerConnection(ConnectionString);
                    sqlCommand = sqlConnection.CreateCommand();

                    sqlCommand.CommandText = SP_EVENTSTORE_GET_EVENTS_TYPE_P;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    p_eventType = sqlCommand.CreateParameter();
                    p_eventType.ParameterName = SP_EVENTSTORE_PARAM_EVENTTYPE;
                    p_eventType.Direction = ParameterDirection.Input;
                    p_eventType.SqlDbType = SqlDbType.NVarChar;
                    p_eventType.Value = eventTypeQuery.ToString();

                    p_aggregateRoodId = sqlCommand.CreateParameter();
                    p_aggregateRoodId.ParameterName = SP_EVENTSTORE_PARAM_AGGREGATEROOTID;
                    p_aggregateRoodId.Direction = ParameterDirection.Input;
                    p_aggregateRoodId.SqlDbType = SqlDbType.UniqueIdentifier;
                    p_aggregateRoodId.Value = aggregateRootID;

                    sqlCommand.Parameters.Add(p_eventType);

                    if (!aggregateRootID.Equals(Guid.Empty))
                    {
                        sqlCommand.Parameters.Add(aggregateRootID);
                    }

                    sqlConnection.Open();

                    sqlReader = sqlCommand.ExecuteReader();

                    while (sqlReader.Read())
                    {
                        events.Add(Serializer.Deserialize(Type.GetType(Convert.ToString(sqlReader[T_EVENTSTORE_COL_EVENTTYPE])), Convert.ToString(sqlReader[T_EVENTSTORE_COL_DATA])));
                    }
                }
                finally
                {
                    if (sqlReader != null)
                    {
                        sqlReader.Close();
                        ((IDisposable)(sqlReader)).Dispose();
                        sqlReader = null;
                    }

                    if (sqlCommand != null)
                    {
                        sqlCommand.Dispose();
                        sqlCommand = null;
                    }

                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        sqlConnection.Dispose();
                        sqlConnection = null;
                    }
                }

                return events.AsReadOnly();
            }
        }

        /// <summary>
        /// Retrieves all <see cref="WhippetDomainEvent"/> objects that are of the specified type.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="WhippetDomainEvent"/> object to return.</typeparam>
        /// <param name="eventTypes"><see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects to filter on.</param>
        /// <param name="startDate">Starting date range to filter the events on.</param>
        /// <param name="endDate">Ending date range to filter the events on.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="WhippetDomainEvent"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual IEnumerable<WhippetDomainEvent> GetEventsByEventTypes(IEnumerable<Type> eventTypes, DateTime startDate, DateTime endDate)
        {
            if (startDate.Kind != DateTimeKind.Utc)
            {
                startDate = startDate.ToUniversalTime();
            }

            if (endDate.Kind != DateTimeKind.Utc)
            {
                endDate = endDate.ToUniversalTime();
            }

            return GetEventsByEventTypes(eventTypes, Instant.FromDateTimeUtc(startDate), Instant.FromDateTimeUtc(endDate));
        }

        /// <summary>
        /// Retrieves all <see cref="WhippetDomainEvent"/> objects that are of the specified type.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="WhippetDomainEvent"/> object to return.</typeparam>
        /// <param name="eventTypes"><see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects to filter on.</param>
        /// <param name="startDate">Starting date range to filter the events on.</param>
        /// <param name="endDate">Ending date range to filter the events on.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="WhippetDomainEvent"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual IEnumerable<WhippetDomainEvent> GetEventsByEventTypes(IEnumerable<Type> eventTypes, Instant startDate, Instant endDate)
        {
            IEnumerable<WhippetDomainEvent> events = GetEventsByEventTypes(eventTypes);

            if ((events != null) && events.Any())
            {
                events = from e in events
                         where e.EventDate >= startDate && e.EventDate <= endDate
                         select e;
            }

            return events;
        }

        /// <summary>
        /// This method is not supported in this instance.
        /// </summary>
        /// <typeparam name="T">Type of domain events to return.</typeparam>
        /// <param name="eventTypes">Event types to filter by.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <typeparamref name="T"/> objects.</returns>
        /// <exception cref="NotSupportedException"></exception>
        IEnumerable<T> IWhippetEventStore.GetEventsByEventTypes<T>(IEnumerable<Type> eventTypes)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported in this instance.
        /// </summary>
        /// <typeparam name="T">Type of domain events to return.</typeparam>
        /// <param name="startDate">Starting date range to filter the events on.</param>
        /// <param name="endDate">Ending date range to filter the events on.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <typeparamref name="T"/> objects.</returns>
        /// <exception cref="NotSupportedException"></exception>
        IEnumerable<T> IWhippetEventStore.GetEventsByEventTypes<T>(IEnumerable<Type> eventTypes, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported in this instance.
        /// </summary>
        /// <typeparam name="T">Type of domain events to return.</typeparam>
        /// <param name="startDate">Starting date range to filter the events on.</param>
        /// <param name="endDate">Ending date range to filter the events on.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <typeparamref name="T"/> objects.</returns>
        /// <exception cref="NotSupportedException"></exception>
        IEnumerable<T> IWhippetEventStore.GetEventsByEventTypes<T>(IEnumerable<Type> eventTypes, Instant startDate, Instant endDate)
        {
            throw new NotImplementedException();
        }
    }
}
