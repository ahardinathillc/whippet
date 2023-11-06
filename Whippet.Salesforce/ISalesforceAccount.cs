using System;
using NodaTime;
using Athi.Whippet.Data;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents an individual account, which is an organization or person involved with your business (such as customers, competitors, and partners).
    /// </summary>
    /// <remarks>See <a href="https://developer.salesforce.com/docs/atlas.en-us.192.0.object_reference.meta/object_reference/sforce_api_objects_account.htm">Account</a> for more information.</remarks>
    public interface ISalesforceAccount : IWhippetEntityDynamicImportMapper, IWhippetEntityExternalDataRowImportMapper, IWhippetEntity, ISalesforceObject, IEqualityComparer<ISalesforceAccount>
    {
        /// <summary>
        /// Account number assigned to this account (not the unique, system-generated ID assigned during creation). Maximum size is 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string AccountNumber
        { get; set; }

        /// <summary>
        /// The source of the account record. For example, Advertisement, Data.com, or Trade Show. The source is selected from a picklist of available values, which are set by an administrator. Each picklist value can have up to 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string AccountSource
        { get; set; }

        /// <summary>
        /// Estimated annual revenue of the account.
        /// </summary>
        decimal? AnnualRevenue
        { get; set; }

        /// <summary>
        /// Details for the billing address of this account. Maximum size is 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string BillingCity
        { get; set; }

        /// <summary>
        /// Details for the billing address of this account. Maximum size is 80 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string BillingCountry
        { get; set; }

        /// <summary>
        /// The ISO country code for the account’s billing address.
        /// </summary>
        string BillingCountryCode
        { get; set; }

        /// <summary>
        /// Details for the billing address of this account. Maximum size is 20 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string BillingPostalCode
        { get; set; }

        /// <summary>
        /// Details for the billing address of this account. Maximum size is 80 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string BillingState
        { get; set; }

        /// <summary>
        /// The ISO state code for the account’s billing address.
        /// </summary>
        string BillingStateCode
        { get; set; }

        /// <summary>
        /// Street address for the billing address of this account.
        /// </summary>
        string BillingStreet
        { get; set; }

        /// <summary>
        /// Indicates the record’s clean status as compared with Data.com.
        /// </summary>
        SalesforceCleanStatus? CleanStatus
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
        /// Text description of the account. Limited to 32,000 KB (16,000,000 characters).
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string Description
        { get; set; }

        /// <summary>
        /// The Data Universal Numbering System (D-U-N-S) number is a unique, nine-digit number assigned to every business location in the Dun & Bradstreet database that has a unique, separate, and distinct operation. D-U-N-S numbers are used by industries and organizations around the world as a global standard for business identification and tracking. Maximum size is 9 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string DUNS_Number
        { get; set; }

        /// <summary>
        /// Fax number for the account.
        /// </summary>
        string Fax
        { get; set; }

        /// <summary>
        /// An industry associated with this account. Maximum size is 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string Industry
        { get; set; }

        /// <summary>
        /// Indicates whether the account has at least one contact enabled to use the organization's Customer Portal (true) or not (false). This field is available if Customer Portal is enabled OR Communities is enabled and you have Customer Portal licenses. If you change this field's value from true to false, you can disable up to 100 Customer Portal users associated with the account and permanently delete all of the account's Customer Portal roles and groups. You can't restore deleted Customer Portal roles and groups. This field can be updated in API version 16.0 and later.
        /// </summary>
        bool IsCustomerPortal
        { get; set; }

        /// <summary>
        /// Indicates whether the object has been moved to the Recycle Bin (true) or not (false). Label is <b>Deleted</b>.
        /// </summary>
        bool IsDeleted
        { get; set; }

        /// <summary>
        /// Indicates whether the account has at least one contact enabled to use the organization's partner portal (true) or not (false). This field is available if partner relationship management (partner portal) is enabled OR Communities is enabled and you have partner portal licenses. If you change this field's value from true to false, you can disable up to 15 partner portal users associated with the account and permanently delete all of the account's partner portal roles and groups. You can't restore deleted partner portal roles and groups. Disabling a partner portal user in the Salesforce user interface or the API does not change this field's value from true to false. Even if this field's value is false, you can enable a contact on an account as a partner portal user via the API. This field can be updated in API version 16.0 and later.
        /// </summary>
        bool IsPartner
        { get; set; }

        /// <summary>
        /// Read only. Label is Is <b>Person Account</b>. Indicates whether this account has a record type of Person Account (true) or not (false).
        /// </summary>
        bool IsPersonAccount
        { get; set; }

        /// <summary>
        /// References the ID of a company in Data.com. If an account has a value in this field, it means that the account was imported from Data.com. If the field value is null, the account was not imported from Data.com. Maximum size is 20 characters. Available in API version 22.0 and later. Label is <b>Data.com Key</b>.
        /// </summary>
        string Jigsaw
        { get; set; }

        /// <summary>
        /// If this object was deleted as the result of a merge, this field contains the ID of the record that was kept. If this object was deleted for any other reason, or has not been deleted, the value is null.
        /// </summary>
        string MasterRecordID
        { get; set; }

        /// <summary>
        /// The six-digit North American Industry Classification System (NAICS) code is the standard used by business and government to classify business establishments into industries, according to their economic activity for the purpose of collecting, analyzing, and publishing statistical data related to the U.S. business economy. Maximum size is 8 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string NAICS_Code
        { get; set; }

        /// <summary>
        /// A brief description of an organization’s line of business, based on its NAICS code. Maximum size is 120 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string NAICS_Description
        { get; set; }

        /// <summary>
        /// Required. Label is <b>Account Name</b>. Name of the account. Maximum size is 255 characters. If the account has a record type of Person Account: this value is the concatenation of the <see cref="FirstName"/> and <see cref="LastName"/> of the associated person contact and the value cannot be modified.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string Name
        { get; set; }

        /// <summary>
        /// Label is Employees. Number of employees working at the company represented by this account. Maximum size is eight digits.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        int? NumberOfEmployees
        { get; set; }

        /// <summary>
        /// The ID of the user who currently owns this account. Default value is the user logged in to the API to perform the create. If you have set up account teams in your organization, updating this field has different consequences depending on your version of the API: for API version 12.0 and later, sharing records are kept, as they are for all objects; for API version before 12.0, sharing records are deleted; for API version 16.0 and later, users must have the “Transfer Record” permission in order to update (transfer) account ownership using this field.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        new SalesforceReference? OwnerID
        { get; set; }

        /// <summary>
        /// Ownership type for the account.
        /// </summary>
        SalesforceOwnership? Ownership
        { get; set; }

        /// <summary>
        /// Phone number for this account. Maximum size is 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string Phone
        { get; set; }

        /// <summary>
        /// Path to be combined with the URL of a Salesforce instance (for example, https://na1.salesforce.com/) to generate a URL to request the social network profile image associated with the account. Generated URL returns an HTTP redirect (code 302) to the social network profile image for the account. Blank if Social Accounts and Contacts isn't enabled for the organization or if Social Accounts and Contacts is disabled for the requesting user.
        /// </summary>
        string PhotoURL
        { get; set; }

        /// <summary>
        /// The account's prospect rating.
        /// </summary>
        SalesforceRating? Rating
        { get; set; }

        /// <summary>
        /// Honorific added to the name for use in letters, etc.
        /// </summary>
        string Salutation
        { get; set; }

        /// <summary>
        /// Details of the shipping address for this account. City maximum size is 40 characters
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string ShippingCity
        { get; set; }

        /// <summary>
        /// Details of the shipping address for this account. Country maximum size is 80 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string ShippingCountry
        { get; set; }

        /// <summary>
        /// The ISO country code for the account’s shipping address.
        /// </summary>
        string ShippingCountryCode
        { get; set; }

        /// <summary>
        /// Details of the shipping address for this account. Postal code maximum size is 20 characters.
        /// </summary>
        string ShippingPostalCode
        { get; set; }

        /// <summary>
        /// Details of the shipping address for this account. State maximum size is 80 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string ShippingState
        { get; set; }

        /// <summary>
        /// The ISO state code for the account’s shipping address.
        /// </summary>
        string ShippingStateCode
        { get; set; }

        /// <summary>
        /// The street address of the shipping address for this account. Maximum of 255 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string ShippingStreet
        { get; set; }

        /// <summary>
        /// Standard Industrial Classification code of the company’s main business categorization, for example, 57340 for Electronics. Maximum of 20 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string StandardIndustrialClassification
        { get; set; }

        /// <summary>
        /// A brief description of an organization’s line of business, based on its SIC code. Maximum length is 80 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string StandardIndustrialClassification_Description
        { get; set; }

        /// <summary>
        /// Name of the account’s location, for example Headquarters or London. Label is <b>Account Site</b>. Maximum of 80 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string Site
        { get; set; }

        /// <summary>
        /// The stock market symbol for this account.Maximum of 20 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string TickerSymbol
        { get; set; }

        /// <summary>
        /// Type of account.
        /// </summary>
        SalesforceAccountType? Type
        { get; set; }

        /// <summary>
        /// A name, different from its legal name, that an organization may use for conducting business. Similar to “Doing business as” or “DBA”. Maximum length is 255 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string Tradestyle
        { get; set; }

        /// <summary>
        /// The website of this account. Maximum of 255 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string Website
        { get; set; }

        /// <summary>
        /// The date when an organization was legally established. Maximum length is 4 characters.
        /// </summary>
        string YearStarted
        { get; set; }

        /// <summary>
        /// First name of the person for a person account. Maximum size is 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string FirstName
        { get; set; }

        /// <summary>
        /// Last name of the person for a person account. Required if the record type is a person account record type. Maximum size is 80 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string LastName
        { get; set; }

        /// <summary>
        /// The person account’s assistant name. Label is <b>Assistant</b>. Maximum size is 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string AssistantName
        { get; set; }

        /// <summary>
        /// The person account’s assistant phone. Label is <b>Asst. Phone</b>. Maximum size is 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string AssistantPhone
        { get; set; }

        /// <summary>
        /// The birthdate of the person. Label is <b>Birthdate</b>.
        /// </summary>
        Instant? Birthdate
        { get; set; }

        /// <summary>
        /// The ID for the contact associated with this person account. Label is <b>Contact ID</b>.
        /// </summary>
        string PersonContactID
        { get; set; }

        /// <summary>
        /// The department. Label is <b>Department</b>. Maximum size is 80 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string Department
        { get; set; }

        /// <summary>
        /// Email address for the account. Label is <b>Email</b>.
        /// </summary>
        string Email
        { get; set; }

        /// <summary>
        /// If bounce management is activated and an email sent to the person account bounces, the date and time the bounce occurred.
        /// </summary>
        Instant? EmailBouncedDate
        { get; set; }

        /// <summary>
        /// Indicates whether the person account has opted out of email (true) or not (false). Label is <b>Email Opt Out</b>.
        /// </summary>
        bool HasOptedOutOfEmail
        { get; set; }

        /// <summary>
        /// The home phone number for this person account. Label is <b>Home Phone</b>.
        /// </summary>
        string HomePhone
        { get; set; }

        /// <summary>
        /// The last date that this person account was requested. Label is <b>Last Stay-in-Touch Request Date</b>.
        /// </summary>
        Instant? LastStayInTouchRequestDate
        { get; set; }

        /// <summary>
        /// The last date a person account was updated. Label is <b>Last Stay-in-Touch Save Date</b>.
        /// </summary>
        Instant? LastStayInTouchSaveDate
        { get; set; }

        /// <summary>
        /// The person account’s lead source. Label is <b>Lead Source</b>.
        /// </summary>
        string LeadSource
        { get; set; }

        /// <summary>
        /// Details about the person account’s mailing city. Maximum size is 40 characters. Label is <b>Mailing City</b>.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string MailingCity
        { get; set; }

        /// <summary>
        /// The mailing street address for this person account. Label is <b>Mailing Street</b>. Maximum size is 255 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string MailingStreet
        { get; set; }

        /// <summary>
        /// The mailing country for this person account. Label is <b>Mailing Country</b>. Maximum size is 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string MailingCountry
        { get; set; }

        /// <summary>
        /// The mailing country for this person account. Label is <b>Postal Code</b>. Maximum size is 20 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string MailingPostalCode
        { get; set; }

        /// <summary>
        /// The mailing state for this person account. Label is <b>Mailing State</b>. Maximum size is 20 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string MailingState
        { get; set; }

        /// <summary>
        /// The mobile phone number for this person account. Label is <b>Mobile</b>.
        /// </summary>
        string MobilePhone
        { get; set; }

        /// <summary>
        /// Details about the person account’s alternate mailing city. Maximum size is 40 characters. Label is <b>Other City</b>.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string OtherCity
        { get; set; }

        /// <summary>
        /// The alternate mailing street address for this person account. Label is <b>Other Street</b>. Maximum size is 255 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string OtherStreet
        { get; set; }

        /// <summary>
        /// The alternate mailing country for this person account. Label is <b>Other Country</b>. Maximum size is 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string OtherCountry
        { get; set; }

        /// <summary>
        /// The alternate mailing country for this person account. Label is <b>Other Zip/Postal Code</b>. Maximum size is 20 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string OtherPostalCode
        { get; set; }

        /// <summary>
        /// The alternate mailing state for this person account. Label is <b>Other State</b>. Maximum size is 20 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string OtherState
        { get; set; }

        /// <summary>
        /// The ISO country code for the alternate address of the person account.
        /// </summary>
        string OtherCountryCode
        { get; set; }

        /// <summary>
        /// The ISO state code for the alternate address of the person account.
        /// </summary>
        string OtherStateCode
        { get; set; }

        /// <summary>
        /// The alternate phone number for this person account. Label is <b>Other Phone</b>.
        /// </summary>
        string OtherPhone
        { get; set; }

        /// <summary>
        /// The person account's title. Label is <b>Title</b>. Maximum size if 80 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string Title
        { get; set; }
    }
}

