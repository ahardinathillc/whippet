using System;
using System.Data;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Json;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents a product entry (an association between an <see cref="ISalesforcePriceBook"/> and <see cref="ISalesforceProduct"/>) in a price book.
    /// </summary>
    public interface ISalesforcePriceBookEntry : IWhippetEntityDynamicImportMapper, IWhippetEntityExternalDataRowImportMapper, IWhippetEntity, ISalesforceObject
    {
        /// <summary>
        /// The count of active price adjustment schedules associated with the price book entry.
        /// </summary>
        int? ActivePriceAdjustmentQuantity
        { get; set; }

        /// <summary>
        /// Indicates whether the product is active (<see langword="true"/>) or not (<see langword="false"/>). Inactive products are hidden in many areas in the user interface. You can change this field’s value as often as necessary. Label is <strong>Active</strong>.
        /// </summary>
        bool IsActive
        { get; set; }

        /// <summary>
        /// Indicates whether the product has been archived (<see langword="true"/>) or not (<see langword="false"/>). This field is read-only.
        /// </summary>
        bool IsArchived
        { get; set; }

        /// <summary>
        /// Name of this object. Label is <strong>Product Name</strong>.
        /// </summary>
        string Name
        { get; set; }

        /// <summary>
        /// ID of the <see cref="ISalesforcePriceBook"/> record with which this record is associated.
        /// </summary>
        SalesforceReference PriceBookID
        { get; set; }

        /// <summary>
        /// ID of the <see cref="ISalesforceProduct"/> record with which this record is associated.
        /// </summary>
        SalesforceReference ProductID
        { get; set; }

        /// <summary>
        /// Product code for the record. References the <see cref="ISalesforceProduct.ProductCode"/> value.
        /// </summary>
        string ProductCode
        { get; set; }

        /// <summary>
        /// The ID of the related product selling model. This field is available when Subscription Management is enabled.
        /// </summary>
        SalesforceReference ProductSellingModelID
        { get; set; }

        /// <summary>
        /// Unit price for this price book entry. A value can be specified only if <see cref="UseStandardPrice"/> is set to <see langword="false"/>. Label is <strong>List Price</strong>.
        /// </summary>
        decimal UnitPrice
        { get; set; }

        /// <summary>
        /// Indicates whether this price book entry uses the standard price defined in the standard <see cref="ISalesforcePriceBook"/> record (<see langword="true"/>) or not (<see langword="false"/>). If set to <see langword="true"/>, then the <see cref="UnitPrice"/> field is
        /// read-only, and the value is the same as the <see cref="UnitPrice"/> value in the corresponding <see cref="ISalesforcePriceBookEntry"/> in the standard price book (that is, the <see cref="ISalesforcePriceBookEntry"/> record whose
        /// <see cref="PriceBookID"/> refers to the standard price book and whose <see cref="ProductID"/> and <strong>CurrencyIsoCode</strong> are the same as this record). For <see cref="ISalesforcePriceBookEntry"/> records associated with the standard
        /// <see cref="ISalesforcePriceBook"/> record, this field must be set to <see langword="true"/>.
        /// </summary>
        bool UseStandardPrice
        { get; set; }
    }
}

