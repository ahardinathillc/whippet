using System;
using FluentNHibernate.Mapping;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.EntityMappings.Components
{
    /// <summary>
    /// Defines a component mapping for <see cref="MultichannelOrderManagerPostalCode"/> objects.
    /// </summary>
    public class MultichannelOrderManagerPostalCodeComponentMap : MultichannelOrderManagerComponentMap<MultichannelOrderManagerPostalCode>
    {
        private const string COMPONENT_COL_PREFIX = "d35417ab";
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerPostalCodeComponentMap"/> with no arguments.
        /// </summary>
        public MultichannelOrderManagerPostalCodeComponentMap()
            : base()
        {
            Map(pc => pc.City).Length(30).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.City)));
            Map(pc => pc.Code1).Length(1).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.Code1)));
            Map(pc => pc.DoNotTaxExceedAmountTaxClass_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.DoNotTaxExceedAmountTaxClass_A)));
            Map(pc => pc.DoNotTaxExceedAmountTaxClass_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.DoNotTaxExceedAmountTaxClass_B)));
            Map(pc => pc.DoNotTaxExceedAmountTaxClass_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.DoNotTaxExceedAmountTaxClass_C)));
            Map(pc => pc.DoNotTaxExceedAmountTaxClass_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.DoNotTaxExceedAmountTaxClass_D)));
            Map(pc => pc.DoNotTaxExceedAmountTaxClass_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.DoNotTaxExceedAmountTaxClass_E)));
            Map(pc => pc.DoNotTaxShippingOnBoxesWithAllNonTaxableItems).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.DoNotTaxShippingOnBoxesWithAllNonTaxableItems)));
            Map(pc => pc.ExceedAmountTaxClass_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.ExceedAmountTaxClass_A)));
            Map(pc => pc.ExceedAmountTaxClass_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.ExceedAmountTaxClass_B)));
            Map(pc => pc.ExceedAmountTaxClass_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.ExceedAmountTaxClass_C)));
            Map(pc => pc.ExceedAmountTaxClass_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.ExceedAmountTaxClass_D)));
            Map(pc => pc.ExceedAmountTaxClass_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.ExceedAmountTaxClass_E)));
            Map(pc => pc.FlagCapTaxClass_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.FlagCapTaxClass_A)));
            Map(pc => pc.FlagCapTaxClass_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.FlagCapTaxClass_B)));
            Map(pc => pc.FlagCapTaxClass_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.FlagCapTaxClass_C)));
            Map(pc => pc.FlagCapTaxClass_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.FlagCapTaxClass_D)));
            Map(pc => pc.FlagCapTaxClass_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.FlagCapTaxClass_E)));
            Map(pc => pc.ID).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.ID)));
            Map(pc => pc.Logic1).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.Logic1)));
            Map(pc => pc.LookupBy).Length(3).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.LookupBy)));
            Map(pc => pc.LookupOn).Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.LookupOn)));
            Map(pc => pc.PostalCode).Length(7).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.PostalCode)));
            Map(pc => pc.Presence).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.Presence)));
            Map(pc => pc.RateClass_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.RateClass_A)));
            Map(pc => pc.RateClass_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.RateClass_B)));
            Map(pc => pc.RateClass_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.RateClass_C)));
            Map(pc => pc.RateClass_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.RateClass_D)));
            Map(pc => pc.RateClass_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.RateClass_E)));
            Map(pc => pc.RTDTax).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.RTDTax)));
            Map(pc => pc.TaxClass_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.TaxClass_A)));
            Map(pc => pc.TaxClass_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.TaxClass_B)));
            Map(pc => pc.TaxClass_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.TaxClass_C)));
            Map(pc => pc.TaxClass_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.TaxClass_D)));
            Map(pc => pc.TaxClass_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.TaxClass_E)));
            Map(pc => pc.TaxHandlingFeesPostalCodeTaxRateOnly).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.TaxHandlingFeesPostalCodeTaxRateOnly)));
            Map(pc => pc.TaxRate).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.TaxRate)));
            Map(pc => pc.TaxShipping).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.TaxShipping)));
            Map(pc => pc.TaxUpdate).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.TaxUpdate)));
            Map(pc => pc.TotalCapTaxClass_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.TotalCapTaxClass_A)));
            Map(pc => pc.TotalCapTaxClass_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.TotalCapTaxClass_B)));
            Map(pc => pc.TotalCapTaxClass_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.TotalCapTaxClass_C)));
            Map(pc => pc.TotalCapTaxClass_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.TotalCapTaxClass_D)));
            Map(pc => pc.TotalCapTaxClass_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.TotalCapTaxClass_E)));
            Map(pc => pc.Type).Length(1).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerPostalCode.Type)));

            //Component(pc => pc.Country, a => a.ColumnPrefix(COMPONENT_COL_PREFIX));
            //Component(pc => pc.County, a => a.ColumnPrefix(COMPONENT_COL_PREFIX));
            //Component(pc => pc.StateProvince, a => a.ColumnPrefix(COMPONENT_COL_PREFIX));
            //Component(pc => pc.Warehouse, a => a.ColumnPrefix(COMPONENT_COL_PREFIX));

            Component(c => c.Country).ColumnPrefix(COMPONENT_COL_PREFIX);
            Component(c => c.Warehouse).ColumnPrefix(COMPONENT_COL_PREFIX);
            Component(c => c.StateProvince).ColumnPrefix(COMPONENT_COL_PREFIX);
            Component(pc => pc.County).ColumnPrefix(COMPONENT_COL_PREFIX);

            References<MultichannelOrderManagerServer>(c => c.Server).Not.Nullable().LazyLoad(Laziness.False).Column(GenerateColumnName(COMPONENT_COL_PREFIX + "_Server"));
        }
    }
}
