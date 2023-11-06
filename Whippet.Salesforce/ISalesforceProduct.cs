using System;
using NodaTime;
using Athi.Whippet.Data;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents a product that a Salesforce organization sells.
    /// </summary>
    public interface ISalesforceProduct : IWhippetEntityDynamicImportMapper, IWhippetEntityExternalDataRowImportMapper, IWhippetEntity, ISalesforceObject
    {
        /// <summary>
        /// The ID of the related billing policy. This field is available when Subscription Management is enabled.
        /// </summary>
        SalesforceReference BillingPolicyID
        { get; set; }

        /// <summary>
        /// Indicates whether the product can have a quantity schedule (<see langword="true"/>) or not (<see langword="false"/>). Label is <strong>Quantity Scheduling Enabled</strong>.
        /// </summary>
        bool CanUseQuantitySchedule
        { get; set; }

        /// <summary>
        /// Indicates whether the product can have a revenue schedule (<see langword="true"/>) or not (<see langword="false"/>). Label is <strong>Revenue Scheduling Enabled</strong>.
        /// </summary>
        bool CanUseRevenueSchedule
        { get; set; }

        /// <summary>
        /// ID of the PartnerNetworkConnection that shared this record with your organization. This field is available if you enabled Salesforce to Salesforce.
        /// </summary>
        SalesforceReference ConnectionReceivedID
        { get; set; }

        /// <summary>
        /// ID of the PartnerNetworkConnection that you shared this record with. This field is available if you enabled Salesforce to Salesforce.
        /// </summary>
        SalesforceReference ConnectionSentID
        { get; set; }

        /// <summary>
        /// A text description of this record. Label is <strong>Product Description</strong>.
        /// </summary>
        string Description
        { get; set; }

        /// <summary>
        /// URL leading to a specific version of a record in the linked external data source.
        /// </summary>
        string DisplayUrl
        { get; set; }

        /// <summary>
        /// ID of the related external data source.
        /// </summary>
        SalesforceReference ExternalDataSourceID
        { get; set; }

        /// <summary>
        /// The unique identifier of a record in the linked external data source.
        /// </summary>
        string ExternalID
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
        /// Indicates whether the product has been moved to the Recycle Bin (<see langword="true"/>) or not (<see langword="false"/>). Label is <strong>Deleted></strong>.
        /// </summary>
        bool IsDeleted
        { get; set; }

        /// <summary>
        /// Name of this object. Label is <strong>Product Name</strong>.
        /// </summary>
        string Name
        { get; set; }

        /// <summary>
        /// If the product has a quantity schedule, the number of installments.
        /// </summary>
        int? NumberOfQuantityInstallments
        { get; set; }

        /// <summary>
        /// If the product has a revenue schedule, the number of installments.
        /// </summary>
        int? NumberOfRevenueInstallments
        { get; set; }

        /// <summary>
        /// Default product code for this record.
        /// </summary>
        string ProductCode
        { get; set; }

        /// <summary>
        /// Changes behavior of <see cref="OpportunityLineItem"/> calculations when a line item has child schedule rows for the <see cref="Quantity"/> value. When enabled, if the rollup quantity changes, then the quantity rollup value is multiplied against the sales price to change the total price.
        /// </summary>
        bool RecalculateTotalPrice
        { get; set; }

        /// <summary>
        /// The SKU for the product. Use in tandem with or instead of the <see cref="ProductCode"/> field. For example, you can track the manufacturer’s identifying code in the <see cref="ProductCode"/> field and assign the product a SKU when you resell it.
        /// </summary>
        string StockKeepingUnit
        { get; set; }

        /// <summary>
        /// The ID of the related tax policy. This field is available when Subscription Management is enabled. 
        /// </summary>
        SalesforceReference TaxPolicyID
        { get; set; }
    }
}

