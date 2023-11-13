using System;
using System.Text;
using System.Collections.ObjectModel;
using System.Data;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Extensions;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents a customer relationship in the Multichannel Order Manager (M.O.M.) database.
    /// </summary>
    public class MultichannelOrderManagerCustomerRelationship : MultichannelOrderManagerEntity, IWhippetEntity, IMultichannelOrderManagerEntity, IWhippetEntityExternalDataRowImportMapper, IMultichannelOrderManagerCustomerRelationship, IEqualityComparer<IMultichannelOrderManagerCustomerRelationship>
    {
        private MultichannelOrderManagerServer _server;

        private string _desc;

        /// <summary>
        /// Gets or sets the unique ID of the object.
        /// </summary>
        public new long ID
        {
            get
            {
                return MomObjectID;
            }
            set
            {
                MomObjectID = value;
            }
        }

        /// <summary>
        /// Gets or sets the unique ID of the relationship.
        /// </summary>
        public virtual long RelationshipId
        {
            get
            {
                return base.MomObjectID;
            }
            set
            {
                base.MomObjectID = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent ID of the <see cref="MultichannelOrderManagerCustomer"/> object.
        /// </summary>
        public virtual long ParentCustomerId
        { get; set; }

        /// <summary>
        /// Gets or sets the child ID of the <see cref="MultichannelOrderManagerCustomer"/> object.
        /// </summary>
        public virtual long ChildCustomerId
        { get; set; }

        /// <summary>
        /// Specifies the relationship type.
        /// </summary>
        public virtual MultichannelOrderManagerCustomerRelationshipType RelationshipType
        { get; set; }

        /// <summary>
        /// Gets or sets the description of the relationship.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Description
        {
            get
            {
                return _desc;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Description)].Column);
                _desc = value;
            }
        }

        /// <summary>
        /// Gets the external table name or <see langword="null"/> if the data source is not stored in a database. This property is read-only.
        /// </summary>
        protected override string ExternalTableName
        {
            get
            {
                return MultichannelOrderManagerDatabaseConstants.Tables.CUSTRELA;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCustomerRelationship"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerCustomerRelationship()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCustomerRelationship"/> with the specified ID.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        public MultichannelOrderManagerCustomerRelationship(Guid id)
            : base(id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCustomerRelationship"/> with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="customerRelationshipId">Customer relationship ID.</param>
        /// <param name="parentCustomerId">Parent <see cref="MultichannelOrderManagerCustomer"/> ID.</param>
        /// <param name="childCustomerId">Child <see cref="MultichannelOrderManagerCustomer"/> ID.</param>
        /// <param name="relationshipType">Relationship type.</param>
        /// <param name="description">Description of the relationship.</param>
        public MultichannelOrderManagerCustomerRelationship(Guid id, long customerRelationshipId, long parentCustomerId, long childCustomerId, MultichannelOrderManagerCustomerRelationshipType relationshipType, string description)
            : this(id)
        {
            MomObjectID = customerRelationshipId;
            ParentCustomerId = parentCustomerId;
            ChildCustomerId = childCustomerId;
            RelationshipType = relationshipType;
            Description = description;
        }

        /// <summary>
        /// Creates a <see cref="WhippetDataRowImportMap"/> object that contains a mapping for the current entity.
        /// </summary>
        /// <returns><see cref="WhippetDataRowImportMap"/> object.</returns>
        public override WhippetDataRowImportMap CreateImportMap()
        {
            WhippetDataRowImportMapEntry customerRelationshipId = new WhippetDataRowImportMapEntry(nameof(RelationshipId), MultichannelOrderManagerDatabaseConstants.Columns.CUSTRELA_ID);
            WhippetDataRowImportMapEntry relationshipType = new WhippetDataRowImportMapEntry(nameof(RelationshipType), MultichannelOrderManagerDatabaseConstants.Columns.RELA_TYPE);
            WhippetDataRowImportMapEntry customerNumber = new WhippetDataRowImportMapEntry(nameof(ChildCustomerId), MultichannelOrderManagerDatabaseConstants.Columns.CUSTNUM);
            WhippetDataRowImportMapEntry parentCustomerNumber = new WhippetDataRowImportMapEntry(nameof(ParentCustomerId), MultichannelOrderManagerDatabaseConstants.Columns.BELONGNUM);
            WhippetDataRowImportMapEntry description = new WhippetDataRowImportMapEntry(nameof(Description), MultichannelOrderManagerDatabaseConstants.Columns.DESC1);

            return new WhippetDataRowImportMap(new[]
            {
                customerRelationshipId,
                relationshipType,
                customerNumber,
                parentCustomerNumber,
                description
            });
        }

        /// <summary>
        /// Imports the specified <see cref="DataRow"/> containing the information needed to populate the <see cref="IWhippetEntity"/>. This method must be overridden.
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> containing the data to import.</param>
        /// <param name="importMap">External <see cref="WhippetDataRowImportMap"/>. If <see langword="null"/>, then the one generated by <see cref="CreateImportMap"/> will be used.</param>
        /// <exception cref="ArgumentNullException" />
        public override void ImportDataRow(DataRow dataRow, WhippetDataRowImportMap importMap = null)
        {
            if (dataRow == null)
            {
                throw new ArgumentNullException(nameof(dataRow));
            }
            else
            {
                MultichannelOrderManagerCustomerRelationshipType rt = default(MultichannelOrderManagerCustomerRelationshipType);
                WhippetDataRowImportMap map = (importMap == null ? CreateImportMap() : importMap);

                MomObjectID = dataRow.Field<long>(map[nameof(RelationshipId)].Column);
                RelationshipType = rt.ParseFieldValue(dataRow.Field<char>(map[nameof(RelationshipType)].Column));
                ParentCustomerId = dataRow.Field<long>(map[nameof(ParentCustomerId)].Column);
                Description = dataRow.Field<string>(map[nameof(Description)].Column);
                ChildCustomerId = dataRow.Field<long>(map[nameof(ChildCustomerId)].Column);
            }
        }

        /// <summary>
        /// Creates a <see cref="DataTable"/> that represents the database table of the current entity.
        /// </summary>
        /// <returns><see cref="DataTable"/> containing the columns and respective definitions of the associated external database table for the current entity.</returns>
        public override DataTable CreateDataTable()
        {
            WhippetDataRowImportMap map = CreateImportMap();
            DataTable table = new DataTable();

            DataColumn parentCustomerId = DataColumnFactory.CreateDataColumn(map[nameof(ParentCustomerId)].Column, typeof(long), false);
            DataColumn relationshipType = DataColumnFactory.CreateDataColumn(map[nameof(RelationshipType)].Column, typeof(char), false);
            DataColumn childCustomerId = DataColumnFactory.CreateDataColumn(map[nameof(ChildCustomerId)].Column, typeof(long), false); 
            DataColumn description = DataColumnFactory.CreateDataColumn(map[nameof(Description)].Column, typeof(string), false, 40);
            DataColumn relationshipId = DataColumnFactory.CreateDataColumn(map[nameof(RelationshipId)].Column, typeof(long), false);

            table.Columns.AddRange(new[]
            {
                parentCustomerId,
                relationshipType,
                childCustomerId,
                description,
                relationshipId
            });

            table.PrimaryKey = new[] { table.Columns[map[nameof(RelationshipId)].Column] };

            return table;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IMultichannelOrderManagerCustomerRelationship);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerCustomerRelationship obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IMultichannelOrderManagerCustomerRelationship"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IMultichannelOrderManagerCustomerRelationship"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerCustomerRelationship a, IMultichannelOrderManagerCustomerRelationship b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals =
                    a.Server.Equals(b.Server)
                        && a.ChildCustomerId == b.ChildCustomerId
                        && String.Equals(a.Description, b.Description, StringComparison.InvariantCultureIgnoreCase)
                        && a.ParentCustomerId == b.ParentCustomerId
                        && a.RelationshipType == b.RelationshipType;
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
        public virtual int GetHashCode(IMultichannelOrderManagerCustomerRelationship obj)
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
            return "[Parent: " + ParentCustomerId + " | Child: " + ChildCustomerId + "]";
        }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be overridden.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public override string ToJson<T>()
        {
            return this.SerializeJson(this);
        }
    }
}
