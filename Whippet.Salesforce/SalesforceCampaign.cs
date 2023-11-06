using System;
using System.Data;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Text;
using System.Diagnostics;
using NodaTime;
using Athi.Whippet.Extensions;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Extensions;
using Athi.Whippet.Salesforce.Extensions;
using Dynamitey;
using Newtonsoft.Json.Linq;
using Athi.Whippet.Json.Newtonsoft.Extensions;
using Athi.Whippet.Json;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents and tracks a marketing campaign, such as a direct mail promotion, webinar, or trade show. This class cannot be inherited.
    /// </summary>
    /// <remarks>See <a href="https://developer.salesforce.com/docs/atlas.en-us.192.0.object_reference.meta/object_reference/sforce_api_objects_campaign.htm">Campaign</a> for more information.</remarks>
    public sealed class SalesforceCampaign : IWhippetEntityDynamicImportMapper, IWhippetEntityExternalDataRowImportMapper, IWhippetEntity, ISalesforceObject, ISalesforceCampaign
    {
        private WhippetDataRowImportMap _internalMap;

        private string _description;
        private string _name;
        private string _ownerId;
        private string _parentCampaign;
        private string _parentId;
        private string _recordTypeId;
        private string _status;
        private string _type;

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
        /// Unique ID of the Salesforce object.
        /// </summary>
        public SalesforceReference? ObjectID
        { get; set; }

        /// <summary>
        /// Gets or sets the unique ID of the entity.
        /// </summary>
        Guid IWhippetEntity.ID
        { get; set; }

        /// <summary>
        /// Amount of money spent to run the campaign.
        /// </summary>
        public decimal? ActualCost
        { get; set; }

        /// <summary>
        /// Amount of money in all opportunities associated with the campaign, including closed/won opportunities. Label is <b>Total Value Opportunities</b>.
        /// </summary>
        public decimal AmountAllOpportunities
        { get; set; }

        /// <summary>
        /// Amount of money in closed or won opportunities associated with the campaign. Label is <b>Total Value Won Opportunities</b>.
        /// </summary>
        public decimal AmountWonOpportunities
        { get; set; }

        /// <summary>
        /// Amount of money budgeted for the campaign.
        /// </summary>
        public decimal BudgetedCost
        { get; set; }

        /// <summary>
        /// The record type ID for CampaignMember records associated with the campaign.
        /// </summary>
        public string CampaignMemberRecordTypeID
        { get; set; }

        /// <summary>
        /// Available only for organizations with the multicurrency feature enabled. Contains the ISO code for any currency allowed by the organization.
        /// </summary>
        public string CurrencyISOCode
        { get; set; }

        /// <summary>
        /// Description of the campaign. Limit: 32 KB. Only the first 255 characters display in reports.
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
        /// Ending date for the campaign.Responses received after this date are still counted.
        /// </summary>
        public Instant? EndDate
        { get; set; }

        /// <summary>
        /// Percentage of responses you expect to receive for the campaign.
        /// </summary>
        public double? ExpectedResponse
        { get; set; }

        /// <summary>
        /// Amount of money you expect to generate from the campaign.
        /// </summary>
        public decimal? ExpectedRevenue
        { get; set; }

        /// <summary>
        /// Calculated field for the total amount of money spent to run the campaigns in a campaign hierarchy. Label is <b>Total Actual Cost in Hierarchy</b>.
        /// </summary>
        public decimal? HierarchyActualCost
        { get; set; }

        /// <summary>
        /// Calculated field for the total amount of money budgeted for the campaigns in a campaign hierarchy. Label is <b>Total Budgeted Cost in Hierarchy</b>.
        /// </summary>
        public decimal? HierarchyBudgetedCost
        { get; set; }

        /// <summary>
        /// Calculated field for the total amount of money you expect to generate from the campaigns in a campaign hierarchy. Label is <b>Total Expected Revenue in Hierarchy</b>.
        /// </summary>
        public decimal? HierarchyExpectedRevenue
        { get; set; }

        /// <summary>
        /// Calculated field for the total number of individuals targeted by the campaigns in a campaign hierarchy. For example, the number of email messagess sent. Label is <b>Total Num Sent in Hierarchy</b>.
        /// </summary>
        public int HierarchyNumberSent
        { get; set; }

        /// <summary>
        /// Indicates whether this campaign is active (true) or not (false). Default value is <see langword="false"/>. Label is <b>Active</b>.
        /// </summary>
        public bool IsActive
        { get; set; }

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
        /// Required. Name of the campaign. Limit: is 80 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(Name)].Column, true);
                _name = value;
            }
        }

        /// <summary>
        /// Number of contacts associated with the campaign. Label is <b>Total Contacts</b>.
        /// </summary>
        public int NumberOfContacts
        { get; set; }

        /// <summary>
        /// Number of leads that were converted to an account and contact due to the marketing efforts in the campaign. Label is <b>Converted Leads</b>.
        /// </summary>
        public int NumberOfConvertedLeads
        { get; set; }

        /// <summary>
        /// Number of leads associated with the campaign. Label is <b>Total Leads</b>.
        /// </summary>
        public int NumberOfLeads
        { get; set; }

        /// <summary>
        /// Number of opportunities associated with the campaign. Label is <b>Num Total Opportunities</b>.
        /// </summary>
        public int NumberOfOpportunities
        { get; set; }

        /// <summary>
        /// Number of contacts and unconverted leads with a Member Status equivalent to “Responded” for the campaign. Label is <b>Total Responses</b>.
        /// </summary>
        public int NumberOfResponses
        { get; set; }

        /// <summary>
        /// Number of closed or won opportunities associated with the campaign. Label is <b>Num Won Opportunities</b>.
        /// </summary>
        public int NumberOfWonOpportunities
        { get; set; }

        /// <summary>
        /// Number of individuals targeted by the campaign. For example, the number of emails sent. Label is <b>Num Sent</b>.
        /// </summary>
        public double? NumberSent
        { get; set; }

        /// <summary>
        /// ID of the user who owns this campaign. Default value is the user logging in to the API to perform the create.
        /// </summary>
        public SalesforceReference? OwnerID
        { get; set; }

        /// <summary>
        /// The campaign above the selected campaign in the campaign hierarchy.
        /// </summary>
        public string ParentCampaign
        { get; set; }

        /// <summary>
        /// ID of the parent Campaign record, if any.
        /// </summary>
        public SalesforceReference? ParentID
        { get; set; }

        /// <summary>
        /// ID of the record type assigned to this object.
        /// </summary>
        public SalesforceReference? RecordTypeID
        { get; set; }

        /// <summary>
        /// Starting date for the campaign.
        /// </summary>
        public Instant? StartDate
        { get; set; }

        /// <summary>
        /// Status of the campaign, for example, Planned, In Progress. Limit: 40 characters.
        /// </summary>
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(Status)].Column, true);
                _status = value;
            }
        }

        /// <summary>
        /// Calculated field for total amount of all opportunities associated with the campaign hierarchy, including closed/won opportunities. Label is <b>Total Value Opportunities in Hierarchy</b>.
        /// </summary>
        public decimal TotalAmountAllOpportunities
        { get; set; }

        /// <summary>
        /// Calculated field for amount of all closed/won opportunities associated with the campaign hierarchy. Label is <b>Total Value Won Opportunities in Hierarchy</b>.
        /// </summary>
        public decimal TotalAmountAllWonOpportunities
        { get; set; }

        /// <summary>
        /// Calculated field for number of contacts associated with the campaign hierarchy. Label is <b>Total Contacts in Hierarchy</b>.
        /// </summary>
        public int TotalNumberOfContacts
        { get; set; }

        /// <summary>
        /// Calculated field for the total number of leads associated with the campaign hierarchy that were converted into accounts, contacts, and opportunities. Label is <b>Total Converted Leads in Hierarchy</b>.
        /// </summary>
        public int TotalNumberOfConvertedLeads
        { get; set; }

        /// <summary>
        /// Calculated field for total number of leads associated with the campaign hierarchy. This number also includes converted leads. Label is <b>Total Leads in Hierarchy</b>.
        /// </summary>
        public int TotalNumberOfLeads
        { get; set; }

        /// <summary>
        /// Calculated field for the total number of opportunities associated with the campaign hierarchy. Label is <b>Total Opportunities in Hierarchy</b>.
        /// </summary>
        public int TotalNumberOfOpportunities
        { get; set; }

        /// <summary>
        /// Calculated field for number of contacts and unconverted leads that have a Member Status equivalent to “Responded” for the campaign hierarchy. Label is <b>Total Responses in Hierarchy</b>.
        /// </summary>
        public int TotalNumberOfResponses
        { get; set; }

        /// <summary>
        /// Calculated field for the total number of won opportunities associated with the campaign hierarchy. Label is <b>Total Won Opportunities in Hierarchy</b>.
        /// </summary>
        public int TotalNumberOfWonOpportunities
        { get; set; }

        /// <summary>
        /// Type of campaign, for example, Direct Mail or Referral Program. Limit: 40 characters.
        /// </summary>
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                this.CheckLengthRequirement(value, ImportMap[nameof(Type)].Column, true);
                _type = value;
            }
        }

        /// <summary>
        /// Gets the external table name or <see langword="null"/> if the data source is not stored in a database. This property is read-only.
        /// </summary>
        string IWhippetEntityExternalDataRowImportMapper.ExternalTableName
        {
            get
            {
                return SalesforceObjectConstants.Objects.Campaign;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceCampaign"/> class with no arguments.
        /// </summary>
        public SalesforceCampaign()
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
                new WhippetDataRowImportMapEntry(nameof(ActualCost), SalesforceObjectConstants.Fields.ActualCost),
                new WhippetDataRowImportMapEntry(nameof(AmountAllOpportunities), SalesforceObjectConstants.Fields.AmountAllOpportunities),
                new WhippetDataRowImportMapEntry(nameof(AmountWonOpportunities), SalesforceObjectConstants.Fields.AmountWonOpportunities),
                new WhippetDataRowImportMapEntry(nameof(BudgetedCost), SalesforceObjectConstants.Fields.BudgetedCost),
                new WhippetDataRowImportMapEntry(nameof(CampaignMemberRecordTypeID), SalesforceObjectConstants.Fields.CampaignMemberRecordTypeId),
                new WhippetDataRowImportMapEntry(nameof(CurrencyISOCode), SalesforceObjectConstants.Fields.CurrencyIsoCode),
                new WhippetDataRowImportMapEntry(nameof(Description), SalesforceObjectConstants.Fields.Description),
                new WhippetDataRowImportMapEntry(nameof(EndDate), SalesforceObjectConstants.Fields.EndDate),
                new WhippetDataRowImportMapEntry(nameof(ExpectedResponse), SalesforceObjectConstants.Fields.ExpectedResponse),
                new WhippetDataRowImportMapEntry(nameof(ExpectedRevenue), SalesforceObjectConstants.Fields.ExpectedRevenue),
                new WhippetDataRowImportMapEntry(nameof(HierarchyActualCost), SalesforceObjectConstants.Fields.HierarchyActualCost),
                new WhippetDataRowImportMapEntry(nameof(HierarchyBudgetedCost), SalesforceObjectConstants.Fields.HierarchyBudgetedCost),
                new WhippetDataRowImportMapEntry(nameof(HierarchyExpectedRevenue), SalesforceObjectConstants.Fields.HierarchyExpectedRevenue),
                new WhippetDataRowImportMapEntry(nameof(HierarchyNumberSent), SalesforceObjectConstants.Fields.HierarchyNumberSent),
                new WhippetDataRowImportMapEntry(nameof(IsActive), SalesforceObjectConstants.Fields.IsActive),
                new WhippetDataRowImportMapEntry(nameof(LastActivityDate), SalesforceObjectConstants.Fields.LastActivityDate),
                new WhippetDataRowImportMapEntry(nameof(LastReferencedDate), SalesforceObjectConstants.Fields.LastReferencedDate),
                new WhippetDataRowImportMapEntry(nameof(LastViewedDate), SalesforceObjectConstants.Fields.LastViewedDate),
                new WhippetDataRowImportMapEntry(nameof(Name), SalesforceObjectConstants.Fields.Name),
                new WhippetDataRowImportMapEntry(nameof(NumberOfContacts), SalesforceObjectConstants.Fields.NumberOfContacts),
                new WhippetDataRowImportMapEntry(nameof(NumberOfConvertedLeads), SalesforceObjectConstants.Fields.NumberOfConvertedLeads),
                new WhippetDataRowImportMapEntry(nameof(NumberOfLeads), SalesforceObjectConstants.Fields.NumberOfLeads),
                new WhippetDataRowImportMapEntry(nameof(NumberOfOpportunities), SalesforceObjectConstants.Fields.NumberOfOpportunities),
                new WhippetDataRowImportMapEntry(nameof(NumberOfResponses), SalesforceObjectConstants.Fields.NumberOfResponses),
                new WhippetDataRowImportMapEntry(nameof(NumberOfWonOpportunities), SalesforceObjectConstants.Fields.NumberOfWonOpportunities),
                new WhippetDataRowImportMapEntry(nameof(NumberSent), SalesforceObjectConstants.Fields.NumberSent),
                new WhippetDataRowImportMapEntry(nameof(OwnerID), SalesforceObjectConstants.Fields.OwnerId),
                new WhippetDataRowImportMapEntry(nameof(ParentCampaign), SalesforceObjectConstants.Fields.ParentCampaign),
                new WhippetDataRowImportMapEntry(nameof(ParentID), SalesforceObjectConstants.Fields.ParentId),
                new WhippetDataRowImportMapEntry(nameof(RecordTypeID), SalesforceObjectConstants.Fields.RecordTypeId),
                new WhippetDataRowImportMapEntry(nameof(OwnerID), SalesforceObjectConstants.Fields.OwnerId),
                new WhippetDataRowImportMapEntry(nameof(StartDate), SalesforceObjectConstants.Fields.StartDate),
                new WhippetDataRowImportMapEntry(nameof(Status), SalesforceObjectConstants.Fields.Status),
                new WhippetDataRowImportMapEntry(nameof(TotalAmountAllOpportunities), SalesforceObjectConstants.Fields.TotalAmountAllOpportunities),
                new WhippetDataRowImportMapEntry(nameof(TotalAmountAllWonOpportunities), SalesforceObjectConstants.Fields.TotalAmountAllWonOpportunities),
                new WhippetDataRowImportMapEntry(nameof(TotalNumberOfContacts), SalesforceObjectConstants.Fields.TotalNumberofContacts),
                new WhippetDataRowImportMapEntry(nameof(TotalNumberOfConvertedLeads), SalesforceObjectConstants.Fields.TotalNumberofConvertedLeads),
                new WhippetDataRowImportMapEntry(nameof(TotalNumberOfLeads), SalesforceObjectConstants.Fields.TotalNumberofLeads),
                new WhippetDataRowImportMapEntry(nameof(TotalNumberOfOpportunities), SalesforceObjectConstants.Fields.TotalNumberofOpportunities),
                new WhippetDataRowImportMapEntry(nameof(TotalNumberOfResponses), SalesforceObjectConstants.Fields.TotalNumberofResponses),
                new WhippetDataRowImportMapEntry(nameof(TotalNumberOfWonOpportunities), SalesforceObjectConstants.Fields.TotalNumberofWonOpportunities),
                new WhippetDataRowImportMapEntry(nameof(Type), SalesforceObjectConstants.Fields.Type)
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
                WhippetDataRowImportMap map = (importMap == null ? ImportMap : importMap);

                ActualCost = dataRow.Field<decimal?>(map[nameof(ActualCost)].Column);
                AmountAllOpportunities = dataRow.Field<decimal>(map[nameof(AmountAllOpportunities)].Column);
                AmountWonOpportunities = dataRow.Field<decimal>(map[nameof(AmountWonOpportunities)].Column);
                BudgetedCost = dataRow.Field<decimal>(map[nameof(BudgetedCost)].Column);
                CampaignMemberRecordTypeID = dataRow.Field<string>(map[nameof(CampaignMemberRecordTypeID)].Column);
                CurrencyISOCode = dataRow.Field<string>(map[nameof(CurrencyISOCode)].Column);
                Description = dataRow.Field<string>(map[nameof(Description)].Column);

                if (dataRow.Field<DateTime?>(map[nameof(EndDate)].Column).HasValue)
                {
                    EndDate = dataRow.Field<DateTime>(map[nameof(EndDate)].Column).ToInstant();
                }
                else
                {
                    EndDate = null;
                }

                ExpectedResponse = dataRow.Field<double?>(map[nameof(ExpectedResponse)].Column);
                ExpectedRevenue = dataRow.Field<decimal?>(map[nameof(ExpectedRevenue)].Column);
                HierarchyActualCost = dataRow.Field<decimal?>(map[nameof(HierarchyActualCost)].Column);
                HierarchyBudgetedCost = dataRow.Field<decimal?>(map[nameof(HierarchyBudgetedCost)].Column);
                HierarchyExpectedRevenue = dataRow.Field<decimal?>(map[nameof(HierarchyExpectedRevenue)].Column);
                HierarchyNumberSent = dataRow.Field<int>(map[nameof(HierarchyNumberSent)].Column);
                IsActive = dataRow.Field<bool>(map[nameof(IsActive)].Column);

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

                Name = dataRow.Field<string>(map[nameof(Name)].Column);
                NumberOfContacts = dataRow.Field<int>(map[nameof(NumberOfContacts)].Column);
                NumberOfConvertedLeads = dataRow.Field<int>(map[nameof(NumberOfConvertedLeads)].Column);
                NumberOfLeads = dataRow.Field<int>(map[nameof(NumberOfLeads)].Column);
                NumberOfOpportunities = dataRow.Field<int>(map[nameof(NumberOfOpportunities)].Column);
                NumberOfResponses = dataRow.Field<int>(map[nameof(NumberOfResponses)].Column);
                NumberOfWonOpportunities = dataRow.Field<int>(map[nameof(NumberOfWonOpportunities)].Column);
                NumberSent = dataRow.Field<double?>(map[nameof(NumberSent)].Column);
                OwnerID = dataRow.Field<string>(map[nameof(OwnerID)].Column);
                ParentCampaign = dataRow.Field<string>(map[nameof(ParentCampaign)].Column);
                ParentID = dataRow.Field<string>(map[nameof(ParentID)].Column);
                RecordTypeID = dataRow.Field<string>(map[nameof(RecordTypeID)].Column);

                if (dataRow.Field<DateTime?>(map[nameof(StartDate)].Column).HasValue)
                {
                    StartDate = dataRow.Field<DateTime>(map[nameof(StartDate)].Column).ToInstant();
                }
                else
                {
                    StartDate = null;
                }

                Status = dataRow.Field<string>(map[nameof(Status)].Column);
                TotalAmountAllOpportunities = dataRow.Field<decimal>(map[nameof(TotalAmountAllOpportunities)].Column);
                TotalAmountAllWonOpportunities = dataRow.Field<decimal>(map[nameof(TotalAmountAllWonOpportunities)].Column);
                TotalNumberOfContacts = dataRow.Field<int>(map[nameof(TotalNumberOfContacts)].Column);
                TotalNumberOfConvertedLeads = dataRow.Field<int>(map[nameof(TotalNumberOfConvertedLeads)].Column);
                TotalNumberOfLeads = dataRow.Field<int>(map[nameof(TotalNumberOfLeads)].Column);
                TotalNumberOfOpportunities = dataRow.Field<int>(map[nameof(TotalNumberOfOpportunities)].Column);
                TotalNumberOfResponses = dataRow.Field<int>(map[nameof(TotalNumberOfResponses)].Column);
                TotalNumberOfWonOpportunities = dataRow.Field<int>(map[nameof(TotalNumberOfWonOpportunities)].Column);
                Type = dataRow.Field<string>(map[nameof(Type)].Column);
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

            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(ActualCost)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(AmountAllOpportunities)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(AmountWonOpportunities)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(BudgetedCost)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CampaignMemberRecordTypeID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CurrencyISOCode)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Description)].Column, true, 16000));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(EndDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<double>(map[nameof(ExpectedResponse)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(ExpectedRevenue)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(HierarchyActualCost)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(HierarchyBudgetedCost)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(HierarchyExpectedRevenue)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(HierarchyNumberSent)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsActive)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastActivityDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastReferencedDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastViewedDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Name)].Column, false, 80));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(NumberOfContacts)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(NumberOfConvertedLeads)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(NumberOfLeads)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(NumberOfOpportunities)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(NumberOfResponses)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(NumberOfWonOpportunities)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<double>(map[nameof(NumberSent)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OwnerID)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ParentCampaign)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ParentID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(RecordTypeID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(StartDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Status)].Column, true, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(TotalAmountAllOpportunities)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(TotalAmountAllWonOpportunities)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(TotalNumberOfContacts)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(TotalNumberOfConvertedLeads)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(TotalNumberOfLeads)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(TotalNumberOfOpportunities)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(TotalNumberOfResponses)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(TotalNumberOfWonOpportunities)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Type)].Column, true, 40));

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
            return Equals(obj as ISalesforceCampaign);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ISalesforceCampaign obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="ISalesforceCampaign"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="ISalesforceCampaign"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ISalesforceCampaign a, ISalesforceCampaign b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals =
                    a.ActualCost.GetValueOrDefault().Equals(b.ActualCost.GetValueOrDefault())
                        && a.AmountAllOpportunities.Equals(b.AmountAllOpportunities)
                        && a.AmountWonOpportunities.Equals(b.AmountWonOpportunities)
                        && a.BudgetedCost.Equals(b.BudgetedCost)
                        && String.Equals(a.CampaignMemberRecordTypeID, b.CampaignMemberRecordTypeID, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.CurrencyISOCode, b.CurrencyISOCode, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Description, b.Description, StringComparison.InvariantCultureIgnoreCase)
                        && a.EndDate.GetValueOrDefault().Equals(b.EndDate.GetValueOrDefault())
                        && a.ExpectedResponse.GetValueOrDefault().Equals(b.ExpectedResponse.GetValueOrDefault())
                        && a.ExpectedRevenue.GetValueOrDefault().Equals(b.ExpectedRevenue.GetValueOrDefault())
                        && a.HierarchyActualCost.GetValueOrDefault().Equals(b.HierarchyActualCost.GetValueOrDefault())
                        && a.HierarchyBudgetedCost.GetValueOrDefault().Equals(b.HierarchyBudgetedCost.GetValueOrDefault())
                        && a.HierarchyExpectedRevenue.GetValueOrDefault().Equals(b.HierarchyExpectedRevenue.GetValueOrDefault())
                        && a.HierarchyNumberSent.Equals(b.HierarchyNumberSent)
                        && a.IsActive.Equals(b.IsActive)
                        && a.LastActivityDate.GetValueOrDefault().Equals(b.LastActivityDate.GetValueOrDefault())
                        && a.LastReferencedDate.GetValueOrDefault().Equals(b.LastReferencedDate.GetValueOrDefault())
                        && a.LastViewedDate.GetValueOrDefault().Equals(b.LastViewedDate.GetValueOrDefault())
                        && String.Equals(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase)
                        && a.NumberOfContacts.Equals(b.NumberOfContacts)
                        && a.NumberOfConvertedLeads.Equals(b.NumberOfConvertedLeads)
                        && a.NumberOfLeads.Equals(b.NumberOfLeads)
                        && a.NumberOfOpportunities.Equals(b.NumberOfOpportunities)
                        && a.NumberOfResponses.Equals(b.NumberOfResponses)
                        && a.NumberOfWonOpportunities.Equals(b.NumberOfWonOpportunities)
                        && a.NumberSent.Equals(b.NumberSent)
                        && String.Equals(a.OwnerID, b.OwnerID, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.ParentCampaign, b.ParentCampaign, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.ParentID, b.ParentID, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.RecordTypeID, b.RecordTypeID, StringComparison.InvariantCultureIgnoreCase)
                        && a.StartDate.GetValueOrDefault().Equals(b.StartDate.GetValueOrDefault())
                        && String.Equals(a.Status, b.Status, StringComparison.InvariantCultureIgnoreCase)
                        && a.TotalAmountAllOpportunities.Equals(b.TotalAmountAllOpportunities)
                        && a.TotalAmountAllWonOpportunities.Equals(b.TotalAmountAllWonOpportunities)
                        && a.TotalNumberOfContacts.Equals(b.TotalNumberOfContacts)
                        && a.TotalNumberOfConvertedLeads.Equals(b.TotalNumberOfConvertedLeads)
                        && a.TotalNumberOfLeads.Equals(b.TotalNumberOfLeads)
                        && a.TotalNumberOfOpportunities.Equals(b.TotalNumberOfOpportunities)
                        && a.TotalNumberOfResponses.Equals(b.TotalNumberOfResponses)
                        && a.TotalNumberOfWonOpportunities.Equals(b.TotalNumberOfWonOpportunities)
                        && String.Equals(a.Type, b.Type, StringComparison.InvariantCultureIgnoreCase);
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
        public int GetHashCode(ISalesforceCampaign obj)
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

