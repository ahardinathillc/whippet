using System;
using Athi.Whippet.Data;
using System.Data;
using System.Reflection;
using System.Text;
using NodaTime;

namespace Athi.Whippet.Salesforce.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ISalesforceObject"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ISalesforceObjectExtensions
    {
        /// <summary>
        /// Creates a new <see cref="DataRow"/> that represents the current entity's state.
        /// </summary>
        /// <typeparam name="T"><see cref="ISalesforceObject"/> type.</typeparam>
        /// <param name="item"><see cref="ISalesforceObject"/> item to create the <see cref="DataRow"/> object from.</param>
        /// <returns><see cref="DataRow"/> object containing the values of the current entity.</returns>
        internal static DataRow CreateDataRow__Internal<T>(this T item) where T : ISalesforceObject, IWhippetEntityExternalDataRowImportMapper
        {
            WhippetDataRowImportMap map = item.CreateImportMap();
            DataTable table = item.CreateDataTable();
            DataRow row = table.NewRow();

            PropertyInfo property = null;

            foreach (WhippetDataRowImportMapEntry entry in ((IEnumerable<WhippetDataRowImportMapEntry>)(map)))
            {
                property = typeof(T).GetProperty(entry.Property);

                if (property == null)
                {
                    throw new MissingMethodException(typeof(T).FullName, entry.Property);
                }
                else
                {
                    object instantObj = null;

                    if (property.PropertyType.Equals(typeof(Instant)))
                    {
                        instantObj = property.GetValue(item, null);

                        if (instantObj == null)
                        {
                            instantObj = DBNull.Value;
                        }
                        else
                        {
                            instantObj = ((Instant)(instantObj)).ToDateTimeUtc();
                        }

                        row[entry.Column] = instantObj;
                    }
                    else
                    {
                        row[entry.Column] = property.GetValue(item, null) ?? DBNull.Value;
                    }
                }
            }

            return row;
        }
    }
}

