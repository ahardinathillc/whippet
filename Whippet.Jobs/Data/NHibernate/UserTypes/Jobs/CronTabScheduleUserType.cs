using System;
using System.Data;
using System.Data.Common;
using NHibernate;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using Athi.Whippet.Jobs;

namespace Athi.Whippet.Data.NHibernate.UserTypes.Jobs
{
    /// <summary>
    /// Represents the custom <see cref="IUserType"/> for <see cref="CronTabSchedule"/>.
    /// </summary>
    public class CronTabScheduleUserType : WhippetUserTypeBase, IUserType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CronTabScheduleUserType"/> class with no arguments.
        /// </summary>
        public CronTabScheduleUserType()
        {
            SqlTypes = new[] { SqlTypeFactory.GetString(CronTabSchedule.MAX_CRON_LENGTH) };
            ReturnedType = typeof(CronTabScheduleUserType);
            IsMutable = false;
        }

        /// <summary>
        /// Retrieves an instance of the mapped class from an ADO result set. Implementors should handle possibility of <see langword="null"/> values. This method must be overridden.
        /// </summary>
        /// <param name="rs"><see cref="DbDataReader"/> object returned from the query.</param>
        /// <param name="names">Column names returned from the query.</param>
        /// <param name="session">The session for which the operation is done.</param>
        /// <param name="owner">The containing entity.</param>
        /// <returns>Value constructed from the data reader.</returns>
        public override object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
        {
            object rawObj = null;

            string[] pieces = null;

            CronTabSchedule cron = null;

            CronStringFormat format = CronStringFormat.Default;

            if (rs != null && names != null)
            {
                if (names.Any())
                {
                    rawObj = NHibernateUtil.String.NullSafeGet(rs, names[0], session);
                }
            }

            if (rawObj != null)
            {
                pieces = Convert.ToString(rawObj).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (pieces != null)
                {
                    if (pieces.Length == 5)
                    {
                        format = CronStringFormat.Default;
                    }
                    else if (pieces.Length == 6)
                    {
                        // assume standard cron format with years instead of seconds
                        format = CronStringFormat.WithYears;
                    }
                    else if (pieces.Length == 7)
                    {
                        format = CronStringFormat.WithSecondsAndYears;
                    }
                    else
                    {
                        format = CronStringFormat.Default;  // let CronTabSchedule figure it out
                    }

                    cron = new CronTabSchedule(Convert.ToString(rawObj), format);

                    rawObj = cron;
                }
            }

            return rawObj;
        }

        /// <summary>
        /// Writes an instance of the mapped class to a prepared statement. Implementors should handle possibility of <see langword="null"/> values. A multi-column type should be written to parameters starting from <paramref name="index"/>. This method must be overridden.
        /// </summary>
        /// <param name="cmd"><see cref="DbCommand"/> object containing the command statement.</param>
        /// <param name="value">Object to write.</param>
        /// <param name="index">Command parameter index.</param>
        /// <param name="session">The session for which the operation is done.</param>
        public override void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
        {
            if (cmd != null)
            {
                if (value == null)
                {
                    ((IDataParameter)(cmd.Parameters[index])).Value = DBNull.Value;
                }
                else
                {
                    ((IDataParameter)(cmd.Parameters[index])).Value = ((CronTabSchedule)(value)).ToString();
                }
            }
        }
    }
}
