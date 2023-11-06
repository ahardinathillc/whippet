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
using Athi.Whippet.Security.AccessControl;
using Athi.Whippet.Web.Mvc;
using Athi.Whippet.Web.Mvc.Security;

namespace Athi.Whippet.Data.NHibernate.UserTypes.Web.Mvc.Security
{
    /// <summary>
    /// Represents the custom <see cref="IUserType"/> for <see cref="WhippetMvcSecurityPermission"/>.
    /// </summary>
    public class WhippetMvcSecurityPermissionUserType : WhippetUserTypeBase, IUserType
    {
        private const int INDEX_PERMISSION_ID = 0;
        private const int INDEX_ENUM_VALUE = 1;
        private const int INDEX_PERMISSION_NAME = 2;
        private const int INDEX_VIEW_ID = 3;
        private const int INDEX_CONTROLLER_ID = 4;
        private const int INDEX_VIEW_NAME = 5;
        private const int INDEX_VIEW_NAME_FRIENDLY = 6;
        private const int INDEX_VIEW_NAME_FILE = 7;
        private const int INDEX_VIEW_SYSTEM = 8;

        private const string COLUMN_PERMISSION_ID = "WhippetViewPermissionID";
        private const string COLUMN_ENUM_VALUE = "WhippetViewPermissionValue";
        private const string COLUMN_PERMISSION_NAME = "WhippetViewPermissionName";
        private const string COLUMN_VIEW_ID = "WhippetViewID";
        private const string COLUMN_CONTROLLER_ID = "WhippetControllerID";
        private const string COLUMN_VIEW_NAME = "WhippetViewName";
        private const string COLUMN_VIEW_NAME_FRIENDLY = "WhippetViewFriendlyName";
        private const string COLUMN_VIEW_NAME_FILE = "WhippetViewFileName";
        private const string COLUMN_VIEW_SYSTEM = "WhippetViewIsSystemView";

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMvcSecurityPermissionUserType"/> class with no arguments.
        /// </summary>
        public WhippetMvcSecurityPermissionUserType()
            : base()
        {
            SqlTypes = new[] {
                SqlTypeFactory.Guid,                                // permission ID
                SqlTypeFactory.Int32,                               // permission enum value
                SqlTypeFactory.GetString(1024),                     // permission name
                SqlTypeFactory.Guid,                                // view ID
                SqlTypeFactory.Guid,                                // controller ID
                SqlTypeFactory.GetString(1024),                     // view name
                SqlTypeFactory.GetString(1024),                     // view friendly name
                SqlTypeFactory.GetString(1024),                     // view file name
                SqlTypeFactory.Boolean                              // system view
            };

            ReturnedType = typeof(WhippetMvcSecurityPermissionUserType);
            IsMutable = true;
        }

