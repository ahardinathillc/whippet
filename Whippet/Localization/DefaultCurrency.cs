using System;
using NodaMoney;

namespace Athi.Whippet.Localization
{
    /// <summary>
    /// Provides a global default <see cref="Currency"/> value to fallback to when using <see cref="Money"/>. This class cannot be inherited.
    /// </summary>
    public static class DefaultCurrency
    {
        /// <summary>
        /// Retrieves the <see cref="Currency"/> for the United States Dollar (USD). This property is read-only.
        /// </summary>
        public static Currency USD => Currency.FromCode("USD");
    }
}

