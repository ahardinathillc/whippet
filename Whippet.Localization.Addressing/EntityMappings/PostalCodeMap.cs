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
    /// Provides a Fluent mapping for <see cref="PostalCode"/> objects.
    /// </summary>
    public class PostalCodeMap : WhippetFluentMap<PostalCode>
    {
        private const string TABLE_NAME = "PostalCodes";

        private const string COL_LAT = "Latitude";
        private const string COL_LON = "Longitude";

        /// <summary>
        /// Initializes a new instance of the <see cref="PostalCodeMap"/> class with no arguments.
        /// </summary>
        public PostalCodeMap()
            : base(TABLE_NAME)
        {
            Map(pc => pc.Value).Length(ObjectExtensionMethods.GetDefaultEntityNameMaxLength()).Not.Nullable();

            Component(pCode => pCode.Coordinates, coord =>
            {
                coord.Map(l => l.Latitude).Column(COL_LAT).Nullable();
                coord.Map(l => l.Longitude).Column(COL_LON).Nullable();
            });

            References<City>(c => c.City).Not.Nullable().LazyLoad(Laziness.False);
        }
    }
}
