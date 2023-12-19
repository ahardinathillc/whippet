using System;

namespace Athi.Whippet.SuperDuper.Legacy.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ILegacySuperDuperCountry"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ILegacySuperDuperCountryExtensions
    {
        public static LegacySuperDuperCountry ToLegacySuperDuperCountry(this ILegacySuperDuperCountry country)
        {
            LegacySuperDuperCountry c = null;

            if (country is LegacySuperDuperCountry)
            {
                c = (LegacySuperDuperCountry)(country);
            }
            else if (country != null)
            {
                c = new LegacySuperDuperCountry(country.ID);
                c.Name = country.Name;
                c.DisplayOrder = country.DisplayOrder;
                c.FreeShipping = country.FreeShipping;
                c.IsDefaultSelection = country.IsDefaultSelection;
                c.PayPalCode = country.PayPalCode;
                //TODO: add multichannel order manager property (new)
            }

            return c;
        }
    }
}
