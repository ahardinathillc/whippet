using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using NHibernate;
using NHibernate.UserTypes;
using NHibernate.SqlTypes;
using NHibernate.Engine;
using Athi.Whippet.Security;

namespace Athi.Whippet.Data.NHibernate.UserTypes.Security
{
    /// <summary>
    /// Represents the custom <see cref="IUserType"/> for <see cref="IWhippetPrincipalObject"/>.
    /// </summary>
    public class IWhippetPrincipalObjectUserType : WhippetUserTypeBase, IUserType
    {
        private const int INDEX_PRINCIPAL_ID = 0;
        private const int INDEX_PRINCIPAL_OBJ_TYPE = 1;
        private const int INDEX_PRINCIPAL_TYPE = 2;
        private const int INDEX_PRINCIPAL_NAME = 3;

        private const string COLUMN_PRINCIPAL_ID = "WhippetPrincipalID";
        private const string COLUMN_PRINCIPAL_OBJ_TYPE = "WhippetPrincipalObjectType";
        private const string COLUMN_PRINCIPAL_TYPE = "WhippetPrincipalType";
        private const string COLUMN_PRINCIPAL_NAME = "WhippetPrincipalName";

        /// <summary>
        /// Initializes a new instance of the <see cref="IWhippetPrincipalObjectUserType"/> class with no arguments.
        /// </summary>
        public IWhippetPrincipalObjectUserType()
        {
            SqlTypes = new[]
            {
                SqlTypeFactory.GetString(4096),     // Principal ID
                SqlTypeFactory.GetString(4096),     // Principal Object Type
                SqlTypeFactory.GetString(1024),     // Principal Type
                SqlTypeFactory.GetString(4096)      // Representative Name
            };

            ReturnedType = typeof(IWhippetPrincipalObjectUserType);
            IsMutable = false;
        }

        /// <summary>
        /// Generates an <see cref="IReadOnlyList{T}"/> of the column names that are mapped to the <see cref="IWhippetPrincipalObjectUserType"/> in the order in which they must be emitted.
        /// </summary>
        /// <param name="prefix">Prefix to apply to each column (if any).</param>
        /// <param name="suffix">Suffix to apply to each column (if any).</param>
        /// <returns><see cref="IReadOnlyList{T}"/> of the column names that are mapped to the <see cref="IWhippetPrincipalObjectUserType"/> in the order in which they must be emitted.</returns>
        public static IReadOnlyList<string> GenerateColumns(string prefix = null, string suffix = null)
        {
            List<string> columns = new List<string>();

            columns.Add((prefix + COLUMN_PRINCIPAL_ID + suffix).Trim());
            columns.Add((prefix + COLUMN_PRINCIPAL_OBJ_TYPE + suffix).Trim());
            columns.Add((prefix + COLUMN_PRINCIPAL_TYPE + suffix).Trim());
            columns.Add((prefix + COLUMN_PRINCIPAL_NAME + suffix).Trim());

            return columns.AsReadOnly();
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
            Type typeValue = null;

            object rawObject_idValue = null;
            object rawObject_typeValue = null;
            object rawObject_principalTypeValue = null;
            object rawObject_nameValue = null;
            object rawObject_principal = null;

            IWhippetPrincipalObject principalObject = null;

            if (rs != null && names != null)
            {
                if (names.Any())
                {
                    rawObject_idValue = NHibernateUtil.String.NullSafeGet(rs, names[INDEX_PRINCIPAL_ID], session);
                    rawObject_typeValue = NHibernateUtil.String.NullSafeGet(rs, names[INDEX_PRINCIPAL_OBJ_TYPE], session);
                    rawObject_nameValue = NHibernateUtil.String.NullSafeGet(rs, names[INDEX_PRINCIPAL_NAME], session);
                    rawObject_principalTypeValue = NHibernateUtil.String.NullSafeGet(rs, names[INDEX_PRINCIPAL_TYPE], session);

                    if (rawObject_typeValue != null)
                    {
                        typeValue = Type.GetType(Convert.ToString(rawObject_typeValue), true, true);
                        rawObject_principal = Activator.CreateInstance(typeValue, true);

                        if (rawObject_principal != null)
                        {
                            principalObject = ((IWhippetPrincipalObject)(rawObject_principal)).CreateInstance(rawObject_idValue, Convert.ToString(rawObject_nameValue), Convert.ToString(rawObject_principalTypeValue));
                        }
                    }
                }
            }

            return principalObject;
        }

        /// <summary>
        /// Writes an instance of the mapped class to a prepared statement. Implementors should handle possibility of <see langword="null"/> values. A multi-column type should be written to parameters starting from <paramref name="index"/>. This method must be overridden.
        /// </summary>
        /// <param name="cmd"><see cref="DbCommand"/> object containing the command statement.</param>
        /// <param name="value">Object to write.</param>
        /// <param name="index">Command parameter index.</param>
        /// <param name="session">The session for which the operation is done.</param>
        /// <exception cref="NullObjectException" />
        public override void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
        {
            if (cmd != null)
            {
                if (value == null || value == DBNull.Value)
                {
                    for (int i = index; i < GenerateColumns().Count; i++)
                    {
                        ((IDataParameter)(cmd.Parameters[i])).Value = DBNull.Value;
                    }
                }
                else
                {
                    IWhippetPrincipalObject principalObject = (IWhippetPrincipalObject)(value);

                    ((IDataParameter)(cmd.Parameters[index + INDEX_PRINCIPAL_ID])).Value = Convert.ToString(principalObject.PrincipalID);
                    ((IDataParameter)(cmd.Parameters[index + INDEX_PRINCIPAL_NAME])).Value = principalObject.Name;
                    ((IDataParameter)(cmd.Parameters[index + INDEX_PRINCIPAL_OBJ_TYPE])).Value = principalObject.GetType().AssemblyQualifiedName;
                    ((IDataParameter)(cmd.Parameters[index + INDEX_PRINCIPAL_TYPE])).Value = principalObject.PrincipalType;
                }
            }
        }
    }
}
