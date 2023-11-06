using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Threading;
using Microsoft.Data.SqlClient;
using Athi.Whippet.Extensions;

namespace Athi.Whippet.Data.Database.Microsoft
{
    /// <summary>
    /// Applies retry logic on an operation through the "Execute" or "ExecuteAsync" function. This class must be inherited.
    /// </summary>
    public abstract class WhippetSqlServerRetryLogicBaseProviderBase : SqlRetryLogicBaseProvider
    {
        private WhippetSqlServerRetryLogic _retryLogic;

        /// <summary>
        /// Gets or sets the internal <see cref="SqlRetryLogicBaseProvider"/> object.
        /// </summary>
        private SqlRetryLogicBaseProvider InternalProvider
        { get; set; }

        /// <summary>
        /// Defines the retry logic used to decide when to retry based on the encountered exception. This property is read-only.
        /// </summary>
        public new virtual WhippetSqlServerRetryLogicBase RetryLogic
        {
            get
            {
                if (_retryLogic == null)
                {
                    if (InternalProvider.RetryLogic != null)
                    {
                        _retryLogic = new WhippetSqlServerRetryLogic(InternalProvider.RetryLogic);
                    }
                    else
                    {
                        _retryLogic = null;
                    }
                }

                return _retryLogic;
            }
            protected set
            {
                IEnumerable<PropertyInfo> props = InternalProvider.GetType().GetNonPublicProperties();
                PropertyInfo pInfo = props.Where(p => String.Equals(p.Name, nameof(RetryLogic), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                if (pInfo != null)
                {
                    pInfo.SetValue(InternalProvider, value);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerRetryLogicBaseProviderBase"/> class with the specified <see cref="SqlRetryLogicBaseProvider"/> object.
        /// </summary>
        /// <param name="provider"><see cref="SqlRetryLogicBaseProvider"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetSqlServerRetryLogicBaseProviderBase(SqlRetryLogicBaseProvider provider)
        { 
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }
            else
            {
                InternalProvider = provider;
            }
        }

        /// <summary>
        /// Executes a function and applies retry logic (if enabled). Exceptions will be reported via an aggregate exdeption if the execution isn't successful via retry attempts.
        /// </summary>
        /// <typeparam name="TResult">The object that <paramref name="function"/> returns when executed.</typeparam>
        /// <param name="sender">The source of the event.</param>
        /// <param name="function">The operation to re-execute if a transient condition occurs.</param>
        /// <returns>The return value of <paramref name="function"/> if it runs without exception.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="AggregateException" />
        public override TResult Execute<TResult>(object sender, Func<TResult> function)
        {
            return InternalProvider.Execute<TResult>(sender, function);
        }

        /// <summary>
        /// Executes a function and applies retry logic (if enabled). The cancellation token can be used to request that the operation be abandoned before the execution attempts are exceeded. 
        /// Exceptions will be reported via the returned <see cref="Task"/> object, which will contain an aggregate exception if execution fails for all retry attempts.
        /// </summary>
        /// <typeparam name="TResult">The object that <paramref name="function"/> returns when executed.</typeparam>
        /// <param name="sender">The source of the event.</param>
        /// <param name="function">The operation to re-execute if a transient condition occurs.</param>
        /// <param name="cancellationToken">The cancellation instruction.</param>
        /// <returns>A <see cref="Task"/> object representing the asynchronous operation. The results of the task will be the return value of <paramref name="function"/> if it runs without exception.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="AggregateException" />
        public override Task<TResult> ExecuteAsync<TResult>(object sender, Func<Task<TResult>> function, CancellationToken cancellationToken = default)
        {
            return InternalProvider.ExecuteAsync<TResult>(sender, function, cancellationToken);
        }

        /// <summary>
        /// Executes a function and applies retry logic (if enabled). The cancellation token can be used to request that the operation be abandoned before the execution attempts are exceeded. 
        /// Exceptions will be reported via the returned <see cref="Task"/> object, which will contain an aggregate exception if execution fails for all retry attempts.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="function">The operation to re-execute if a transient condition occurs.</param>
        /// <param name="cancellationToken">The cancellation instruction.</param>
        /// <returns>A <see cref="Task"/> object representing the asynchronous operation. The results of the task will be the return value of <paramref name="function"/> if it runs without exception.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="AggregateException" />
        public override Task ExecuteAsync(object sender, Func<Task> function, CancellationToken cancellationToken = default)
        {
            return InternalProvider.ExecuteAsync(sender, function, cancellationToken);
        }
    }
}
