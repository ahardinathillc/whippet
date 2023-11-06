using System;
using NodaTime;
using Athi.Whippet.Data;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents an opportunity, which is a sale or pending deal.
    /// </summary>
    /// <remarks>See <a href="https://developer.salesforce.com/docs/atlas.en-us.192.0.object_reference.meta/object_reference/sforce_api_objects_opportunity.htm">Account</a> for more information.</remarks>
    public interface ISalesforceOpportunity : IWhippetEntityDynamicImportMapper, IWhippetEntityExternalDataRowImportMapper, IWhippetEntity, ISalesforceObject
    {
        /// <summary>
        /// ID of the account associated with this opportunity.
        /// </summary>
        SalesforceReference? AccountID
        { get; set; }

        /// <summary>
        /// Estimated total sale amount. For opportunities with products, the amount is the sum of the related products. Any attempt to update this field, if the record has products, will be ignored. The update call will not be rejected, and other fields will be updated as specified, but the Amount will be unchanged.
        /// </summary>
        decimal? Amount
        { get; set; }

        /// <summary>
        /// ID of a related Campaign. This field is defined only for those organizations that have the campaign feature Campaigns enabled. The User must have read access rights to the cross-referenced Campaign object in order to create or update that campaign into this field on the opportunity.
        /// </summary>
        SalesforceReference? CampaignID
        { get; set; }

        /// <summary>
        /// Required. Date when the opportunity is expected to close.
        /// </summary>
        Instant CloseDate
        { get; set; }

        /// <summary>
        /// ID of the PartnerNetworkConnection that shared this record with your organization. This field is only available if you have enabled Salesforce to Salesforce.
        /// </summary>
        string ConnectionReceivedID
        { get; set; }

        /// <summary>
        /// ID of the PartnerNetworkConnection that you shared this record with. This field is only available if you have enabled Salesforce to Salesforce. Beginning with API version 15.0, the ConnectionSentId field is no longer supported. The ConnectionSentId field is still visible, but the value is null. You can use the new PartnerNetworkRecordConnection object to forward records to connections.
        /// </summary>
        string ConnectionSentID
        { get; set; }

        /// <summary>
        /// ID of the contract that’s associated with this opportunity.
        /// </summary>
        string ContractID
        { get; set; }

        /// <summary>
        /// Available only for organizations with the multicurrency feature enabled. Contains the ISO code for any currency allowed by the organization. If the organization has multicurrency and a Pricebook2 is specified on the opportunity(i.e., the Pricebook2Id field is not blank), then the currency value of this field must match the currency of the PricebookEntry records that are associated with any opportunity line items it has.
        /// </summary>
        string CurrencyISOCode
        { get; set; }

        /// <summary>
        /// Description of the opportunity. Limit: 32,000 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string Description
        { get; set; }

        /// <summary>
        /// Read-only field that is equal to the product of the opportunity <see cref="Amount"/> field and the <see cref="Probability"/>. You can’t directly set this field, but you can indirectly set it by setting the <see cref="Amount"/> or <see cref="Probability"/> fields.
        /// </summary>
        decimal? ExpectedRevenue
        { get; set; }

        /// <summary>
        /// If fiscal years are not enabled, the name of the fiscal quarter or period in which the opportunity <see cref="CloseDate"/> falls.
        /// </summary>
        SalesforceFiscalDate? Fiscal
        { get; set; }

        /// <summary>
        /// Restricted picklist field. It is implied, but not directly controlled, by the <see cref="StageName"/> field. You can override this field to a different value than is implied by the <see cref="StageName"/> value. The values of this field are fixed enumerated values. The field labels are localized to the language of the user performing the operation, if localized versions of those labels are available for that language in the user interface. In API version 12.0 and later, the value of this field is automatically set based on the value of the ForecastCategoryName and can’t be updated any other way. The field properties Create, Defaulted on create, Nillable, and Update are not available in version 12.0.
        /// </summary>
        string ForecastCategory
        { get; set; }

        /// <summary>
        /// Available in API version 12.0 and later. The name of the forecast category. It is implied, but not directly controlled, by the <see cref="StageName"/> field. You can override this field to a different value than is implied by the <see cref="StageName"/> value.
        /// </summary>
        string ForecastCategoryName
        { get; set; }

        /// <summary>
        /// Read-only field that indicates whether the opportunity has associated line items. A value of true means that Opportunity line items have been created for the opportunity. An opportunity can have opportunity line items only if the opportunity has a price book. The opportunity line items must correspond to PricebookEntry objects that are listed in the opportunity Pricebook2. However, you can insert opportunity line items on an opportunity that does not have an associated Pricebook2. For the first opportunity line item that you insert on an opportunity without a Pricebook2, the API automatically sets the Pricebook2Id field, if the opportunity line item corresponds to a PricebookEntry in an active Pricebook2 that has a CurrencyIsoCode field that matches the CurrencyIsoCode field of the opportunity. If the Pricebook2 is not active or the CurrencyIsoCode fields do not match, then the API returns an error. You can’t update the <see cref="Pricebook2Id"/> or <see cref="PricebookId"/> fields if opportunity line items exist on the Opportunity. You must delete the line items before attempting to update the PricebookId field.
        /// </summary>
        bool HasOpportunityLineItem
        { get; set; }

        /// <summary>
        /// Directly controlled by <see cref="StageName"/>. You can query and filter on this field, but you can’t directly set it in a create, upsert, or update request. It can only be set via <see cref="StageName"/>. Label is <b>Closed</b>.
        /// </summary>
        bool IsClosed
        { get; set; }

        /// <summary>
        /// Indicates whether the object has been moved to the Recycle Bin (true) or not (false). Label is <b>Deleted</b>.
        /// </summary>
        bool IsDeleted
        { get; set; }

        /// <summary>
        /// Read-only field that indicates whether credit for the opportunity is split between opportunity team members. Label is <b>IsSplit</b>. This field is available in versions 14.0 and later for organizations that enabled Opportunity Splits during the pilot period.
        /// </summary>
        bool IsSplit
        { get; set; }

        /// <summary>
        /// Directly controlled by <see cref="StageName"/>. You can query and filter on this field, but you can’t directly set the value. It can only be set via <see cref="StageName"/>. Label is <b>Won</b>.
        /// </summary>
        bool IsWon
        { get; set; }

        /// <summary>
        /// Source of this opportunity, such as Advertisement or Trade Show.
        /// </summary>
        string LeadSource
        { get; set; }

        /// <summary>
        /// Required. A name for this opportunity. Limit: 120 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string Name
        { get; set; }

        /// <summary>
        /// Description of next task in closing opportunity. Limit: 255 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string NextStep
        { get; set; }

        /// <summary>
        /// ID of a related Pricebook2 object. The Pricebook2Id field indicates which Pricebook2 applies to this opportunity. The Pricebook2Id field is defined only for those organizations that have products enabled as a feature. You can specify values for only one field (Pricebook2Id or PricebookId)—not both fields. For this reason, both fields are declared nillable.
        /// </summary>
        string Pricebook2ID
        { get; set; }

        /// <summary>
        /// Unavailable as of version 3.0. As of version 8.0, the Pricebook object is no longer available. Use the Pricebook2Id field instead, specifying the ID of the Pricebook2 record.
        /// </summary>
        string PricebookID
        { get; set; }

        /// <summary>
        /// Percentage of estimated confidence in closing the opportunity. It is implied, but not directly controlled, by the <see cref="StageName"/> field. You can override this field to a different value than what is implied by the StageName.
        /// </summary>
        double? Probability
        { get; set; }

        /// <summary>
        /// Required. Current stage of this record. The <see cref="StageName"/> field controls several other fields on an opportunity. Each of the fields can be directly set or implied by changing the <see cref="StageName"/> field. In addition, the StageName field is a picklist, so it has additional members in the returned describeSObjectResult to indicate how it affects the other fields. To obtain the stage name values in the picklist, query the OpportunityStage object. If the <see cref="StageName"/> is updated, then the <see cref="ForecastCategoryName"/>, <see cref="IsClosed"/>, <see cref="IsWon"/>, and <see cref="Probability"/> are automatically updated based on the stage-category mapping.
        /// </summary>
        string StageName
        { get; set; }

        /// <summary>
        /// Read only in an Apex trigger. The ID of the Quote that syncs with the opportunity. Setting this field lets you start and stop syncing between the opportunity and a quote. The ID has to be for a quote that is a child of the opportunity.
        /// </summary>
        string SyncedQuoteID
        { get; set; }

        /// <summary>
        /// Number of items included in this opportunity. Used in quantity-based forecasting.
        /// </summary>
        double? TotalOpportunityQuantity
        { get; set; }

        /// <summary>
        /// Type of opportunity. For example, Existing Business or New Business. Label is <b>Opportunity Type</b>.
        /// </summary>
        string Type
        { get; set; }
    }
}

