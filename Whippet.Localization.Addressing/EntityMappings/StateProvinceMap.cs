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
    /// Provides a Fluent mapping for <see cref="StateProvince"/> objects.
    /// </summary>
    public class StateProvinceMap : WhippetFluentMap<StateProvince>
    {
        private const string TABLE_NAME = "[Localization.StateProvinces]";

        /// <summary>
        /// Initializes a new instance of the <see cref="StateProvinceMap"/> class with no arguments.
        /// </summary>
        public StateProvinceMap()
            : base(TABLE_NAME)
        {
            Map(s => s.Abbreviation).Length(ObjectExtensionMethods.GetDefaultStringLength()).Nullable();
            Map(s => s.Name).Length(ObjectExtensionMethods.GetDefaultStringLength()).Not.Nullable();

            References<Country>(s => s.Country).Not.Nullable().LazyLoad(Laziness.False);
        }
    }
}