        /// <summary>
        /// Generates an <see cref="IReadOnlyList{T}"/> of the column names that are mapped to the <see cref="WhippetMvcSecurityPermissionUserType"/> in the order in which they must be emitted.
        /// </summary>
        /// <param name="prefix">Prefix to apply to each column (if any).</param>
        /// <param name="suffix">Suffix to apply to each column (if any).</param>
        /// <returns><see cref="IReadOnlyList{T}"/> of the column names that are mapped to the <see cref="WhippetMvcSecurityPermissionUserType"/> in the order in which they must be emitted.</returns>
        public static IReadOnlyList<string> GenerateColumns(string prefix = null, string suffix = null)
        {
            List<string> columns = new List<string>();

            columns.Add((prefix + COLUMN_PERMISSION_ID + suffix).Trim());
            columns.Add((prefix + COLUMN_ENUM_VALUE + suffix).Trim());
            columns.Add((prefix + COLUMN_PERMISSION_NAME + suffix).Trim());
            columns.Add((prefix + COLUMN_VIEW_ID + suffix).Trim());
            columns.Add((prefix + COLUMN_CONTROLLER_ID + suffix).Trim());
            columns.Add((prefix + COLUMN_VIEW_NAME + suffix).Trim());
            columns.Add((prefix + COLUMN_VIEW_NAME_FRIENDLY + suffix).Trim());
            columns.Add((prefix + COLUMN_VIEW_NAME_FILE + suffix).Trim());
            columns.Add((prefix + COLUMN_VIEW_SYSTEM + suffix).Trim());

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
            Guid idValue = default(Guid);
            Guid viewValue = default(Guid);
            Guid controllerValue = default(Guid);

            int typeValue = default(int);

            string nameValue = null;
            string viewNameValue = null;
            string friendlyNameValue = null;
            string fileNameValue = null;

            bool isSystemValue = default(bool);

            WhippetPermissionType permissionTypeValue = default(WhippetPermissionType);

            object rawObject_idValue = null;
            object rawObject_typeValue = null;
            object rawObject_nameValue = null;
            object rawObject_viewValue = null;
            object rawObject_controllerValue = null;
            object rawObject_viewNameValue = null;
            object rawObject_friendlyNameValue = null;
            object rawObject_fileNameValue = null;
            object rawObject_isSystemValue = null;

            bool successfulParse = false;

            WhippetMvcSecurityPermission permissionObject = null;

            if (rs != null && names != null)
            {
                if (names.Any())
                {
                    rawObject_idValue = NHibernateUtil.Guid.NullSafeGet(rs, names[INDEX_PERMISSION_ID], session);
                    rawObject_typeValue = NHibernateUtil.Int32.NullSafeGet(rs, names[INDEX_ENUM_VALUE], session);
                    rawObject_nameValue = NHibernateUtil.String.NullSafeGet(rs, names[INDEX_PERMISSION_NAME], session);
                    rawObject_viewValue = NHibernateUtil.Guid.NullSafeGet(rs, names[INDEX_VIEW_ID], session);
                    rawObject_controllerValue = NHibernateUtil.Guid.NullSafeGet(rs, names[INDEX_CONTROLLER_ID], session);
                    rawObject_viewNameValue = NHibernateUtil.String.NullSafeGet(rs, names[INDEX_VIEW_NAME], session);
                    rawObject_friendlyNameValue = NHibernateUtil.String.NullSafeGet(rs, names[INDEX_VIEW_NAME_FRIENDLY], session);
                    rawObject_fileNameValue = NHibernateUtil.String.NullSafeGet(rs, names[INDEX_VIEW_NAME_FILE], session);
                    rawObject_isSystemValue = NHibernateUtil.Boolean.NullSafeGet(rs, names[INDEX_VIEW_SYSTEM], session);

                    if (Guid.TryParse(Convert.ToString(rawObject_idValue), out idValue)
                            && Int32.TryParse(Convert.ToString(rawObject_typeValue), out typeValue)
                            && Guid.TryParse(Convert.ToString(rawObject_viewValue), out viewValue)
                            && Guid.TryParse(Convert.ToString(rawObject_controllerValue), out controllerValue)
                            && Boolean.TryParse(Convert.ToString(rawObject_isSystemValue), out isSystemValue)
                        )
                    {
                        nameValue = Convert.ToString(rawObject_nameValue);
                        viewNameValue = Convert.ToString(rawObject_viewNameValue);
                        friendlyNameValue = Convert.ToString(rawObject_friendlyNameValue);
                        fileNameValue = Convert.ToString(rawObject_fileNameValue);

                        successfulParse = !String.IsNullOrWhiteSpace(nameValue)
                            && Enum.TryParse<WhippetPermissionType>(Convert.ToString(typeValue), out permissionTypeValue)
                            && !String.IsNullOrWhiteSpace(viewNameValue)
                            && !String.IsNullOrWhiteSpace(friendlyNameValue)
                            && !String.IsNullOrWhiteSpace(fileNameValue);
                    }

                    if (successfulParse)
                    {
                        permissionObject = new WhippetMvcSecurityPermission(idValue, permissionTypeValue, nameValue, new WhippetViewProfile(controllerValue, viewValue, viewNameValue, friendlyNameValue, fileNameValue, isSystemValue));
                    }
                }
            }

            return permissionObject;
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
                    WhippetMvcSecurityPermission permissionObject = (WhippetMvcSecurityPermission)(value);

                    if (permissionObject.View == null)
                    {
                        throw new NullObjectException();
                    }
                    else
                    {
                        ((IDataParameter)(cmd.Parameters[index + INDEX_PERMISSION_ID])).Value = permissionObject.ID;
                        ((IDataParameter)(cmd.Parameters[index + INDEX_ENUM_VALUE])).Value = Convert.ToInt32(permissionObject.Type);
                        ((IDataParameter)(cmd.Parameters[index + INDEX_PERMISSION_NAME])).Value = permissionObject.Name;
                        ((IDataParameter)(cmd.Parameters[index + INDEX_VIEW_ID])).Value = permissionObject.View.ViewID;
                        ((IDataParameter)(cmd.Parameters[index + INDEX_CONTROLLER_ID])).Value = permissionObject.View.ControllerID;
                        ((IDataParameter)(cmd.Parameters[index + INDEX_VIEW_NAME])).Value = permissionObject.View.Name;
                        ((IDataParameter)(cmd.Parameters[index + INDEX_VIEW_NAME_FRIENDLY])).Value = permissionObject.View.FriendlyName;
                        ((IDataParameter)(cmd.Parameters[index + INDEX_VIEW_NAME_FILE])).Value = permissionObject.View.Filename;
                        ((IDataParameter)(cmd.Parameters[index + INDEX_VIEW_SYSTEM])).Value = permissionObject.View.IsSystem;
                    }
                }
            }
        }


    }
}
