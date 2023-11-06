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
using Athi.Whippet.Data;
using Athi.Whippet.Salesforce.Extensions;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents a product entry (an association between a <see cref="SalesforcePriceBook"/> and <see cref="SalesforceProduct"/>) in a price book.
    /// </summary>
    /// <remarks>See <a href="https://developer.salesforce.com/docs/atlas.en-us.object_reference.meta/object_reference/sforce_api_objects_pricebookentry.htm">PricebookEntry</a> for more information.</remarks>
    public sealed class SalesforcePriceBookEntry : IWhippetEntityDynamicImportMapper, IWhippetEntityExternalDataRowImportMapper, IWhippetEntity, ISalesforceObject, ISalesforcePriceBookEntry
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
                return SalesforceObjectConstants.Objects.PricebookEntry;
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
        /// <exception cref="FormatException" />
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
        /// The count of active price adjustment schedules associated with the price book entry.
        /// </summary>
        public int? ActivePriceAdjustmentQuantity
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
        /// ID of the <see cref="SalesforcePriceBook"/> record with which this record is associated.
        /// </summary>
        public SalesforceReference PriceBookID
        { get; set; }

        /// <summary>
        /// ID of the <see cref="SalesforceProduct"/> record with which this record is associated.
        /// </summary>
        public SalesforceReference ProductID
        { get; set; }

        /// <summary>
        /// Product code for the record. References the <see cref="SalesforceProduct.ProductCode"/> value.
        /// </summary>
        public string ProductCode
        { get; set; }

        /// <summary>
        /// The ID of the related product selling model. This field is available when Subscription Management is enabled.
        /// </summary>
        public SalesforceReference ProductSellingModelID
        { get; set; }

        /// <summary>
        /// Unit price for this price book entry. A value can be specified only if <see cref="UseStandardPrice"/> is set to <see langword="false"/>. Label is <strong>List Price</strong>.
        /// </summary>
        public decimal UnitPrice
        { get; set; }

        /// <summary>
        /// Indicates whether this price book entry uses the standard price defined in the standard <see cref="SalesforcePriceBook"/> record (<see langword="true"/>) or not (<see langword="false"/>). If set to <see langword="true"/>, then the <see cref="UnitPrice"/> field is
        /// read-only, and the value is the same as the <see cref="UnitPrice"/> value in the corresponding <see cref="SalesforcePriceBookEntry"/> in the standard price book (that is, the <see cref="SalesforcePriceBookEntry"/> record whose
        /// <see cref="PriceBookID"/> refers to the standard price book and whose <see cref="ProductID"/> and <strong>CurrencyIsoCode</strong> are the same as this record). For <see cref="SalesforcePriceBookEntry"/> records associated with the standard
        /// <see cref="SalesforcePriceBook"/> record, this field must be set to <see langword="true"/>.
        /// </summary>
        public bool UseStandardPrice
        { get; set; }

        /// <summary>
        /// The timestamp for when the current user last viewed a record related to this record.
        /// </summary>
        Instant? ISalesforceObject.LastReferencedDate
        { get; set; }

        /// <summary>
        /// The timestamp for when the current user last viewed this record. If this value is null, this record might only have been referenced (<see cref="LastReferencedDate"/>) and not viewed.
        /// </summary>
        Instant? ISalesforceObject.LastViewedDate
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforcePriceBookEntry"/> class with no arguments.
        /// </summary>
        public SalesforcePriceBookEntry()
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
                new WhippetDataRowImportMapEntry(nameof(ActivePriceAdjustmentQuantity), SalesforceObjectConstants.Fields.ActivePriceAdjustmentQuantity),
                new WhippetDataRowImportMapEntry(nameof(IsActive), SalesforceObjectConstants.Fields.IsActive),
                new WhippetDataRowImportMapEntry(nameof(IsArchived), SalesforceObjectConstants.Fields.IsArchived),
                new WhippetDataRowImportMapEntry(nameof(Name), SalesforceObjectConstants.Fields.Name),
                new WhippetDataRowImportMapEntry(nameof(PriceBookID), SalesforceObjectConstants.Fields.Pricebook2Id),
                new WhippetDataRowImportMapEntry(nameof(ProductID), SalesforceObjectConstants.Fields.Product2Id),
                new WhippetDataRowImportMapEntry(nameof(ProductCode), SalesforceObjectConstants.Fields.ProductCode),
                new WhippetDataRowImportMapEntry(nameof(ProductSellingModelID), SalesforceObjectConstants.Fields.ProductSellingModelId),
                new WhippetDataRowImportMapEntry(nameof(UnitPrice), SalesforceObjectConstants.Fields.UnitPrice),
                new WhippetDataRowImportMapEntry(nameof(UseStandardPrice), SalesforceObjectConstants.Fields.UseStandardPrice),
                new WhippetDataRowImportMapEntry(nameof(ObjectID), SalesforceObjectConstants.Fields.PricebookEntryId)
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

                ActivePriceAdjustmentQuantity = dataRow.Field<int?>(map[nameof(ActivePriceAdjustmentQuantity)].Column);
                IsActive = dataRow.Field<bool>(map[nameof(IsActive)].Column);
                IsArchived = dataRow.Field<bool>(map[nameof(IsArchived)].Column);
                Name = dataRow.Field<string>(map[nameof(Name)].Column);
                PriceBookID = dataRow.Field<string>(map[nameof(PriceBookID)].Column);
                ProductID = dataRow.Field<string>(map[nameof(ProductID)].Column);
                ProductCode = dataRow.Field<string>(map[nameof(ProductCode)].Column);
                ProductSellingModelID = dataRow.Field<string>(map[nameof(ProductSellingModelID)].Column);
                UnitPrice = dataRow.Field<decimal>(map[nameof(UnitPrice)].Column);
                UseStandardPrice = dataRow.Field<bool>(map[nameof(UseStandardPrice)].Column);
                ObjectID = dataRow.Field<string>(map[nameof(ObjectID)].Column);
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

            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ObjectID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(ActivePriceAdjustmentQuantity)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsActive)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsArchived)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Name)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PriceBookID)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ProductID)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ProductCode)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ProductSellingModelID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(UnitPrice)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(UseStandardPrice)].Column, false));

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
            return Equals(obj as ISalesforcePriceBookEntry);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ISalesforcePriceBookEntry obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="ISalesforcePriceBookEntry"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="ISalesforcePriceBookEntry"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ISalesforcePriceBookEntry a, ISalesforcePriceBookEntry b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals = a.ActivePriceAdjustmentQuantity == b.ActivePriceAdjustmentQuantity
                    && a.IsActive == b.IsActive
                    && a.IsArchived == b.IsArchived
                    && String.Equals(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.PriceBookID, b.PriceBookID, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.ProductID, b.ProductID, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.ProductCode, b.ProductCode, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.ProductSellingModelID, b.ProductSellingModelID, StringComparison.InvariantCultureIgnoreCase)
                    && a.UnitPrice == b.UnitPrice
                    && a.UseStandardPrice == b.UseStandardPrice;
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
        public int GetHashCode(ISalesforcePriceBookEntry obj)
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
