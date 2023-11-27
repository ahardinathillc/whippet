using System;

namespace Athi.Whippet.Adobe.Magento.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="Boolean"/> values for Magento. This class cannot be inherited.
    /// </summary>
    public static class BooleanExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="Boolean"/> value to its equivalent Magento flag value. 
        /// </summary>
        /// <param name="value"><see cref="Boolean"/> value to convert.</param>
        /// <returns>Magento flag value.</returns>
        public static int ToMagentoBoolean(this bool value)
        {
            return value ? 1 : 0;
        }

        /// <summary>
        /// Converts the specified <see cref="Int32"/> value to its equivalent <see cref="Boolean"/> value.
        /// </summary>
        /// <param name="value"><see cref="Int32"/> value to convert.</param>
        /// <returns><see cref="Boolean"/> value.</returns>
        public static bool FromMagentoBoolean(this int value)
        {
            return (value > 1) ? true : false;
        }
    }
}
