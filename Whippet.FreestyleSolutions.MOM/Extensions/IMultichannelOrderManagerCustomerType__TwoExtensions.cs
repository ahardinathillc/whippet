using System;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IMultichannelOrderManagerCustomerType__Two"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ICustomerType__TwoExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IMultichannelOrderManagerCustomerType__Two"/> object to a <see cref="MultichannelOrderManagerCustomerType__Two"/> object.
        /// </summary>
        /// <param name="ctTwo"><see cref="IMultichannelOrderManagerCustomerType__Two"/> object to convert.</param>
        /// <returns><see cref="MultichannelOrderManagerCustomerType__Two"/> object.</returns>
        public static MultichannelOrderManagerCustomerType__Two ToCustomerType__Two(this IMultichannelOrderManagerCustomerType__Two ctTwo)
        {
            MultichannelOrderManagerCustomerType__Two type = null;

            if (ctTwo != null)
            {
                if (ctTwo is MultichannelOrderManagerCustomerType__Two)
                {
                    type = (MultichannelOrderManagerCustomerType__Two)(ctTwo);
                }
                else
                {
                    type = new MultichannelOrderManagerCustomerType__Two(
                        ctTwo.ID,
                        ctTwo.CustomerType,
                        ctTwo.Description,
                        ctTwo.TypeId
                        );
                }
            }

            return type;
        }
    }
}

