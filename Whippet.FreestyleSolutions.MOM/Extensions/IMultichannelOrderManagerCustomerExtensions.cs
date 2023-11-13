using System;
using System.Text;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IMultichannelOrderManagerCustomer"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IMultichannelOrderManagerCustomerExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IMultichannelOrderManagerCustomer"/> object to a <see cref="MultichannelOrderManagerCustomer"/> object.
        /// </summary>
        /// <param name="cust"><see cref="IMultichannelOrderManagerCustomer"/> object to convert.</param>
        /// <returns><see cref="MultichannelOrderManagerCustomer"/> object.</returns>
        public static MultichannelOrderManagerCustomer ToMultichannelOrderManagerCustomer(this IMultichannelOrderManagerCustomer cust)
        {
            MultichannelOrderManagerCustomer c = null;

            if (cust != null)
            {
                if (cust is MultichannelOrderManagerCustomer)
                {
                    c = ((MultichannelOrderManagerCustomer)(cust));
                }
                else
                {
                    c = new MultichannelOrderManagerCustomer();
                    c.ImportDataRow(cust.CreateDataRow());
                }
            }

            return c;
        }

        /// <summary>
        /// Concatenates the <see cref="IMultichannelOrderManagerCustomer.Address"/>, <see cref="IMultichannelOrderManagerCustomer.SecondAddress"/>, and <see cref="IMultichannelOrderManagerCustomer.ThirdAddress"/> fields with the default environment line terminator.
        /// </summary>
        /// <param name="cust"><see cref="IMultichannelOrderManagerCustomer"/> object.</param>
        /// <returns>Concatenated address line without the city, state/province, postal code, and country.</returns>
        public static string AddressToString(this IMultichannelOrderManagerCustomer cust)
        {
            StringBuilder addressBuilder = new StringBuilder();

            if (cust != null)
            {
                addressBuilder.AppendLine(cust.Address?.Trim());

                if (!String.IsNullOrWhiteSpace(cust.SecondAddress?.Trim()))
                {
                    addressBuilder.AppendLine(cust.SecondAddress?.Trim());
                }

                if (!String.IsNullOrWhiteSpace(cust.ThirdAddress?.Trim()))
                {
                    addressBuilder.AppendLine(cust.ThirdAddress?.Trim());
                }
            }

            return addressBuilder.ToString();
        }
    }
}
