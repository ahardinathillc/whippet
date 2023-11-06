using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Localization.Addressing.Extensions
{
    /// <summary>
    /// Provides extensions for <see cref="City"/> and <see cref="ICity"/> objects. This class cannot be inherited.
    /// </summary>
    public static class CityExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ICity"/> object to a <see cref="City"/> object.
        /// </summary>
        /// <param name="city"><see cref="ICity"/> object to convert.</param>
        /// <returns><see cref="ICity"/> object.</returns>
        public static City ToCity(this ICity city)
        {
            City cty = null;

            if (city != null)
            {
                if (city is City)
                {
                    cty = ((City)(city));
                }
                else
                {
                    cty = new City(city.ID, city.Name, city.StateProvince?.ToStateProvince(), city.Coordinates);
                }
            }

            return cty;
        }
    }
}
