using System;
using System.Data;
using Athi.Whippet.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="object"/> instances for use in data scenarios. This class cannot be inherited.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Parses the specified value for <see cref="DBNull"/> and returns the appropriate value for the M.O.M. object if <see langword="null"/>.
        /// </summary>
        /// <param name="rowValue">Value to be assigned to the <see cref="DataRow"/>.</param>
        /// <param name="dataType"><see cref="Type"/> specified by the parent <see cref="DataColumn"/>.</param>
        /// <returns><see cref="object"/> to assign to the <see cref="DataRow"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static object ParseForNull(this object rowValue, Type dataType)
        {
            if (dataType == null)
            {
                throw new ArgumentNullException(nameof(dataType));
            }
            else
            {
                object toReturn = rowValue;

                if (rowValue != null)
                {
                    if (String.IsNullOrWhiteSpace(Convert.ToString(rowValue)))
                    {
                        // check to see if dataType is numeric

                        if (dataType.IsNumericType() || dataType.IsValueType)
                        {
                            toReturn = Activator.CreateInstance(dataType);
                        }
                    }
                    else
                    {
                        toReturn = rowValue;
                    }
                }
                else
                {
                    toReturn = DBNull.Value;
                }

                return toReturn;
            }
        }
    }
}

