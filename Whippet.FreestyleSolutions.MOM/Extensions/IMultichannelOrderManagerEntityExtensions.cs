using System;
using Athi.Whippet.Data;
using System.Data;
using System.Reflection;
using Dynamitey;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IMultichannelOrderManagerEntity"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IMultichannelOrderManagerEntityExtensions
    {
        /// <summary>
        /// Creates a new <see cref="DataRow"/> that represents the current entity's state.
        /// </summary>
        /// <returns><see cref="DataRow"/> object containing the values of the current entity.</returns>
        internal static DataRow CreateDataRow__Internal<T>(this T item) where T : IMultichannelOrderManagerEntity, IWhippetEntityExternalDataRowImportMapper
        {
            WhippetDataRowImportMap map = item.CreateImportMap();
            DataTable table = item.CreateDataTable();
            DataRow row = table.NewRow();

            PropertyInfo property = null;

            foreach (WhippetDataRowImportMapEntry entry in ((IEnumerable<WhippetDataRowImportMapEntry>)(map)))
            {
                property = typeof(T).GetProperty(entry.Property);       // this was set to MultichannelOrderManagerOrderItem originally?
                row[entry.Column] = property.GetValue(item, null) ?? DBNull.Value;
            }

            return row;
        }
    }
}
