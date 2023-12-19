using System;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ILegacyDigitalLibrarySubscriptionPeriod"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ILegacyDigitalLibrarySubscriptionPeriodExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ILegacyDigitalLibrarySubscriptionPeriod"/> object to a <see cref="LegacyDigitalLibrarySubscriptionPeriod"/> object.
        /// </summary>
        /// <param name="period"><see cref="ILegacyDigitalLibrarySubscriptionPeriod"/> object to convert.</param>
        /// <returns><see cref="LegacyDigitalLibrarySubscriptionPeriod"/> object.</returns>
        public static LegacyDigitalLibrarySubscriptionPeriod ToLegacyDigitalLibrarySubscriptionPeriod(this ILegacyDigitalLibrarySubscriptionPeriod period)
        {
            LegacyDigitalLibrarySubscriptionPeriod sddlPeriod = null;

            if (period is LegacyDigitalLibrarySubscriptionPeriod)
            {
                sddlPeriod = (LegacyDigitalLibrarySubscriptionPeriod)(period);
            }
            else if (period != null)
            {
                sddlPeriod = new LegacyDigitalLibrarySubscriptionPeriod(period.ID, period.Name);
            }

            return sddlPeriod;
        }
    }
}
