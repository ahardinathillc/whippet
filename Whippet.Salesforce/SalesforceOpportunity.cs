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
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents an opportunity, which is a sale or pending deal. This class cannot be inherited.
    /// </summary>
    /// <remarks>See <a href="https://developer.salesforce.com/docs/atlas.en-us.192.0.object_reference.meta/object_reference/sforce_api_objects_opportunity.htm">Opportunity</a> for more information.</remarks>
    public sealed class SalesforceOpportunity : IWhippetEntityDynamicImportMapper, IWhippetEntityExternalDataRowImportMapper, IWhippetEntity, ISalesforceObject, ISalesforceOpportunity
    {
        private string _description;
        private string _name;
        private string _nextStep;

        private int? _fsQuarter;

        private SalesforceFiscalDate? _fsDate;

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
        /// ID of the account associated with this opportunity.
        /// </summary>
        public SalesforceReference? AccountID
        { get; set; }

        /// <summary>
        /// Estimated total sale amount. For opportunities with products, the amount is the sum of the related products. Any attempt to update this field, if the record has products, will be ignored. The update call will not be rejected, and other fields will be updated as specified, but the Amount will be unchanged.
        /// </summary>
        public decimal? Amount
        { get; set; }

        /// <summary>
        /// ID of a related Campaign. This field is defined only for those organizations that have the campaign feature Campaigns enabled. The User must have read access rights to the cross-referenced Campaign object in order to create or update that campaign into this field on the opportunity.
        /// </summary>
        public SalesforceReference? CampaignID
        { get; set; }

        /// <summary>
        /// Required. Date when the opportunity is expected to close.
        /// </summary>
        public Instant CloseDate
        { get; set; }

        /// <summary>
        /// ID of the PartnerNetworkConnection that shared this record with your organization. This field is only available if you have enabled Salesforce to Salesforce.
        /// </summary>
        public string ConnectionReceivedID
        { get; set; }

        /// <summary>
        /// ID of the PartnerNetworkConnection that you shared this record with. This field is only available if you have enabled Salesforce to Salesforce. Beginning with API version 15.0, the ConnectionSentId field is no longer supported. The ConnectionSentId field is still visible, but the value is null. You can use the new PartnerNetworkRecordConnection object to forward records to connections.
        /// </summary>
        public string ConnectionSentID
        { get; set; }

        /// <summary>
        /// ID of the contract that’s associated with this opportunity.
        /// </summary>
        public string ContractID
        { get; set; }

        /// <summary>
        /// Available only for organizations with the multicurrency feature enabled. Contains the ISO code for any currency allowed by the organization. If the organization has multicurrency and a Pricebook2 is specified on the opportunity(i.e., the Pricebook2Id field is not blank), then the currency value of this field must match the currency of the PricebookEntry records that are associated with any opportunity line items it has.
        /// </summary>
        public string CurrencyISOCode
        { get; set; }

        /// <summary>
        /// Description of the opportunity. Limit: 32,000 characters.
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
        /// Read-only field that is equal to the product of the opportunity <see cref="Amount"/> field and the <see cref="Probability"/>. You can’t directly set this field, but you can indirectly set it by setting the <see cref="Amount"/> or <see cref="Probability"/> fields.
        /// </summary>
        public decimal? ExpectedRevenue
        { get; set; }

        /// <summary>
        /// If fiscal years are not enabled, the name of the fiscal quarter or period in which the opportunity <see cref="CloseDate"/> falls.
        /// </summary>
        public SalesforceFiscalDate? Fiscal
        {
            get
            {
                SalesforceFiscalDate fsDate;

                if (!_fsDate.HasValue)
                {
                    if (FiscalQuarter.HasValue && FiscalYear.HasValue)
                    {
                        fsDate = new SalesforceFiscalDate(FiscalYear.Value, Enum.Parse<SalesforceFiscalQuarter>(Convert.ToString(FiscalQuarter.Value)));
                    }
                    else
                    {
                        fsDate = new SalesforceFiscalDate();

                        if (FiscalQuarter.HasValue)
                        {
                            fsDate.Quarter = Enum.Parse<SalesforceFiscalQuarter>(Convert.ToString(FiscalQuarter.Value));
                        }

                        if (FiscalYear.HasValue)
                        {
                            fsDate.Year = new DateTime(FiscalYear.Value, 1, 1, 0, 0, 0, DateTimeKind.Utc).ToInstant();
                        }
                        else
                        {
                            fsDate.Year = CloseDate;
                        }
                    }

                    _fsDate = fsDate;
                }

                return _fsDate;
            }
            set
            {
                _fsDate = value;
            }
        }

        /// <summary>
        /// Represents the fiscal quarter.
        /// </summary>
        /// <exception cref="InvalidEnumArgumentException" />
        public int? FiscalQuarter
        {
            get
            {
                return _fsQuarter;
            }
            set
            {
                SalesforceFiscalQuarter quarterValue;

                if (value.HasValue)
                {
                    if (!Enum.TryParse<SalesforceFiscalQuarter>(Convert.ToString(value.Value), out quarterValue))
                    {
                        throw new InvalidEnumArgumentException(nameof(value), value.Value, typeof(SalesforceFiscalQuarter));
                    }
                }

                _fsQuarter = value;
            }
        }

        /// <summary>
        /// Represents the fiscal year.
        /// </summary>
        public int? FiscalYear
        { get; set; }

        /// <summary>
        /// Restricted picklist field. It is implied, but not directly controlled, by the <see cref="StageName"/> field. You can override this field to a different value than is implied by the <see cref="StageName"/> value. The values of this field are fixed enumerated values. The field labels are localized to the language of the user performing the operation, if localized versions of those labels are available for that language in the user interface. In API version 12.0 and later, the value of this field is automatically set based on the value of the ForecastCategoryName and can’t be updated any other way. The field properties Create, Defaulted on create, Nillable, and Update are not available in version 12.0.
        /// </summary>
        public string ForecastCategory
        { get; set; }

        /// <summary>
        /// Available in API version 12.0 and later. The name of the forecast category. It is implied, but not directly controlled, by the <see cref="StageName"/> field. You can override this field to a different value than is implied by the <see cref="StageName"/> value.
        /// </summary>
        public string ForecastCategoryName
        { get; set; }

        /// <summary>
        /// Read-only field that indicates whether the opportunity has associated line items. A value of true means that Opportunity line items have been created for the opportunity. An opportunity can have opportunity line items only if the opportunity has a price book. The opportunity line items must correspond to PricebookEntry objects that are listed in the opportunity Pricebook2. However, you can insert opportunity line items on an opportunity that does not have an associated Pricebook2. For the first opportunity line item that you insert on an opportunity without a Pricebook2, the API automatically sets the Pricebook2Id field, if the opportunity line item corresponds to a PricebookEntry in an active Pricebook2 that has a CurrencyIsoCode field that matches the CurrencyIsoCode field of the opportunity. If the Pricebook2 is not active or the CurrencyIsoCode fields do not match, then the API returns an error. You can’t update the <see cref="Pricebook2Id"/> or <see cref="PricebookId"/> fields if opportunity line items exist on the Opportunity. You must delete the line items before attempting to update the PricebookId field.
        /// </summary>
        public bool HasOpportunityLineItem
        { get; set; }

        /// <summary>
        /// Directly controlled by <see cref="StageName"/>. You can query and filter on this field, but you can’t directly set it in a create, upsert, or update request. It can only be set via <see cref="StageName"/>. Label is <b>Closed</b>.
        /// </summary>
        public bool IsClosed
        { get; set; }

        /// <summary>
        /// Indicates whether the object has been moved to the Recycle Bin (true) or not (false). Label is <b>Deleted</b>.
        /// </summary>
        public bool IsDeleted
        { get; set; }

        /// <summary>
        /// Read-only field that indicates whether credit for the opportunity is split between opportunity team members. Label is <b>IsSplit</b>. This field is available in versions 14.0 and later for organizations that enabled Opportunity Splits during the pilot period.
        /// </summary>
        public bool IsSplit
        { get; set; }

        /// <summary>
        /// Directly controlled by <see cref="StageName"/>. You can query and filter on this field, but you can’t directly set the value. It can only be set via <see cref="StageName"/>. Label is <b>Won</b>.
        /// </summary>
        public bool IsWon
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
        /// Source of this opportunity, such as Advertisement or Trade Show.
        /// </summary>
        public string LeadSource
        { get; set; }

        /// <summary>
        /// Required. A name for this opportunity. Limit: 120 characters.
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
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Name)].Column, true);
                _name = value;
            }
        }

        /// <summary>
        /// Description of next task in closing opportunity. Limit: 255 characters.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public string NextStep
        {
            get
            {
                return _nextStep;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(NextStep)].Column, true);
                _name = value;
            }
        }

        /// <summary>
        /// ID of the user who owns this opportunity. Default value is the user logging in to the API to perform the create.
        /// </summary>
        public SalesforceReference? OwnerID
        { get; set; }

        /// <summary>
        /// ID of a related Pricebook2 object. The Pricebook2Id field indicates which Pricebook2 applies to this opportunity. The Pricebook2Id field is defined only for those organizations that have products enabled as a feature. You can specify values for only one field (Pricebook2Id or PricebookId)—not both fields. For this reason, both fields are declared nillable.
        /// </summary>
        public string Pricebook2ID
        { get; set; }

        /// <summary>
        /// Unavailable as of version 3.0. As of version 8.0, the Pricebook object is no longer available. Use the Pricebook2Id field instead, specifying the ID of the Pricebook2 record.
        /// </summary>
        public string PricebookID
        { get; set; }

        /// <summary>
        /// Percentage of estimated confidence in closing the opportunity. It is implied, but not directly controlled, by the <see cref="StageName"/> field. You can override this field to a different value than what is implied by the StageName.
        /// </summary>
        public double? Probability
        { get; set; }

        /// <summary>
        /// ID of the record type assigned to this object.
        /// </summary>
        public SalesforceReference? RecordTypeID
        { get; set; }

        /// <summary>
        /// Required. Current stage of this record. The <see cref="StageName"/> field controls several other fields on an opportunity. Each of the fields can be directly set or implied by changing the <see cref="StageName"/> field. In addition, the StageName field is a picklist, so it has additional members in the returned describeSObjectResult to indicate how it affects the other fields. To obtain the stage name values in the picklist, query the OpportunityStage object. If the <see cref="StageName"/> is updated, then the <see cref="ForecastCategoryName"/>, <see cref="IsClosed"/>, <see cref="IsWon"/>, and <see cref="Probability"/> are automatically updated based on the stage-category mapping.
        /// </summary>
        public string StageName
        { get; set; }

        /// <summary>
        /// Read only in an Apex trigger. The ID of the Quote that syncs with the opportunity. Setting this field lets you start and stop syncing between the opportunity and a quote. The ID has to be for a quote that is a child of the opportunity.
        /// </summary>
        public string SyncedQuoteID
        { get; set; }

        /// <summary>
        /// Number of items included in this opportunity. Used in quantity-based forecasting.
        /// </summary>
        public double? TotalOpportunityQuantity
        { get; set; }

        /// <summary>
        /// Type of opportunity. For example, Existing Business or New Business. Label is <b>Opportunity Type</b>.
        /// </summary>
        public string Type
        { get; set; }

        /// <summary>
        /// Gets the external table name or <see langword="null"/> if the data source is not stored in a database. This property is read-only.
        /// </summary>
        string IWhippetEntityExternalDataRowImportMapper.ExternalTableName
        {
            get
            {
                return SalesforceObjectConstants.Objects.Opportunity;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceOpportunity"/> class with no arguments.
        /// </summary>
        public SalesforceOpportunity()
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
                new WhippetDataRowImportMapEntry(nameof(AccountID), SalesforceObjectConstants.Fields.AccountId),
                new WhippetDataRowImportMapEntry(nameof(Amount), SalesforceObjectConstants.Fields.Amount),
                new WhippetDataRowImportMapEntry(nameof(CampaignID), SalesforceObjectConstants.Fields.CampaignId),
                new WhippetDataRowImportMapEntry(nameof(CloseDate), SalesforceObjectConstants.Fields.CloseDate),
                new WhippetDataRowImportMapEntry(nameof(ConnectionReceivedID), SalesforceObjectConstants.Fields.ConnectionReceivedId),
                new WhippetDataRowImportMapEntry(nameof(ConnectionSentID), SalesforceObjectConstants.Fields.ConnectionSentId),
                new WhippetDataRowImportMapEntry(nameof(ContractID), SalesforceObjectConstants.Fields.ContractId),
                new WhippetDataRowImportMapEntry(nameof(CurrencyISOCode), SalesforceObjectConstants.Fields.CurrencyIsoCode),
                new WhippetDataRowImportMapEntry(nameof(Description), SalesforceObjectConstants.Fields.Description),
                new WhippetDataRowImportMapEntry(nameof(ExpectedRevenue), SalesforceObjectConstants.Fields.ExpectedRevenue),
                new WhippetDataRowImportMapEntry(nameof(Fiscal), SalesforceObjectConstants.Fields.Fiscal),
                new WhippetDataRowImportMapEntry(nameof(FiscalQuarter), SalesforceObjectConstants.Fields.FiscalQuarter),
                new WhippetDataRowImportMapEntry(nameof(FiscalYear), SalesforceObjectConstants.Fields.FiscalYear),
                new WhippetDataRowImportMapEntry(nameof(ForecastCategory), SalesforceObjectConstants.Fields.ForecastCategory),
                new WhippetDataRowImportMapEntry(nameof(ForecastCategoryName), SalesforceObjectConstants.Fields.ForecastCategoryName),
                new WhippetDataRowImportMapEntry(nameof(HasOpportunityLineItem), SalesforceObjectConstants.Fields.HasOpportunityLineItem),
                new WhippetDataRowImportMapEntry(nameof(IsClosed), SalesforceObjectConstants.Fields.IsClosed),
                new WhippetDataRowImportMapEntry(nameof(IsDeleted), SalesforceObjectConstants.Fields.IsDeleted),
                new WhippetDataRowImportMapEntry(nameof(IsSplit), SalesforceObjectConstants.Fields.IsSplit),
                new WhippetDataRowImportMapEntry(nameof(IsWon), SalesforceObjectConstants.Fields.IsWon),
                new WhippetDataRowImportMapEntry(nameof(LastActivityDate), SalesforceObjectConstants.Fields.LastActivityDate),
                new WhippetDataRowImportMapEntry(nameof(LastReferencedDate), SalesforceObjectConstants.Fields.LastReferencedDate),
                new WhippetDataRowImportMapEntry(nameof(LastViewedDate), SalesforceObjectConstants.Fields.LastViewedDate),
                new WhippetDataRowImportMapEntry(nameof(LeadSource), SalesforceObjectConstants.Fields.LeadSource),
                new WhippetDataRowImportMapEntry(nameof(Name), SalesforceObjectConstants.Fields.Name),
                new WhippetDataRowImportMapEntry(nameof(NextStep), SalesforceObjectConstants.Fields.NextStep),
                new WhippetDataRowImportMapEntry(nameof(OwnerID), SalesforceObjectConstants.Fields.OwnerId),
                new WhippetDataRowImportMapEntry(nameof(Pricebook2ID), SalesforceObjectConstants.Fields.Pricebook2Id),
                new WhippetDataRowImportMapEntry(nameof(PricebookID), SalesforceObjectConstants.Fields.PricebookId),
                new WhippetDataRowImportMapEntry(nameof(Probability), SalesforceObjectConstants.Fields.Probability),
                new WhippetDataRowImportMapEntry(nameof(RecordTypeID), SalesforceObjectConstants.Fields.RecordTypeId),
                new WhippetDataRowImportMapEntry(nameof(StageName), SalesforceObjectConstants.Fields.StageName),
                new WhippetDataRowImportMapEntry(nameof(SyncedQuoteID), SalesforceObjectConstants.Fields.SyncedQuoteID),
                new WhippetDataRowImportMapEntry(nameof(TotalOpportunityQuantity), SalesforceObjectConstants.Fields.TotalOpportunityQuantity),
                new WhippetDataRowImportMapEntry(nameof(Type), SalesforceObjectConstants.Fields.Type),
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

                AccountID = dataRow.Field<string>(map[nameof(AccountID)].Column);
                Amount = dataRow.Field<decimal?>(map[nameof(Amount)].Column);
                CampaignID = dataRow.Field<string>(map[nameof(CampaignID)].Column);
                CloseDate = dataRow.Field<DateTime>(map[nameof(CloseDate)].Column).ToInstant();
                ConnectionReceivedID = dataRow.Field<string>(map[nameof(ConnectionReceivedID)].Column);
                ConnectionSentID = dataRow.Field<string>(map[nameof(ConnectionSentID)].Column);
                ContractID = dataRow.Field<string>(map[nameof(ContractID)].Column);
                CurrencyISOCode = dataRow.Field<string>(map[nameof(CurrencyISOCode)].Column);
                Description = dataRow.Field<string>(map[nameof(Description)].Column);
                ExpectedRevenue = dataRow.Field<decimal?>(map[nameof(ExpectedRevenue)].Column);
                FiscalQuarter = dataRow.Field<int?>(map[nameof(FiscalQuarter)].Column);
                FiscalYear = dataRow.Field<int?>(map[nameof(FiscalYear)].Column);
                ForecastCategory = dataRow.Field<string>(map[nameof(ForecastCategory)].Column);
                ForecastCategoryName = dataRow.Field<string>(map[nameof(ForecastCategoryName)].Column);
                HasOpportunityLineItem = dataRow.Field<bool>(map[nameof(HasOpportunityLineItem)].Column);
                IsClosed = dataRow.Field<bool>(map[nameof(IsClosed)].Column);
                IsDeleted = dataRow.Field<bool>(map[nameof(IsDeleted)].Column);
                IsSplit = dataRow.Field<bool>(map[nameof(IsSplit)].Column);
                IsWon = dataRow.Field<bool>(map[nameof(IsWon)].Column);

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

                LeadSource = dataRow.Field<string>(map[nameof(LeadSource)].Column);
                Name = dataRow.Field<string>(map[nameof(Name)].Column);
                NextStep = dataRow.Field<string>(map[nameof(NextStep)].Column);
                OwnerID = dataRow.Field<string>(map[nameof(OwnerID)].Column);
                Pricebook2ID = dataRow.Field<string>(map[nameof(Pricebook2ID)].Column);
                PricebookID = dataRow.Field<string>(map[nameof(PricebookID)].Column);
                Probability = dataRow.Field<double>(map[nameof(Probability)].Column);
                RecordTypeID = dataRow.Field<string>(map[nameof(RecordTypeID)].Column);
                StageName = dataRow.Field<string>(map[nameof(StageName)].Column);
                SyncedQuoteID = dataRow.Field<string>(map[nameof(SyncedQuoteID)].Column);
                TotalOpportunityQuantity = dataRow.Field<double>(map[nameof(TotalOpportunityQuantity)].Column);
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

            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(AccountID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(Amount)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CampaignID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(CloseDate)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ConnectionReceivedID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ConnectionSentID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ContractID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CurrencyISOCode)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Description)].Column, true, 32000));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(ExpectedRevenue)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Fiscal)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(FiscalQuarter)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(FiscalYear)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ForecastCategory)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ForecastCategoryName)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(HasOpportunityLineItem)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsClosed)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsDeleted)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsSplit)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsWon)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastActivityDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastReferencedDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastViewedDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(LeadSource)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Name)].Column, false, 120));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(NextStep)].Column, true, 255));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OwnerID)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Pricebook2ID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PricebookID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<double>(map[nameof(Probability)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(RecordTypeID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(StageName)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SyncedQuoteID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<double>(map[nameof(TotalOpportunityQuantity)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Type)].Column, true));

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
            return Equals(obj as ISalesforceOpportunity);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ISalesforceOpportunity obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="ISalesforceOpportunity"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="ISalesforceOpportunity"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ISalesforceOpportunity a, ISalesforceOpportunity b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals =
                    String.Equals(a.AccountID, b.AccountID, StringComparison.InvariantCultureIgnoreCase)
                        && a.Amount.GetValueOrDefault().Equals(b.Amount.GetValueOrDefault())
                        && String.Equals(a.CampaignID, b.CampaignID, StringComparison.InvariantCultureIgnoreCase)
                        && CloseDate.Equals(b.CloseDate)
                        && String.Equals(a.ConnectionReceivedID, b.ConnectionReceivedID, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.ConnectionSentID, b.ConnectionSentID, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.ContractID, b.ContractID, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.CurrencyISOCode, b.CurrencyISOCode, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Description, b.Description, StringComparison.InvariantCultureIgnoreCase)
                        && a.ExpectedRevenue.GetValueOrDefault().Equals(b.ExpectedRevenue.GetValueOrDefault())
                        && Fiscal.GetValueOrDefault().Equals(b.Fiscal.GetValueOrDefault())
                        && String.Equals(a.ForecastCategory, b.ForecastCategory, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.ForecastCategoryName, b.ForecastCategoryName, StringComparison.InvariantCultureIgnoreCase)
                        && a.HasOpportunityLineItem.Equals(b.HasOpportunityLineItem)
                        && a.IsClosed.Equals(b.IsClosed)
                        && a.IsDeleted.Equals(b.IsDeleted)
                        && a.IsSplit.Equals(b.IsSplit)
                        && a.IsWon.Equals(b.IsWon)
                        && LastActivityDate.GetValueOrDefault().Equals(b.LastActivityDate.GetValueOrDefault())
                        && LastReferencedDate.GetValueOrDefault().Equals(b.LastReferencedDate.GetValueOrDefault())
                        && LastViewedDate.GetValueOrDefault().Equals(b.LastViewedDate.GetValueOrDefault())
                        && String.Equals(a.LeadSource, b.LeadSource, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.NextStep, b.NextStep, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.OwnerID, b.OwnerID, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Pricebook2ID, b.Pricebook2ID, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.PricebookID, b.PricebookID, StringComparison.InvariantCultureIgnoreCase)
                        && a.Probability.GetValueOrDefault().Equals(b.Probability.GetValueOrDefault())
                        && String.Equals(a.RecordTypeID, b.RecordTypeID, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.StageName, b.StageName, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.SyncedQuoteID, b.SyncedQuoteID, StringComparison.InvariantCultureIgnoreCase)
                        && TotalOpportunityQuantity.GetValueOrDefault().Equals(b.TotalOpportunityQuantity.GetValueOrDefault())
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
        public int GetHashCode(ISalesforceOpportunity obj)
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

