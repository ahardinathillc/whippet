using System;
using System.Data;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Text;
using System.Diagnostics;
using Dynamitey;
using NodaTime;
using Athi.Whippet.Extensions;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Extensions;
using Athi.Whippet.Salesforce.Extensions;
using Newtonsoft.Json.Linq;
using Athi.Whippet.Json.Newtonsoft.Extensions;
using Athi.Whippet.Json;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents an individual account, which is an organization or person involved with your business (such as customers, competitors, and partners). This class cannot be inherited.
    /// </summary>
    /// <remarks>See <a href="https://developer.salesforce.com/docs/atlas.en-us.192.0.object_reference.meta/object_reference/sforce_api_objects_account.htm">Account</a> for more information.</remarks>
    public sealed class SalesforceAccount : IWhippetEntityDynamicImportMapper, IWhippetEntityExternalDataRowImportMapper, IWhippetEntity, ISalesforceObject, ISalesforceAccount
    {
        private const int NUMBER_OF_EMPLOYEES_MAX = 999999;

        private int? _numberOfEmployees;

        private string _accountNumber;
        private string _accountSource;
        private string _billingCity;
        private string _billingCountry;
        private string _billingCountryCode;
        private string _billingPostalCode;
        private string _billingState;
        private string _billingStateCode;
        private string _billingStreet;
        private string _cleanStatus;
        private string _connectionReceivedId;
        private string _connectionSentId;
        private string _description;
        private string _dunsNumber;
        private string _fax;
        private string _industry;
        private string _jigsaw;
        private string _masterRecordId;
        private string _naicsCode;
        private string _naicsDesc;
        private string _name;
        private string _ownerId;
        private string _ownership;
        private string _parentId;
        private string _phone;
        private string _photoUrl;
        private string _rating;
        private string _recordTypeId;
        private string _salutation;
        private string _shippingCity;
        private string _shippingCountry;
        private string _shippingCountryCode;
        private string _shippingPostalCode;
        private string _shippingState;
        private string _shippingStateCode;
        private string _shippingStreet;
        private string _sic;
        private string _sicDesc;
        private string _site;
        private string _tickerSymbol;
        private string _tradestyle;
        private string _type;
        private string _website;
        private string _yearStarted;

        // If account is person fields

        private string _firstName;
        private string _lastName;
        private string _personAssistantName;
        private string _personAssistantPhone;
        private string _personContactId;
        private string _personDepartment;
        private string _personEmail;
        private string _personHomePhone;
        private string _personLeadSource;
        private string _personMailingCity;
        private string _personMailingStreet;
        private string _personMailingCountry;
        private string _personMailingPostalCode;
        private string _personMailingState;
        private string _personMobilePhone;
        private string _personOtherCity;
        private string _personOtherCountry;
        private string _personOtherPostalCode;
        private string _personOtherState;
        private string _personOtherCountryCode;
        private string _personOtherStateCode;
        private string _personOtherPhone;
        private string _personOtherStreet;
        private string _personTitle;

        private WhippetDataRowImportMap _internalMap;

        /// <summary>
        /// Gets the <see cref="WhippetDataRowImportMap"/> object for the current object. This property is read-only.
        /// </summary>
        public WhippetDataRowImportMap ImportMap
        {
            get
            {
                if (_internalMap == null)
                {
                    _internalMap = CreateImportMap();
                }

                return _internalMap;
            }
        }

        /// <summary>
        /// Gets or sets the unique ID of the entity.
        /// </summary>
        Guid IWhippetEntity.ID
        { get; set; }

        /// <summary>
        /// Unique ID of the Salesforce object.
        /// </summary>
        public SalesforceReference? ObjectID
        { get; set; }

        /// <summary>
        /// Account number assigned to this account (not the unique, system-generated ID assigned during creation). Maximum size is 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string AccountNumber
        {
            get
            {
                return _accountNumber;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(AccountNumber)].Column, true);
                _accountNumber = value;
            }
        }

        /// <summary>
        /// The source of the account record. For example, Advertisement, Data.com, or Trade Show. The source is selected from a picklist of available values, which are set by an administrator. Each picklist value can have up to 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string AccountSource
        {
            get
            {
                return _accountSource;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(AccountSource)].Column, true);
                _accountSource = value;
            }
        }

        /// <summary>
        /// Estimated annual revenue of the account.
        /// </summary>
        public decimal? AnnualRevenue
        { get; set; }

        /// <summary>
        /// Details for the billing address of this account. Maximum size is 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string BillingCity
        {
            get
            {
                return _billingCity;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(BillingCity)].Column, true);
                _billingCity = value;
            }
        }

        /// <summary>
        /// Details for the billing address of this account. Maximum size is 80 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string BillingCountry
        {
            get
            {
                return _billingCountry;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(BillingCountry)].Column, true);
                _billingCountry = value;
            }
        }

        /// <summary>
        /// The ISO country code for the account’s billing address.
        /// </summary>
        public string BillingCountryCode
        {
            get
            {
                return _billingCountryCode;
            }
            set
            {
                _billingCountryCode = value;
            }
        }

        /// <summary>
        /// Details for the billing address of this account. Maximum size is 20 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string BillingPostalCode
        {
            get
            {
                return _billingPostalCode;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(BillingPostalCode)].Column, true);
                _billingPostalCode = value;
            }
        }

        /// <summary>
        /// Details for the billing address of this account. Maximum size is 80 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string BillingState
        {
            get
            {
                return _billingState;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(BillingState)].Column, true);
                _billingState = value;
            }
        }

        /// <summary>
        /// The ISO state code for the account’s billing address.
        /// </summary>
        public string BillingStateCode
        {
            get
            {
                return _billingStateCode;
            }
            set
            {
                _billingStateCode = value;
            }
        }

        /// <summary>
        /// Street address for the billing address of this account.
        /// </summary>
        public string BillingStreet
        {
            get
            {
                return _billingStreet;
            }
            set
            {
                _billingStreet = value;
            }
        }

        /// <summary>
        /// Indicates the record’s clean status as compared with Data.com.
        /// </summary>
        public SalesforceCleanStatus? CleanStatus
        { get; set; }

        /// <summary>
        /// ID of the PartnerNetworkConnection that shared this record with your organization. This field is only available if you have enabled Salesforce to Salesforce.
        /// </summary>
        public string ConnectionReceivedID
        {
            get
            {
                return _connectionReceivedId;
            }
            set
            {
                _connectionReceivedId = value;
            }
        }

        /// <summary>
        /// ID of the PartnerNetworkConnection that you shared this record with. This field is only available if you have enabled Salesforce to Salesforce. Beginning with API version 15.0, the ConnectionSentId field is no longer supported. The ConnectionSentId field is still visible, but the value is null. You can use the new PartnerNetworkRecordConnection object to forward records to connections.
        /// </summary>
        public string ConnectionSentID
        {
            get
            {
                return _connectionSentId;
            }
            set
            {
                _connectionSentId = value;
            }
        }

        /// <summary>
        /// Text description of the account. Limited to 32,000 KB (16,000,000 characters).
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(Description)].Column, true);
                _description = value;
            }
        }

        /// <summary>
        /// The Data Universal Numbering System (D-U-N-S) number is a unique, nine-digit number assigned to every business location in the Dun & Bradstreet database that has a unique, separate, and distinct operation. D-U-N-S numbers are used by industries and organizations around the world as a global standard for business identification and tracking. Maximum size is 9 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string DUNS_Number
        {
            get
            {
                return _dunsNumber;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(DUNS_Number)].Column, true);
                _dunsNumber = value;
            }
        }

        /// <summary>
        /// Fax number for the account.
        /// </summary>
        public string Fax
        {
            get
            {
                return _fax;
            }
            set
            {
                _fax = value;
            }
        }

        /// <summary>
        /// An industry associated with this account. Maximum size is 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string Industry
        {
            get
            {
                return _industry;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(Industry)].Column, true);
                _industry = value;
            }
        }

        /// <summary>
        /// Indicates whether the account has at least one contact enabled to use the organization's Customer Portal (true) or not (false). This field is available if Customer Portal is enabled OR Communities is enabled and you have Customer Portal licenses. If you change this field's value from true to false, you can disable up to 100 Customer Portal users associated with the account and permanently delete all of the account's Customer Portal roles and groups. You can't restore deleted Customer Portal roles and groups. This field can be updated in API version 16.0 and later.
        /// </summary>
        public bool IsCustomerPortal
        { get; set; }

        /// <summary>
        /// Indicates whether the object has been moved to the Recycle Bin (true) or not (false). Label is <b>Deleted</b>.
        /// </summary>
        public bool IsDeleted
        { get; set; }

        /// <summary>
        /// Indicates whether the account has at least one contact enabled to use the organization's partner portal (true) or not (false). This field is available if partner relationship management (partner portal) is enabled OR Communities is enabled and you have partner portal licenses. If you change this field's value from true to false, you can disable up to 15 partner portal users associated with the account and permanently delete all of the account's partner portal roles and groups. You can't restore deleted partner portal roles and groups. Disabling a partner portal user in the Salesforce user interface or the API does not change this field's value from true to false. Even if this field's value is false, you can enable a contact on an account as a partner portal user via the API. This field can be updated in API version 16.0 and later.
        /// </summary>
        public bool IsPartner
        { get; set; }

        /// <summary>
        /// Read only. Label is Is <b>Person Account</b>. Indicates whether this account has a record type of Person Account (true) or not (false).
        /// </summary>
        public bool IsPersonAccount
        { get; set; }

        /// <summary>
        /// References the ID of a company in Data.com. If an account has a value in this field, it means that the account was imported from Data.com. If the field value is null, the account was not imported from Data.com. Maximum size is 20 characters. Available in API version 22.0 and later. Label is <b>Data.com Key</b>.
        /// </summary>
        public string Jigsaw
        {
            get
            {
                return _jigsaw;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(Jigsaw)].Column, true);
                _jigsaw = value;
            }
        }

        /// <summary>
        /// Value is one of the following, whichever is the most recent: due date of the most recent event logged against the record, or, due date of the most recently closed task associated with the record.
        /// </summary>
        public Instant? LastActivityDate
        { get; set; }

        /// <summary>
        /// The timestamp for when the current user last viewed a record related to this record.
        /// </summary>
        public Instant? LastReferencedDate
        { get; set; }

        /// <summary>
        /// The timestamp for when the current user last viewed this record. If this value is null, this record might only have been referenced (<see cref="LastReferencedDate"/>) and not viewed.
        /// </summary>
        public Instant? LastViewedDate
        { get; set; }

        /// <summary>
        /// If this object was deleted as the result of a merge, this field contains the ID of the record that was kept. If this object was deleted for any other reason, or has not been deleted, the value is null.
        /// </summary>
        public string MasterRecordID
        {
            get
            {
                return _masterRecordId;
            }
            set
            {
                _masterRecordId = value;
            }
        }

        /// <summary>
        /// The six-digit North American Industry Classification System (NAICS) code is the standard used by business and government to classify business establishments into industries, according to their economic activity for the purpose of collecting, analyzing, and publishing statistical data related to the U.S. business economy. Maximum size is 8 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string NAICS_Code
        {
            get
            {
                return _naicsCode;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(NAICS_Code)].Column, true);
                _naicsCode = value;
            }
        }

        /// <summary>
        /// A brief description of an organization’s line of business, based on its NAICS code. Maximum size is 120 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string NAICS_Description
        {
            get
            {
                return _naicsDesc;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(NAICS_Description)].Column, true);
                _naicsDesc = value;
            }
        }

        /// <summary>
        /// Required. Label is <b>Account Name</b>. Name of the account. Maximum size is 255 characters. If the account has a record type of Person Account: this value is the concatenation of the <see cref="FirstName"/> and <see cref="LastName"/> of the associated person contact and the value cannot be modified.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string Name
        {
            get
            {
                return (String.IsNullOrWhiteSpace(_name) && !((String.IsNullOrWhiteSpace(FirstName) || String.IsNullOrWhiteSpace(LastName)))) ? (FirstName + " " + LastName).Trim() : _name;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(Name)].Column, false);
                _name = value;
            }
        }

        /// <summary>
        /// Label is Employees. Number of employees working at the company represented by this account. Maximum size is eight digits.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public int? NumberOfEmployees
        {
            get
            {
                return _numberOfEmployees;
            }
            set
            {
                if (value.HasValue && (value.Value > NUMBER_OF_EMPLOYEES_MAX))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _numberOfEmployees = value;
            }
        }

        /// <summary>
        /// The ID of the user who currently owns this account. Default value is the user logged in to the API to perform the create. If you have set up account teams in your organization, updating this field has different consequences depending on your version of the API: for API version 12.0 and later, sharing records are kept, as they are for all objects; for API version before 12.0, sharing records are deleted; for API version 16.0 and later, users must have the “Transfer Record” permission in order to update (transfer) account ownership using this field.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        public SalesforceReference? OwnerID
        {
            get
            {
                return _ownerId;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value.GetValueOrDefault()))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else
                {
                    _ownerId = value;
                }
            }
        }

        /// <summary>
        /// Ownership type for the account.
        /// </summary>
        public SalesforceOwnership? Ownership
        { get; set; }

        /// <summary>
        /// ID of the parent object (if any).
        /// </summary>
        public SalesforceReference? ParentID
        {
            get
            {
                return _parentId;
            }
            set
            {
                _parentId = value;
            }
        }

        /// <summary>
        /// Phone number for this account. Maximum size is 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(Phone)].Column, true);
                _phone = value;
            }
        }

        /// <summary>
        /// Path to be combined with the URL of a Salesforce instance (for example, https://na1.salesforce.com/) to generate a URL to request the social network profile image associated with the account. Generated URL returns an HTTP redirect (code 302) to the social network profile image for the account. Blank if Social Accounts and Contacts isn't enabled for the organization or if Social Accounts and Contacts is disabled for the requesting user.
        /// </summary>
        public string PhotoURL
        {
            get
            {
                return _photoUrl;
            }
            set
            {
                _photoUrl = value;
            }
        }

        /// <summary>
        /// The account's prospect rating.
        /// </summary>
        public SalesforceRating? Rating
        { get; set; }

        /// <summary>
        /// ID of the record type assigned to this object.
        /// </summary>
        public SalesforceReference? RecordTypeID
        {
            get
            {
                return _recordTypeId;
            }
            set
            {
                _recordTypeId = value;
            }
        }

        /// <summary>
        /// Honorific added to the name for use in letters, etc.
        /// </summary>
        public string Salutation
        {
            get
            {
                return _salutation;
            }
            set
            {
                _salutation = value;
            }
        }

        /// <summary>
        /// Details of the shipping address for this account. City maximum size is 40 characters
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string ShippingCity
        {
            get
            {
                return _shippingCity;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(ShippingCity)].Column, true);
                _shippingCity = value;
            }
        }

        /// <summary>
        /// Details of the shipping address for this account. Country maximum size is 80 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string ShippingCountry
        {
            get
            {
                return _shippingCountry;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(ShippingCountry)].Column, true);
                _shippingCountry = value;
            }
        }

        /// <summary>
        /// The ISO country code for the account’s shipping address.
        /// </summary>
        public string ShippingCountryCode
        {
            get
            {
                return _shippingCountryCode;
            }
            set
            {
                _shippingCountryCode = value;
            }
        }

        /// <summary>
        /// Details of the shipping address for this account. Postal code maximum size is 20 characters.
        /// </summary>
        public string ShippingPostalCode
        {
            get
            {
                return _shippingPostalCode;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(ShippingPostalCode)].Column, true);
                _shippingPostalCode = value;
            }
        }

        /// <summary>
        /// Details of the shipping address for this account. State maximum size is 80 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string ShippingState
        {
            get
            {
                return _shippingState;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(ShippingState)].Column, true);
                _shippingState = value;
            }
        }

        /// <summary>
        /// The ISO state code for the account’s shipping address.
        /// </summary>
        public string ShippingStateCode
        {
            get
            {
                return _shippingStateCode;
            }
            set
            {
                _shippingStateCode = value;
            }
        }

        /// <summary>
        /// The street address of the shipping address for this account. Maximum of 255 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string ShippingStreet
        {
            get
            {
                return _shippingStreet;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(ShippingStreet)].Column, true);
                _shippingStreet = value;
            }
        }

        /// <summary>
        /// Standard Industrial Classification code of the company’s main business categorization, for example, 57340 for Electronics. Maximum of 20 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string StandardIndustrialClassification
        {
            get
            {
                return _sic;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(StandardIndustrialClassification)].Column, true);
                _sic = value;
            }
        }

        /// <summary>
        /// A brief description of an organization’s line of business, based on its SIC code. Maximum length is 80 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string StandardIndustrialClassification_Description
        {
            get
            {
                return _sicDesc;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(StandardIndustrialClassification_Description)].Column, true);
                _sicDesc = value;
            }
        }

        /// <summary>
        /// Name of the account’s location, for example Headquarters or London. Label is <b>Account Site</b>. Maximum of 80 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string Site
        {
            get
            {
                return _site;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(Site)].Column, true);
                _site = value;
            }
        }

        /// <summary>
        /// The stock market symbol for this account.Maximum of 20 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string TickerSymbol
        {
            get
            {
                return _tickerSymbol;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(TickerSymbol)].Column, true);
                _tickerSymbol = value;
            }
        }

        /// <summary>
        /// Type of account.
        /// </summary>
        public SalesforceAccountType? Type
        { get; set; }

        /// <summary>
        /// A name, different from its legal name, that an organization may use for conducting business. Similar to “Doing business as” or “DBA”. Maximum length is 255 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string Tradestyle
        {
            get
            {
                return _tradestyle;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(Tradestyle)].Column, true);
                _tradestyle = value;
            }
        }

        /// <summary>
        /// The website of this account. Maximum of 255 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string Website
        {
            get
            {
                return _website;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(Website)].Column, true);
                _website = value;
            }
        }

        /// <summary>
        /// The date when an organization was legally established. Maximum length is 4 characters.
        /// </summary>
        public string YearStarted
        {
            get
            {
                return _yearStarted;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(YearStarted)].Column, true);
                _yearStarted = value;
            }
        }

        /// <summary>
        /// First name of the person for a person account. Maximum size is 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(FirstName)].Column, true);
                _firstName = value;
            }
        }

        /// <summary>
        /// Last name of the person for a person account. Required if the record type is a person account record type. Maximum size is 80 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(LastName)].Column, true);
                _lastName = value;
            }
        }

        /// <summary>
        /// The person account’s assistant name. Label is <b>Assistant</b>. Maximum size is 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string AssistantName
        {
            get
            {
                return _personAssistantName;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(AssistantName)].Column, true);
                _personAssistantName = value;
            }
        }

        /// <summary>
        /// The person account’s assistant phone. Label is <b>Asst. Phone</b>. Maximum size is 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string AssistantPhone
        {
            get
            {
                return _personAssistantPhone;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(AssistantPhone)].Column, true);
                _personAssistantPhone = value;
            }
        }

        /// <summary>
        /// The birthdate of the person. Label is <b>Birthdate</b>.
        /// </summary>
        public Instant? Birthdate
        { get; set; }

        /// <summary>
        /// The ID for the contact associated with this person account. Label is <b>Contact ID</b>.
        /// </summary>
        public string PersonContactID
        {
            get
            {
                return _personContactId;
            }
            set
            {
                _personContactId = value;
            }
        }

        /// <summary>
        /// The department. Label is <b>Department</b>. Maximum size is 80 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string Department
        {
            get
            {
                return _personDepartment;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(Department)].Column, true);
                _personDepartment = value;
            }
        }

        /// <summary>
        /// Email address for the account. Label is <b>Email</b>.
        /// </summary>
        public string Email
        {
            get
            {
                return _personEmail;
            }
            set
            {
                _personEmail = value;
            }
        }

        /// <summary>
        /// If bounce management is activated and an email sent to the person account bounces, the date and time the bounce occurred.
        /// </summary>
        public Instant? EmailBouncedDate
        { get; set; }

        /// <summary>
        /// Indicates whether the person account has opted out of email (true) or not (false). Label is <b>Email Opt Out</b>.
        /// </summary>
        public bool HasOptedOutOfEmail
        { get; set; }

        /// <summary>
        /// The home phone number for this person account. Label is <b>Home Phone</b>.
        /// </summary>
        public string HomePhone
        {
            get
            {
                return _personHomePhone;
            }
            set
            {
                _personHomePhone = value;
            }
        }

        /// <summary>
        /// The last date that this person account was requested. Label is <b>Last Stay-in-Touch Request Date</b>.
        /// </summary>
        public Instant? LastStayInTouchRequestDate
        { get; set; }

        /// <summary>
        /// The last date a person account was updated. Label is <b>Last Stay-in-Touch Save Date</b>.
        /// </summary>
        public Instant? LastStayInTouchSaveDate
        { get; set; }

        /// <summary>
        /// The person account’s lead source. Label is <b>Lead Source</b>.
        /// </summary>
        public string LeadSource
        {
            get
            {
                return _personLeadSource;
            }
            set
            {
                _personLeadSource = value;
            }
        }

        /// <summary>
        /// Details about the person account’s mailing city. Maximum size is 40 characters. Label is <b>Mailing City</b>.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string MailingCity
        {
            get
            {
                return _personMailingCity;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(MailingCity)].Column, true);
                _personMailingCity = value;
            }
        }

        /// <summary>
        /// The mailing street address for this person account. Label is <b>Mailing Street</b>. Maximum size is 255 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string MailingStreet
        {
            get
            {
                return _personMailingStreet;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(MailingStreet)].Column, true);
                _personMailingStreet = value;
            }
        }

        /// <summary>
        /// The mailing country for this person account. Label is <b>Mailing Country</b>. Maximum size is 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string MailingCountry
        {
            get
            {
                return _personMailingCountry;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(MailingCountry)].Column, true);
                _personMailingCountry = value;
            }
        }

        /// <summary>
        /// The mailing postal code for this person account. Label is <b>Postal Code</b>. Maximum size is 20 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string MailingPostalCode
        {
            get
            {
                return _personMailingPostalCode;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(MailingPostalCode)].Column, true);
                _personMailingPostalCode = value;
            }
        }

        /// <summary>
        /// The mailing state for this person account. Label is <b>Mailing State</b>. Maximum size is 20 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string MailingState
        {
            get
            {
                return _personMailingState;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(MailingState)].Column, true);
                _personMailingState = value;
            }
        }

        /// <summary>
        /// The mobile phone number for this person account. Label is <b>Mobile</b>.
        /// </summary>
        public string MobilePhone
        {
            get
            {
                return _personMobilePhone;
            }
            set
            {
                _personMobilePhone = value;
            }
        }

        /// <summary>
        /// Details about the person account’s alternate mailing city. Maximum size is 40 characters. Label is <b>Other City</b>.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string OtherCity
        {
            get
            {
                return _personOtherCity;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(OtherCity)].Column, true);
                _personOtherCity = value;
            }
        }

        /// <summary>
        /// The alternate mailing street address for this person account. Label is <b>Other Street</b>. Maximum size is 255 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string OtherStreet
        {
            get
            {
                return _personOtherStreet;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(OtherStreet)].Column, true);
                _personOtherStreet = value;
            }
        }

        /// <summary>
        /// The alternate mailing country for this person account. Label is <b>Other Country</b>. Maximum size is 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string OtherCountry
        {
            get
            {
                return _personOtherCountry;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(OtherCountry)].Column, true);
                _personOtherCountry = value;
            }
        }

        /// <summary>
        /// The alternate mailing country for this person account. Label is <b>Other Zip/Postal Code</b>. Maximum size is 20 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string OtherPostalCode
        {
            get
            {
                return _personOtherPostalCode;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(OtherPostalCode)].Column, true);
                _personOtherPostalCode = value;
            }
        }

        /// <summary>
        /// The alternate mailing state for this person account. Label is <b>Other State</b>. Maximum size is 20 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string OtherState
        {
            get
            {
                return _personOtherState;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(OtherState)].Column, true);
                _personOtherState = value;
            }
        }

        /// <summary>
        /// The ISO country code for the alternate address of the person account.
        /// </summary>
        public string OtherCountryCode
        {
            get
            {
                return _personOtherCountryCode;
            }
            set
            {
                _personOtherCountryCode = value;
            }
        }

        /// <summary>
        /// The ISO state code for the alternate address of the person account.
        /// </summary>
        public string OtherStateCode
        {
            get
            {
                return _personOtherStateCode;
            }
            set
            {
                _personOtherStateCode = value;
            }
        }

        /// <summary>
        /// The alternate phone number for this person account. Label is <b>Other Phone</b>.
        /// </summary>
        public string OtherPhone
        {
            get
            {
                return _personOtherPhone;
            }
            set
            {
                _personOtherPhone = value;
            }
        }

        /// <summary>
        /// The person account's title. Label is <b>Title</b>. Maximum size if 80 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string Title
        {
            get
            {
                return _personTitle;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(Title)].Column, true);
                _personTitle = value;
            }
        }

        /// <summary>
        /// Gets the external table name or <see langword="null"/> if the data source is not stored in a database. This property is read-only.
        /// </summary>
        string IWhippetEntityExternalDataRowImportMapper.ExternalTableName
        {
            get
            {
                return SalesforceObjectConstants.Objects.Account;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceAccount"/> class with no arguments.
        /// </summary>
        public SalesforceAccount()
        { }

        /// <summary>
        /// Imports the specified <see langword="dynamic"/> object containing information needed to populate the <see cref="IWhippetEntity"/>.
        /// </summary>
        /// <param name="dynObj"><see langword="dynamic"/> object containing the data to import.</param>
        /// <exception cref="ArgumentNullException" />
        public void ImportObject(dynamic dynObj)
        {
            if (dynObj == null)
            {
                throw new ArgumentNullException(nameof(dynObj));
            }
            else
            {
                DataTable table = CreateDataTable();
                DataRow row = table.NewRow();

                object rowValue = null;

                foreach (DataColumn column in table.Columns)
                {
                    rowValue = Dynamic.InvokeGet(dynObj, column.ColumnName);

                    if (rowValue == null)
                    {
                        if (column.DataType.Equals(typeof(bool)))
                        {
                            rowValue = default(bool);
                        }
                        else
                        {
                            rowValue = DBNull.Value;
                        }
                    }

                    row[column] = rowValue;
                }

                ImportDataRow(row);
            }
        }

        /// <summary>
        /// Imports a JSON result returned from Salesforce.
        /// </summary>
        /// <param name="jsonObj"><see cref="JObject"/> that was returned from Salesforce.</param>
        /// <param name="availableFields">Available fields returned from the Salesforce instance.</param>
        /// <exception cref="ArgumentNullException" />
        public void ImportJsonObject(dynamic jsonObj, IEnumerable<string> availableFields)
        {
            if (jsonObj == null)
            {
                throw new ArgumentNullException(nameof(jsonObj));
            }
            else if (availableFields == null || !availableFields.Any())
            {
                throw new ArgumentNullException(nameof(availableFields));
            }
            else
            {
                DataTable table = CreateDataTable();
                DataRow row = table.NewRow();

                object rowValue = null;

                string fieldName = String.Empty;

                foreach (DataColumn column in table.Columns)
                {
                    if (availableFields.Contains(column.ColumnName, StringComparer.InvariantCultureIgnoreCase))
                    {
                        fieldName = (from af in availableFields where String.Equals(af, column.ColumnName, StringComparison.InvariantCultureIgnoreCase) select af).FirstOrDefault();
                        rowValue = Dynamic.InvokeGet(jsonObj, fieldName);
                        rowValue = rowValue.ToString();

                        if (rowValue is JObject || rowValue is JToken || String.IsNullOrWhiteSpace(Convert.ToString(rowValue)))
                        {
                            rowValue = null;
                        }
                        else
                        {
                            rowValue = Dynamic.InvokeGet(jsonObj, fieldName);
                        }
                    }
                    else
                    {
                        rowValue = null;
                    }

                    if (rowValue == null)
                    {
                        if (column.DataType.Equals(typeof(bool)))
                        {
                            rowValue = default(bool);
                        }
                        else
                        {
                            rowValue = DBNull.Value;
                        }
                    }

                    row[column] = rowValue;
                }

                ImportDataRow(row);
            }
        }

        /// <summary>
        /// Creates a <see cref="WhippetDataRowImportMap"/> object that contains a mapping for the current entity.
        /// </summary>
        /// <returns><see cref="WhippetDataRowImportMap"/> object.</returns>
        public WhippetDataRowImportMap CreateImportMap()
        {
            return new WhippetDataRowImportMap(new[] {
                new WhippetDataRowImportMapEntry(nameof(AccountNumber), SalesforceObjectConstants.Fields.AccountNumber),
                new WhippetDataRowImportMapEntry(nameof(AccountSource), SalesforceObjectConstants.Fields.AccountSource),
                new WhippetDataRowImportMapEntry(nameof(AnnualRevenue), SalesforceObjectConstants.Fields.AnnualRevenue),
                new WhippetDataRowImportMapEntry(nameof(BillingCity), SalesforceObjectConstants.Fields.BillingCity),
                new WhippetDataRowImportMapEntry(nameof(BillingCountry), SalesforceObjectConstants.Fields.BillingCountry),
                new WhippetDataRowImportMapEntry(nameof(BillingCountryCode), SalesforceObjectConstants.Fields.BillingCountryCode),
                new WhippetDataRowImportMapEntry(nameof(BillingPostalCode), SalesforceObjectConstants.Fields.BillingPostalCode),
                new WhippetDataRowImportMapEntry(nameof(BillingState), SalesforceObjectConstants.Fields.BillingState),
                new WhippetDataRowImportMapEntry(nameof(BillingStateCode), SalesforceObjectConstants.Fields.BillingStateCode),
                new WhippetDataRowImportMapEntry(nameof(BillingStreet), SalesforceObjectConstants.Fields.BillingStreet),
                new WhippetDataRowImportMapEntry(nameof(CleanStatus), SalesforceObjectConstants.Fields.CleanStatus),
                new WhippetDataRowImportMapEntry(nameof(ConnectionReceivedID), SalesforceObjectConstants.Fields.ConnectionReceivedId),
                new WhippetDataRowImportMapEntry(nameof(ConnectionSentID), SalesforceObjectConstants.Fields.ConnectionSentId),
                new WhippetDataRowImportMapEntry(nameof(Description), SalesforceObjectConstants.Fields.Description),
                new WhippetDataRowImportMapEntry(nameof(DUNS_Number), SalesforceObjectConstants.Fields.DunsNumber),
                new WhippetDataRowImportMapEntry(nameof(Fax), SalesforceObjectConstants.Fields.Fax),
                new WhippetDataRowImportMapEntry(nameof(Industry), SalesforceObjectConstants.Fields.Industry),
                new WhippetDataRowImportMapEntry(nameof(IsCustomerPortal), SalesforceObjectConstants.Fields.IsCustomerPortal),
                new WhippetDataRowImportMapEntry(nameof(IsDeleted), SalesforceObjectConstants.Fields.IsDeleted),
                new WhippetDataRowImportMapEntry(nameof(IsPartner), SalesforceObjectConstants.Fields.IsPartner),
                new WhippetDataRowImportMapEntry(nameof(IsPersonAccount), SalesforceObjectConstants.Fields.IsPersonAccount),
                new WhippetDataRowImportMapEntry(nameof(Jigsaw), SalesforceObjectConstants.Fields.Jigsaw),
                new WhippetDataRowImportMapEntry(nameof(LastActivityDate), SalesforceObjectConstants.Fields.LastActivityDate),
                new WhippetDataRowImportMapEntry(nameof(LastReferencedDate), SalesforceObjectConstants.Fields.LastReferencedDate),
                new WhippetDataRowImportMapEntry(nameof(LastViewedDate), SalesforceObjectConstants.Fields.LastViewedDate),
                new WhippetDataRowImportMapEntry(nameof(MasterRecordID), SalesforceObjectConstants.Fields.MasterRecordId),
                new WhippetDataRowImportMapEntry(nameof(NAICS_Code), SalesforceObjectConstants.Fields.NaicsCode),
                new WhippetDataRowImportMapEntry(nameof(NAICS_Description), SalesforceObjectConstants.Fields.NaicsDesc),
                new WhippetDataRowImportMapEntry(nameof(Name), SalesforceObjectConstants.Fields.Name),
                new WhippetDataRowImportMapEntry(nameof(NumberOfEmployees), SalesforceObjectConstants.Fields.NumberOfEmployees),
                new WhippetDataRowImportMapEntry(nameof(OwnerID), SalesforceObjectConstants.Fields.OwnerId),
                new WhippetDataRowImportMapEntry(nameof(Ownership), SalesforceObjectConstants.Fields.Ownership),
                new WhippetDataRowImportMapEntry(nameof(ParentID), SalesforceObjectConstants.Fields.ParentId),
                new WhippetDataRowImportMapEntry(nameof(Phone), SalesforceObjectConstants.Fields.Phone),
                new WhippetDataRowImportMapEntry(nameof(PhotoURL), SalesforceObjectConstants.Fields.PhotoUrl),
                new WhippetDataRowImportMapEntry(nameof(Rating), SalesforceObjectConstants.Fields.Rating),
                new WhippetDataRowImportMapEntry(nameof(RecordTypeID), SalesforceObjectConstants.Fields.RecordTypeId),
                new WhippetDataRowImportMapEntry(nameof(Salutation), SalesforceObjectConstants.Fields.Salutation),
                new WhippetDataRowImportMapEntry(nameof(ShippingCity), SalesforceObjectConstants.Fields.ShippingCity),
                new WhippetDataRowImportMapEntry(nameof(ShippingCountry), SalesforceObjectConstants.Fields.ShippingCountry),
                new WhippetDataRowImportMapEntry(nameof(ShippingCountryCode), SalesforceObjectConstants.Fields.ShippingCountryCode),
                new WhippetDataRowImportMapEntry(nameof(ShippingPostalCode), SalesforceObjectConstants.Fields.ShippingPostalCode),
                new WhippetDataRowImportMapEntry(nameof(ShippingState), SalesforceObjectConstants.Fields.ShippingState),
                new WhippetDataRowImportMapEntry(nameof(ShippingStateCode), SalesforceObjectConstants.Fields.ShippingStateCode),
                new WhippetDataRowImportMapEntry(nameof(ShippingStreet), SalesforceObjectConstants.Fields.ShippingStreet),
                new WhippetDataRowImportMapEntry(nameof(StandardIndustrialClassification), SalesforceObjectConstants.Fields.Sic),
                new WhippetDataRowImportMapEntry(nameof(StandardIndustrialClassification_Description), SalesforceObjectConstants.Fields.SicDesc),
                new WhippetDataRowImportMapEntry(nameof(Site), SalesforceObjectConstants.Fields.Site),
                new WhippetDataRowImportMapEntry(nameof(TickerSymbol), SalesforceObjectConstants.Fields.TickerSymbol),
                new WhippetDataRowImportMapEntry(nameof(Tradestyle), SalesforceObjectConstants.Fields.Tradestyle),
                new WhippetDataRowImportMapEntry(nameof(Type), SalesforceObjectConstants.Fields.Type),
                new WhippetDataRowImportMapEntry(nameof(Website), SalesforceObjectConstants.Fields.Website),
                new WhippetDataRowImportMapEntry(nameof(YearStarted), SalesforceObjectConstants.Fields.YearStarted),
                new WhippetDataRowImportMapEntry(nameof(FirstName), SalesforceObjectConstants.Fields.FirstName),
                new WhippetDataRowImportMapEntry(nameof(LastName), SalesforceObjectConstants.Fields.LastName),
                new WhippetDataRowImportMapEntry(nameof(AssistantName), SalesforceObjectConstants.Fields.PersonAssistantName),
                new WhippetDataRowImportMapEntry(nameof(AssistantPhone), SalesforceObjectConstants.Fields.PersonAssistantPhone),
                new WhippetDataRowImportMapEntry(nameof(Birthdate), SalesforceObjectConstants.Fields.PersonBirthDate),
                new WhippetDataRowImportMapEntry(nameof(PersonContactID), SalesforceObjectConstants.Fields.PersonContactId),
                new WhippetDataRowImportMapEntry(nameof(Department), SalesforceObjectConstants.Fields.PersonDepartment),
                new WhippetDataRowImportMapEntry(nameof(Email), SalesforceObjectConstants.Fields.PersonEmail),
                new WhippetDataRowImportMapEntry(nameof(EmailBouncedDate), SalesforceObjectConstants.Fields.PersonEmailBouncedDate),
                new WhippetDataRowImportMapEntry(nameof(HasOptedOutOfEmail), SalesforceObjectConstants.Fields.PersonHasOptedOutOfEmail),
                new WhippetDataRowImportMapEntry(nameof(HomePhone), SalesforceObjectConstants.Fields.PersonHomePhone),
                new WhippetDataRowImportMapEntry(nameof(LastStayInTouchRequestDate), SalesforceObjectConstants.Fields.PersonLastCURequestDate),
                new WhippetDataRowImportMapEntry(nameof(LastStayInTouchSaveDate), SalesforceObjectConstants.Fields.PersonLastCUUpdateDate),
                new WhippetDataRowImportMapEntry(nameof(LeadSource), SalesforceObjectConstants.Fields.PersonLeadSource),
                new WhippetDataRowImportMapEntry(nameof(MailingCity), SalesforceObjectConstants.Fields.PersonMailingCity),
                new WhippetDataRowImportMapEntry(nameof(MailingStreet), SalesforceObjectConstants.Fields.PersonMailingStreet),
                new WhippetDataRowImportMapEntry(nameof(MailingCountry), SalesforceObjectConstants.Fields.PersonMailingCountry),
                new WhippetDataRowImportMapEntry(nameof(MailingState), SalesforceObjectConstants.Fields.PersonMailingState),
                new WhippetDataRowImportMapEntry(nameof(MailingPostalCode), SalesforceObjectConstants.Fields.PersonMailingPostalCode),
                new WhippetDataRowImportMapEntry(nameof(MobilePhone), SalesforceObjectConstants.Fields.PersonMobilePhone),
                new WhippetDataRowImportMapEntry(nameof(OtherCity), SalesforceObjectConstants.Fields.PersonOtherCity),
                new WhippetDataRowImportMapEntry(nameof(OtherCountry), SalesforceObjectConstants.Fields.PersonOtherCountry),
                new WhippetDataRowImportMapEntry(nameof(OtherPostalCode), SalesforceObjectConstants.Fields.PersonOtherPostalCode),
                new WhippetDataRowImportMapEntry(nameof(OtherState), SalesforceObjectConstants.Fields.PersonOtherState),
                new WhippetDataRowImportMapEntry(nameof(OtherCountryCode), SalesforceObjectConstants.Fields.PersonOtherCountryCode),
                new WhippetDataRowImportMapEntry(nameof(OtherStateCode), SalesforceObjectConstants.Fields.PersonOtherStateCode),
                new WhippetDataRowImportMapEntry(nameof(OtherPhone), SalesforceObjectConstants.Fields.PersonOtherPhone),
                new WhippetDataRowImportMapEntry(nameof(OtherStreet), SalesforceObjectConstants.Fields.PersonOtherStreet),
                new WhippetDataRowImportMapEntry(nameof(Title), SalesforceObjectConstants.Fields.PersonTitle)
            });
        }

        /// <summary>
        /// Imports the specified <see cref="DataRow"/> containing the information needed to populate the <see cref="IWhippetEntity"/>. This method must be overridden.
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> containing the data to import.</param>
        /// <param name="importMap">External <see cref="WhippetDataRowImportMap"/>. If <see langword="null"/>, then the one generated by <see cref="CreateImportMap"/> will be used.</param>
        /// <exception cref="ArgumentNullException" />
        public void ImportDataRow(DataRow dataRow, WhippetDataRowImportMap importMap = null)
        {
            if (dataRow == null)
            {
                throw new ArgumentNullException(nameof(dataRow));
            }
            else
            {
                WhippetDataRowImportMap map = (importMap == null ? CreateImportMap() : importMap);

                AccountNumber = dataRow.Field<string>(map[nameof(AccountNumber)].Column);
                AccountSource = dataRow.Field<string>(map[nameof(AccountSource)].Column);
                AnnualRevenue = dataRow.Field<decimal?>(map[nameof(AnnualRevenue)].Column);
                BillingCity = dataRow.Field<string>(map[nameof(BillingCity)].Column);
                BillingCountry = dataRow.Field<string>(map[nameof(BillingCountry)].Column);
                BillingCountryCode = dataRow.Field<string>(map[nameof(BillingCountryCode)].Column);
                BillingPostalCode = dataRow.Field<string>(map[nameof(BillingPostalCode)].Column);
                BillingState = dataRow.Field<string>(map[nameof(BillingState)].Column);
                BillingStateCode = dataRow.Field<string>(map[nameof(BillingStateCode)].Column);
                BillingStreet = dataRow.Field<string>(map[nameof(BillingStreet)].Column);

                if (!String.IsNullOrWhiteSpace(dataRow.Field<string>(map[nameof(CleanStatus)].Column)))
                {
                    try
                    {
                        CleanStatus = Enum.Parse<SalesforceCleanStatus>(dataRow.Field<string>(map[nameof(CleanStatus)].Column));
                    }
                    catch
                    {
                        CleanStatus = null;
                    }
                }
                else
                {
                    CleanStatus = null;
                }

                ConnectionReceivedID = dataRow.Field<string>(map[nameof(ConnectionReceivedID)].Column);
                ConnectionSentID = dataRow.Field<string>(map[nameof(ConnectionSentID)].Column);
                Description = dataRow.Field<string>(map[nameof(Description)].Column);
                DUNS_Number = dataRow.Field<string>(map[nameof(DUNS_Number)].Column);
                Fax = dataRow.Field<string>(map[nameof(Fax)].Column);
                Industry = dataRow.Field<string>(map[nameof(Industry)].Column);
                IsCustomerPortal = dataRow.Field<bool>(map[nameof(IsCustomerPortal)].Column);
                IsDeleted = dataRow.Field<bool>(map[nameof(IsDeleted)].Column);
                IsPartner = dataRow.Field<bool>(map[nameof(IsPartner)].Column);
                IsPersonAccount = dataRow.Field<bool>(map[nameof(IsPersonAccount)].Column);
                Jigsaw = dataRow.Field<string>(map[nameof(Jigsaw)].Column);

                if (dataRow.Field<DateTime?>(map[nameof(LastActivityDate)].Column).HasValue)
                {
                    LastActivityDate = dataRow.Field<DateTime>(map[nameof(LastActivityDate)].Column).ToInstant();
                }
                else
                {
                    LastActivityDate = null;
                }

                if (dataRow.Field<DateTime?>(map[nameof(LastReferencedDate)].Column).HasValue)
                {
                    LastReferencedDate = dataRow.Field<DateTime>(map[nameof(LastReferencedDate)].Column).ToInstant();
                }
                else
                {
                    LastReferencedDate = null;
                }

                if (dataRow.Field<DateTime?>(map[nameof(LastViewedDate)].Column).HasValue)
                {
                    LastViewedDate = dataRow.Field<DateTime>(map[nameof(LastViewedDate)].Column).ToInstant();
                }
                else
                {
                    LastViewedDate = null;
                }

                MasterRecordID = dataRow.Field<string>(map[nameof(MasterRecordID)].Column);
                NAICS_Code = dataRow.Field<string>(map[nameof(NAICS_Code)].Column);
                NAICS_Description = dataRow.Field<string>(map[nameof(NAICS_Description)].Column);
                Name = dataRow.Field<string>(map[nameof(Name)].Column);
                NumberOfEmployees = dataRow.Field<int?>(map[nameof(NumberOfEmployees)].Column);
                OwnerID = dataRow.Field<string>(map[nameof(OwnerID)].Column);

                if (!String.IsNullOrWhiteSpace(dataRow.Field<string>(map[nameof(Ownership)].Column)))
                {
                    try
                    {
                        Ownership = Enum.Parse<SalesforceOwnership>(dataRow.Field<string>(map[nameof(Ownership)].Column));
                    }
                    catch
                    {
                        Ownership = null;
                    }
                }
                else
                {
                    Ownership = null;
                }

                ParentID = dataRow.Field<string>(map[nameof(ParentID)].Column);
                Phone = dataRow.Field<string>(map[nameof(Phone)].Column);
                PhotoURL = dataRow.Field<string>(map[nameof(PhotoURL)].Column);

                if (!String.IsNullOrWhiteSpace(dataRow.Field<string>(map[nameof(Rating)].Column)))
                {
                    try
                    {
                        Rating = Enum.Parse<SalesforceRating>(dataRow.Field<string>(map[nameof(Rating)].Column));
                    }
                    catch
                    {
                        Rating = null;
                    }
                }
                else
                {
                    Rating = null;
                }

                RecordTypeID = dataRow.Field<string>(map[nameof(RecordTypeID)].Column);
                Salutation = dataRow.Field<string>(map[nameof(Salutation)].Column);
                ShippingCity = dataRow.Field<string>(map[nameof(ShippingCity)].Column);
                ShippingCountry = dataRow.Field<string>(map[nameof(ShippingCountry)].Column);
                ShippingCountryCode = dataRow.Field<string>(map[nameof(ShippingCountryCode)].Column);
                ShippingPostalCode = dataRow.Field<string>(map[nameof(ShippingPostalCode)].Column);
                ShippingState = dataRow.Field<string>(map[nameof(ShippingState)].Column);
                ShippingStateCode = dataRow.Field<string>(map[nameof(ShippingStateCode)].Column);
                ShippingStreet = dataRow.Field<string>(map[nameof(ShippingStreet)].Column);
                StandardIndustrialClassification = dataRow.Field<string>(map[nameof(StandardIndustrialClassification)].Column);
                StandardIndustrialClassification_Description = dataRow.Field<string>(map[nameof(StandardIndustrialClassification_Description)].Column);
                Site = dataRow.Field<string>(map[nameof(Site)].Column);
                TickerSymbol = dataRow.Field<string>(map[nameof(TickerSymbol)].Column);
                Tradestyle = dataRow.Field<string>(map[nameof(Tradestyle)].Column);

                if (!String.IsNullOrWhiteSpace(dataRow.Field<string>(map[nameof(Type)].Column)))
                {
                    try
                    {
                        Type = Enum.Parse<SalesforceAccountType>(dataRow.Field<string>(map[nameof(Type)].Column));
                    }
                    catch
                    {
                        Type = null;
                    }
                }
                else
                {
                    Type = null;
                }

                Website = dataRow.Field<string>(map[nameof(Website)].Column);
                YearStarted = dataRow.Field<string>(map[nameof(YearStarted)].Column);
                FirstName = dataRow.Field<string>(map[nameof(FirstName)].Column);
                LastName = dataRow.Field<string>(map[nameof(LastName)].Column);
                AssistantName = dataRow.Field<string>(map[nameof(AssistantName)].Column);
                AssistantPhone = dataRow.Field<string>(map[nameof(AssistantPhone)].Column);

                if (dataRow.Field<DateTime?>(map[nameof(Birthdate)].Column).HasValue)
                {
                    Birthdate = dataRow.Field<DateTime>(map[nameof(Birthdate)].Column).ToInstant();
                }
                else
                {
                    Birthdate = null;
                }

                PersonContactID = dataRow.Field<string>(map[nameof(PersonContactID)].Column);
                Department = dataRow.Field<string>(map[nameof(Department)].Column);
                Email = dataRow.Field<string>(map[nameof(Email)].Column);

                if (dataRow.Field<DateTime?>(map[nameof(EmailBouncedDate)].Column).HasValue)
                {
                    EmailBouncedDate = dataRow.Field<DateTime>(map[nameof(EmailBouncedDate)].Column).ToInstant();
                }
                else
                {
                    EmailBouncedDate = null;
                }

                HomePhone = dataRow.Field<string>(map[nameof(HomePhone)].Column);

                if (dataRow.Field<DateTime?>(map[nameof(LastStayInTouchRequestDate)].Column).HasValue)
                {
                    LastStayInTouchRequestDate = dataRow.Field<DateTime>(map[nameof(LastStayInTouchRequestDate)].Column).ToInstant();
                }
                else
                {
                    LastStayInTouchRequestDate = null;
                }

                if (dataRow.Field<DateTime?>(map[nameof(LastStayInTouchSaveDate)].Column).HasValue)
                {
                    LastStayInTouchSaveDate = dataRow.Field<DateTime>(map[nameof(LastStayInTouchSaveDate)].Column).ToInstant();
                }
                else
                {
                    LastStayInTouchSaveDate = null;
                }

                LeadSource = dataRow.Field<string>(map[nameof(LeadSource)].Column);
                MailingCity = dataRow.Field<string>(map[nameof(MailingCity)].Column);
                MailingStreet = dataRow.Field<string>(map[nameof(MailingStreet)].Column);
                MobilePhone = dataRow.Field<string>(map[nameof(MobilePhone)].Column);
                MailingCountry = dataRow.Field<string>(map[nameof(MailingCountry)].Column);
                MailingState = dataRow.Field<string>(map[nameof(MailingState)].Column);
                MailingPostalCode = dataRow.Field<string>(map[nameof(MailingPostalCode)].Column);
                OtherCity = dataRow.Field<string>(map[nameof(OtherCity)].Column);
                OtherCountry = dataRow.Field<string>(map[nameof(OtherCountry)].Column);
                OtherPostalCode = dataRow.Field<string>(map[nameof(OtherPostalCode)].Column);
                OtherState = dataRow.Field<string>(map[nameof(OtherState)].Column);
                OtherStreet = dataRow.Field<string>(map[nameof(OtherStreet)].Column);
                OtherCountryCode = dataRow.Field<string>(map[nameof(OtherCountryCode)].Column);
                OtherStateCode = dataRow.Field<string>(map[nameof(OtherStateCode)].Column);
                OtherPhone = dataRow.Field<string>(map[nameof(OtherPhone)].Column);
                Title = dataRow.Field<string>(map[nameof(Title)].Column);
            }
        }

        /// <summary>
        /// Creates a <see cref="DataTable"/> that represents the database table of the current entity.
        /// </summary>
        /// <returns><see cref="DataTable"/> containing the columns and respective definitions of the associated external database table for the current entity.</returns>
        public DataTable CreateDataTable()
        {
            WhippetDataRowImportMap map = CreateImportMap();
            DataTable table = new DataTable(((IWhippetEntityExternalDataRowImportMapper)(this)).ExternalTableName);

            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(AccountNumber)].Column, true, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(AccountSource)].Column, true, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(AnnualRevenue)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(BillingCity)].Column, true, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(BillingCountry)].Column, true, 80));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(BillingCountryCode)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(BillingPostalCode)].Column, true, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(BillingState)].Column, true, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(BillingStateCode)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(BillingStreet)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CleanStatus)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ConnectionReceivedID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ConnectionSentID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Description)].Column, true, 16000000));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(DUNS_Number)].Column, true, 9));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Fax)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Industry)].Column, true, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsCustomerPortal)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsDeleted)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsPartner)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsPersonAccount)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Jigsaw)].Column, true, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastActivityDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastReferencedDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastViewedDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(MasterRecordID)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(NAICS_Code)].Column, true, 8));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(NAICS_Description)].Column, true, 120));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Name)].Column, false, 255));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(NumberOfEmployees)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OwnerID)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Ownership)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ParentID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Phone)].Column, true, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PhotoURL)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Rating)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(RecordTypeID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Salutation)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ShippingCity)].Column, true, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ShippingCountry)].Column, true, 80));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ShippingCountryCode)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ShippingPostalCode)].Column, true, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ShippingState)].Column, true, 80));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ShippingStateCode)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ShippingStreet)].Column, true, 255));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(StandardIndustrialClassification)].Column, true, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(StandardIndustrialClassification_Description)].Column, true, 80));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Site)].Column, true, 80));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(TickerSymbol)].Column, true, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Tradestyle)].Column, true, 255));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Type)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Website)].Column, true, 255));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(YearStarted)].Column, true, 4));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(FirstName)].Column, true, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(LastName)].Column, true, 80));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(AssistantName)].Column, true, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(AssistantPhone)].Column, true, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(Birthdate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PersonContactID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Department)].Column, true, 80));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Email)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(EmailBouncedDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(HasOptedOutOfEmail)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(HomePhone)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastStayInTouchRequestDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastStayInTouchSaveDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(LeadSource)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(MailingCity)].Column, true, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(MailingStreet)].Column, true, 255));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(MobilePhone)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(MailingState)].Column, true, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(MailingCountry)].Column, true, 80));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(MailingPostalCode)].Column, true, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OtherCity)].Column, true, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OtherCountry)].Column, true, 80));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OtherCountryCode)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OtherPhone)].Column, true, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OtherPostalCode)].Column, true, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OtherState)].Column, true, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OtherStateCode)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OtherStreet)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Title)].Column, true, 80));

            return table;
        }

        /// <summary>
        /// Creates a new <see cref="DataRow"/> that represents the current entity's state.
        /// </summary>
        /// <returns><see cref="DataRow"/> object containing the values of the current entity.</returns>
        public DataRow CreateDataRow()
        {
            return this.CreateDataRow__Internal();
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as ISalesforceAccount);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ISalesforceAccount obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="ISalesforceAccount"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="ISalesforceAccount"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ISalesforceAccount a, ISalesforceAccount b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals =
                    String.Equals(a.AccountNumber, b.AccountNumber, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.AccountSource, b.AccountSource, StringComparison.InvariantCultureIgnoreCase)
                        && a.AnnualRevenue.GetValueOrDefault().Equals(b.AnnualRevenue.GetValueOrDefault())
                        && String.Equals(a.AssistantName, b.AssistantName, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.AssistantPhone, b.AssistantPhone, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.BillingCity, b.BillingCity, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.BillingCountry, b.BillingCountry, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.BillingCountryCode, b.BillingCountryCode, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.BillingPostalCode, b.BillingPostalCode, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.BillingState, b.BillingState, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.BillingStateCode, b.BillingStateCode, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.BillingStreet, b.BillingStreet, StringComparison.InvariantCultureIgnoreCase)
                        && a.Birthdate.GetValueOrDefault().Equals(b.Birthdate.GetValueOrDefault())
                        && a.CleanStatus.GetValueOrDefault().Equals(b.CleanStatus.GetValueOrDefault())
                        && String.Equals(a.ConnectionReceivedID, b.ConnectionReceivedID, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.ConnectionSentID, b.ConnectionSentID, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Department, b.Department, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Description, b.Description, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.DUNS_Number, b.DUNS_Number, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Email, b.Email, StringComparison.InvariantCultureIgnoreCase)
                        && a.EmailBouncedDate.GetValueOrDefault().Equals(b.EmailBouncedDate.GetValueOrDefault())
                        && String.Equals(a.Fax, b.Fax, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.FirstName, b.FirstName, StringComparison.InvariantCultureIgnoreCase)
                        && a.HasOptedOutOfEmail.Equals(b.HasOptedOutOfEmail)
                        && String.Equals(a.HomePhone, b.HomePhone, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Industry, b.Industry, StringComparison.InvariantCultureIgnoreCase)
                        && a.IsCustomerPortal.Equals(b.IsCustomerPortal)
                        && a.IsDeleted.Equals(b.IsDeleted)
                        && a.IsPartner.Equals(b.IsPartner)
                        && a.IsPersonAccount.Equals(b.IsPersonAccount)
                        && String.Equals(a.Jigsaw, b.Jigsaw, StringComparison.InvariantCultureIgnoreCase)
                        && a.LastActivityDate.GetValueOrDefault().Equals(b.LastActivityDate.GetValueOrDefault())
                        && String.Equals(a.LastName, b.LastName, StringComparison.InvariantCultureIgnoreCase)
                        && a.LastReferencedDate.GetValueOrDefault().Equals(b.LastReferencedDate.GetValueOrDefault())
                        && a.LastStayInTouchRequestDate.GetValueOrDefault().Equals(b.LastStayInTouchRequestDate.GetValueOrDefault())
                        && a.LastStayInTouchSaveDate.GetValueOrDefault().Equals(b.LastStayInTouchSaveDate.GetValueOrDefault())
                        && a.LastViewedDate.GetValueOrDefault().Equals(b.LastViewedDate.GetValueOrDefault())
                        && String.Equals(a.LeadSource, b.LeadSource, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.MailingCity, b.MailingCity, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.MailingCountry, b.MailingCountry, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.MailingPostalCode, b.MailingPostalCode, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.MailingState, b.MailingState, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.MailingStreet, b.MailingStreet, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.MasterRecordID, b.MasterRecordID, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.MobilePhone, b.MobilePhone, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.NAICS_Code, b.NAICS_Code, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.NAICS_Description, b.NAICS_Description, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase)
                        && a.NumberOfEmployees.GetValueOrDefault().Equals(b.NumberOfEmployees.GetValueOrDefault())
                        && String.Equals(a.OtherCity, b.OtherCity, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.OtherCountry, b.OtherCountry, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.OtherCountryCode, b.OtherCountryCode, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.OtherPhone, b.OtherPhone, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.OtherPostalCode, b.OtherPostalCode, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.OtherState, b.OtherState, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.OtherStateCode, b.OtherStateCode, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.OtherStreet, b.OtherStreet, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.OwnerID, b.OwnerID, StringComparison.InvariantCultureIgnoreCase)
                        && a.Ownership.GetValueOrDefault().Equals(b.Ownership.GetValueOrDefault())
                        && String.Equals(a.ParentID, b.ParentID, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.PersonContactID, b.PersonContactID, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Phone, b.Phone, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.PhotoURL, b.PhotoURL, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.ShippingPostalCode, b.ShippingPostalCode, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.ShippingState, b.ShippingState, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.ShippingStateCode, b.ShippingStateCode, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.ShippingStreet, b.ShippingStreet, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Site, b.Site, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.StandardIndustrialClassification, b.StandardIndustrialClassification, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.StandardIndustrialClassification_Description, b.StandardIndustrialClassification_Description, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.TickerSymbol, b.TickerSymbol, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Title, b.Title, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Tradestyle, b.Tradestyle, StringComparison.InvariantCultureIgnoreCase)
                        && a.Type.GetValueOrDefault().Equals(b.Type.GetValueOrDefault())
                        && String.Equals(a.Website, b.Website, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.YearStarted, b.YearStarted, StringComparison.InvariantCultureIgnoreCase);
            }

            return equals;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException" />
        public int GetHashCode(ISalesforceAccount obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else
            {
                return obj.GetHashCode();
            }
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            if (IsPersonAccount)
            {
                if (!String.IsNullOrWhiteSpace(FirstName))
                {
                    builder.Append(FirstName);

                    if (!String.IsNullOrWhiteSpace(LastName))
                    {
                        builder.Append(' ');
                        builder.Append(LastName);
                    }
                }
                else if (!String.IsNullOrWhiteSpace(LastName))
                {
                    builder.Append(LastName);
                }
            }
            else
            {
                builder.Append(Name);
            }

            return String.IsNullOrWhiteSpace(builder.ToString()) ? base.ToString() : builder.ToString();
        }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be overridden.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public string ToJson<T>() where T : IJsonSerializableObject
        {
            return this.SerializeJson(this);
        }
    }
}

