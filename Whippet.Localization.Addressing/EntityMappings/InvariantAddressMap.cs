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
    /// Provides a Fluent mapping for <see cref="InvariantAddressMap"/> objects.
    /// </summary>
    public class InvariantAddressMap : WhippetFluentMap<InvariantAddress>
    {
        private const string TABLE_NAME = "[Localization.Addresses]";

        /// <summary>
        /// Initializes a new instance of the <see cref="InvariantAddressMap"/> class with no arguments.
        /// </summary>
        public InvariantAddressMap()
            : base(TABLE_NAME)
        {
            Map(ia => ia.LineOne).Length(ObjectExtensionMethods.GetMaximumStringLength()).Nullable();
            Map(ia => ia.LineTwo).Length(ObjectExtensionMethods.GetMaximumStringLength()).Nullable();
            Map(ia => ia.LineThree).Length(ObjectExtensionMethods.GetMaximumStringLength()).Nullable();
            Map(ia => ia.LineFour).Length(ObjectExtensionMethods.GetMaximumStringLength()).Nullable();

            References<City>(c => c.City).Not.Nullable().LazyLoad(Laziness.False);
            References<PostalCode>(ia => ia.PostalCode).Not.Nullable();
        }
    }
}
