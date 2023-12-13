using System;
using System.Text;
using System.Data;
using System.Collections.ObjectModel;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Collections.Comparers;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents a warehouse in the Multichannel Order Management (M.O.M.) system.
    /// </summary>
    public class MultichannelOrderManagerWarehouse : MultichannelOrderManagerEntity, IWhippetEntity, IWhippetEntityExternalDataRowImportMapper, IEqualityComparer<IMultichannelOrderManagerWarehouse>, IMultichannelOrderManagerEntity, IMultichannelOrderManagerWarehouse, IMultichannelOrderManagerLookup, IWhippetEntityDynamicImportMapper, IWhippetCloneable, IComparable<IMultichannelOrderManagerWarehouse>
    {
        private string _code;
        private string _desc;
        private string _address_l1;
        private string _address_l2;
        private string _city;
        private string _state;
        private string _zipCode;
        private string _country;
        private string _upsca_Id;
        private string _message1;
        private string _message2;
        private string _luBy;
        private string _sh_upsId;
        private string _sh_fexId;
        private string _sh_uspId;
        private string _addressId;

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
        /// Gets the external table name or <see langword="null"/> if the data source is not stored in a database. This property is read-only.
        /// </summary>
        protected override string ExternalTableName
        {
            get
            {
                return MultichannelOrderManagerDatabaseConstants.Tables.WAREHOUS;
            }
        }

        /// <summary>
        /// Unique record identifier of the warehouse.
        /// </summary>
        public virtual long WarehouseID
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
        /// Warehouse code.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        public virtual string Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = EnsureLength(value, nameof(Code));
            }
        }

        /// <summary>
        /// Warehouse description.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        public virtual string Description
        {
            get
            {
                return _desc;
            }
            set
            {
                _desc = EnsureLength(value, nameof(Description));
            }
        }

        /// <summary>
        /// First address line.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        public virtual string AddressLineOne
        {
            get
            {
                return _address_l1;
            }
            set
            {
                _address_l1 = EnsureLength(value, nameof(AddressLineOne));
            }
        }

        /// <summary>
        /// Second address line.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        public virtual string AddressLineTwo
        {
            get
            {
                return _address_l2;
            }
            set
            {
                _address_l2 = EnsureLength(value, nameof(AddressLineTwo));
            }
        }

        /// <summary>
        /// Warehouse city.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        public virtual string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = EnsureLength(value, nameof(City));
            }
        }

        /// <summary>
        /// Warehouse state.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        public virtual string State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = EnsureLength(value, nameof(State));
            }
        }

        /// <summary>
        /// Warehouse ZIP code.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        public virtual string ZipCode
        {
            get
            {
                return _zipCode;
            }
            set
            {
                _zipCode = EnsureLength(value, nameof(ZipCode));
            }
        }

        /// <summary>
        /// Country code of the warehouse.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = EnsureLength(value, nameof(Country));
            }
        }

        /// <summary>
        /// Shipping ID/Account for UPS Canada.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string UPS_Canada_ID
        {
            get
            {
                return _upsca_Id;
            }
            set
            {
                _upsca_Id = EnsureLength(value, nameof(UPS_Canada_ID));
            }
        }

        /// <summary>
        /// Shipping ID/Account for UPS.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string UPS_ID
        {
            get
            {
                return _sh_upsId;
            }
            set
            {
                _sh_upsId = EnsureLength(value, nameof(UPS_ID));
            }
        }

        /// <summary>
        /// Shipping ID/Account for FedEx.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string FedEx_ID
        {
            get
            {
                return _sh_fexId;
            }
            set
            {
                _sh_fexId = EnsureLength(value, nameof(FedEx_ID));
            }
        }

        /// <summary>
        /// Shipping ID/Account for USPS.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string USPS_ID
        {
            get
            {
                return _sh_uspId;
            }
            set
            {
                _sh_uspId = EnsureLength(value, nameof(USPS_ID));
            }
        }

        /// <summary>
        /// Indicates if the warehouse is a retail location.
        /// </summary>
        public virtual bool IsRetail
        { get; set; }

        /// <summary>
        /// For use by M.O.M. internally.
        /// </summary>
        public virtual long CustomerNumber
        { get; set; }

        /// <summary>
        /// Message line one to print on receipts.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string MessageOne
        {
            get
            {
                return _message1;
            }
            set
            {
                _message1 = EnsureLength(value, nameof(MessageOne));
            }
        }

        /// <summary>
        /// Message line two to print on receipts.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string MessageTwo
        {
            get
            {
                return _message2;
            }
            set
            {
                _message2 = EnsureLength(value, nameof(MessageTwo));
            }
        }

        /// <summary>
        /// Gets or sets the username of who last accessed the record.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string LookupBy
        {
            get
            {
                return _luBy;
            }
            set
            {
                _luBy = EnsureLength(value, nameof(LookupBy));
            }
        }

        /// <summary>
        /// Gets or sets the date/time the record was last accessed.
        /// </summary>
        public virtual Instant? LookupOn
        { get; set; }

        /// <summary>
        /// For use by M.O.M. internally.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string AddressID
        {
            get
            {
                return _addressId;
            }
            set
            {
                _addressId = EnsureLength(value, nameof(AddressID));
            }
        }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        public virtual bool IsPickup
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerWarehouse"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerWarehouse()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerWarehouse"/> class with the specified warehouse ID.
        /// </summary>
        /// <param name="warehouseId">Warehouse ID to initialize with.</param>
        public MultichannelOrderManagerWarehouse(long warehouseId)
            : this()
        {
            WarehouseID = warehouseId;
        }

        /// <summary>
        /// Creates a <see cref="WhippetDataRowImportMap"/> object that contains a mapping for the current entity.
        /// </summary>
        /// <returns><see cref="WhippetDataRowImportMap"/> object.</returns>
        public override WhippetDataRowImportMap CreateImportMap()
        {
            return new WhippetDataRowImportMap(new[] {
                new WhippetDataRowImportMapEntry(nameof(Code), MultichannelOrderManagerDatabaseConstants.Columns.CODE),
                new WhippetDataRowImportMapEntry(nameof(Description), MultichannelOrderManagerDatabaseConstants.Columns.DESC1),
                new WhippetDataRowImportMapEntry(nameof(AddressLineOne), MultichannelOrderManagerDatabaseConstants.Columns.ADDR),
                new WhippetDataRowImportMapEntry(nameof(AddressLineTwo), MultichannelOrderManagerDatabaseConstants.Columns.ADDR2),
                new WhippetDataRowImportMapEntry(nameof(City), MultichannelOrderManagerDatabaseConstants.Columns.CITY),
                new WhippetDataRowImportMapEntry(nameof(State), MultichannelOrderManagerDatabaseConstants.Columns.STATE),
                new WhippetDataRowImportMapEntry(nameof(ZipCode), MultichannelOrderManagerDatabaseConstants.Columns.ZIPCODE),
                new WhippetDataRowImportMapEntry(nameof(Country), MultichannelOrderManagerDatabaseConstants.Columns.COUNTRY),
                new WhippetDataRowImportMapEntry(nameof(UPS_Canada_ID), MultichannelOrderManagerDatabaseConstants.Columns.UPSCA_ID),
                new WhippetDataRowImportMapEntry(nameof(IsRetail), MultichannelOrderManagerDatabaseConstants.Columns.RETAIL),
                new WhippetDataRowImportMapEntry(nameof(CustomerNumber), MultichannelOrderManagerDatabaseConstants.Columns.CUSTNUM),
                new WhippetDataRowImportMapEntry(nameof(MessageOne), MultichannelOrderManagerDatabaseConstants.Columns.MSG1),
                new WhippetDataRowImportMapEntry(nameof(MessageTwo), MultichannelOrderManagerDatabaseConstants.Columns.MSG2),
                new WhippetDataRowImportMapEntry(nameof(WarehouseID), MultichannelOrderManagerDatabaseConstants.Columns.WAREHOUS_ID),
                new WhippetDataRowImportMapEntry(nameof(LookupBy), MultichannelOrderManagerDatabaseConstants.Columns.LU_BY),
                new WhippetDataRowImportMapEntry(nameof(LookupOn), MultichannelOrderManagerDatabaseConstants.Columns.LU_ON),
                new WhippetDataRowImportMapEntry(nameof(IsPickup), MultichannelOrderManagerDatabaseConstants.Columns.IS_PICKUP),
                new WhippetDataRowImportMapEntry(nameof(AddressID), MultichannelOrderManagerDatabaseConstants.Columns.ADDR_ID),
                new WhippetDataRowImportMapEntry(nameof(UPS_ID), MultichannelOrderManagerDatabaseConstants.Columns.SH_UPS_ID),
                new WhippetDataRowImportMapEntry(nameof(FedEx_ID), MultichannelOrderManagerDatabaseConstants.Columns.SH_FEX_ID),
                new WhippetDataRowImportMapEntry(nameof(USPS_ID), MultichannelOrderManagerDatabaseConstants.Columns.SH_USP_ID)
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
                WhippetDataRowImportMap map = (importMap == null ? CreateImportMap() : importMap);

                Code = dataRow.Field<string>(map[nameof(Code)].Column);
                Description = dataRow.Field<string>(map[nameof(Description)].Column);
                AddressLineOne = dataRow.Field<string>(map[nameof(AddressLineOne)].Column);
                AddressLineTwo = dataRow.Field<string>(map[nameof(AddressLineTwo)].Column);
                City = dataRow.Field<string>(map[nameof(City)].Column);
                State = dataRow.Field<string>(map[nameof(State)].Column);
                ZipCode = dataRow.Field<string>(map[nameof(ZipCode)].Column);
                Country = dataRow.Field<string>(map[nameof(Country)].Column);
                UPS_Canada_ID = dataRow.Field<string>(map[nameof(UPS_Canada_ID)].Column);
                IsRetail = dataRow.Field<bool>(map[nameof(IsRetail)].Column);
                CustomerNumber = dataRow.Field<long>(map[nameof(CustomerNumber)].Column);
                MessageOne = dataRow.Field<string>(map[nameof(MessageOne)].Column);
                MessageTwo = dataRow.Field<string>(map[nameof(MessageTwo)].Column);
                WarehouseID = dataRow.Field<long>(map[nameof(WarehouseID)].Column);
                LookupBy = dataRow.Field<string>(map[nameof(LookupBy)].Column);
                LookupOn = ToNullableInstant(dataRow.Field<DateTime?>(map[nameof(LookupOn)].Column));
                IsPickup = dataRow.Field<bool>(map[nameof(IsPickup)].Column);
                AddressID = dataRow.Field<string>(map[nameof(AddressID)].Column);
                UPS_ID = dataRow.Field<string>(map[nameof(UPS_ID)].Column);
                FedEx_ID = dataRow.Field<string>(map[nameof(FedEx_ID)].Column);
                USPS_ID = dataRow.Field<string>(map[nameof(USPS_ID)].Column);
            }
        }

        /// <summary>
        /// Creates a <see cref="DataTable"/> that represents the database table of the current entity.
        /// </summary>
        /// <returns><see cref="DataTable"/> containing the columns and respective definitions of the associated external database table for the current entity.</returns>
        public override DataTable CreateDataTable()
        {
            WhippetDataRowImportMap map = CreateImportMap();
            DataTable table = new DataTable(((IWhippetEntityExternalDataRowImportMapper)(this)).ExternalTableName);

            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Code)].Column, false, 6));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Description)].Column, false, 30));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(AddressLineOne)].Column, false, 30));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(AddressLineTwo)].Column, false, 30));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(City)].Column, false, 30));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(State)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ZipCode)].Column, false, 10));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Country)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(UPS_Canada_ID)].Column, false, 10));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsRetail)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<long>(map[nameof(CustomerNumber)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(MessageOne)].Column, false, 35));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(MessageTwo)].Column, false, 35));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<long>(map[nameof(WarehouseID)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(LookupBy)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LookupOn)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(IsPickup)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(AddressID)].Column, false, 32));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(UPS_ID)].Column, false, 32));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(FedEx_ID)].Column, false, 32));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(USPS_ID)].Column, false, 32));

            table.PrimaryKey = new[] { table.Columns[map[nameof(WarehouseID)].Column] };

            return table;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IMultichannelOrderManagerWarehouse);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerWarehouse obj)
        {
            return (obj != null) && Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerWarehouse x, IMultichannelOrderManagerWarehouse y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals =
                    String.Equals(x.Code, y.Code, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.Description, y.Description, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.AddressLineOne, y.AddressLineOne, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.AddressLineTwo, y.AddressLineTwo, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.City, y.City, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.State, y.State, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.ZipCode, y.ZipCode, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.Country, y.Country, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.UPS_Canada_ID, y.UPS_Canada_ID, StringComparison.InvariantCultureIgnoreCase)
                        && x.IsRetail == y.IsRetail
                        && x.CustomerNumber == y.CustomerNumber
                        && String.Equals(x.MessageOne, y.MessageOne, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.MessageTwo, y.MessageTwo, StringComparison.InvariantCultureIgnoreCase)
                        && x.IsPickup == y.IsPickup
                        && String.Equals(x.AddressID, y.AddressID, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.UPS_ID, y.UPS_ID, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.FedEx_ID, y.FedEx_ID, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.USPS_ID, y.USPS_ID, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.LookupBy, y.LookupBy, StringComparison.InvariantCultureIgnoreCase)
                        && x.LookupOn.GetValueOrDefault().Equals(y.LookupOn.GetValueOrDefault());
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="IMultichannelOrderManagerWarehouse"/> object ot get hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(IMultichannelOrderManagerWarehouse obj)
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
        /// Creates a duplicate instance of the current object with the optional <see cref="Guid"/> that represents the user ID of the user who instantiated the new instance.
        /// </summary>
        /// <typeparam name="TObject">Type of object to return from the operation.</typeparam>
        /// <param name="createdBy"><see cref="Guid"/> ID of the user who instantiated the new instance.</param>
        /// <returns>Object of type <typeparamref name="TObject"/>.</returns>
        public TObject Clone<TObject>(Guid? createdBy = null)
        {
            return (TObject)(Clone());
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public object Clone()
        {
            MultichannelOrderManagerWarehouse warehouse = new MultichannelOrderManagerWarehouse();

            warehouse.AddressID = AddressID;
            warehouse.AddressLineOne = AddressLineOne;
            warehouse.AddressLineTwo = AddressLineTwo;
            warehouse.City = City;
            warehouse.Code = Code;
            warehouse.Country = Country;
            warehouse.CustomerNumber = CustomerNumber;
            warehouse.Description = Description;
            warehouse.FedEx_ID = FedEx_ID;
            warehouse.ID = ID;
            warehouse.IsPickup = IsPickup;
            warehouse.IsRetail = IsRetail;
            warehouse.LookupBy = LookupBy;
            warehouse.LookupOn = LookupOn;
            warehouse.MessageOne = MessageOne;
            warehouse.MessageTwo = MessageTwo;
            warehouse.MomObjectID = MomObjectID;
            warehouse.Server = Server.Clone<MultichannelOrderManagerServer>();
            warehouse.State = State;
            warehouse.UPS_Canada_ID = UPS_Canada_ID;
            warehouse.UPS_ID = UPS_ID;
            warehouse.USPS_ID = USPS_ID;
            warehouse.WarehouseID = WarehouseID;
            warehouse.ZipCode = ZipCode;

            return warehouse;
        }

        /// <summary>
        /// Compares the current instance to the specified <see cref="IMultichannelOrderManagerWarehouse"/> for determining sort order.
        /// </summary>
        /// <param name="obj"><see cref="IMultichannelOrderManagerWarehouse"/> to compare against.</param>
        /// <returns>A signed integer that indicates the relative values of the current object and <paramref name="obj"/>. Values less than zero indicates that the current object precedes <paramref name="obj"/>; zero indicates that the values are equal; and values greater than zero indicate that the current object follows <paramref name="obj"/>.</returns>
        public virtual int CompareTo(IMultichannelOrderManagerWarehouse obj)
        {
            return CaseInsensitiveStringComparer.Instance.Compare(Code?.Trim(), obj?.Code?.Trim());
        }

        /// <summary>
        /// Returns the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            if (String.IsNullOrWhiteSpace(Code))
            {
                builder.Append(base.ToString());
            }
            else
            {
                builder.Append(Code.Trim());

                if (!String.IsNullOrWhiteSpace(Description))
                {
                    builder.Append(" [");
                    builder.Append(Description.Trim());
                    builder.Append("]");
                }
            }

            return builder.ToString();
        }

    }
}
