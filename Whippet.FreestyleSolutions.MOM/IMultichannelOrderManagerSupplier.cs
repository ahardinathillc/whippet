using System;
using System.Diagnostics.Contracts;
using Athi.Whippet.Data;
using static NHibernate.Engine.Query.CallableParser;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents a stock item supplier in the Multichannel Order Management (M.O.M.) system.
    /// </summary>
    public interface IMultichannelOrderManagerSupplier : IWhippetEntity, IWhippetEntityExternalDataRowImportMapper, IEqualityComparer<IMultichannelOrderManagerSupplier>, IMultichannelOrderManagerEntity, IMultichannelOrderManagerLookup
    {
        /// <summary>
        /// Unique record identifier of the supplier.
        /// </summary>
        long SupplierID
        { get; set; }

        /// <summary>
        /// Indicates whether the supplier can drop-ship items.
        /// </summary>
        bool CanDropShip
        { get; set; }

        /// <summary>
        /// Discount allowed by supplier.
        /// </summary>
        decimal DiscountPercent
        { get; set; }

        /// <summary>
        /// Number of days for discount.
        /// </summary>
        int DiscountDays
        { get; set; }

        /// <summary>
        /// Number of days invoice is due.
        /// </summary>
        int DueDays
        { get; set; }

        /// <summary>
        /// Indicates whether the supplier allows terms.
        /// </summary>
        bool AllowTerms
        { get; set; }

        /// <summary>
        /// Indicates whether purchase orders are printed.
        /// </summary>
        bool PrintPurchaseOrders
        { get; set; }

        /// <summary>
        /// Indicates whether purchase orders are e-mailed.
        /// </summary>
        bool EmailPurchaseOrders
        { get; set; }

        /// <summary>
        /// Indicates whether purchase orders are faxed.
        /// </summary>
        bool FaxPurchaseOrders
        { get; set; }

        /// <summary>
        /// Specifies the payment terms.
        /// </summary>
        char PaymentTerms
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        bool LoadZones
        { get; set; }

        /// <summary>
        /// Reserved for internal use by M.O.M.
        /// </summary>
        decimal LeadAverage
        { get; set; }

        /// <summary>
        /// Minimum units required for the supplier.
        /// </summary>
        decimal MinimumUnits
        { get; set; }

        /// <summary>
        /// Minimum order amount required for the supplier.
        /// </summary>
        decimal MinimumAmount
        { get; set; }

        /// <summary>
        /// Indicates a minimum is required for the supplier.
        /// </summary>
        bool MinimumRequired
        { get; set; }

        /// <summary>
        /// Indicates whether the supplier code and associated purchasing levels will display during purchasing.
        /// </summary>
        bool Inactive
        { get; set; }

        /// <summary>
        /// Indicates if the landed cost adjustment will be determined by the product's value.
        /// </summary>
        bool LandedCostAdjustmentDeterminedByProductValue
        { get; set; }

        /// <summary>
        /// Indicates if the landed cost adjustment will be determined by the product's volume.
        /// </summary>
        bool LandedCostAdjustmentDeterminedByProductVolume
        { get; set; }

        /// <summary>
        /// Indicates if the landed cost adjustment will be determined by the product's weight.
        /// </summary>
        bool LandedCostAdjustmentDeterminedByProductWeight
        { get; set; }

        /// <summary>
        /// Indicates if the landed cost tax will be determined by the product's value.
        /// </summary>
        bool LandedCostTaxDerterminedByProductValue
        { get; set; }

        /// <summary>
        /// Indicates if the landed cost tax will be determined by the product's volume.
        /// </summary>
        bool LandedCostTaxDeterminedByProductVolume
        { get; set; }

        /// <summary>
        /// Indicates if the landed cost tax will be determined by the product's weight.
        /// </summary>
        bool LandedCostTaxDeterminedByProductWeight
        { get; set; }

        /// <summary>
        /// Indicates if the shipping landed cost will be determined by the product's value.
        /// </summary>
        bool ShippingLandedCostDeterminedByValue
        { get; set; }

        /// <summary>
        /// Indicates if the shipping landed cost will be determined by the product's volume.
        /// </summary>
        bool ShippingLandedCostDeterminedByVolume
        { get; set; }

        /// <summary>
        /// Indicates if the shipping landed cost will be determined by the product's weight.
        /// </summary>
        bool ShippingLandedCostDeterminedByWeight
        { get; set; }

        /// <summary>
        /// Specifies the maximum volume per shipment.
        /// </summary>
        decimal MaximumVolume
        { get; set; }

        /// <summary>
        /// Specifies the minimum volume per shipment.
        /// </summary>
        decimal MinimumVolume
        { get; set; }

        /// <summary>
        /// Specifies the minimum weight per shipment.
        /// </summary>
        decimal MinimumWeight
        { get; set; }

        /// <summary>
        /// Specifies the maximum weight per shipment.
        /// </summary>
        decimal MaximumWeight
        { get; set; }

        /// <summary>
        /// Supplier code.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        string Code
        { get; set; }

        /// <summary>
        /// Supplier name.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        string Name
        { get; set; }

        /// <summary>
        /// First address line.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        string AddressLineOne
        { get; set; }

        /// <summary>
        /// Second address line.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        string AddressLineTwo
        { get; set; }

        /// <summary>
        /// Third address line.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        string AddressLineThree
        { get; set; }

        /// <summary>
        /// Contact phone number.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string Phone
        { get; set; }

        /// <summary>
        /// Contact fax number.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string Fax
        { get; set; }

        /// <summary>
        /// Account number.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string Account
        { get; set; }

        /// <summary>
        /// Contact name.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string Contact
        { get; set; }

        /// <summary>
        /// Terms.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string Terms
        { get; set; }

        /// <summary>
        /// Instructions on purchase order one.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string PurchaseOrderInstructionsOne
        { get; set; }

        /// <summary>
        /// Instructions on purchase order two.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string PurchaseOrderInstructionsTwo
        { get; set; }

        /// <summary>
        /// Instructions on purchase order three.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string PurchaseOrderInstructionsThree
        { get; set; }

        /// <summary>
        /// First line of notes about the supplier.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string NotesOne
        { get; set; }

        /// <summary>
        /// Second line of notes about the supplier.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string NotesTwo
        { get; set; }

        /// <summary>
        /// Third line of notes about the supplier.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string NotesThree
        { get; set; }

        /// <summary>
        /// Supplier e-mail address.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string Email
        { get; set; }

        /// <summary>
        /// Country code of the supplier.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string Country
        { get; set; }

        /// <summary>
        /// Indicates whether the supplier participates in an electronic data interchange.
        /// </summary>
        bool EDI
        { get; set; }

        /// <summary>
        /// Specifies the credit card payment type.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string CardType
        { get; set; }

        /// <summary>
        /// Specifies the zip code of the supplier.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string ZipCode
        { get; set; }

        /// <summary>
        /// Preferred shipping method for product delivery.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string ShipVia
        { get; set; }

        /// <summary>
        /// Preferred e-mail format.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string PreferredEmailFormat
        { get; set; }

        /// <summary>
        /// Supplier contact phone extension number.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string PhoneExtension
        { get; set; }
    }
}
