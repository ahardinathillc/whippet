using System;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IMultichannelOrderManagerCustomerType__Three"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ICustomerType__ThreeExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IMultichannelOrderManagerCustomerType__Three"/> object to a <see cref="MultichannelOrderManagerCustomerType__Three"/> object.
        /// </summary>
        /// <param name="ctThree"><see cref="IMultichannelOrderManagerCustomerType__Three"/> object to convert.</param>
        /// <returns><see cref="MultichannelOrderManagerCustomerType__Three"/> object.</returns>
        public static MultichannelOrderManagerCustomerType__Three ToCustomerType__Three(this IMultichannelOrderManagerCustomerType__Three ctThree)
        {
            MultichannelOrderManagerCustomerType__Three type = null;

            if (ctThree != null)
            {
                if (ctThree is MultichannelOrderManagerCustomerType__Three)
                {
                    type = (MultichannelOrderManagerCustomerType__Three)(ctThree);
                }
                else
                {
                    type = new MultichannelOrderManagerCustomerType__Three(
                        ctThree.ID,
                        ctThree.CustomerType,
                        ctThree.Description,
                        ctThree.TypeId
                        );
                }
            }

            return type;
        }
    }
}

