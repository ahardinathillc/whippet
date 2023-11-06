using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Extensions;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents and tracks a marketing campaign, such as a direct mail promotion, webinar, or trade show.
    /// </summary>
    /// <remarks>See <a href="https://developer.salesforce.com/docs/atlas.en-us.192.0.object_reference.meta/object_reference/sforce_api_objects_campaign.htm">Campaign</a> for more information.</remarks>
    public interface ISalesforceCampaign : IWhippetEntityDynamicImportMapper, IWhippetEntityExternalDataRowImportMapper, IWhippetEntity, ISalesforceObject, IEqualityComparer<ISalesforceCampaign>
    {
        /// <summary>
        /// Amount of money spent to run the campaign.
        /// </summary>
        decimal? ActualCost
        { get; set; }

        /// <summary>
        /// Amount of money in all opportunities associated with the campaign, including closed/won opportunities. Label is <b>Total Value Opportunities</b>.
        /// </summary>
        decimal AmountAllOpportunities
        { get; set; }

        /// <summary>
        /// Amount of money in closed or won opportunities associated with the campaign. Label is <b>Total Value Won Opportunities</b>.
        /// </summary>
        decimal AmountWonOpportunities
        { get; set; }

        /// <summary>
        /// Amount of money budgeted for the campaign.
        /// </summary>
        decimal BudgetedCost
        { get; set; }

        /// <summary>
        /// The record type ID for CampaignMember records associated with the campaign.
        /// </summary>
        string CampaignMemberRecordTypeID
        { get; set; }

        /// <summary>
        /// Available only for organizations with the multicurrency feature enabled. Contains the ISO code for any currency allowed by the organization.
        /// </summary>
        string CurrencyISOCode
        { get; set; }

        /// <summary>
        /// Description of the campaign. Limit: 32 KB. Only the first 255 characters display in reports.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string Description
        { get; set; }

        /// <summary>
        /// Ending date for the campaign.Responses received after this date are still counted.
        /// </summary>
        Instant? EndDate
        { get; set; }

        /// <summary>
        /// Percentage of responses you expect to receive for the campaign.
        /// </summary>
        double? ExpectedResponse
        { get; set; }

        /// <summary>
        /// Amount of money you expect to generate from the campaign.
        /// </summary>
        decimal? ExpectedRevenue
        { get; set; }

        /// <summary>
        /// Calculated field for the total amount of money spent to run the campaigns in a campaign hierarchy. Label is <b>Total Actual Cost in Hierarchy</b>.
        /// </summary>
        decimal? HierarchyActualCost
        { get; set; }

        /// <summary>
        /// Calculated field for the total amount of money budgeted for the campaigns in a campaign hierarchy. Label is <b>Total Budgeted Cost in Hierarchy</b>.
        /// </summary>
        decimal? HierarchyBudgetedCost
        { get; set; }

        /// <summary>
        /// Calculated field for the total amount of money you expect to generate from the campaigns in a campaign hierarchy. Label is <b>Total Expected Revenue in Hierarchy</b>.
        /// </summary>
        decimal? HierarchyExpectedRevenue
        { get; set; }

        /// <summary>
        /// Calculated field for the total number of individuals targeted by the campaigns in a campaign hierarchy. For example, the number of email messagess sent. Label is <b>Total Num Sent in Hierarchy</b>.
        /// </summary>
        int HierarchyNumberSent
        { get; set; }

        /// <summary>
        /// Indicates whether this campaign is active (true) or not (false). Default value is <see langword="false"/>. Label is <b>Active</b>.
        /// </summary>
        bool IsActive
        { get; set; }

        /// <summary>
        /// Required. Name of the campaign. Limit: is 80 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string Name
        { get; set; }

        /// <summary>
        /// Number of contacts associated with the campaign. Label is <b>Total Contacts</b>.
        /// </summary>
        int NumberOfContacts
        { get; set; }

        /// <summary>
        /// Number of leads that were converted to an account and contact due to the marketing efforts in the campaign. Label is <b>Converted Leads</b>.
        /// </summary>
        int NumberOfConvertedLeads
        { get; set; }

        /// <summary>
        /// Number of leads associated with the campaign. Label is <b>Total Leads</b>.
        /// </summary>
        int NumberOfLeads
        { get; set; }

        /// <summary>
        /// Number of opportunities associated with the campaign. Label is <b>Num Total Opportunities</b>.
        /// </summary>
        int NumberOfOpportunities
        { get; set; }

        /// <summary>
        /// Number of contacts and unconverted leads with a Member Status equivalent to “Responded” for the campaign. Label is <b>Total Responses</b>.
        /// </summary>
        int NumberOfResponses
        { get; set; }

        /// <summary>
        /// Number of closed or won opportunities associated with the campaign. Label is <b>Num Won Opportunities</b>.
        /// </summary>
        int NumberOfWonOpportunities
        { get; set; }

        /// <summary>
        /// Number of individuals targeted by the campaign. For example, the number of emails sent. Label is <b>Num Sent</b>.
        /// </summary>
        double? NumberSent
        { get; set; }

        /// <summary>
        /// The campaign above the selected campaign in the campaign hierarchy.
        /// </summary>
        string ParentCampaign
        { get; set; }

        /// <summary>
        /// Starting date for the campaign.
        /// </summary>
        Instant? StartDate
        { get; set; }

        /// <summary>
        /// Status of the campaign, for example, Planned, In Progress. Limit: 40 characters.
        /// </summary>
        string Status
        { get; set; }

        /// <summary>
        /// Calculated field for total amount of all opportunities associated with the campaign hierarchy, including closed/won opportunities. Label is <b>Total Value Opportunities in Hierarchy</b>.
        /// </summary>
        decimal TotalAmountAllOpportunities
        { get; set; }

        /// <summary>
        /// Calculated field for amount of all closed/won opportunities associated with the campaign hierarchy. Label is <b>Total Value Won Opportunities in Hierarchy</b>.
        /// </summary>
        decimal TotalAmountAllWonOpportunities
        { get; set; }

        /// <summary>
        /// Calculated field for number of contacts associated with the campaign hierarchy. Label is <b>Total Contacts in Hierarchy</b>.
        /// </summary>
        int TotalNumberOfContacts
        { get; set; }

        /// <summary>
        /// Calculated field for the total number of leads associated with the campaign hierarchy that were converted into accounts, contacts, and opportunities. Label is <b>Total Converted Leads in Hierarchy</b>.
        /// </summary>
        int TotalNumberOfConvertedLeads
        { get; set; }

        /// <summary>
        /// Calculated field for total number of leads associated with the campaign hierarchy. This number also includes converted leads. Label is <b>Total Leads in Hierarchy</b>.
        /// </summary>
        int TotalNumberOfLeads
        { get; set; }

        /// <summary>
        /// Calculated field for the total number of opportunities associated with the campaign hierarchy. Label is <b>Total Opportunities in Hierarchy</b>.
        /// </summary>
        int TotalNumberOfOpportunities
        { get; set; }

        /// <summary>
        /// Calculated field for number of contacts and unconverted leads that have a Member Status equivalent to “Responded” for the campaign hierarchy. Label is <b>Total Responses in Hierarchy</b>.
        /// </summary>
        int TotalNumberOfResponses
        { get; set; }

        /// <summary>
        /// Calculated field for the total number of won opportunities associated with the campaign hierarchy. Label is <b>Total Won Opportunities in Hierarchy</b>.
        /// </summary>
        int TotalNumberOfWonOpportunities
        { get; set; }

        /// <summary>
        /// Type of campaign, for example, Direct Mail or Referral Program. Limit: 40 characters.
        /// </summary>
        string Type
        { get; set; }
    }
}

