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
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents a contact, which is a person associated with an account. This class cannot be inherited.
    /// </summary>
    /// <remarks>See <a href="https://developer.salesforce.com/docs/atlas.en-us.228.0.object_reference.meta/object_reference/sforce_api_objects_contact.htm">Contact</a> for more information.</remarks>
    public sealed class SalesforceContact : IWhippetEntityDynamicImportMapper, IWhippetEntityExternalDataRowImportMapper, IWhippetEntity, ISalesforceObject, ISalesforceContact
    {
        private string _description;
        private string _firstName;
        private string _jigsaw;
        private string _lastName;
        private string _name;

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
        /// ID of the account that’s the parent of this contact.
        /// </summary>
        public SalesforceReference? AccountID
        { get; set; }

        /// <summary>
        /// The assistant’s name.
        /// </summary>
        public string AssistantName
        { get; set; }

        /// <summary>
        /// The assistant’s telephone number.
        /// </summary>
        public string AssistantPhone
        { get; set; }

        /// <summary>
        /// The contact’s birthdate.
        /// </summary>
        public Instant? Birthdate
        { get; set; }

        /// <summary>
        /// Indicates whether this contact can self-register for your Customer Portal (true) or not (false).
        /// </summary>
        public bool CanAllowPortalSelfRegistration
        { get; set; }

        /// <summary>
        /// Gets the external table name or <see langword="null"/> if the data source is not stored in a database. This property is read-only.
        /// </summary>
        string IWhippetEntityExternalDataRowImportMapper.ExternalTableName
        {
            get
            {
                return SalesforceObjectConstants.Objects.Contact;
            }
        }

        /// <summary>
        /// Indicates the record’s clean status as compared with Data.com. 
        /// </summary>
        public SalesforceCleanStatus? CleanStatus
        { get; set; }

        /// <summary>
        /// ID of the PartnerNetworkConnection that shared this record with your organization. This field is available if you enabled Salesforce to Salesforce.
        /// </summary>
        public SalesforceReference? ConnectionReceivedID
        { get; set; }

        /// <summary>
        /// ID of the PartnerNetworkConnection that you shared this record with. This field is available if you enabled Salesforce to Salesforce. This field is supported using API versions earlier than 15.0. In all other API versions, this field’s value is <see langword="null"/>. You can use the new <a href="https://developer.salesforce.com/docs/atlas.en-us.object_reference.meta/object_reference/sforce_api_objects_partnernetworkrecordconnection.htm">PartnerNetworkRecordConnection</a> object to forward records to connections.
        /// </summary>
        public SalesforceReference? ConnectionSentID
        { get; set; }

        /// <summary>
        /// The department of the contact.
        /// </summary>
        public string Department
        { get; set; }

        /// <summary>
        /// A description of the contact. Label is <b>Contact Description</b>.
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
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Description)].Column, true);
                _description = value;
            }
        }

        /// <summary>
        /// Indicates that the contact does not wish to be called.
        /// </summary>
        public bool DoNotCall
        { get; set; }

        /// <summary>
        /// Email address for the contact.
        /// </summary>
        public string Email
        { get; set; }

        /// <summary>
        /// If bounce management is activated and an email sent to the contact bounces, the date and time the bounce occurred.
        /// </summary>
        public Instant? EmailBouncedDate
        { get; set; }

        /// <summary>
        /// If bounce management is activated and an email sent to the contact bounces, the reason the bounce occurred.
        /// </summary>
        public string EmailBouncedReason
        { get; set; }

        /// <summary>
        /// Fax number for the contact. Label is <b>Business Phone</b>.
        /// </summary>
        public string Fax
        { get; set; }

        /// <summary>
        /// First name of the contact. Maximum size is 40 characters.
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
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(FirstName)].Column, true);
                _firstName = value;
            }
        }

        /// <summary>
        /// Indicates whether the contact would prefer not to receive email from Salesforce (true) or not (false). Label is <b>Email Opt Out</b>.
        /// </summary>
        public bool HasOptedOutOfEmail
        { get; set; }

        /// <summary>
        /// Indicates that the contact does not wish to receive faxes.
        /// </summary>
        public bool HasOptedOutOfFax
        { get; set; }

        /// <summary>
        /// Home telephone number for the contact.
        /// </summary>
        public string HomePhone
        { get; set; }

        /// <summary>
        /// Indicates whether the object has been moved to the Recycle Bin (true) or not (false). Label is <b>Deleted</b>.
        /// </summary>
        public bool IsDeleted
        { get; set; }

        /// <summary>
        /// If bounce management is activated and an email is sent to a contact, indicates whether the email bounced (true) or not (false).
        /// </summary>
        public bool IsEmailBounced
        { get; set; }

        /// <summary>
        /// Read only. Label is <b>Is Person Account</b>. Indicates whether this account has a record type of Person Account (true) or not (false).
        /// </summary>
        public bool IsPersonAccount
        { get; set; }

        /// <summary>
        /// References the ID of a company in Data.com. If an account has a value in this field, it means that the account was imported from Data.com. If the field value is <see langword="null"/>, the account was not imported from Data.com. Maximum size is 20 characters. Available in API version 22.0 and later. Label is <b>Data.com Key</b>.
        /// </summary>
        public string Jigsaw
        {
            get
            {
                return _jigsaw;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Jigsaw)].Column, true);
                _jigsaw = value;
            }
        }

        /// <summary>
        /// Value is one of the following, whichever is the most recent: due date of the most recent event logged against the record, or the due date of the most recently closed task associated with the record.
        /// </summary>
        public Instant? LastActivityDate
        { get; set; }

        /// <summary>
        /// The last date that a Stay-in-Touch request was sent to the contact.
        /// </summary>
        public Instant? LastStayInTouchRequestDate
        { get; set; }

        /// <summary>
        /// The last time a Stay-in-Touch update was processed for the contact.
        /// </summary>
        public Instant? LastStayInTouchSaveDate
        { get; set; }

        /// <summary>
        /// Required. Last name of the contact. Maximum size is 80 characters.
        /// </summary>
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(LastName)].Column, true);
                _lastName = value;
            }
        }

        /// <summary>
        /// The timestamp for when the current user last viewed a record related to this record.
        /// </summary>
        public Instant? LastReferencedDate
        { get; set; }

        /// <summary>
        /// The timestamp for when the current user last viewed this record. If this value is <see langword="null"/>, this record might only have been referenced (<see cref="LastReferencedDate"/>) and not viewed.
        /// </summary>
        public Instant? LastViewedDate
        { get; set; }

        /// <summary>
        /// The source of the lead.
        /// </summary>
        public string LeadSource
        { get; set; }

        /// <summary>
        /// Details about the contact's mailing city.
        /// </summary>
        public string MailingCity
        { get; set; }

        /// <summary>
        /// The mailing street address for this contact.
        /// </summary>
        public string MailingStreet
        { get; set; }

        /// <summary>
        /// The mailing country for this contact.
        /// </summary>
        public string MailingCountry
        { get; set; }

        /// <summary>
        /// The mailing postal code for this contact.
        /// </summary>
        public string MailingPostalCode
        { get; set; }

        /// <summary>
        /// The mailing state for this postal code.
        /// </summary>
        public string MailingState
        { get; set; }

        /// <summary>
        /// The ISO code for the mailing address state.
        /// </summary>
        public string MailingStateCode
        { get; set; }

        /// <summary>
        /// The ISO code for the mailing address country.
        /// </summary>
        public string MailingCountryCode
        { get; set; }

        /// <summary>
        /// If this object was deleted as the result of a merge, this field contains the ID of the record that was kept. If this object was deleted for any other reason, or has not been deleted, the value is <see langword="null"/>.
        /// </summary>
        public SalesforceReference? MasterRecordID
        { get; set; }

        /// <summary>
        /// Contact’s mobile phone number.
        /// </summary>
        public string MobilePhone
        { get; set; }

        /// <summary>
        /// Name of the contact. Maximum size is 121 characters.
        /// </summary>
        public string Name
        {
            get
            {
                return (String.IsNullOrWhiteSpace(_name) && !(String.IsNullOrWhiteSpace(FirstName) || String.IsNullOrWhiteSpace(LastName))) ? (FirstName + " " + LastName).Trim() : _name;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Name)].Column, true);
                _name = value;
            }
        }

        /// <summary>
        /// Details about the contact's alternate mailing city.
        /// </summary>
        public string OtherCity
        { get; set; }

        /// <summary>
        /// The alternate mailing street address for this contact.
        /// </summary>
        public string OtherStreet
        { get; set; }

        /// <summary>
        /// The alternate mailing country for this contact.
        /// </summary>
        public string OtherCountry
        { get; set; }

        /// <summary>
        /// The alternate mailing postal code for this contact.
        /// </summary>
        public string OtherPostalCode
        { get; set; }

        /// <summary>
        /// The alternate mailing state for this postal code.
        /// </summary>
        public string OtherState
        { get; set; }

        /// <summary>
        /// The ISO code for the alternate mailing address state.
        /// </summary>
        public string OtherStateCode
        { get; set; }

        /// <summary>
        /// The ISO code for the alternate mailing address country.
        /// </summary>
        public string OtherCountryCode
        { get; set; }

        /// <summary>
        /// Telephone for alternate address.
        /// </summary>
        public string OtherPhone
        { get; set; }

        /// <summary>
        /// The ID of the owner of the account associated with this contact.
        /// </summary>
        public SalesforceReference? OwnerID
        { get; set; }

        /// <summary>
        /// Telephone number for the contact. Label is <b>Business Phone</b>.
        /// </summary>
        public string Phone
        { get; set; }

        /// <summary>
        /// Path to be combined with the URL of a Salesforce instance (for example, https://na1.salesforce.com/) to generate a URL to request the social network profile image associated with the contact. Generated URL returns an HTTP redirect (code 302) to the social network profile image for the contact. Blank if Social Accounts and Contacts isn't enabled for the organization or if Social Accounts and Contacts is disabled for the requesting user.
        /// </summary>
        public string PhotoUrl
        { get; set; }

        /// <summary>
        /// ID of the record type assigned to this object.
        /// </summary>
        public SalesforceReference? RecordTypeID
        { get; set; }

        /// <summary>
        /// This field is not visible if <see cref="IsPersonAccount"/> is <see langword="true"/>.
        /// </summary>
        public SalesforceReference? ReportsToID
        { get; set; }

        /// <summary>
        /// Honorific abbreviation, word, or phrase to be used in front of name in greetings, such as Dr. or Mrs.
        /// </summary>
        public string Salutation
        { get; set; }

        /// <summary>
        /// Title of the contact such as CEO or Vice President.
        /// </summary>
        public string Title
        { get; set; }

        /// <summary>
        /// ID of the parent object (if any).
        /// </summary>
        SalesforceReference? ISalesforceObject.ParentID
        {
            get
            {
                return null;
            }
            set
            { }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceContact"/> class with no arguments.
        /// </summary>
        public SalesforceContact()
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
                new WhippetDataRowImportMapEntry(nameof(AccountID), SalesforceObjectConstants.Fields.AccountId),
                new WhippetDataRowImportMapEntry(nameof(AssistantName), SalesforceObjectConstants.Fields.AssistantName),
                new WhippetDataRowImportMapEntry(nameof(AssistantPhone), SalesforceObjectConstants.Fields.AssistantPhone),
                new WhippetDataRowImportMapEntry(nameof(Birthdate), SalesforceObjectConstants.Fields.Birthdate),
                new WhippetDataRowImportMapEntry(nameof(CanAllowPortalSelfRegistration), SalesforceObjectConstants.Fields.CanAllowPortalSelfReg),
                new WhippetDataRowImportMapEntry(nameof(CleanStatus), SalesforceObjectConstants.Fields.CleanStatus),
                new WhippetDataRowImportMapEntry(nameof(ConnectionReceivedID), SalesforceObjectConstants.Fields.ConnectionReceivedId),
                new WhippetDataRowImportMapEntry(nameof(ConnectionSentID), SalesforceObjectConstants.Fields.ConnectionSentId),
                new WhippetDataRowImportMapEntry(nameof(Department), SalesforceObjectConstants.Fields.Department),
                new WhippetDataRowImportMapEntry(nameof(Description), SalesforceObjectConstants.Fields.Description),
                new WhippetDataRowImportMapEntry(nameof(DoNotCall), SalesforceObjectConstants.Fields.DoNotCall),
                new WhippetDataRowImportMapEntry(nameof(Email), SalesforceObjectConstants.Fields.Email),
                new WhippetDataRowImportMapEntry(nameof(EmailBouncedDate), SalesforceObjectConstants.Fields.EmailBouncedDate),
                new WhippetDataRowImportMapEntry(nameof(EmailBouncedReason), SalesforceObjectConstants.Fields.EmailBouncedReason),
                new WhippetDataRowImportMapEntry(nameof(Fax), SalesforceObjectConstants.Fields.Fax),
                new WhippetDataRowImportMapEntry(nameof(FirstName), SalesforceObjectConstants.Fields.FirstName),
                new WhippetDataRowImportMapEntry(nameof(HasOptedOutOfEmail), SalesforceObjectConstants.Fields.HasOptedOutOfEmail),
                new WhippetDataRowImportMapEntry(nameof(HasOptedOutOfFax), SalesforceObjectConstants.Fields.HasOptedOutOfFax),
                new WhippetDataRowImportMapEntry(nameof(HomePhone), SalesforceObjectConstants.Fields.HomePhone),
                new WhippetDataRowImportMapEntry(nameof(IsDeleted), SalesforceObjectConstants.Fields.IsDeleted),
                new WhippetDataRowImportMapEntry(nameof(IsEmailBounced), SalesforceObjectConstants.Fields.IsEmailBounced),
                new WhippetDataRowImportMapEntry(nameof(IsPersonAccount), SalesforceObjectConstants.Fields.IsPersonAccount),
                new WhippetDataRowImportMapEntry(nameof(Jigsaw), SalesforceObjectConstants.Fields.Jigsaw),
                new WhippetDataRowImportMapEntry(nameof(LastActivityDate), SalesforceObjectConstants.Fields.LastActivityDate),
                new WhippetDataRowImportMapEntry(nameof(LastStayInTouchRequestDate), SalesforceObjectConstants.Fields.PersonLastCURequestDate),
                new WhippetDataRowImportMapEntry(nameof(LastStayInTouchSaveDate), SalesforceObjectConstants.Fields.PersonLastCUUpdateDate),
                new WhippetDataRowImportMapEntry(nameof(LastName), SalesforceObjectConstants.Fields.LastName),
                new WhippetDataRowImportMapEntry(nameof(LastReferencedDate), SalesforceObjectConstants.Fields.LastReferencedDate),
                new WhippetDataRowImportMapEntry(nameof(LastViewedDate), SalesforceObjectConstants.Fields.LastViewedDate),
                new WhippetDataRowImportMapEntry(nameof(LeadSource), SalesforceObjectConstants.Fields.LeadSource),
                new WhippetDataRowImportMapEntry(nameof(MailingCity), SalesforceObjectConstants.Fields.MailingCity),
                new WhippetDataRowImportMapEntry(nameof(MailingState), SalesforceObjectConstants.Fields.MailingState),
                new WhippetDataRowImportMapEntry(nameof(MailingCountry), SalesforceObjectConstants.Fields.MailingCountry),
                new WhippetDataRowImportMapEntry(nameof(MailingPostalCode), SalesforceObjectConstants.Fields.MailingPostalCode),
                new WhippetDataRowImportMapEntry(nameof(MailingStateCode), SalesforceObjectConstants.Fields.MailingStateCode),
                new WhippetDataRowImportMapEntry(nameof(MailingCountryCode), SalesforceObjectConstants.Fields.MailingCountryCode),
                new WhippetDataRowImportMapEntry(nameof(MailingStreet), SalesforceObjectConstants.Fields.MailingStreet),
                new WhippetDataRowImportMapEntry(nameof(MasterRecordID), SalesforceObjectConstants.Fields.MasterRecordId),
                new WhippetDataRowImportMapEntry(nameof(MobilePhone), SalesforceObjectConstants.Fields.MobilePhone),
                new WhippetDataRowImportMapEntry(nameof(Name), SalesforceObjectConstants.Fields.Name),
                new WhippetDataRowImportMapEntry(nameof(OtherCity), SalesforceObjectConstants.Fields.OtherCity),
                new WhippetDataRowImportMapEntry(nameof(OtherCountry), SalesforceObjectConstants.Fields.OtherCountry),
                new WhippetDataRowImportMapEntry(nameof(OtherPostalCode), SalesforceObjectConstants.Fields.OtherPostalCode),
                new WhippetDataRowImportMapEntry(nameof(OtherState), SalesforceObjectConstants.Fields.OtherState),
                new WhippetDataRowImportMapEntry(nameof(OtherCountryCode), SalesforceObjectConstants.Fields.OtherCountryCode),
                new WhippetDataRowImportMapEntry(nameof(OtherStateCode), SalesforceObjectConstants.Fields.OtherStateCode),
                new WhippetDataRowImportMapEntry(nameof(OtherPhone), SalesforceObjectConstants.Fields.OtherPhone),
                new WhippetDataRowImportMapEntry(nameof(OtherStreet), SalesforceObjectConstants.Fields.OtherStreet),
                new WhippetDataRowImportMapEntry(nameof(OwnerID), SalesforceObjectConstants.Fields.OwnerId),
                new WhippetDataRowImportMapEntry(nameof(Phone), SalesforceObjectConstants.Fields.Phone),
                new WhippetDataRowImportMapEntry(nameof(PhotoUrl), SalesforceObjectConstants.Fields.PhotoUrl),
                new WhippetDataRowImportMapEntry(nameof(RecordTypeID), SalesforceObjectConstants.Fields.RecordTypeId),
                new WhippetDataRowImportMapEntry(nameof(ReportsToID), SalesforceObjectConstants.Fields.ReportsToId),
                new WhippetDataRowImportMapEntry(nameof(Salutation), SalesforceObjectConstants.Fields.Salutation),
                new WhippetDataRowImportMapEntry(nameof(Title), SalesforceObjectConstants.Fields.Title)
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
                SalesforceCleanStatus cleanStatus;

                AccountID = dataRow.Field<string>(map[nameof(AccountID)].Column);
                AssistantName = dataRow.Field<string>(map[nameof(AssistantName)].Column);
                AssistantPhone = dataRow.Field<string>(map[nameof(AssistantPhone)].Column);
                Birthdate = dataRow.Field<DateTime?>(map[nameof(Birthdate)].Column).ToInstant();
                CanAllowPortalSelfRegistration = dataRow.Field<bool>(map[nameof(CanAllowPortalSelfRegistration)].Column);

                if (!String.IsNullOrWhiteSpace(dataRow.Field<string>(map[nameof(CleanStatus)].Column)))
                {
                    if (Enum.TryParse<SalesforceCleanStatus>(dataRow.Field<string>(map[nameof(CleanStatus)].Column).Trim().Replace(' ', '_'), out cleanStatus))
                    {
                        CleanStatus = cleanStatus;
                    }
                    else
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
                Department = dataRow.Field<string>(map[nameof(Department)].Column);
                Description = dataRow.Field<string>(map[nameof(Description)].Column);
                DoNotCall = dataRow.Field<bool>(map[nameof(DoNotCall)].Column);
                Email = dataRow.Field<string>(map[nameof(Email)].Column);
                EmailBouncedDate = dataRow.Field<DateTime?>(map[nameof(EmailBouncedDate)].Column).ToInstant();
                EmailBouncedReason = dataRow.Field<string>(map[nameof(EmailBouncedReason)].Column);
                Fax = dataRow.Field<string>(map[nameof(Fax)].Column);
                FirstName = dataRow.Field<string>(map[nameof(FirstName)].Column);
                HasOptedOutOfEmail = dataRow.Field<bool>(map[nameof(HasOptedOutOfEmail)].Column);
                HasOptedOutOfFax = dataRow.Field<bool>(map[nameof(HasOptedOutOfFax)].Column);
                HomePhone = dataRow.Field<string>(map[nameof(HomePhone)].Column);
                IsDeleted = dataRow.Field<bool>(map[nameof(IsDeleted)].Column);
                IsEmailBounced = dataRow.Field<bool>(map[nameof(IsEmailBounced)].Column);
                IsPersonAccount = dataRow.Field<bool>(map[nameof(IsPersonAccount)].Column);
                Jigsaw = dataRow.Field<string>(map[nameof(Jigsaw)].Column);
                LastActivityDate = dataRow.Field<DateTime?>(map[nameof(LastActivityDate)].Column).ToInstant();
                LastStayInTouchRequestDate = dataRow.Field<DateTime?>(map[nameof(LastStayInTouchRequestDate)].Column).ToInstant();
                LastStayInTouchSaveDate = dataRow.Field<DateTime?>(map[nameof(LastStayInTouchSaveDate)].Column).ToInstant();
                LastName = dataRow.Field<string>(map[nameof(LastName)].Column);
                LastReferencedDate = dataRow.Field<DateTime?>(map[nameof(LastReferencedDate)].Column).ToInstant();
                LastViewedDate = dataRow.Field<DateTime?>(map[nameof(LastViewedDate)].Column).ToInstant();
                LeadSource = dataRow.Field<string>(map[nameof(LeadSource)].Column);
                MailingCity = dataRow.Field<string>(map[nameof(MailingCity)].Column);
                MailingState = dataRow.Field<string>(map[nameof(MailingState)].Column);
                MailingCountry = dataRow.Field<string>(map[nameof(MailingCountry)].Column);
                MailingPostalCode = dataRow.Field<string>(map[nameof(MailingPostalCode)].Column);
                MailingStateCode = dataRow.Field<string>(map[nameof(MailingStateCode)].Column);
                MailingCountryCode = dataRow.Field<string>(map[nameof(MailingCountryCode)].Column);
                MailingStreet = dataRow.Field<string>(map[nameof(MailingStreet)].Column);
                MasterRecordID = dataRow.Field<string>(map[nameof(MasterRecordID)].Column);
                MobilePhone = dataRow.Field<string>(map[nameof(MobilePhone)].Column);
                Name = dataRow.Field<string>(map[nameof(Name)].Column);
                OtherCity = dataRow.Field<string>(map[nameof(OtherCity)].Column);
                OtherCountry = dataRow.Field<string>(map[nameof(OtherCountry)].Column);
                OtherPostalCode = dataRow.Field<string>(map[nameof(OtherPostalCode)].Column);
                OtherState = dataRow.Field<string>(map[nameof(OtherState)].Column);
                OtherCountryCode = dataRow.Field<string>(map[nameof(OtherCountryCode)].Column);
                OtherStateCode = dataRow.Field<string>(map[nameof(OtherStateCode)].Column);
                OtherPhone = dataRow.Field<string>(map[nameof(OtherPhone)].Column);
                OtherStreet = dataRow.Field<string>(map[nameof(OtherStreet)].Column);
                OwnerID = dataRow.Field<string>(map[nameof(OwnerID)].Column);
                Phone = dataRow.Field<string>(map[nameof(Phone)].Column);
                PhotoUrl = dataRow.Field<string>(map[nameof(PhotoUrl)].Column);
                RecordTypeID = dataRow.Field<string>(map[nameof(RecordTypeID)].Column);
                ReportsToID = dataRow.Field<string>(map[nameof(ReportsToID)].Column);
                Salutation = dataRow.Field<string>(map[nameof(Salutation)].Column);
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

            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(AccountID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(AssistantName)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(AssistantPhone)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(Birthdate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(CanAllowPortalSelfRegistration)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CleanStatus)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ConnectionReceivedID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ConnectionSentID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Department)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Description)].Column, true, 16000));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(DoNotCall)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Email)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(EmailBouncedDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(EmailBouncedReason)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Fax)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(FirstName)].Column, true, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(HasOptedOutOfEmail)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(HasOptedOutOfFax)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(HomePhone)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsDeleted)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsEmailBounced)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsPersonAccount)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Jigsaw)].Column, true, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastActivityDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastStayInTouchRequestDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastStayInTouchSaveDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(LastName)].Column, false, 80));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastReferencedDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastViewedDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(LeadSource)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(MailingCity)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(MailingState)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(MailingCountry)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(MailingPostalCode)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(MailingStateCode)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(MailingCountryCode)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(MailingStreet)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(MasterRecordID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(MobilePhone)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Name)].Column, false, 121));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OtherCity)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OtherCountry)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OtherPostalCode)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OtherState)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OtherCountryCode)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OtherStateCode)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OtherStreet)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OwnerID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OtherPhone)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Phone)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PhotoUrl)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(RecordTypeID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ReportsToID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Salutation)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Title)].Column, true));

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
            return Equals(obj as ISalesforceContact);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ISalesforceContact obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="ISalesforceContact"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="ISalesforceContact"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ISalesforceContact a, ISalesforceContact b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals =
                    String.Equals(a.AccountID, b.AccountID, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.AssistantName, b.AssistantName, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.AssistantPhone, b.AssistantPhone, StringComparison.InvariantCultureIgnoreCase)
                        && a.Birthdate.GetValueOrDefault().Equals(b.Birthdate.GetValueOrDefault())
                        && a.CanAllowPortalSelfRegistration.Equals(b.CanAllowPortalSelfRegistration)
                        && a.CleanStatus.GetValueOrDefault().Equals(b.CleanStatus.GetValueOrDefault())
                        && a.ConnectionReceivedID.GetValueOrDefault().Equals(b.ConnectionReceivedID.GetValueOrDefault())
                        && a.ConnectionSentID.GetValueOrDefault().Equals(b.ConnectionSentID.GetValueOrDefault())
                        && String.Equals(a.Department, b.Department, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Description, b.Description, StringComparison.InvariantCultureIgnoreCase)
                        && a.DoNotCall.Equals(b.DoNotCall)
                        && String.Equals(a.Email, b.Email, StringComparison.InvariantCultureIgnoreCase)
                        && a.EmailBouncedDate.GetValueOrDefault().Equals(b.EmailBouncedDate.GetValueOrDefault())
                        && String.Equals(a.EmailBouncedReason, b.EmailBouncedReason, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Fax, b.Fax, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.FirstName, b.FirstName, StringComparison.InvariantCultureIgnoreCase)
                        && a.HasOptedOutOfEmail.Equals(b.HasOptedOutOfEmail)
                        && a.HasOptedOutOfFax.Equals(b.HasOptedOutOfFax)
                        && String.Equals(a.HomePhone, b.HomePhone, StringComparison.InvariantCultureIgnoreCase)
                        && a.IsDeleted.Equals(b.IsDeleted)
                        && a.IsEmailBounced.Equals(b.IsEmailBounced)
                        && a.IsPersonAccount.Equals(b.IsPersonAccount)
                        && String.Equals(a.Jigsaw, b.Jigsaw, StringComparison.InvariantCultureIgnoreCase)
                        && a.LastActivityDate.GetValueOrDefault().Equals(b.LastActivityDate.GetValueOrDefault())
                        && String.Equals(a.LastName, b.LastName, StringComparison.InvariantCultureIgnoreCase)
                        && a.LastReferencedDate.GetValueOrDefault().Equals(b.LastReferencedDate.GetValueOrDefault())
                        && a.LastViewedDate.GetValueOrDefault().Equals(b.LastViewedDate.GetValueOrDefault())
                        && String.Equals(a.LeadSource, b.LeadSource, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.MailingCity, b.MailingCity, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.MailingState, b.MailingState, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.MailingCountry, b.MailingCountry, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.MailingPostalCode, b.MailingPostalCode, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.MailingStateCode, b.MailingCountryCode, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.MailingStreet, b.MailingStreet, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.MasterRecordID, b.MasterRecordID, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.MobilePhone, b.MobilePhone, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.OtherCity, b.OtherCity, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.OtherState, b.OtherState, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.OtherCountry, b.OtherCountry, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.OtherPostalCode, b.OtherPostalCode, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.OtherStateCode, b.OtherStateCode, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.OtherStreet, b.OtherStreet, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.OtherPhone, b.OtherPhone, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.OwnerID, b.OwnerID, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Phone, b.Phone, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.PhotoUrl, b.PhotoUrl, StringComparison.InvariantCultureIgnoreCase)
                        && a.ReportsToID.GetValueOrDefault().Equals(b.ReportsToID.GetValueOrDefault())
                        && String.Equals(a.Salutation, b.Salutation, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Title, b.Title, StringComparison.InvariantCultureIgnoreCase);
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
        public int GetHashCode(ISalesforceContact obj)
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
            return Name;
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

