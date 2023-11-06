using System;
using Athi.Whippet.Data;
using System.Data;
using System.Reflection;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IMultichannelOrderManagerOrderItem"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IMultichannelOrderManagerOrderItemExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IMultichannelOrderManagerOrderItem"/> object to a <see cref="MultichannelOrderManagerOrderItem"/> object.
        /// </summary>
        /// <param name="item"><see cref="IMultichannelOrderManagerOrderItem"/> object to convert.</param>
        /// <returns><see cref="MultichannelOrderManagerOrderItem"/> object.</returns>
        public static MultichannelOrderManagerOrderItem ToMultichannelOrderManagerOrderItem(this IMultichannelOrderManagerOrderItem item)
        {
            MultichannelOrderManagerOrderItem momItem = null;

            if (item != null)
            {
                if (item is MultichannelOrderManagerOrderItem)
                {
                    momItem = (MultichannelOrderManagerOrderItem)(item);
                }
                else
                {
                    momItem = new MultichannelOrderManagerOrderItem();
                    momItem.ImportDataRow(item.CreateDataRow());
                }
            }

            return momItem;
        }

    }
}

