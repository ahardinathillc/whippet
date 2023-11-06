using System;
using Athi.Whippet.Data;
using System.Data;
using System.Reflection;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IMultichannelOrderManagerOrder"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IMultichannelOrderManagerOrderExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IMultichannelOrderManagerOrder"/> object to a <see cref="MultichannelOrderManagerOrder"/> object.
        /// </summary>
        /// <param name="order"><see cref="IMultichannelOrderManagerOrder"/> object to convert.</param>
        /// <returns><see cref="MultichannelOrderManagerServer"/> object.</returns>
        public static MultichannelOrderManagerOrder ToMultichannelOrderManagerOrder(this IMultichannelOrderManagerOrder order)
        {
            MultichannelOrderManagerOrder mom = null;

            if (order != null)
            {
                if (order is MultichannelOrderManagerOrder)
                {
                    mom = (MultichannelOrderManagerOrder)(order);
                }
                else
                {
                    mom = new MultichannelOrderManagerOrder();
                    mom.ImportDataRow(order.CreateDataRow());
                }
            }

            return mom;
        }

    }
}

