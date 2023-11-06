using System;
using System.Data;

namespace Athi.Whippet.Data.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IWhippetEntityExternalDataRowImportMapper"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IWhippetEntityExternalDataRowImportMapperExtensions
    {
        /// <summary>
        /// Determines if the provided value for the external column is within the column's maximum length allowance.
        /// </summary>
        /// <param name="mapper"><see cref="IWhippetEntityExternalDataRowImportMapper"/> object.</param>
        /// <param name="value">Value to check.</param>
        /// <param name="externalColumnName">External column name that the value will be assigned to.</param>
        /// <param name="allowNull">If <see langword="true"/>, <see langword="null"/> or <see cref="String.Empty"/> values will be allowed.</param>
        /// <returns>Original value if it passes the length check.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        [Obsolete("This method is deprecated and will be removed in a future version.")]
        public static string CheckLengthRequirement(this IWhippetEntityExternalDataRowImportMapper mapper, string value, string externalColumnName, bool allowNull = false)
        {
            return value;
            //if (mapper == null)
            //{
            //    throw new ArgumentNullException(nameof(mapper));
            //}
            //else if (String.IsNullOrWhiteSpace(externalColumnName))
            //{
            //    throw new ArgumentNullException(nameof(externalColumnName));
            //}
            //else if (String.IsNullOrEmpty(value) && !allowNull)
            //{
            //    throw new ArgumentNullException(nameof(value));
            //}
            //else
            //{
            //    DataTable table = null;
            //    WhippetDataRowImportMap map = null;

            //    if (!String.IsNullOrWhiteSpace(value))
            //    {
            //        table = mapper.CreateDataTable();
            //        map = mapper.CreateImportMap();

            //        if (table != null && map != null)
            //        {
            //            foreach (DataColumn column in table.Columns)
            //            {
            //                if (String.Equals(column.ColumnName, externalColumnName, StringComparison.InvariantCultureIgnoreCase))
            //                {
            //                    // found the column

            //                    if (column.MaxLength >= 1 && !String.IsNullOrEmpty(value))
            //                    {
            //                        if (value.Length > column.MaxLength)
            //                        {
            //                            throw new ArgumentOutOfRangeException(nameof(value));
            //                        }
            //                    }

            //                    break;
            //                }
            //            }
            //        }
            //    }

            //    return value;
            //}
        }
    }
}

