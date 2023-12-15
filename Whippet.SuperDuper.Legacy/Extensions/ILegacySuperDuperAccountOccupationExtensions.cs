using System;

namespace Athi.Whippet.SuperDuper.Legacy.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ILegacySuperDuperAccountOccupation"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ILegacySuperDuperAccountOccupationExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ILegacySuperDuperAccountOccupation"/> instance to a <see cref="LegacySuperDuperAccountOccupation"/> object.
        /// </summary>
        /// <param name="occupation"><see cref="ILegacySuperDuperAccountOccupation"/> object to convert.</param>
        /// <returns></returns>
        public static LegacySuperDuperAccountOccupation ToLegacySuperDuperAccountOccupation(this ILegacySuperDuperAccountOccupation occupation)
        {
            LegacySuperDuperAccountOccupation lsdao = null;

            if (occupation is LegacySuperDuperAccountOccupation)
            {
                lsdao = (LegacySuperDuperAccountOccupation)(lsdao);
            }
            else if (occupation != null)
            {
                lsdao = new LegacySuperDuperAccountOccupation(occupation.ID, occupation.Title, occupation.Display, occupation.DisplayOrder, occupation.Categorization);
            }

            return lsdao;
        }
    }
}
