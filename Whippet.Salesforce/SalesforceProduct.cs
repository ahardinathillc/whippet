using System;
using System.Data;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;
using NodaTime;
using Dynamitey;
using Newtonsoft.Json.Linq;
using Athi.Whippet.Extensions;
using Athi.Whippet.Data;
using Athi.Whippet.Salesforce.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;
using Athi.Whippet.Json;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents a product that a Salesforce organization sells.
    /// </summary>
    /// <remarks>See <a href="https://developer.salesforce.com/docs/atlas.en-us.object_reference.meta/object_reference/sforce_api_objects_product2.htm">Product2</a> for more information.</remarks>
    public sealed class SalesforceProduct : IWhippetEntityDynamicImportMapper, IWhippetEntityExternalDataRowImportMapper, IWhippetEntity, ISalesforceObject, ISalesforceProduct
    {
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
        /// Gets the external table name or <see langword="null"/> if the data source is not stored in a database. This property is read-only.
        /// </summary>
        string IWhippetEntityExternalDataRowImportMapper.ExternalTableName
        {
            get
            {
                return SalesforceObjectConstants.Objects.Product;
            }
        }

        /// <summary>
        /// Gets or sets the unique ID of the entity.
        /// </summary>
        Guid IWhippetEntity.ID
        { get; set; }

        /// <summary>
        /// ID of the object who owns the current instance.
        /// </summary>
        SalesforceReference? ISalesforceObject.OwnerID
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
        /// ID of the record type assigned to the current instance.
        /// </summary>
        SalesforceReference? ISalesforceObject.RecordTypeID
        { get; set; }

        /// <summary>
        /// The ID of the related billing policy. This field is available when Subscription Management is enabled.
        /// </summary>
        public SalesforceReference BillingPolicyID
        { get; set; }

        /// <summary>
        /// Indicates whether the product can have a quantity schedule (<see langword="true"/>) or not (<see langword="false"/>). Label is <strong>Quantity Scheduling Enabled</strong>.
        /// </summary>
        public bool CanUseQuantitySchedule
        { get; set; }

        /// <summary>
        /// Indicates whether the product can have a revenue schedule (<see langword="true"/>) or not (<see langword="false"/>). Label is <strong>Revenue Scheduling Enabled</strong>.
        /// </summary>
        public bool CanUseRevenueSchedule
        { get; set; }

        /// <summary>
        /// ID of the PartnerNetworkConnection that shared this record with your organization. This field is available if you enabled Salesforce to Salesforce.
        /// </summary>
        public SalesforceReference ConnectionReceivedID
        { get; set; }

        /// <summary>
        /// ID of the PartnerNetworkConnection that you shared this record with. This field is available if you enabled Salesforce to Salesforce.
        /// </summary>
        public SalesforceReference ConnectionSentID
        { get; set; }

        /// <summary>
        /// A text description of this record. Label is <strong>Product Description</strong>.
        /// </summary>
        public string Description
        { get; set; }

        /// <summary>
        /// URL leading to a specific version of a record in the linked external data source.
        /// </summary>
        public string DisplayUrl
        { get; set; }

        /// <summary>
        /// ID of the related external data source.
        /// </summary>
        public SalesforceReference ExternalDataSourceID
        { get; set; }

        /// <summary>
        /// The unique identifier of a record in the linked external data source.
        /// </summary>
        public string ExternalID
        { get; set; }

        /// <summary>
        /// Indicates whether the product is active (<see langword="true"/>) or not (<see langword="false"/>). Inactive products are hidden in many areas in the user interface. You can change this field’s value as often as necessary. Label is <strong>Active</strong>.
        /// </summary>
        public bool IsActive
        { get; set; }

        /// <summary>
        /// Indicates whether the product has been archived (<see langword="true"/>) or not (<see langword="false"/>). This field is read-only.
        /// </summary>
        public bool IsArchived
        { get; set; }

        /// <summary>
        /// Indicates whether the product has been moved to the Recycle Bin (<see langword="true"/>) or not (<see langword="false"/>). Label is <strong>Deleted></strong>.
        /// </summary>
        public bool IsDeleted
        { get; set; }

        /// <summary>
        /// The timestamp when the current user last accessed this record, a record related to this record, or a list view.
        /// </summary>
        public Instant? LastReferencedDate
        { get; set; }

        /// <summary>
        /// The timestamp for when the current user last viewed this record. If this value is <see langword="null"/>, it’s possible that this record was referenced (<see cref="LastReferencedDate"/>) and not viewed.
        /// </summary>
        public Instant? LastViewedDate
        { get; set; }

        /// <summary>
        /// Value is one of the following, whichever is the most recent: due date of the most recent event logged against the record, or, due date of the most recently closed task associated with the record.
        /// </summary>
        Instant? ISalesforceObject.LastActivityDate
        { get; set; }

        /// <summary>
        /// Name of this object. Label is <strong>Product Name</strong>.
        /// </summary>
        public string Name
        { get; set; }

        /// <summary>
        /// If the product has a quantity schedule, the number of installments.
        /// </summary>
        public int? NumberOfQuantityInstallments
        { get; set; }

        /// <summary>
        /// If the product has a revenue schedule, the number of installments.
        /// </summary>
        public int? NumberOfRevenueInstallments
        { get; set; }

        /// <summary>
        /// Default product code for this record.
        /// </summary>
        public string ProductCode
        { get; set; }

        /// <summary>
        /// Changes behavior of <see cref="OpportunityLineItem"/> calculations when a line item has child schedule rows for the <see cref="Quantity"/> value. When enabled, if the rollup quantity changes, then the quantity rollup value is multiplied against the sales price to change the total price.
        /// </summary>
        public bool RecalculateTotalPrice
        { get; set; }

        /// <summary>
        /// The SKU for the product. Use in tandem with or instead of the <see cref="ProductCode"/> field. For example, you can track the manufacturer’s identifying code in the <see cref="ProductCode"/> field and assign the product a SKU when you resell it.
        /// </summary>
        public string StockKeepingUnit
        { get; set; }

        /// <summary>
        /// The ID of the related tax policy. This field is available when Subscription Management is enabled. 
        /// </summary>
        public SalesforceReference TaxPolicyID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceProduct"/> class with no arguments.
        /// </summary>
        public SalesforceProduct()
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
                new WhippetDataRowImportMapEntry(nameof(BillingPolicyID), SalesforceObjectConstants.Fields.BillingPolicyId),
                new WhippetDataRowImportMapEntry(nameof(CanUseQuantitySchedule), SalesforceObjectConstants.Fields.CanUseQuantitySchedule),
                new WhippetDataRowImportMapEntry(nameof(CanUseRevenueSchedule), SalesforceObjectConstants.Fields.CanUseRevenueSchedule),
                new WhippetDataRowImportMapEntry(nameof(ConnectionReceivedID), SalesforceObjectConstants.Fields.ConnectionReceivedId),
                new WhippetDataRowImportMapEntry(nameof(ConnectionSentID), SalesforceObjectConstants.Fields.ConnectionSentId),
                new WhippetDataRowImportMapEntry(nameof(Description), SalesforceObjectConstants.Fields.Description),
                new WhippetDataRowImportMapEntry(nameof(DisplayUrl), SalesforceObjectConstants.Fields.DisplayUrl),
                new WhippetDataRowImportMapEntry(nameof(ExternalDataSourceID), SalesforceObjectConstants.Fields.ExternalDataSourceId),
                new WhippetDataRowImportMapEntry(nameof(ExternalID), SalesforceObjectConstants.Fields.ExternalId),
                new WhippetDataRowImportMapEntry(nameof(IsActive), SalesforceObjectConstants.Fields.IsActive),
                new WhippetDataRowImportMapEntry(nameof(IsArchived), SalesforceObjectConstants.Fields.IsArchived),
                new WhippetDataRowImportMapEntry(nameof(IsDeleted), SalesforceObjectConstants.Fields.IsDeleted),
                new WhippetDataRowImportMapEntry(nameof(LastReferencedDate), SalesforceObjectConstants.Fields.LastReferencedDate),
                new WhippetDataRowImportMapEntry(nameof(LastViewedDate), SalesforceObjectConstants.Fields.LastViewedDate),
                new WhippetDataRowImportMapEntry(nameof(Name), SalesforceObjectConstants.Fields.Name),
                new WhippetDataRowImportMapEntry(nameof(NumberOfQuantityInstallments), SalesforceObjectConstants.Fields.NumberOfQuantityInstallments),
                new WhippetDataRowImportMapEntry(nameof(NumberOfRevenueInstallments), SalesforceObjectConstants.Fields.NumberOfRevenueInstallments),
                new WhippetDataRowImportMapEntry(nameof(ProductCode), SalesforceObjectConstants.Fields.ProductCode),
                new WhippetDataRowImportMapEntry(nameof(RecalculateTotalPrice), SalesforceObjectConstants.Fields.RecalculateTotalPrice),
                new WhippetDataRowImportMapEntry(nameof(StockKeepingUnit), SalesforceObjectConstants.Fields.StockKeepingUnit),
                new WhippetDataRowImportMapEntry(nameof(TaxPolicyID), SalesforceObjectConstants.Fields.TaxPolicyId)
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

                BillingPolicyID = dataRow.Field<string>(map[nameof(BillingPolicyID)].Column);
                CanUseQuantitySchedule = dataRow.Field<bool>(map[nameof(CanUseQuantitySchedule)].Column);
                CanUseRevenueSchedule = dataRow.Field<bool>(map[nameof(CanUseRevenueSchedule)].Column);
                ConnectionReceivedID = dataRow.Field<string>(map[nameof(ConnectionReceivedID)].Column);
                ConnectionSentID = dataRow.Field<string>(map[nameof(ConnectionSentID)].Column);
                Description = dataRow.Field<string>(map[nameof(Description)].Column);
                DisplayUrl = dataRow.Field<string>(map[nameof(DisplayUrl)].Column);
                ExternalDataSourceID = dataRow.Field<string>(map[nameof(ExternalDataSourceID)].Column);
                ExternalID = dataRow.Field<string>(map[nameof(ExternalID)].Column);
                IsActive = dataRow.Field<bool>(map[nameof(IsActive)].Column);
                IsArchived = dataRow.Field<bool>(map[nameof(IsArchived)].Column);
                IsDeleted = dataRow.Field<bool>(map[nameof(IsDeleted)].Column);
                LastReferencedDate = dataRow.Field<DateTime?>(map[nameof(LastReferencedDate)].Column).HasValue ? dataRow.Field<DateTime?>(map[nameof(LastReferencedDate)].Column).ToInstant() : null;
                LastViewedDate = dataRow.Field<DateTime?>(map[nameof(LastViewedDate)].Column).HasValue ? dataRow.Field<DateTime?>(map[nameof(LastViewedDate)].Column).ToInstant() : null;
                Name = dataRow.Field<string>(map[nameof(Name)].Column);
                NumberOfQuantityInstallments = dataRow.Field<int?>(map[nameof(NumberOfQuantityInstallments)].Column);
                NumberOfRevenueInstallments = dataRow.Field<int?>(map[nameof(NumberOfRevenueInstallments)].Column);
                ProductCode = dataRow.Field<string>(map[nameof(ProductCode)].Column);
                RecalculateTotalPrice = dataRow.Field<bool>(map[nameof(RecalculateTotalPrice)].Column);
                StockKeepingUnit = dataRow.Field<string>(map[nameof(StockKeepingUnit)].Column);
                TaxPolicyID = dataRow.Field<string>(map[nameof(TaxPolicyID)].Column);
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

            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(BillingPolicyID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(CanUseQuantitySchedule)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(CanUseRevenueSchedule)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ConnectionReceivedID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ConnectionSentID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Description)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(DisplayUrl)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ExternalDataSourceID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ExternalID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsActive)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsArchived)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsDeleted)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastReferencedDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastViewedDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Name)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(NumberOfQuantityInstallments)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(NumberOfRevenueInstallments)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ProductCode)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(RecalculateTotalPrice)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(StockKeepingUnit)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(TaxPolicyID)].Column, true));

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
            return Equals(obj as ISalesforceProduct);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ISalesforceProduct obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="ISalesforceProduct"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="ISalesforceProduct"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ISalesforceProduct a, ISalesforceProduct b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals = String.Equals(a.BillingPolicyID, b.BillingPolicyID, StringComparison.InvariantCultureIgnoreCase)
                    && a.CanUseQuantitySchedule.Equals(b.CanUseQuantitySchedule)
                    && a.CanUseRevenueSchedule.Equals(b.CanUseRevenueSchedule)
                    && String.Equals(a.ConnectionReceivedID, b.ConnectionReceivedID, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Description, b.Description, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.DisplayUrl, b.DisplayUrl, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.ExternalDataSourceID, b.ExternalDataSourceID, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.ExternalID, b.ExternalID, StringComparison.InvariantCultureIgnoreCase)
                    && a.IsActive == b.IsActive
                    && a.IsArchived == b.IsArchived
                    && a.IsDeleted == b.IsDeleted
                    && a.LastActivityDate.GetValueOrDefault().Equals(b.LastActivityDate.GetValueOrDefault())
                    && a.LastReferencedDate.GetValueOrDefault().Equals(b.LastReferencedDate.GetValueOrDefault())
                    && a.LastViewedDate.GetValueOrDefault().Equals(b.LastViewedDate.GetValueOrDefault())
                    && String.Equals(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase)
                    && a.NumberOfQuantityInstallments.GetValueOrDefault() == b.NumberOfQuantityInstallments.GetValueOrDefault()
                    && a.NumberOfRevenueInstallments.GetValueOrDefault() == b.NumberOfRevenueInstallments.GetValueOrDefault()
                    && String.Equals(a.ProductCode, b.ProductCode, StringComparison.InvariantCultureIgnoreCase)
                    && a.RecalculateTotalPrice == b.RecalculateTotalPrice
                    && String.Equals(a.StockKeepingUnit, b.StockKeepingUnit, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.TaxPolicyID, b.TaxPolicyID, StringComparison.InvariantCultureIgnoreCase);
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
        public int GetHashCode(ISalesforceProduct obj)
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

            if (!String.IsNullOrWhiteSpace(Name) || !String.IsNullOrWhiteSpace(StockKeepingUnit))
            {
                builder.Append("[");

                if (!String.IsNullOrWhiteSpace(StockKeepingUnit))
                {
                    builder.Append(StockKeepingUnit.Trim());

                    if (!String.IsNullOrWhiteSpace(Name))
                    {
                        builder.Append(" - ");
                    }
                }

                if (!String.IsNullOrWhiteSpace(Name))
                {
                    builder.Append(Name);
                }

                builder.Append("]");
            }
            else
            {
                builder.Append(base.ToString());
            }

            return builder.ToString();
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
