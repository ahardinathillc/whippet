using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Data.SqlClient;
using Athi.Whippet.Extensions;

namespace Athi.Whippet.Data.Database.Microsoft
{
    /// <summary>
    /// Retrieves the next time interval with respect to the number of retries if a transient condition occurs. This class must be inherited.
    /// </summary>
    public abstract class WhippetSqlServerRetryLogicBase : SqlRetryLogicBase, ICloneable
    {
        private WhippetSqlServerRetryIntervalBaseEnumeratorBase _enumerator;

        /// <summary>
        /// Gets or sets the internal <see cref="SqlRetryLogicBase"/> object.
        /// </summary>
        private SqlRetryLogicBase InternalObject
        { get; set; }

        /// <summary>
        /// Gets the maximum number of retries. This property is read-only.
        /// </summary>
        public virtual new int NumberOfTries
        {
            get
            {
                return InternalObject.NumberOfTries;
            }
            protected set
            {
                IEnumerable<PropertyInfo> props = InternalObject.GetType().GetNonPublicProperties();
                PropertyInfo pInfo = props.Where(p => String.Equals(p.Name, nameof(NumberOfTries), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                if (pInfo != null)
                {
                    pInfo.SetValue(InternalObject, value);
                }
            }
        }

        /// <summary>
        /// Gets the current retry number starting from zero. This property is read-only.
        /// </summary>
        public virtual new int Current
        {
            get
            {
                return InternalObject.Current;
            }
            protected set
            {
                IEnumerable<PropertyInfo> props = InternalObject.GetType().GetNonPublicProperties();
                PropertyInfo pInfo = props.Where(p => String.Equals(p.Name, nameof(Current), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                if (pInfo != null)
                {
                    pInfo.SetValue(InternalObject, value);
                }
            }
        }

        /// <summary>
        /// The timer interval enumerator. This property is read-only.
        /// </summary>
        public virtual new WhippetSqlServerRetryIntervalBaseEnumeratorBase RetryIntervalEnumerator
        {
            get
            {
                if (_enumerator == null)
                {
                    if (InternalObject.RetryIntervalEnumerator != null)
                    {
                        _enumerator = new WhippetSqlServerRetryIntervalBaseEnumerator(InternalObject.RetryIntervalEnumerator);
                    }
                    else
                    {
                        _enumerator = null;
                    }
                }

                return _enumerator;
            }
            protected set
            {
                IEnumerable<PropertyInfo> props = InternalObject.GetType().GetNonPublicProperties();
                PropertyInfo pInfo = props.Where(p => String.Equals(p.Name, nameof(RetryIntervalEnumerator), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                if (pInfo != null)
                {
                    pInfo.SetValue(InternalObject, value);
                }

                _enumerator = null;
            }
        }

        /// <summary>
        /// Delegate to a transient condition predicate. The function that this delegate points to must return a <see langword="true"/> value when an expected transient exception happens. This property is read-only.
        /// </summary>
        public virtual new Predicate<Exception> TransientPredicate
        {
            get
            {
                return InternalObject.TransientPredicate;
            }
            protected set
            {
                IEnumerable<PropertyInfo> props = InternalObject.GetType().GetNonPublicProperties();
                PropertyInfo pInfo = props.Where(p => String.Equals(p.Name, nameof(TransientPredicate), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                if (pInfo != null)
                {
                    pInfo.SetValue(InternalObject, value);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerRetryLogicBase"/> class with the specified <see cref="SqlRetryLogicBase"/> object.
        /// </summary>
        /// <param name="logicBase"><see cref="SqlRetryLogicBase"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetSqlServerRetryLogicBase(SqlRetryLogicBase logicBase)
        {
            if (logicBase == null)
            {
                throw new ArgumentNullException(nameof(logicBase));
            }
            else
            {
                InternalObject = logicBase;
            }
        }

        /// <summary>
        /// Pre-retry validation for the sender state.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <returns><see langword="true"/> if the sender is authorized to retry the operation.</returns>
        public override bool RetryCondition(object sender)
        {
            return InternalObject.RetryCondition(sender);
        }

        /// <summary>
        /// Try to get the next interval time by using the enumerator if the counter does not exceed the number of retries.
        /// </summary>
        /// <param name="intervalTime">The interval time that is generated by <see cref="RetryIntervalEnumerator"/>.</param>
        /// <returns><see langword="true"/> if the number of retry attempts has not been exceeded; otherwise, <see langword="false"/>.</returns>
        public override bool TryNextInterval(out TimeSpan intervalTime)
        {
            return InternalObject.TryNextInterval(out intervalTime);
        }

        /// <summary>
        /// Sets the counters and enumerator to default values for next use.
        /// </summary>
        public override void Reset()
        {
            InternalObject.Reset();
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public override object Clone()
        {
            return InternalObject.Clone();
        }
    }
}
