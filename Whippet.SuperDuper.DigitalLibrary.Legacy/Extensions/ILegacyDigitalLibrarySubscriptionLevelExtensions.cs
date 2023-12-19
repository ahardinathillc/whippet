using System;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ILegacyDigitalLibrarySubscriptionLevel"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ILegacyDigitalLibrarySubscriptionLevelExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ILegacyDigitalLibrarySubscriptionLevel"/> object to a <see cref="LegacyDigitalLibrarySubscriptionLevel"/> object.
        /// </summary>
        /// <param name="level"><see cref="ILegacyDigitalLibrarySubscriptionLevel"/> object to convert.</param>
        /// <returns><see cref="LegacyDigitalLibrarySubscriptionLevel"/> object.</returns>
        public static LegacyDigitalLibrarySubscriptionLevel ToLegacyDigitalLibrarySubscriptionLevel(this ILegacyDigitalLibrarySubscriptionLevel level)
        {
            LegacyDigitalLibrarySubscriptionLevel sddlLevel = null;

            if (level is LegacyDigitalLibrarySubscriptionLevel)
            {
                sddlLevel = (LegacyDigitalLibrarySubscriptionLevel)(level);
            }
            else if (level != null)
            {
                sddlLevel = new LegacyDigitalLibrarySubscriptionLevel(level.ID, level.Name);
            }

            return sddlLevel;
        }
    }
}
