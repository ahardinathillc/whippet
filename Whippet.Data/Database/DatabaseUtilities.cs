using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using Athi.Whippet.Data.Database.Microsoft;

namespace Athi.Whippet.Data.Database
{
    /// <summary>
    /// Provides common database utilities used in Whippet. This class cannot be inherited.
    /// </summary>
    internal static class DatabaseUtilities
    {
        /// <summary>
        /// Decorates the specified database object name.
        /// </summary>
        /// <param name="objName">Object name to decorate.</param>
        /// <returns>Decorated object name.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string DecorateDbObject(string objName)
        {
            if (String.IsNullOrWhiteSpace(objName))
            {
                throw new ArgumentNullException(nameof(objName));
            }
            else
            {
                if (!objName.StartsWith('['))
                {
                    objName = '[' + objName;
                }

                if (!objName.EndsWith(']'))
                {
                    objName = objName + ']';
                }

                return objName;
            }
        }

        /// <summary>
        /// Decorates the specified parameter name.
        /// </summary>
        /// <param name="paramName">Parameter name to decorate.</param>
        /// <returns>Decorated parameter name.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string DecorateDbParameter(string paramName)
        {
            if (String.IsNullOrWhiteSpace(paramName))
            {
                throw new ArgumentNullException(nameof(paramName));
            }
            else
            {
                if (!paramName.StartsWith('@'))
                {
                    paramName = '@' + paramName;
                }

                return paramName;
            }
        }

        /// <summary>
        /// Parses the specified <see cref="Type"/> to its equivalent <see cref="DbType"/> value.
        /// </summary>
        /// <param name="type"><see cref="Type"/> to parse.</param>
        /// <returns><see cref="DbType"/> value.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DbType ParseType(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            else
            {
                DbType dbType = default(DbType);

                if (type == typeof(byte))
                {
                    dbType = DbType.Byte;
                }
                else if (type == typeof(sbyte))
                {
                    dbType = DbType.SByte;
                }
                else if (type == typeof(short))
                {
                    dbType = DbType.Int16;
                }
                else if (type == typeof(ushort))
                {
                    dbType = DbType.UInt16;
                }
                else if (type == typeof(int))
                {
                    dbType = DbType.Int32;
                }
                else if (type == typeof(uint))
                {
                    dbType = DbType.UInt32;
                }
                else if (type == typeof(long))
                {
                    dbType = DbType.Int64;
                }
                else if (type == typeof(ulong))
                {
                    dbType = DbType.UInt64;
                }
                else if (type == typeof(float))
                {
                    dbType = DbType.Single;
                }
                else if (type == typeof(double))
                {
                    dbType = DbType.Double;
                }
                else if (type == typeof(decimal))
                {
                    dbType = DbType.Decimal;
                }
                else if (type == typeof(string))
                {
                    dbType = DbType.String;
                }
                else if (type == typeof(byte[]))
                {
                    dbType = DbType.Binary;
                }
                else if (type == typeof(Guid))
                {
                    dbType = DbType.Guid;
                }
                else if (type == typeof(DateTime))
                {
                    dbType = DbType.DateTime2;
                }
                else
                {
                    dbType = DbType.Object;
                }

                return dbType;
            }
        }

        /// <summary>
        /// Parses the specified <see cref="DataColumn"/> type to its equivalent <see cref="DbType"/> value.
        /// </summary>
        /// <param name="column"><see cref="DataColumn"/> to parse.</param>
        /// <returns><see cref="DbType"/> value.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DbType ParseType(DataColumn column)
        {
            if (column == null)
            {
                throw new ArgumentNullException(nameof(column));
            }
            else
            {
                return ParseType(column.DataType);
            }
        }

        /// <summary>
        /// Checks the specified value and converts it to <see cref="DBNull"/> if necessary.
        /// </summary>
        /// <param name="value">Value to check.</param>
        /// <returns>Value to assign to the parameter.</returns>
        public static object ParseValue(object value)
        {
            return (value == null) ? DBNull.Value : value;
        }

        /// <summary>
        /// Generates a random short name to alias a table by in a query.
        /// </summary>
        /// <returns>Table short name to use as an alias.</returns>
        public static string GenerateTableShortName()
        {
            Guid guid = Guid.NewGuid();

            while (!Char.IsLetter(guid.ToString()[0]))
            {
                guid = Guid.NewGuid();
            }

            return guid.ToString().Substring(0, 7);
        }
    }
}

