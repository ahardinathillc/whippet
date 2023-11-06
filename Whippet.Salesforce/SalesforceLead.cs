using System;
using System.Data;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;
using NodaTime;
using Dynamitey;
using Athi.Whippet.Extensions;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Extensions;
using Athi.Whippet.Salesforce.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;
using Athi.Whippet.Json;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents a prospect or lead. This class cannot be inherited.
    /// </summary>
    /// <remarks>See <a href="https://developer.salesforce.com/docs/atlas.en-us.object_reference.meta/object_reference/sforce_api_objects_lead.htm">Lead</a> for more information.</remarks>
    public sealed class SalesforceLead : IWhippetEntityDynamicImportMapper, IWhippetEntityExternalDataRowImportMapper, IWhippetEntity, ISalesforceObject, ISalesforceLead
    {
        private string _duns;
        private string _firstName;
        private string _jigsaw;
        private string _lastName;
        private string _middleName;
        private string _name;
        private string _suffix;

        private double? _latitude;
        private double? _longitude;

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
        /// This property is not supported for this object.
        /// </summary>
        /// <exception cref="NotImplementedException" />
        SalesforceReference? ISalesforceObject.ParentID
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// The ID of the sales rep designated to work the lead through their assigned cadence.
        /// </summary>
        public SalesforceReference ActionCadenceAssigneeId
        { get; set; }

        /// <summary>
        /// The ID of the lead’s assigned cadence.
        /// </summary>
        public SalesforceReference ActionCadenceId
        { get; set; }

        /// <summary>
        /// The ID of the related activity metric. 
        /// </summary>
        public SalesforceReference ActivityMetricId
        { get; set; }

        /// <summary>
        /// Annual revenue for the lead’s company.
        /// </summary>
        public decimal? AnnualRevenue
        { get; set; }

        /// <summary>
        /// City for the lead’s address.
        /// </summary>
        public string City
        { get; set; }

        /// <summary>
        /// Indicates the record’s clean status compared with Data.com.
        /// </summary>
        public SalesforceCleanStatus? CleanStatus
        { get; set; }

        /// <summary>
        /// The lead's company.
        /// </summary>
        public string Company
        { get; set; }

        /// <summary>
        /// The Data Universal Numbering System (D-U-N-S) number, which is a unique, nine-digit number assigned to every business location in the Dun & Bradstreet database that has a unique, separate, and distinct operation. Industries and companies use D-U-N-S numbers as a global standard for business identification and tracking. Maximum size is 9 characters.
        /// </summary>
        public string CompanyDunsNumber
        {
            get
            {
                return _duns;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(CompanyDunsNumber)].Column, true);
                _duns = value;
            }
        }

        /// <summary>
        /// ID of the PartnerNetworkConnection that shared this record with your organization. This field is available if you enabled Salesforce to Salesforce.
        /// </summary>
        public SalesforceReference ConnectionReceivedId
        { get; set; }

        /// <summary>
        /// ID of the PartnerNetworkConnection that you shared this record with. This field is available if you enabled Salesforce to Salesforce. 
        /// </summary>
        public SalesforceReference ConnectionSentId
        { get; set; }

        /// <summary>
        /// Object reference ID that points to the account into which the lead converted.
        /// </summary>
        public SalesforceReference ConvertedAccountId
        { get; set; }

        /// <summary>
        /// Object reference ID that points to the contact into which the lead converted.
        /// </summary>
        public SalesforceReference ConvertedContactId
        { get; set; }

        /// <summary>
        /// Date on which this lead was converted.
        /// </summary>
        public Instant? ConvertedDate
        { get; set; }

        /// <summary>
        /// Object reference ID that points to the opportunity into which the lead has been converted.
        /// </summary>
        public SalesforceReference ConvertedOpportunityId
        { get; set; }

        /// <summary>
        /// The lead’s country.
        /// </summary>
        public string Country
        { get; set; }

        /// <summary>
        /// The lead's description.
        /// </summary>
        public string Description
        { get; set; }

        /// <summary>
        /// The lead's e-mail address.
        /// </summary>
        public string Email
        { get; set; }

        /// <summary>
        /// If bounce management is activated and an email sent to the lead bounced, the date and time of the bounce.
        /// </summary>
        public Instant? EmailBouncedDate
        { get; set; }

        /// <summary>
        /// If bounce management is activated and an email sent to the lead bounced, the reason for the bounce.
        /// </summary>
        public string EmailBouncedReason
        { get; set; }

        /// <summary>
        /// Gets the external table name or <see langword="null"/> if the data source is not stored in a database. This property is read-only.
        /// </summary>
        string IWhippetEntityExternalDataRowImportMapper.ExternalTableName
        {
            get
            {
                return SalesforceObjectConstants.Objects.Lead;
            }
        }

        /// <summary>
        /// The lead’s fax number.
        /// </summary>
        public string Fax
        { get; set; }

        /// <summary>
        /// The date and time of the first call placed to the lead.
        /// </summary>
        public Instant? FirstCallDateTime
        { get; set; }

        /// <summary>
        /// The date and time of the first email sent to the lead.
        /// </summary>
        public Instant? FirstEmailDateTime
        { get; set; }

        /// <summary>
        /// The lead's first name up to 40 characters.
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
        /// Indicates whether the lead doesn’t want to receive email from Salesforce (<see langword="true"/>) or does (<see langword="false"/>). Label is <b>Email Opt Out</b>.
        /// </summary>
        public bool HasOptedOutOfEmail
        { get; set; }

        /// <summary>
        /// Indicates whether the lead doesn’t want to receive faxes from Salesforce (<see langword="true"/>) or does (<see langword="false"/>). Label is <b>Fax Opt Out</b>.
        /// </summary>
        public bool HasOptedOutOfFax
        { get; set; }

        /// <summary>
        /// ID of the data privacy record associated with this lead. 
        /// </summary>
        public SalesforceReference IndividualId
        { get; set; }

        /// <summary>
        /// Indicates whether the lead has been converted (<see langword="true"/>) or not (<see langword="false"/>). Label is <b>Converted</b>.
        /// </summary>
        public bool IsConverted
        { get; set; }

        /// <summary>
        /// Indicates whether the object has been moved to the Recycle Bin (<see langword="true"/>) or not (<see langword="false"/>). Label is <b>Deleted</b>.
        /// </summary>
        public bool IsDeleted
        { get; set; }

        /// <summary>
        /// If <see langword="true"/>, lead has been assigned, but not yet viewed. Label is <b>Unread By Owner</b>.
        /// </summary>
        public bool IsUnreadByOwner
        { get; set; }

        /// <summary>
        /// References the ID of a contact in Data.com. If a lead has a value in this field, it means that a contact was imported as a lead from Data.com. If the contact (converted to a lead) wasn’t imported from Data.com, the field value is <see langword="null"/>. Maximum size is 20 characters. 
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
        /// Value is the most recent of either: (1) Due date of the most recent event logged against the record, or (2) Due date of the most recently closed task associated with the record.
        /// </summary>
        public Instant? LastActivityDate
        { get; set; }

        /// <summary>
        /// Required. Last name of the lead up to 80 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(LastName)].Column, false);
                _lastName = value;
            }
        }

        /// <summary>
        /// The timestamp when the current user last accessed this record, a record related to this record, or a list view.
        /// </summary>
        public Instant? LastReferencedDate
        { get; set; }

        /// <summary>
        /// The timestamp when the current user last viewed this record or list view. If this value is <see langword="null"/>, the user might have only accessed this record or list view (<see cref="LastReferencedDate"/>) but not viewed it.
        /// </summary>
        public Instant? LastViewedDate
        { get; set; }

        /// <summary>
        /// Used with <see cref="Longitude"/> to specify the precise geolocation of an address. Acceptable values are numbers between –90 and 90 up to 15 decimal places. 
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public double? Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                if (value.HasValue && (value.Value > 90 || value < -90))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                else
                {
                    _latitude = value;
                }
            }
        }

        /// <summary>
        /// Used with <see cref="Latitude"/> to specify the precise geolocation of an address. Acceptable values are numbers between –180 and 180 up to 15 decimal places.
        /// </summary>
        public double? Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                if (value.HasValue && (value.Value > 180 || value < -180))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                else
                {
                    _longitude = value;
                }
            }
        }

        /// <summary>
        /// If this record was deleted as the result of a merge, this field contains the ID of the record that was kept. If this record was deleted for any other reason, or hasn’t been deleted, the value is <see langword="null"/>.
        /// </summary>
        public SalesforceReference MasterRecordId
        { get; set; }

        /// <summary>
        /// The lead's middle name up to 40 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string MiddleName
        {
            get
            {
                return _middleName;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(MiddleName)].Column, true);
                _middleName = value;
            }
        }

        /// <summary>
        /// The lead's mobile phone number.
        /// </summary>
        public string MobilePhone
        { get; set; }

        /// <summary>
        /// Concatenation of <see cref="FirstName"/>, <see cref="MiddleName"/>, <see cref="LastName"/>, and <see cref="Suffix"/> up to 203 characters, including whitespaces.
        /// </summary>
        public string Name
        {
            get
            {
                return (String.IsNullOrWhiteSpace(_name) && !(String.IsNullOrWhiteSpace(FirstName) || String.IsNullOrWhiteSpace(LastName))) ? (FirstName + " " + LastName).Trim() : _name;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(Name)].Column, false);
                _name = value;
            }
        }

        /// <summary>
        /// Number of employees at the lead’s company. Label is <b>Employees</b>.
        /// </summary>
        public int? NumberOfEmployees
        { get; set; }

        /// <summary>
        /// ID of the lead's owner.
        /// </summary>
        public SalesforceReference? OwnerID
        { get; set; }

        /// <summary>
        /// ID of the partner account for the partner user that owns this lead. Available if Partner Relationship Management is enabled or if digital experiences is enabled and you have partner portal licenses.
        /// </summary>
        public SalesforceReference PartnerAccountId
        { get; set; }

        /// <summary>
        /// The lead’s phone number.
        /// </summary>
        public string Phone
        { get; set; }

        /// <summary>
        /// Path to be combined with the URL of a Salesforce instance to generate a URL to request the social network profile image associated with the lead. Generated URL returns an HTTP redirect (code 302) to the social network profile image for the lead. Empty if Social Accounts and Contacts isn't enabled or if Social Accounts and Contacts has been disabled for the requesting user.
        /// </summary>
        public string PhotoUrl
        { get; set; }

        /// <summary>
        /// Postal code for the address of the lead. Label is <b>Zip/Postal Code</b>.
        /// </summary>
        public string PostalCode
        { get; set; }

        /// <summary>
        /// ID of the record type assigned to this object.
        /// </summary>
        public SalesforceReference? RecordTypeID
        { get; set; }

        /// <summary>
        /// The ID of the intelligent field record that contains lead score.
        /// </summary>
        public SalesforceReference ScoreIntelligenceId
        { get; set; }

        /// <summary>
        /// State for the address of the lead.
        /// </summary>
        public string State
        { get; set; }

        /// <summary>
        /// Street number and name for the address of the lead.
        /// </summary>
        public string Street
        { get; set; }

        /// <summary>
        /// The lead’s name suffix up to 40 characters. 
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string Suffix
        {
            get
            {
                return _suffix;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(Suffix)].Column, true);
                _suffix = value;
            }
        }

        /// <summary>
        /// Title for the lead, such as CFO or CEO.
        /// </summary>
        public string Title
        { get; set; }

        /// <summary>
        /// Website for the lead.
        /// </summary>
        public string Website
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceLead"/> class with no arguments.
        /// </summary>
        public SalesforceLead()
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
        { }

        /// <summary>
        /// Creates a <see cref="WhippetDataRowImportMap"/> object that contains a mapping for the current entity.
        /// </summary>
        /// <returns><see cref="WhippetDataRowImportMap"/> object.</returns>
        public WhippetDataRowImportMap CreateImportMap()
        {
            return new WhippetDataRowImportMap(new[] {
                new WhippetDataRowImportMapEntry(nameof(ActionCadenceAssigneeId), SalesforceObjectConstants.Fields.ActionCadenceAssigneeId),
                new WhippetDataRowImportMapEntry(nameof(ActionCadenceId), SalesforceObjectConstants.Fields.ActionCadenceId),
                new WhippetDataRowImportMapEntry(nameof(ActivityMetricId), SalesforceObjectConstants.Fields.ActivityMetricId),
                new WhippetDataRowImportMapEntry(nameof(AnnualRevenue), SalesforceObjectConstants.Fields.AnnualRevenue),
                new WhippetDataRowImportMapEntry(nameof(City), SalesforceObjectConstants.Fields.City),
                new WhippetDataRowImportMapEntry(nameof(CleanStatus), SalesforceObjectConstants.Fields.CleanStatus),
                new WhippetDataRowImportMapEntry(nameof(Company), SalesforceObjectConstants.Fields.Company),
                new WhippetDataRowImportMapEntry(nameof(CompanyDunsNumber), SalesforceObjectConstants.Fields.CompanyDunsNumber),
                new WhippetDataRowImportMapEntry(nameof(ConnectionReceivedId), SalesforceObjectConstants.Fields.ConnectionReceivedId),
                new WhippetDataRowImportMapEntry(nameof(ConnectionSentId), SalesforceObjectConstants.Fields.ConnectionSentId),
                new WhippetDataRowImportMapEntry(nameof(ConvertedAccountId), SalesforceObjectConstants.Fields.ConvertedAccountId),
                new WhippetDataRowImportMapEntry(nameof(ConvertedContactId), SalesforceObjectConstants.Fields.ConvertedContactId),
                new WhippetDataRowImportMapEntry(nameof(ConvertedDate), SalesforceObjectConstants.Fields.ConvertedDate),
                new WhippetDataRowImportMapEntry(nameof(ConvertedOpportunityId), SalesforceObjectConstants.Fields.ConvertedOpportunityId),
                new WhippetDataRowImportMapEntry(nameof(Country), SalesforceObjectConstants.Fields.Country),
                new WhippetDataRowImportMapEntry(nameof(Description), SalesforceObjectConstants.Fields.Description),
                new WhippetDataRowImportMapEntry(nameof(Email), SalesforceObjectConstants.Fields.Email),
                new WhippetDataRowImportMapEntry(nameof(EmailBouncedDate), SalesforceObjectConstants.Fields.EmailBouncedDate),
                new WhippetDataRowImportMapEntry(nameof(EmailBouncedReason), SalesforceObjectConstants.Fields.EmailBouncedReason),
                new WhippetDataRowImportMapEntry(nameof(Fax), SalesforceObjectConstants.Fields.Fax),
                new WhippetDataRowImportMapEntry(nameof(FirstCallDateTime), SalesforceObjectConstants.Fields.FirstCallDateTime),
                new WhippetDataRowImportMapEntry(nameof(FirstEmailDateTime), SalesforceObjectConstants.Fields.FirstEmailDateTime),
                new WhippetDataRowImportMapEntry(nameof(FirstName), SalesforceObjectConstants.Fields.FirstName),
                new WhippetDataRowImportMapEntry(nameof(HasOptedOutOfEmail), SalesforceObjectConstants.Fields.HasOptedOutOfEmail),
                new WhippetDataRowImportMapEntry(nameof(HasOptedOutOfFax), SalesforceObjectConstants.Fields.HasOptedOutOfFax),
                new WhippetDataRowImportMapEntry(nameof(IndividualId), SalesforceObjectConstants.Fields.IndividualId),
                new WhippetDataRowImportMapEntry(nameof(IsConverted), SalesforceObjectConstants.Fields.IsConverted),
                new WhippetDataRowImportMapEntry(nameof(IsDeleted), SalesforceObjectConstants.Fields.IsDeleted),
                new WhippetDataRowImportMapEntry(nameof(IsUnreadByOwner), SalesforceObjectConstants.Fields.IsUnreadByOwner),
                new WhippetDataRowImportMapEntry(nameof(Jigsaw), SalesforceObjectConstants.Fields.Jigsaw),
                new WhippetDataRowImportMapEntry(nameof(LastActivityDate), SalesforceObjectConstants.Fields.LastActivityDate),
                new WhippetDataRowImportMapEntry(nameof(LastName), SalesforceObjectConstants.Fields.LastName),
                new WhippetDataRowImportMapEntry(nameof(LastReferencedDate), SalesforceObjectConstants.Fields.LastReferencedDate),
                new WhippetDataRowImportMapEntry(nameof(LastViewedDate), SalesforceObjectConstants.Fields.LastViewedDate),
                new WhippetDataRowImportMapEntry(nameof(Latitude), SalesforceObjectConstants.Fields.Latitude),
                new WhippetDataRowImportMapEntry(nameof(Longitude), SalesforceObjectConstants.Fields.Longitude),
                new WhippetDataRowImportMapEntry(nameof(MasterRecordId), SalesforceObjectConstants.Fields.MasterRecordId),
                new WhippetDataRowImportMapEntry(nameof(MiddleName), SalesforceObjectConstants.Fields.MiddleName),
                new WhippetDataRowImportMapEntry(nameof(MobilePhone), SalesforceObjectConstants.Fields.MobilePhone),
                new WhippetDataRowImportMapEntry(nameof(Name), SalesforceObjectConstants.Fields.Name),
                new WhippetDataRowImportMapEntry(nameof(NumberOfEmployees), SalesforceObjectConstants.Fields.NumberOfEmployees),
                new WhippetDataRowImportMapEntry(nameof(OwnerID), SalesforceObjectConstants.Fields.OwnerId),
                new WhippetDataRowImportMapEntry(nameof(PartnerAccountId), SalesforceObjectConstants.Fields.PartnerAccountId),
                new WhippetDataRowImportMapEntry(nameof(Phone), SalesforceObjectConstants.Fields.Phone),
                new WhippetDataRowImportMapEntry(nameof(PhotoUrl), SalesforceObjectConstants.Fields.PhotoUrl),
                new WhippetDataRowImportMapEntry(nameof(PostalCode), SalesforceObjectConstants.Fields.PostalCode),
                new WhippetDataRowImportMapEntry(nameof(RecordTypeID), SalesforceObjectConstants.Fields.RecordTypeId),
                new WhippetDataRowImportMapEntry(nameof(ScoreIntelligenceId), SalesforceObjectConstants.Fields.ScoreIntelligenceId),
                new WhippetDataRowImportMapEntry(nameof(State), SalesforceObjectConstants.Fields.State),
                new WhippetDataRowImportMapEntry(nameof(Street), SalesforceObjectConstants.Fields.Street),
                new WhippetDataRowImportMapEntry(nameof(Suffix), SalesforceObjectConstants.Fields.Suffix),
                new WhippetDataRowImportMapEntry(nameof(Title), SalesforceObjectConstants.Fields.Title),
                new WhippetDataRowImportMapEntry(nameof(Website), SalesforceObjectConstants.Fields.Website)
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

                ActionCadenceAssigneeId = dataRow.Field<string>(map[nameof(ActionCadenceAssigneeId)].Column);
                ActionCadenceId = dataRow.Field<string>(map[nameof(ActionCadenceId)].Column);
                ActivityMetricId = dataRow.Field<string>(map[nameof(AnnualRevenue)].Column);
                AnnualRevenue = dataRow.Field<decimal?>(map[nameof(AnnualRevenue)].Column);
                City = dataRow.Field<string>(map[nameof(City)].Column);

                if (!String.IsNullOrWhiteSpace(dataRow.Field<string>(map[nameof(CleanStatus)].Column)))
                {
                    CleanStatus = (SalesforceCleanStatus)(Enum.Parse(typeof(SalesforceCleanStatus), dataRow.Field<string>(map[nameof(CleanStatus)].Column)));
                }
                else
                {
                    CleanStatus = null;
                }
            
                Company = dataRow.Field<string>(map[nameof(Company)].Column);
                CompanyDunsNumber = dataRow.Field<string>(map[nameof(CompanyDunsNumber)].Column);
                ConnectionReceivedId = dataRow.Field<string>(map[nameof(ConnectionReceivedId)].Column);
                ConnectionSentId = dataRow.Field<string>(map[nameof(ConnectionSentId)].Column);
                ConvertedAccountId = dataRow.Field<string>(map[nameof(ConvertedAccountId)].Column);
                ConvertedContactId = dataRow.Field<string>(map[nameof(ConvertedContactId)].Column);

                if (dataRow.Field<DateTime?>(map[nameof(ConvertedDate)].Column).HasValue)
                {
                    ConvertedDate = dataRow.Field<DateTime>(map[nameof(ConvertedDate)].Column).ToInstant();
                }
                else
                {
                    ConvertedDate = null;
                }

                ConvertedOpportunityId = dataRow.Field<string>(map[nameof(ConvertedOpportunityId)].Column);
                Country = dataRow.Field<string>(map[nameof(Country)].Column);
                Description = dataRow.Field<string>(map[nameof(Description)].Column);
                Email = dataRow.Field<string>(map[nameof(Email)].Column);

                if (dataRow.Field<DateTime?>(map[nameof(EmailBouncedDate)].Column).HasValue)
                {
                    EmailBouncedDate = dataRow.Field<DateTime>(map[nameof(EmailBouncedDate)].Column).ToInstant();
                }
                else
                {
                    EmailBouncedDate = null;
                }

                EmailBouncedReason = dataRow.Field<string>(map[nameof(EmailBouncedReason)].Column);
                Fax = dataRow.Field<string>(map[nameof(Fax)].Column);

                if (dataRow.Field<DateTime?>(map[nameof(FirstCallDateTime)].Column).HasValue)
                {
                    FirstCallDateTime = dataRow.Field<DateTime>(map[nameof(FirstCallDateTime)].Column).ToInstant();
                }
                else
                {
                    FirstCallDateTime = null;
                }

                FirstName = dataRow.Field<string>(map[nameof(FirstName)].Column);
                HasOptedOutOfEmail = dataRow.Field<bool>(map[nameof(HasOptedOutOfEmail)].Column);
                HasOptedOutOfFax = dataRow.Field<bool>(map[nameof(HasOptedOutOfFax)].Column);
                IndividualId = dataRow.Field<string>(map[nameof(IndividualId)].Column);
                IsConverted = dataRow.Field<bool>(map[nameof(IsConverted)].Column);
                IsDeleted = dataRow.Field<bool>(map[nameof(IsDeleted)].Column);
                IsUnreadByOwner = dataRow.Field<bool>(map[nameof(IsUnreadByOwner)].Column);
                Jigsaw = dataRow.Field<string>(map[nameof(Jigsaw)].Column);

                if (dataRow.Field<DateTime?>(map[nameof(LastActivityDate)].Column).HasValue)
                {
                    LastActivityDate = dataRow.Field<DateTime>(map[nameof(LastActivityDate)].Column).ToInstant();
                }
                else
                {
                    LastActivityDate = null;
                }

                LastName = dataRow.Field<string>(map[nameof(LastName)].Column);

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

                Latitude = dataRow.Field<double?>(map[nameof(Latitude)].Column);
                Longitude = dataRow.Field<double?>(map[nameof(Longitude)].Column);
                MasterRecordId = dataRow.Field<string>(map[nameof(MasterRecordId)].Column);
                MiddleName = dataRow.Field<string>(map[nameof(MiddleName)].Column);
                MobilePhone = dataRow.Field<string>(map[nameof(MobilePhone)].Column);
                Name = dataRow.Field<string>(map[nameof(Name)].Column);
                NumberOfEmployees = dataRow.Field<int?>(map[nameof(NumberOfEmployees)].Column);
                OwnerID = dataRow.Field<string>(map[nameof(OwnerID)].Column);
                PartnerAccountId = dataRow.Field<string>(map[nameof(PartnerAccountId)].Column);
                Phone = dataRow.Field<string>(map[nameof(Phone)].Column);
                PhotoUrl = dataRow.Field<string>(map[nameof(PhotoUrl)].Column);
                PostalCode = dataRow.Field<string>(map[nameof(PostalCode)].Column);
                RecordTypeID = dataRow.Field<string>(map[nameof(RecordTypeID)].Column);
                ScoreIntelligenceId = dataRow.Field<string>(map[nameof(ScoreIntelligenceId)].Column);
                State = dataRow.Field<string>(map[nameof(State)].Column);
                Street = dataRow.Field<string>(map[nameof(Street)].Column);
                Suffix = dataRow.Field<string>(map[nameof(Suffix)].Column);
                Title = dataRow.Field<string>(map[nameof(Title)].Column);
                Website = dataRow.Field<string>(map[nameof(Website)].Column);
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

            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ActionCadenceAssigneeId)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ActionCadenceId)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ActivityMetricId)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(AnnualRevenue)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(City)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(CleanStatus)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Company)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CompanyDunsNumber)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ConnectionReceivedId)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ConnectionSentId)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ConvertedAccountId)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ConvertedContactId)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(ConvertedDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ConvertedOpportunityId)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Country)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Description)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Email)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(EmailBouncedDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(EmailBouncedReason)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Fax)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(FirstCallDateTime)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(FirstEmailDateTime)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(FirstName)].Column, true, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(HasOptedOutOfEmail)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(HasOptedOutOfFax)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(IndividualId)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsConverted)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsDeleted)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsUnreadByOwner)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Jigsaw)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastActivityDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(LastName)].Column, false, 80));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastReferencedDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastViewedDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<double>(map[nameof(Latitude)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<double>(map[nameof(Longitude)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(MasterRecordId)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(MiddleName)].Column, true, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(MobilePhone)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Name)].Column, false, 203));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(NumberOfEmployees)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OwnerID)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PartnerAccountId)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Phone)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PhotoUrl)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PostalCode)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(RecordTypeID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ScoreIntelligenceId)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(State)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Street)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Suffix)].Column, true, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Title)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Website)].Column, true));

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
            return Equals(obj as ISalesforceLead);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ISalesforceLead obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="ISalesforceLead"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="ISalesforceLead"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ISalesforceLead a, ISalesforceLead b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals = String.Equals(a.ActionCadenceAssigneeId, b.ActionCadenceAssigneeId, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.ActionCadenceId, b.ActionCadenceId, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.ActivityMetricId, b.ActivityMetricId, StringComparison.InvariantCultureIgnoreCase)
                    && a.AnnualRevenue.GetValueOrDefault().Equals(b.AnnualRevenue.GetValueOrDefault())
                    && String.Equals(a.City, b.City, StringComparison.InvariantCultureIgnoreCase)
                    && a.CleanStatus.GetValueOrDefault().Equals(b.CleanStatus.GetValueOrDefault())
                    && String.Equals(a.Company, b.Company, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.CompanyDunsNumber, b.CompanyDunsNumber, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.ConnectionReceivedId, b.ConnectionReceivedId, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.ConnectionSentId, b.ConnectionSentId, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.ConvertedAccountId, b.ConvertedAccountId, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.ConvertedContactId, b.ConvertedContactId, StringComparison.InvariantCultureIgnoreCase)
                    && a.ConvertedDate.GetValueOrDefault().Equals(b.ConvertedDate.GetValueOrDefault())
                    && String.Equals(a.ConvertedOpportunityId, b.ConvertedOpportunityId, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Country, b.Country, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Description, b.Description, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Email, b.Email, StringComparison.InvariantCultureIgnoreCase)
                    && a.EmailBouncedDate.GetValueOrDefault().Equals(b.EmailBouncedDate.GetValueOrDefault())
                    && String.Equals(a.EmailBouncedReason, b.EmailBouncedReason, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Fax, b.Fax, StringComparison.InvariantCultureIgnoreCase)
                    && a.FirstCallDateTime.GetValueOrDefault().Equals(b.FirstCallDateTime.GetValueOrDefault())
                    && a.FirstEmailDateTime.GetValueOrDefault().Equals(b.FirstEmailDateTime.GetValueOrDefault())
                    && String.Equals(a.FirstName, b.FirstName, StringComparison.InvariantCultureIgnoreCase)
                    && a.HasOptedOutOfEmail.Equals(b.HasOptedOutOfEmail)
                    && a.HasOptedOutOfFax.Equals(b.HasOptedOutOfFax)
                    && String.Equals(a.IndividualId, b.IndividualId, StringComparison.InvariantCultureIgnoreCase)
                    && a.IsConverted.Equals(b.IsConverted)
                    && a.IsDeleted.Equals(b.IsDeleted)
                    && a.IsUnreadByOwner.Equals(b.IsUnreadByOwner)
                    && String.Equals(a.Jigsaw, b.Jigsaw, StringComparison.InvariantCultureIgnoreCase)
                    && a.LastActivityDate.GetValueOrDefault().Equals(b.LastActivityDate.GetValueOrDefault())
                    && String.Equals(a.LastName, b.LastName, StringComparison.InvariantCultureIgnoreCase)
                    && a.LastReferencedDate.GetValueOrDefault().Equals(b.LastReferencedDate.GetValueOrDefault())
                    && a.LastViewedDate.GetValueOrDefault().Equals(b.LastViewedDate.GetValueOrDefault())
                    && a.Latitude.GetValueOrDefault().Equals(b.Latitude.GetValueOrDefault())
                    && a.Longitude.GetValueOrDefault().Equals(b.Longitude.GetValueOrDefault())
                    && String.Equals(a.MasterRecordId, b.MasterRecordId, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.MiddleName, b.MiddleName, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.MobilePhone, b.MobilePhone, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase)
                    && a.NumberOfEmployees.GetValueOrDefault().Equals(b.NumberOfEmployees.GetValueOrDefault())
                    && String.Equals(a.ObjectID, b.ObjectID, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.OwnerID, b.OwnerID, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.ParentID, b.ParentID, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.PartnerAccountId, b.PartnerAccountId, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Phone, b.Phone, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.PhotoUrl, b.PhotoUrl, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.PostalCode, b.PostalCode, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.RecordTypeID, b.RecordTypeID, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.ScoreIntelligenceId, b.ScoreIntelligenceId, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.State, b.State, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Street, b.Street, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Suffix, b.Suffix, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Title, b.Title, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Website, b.Website, StringComparison.InvariantCultureIgnoreCase);
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
        public int GetHashCode(ISalesforceLead obj)
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
            return String.IsNullOrWhiteSpace(Name) ? base.ToString() : Name;
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

