using System;
using FluentNHibernate.Mapping;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.EntityMappings.Components
{
    /// <summary>
    /// Defines a component mapping for <see cref="MultichannelOrderManagerCountry"/> objects.
    /// </summary>
    public class MultichannelOrderManagerCountryComponentMap : MultichannelOrderManagerComponentMap<MultichannelOrderManagerCountry>
    {
        private const string COMPONENT_COL_PREFIX = "cf849092";

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCountryComponentMap"/> with no arguments.
        /// </summary>
        public MultichannelOrderManagerCountryComponentMap()
            : base()
        {
            Map(c => c.CountryCode).Length(3).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.CountryCode)));
            Map(c => c.CountryId).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.CountryId)));
            Map(c => c.ISO2).Length(2).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.ISO2)));
            Map(c => c.ISO3).Length(3).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.ISO3)));
            Map(c => c.ISONumber).Length(3).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.ISONumber)));
            Map(c => c.LCAP_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.LCAP_A)));
            Map(c => c.LCAP_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.LCAP_B)));
            Map(c => c.LCAP_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.LCAP_C)));
            Map(c => c.LCAP_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.LCAP_D)));
            Map(c => c.LCAP_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.LCAP_E)));
            Map(c => c.LookupBy).Length(3).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.LookupBy)));
            Map(c => c.LookupOn).Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.LookupOn)));
            Map(c => c.LTAXIT_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.LTAXIT_A)));
            Map(c => c.LTAXIT_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.LTAXIT_B)));
            Map(c => c.LTAXIT_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.LTAXIT_C)));
            Map(c => c.LTAXIT_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.LTAXIT_D)));
            Map(c => c.LTAXIT_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.LTAXIT_E)));
            Map(c => c.Name).Length(40).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.Name)));
            Map(c => c.NationalTaxRate).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.NationalTaxRate)));
            Map(c => c.NCAP_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.NCAP_A)));
            Map(c => c.NCAP_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.NCAP_B)));
            Map(c => c.NCAP_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.NCAP_C)));
            Map(c => c.NCAP_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.NCAP_D)));
            Map(c => c.NCAP_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.NCAP_E)));
            Map(c => c.NONTAXBOX).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.NONTAXBOX)));
            Map(c => c.NTAXIT_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.NTAXIT_A)));
            Map(c => c.NTAXIT_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.NTAXIT_B)));
            Map(c => c.NTAXIT_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.NTAXIT_C)));
            Map(c => c.NTAXIT_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.NTAXIT_D)));
            Map(c => c.NTAXIT_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.NTAXIT_E)));
            Map(c => c.NTAXTHRES_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.NTAXTHRES_A)));
            Map(c => c.NTAXTHRES_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.NTAXTHRES_B)));
            Map(c => c.NTAXTHRES_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.NTAXTHRES_C)));
            Map(c => c.NTAXTHRES_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.NTAXTHRES_D)));
            Map(c => c.NTAXTHRES_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.NTAXTHRES_E)));
            Map(c => c.PhoneMask).Length(18).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.PhoneMask)));
            Map(c => c.RateClass_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.RateClass_A)));
            Map(c => c.RateClass_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.RateClass_B)));
            Map(c => c.RateClass_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.RateClass_C)));
            Map(c => c.RateClass_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.RateClass_D)));
            Map(c => c.RateClass_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.RateClass_E)));
            Map(c => c.TaxHandling).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.TaxHandling)));
            Map(c => c.TaxShipping).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.TaxShipping)));
            Map(c => c.Tax_ClassA).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.Tax_ClassA)));
            Map(c => c.Tax_ClassB).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.Tax_ClassB)));
            Map(c => c.Tax_ClassC).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.Tax_ClassC)));
            Map(c => c.Tax_ClassD).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.Tax_ClassD)));
            Map(c => c.Tax_ClassE).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCountry.Tax_ClassE)));

            Component(c => c.Warehouse).ColumnPrefix(COMPONENT_COL_PREFIX);

            References<MultichannelOrderManagerServer>(c => c.Server).Not.Nullable().LazyLoad(Laziness.False).Column(GenerateColumnName(COMPONENT_COL_PREFIX + "_Server"));
        }
    }
}

