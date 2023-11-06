using System;
using NodaTime;
using Athi.Whippet.Data;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents an individual account, which is an organization or person involved with your business (such as customers, competitors, and partners).
    /// </summary>
    /// <remarks>See <a href="https://developer.salesforce.com/docs/atlas.en-us.192.0.object_reference.meta/object_reference/sforce_api_objects_contact.htm">Contact</a> for more information.</remarks>
    public interface ISalesforceContact : IWhippetEntityDynamicImportMapper, IWhippetEntityExternalDataRowImportMapper, IWhippetEntity, ISalesforceObject, IEqualityComparer<ISalesforceContact>
    {
        /// <summary>
        /// ID of the account that’s the parent of this contact.
        /// </summary>
        SalesforceReference? AccountID
        { get; set; }

        /// <summary>
        /// The assistant’s name.
        /// </summary>
        string AssistantName
        { get; set; }

        /// <summary>
        /// The assistant’s telephone number.
        /// </summary>
        string AssistantPhone
        { get; set; }

        /// <summary>
        /// The contact’s birthdate.
        /// </summary>
        Instant? Birthdate
        { get; set; }

        /// <summary>
        /// Indicates whether this contact can self-register for your Customer Portal (true) or not (false).
        /// </summary>
        bool CanAllowPortalSelfRegistration
        { get; set; }

        /// <summary>
        /// Indicates the record’s clean status as compared with Data.com. 
        /// </summary>
        SalesforceCleanStatus? CleanStatus
        { get; set; }

        /// <summary>
        /// ID of the PartnerNetworkConnection that shared this record with your organization. This field is available if you enabled Salesforce to Salesforce.
        /// </summary>
        SalesforceReference? ConnectionReceivedID
        { get; set; }

        /// <summary>
        /// ID of the PartnerNetworkConnection that you shared this record with. This field is available if you enabled Salesforce to Salesforce. This field is supported using API versions earlier than 15.0. In all other API versions, this field’s value is <see langword="null"/>. You can use the new <a href="https://developer.salesforce.com/docs/atlas.en-us.object_reference.meta/object_reference/sforce_api_objects_partnernetworkrecordconnection.htm">PartnerNetworkRecordConnection</a> object to forward records to connections.
        /// </summary>
        SalesforceReference? ConnectionSentID
        { get; set; }

        /// <summary>
        /// The department of the contact.
        /// </summary>
        string Department
        { get; set; }

        /// <summary>
        /// A description of the contact. Label is <b>Contact Description</b>.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string Description
        { get; set; }

        /// <summary>
        /// Indicates that the contact does not wish to be called.
        /// </summary>
        bool DoNotCall
        { get; set; }

        /// <summary>
        /// Email address for the contact.
        /// </summary>
        string Email
        { get; set; }

        /// <summary>
        /// If bounce management is activated and an email sent to the contact bounces, the date and time the bounce occurred.
        /// </summary>
        Instant? EmailBouncedDate
        { get; set; }

        /// <summary>
        /// If bounce management is activated and an email sent to the contact bounces, the reason the bounce occurred.
        /// </summary>
        string EmailBouncedReason
        { get; set; }

        /// <summary>
        /// Fax number for the contact. Label is <b>Business Phone</b>.
        /// </summary>
        string Fax
        { get; set; }

        /// <summary>
        /// First name of the contact. Maximum size is 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string FirstName
        { get; set; }

        /// <summary>
        /// Indicates whether the contact would prefer not to receive email from Salesforce (true) or not (false). Label is <b>Email Opt Out</b>.
        /// </summary>
        bool HasOptedOutOfEmail
        { get; set; }

        /// <summary>
        /// Indicates that the contact does not wish to receive faxes.
        /// </summary>
        bool HasOptedOutOfFax
        { get; set; }

        /// <summary>
        /// Home telephone number for the contact.
        /// </summary>
        string HomePhone
        { get; set; }

        /// <summary>
        /// Indicates whether the object has been moved to the Recycle Bin (true) or not (false). Label is <b>Deleted</b>.
        /// </summary>
        bool IsDeleted
        { get; set; }

        /// <summary>
        /// If bounce management is activated and an email is sent to a contact, indicates whether the email bounced (true) or not (false).
        /// </summary>
        bool IsEmailBounced
        { get; set; }

        /// <summary>
        /// Read only. Label is <b>Is Person Account</b>. Indicates whether this account has a record type of Person Account (true) or not (false).
        /// </summary>
        bool IsPersonAccount
        { get; set; }

        /// <summary>
        /// References the ID of a company in Data.com. If an account has a value in this field, it means that the account was imported from Data.com. If the field value is <see langword="null"/>, the account was not imported from Data.com. Maximum size is 20 characters. Available in API version 22.0 and later. Label is <b>Data.com Key</b>.
        /// </summary>
        string Jigsaw
        { get; set; }

        /// <summary>
        /// The last date that a Stay-in-Touch request was sent to the contact.
        /// </summary>
        Instant? LastStayInTouchRequestDate
        { get; set; }

        /// <summary>
        /// The last time a Stay-in-Touch update was processed for the contact.
        /// </summary>
        Instant? LastStayInTouchSaveDate
        { get; set; }

        /// <summary>
        /// Required. Last name of the contact. Maximum size is 80 characters.
        /// </summary>
        string LastName
        { get; set; }

        /// <summary>
        /// The source of the lead.
        /// </summary>
        string LeadSource
        { get; set; }

        /// <summary>
        /// Details about the contact's mailing city.
        /// </summary>
        string MailingCity
        { get; set; }

        /// <summary>
        /// The mailing street address for this contact.
        /// </summary>
        string MailingStreet
        { get; set; }

        /// <summary>
        /// The mailing country for this contact.
        /// </summary>
        string MailingCountry
        { get; set; }

        /// <summary>
        /// The mailing postal code for this contact.
        /// </summary>
        string MailingPostalCode
        { get; set; }

        /// <summary>
        /// The mailing state for this postal code.
        /// </summary>
        string MailingState
        { get; set; }

        /// <summary>
        /// The ISO code for the mailing address state.
        /// </summary>
        string MailingStateCode
        { get; set; }

        /// <summary>
        /// The ISO code for the mailing address country.
        /// </summary>
        string MailingCountryCode
        { get; set; }

        /// <summary>
        /// If this object was deleted as the result of a merge, this field contains the ID of the record that was kept. If this object was deleted for any other reason, or has not been deleted, the value is <see langword="null"/>.
        /// </summary>
        SalesforceReference? MasterRecordID
        { get; set; }

        /// <summary>
        /// Contact’s mobile phone number.
        /// </summary>
        string MobilePhone
        { get; set; }

        /// <summary>
        /// Name of the contact. Maximum size is 121 characters.
        /// </summary>
        string Name
        { get; set; }

        /// <summary>
        /// Details about the contact's alternate mailing city.
        /// </summary>
        string OtherCity
        { get; set; }

        /// <summary>
        /// The alternate mailing street address for this contact.
        /// </summary>
        string OtherStreet
        { get; set; }

        /// <summary>
        /// The alternate mailing country for this contact.
        /// </summary>
        string OtherCountry
        { get; set; }

        /// <summary>
        /// The alternate mailing postal code for this contact.
        /// </summary>
        string OtherPostalCode
        { get; set; }

        /// <summary>
        /// The alternate mailing state for this postal code.
        /// </summary>
        string OtherState
        { get; set; }

        /// <summary>
        /// The ISO code for the alternate mailing address state.
        /// </summary>
        string OtherStateCode
        { get; set; }

        /// <summary>
        /// The ISO code for the alternate mailing address country.
        /// </summary>
        string OtherCountryCode
        { get; set; }

        /// <summary>
        /// Telephone for alternate address.
        /// </summary>
        string OtherPhone
        { get; set; }

        /// <summary>
        /// Telephone number for the contact. Label is <b>Business Phone</b>.
        /// </summary>
        string Phone
        { get; set; }

        /// <summary>
        /// Path to be combined with the URL of a Salesforce instance (for example, https://na1.salesforce.com/) to generate a URL to request the social network profile image associated with the contact. Generated URL returns an HTTP redirect (code 302) to the social network profile image for the contact. Blank if Social Accounts and Contacts isn't enabled for the organization or if Social Accounts and Contacts is disabled for the requesting user.
        /// </summary>
        string PhotoUrl
        { get; set; }

        /// <summary>
        /// This field is not visible if <see cref="IsPersonAccount"/> is <see langword="true"/>.
        /// </summary>
        SalesforceReference? ReportsToID
        { get; set; }

        /// <summary>
        /// Honorific abbreviation, word, or phrase to be used in front of name in greetings, such as Dr. or Mrs.
        /// </summary>
        string Salutation
        { get; set; }

        /// <summary>
        /// Title of the contact such as CEO or Vice President.
        /// </summary>
        string Title
        { get; set; }
    }
}

