using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using NodaTime;
using NHibernate;
using NHibernate.UserTypes;
using NHibernate.SqlTypes;
using NHibernate.Engine;
using Athi.Whippet.Salesforce;

namespace Athi.Whippet.Data.NHibernate.UserTypes.Salesforce
{
    /// <summary>
    /// Represents the custom <see cref="IUserType"/> for <see cref="SalesforceReference"/>.
    /// </summary>
    public class SalesforceReferenceUserType : WhippetUserTypeBase, IUserType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceReferenceUserType"/> class with no arguments.
        /// </summary>
        public SalesforceReferenceUserType()
            : base()
        {
            SqlTypes = new[] { SqlTypeFactory.GetString(SalesforceReference.MaximumLength) };
            ReturnedType = typeof(SalesforceReference);
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
            SalesforceReference boxedObj = null;

            if (rs != null && names != null)
            {
                if (names.Any())
                {
                    rawObj = NHibernateUtil.String.NullSafeGet(rs, names[0], session);
                }
            }

            if (rawObj != null)
            {
                boxedObj = new SalesforceReference(Convert.ToString(rawObj));
                rawObj = boxedObj;
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
                    ((IDataParameter)(cmd.Parameters[index])).Value = Convert.ToString(value);
                }
            }
        }
    }
}
