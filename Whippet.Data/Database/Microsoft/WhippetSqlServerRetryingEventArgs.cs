using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Athi.Whippet.Data.Database.Microsoft
{
    /// <summary>
    /// Represents the set of arguments passed to the <see cref="WhippetSqlServerRetryLogicBaseProviderBase.Retrying"/> event. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetSqlServerRetryingEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the internal <see cref="SqlRetryingEventArgs"/> object.
        /// </summary>
        private SqlRetryingEventArgs InternalArgs
        { get; set; }

        /// <summary>
        /// Retry attempt number after the first exception occurrence. This property is read-only.
        /// </summary>
        public int RetryCount
        {
            get
            {
                return InternalArgs.RetryCount;
            }
        }

        /// <summary>
        /// Gets the current waiting time. This property is read-only.
        /// </summary>
        public TimeSpan Delay
        {
            get
            {
                return InternalArgs.Delay;
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether the retry logic should be canceled.
        /// </summary>
        public bool Cancel
        {
            get
            {
                return InternalArgs.Cancel;
            }
            set
            {
                InternalArgs.Cancel = value;
            }
        }

        /// <summary>
        /// Gets the list of exceptions since the first attempt failure. This property is read-only.
        /// </summary>
        public IList<Exception> Exceptions
        {
            get
            {
                return InternalArgs.Exceptions;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerRetryingEventArgs"/> class with the specified <see cref="SqlRetryingEventArgs"/> object.
        /// </summary>
        /// <param name="args"><see cref="SqlRetryingEventArgs"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetSqlServerRetryingEventArgs(SqlRetryingEventArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }
            else
            {
                InternalArgs = args;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerRetryingEventArgs"/> class.
        /// </summary>
        /// <param name="retryCount">The current retry attempt count.</param>
        /// <param name="delay">The delay that indicates how long the current thread will be suspended before the next iteration is invoked.</param>
        /// <param name="exceptions">The list of exceptions since the first retry that caused the retry logic to re-execute the function.</param>
        public WhippetSqlServerRetryingEventArgs(int retryCount, TimeSpan delay, IEnumerable<Exception> exceptions)
            : this(new SqlRetryingEventArgs(retryCount, delay, exceptions?.ToList()))
        { }

        public static implicit operator WhippetSqlServerRetryingEventArgs(SqlRetryingEventArgs args)
        {
            return (args == null) ? null : new WhippetSqlServerRetryingEventArgs(args);
        }

        public static implicit operator SqlRetryingEventArgs(WhippetSqlServerRetryingEventArgs args)
        {
            return (args == null) ? null : args.InternalArgs;
        }
    }
}
