using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Extensions.Primitives;

namespace Athi.Whippet.Localization.Addressing.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="City"/> objects.
    /// </summary>
    public class CityMap : WhippetFluentMap<City>
    {
        private const string TABLE_NAME = "Cities";

        private const string COL_LAT = "Latitude";
        private const string COL_LON = "Longitude";

        /// <summary>
        /// Initializes a new instance of the <see cref="CityMap"/> class with no arguments.
        /// </summary>
        public CityMap()
            : base(TABLE_NAME)
        {
            Map(c => c.Name).Length(ObjectExtensionMethods.GetDefaultEntityNameMaxLength()).Not.Nullable();

            Component(city => city.Coordinates, coord =>
            {
                coord.Map(l => l.Latitude).Column(COL_LAT).Nullable();
                coord.Map(l => l.Longitude).Column(COL_LON).Nullable();
            });

            References<StateProvince>(s => s.StateProvince).Not.Nullable().LazyLoad(Laziness.False);
        }
    }
}
