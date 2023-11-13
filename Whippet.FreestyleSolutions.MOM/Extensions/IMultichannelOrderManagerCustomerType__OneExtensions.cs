using System;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ICustomerType__One"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IMultichannelOrderManagerCustomerType__OneExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IMultichannelOrderManagerCustomerType__One"/> object to a <see cref="MultichannelOrderManagerCustomerType__One"/> object.
        /// </summary>
        /// <param name="ctOne"><see cref="IMultichannelOrderManagerCustomerType__One"/> object to convert.</param>
        /// <returns><see cref="MultichannelOrderManagerCustomerType__One"/> object.</returns>
        public static MultichannelOrderManagerCustomerType__One ToCustomerType__One(this IMultichannelOrderManagerCustomerType__One ctOne)
        {
            MultichannelOrderManagerCustomerType__One type = null;

            if (ctOne != null)
            {
                if (ctOne is MultichannelOrderManagerCustomerType__One)
                {
                    type = (MultichannelOrderManagerCustomerType__One)(ctOne);
                }
                else
                {
                    type = new MultichannelOrderManagerCustomerType__One(
                        ctOne.ID,
                        ctOne.CustomerType,
                        ctOne.Description,
                        ctOne.TypeId
                        );
                }
            }

            return type;
        }
    }
}
