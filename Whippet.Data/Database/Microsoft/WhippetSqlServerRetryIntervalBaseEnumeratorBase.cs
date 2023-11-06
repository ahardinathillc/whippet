using System;
using System.Collections;
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
    /// Generates a sequence of time intervals. This class must be inherited.
    /// </summary>
    public abstract class WhippetSqlServerRetryIntervalBaseEnumeratorBase : SqlRetryIntervalBaseEnumerator, IEnumerator<TimeSpan>, IEnumerator, IDisposable, ICloneable
    {
        /// <summary>
        /// Gets or sets the internal <see cref="SqlRetryIntervalBaseEnumerator"/> object.
        /// </summary>
        private SqlRetryIntervalBaseEnumerator InternalObject
        { get; set; }

        /// <summary>
        /// Specifies the default gap time of each interval. This property is read-only.
        /// </summary>
        public virtual new TimeSpan GapTimeInterval
        {
            get
            {
                return InternalObject.GapTimeInterval;
            }
            protected set
            {
                IEnumerable<PropertyInfo> props = InternalObject.GetType().GetNonPublicProperties();
                PropertyInfo pInfo = props.Where(p => String.Equals(p.Name, nameof(GapTimeInterval), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                if (pInfo != null)
                {
                    pInfo.SetValue(InternalObject, value);
                }
            }
        }

        /// <summary>
        /// Specifies the maximum allowed time interval value. This property is read-only.
        /// </summary>
        public virtual new TimeSpan MaxTimeInterval
        {
            get
            {
                return InternalObject.MaxTimeInterval;
            }
            protected set
            {
                IEnumerable<PropertyInfo> props = InternalObject.GetType().GetNonPublicProperties();
                PropertyInfo pInfo = props.Where(p => String.Equals(p.Name, nameof(MaxTimeInterval), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                if (pInfo != null)
                {
                    pInfo.SetValue(InternalObject, value);
                }
            }
        }

        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator. This property is read-only.
        /// </summary>
        public virtual new TimeSpan Current
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
        /// Gets the element in the collection at the current position of the enumerator. This property is read-only.
        /// </summary>
        object IEnumerator.Current
        {
            get
            {
                return ((IEnumerator)(InternalObject)).Current;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerRetryIntervalBaseEnumeratorBase"/> class with the specified <see cref="SqlRetryIntervalBaseEnumerator"/> object.
        /// </summary>
        /// <param name="enumerator"><see cref="SqlRetryIntervalBaseEnumerator"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetSqlServerRetryIntervalBaseEnumeratorBase(SqlRetryIntervalBaseEnumerator enumerator)
        {
            if (enumerator == null)
            {
                throw new ArgumentNullException(nameof(enumerator));
            }
            else
            {
                InternalObject = enumerator;
            }
        }

        /// <summary>
        /// Sets the enumerator to its initial position (before the first element in the collection).
        /// </summary>
        public override void Reset()
        {
            InternalObject.Reset();
        }

        /// <summary>
        /// Validates the enumeration parameters.
        /// </summary>
        /// <param name="timeInterval">The gap time of each interval. Must be between 0 and 120 seconds.</param>
        /// <param name="maxTimeInterval">Maximum time interval value. Must be between 0 and 120 seconds.</param>
        /// <param name="minTimeInterval">Minimum time interval value. Must be less than maximum time and between 0 and 120 seconds.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        protected override void Validate(TimeSpan timeInterval, TimeSpan maxTimeInterval, TimeSpan minTimeInterval)
        {
            MethodInfo method = InternalObject.GetType().GetMethod(nameof(Validate), BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(TimeSpan), typeof(TimeSpan), typeof(TimeSpan) }, null);

            if (method != null)
            {
                method.Invoke(InternalObject, new object[] { timeInterval, maxTimeInterval, minTimeInterval });
            }
        }

        /// <summary>
        /// Calculates the next interval time.
        /// </summary>
        /// <returns>The next gap time interval.</returns>
        /// <exception cref="NotImplementedException"></exception>
        protected override TimeSpan GetNextInterval()
        {
            MethodInfo method = InternalObject.GetType().GetMethod(nameof(Validate), BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null);
            TimeSpan defaultTS = default(TimeSpan);

            if (method != null)
            {
                defaultTS = (TimeSpan)(method.Invoke(InternalObject, null));
            }
            else
            {
                throw new NotImplementedException();
            }

            return defaultTS;
        }

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns><see langword="true"/> if the enumerator was successfully advanced to the next element; <see langword="false"/> if the enumerator has passed the end of the collection.</returns>
        public override bool MoveNext()
        {
            return InternalObject.MoveNext();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public override void Dispose()
        {
            InternalObject.Dispose();
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
