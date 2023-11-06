using System;
using FluentNHibernate.Mapping;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.EntityMappings.Components
{
    /// <summary>
    /// Defines a component mapping for <see cref="MultichannelOrderManagerCounty"/> objects.
    /// </summary>
    public class MultichannelOrderManagerCountyComponentMap : MultichannelOrderManagerComponentMap<MultichannelOrderManagerCounty>
    {
        private const string COMPONENT_COL_PREFIX = "fa1ffe35";
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCountyComponentMap"/> with no arguments.
        /// </summary>
        public MultichannelOrderManagerCountyComponentMap()
            : base()
        {
            Map(c => c.Code).Length(1).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.Code)));
            Map(c => c.CountyId).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.CountyId)));
            Map(c => c.CountyCode).Length(3).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.CountyCode)));
            Map(c => c.LCAP_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.LCAP_A)));
            Map(c => c.LCAP_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.LCAP_B)));
            Map(c => c.LCAP_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.LCAP_C)));
            Map(c => c.LCAP_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.LCAP_D)));
            Map(c => c.LCAP_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.LCAP_E)));
            Map(c => c.LookupBy).Length(3).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.LookupBy)));
            Map(c => c.LookupOn).Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.LookupOn)));
            Map(c => c.FIPS).Length(5).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.FIPS)));
            Map(c => c.LTAXIT_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.LTAXIT_A)));
            Map(c => c.LTAXIT_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.LTAXIT_B)));
            Map(c => c.LTAXIT_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.LTAXIT_C)));
            Map(c => c.LTAXIT_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.LTAXIT_D)));
            Map(c => c.LTAXIT_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.LTAXIT_E)));
            Map(c => c.MSA).Length(4).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.MSA)));
            Map(c => c.Name).Length(25).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.Name)));
            Map(c => c.NCAP_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.NCAP_A)));
            Map(c => c.NCAP_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.NCAP_B)));
            Map(c => c.NCAP_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.NCAP_C)));
            Map(c => c.NCAP_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.NCAP_D)));
            Map(c => c.NCAP_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.NCAP_E)));
            Map(c => c.NONTAXBOX).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.NONTAXBOX)));
            Map(c => c.NTAXIT_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.NTAXIT_A)));
            Map(c => c.NTAXIT_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.NTAXIT_B)));
            Map(c => c.NTAXIT_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.NTAXIT_C)));
            Map(c => c.NTAXIT_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.NTAXIT_D)));
            Map(c => c.NTAXIT_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.NTAXIT_E)));
            Map(c => c.NTAXTHRES_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.NTAXTHRES_A)));
            Map(c => c.NTAXTHRES_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.NTAXTHRES_B)));
            Map(c => c.NTAXTHRES_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.NTAXTHRES_C)));
            Map(c => c.NTAXTHRES_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.NTAXTHRES_D)));
            Map(c => c.NTAXTHRES_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.NTAXTHRES_E)));
            Map(c => c.Presence).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.Presence)));
            Map(c => c.RateClass_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.RateClass_A)));
            Map(c => c.RateClass_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.RateClass_B)));
            Map(c => c.RateClass_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.RateClass_C)));
            Map(c => c.RateClass_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.RateClass_D)));
            Map(c => c.RateClass_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.RateClass_E)));
            Map(c => c.TaxHandling).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.TaxHandling)));
            Map(c => c.TaxRate).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.TaxRate)));
            Map(c => c.TaxShipping).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.TaxShipping)));
            Map(c => c.Tax_ClassA).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.Tax_ClassA)));
            Map(c => c.Tax_ClassB).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.Tax_ClassB)));
            Map(c => c.Tax_ClassC).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.Tax_ClassC)));
            Map(c => c.Tax_ClassD).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.Tax_ClassD)));
            Map(c => c.Tax_ClassE).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.Tax_ClassE)));
            Map(c => c.TimezoneOffset).Length(2).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.TimezoneOffset)));
            Map(c => c.Updated).Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerCounty.Updated)));

            //Component(c => c.Country, a => a.ColumnPrefix(COMPONENT_COL_PREFIX));
            //Component(c => c.Warehouse, a => a.ColumnPrefix(COMPONENT_COL_PREFIX));
            //Component(c => c.StateProvince, a => a.ColumnPrefix(COMPONENT_COL_PREFIX));

            Component(c => c.Country).ColumnPrefix(COMPONENT_COL_PREFIX);
            Component(c => c.Warehouse).ColumnPrefix(COMPONENT_COL_PREFIX);
            Component(c => c.StateProvince).ColumnPrefix(COMPONENT_COL_PREFIX);

            References<MultichannelOrderManagerServer>(c => c.Server).Not.Nullable().LazyLoad(Laziness.False).Column(GenerateColumnName(COMPONENT_COL_PREFIX + "_Server"));
        }
    }
}

