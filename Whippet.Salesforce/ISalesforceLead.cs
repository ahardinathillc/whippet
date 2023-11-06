using System;
using NodaTime;
using Athi.Whippet.Data;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents a prospect or lead.
    /// </summary>
    /// <remarks>See <a href="https://developer.salesforce.com/docs/atlas.en-us.object_reference.meta/object_reference/sforce_api_objects_lead.htm">Lead</a> for more information.</remarks>
    public interface ISalesforceLead : IWhippetEntityDynamicImportMapper, IWhippetEntityExternalDataRowImportMapper, IWhippetEntity, ISalesforceObject, IEqualityComparer<ISalesforceLead>
    {
        /// <summary>
        /// The ID of the sales rep designated to work the lead through their assigned cadence.
        /// </summary>
        SalesforceReference ActionCadenceAssigneeId
        { get; set; }

        /// <summary>
        /// The ID of the lead’s assigned cadence.
        /// </summary>
        SalesforceReference ActionCadenceId
        { get; set; }

        /// <summary>
        /// The ID of the related activity metric. 
        /// </summary>
        SalesforceReference ActivityMetricId
        { get; set; }

        /// <summary>
        /// Annual revenue for the lead’s company.
        /// </summary>
        decimal? AnnualRevenue
        { get; set; }

        /// <summary>
        /// City for the lead’s address.
        /// </summary>
        string City
        { get; set; }

        /// <summary>
        /// Indicates the record’s clean status compared with Data.com.
        /// </summary>
        SalesforceCleanStatus? CleanStatus
        { get; set; }

        /// <summary>
        /// The lead's company.
        /// </summary>
        string Company
        { get; set; }

        /// <summary>
        /// The Data Universal Numbering System (D-U-N-S) number, which is a unique, nine-digit number assigned to every business location in the Dun & Bradstreet database that has a unique, separate, and distinct operation. Industries and companies use D-U-N-S numbers as a global standard for business identification and tracking. Maximum size is 9 characters.
        /// </summary>
        string CompanyDunsNumber
        { get; set; }

        /// <summary>
        /// ID of the PartnerNetworkConnection that shared this record with your organization. This field is available if you enabled Salesforce to Salesforce.
        /// </summary>
        SalesforceReference ConnectionReceivedId
        { get; set; }

        /// <summary>
        /// ID of the PartnerNetworkConnection that you shared this record with. This field is available if you enabled Salesforce to Salesforce. 
        /// </summary>
        SalesforceReference ConnectionSentId
        { get; set; }

        /// <summary>
        /// Object reference ID that points to the account into which the lead converted.
        /// </summary>
        SalesforceReference ConvertedAccountId
        { get; set; }

        /// <summary>
        /// Object reference ID that points to the contact into which the lead converted.
        /// </summary>
        SalesforceReference ConvertedContactId
        { get; set; }

        /// <summary>
        /// Date on which this lead was converted.
        /// </summary>
        Instant? ConvertedDate
        { get; set; }

        /// <summary>
        /// Object reference ID that points to the opportunity into which the lead has been converted.
        /// </summary>
        SalesforceReference ConvertedOpportunityId
        { get; set; }

        /// <summary>
        /// The lead’s country.
        /// </summary>
        string Country
        { get; set; }

        /// <summary>
        /// The lead's description.
        /// </summary>
        string Description
        { get; set; }

        /// <summary>
        /// The lead's e-mail address.
        /// </summary>
        string Email
        { get; set; }

        /// <summary>
        /// If bounce management is activated and an email sent to the lead bounced, the date and time of the bounce.
        /// </summary>
        Instant? EmailBouncedDate
        { get; set; }

        /// <summary>
        /// If bounce management is activated and an email sent to the lead bounced, the reason for the bounce.
        /// </summary>
        string EmailBouncedReason
        { get; set; }

        /// <summary>
        /// The lead’s fax number.
        /// </summary>
        string Fax
        { get; set; }

        /// <summary>
        /// The date and time of the first call placed to the lead.
        /// </summary>
        Instant? FirstCallDateTime
        { get; set; }

        /// <summary>
        /// The date and time of the first email sent to the lead.
        /// </summary>
        Instant? FirstEmailDateTime
        { get; set; }

        /// <summary>
        /// The lead's first name up to 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string FirstName
        { get; set; }

        /// <summary>
        /// Indicates whether the lead doesn’t want to receive email from Salesforce (<see langword="true"/>) or does (<see langword="false"/>). Label is <b>Email Opt Out</b>.
        /// </summary>
        bool HasOptedOutOfEmail
        { get; set; }

        /// <summary>
        /// Indicates whether the lead doesn’t want to receive faxes from Salesforce (<see langword="true"/>) or does (<see langword="false"/>). Label is <b>Fax Opt Out</b>.
        /// </summary>
        bool HasOptedOutOfFax
        { get; set; }

        /// <summary>
        /// ID of the data privacy record associated with this lead. 
        /// </summary>
        SalesforceReference IndividualId
        { get; set; }

        /// <summary>
        /// Indicates whether the lead has been converted (<see langword="true"/>) or not (<see langword="false"/>). Label is <b>Converted</b>.
        /// </summary>
        bool IsConverted
        { get; set; }

        /// <summary>
        /// Indicates whether the object has been moved to the Recycle Bin (<see langword="true"/>) or not (<see langword="false"/>). Label is <b>Deleted</b>.
        /// </summary>
        bool IsDeleted
        { get; set; }

        /// <summary>
        /// If <see langword="true"/>, lead has been assigned, but not yet viewed. Label is <b>Unread By Owner</b>.
        /// </summary>
        bool IsUnreadByOwner
        { get; set; }

        /// <summary>
        /// References the ID of a contact in Data.com. If a lead has a value in this field, it means that a contact was imported as a lead from Data.com. If the contact (converted to a lead) wasn’t imported from Data.com, the field value is <see langword="null"/>. Maximum size is 20 characters. 
        /// </summary>
        string Jigsaw
        { get; set; }

        /// <summary>
        /// Required. Last name of the lead up to 80 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        string LastName
        { get; set; }

        /// <summary>
        /// Used with <see cref="Longitude"/> to specify the precise geolocation of an address. Acceptable values are numbers between –90 and 90 up to 15 decimal places. 
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        double? Latitude
        { get; set; }

        /// <summary>
        /// Used with <see cref="Latitude"/> to specify the precise geolocation of an address. Acceptable values are numbers between –180 and 180 up to 15 decimal places.
        /// </summary>
        double? Longitude
        { get; set; }

        /// <summary>
        /// If this record was deleted as the result of a merge, this field contains the ID of the record that was kept. If this record was deleted for any other reason, or hasn’t been deleted, the value is <see langword="null"/>.
        /// </summary>
        SalesforceReference MasterRecordId
        { get; set; }

        /// <summary>
        /// The lead's middle name up to 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string MiddleName
        { get; set; }

        /// <summary>
        /// The lead's mobile phone number.
        /// </summary>
        string MobilePhone
        { get; set; }

        /// <summary>
        /// Concatenation of <see cref="FirstName"/>, <see cref="MiddleName"/>, <see cref="LastName"/>, and <see cref="Suffix"/> up to 203 characters, including whitespaces.
        /// </summary>
        string Name
        { get; set; }

        /// <summary>
        /// Number of employees at the lead’s company. Label is <b>Employees</b>.
        /// </summary>
        int? NumberOfEmployees
        { get; set; }

        /// <summary>
        /// ID of the partner account for the partner user that owns this lead. Available if Partner Relationship Management is enabled or if digital experiences is enabled and you have partner portal licenses.
        /// </summary>
        SalesforceReference PartnerAccountId
        { get; set; }

        /// <summary>
        /// The lead’s phone number.
        /// </summary>
        string Phone
        { get; set; }

        /// <summary>
        /// Path to be combined with the URL of a Salesforce instance to generate a URL to request the social network profile image associated with the lead. Generated URL returns an HTTP redirect (code 302) to the social network profile image for the lead. Empty if Social Accounts and Contacts isn't enabled or if Social Accounts and Contacts has been disabled for the requesting user.
        /// </summary>
        string PhotoUrl
        { get; set; }

        /// <summary>
        /// Postal code for the address of the lead. Label is <b>Zip/Postal Code</b>.
        /// </summary>
        string PostalCode
        { get; set; }

        /// <summary>
        /// The ID of the intelligent field record that contains lead score.
        /// </summary>
        SalesforceReference ScoreIntelligenceId
        { get; set; }

        /// <summary>
        /// State for the address of the lead.
        /// </summary>
        string State
        { get; set; }

        /// <summary>
        /// Street number and name for the address of the lead.
        /// </summary>
        string Street
        { get; set; }

        /// <summary>
        /// The lead’s name suffix up to 40 characters. 
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string Suffix
        { get; set; }

        /// <summary>
        /// Title for the lead, such as CFO or CEO.
        /// </summary>
        string Title
        { get; set; }

        /// <summary>
        /// Website for the lead.
        /// </summary>
        string Website
        { get; set; }
    }
}

