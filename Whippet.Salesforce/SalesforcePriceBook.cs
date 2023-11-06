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
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Salesforce
{
    /// <summary>
    /// Represents a price book that contains the list of products that your org sells. 
    /// </summary>
    /// <remarks>See <a href="https://developer.salesforce.com/docs/atlas.en-us.object_reference.meta/object_reference/sforce_api_objects_pricebook2.htm">Pricebook2</a> for more information.</remarks>
    public sealed class SalesforcePriceBook : IWhippetEntityDynamicImportMapper, IWhippetEntityExternalDataRowImportMapper, IWhippetEntity, ISalesforceObject, ISalesforcePriceBook
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
                return SalesforceObjectConstants.Objects.Pricebook;
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
        public SalesforceReference? OwnerID
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
        /// Text description of the price book.
        /// </summary>
        public string Description
        { get; set; }

        /// <summary>
        /// Indicates whether the price book is active (<see langword="true"/>) or not (<see langword="false"/>). Inactive price books are hidden in many areas in the user interface. You can change this field’s value as often as necessary. Label is <strong>Active</strong>.
        /// </summary>
        public bool IsActive
        { get; set; }

        /// <summary>
        /// Indicates whether the price book has been archived (<see langword="true"/>) or not (<see langword="false"/>). This field is read-only.
        /// </summary>
        public bool IsArchived
        { get; set; }

        /// <summary>
        /// Indicates whether the price book has been moved to the Recycle Bin (<see langword="true"/>) or not (<see langword="false"/>). Label is <strong>Deleted></strong>.
        /// </summary>
        public bool IsDeleted
        { get; set; }

        /// <summary>
        /// Indicates whether the price book is the standard price book for the org (<see langword="true"/>) or not (<see langword="false"/>). Every org has one standard price book; all other price books are custom price books.
        /// </summary>
        public bool IsStandard
        { get; set; }

        /// <summary>
        /// Value is one of the following, whichever is the most recent: due date of the most recent event logged against the record, or the due date of the most recently closed task associated with the record.
        /// </summary>
        public Instant? LastActivityDate
        { get; set; }

        /// <summary>
        /// The timestamp for when the current user last viewed a record related to this record.
        /// </summary>
        public Instant? LastReferencedDate
        { get; set; }

        /// <summary>
        /// The timestamp for when the current user last viewed this record. If this value is <see langword="null"/>, it’s possible that this record was referenced (<see cref="LastReferencedDate"/>) and not viewed.
        /// </summary>
        public Instant? LastViewedDate
        { get; set; }

        /// <summary>
        /// Name of this object. This field is read-only for the standard price book. Label is <strong>Price Book Name</strong>.
        /// </summary>
        public string Name
        { get; set; }

        /// <summary>
        /// The date and time when a Commerce price book is valid from. If this field is <see langword="null"/>, the price book is valid from the time it's created.
        /// </summary>
        public Instant? ValidFrom
        { get; set; }

        /// <summary>
        /// The date and time when a Commerce price book is valid to. If this field is <see langword="null"/>, the price book is valid until it's deactivated.
        /// </summary>
        public Instant? ValidTo
        { get; set; }

        /// <summary>
        /// ID of the record type assigned to this object.
        /// </summary>
        public SalesforceReference? RecordTypeID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforcePriceBook"/> class with no arguments.
        /// </summary>
        public SalesforcePriceBook()
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
                new WhippetDataRowImportMapEntry(nameof(Description), SalesforceObjectConstants.Fields.Description),
                new WhippetDataRowImportMapEntry(nameof(IsActive), SalesforceObjectConstants.Fields.IsActive),
                new WhippetDataRowImportMapEntry(nameof(IsArchived), SalesforceObjectConstants.Fields.IsArchived),
                new WhippetDataRowImportMapEntry(nameof(IsDeleted), SalesforceObjectConstants.Fields.IsDeleted),
                new WhippetDataRowImportMapEntry(nameof(IsStandard), SalesforceObjectConstants.Fields.IsStandard),
                new WhippetDataRowImportMapEntry(nameof(LastActivityDate), SalesforceObjectConstants.Fields.LastActivityDate),
                new WhippetDataRowImportMapEntry(nameof(LastReferencedDate), SalesforceObjectConstants.Fields.LastReferencedDate),
                new WhippetDataRowImportMapEntry(nameof(LastViewedDate), SalesforceObjectConstants.Fields.LastViewedDate),
                new WhippetDataRowImportMapEntry(nameof(Name), SalesforceObjectConstants.Fields.Name),
                new WhippetDataRowImportMapEntry(nameof(ValidFrom), SalesforceObjectConstants.Fields.ValidFrom),
                new WhippetDataRowImportMapEntry(nameof(OwnerID), SalesforceObjectConstants.Fields.OwnerId),
                new WhippetDataRowImportMapEntry(nameof(RecordTypeID), SalesforceObjectConstants.Fields.RecordTypeId),
                new WhippetDataRowImportMapEntry(nameof(ValidTo), SalesforceObjectConstants.Fields.ValidTo)
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

                Description = dataRow.Field<string>(map[nameof(Description)].Column);
                IsActive = dataRow.Field<bool>(map[nameof(IsActive)].Column);
                IsArchived = dataRow.Field<bool>(map[nameof(IsArchived)].Column);
                IsDeleted = dataRow.Field<bool>(map[nameof(IsDeleted)].Column);
                IsStandard = dataRow.Field<bool>(map[nameof(IsStandard)].Column);
                LastActivityDate = dataRow.Field<DateTime?>(map[nameof(LastActivityDate)].Column).ToInstant();
                LastReferencedDate = dataRow.Field<DateTime?>(map[nameof(LastReferencedDate)].Column).HasValue ? dataRow.Field<DateTime?>(map[nameof(LastReferencedDate)].Column).ToInstant() : null;
                LastViewedDate = dataRow.Field<DateTime?>(map[nameof(LastViewedDate)].Column).HasValue ? dataRow.Field<DateTime?>(map[nameof(LastViewedDate)].Column).ToInstant() : null;
                Name = dataRow.Field<string>(map[nameof(Name)].Column);
                ValidFrom = dataRow.Field<DateTime?>(map[nameof(ValidFrom)].Column).HasValue ? dataRow.Field<DateTime?>(map[nameof(ValidFrom)].Column).ToInstant() : null;
                ValidTo = dataRow.Field<DateTime?>(map[nameof(ValidTo)].Column).HasValue ? dataRow.Field<DateTime?>(map[nameof(ValidTo)].Column).ToInstant() : null;
                OwnerID = dataRow.Field<string>(map[nameof(OwnerID)].Column);
                RecordTypeID = dataRow.Field<string>(map[nameof(RecordTypeID)].Column);
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

            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Description)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsActive)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsArchived)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsDeleted)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsStandard)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastActivityDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastReferencedDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LastViewedDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Name)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(ValidFrom)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(ValidTo)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OwnerID)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(RecordTypeID)].Column, true));

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
            return Equals(obj as ISalesforcePriceBook);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ISalesforcePriceBook obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="ISalesforcePriceBook"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="ISalesforcePriceBook"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ISalesforcePriceBook a, ISalesforcePriceBook b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals = String.Equals(a.Description, b.Description, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase)
                    && a.LastActivityDate.GetValueOrDefault().Equals(b.LastActivityDate.GetValueOrDefault())
                    && a.LastReferencedDate.GetValueOrDefault().Equals(b.LastReferencedDate.GetValueOrDefault())
                    && a.LastViewedDate.GetValueOrDefault().Equals(b.LastViewedDate.GetValueOrDefault())
                    && String.Equals(a.OwnerID, b.OwnerID, StringComparison.InvariantCultureIgnoreCase)
                    && a.IsDeleted.Equals(b.IsDeleted)
                    && a.ValidFrom.GetValueOrDefault().Equals(b.ValidFrom.GetValueOrDefault())
                    && a.ValidTo.GetValueOrDefault().Equals(b.ValidTo.GetValueOrDefault())
                    && a.IsActive == b.IsActive
                    && a.IsArchived == b.IsArchived
                    && a.IsStandard == b.IsStandard;
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
        public int GetHashCode(ISalesforcePriceBook obj)
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
