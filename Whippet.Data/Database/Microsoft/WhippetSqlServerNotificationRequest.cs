using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sql;

namespace Athi.Whippet.Data.Database.Microsoft
{
    /// <summary>
    /// Represents a request for notification for a given command in SQL Server. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetSqlServerNotificationRequest
    {
        /// <summary>
        /// Gets or sets the internal <see cref="SqlNotificationRequest"/> object.
        /// </summary>
        private SqlNotificationRequest InternalRequest
        { get; set; }

        /// <summary>
        /// Gets or sets the SQL Server Service Broker service name where notification messages are posted.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public string Options
        {
            get
            {
                return InternalRequest.Options;
            }
            set
            {
                InternalRequest.Options = value;
            }
        }

        /// <summary>
        /// Gets or sets a value that specifies how long SQL Server waits for a change to occur before the operation times out.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public int Timeout
        {
            get
            {
                return InternalRequest.Timeout;
            }
            set
            {
                InternalRequest.Timeout = value;
            }
        }

        /// <summary>
        /// Gets or sets an application-specific identifier for this notification.
        /// </summary>
        /// <exception cref="ArgumentException" />
        public string UserData
        {
            get
            {
                return InternalRequest.UserData;
            }
            set
            {
                InternalRequest.UserData = value;
            }
        }

        /// <summary>
        /// Creates a new instance of the <see cref="WhippetSqlServerNotificationRequest"/> class with no arguments.
        /// </summary>
        public WhippetSqlServerNotificationRequest()
            : this(new SqlNotificationRequest())
        { }

        //
        // Summary:
        //     Creates a new instance of the Microsoft.Data.Sql.SqlNotificationRequest class
        //     with a user-defined string that identifies a particular notification request,
        //     the name of a predefined SQL Server 2005 Service Broker service name, and the
        //     time-out period, measured in seconds.
        //
        // Parameters:
        //   userData:
        //     A string that contains an application-specific identifier for this notification.
        //     It is not used by the notifications infrastructure, but it allows you to associate
        //     notifications with the application state. The value indicated in this parameter
        //     is included in the Service Broker queue message.
        //
        //   options:
        //     A string that contains the Service Broker service name where notification messages
        //     are posted, and it must include a database name or a Service Broker instance
        //     GUID that restricts the scope of the service name lookup to a particular database.
        //     For more information about the format of the options parameter, see Microsoft.Data.Sql.SqlNotificationRequest.Options.
        //
        //   timeout:
        //     The time, in seconds, to wait for a notification message.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     The value of the options parameter is NULL.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     The options or userData parameter is longer than uint16.MaxValue or the value
        //     in the timeout parameter is less than zero.
        //
        // Remarks:
        //     ## Remarks This constructor allows you to initialize a new <xref:Microsoft.Data.Sql.SqlNotificationRequest>
        //     instance, providing your own identifier, the SQL Server 2005 Service Broker service
        //     name, and a time-out value.

        /// <summary>
        /// Creates a new instance of the <see cref="WhippetSqlServerNotificationRequest"/> class with a user-defined string that identifies a particular notification request, the name of a predefined SQL Server Service Broker name, and the time-out period measured in seconds.
        /// </summary>
        /// <param name="userData">A string that contains an application-specific identifier for this notification. It is not used by the notifications infrastructure, but it allows you to associate notifications with the application state. The value indicated in this parameter is included in the Service Broker queue message.</param>
        /// <param name="options">A string that contains the Service Broker service name where notification messages are posted, and it must include a database name or a Service Broker instance GUID that restricts the scope of the service name lookup to a particular database.</param>
        /// <param name="timeout">The time, in seconds, to wait for a notification message.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public WhippetSqlServerNotificationRequest(string userData, string options, int timeout)
            : this(new SqlNotificationRequest(userData, options, timeout))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerNotificationRequest"/> class with the specified <see cref="SqlNotificationRequest"/> object.
        /// </summary>
        /// <param name="request"><see cref="SqlNotificationRequest"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetSqlServerNotificationRequest(SqlNotificationRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                InternalRequest = request;
            }
        }

        public static implicit operator WhippetSqlServerNotificationRequest(SqlNotificationRequest request)
        {
            return (request == null) ? null : new WhippetSqlServerNotificationRequest(request);
        }

        public static implicit operator SqlNotificationRequest(WhippetSqlServerNotificationRequest request)
        {
            return (request == null) ? null : request.InternalRequest;
        }
    }
}
