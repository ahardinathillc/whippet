using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data;
using Athi.Whippet.Data.NHibernate.UserTypes.NodaTime;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Extensions.Primitives;

namespace Athi.Whippet.Localization.Addressing.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="Country"/> objects.
    /// </summary>
    public class CountryMap : WhippetFluentMap<Country>
    {
        private const string TABLE_NAME = "[Localization.Countries]";
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryMap"/> class with no arguments.
        /// </summary>
        public CountryMap()
            : base(TABLE_NAME)
        {
            Map(c => c.Abbreviation).Length(ObjectExtensionMethods.GetDefaultStringLength()).Nullable();
            Map(c => c.CallingCode).Length(ObjectExtensionMethods.GetDefaultStringLength()).Nullable();
            Map(c => c.Name).Length(ObjectExtensionMethods.GetMaximumStringLength()).Not.Nullable();
            Map(c => c.Region).Nullable();
        }
    }
}
