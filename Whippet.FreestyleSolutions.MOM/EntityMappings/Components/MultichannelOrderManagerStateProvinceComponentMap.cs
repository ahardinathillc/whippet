using System;
using FluentNHibernate.Mapping;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.EntityMappings.Components
{
    /// <summary>
    /// Defines a component mapping for <see cref="MultichannelOrderManagerStateProvince"/> objects.
    /// </summary>
    public class MultichannelOrderManagerStateProvinceComponentMap : MultichannelOrderManagerComponentMap<MultichannelOrderManagerStateProvince>
    {
        private const string COMPONENT_COL_PREFIX = "d5bf90af";

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerStateProvinceComponentMap"/> with no arguments.
        /// </summary>
        public MultichannelOrderManagerStateProvinceComponentMap()
            : base()
        {
            Map(sp => sp.Abbreviation).Length(3).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.Abbreviation)));
            Map(sp => sp.DoNotTaxExceedAmountTaxClass_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.DoNotTaxExceedAmountTaxClass_A)));
            Map(sp => sp.DoNotTaxExceedAmountTaxClass_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.DoNotTaxExceedAmountTaxClass_B)));
            Map(sp => sp.DoNotTaxExceedAmountTaxClass_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.DoNotTaxExceedAmountTaxClass_C)));
            Map(sp => sp.DoNotTaxExceedAmountTaxClass_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.DoNotTaxExceedAmountTaxClass_D)));
            Map(sp => sp.DoNotTaxExceedAmountTaxClass_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.DoNotTaxExceedAmountTaxClass_E)));
            Map(sp => sp.DoNotTaxShippingOnBoxesWithAllNonTaxableItems).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.DoNotTaxShippingOnBoxesWithAllNonTaxableItems)));
            Map(sp => sp.ExceedAmountTaxClass_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.ExceedAmountTaxClass_A)));
            Map(sp => sp.ExceedAmountTaxClass_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.ExceedAmountTaxClass_B)));
            Map(sp => sp.ExceedAmountTaxClass_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.ExceedAmountTaxClass_C)));
            Map(sp => sp.ExceedAmountTaxClass_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.ExceedAmountTaxClass_D)));
            Map(sp => sp.ExceedAmountTaxClass_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.ExceedAmountTaxClass_E)));
            Map(sp => sp.FinanceChargesRate).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.FinanceChargesRate)));
            Map(sp => sp.FlagCapTaxClass_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.FlagCapTaxClass_A)));
            Map(sp => sp.FlagCapTaxClass_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.FlagCapTaxClass_B)));
            Map(sp => sp.FlagCapTaxClass_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.FlagCapTaxClass_C)));
            Map(sp => sp.FlagCapTaxClass_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.FlagCapTaxClass_D)));
            Map(sp => sp.FlagCapTaxClass_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.FlagCapTaxClass_E)));
            Map(sp => sp.High).Length(3).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.High)));
            Map(sp => sp.ID).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.ID)));
            Map(sp => sp.LookupBy).Length(3).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.LookupBy)));
            Map(sp => sp.LookupOn).Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.LookupOn)));
            Map(sp => sp.Low).Length(3).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.Low)));
            Map(sp => sp.Name).Length(25).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.Name)));
            Map(sp => sp.Presence).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.Presence)));
            Map(sp => sp.RateClass_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.RateClass_A)));
            Map(sp => sp.RateClass_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.RateClass_B)));
            Map(sp => sp.RateClass_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.RateClass_C)));
            Map(sp => sp.RateClass_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.RateClass_D)));
            Map(sp => sp.RateClass_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.RateClass_E)));
            Map(sp => sp.TaxClass_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.TaxClass_A)));
            Map(sp => sp.TaxClass_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.TaxClass_B)));
            Map(sp => sp.TaxClass_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.TaxClass_C)));
            Map(sp => sp.TaxClass_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.TaxClass_D)));
            Map(sp => sp.TaxClass_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.TaxClass_E)));
            Map(sp => sp.TaxHandlingFeesNationalTaxRateOnly).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.TaxHandlingFeesNationalTaxRateOnly)));
            Map(sp => sp.TaxRate).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.TaxRate)));
            Map(sp => sp.TaxShipping).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.TaxShipping)));
            Map(sp => sp.TaxUpdate).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.TaxUpdate)));
            Map(sp => sp.TotalCapTaxClass_A).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.TotalCapTaxClass_A)));
            Map(sp => sp.TotalCapTaxClass_B).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.TotalCapTaxClass_B)));
            Map(sp => sp.TotalCapTaxClass_C).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.TotalCapTaxClass_C)));
            Map(sp => sp.TotalCapTaxClass_D).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.TotalCapTaxClass_D)));
            Map(sp => sp.TotalCapTaxClass_E).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerStateProvince.TotalCapTaxClass_E)));

            //Component(sp => sp.Country, a => a.ColumnPrefix(COMPONENT_COL_PREFIX));
            //Component(sp => sp.Warehouse, a => a.ColumnPrefix(COMPONENT_COL_PREFIX));

            Component(sp => sp.Country).ColumnPrefix(COMPONENT_COL_PREFIX);
            Component(sp => sp.Warehouse).ColumnPrefix(COMPONENT_COL_PREFIX);

            References<MultichannelOrderManagerServer>(c => c.Server).Not.Nullable().LazyLoad(Laziness.False).Column(GenerateColumnName(COMPONENT_COL_PREFIX + "_Server"));
        }
    }
}

