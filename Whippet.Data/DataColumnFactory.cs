using System;
using System.Data;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Creates new <see cref="DataColumn" /> objects with extended options not provided in the default constructor. This class cannot be inherited.
    /// </summary>
    public static class DataColumnFactory
    {
        /// <summary>
        /// Creates a new <see cref="DataColumn"/> object.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="type">Data type of the values stored in the column.</param>
        /// <param name="allowDbNull">If <see langword="true"/>, will allow <see langword="null"/> or <see cref="DBNull.Value"/> values.</param>
        /// <param name="maxLength">Maximum length to apply to the column if the data type is a text type.</param>
        /// <returns><see cref="DataColumn"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public static DataColumn CreateDataColumn(string columnName, Type type, bool allowDbNull, int maxLength = -1)
        {
            return CreateDataColumn(columnName, type, null, allowDbNull, maxLength);
        }

        /// <summary>
        /// Creates a new <see cref="DataColumn"/> object.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="type">Data type of the values stored in the column.</param>
        /// <param name="expression">Expression to apply to the values in the column.</param>
        /// <param name="allowDbNull">If <see langword="true"/>, will allow <see langword="null"/> or <see cref="DBNull.Value"/> values.</param>
        /// <param name="maxLength">Maximum length to apply to the column if the data type is a text type.</param>
        /// <returns><see cref="DataColumn"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public static DataColumn CreateDataColumn(string columnName, Type type, string expression, bool allowDbNull, int maxLength = -1)
        {
            DataColumn column = new DataColumn(columnName, type, expression);

            column.AllowDBNull = allowDbNull;

            if (column.DataType.Equals(typeof(string)))
            {
                column.MaxLength = maxLength;
            }

            return column;
        }

        /// <summary>
        /// Creates a new <see cref="DataColumn"/> object.
        /// </summary>
        /// <typeparam name="TColumnDataType">Data type of the values stored in the column.</typeparam>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="allowDbNull">If <see langword="true"/>, will allow <see langword="null"/> or <see cref="DBNull.Value"/> values.</param>
        /// <param name="maxLength">Maximum length to apply to the column if the data type is a text type.</param>
        /// <returns><see cref="DataColumn"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public static DataColumn CreateDataColumn<TColumnDataType>(string columnName, bool allowDbNull, int maxLength = -1)
        {
            return CreateDataColumn(columnName, typeof(TColumnDataType), allowDbNull, maxLength);
        }
    }
}

