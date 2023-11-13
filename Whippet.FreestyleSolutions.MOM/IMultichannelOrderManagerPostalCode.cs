using System;
using Athi.Whippet.Data;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents a postal code and its associated tax information in M.O.M.
    /// </summary>
    public interface IMultichannelOrderManagerPostalCode : IWhippetEntity, IWhippetEntityExternalDataRowImportMapper, IEqualityComparer<IMultichannelOrderManagerPostalCode>, IMultichannelOrderManagerEntity, IWhippetEntityDynamicImportMapper, IWhippetCloneable, IComparable<IMultichannelOrderManagerPostalCode>
    {
        /// <summary>
        /// Gets or sets the unique ID of the <see cref="IMultichannelOrderManagerPostalCode"/>.
        /// </summary>
        new long ID
        { get; set; }

        /// <summary>
        /// Gets or sets the parent <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        IMultichannelOrderManagerCountry Country
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or sets the parent <see cref="MultichannelOrderManagerStateProvince"/>.
        /// </summary>
        IMultichannelOrderManagerStateProvince StateProvince
        { get; set; }

        /// <summary>
        /// Gets or sets the parent <see cref="MultichannelOrderManagerCounty"/>.
        /// </summary>
        IMultichannelOrderManagerCounty County
        { get; set; }

        /// <summary>
        /// Reserved for internal use.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string City
        { get; set; }

        /// <summary>
        /// Reserved for internal use.
        /// </summary>
        char Type
        { get; set; }

        /// <summary>
        /// Reserved for internal use.
        /// </summary>
        bool RTDTax
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code tax rate.
        /// </summary>
        decimal TaxRate
        { get; set; }

        /// <summary>
        /// Reserved for internal use.
        /// </summary>
        bool Presence
        { get; set; }

        /// <summary>
        /// Reserved for internal use.
        /// </summary>
        char Code1
        { get; set; }

        /// <summary>
        /// Reserved for internal use.
        /// </summary>
        bool Logic1
        { get; set; }

        /// <summary>
        /// Specifies the warehouse that serves the postal code.
        /// </summary>
        IMultichannelOrderManagerWarehouse Warehouse
        { get; set; }

        /// <summary>
        /// Indicates whether shipping is taxed for the postal code.
        /// </summary>
        bool TaxShipping
        { get; set; }

        /// <summary>
        /// Indicates whether the postal code is sales tax class A taxable.
        /// </summary>
        bool TaxClass_A
        { get; set; }

        /// <summary>
        /// Indicates whether the postal code is sales tax class B taxable.
        /// </summary>
        bool TaxClass_B
        { get; set; }

        /// <summary>
        /// Indicates whether the postal code is sales tax class C taxable.
        /// </summary>
        bool TaxClass_C
        { get; set; }

        /// <summary>
        /// Indicates whether the postal code is sales tax class D taxable.
        /// </summary>
        bool TaxClass_D
        { get; set; }

        /// <summary>
        /// Indicates whether the postal code is sales tax class E taxable.
        /// </summary>
        bool TaxClass_E
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code sales tax rate for class A.
        /// </summary>
        decimal RateClass_A
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code sales tax rate for class B.
        /// </summary>
        decimal RateClass_B
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code sales tax rate for class C.
        /// </summary>
        decimal RateClass_C
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code sales tax rate for class D.
        /// </summary>
        decimal RateClass_D
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code sales tax rate for class E.
        /// </summary>
        decimal RateClass_E
        { get; set; }

        /// <summary>
        /// Indicates whether to stop taxing after the order total exceeds flag for tax class A.
        /// </summary>
        bool FlagCapTaxClass_A
        { get; set; }

        /// <summary>
        /// Indicates whether to stop taxing after the order total exceeds flag for tax class B.
        /// </summary>
        bool FlagCapTaxClass_B
        { get; set; }

        /// <summary>
        /// Indicates whether to stop taxing after the order total exceeds flag for tax class C.
        /// </summary>
        bool FlagCapTaxClass_C
        { get; set; }

        /// <summary>
        /// Indicates whether to stop taxing after the order total exceeds flag for tax class D.
        /// </summary>
        bool FlagCapTaxClass_D
        { get; set; }

        /// <summary>
        /// Indicates whether to stop taxing after the order total exceeds flag for tax class E.
        /// </summary>
        bool FlagCapTaxClass_E
        { get; set; }

        /// <summary>
        /// Gets or sets the amount in which to stop taxing after the order total exceeds amount for tax class A.
        /// </summary>
        decimal TotalCapTaxClass_A
        { get; set; }

        /// <summary>
        /// Gets or sets the amount in which to stop taxing after the order total exceeds amount for tax class B.
        /// </summary>
        decimal TotalCapTaxClass_B
        { get; set; }

        /// <summary>
        /// Gets or sets the amount in which to stop taxing after the order total exceeds amount for tax class C.
        /// </summary>
        decimal TotalCapTaxClass_C
        { get; set; }

        /// <summary>
        /// Gets or sets the amount in which to stop taxing after the order total exceeds amount for tax class D.
        /// </summary>
        decimal TotalCapTaxClass_D
        { get; set; }

        /// <summary>
        /// Gets or sets the amount in which to stop taxing after the order total exceeds amount for tax class E.
        /// </summary>
        decimal TotalCapTaxClass_E
        { get; set; }

        /// <summary>
        /// Gets or sets the amount in which to start taxing after the order total exceeds amount for tax class A.
        /// </summary>
        decimal ExceedAmountTaxClass_A
        { get; set; }

        /// <summary>
        /// Gets or sets the amount in which to start taxing after the order total exceeds amount for tax class B.
        /// </summary>
        decimal ExceedAmountTaxClass_B
        { get; set; }

        /// <summary>
        /// Gets or sets the amount in which to start taxing after the order total exceeds amount for tax class C.
        /// </summary>
        decimal ExceedAmountTaxClass_C
        { get; set; }

        /// <summary>
        /// Gets or sets the amount in which to start taxing after the order total exceeds amount for tax class D.
        /// </summary>
        decimal ExceedAmountTaxClass_D
        { get; set; }

        /// <summary>
        /// Gets or sets the amount in which to start taxing after the order total exceeds amount for tax class E.
        /// </summary>
        decimal ExceedAmountTaxClass_E
        { get; set; }

        /// <summary>
        /// Specifies whether to tax shipping on boxes with all non-taxable items for state/province tax rates.
        /// </summary>
        bool DoNotTaxShippingOnBoxesWithAllNonTaxableItems
        { get; set; }

        /// <summary>
        /// Specifies whether to tax amounts below <see cref="ExceedAmountTaxClass_A"/>.
        /// </summary>
        bool DoNotTaxExceedAmountTaxClass_A
        { get; set; }

        /// <summary>
        /// Specifies whether to tax amounts below <see cref="ExceedAmountTaxClass_B"/>.
        /// </summary>
        bool DoNotTaxExceedAmountTaxClass_B
        { get; set; }

        /// <summary>
        /// Specifies whether to tax amounts below <see cref="ExceedAmountTaxClass_C"/>.
        /// </summary>
        bool DoNotTaxExceedAmountTaxClass_C
        { get; set; }

        /// <summary>
        /// Specifies whether to tax amounts below <see cref="ExceedAmountTaxClass_D"/>.
        /// </summary>
        bool DoNotTaxExceedAmountTaxClass_D
        { get; set; }

        /// <summary>
        /// Specifies whether to tax amounts below <see cref="ExceedAmountTaxClass_E"/>.
        /// </summary>
        bool DoNotTaxExceedAmountTaxClass_E
        { get; set; }

        /// <summary>
        /// Indicates whether to tax handling fees only at postal code tax rates.
        /// </summary>
        bool TaxHandlingFeesPostalCodeTaxRateOnly
        { get; set; }

        /// <summary>
        /// This property is reserved for use by M.O.M.
        /// </summary>
        bool TaxUpdate
        { get; set; }

        /// <summary>
        /// Gets or sets the username of the user who last accessed the record.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string LookupBy
        { get; set; }

        /// <summary>
        /// Gets or sets the timestamp the record was last accessed.
        /// </summary>
        DateTime? LookupOn
        { get; set; }
    }
}
