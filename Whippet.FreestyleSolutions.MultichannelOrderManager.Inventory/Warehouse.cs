using System;
using System.Text;
using NodaTime;
using Athi.Whippet.Collections.Comparers;
using Athi.Whippet.Data;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Data;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Inventory
{
    /// <summary>
    /// Represents a warehouse in the Multichannel Order Manager application.
    /// </summary>
    public class Warehouse : MultichannelOrderManagerAuditableEntity, IMultichannelOrderManagerAuditableEntity, IMultichannelOrderManagerEntity, IWhippetEntity, IWarehouse, IEqualityComparer<IWarehouse>
    {
        /// <summary>
        /// Gets or sets the unique ID of the object.
        /// </summary>
        public new virtual MultichannelOrderManagerEntityKey<int> ID
        {
            get
            {
                return base.ID.ToValue<int>();
            }
            set
            {
                base.ID = new MultichannelOrderManagerEntityKey<int>(value);
            }
        }

        /// <summary>
        /// Gets or sets the warehouse code.
        /// </summary>
        public virtual string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the warehouse description.
        /// </summary>
        public virtual string Description
        { get; set; }

        /// <summary>
        /// Gets or sets the warehouse address.
        /// </summary>
        public virtual MultichannelOrderManagerObjectAddress Address
        { get; set; }

        /// <summary>
        /// Shipping ID/Account for UPS Canada.
        /// </summary>
        public virtual string UPS_Canada_ID
        { get; set; }

        /// <summary>
        /// Shipping ID/Account for UPS.
        /// </summary>
        public virtual string UPS_ID
        { get; set; }

        /// <summary>
        /// Shipping ID/Account for FedEx.
        /// </summary>
        public virtual string FedEx_ID
        { get; set; }

        /// <summary>
        /// Shipping ID/Account for USPS.
        /// </summary>
        public virtual string USPS_ID
        { get; set; }

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
        public virtual string MessageOne
        { get; set; }

        /// <summary>
        /// Message line two to print on receipts.
        /// </summary>
        public virtual string MessageTwo
        { get; set; }

        /// <summary>
        /// For use by M.O.M. internally.
        /// </summary>
        public virtual string AddressID
        { get; set; }

        /// <summary>
        /// Reserved for M.O.M. internal use.
        /// </summary>
        public virtual bool IsPickup
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Warehouse"/> class with no arguments.
        /// </summary>
        public Warehouse()
            : this(new MultichannelOrderManagerEntityKey<int>(default(int)))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Warehouse"/> class with the specified key.
        /// </summary>
        /// <param name="id">ID of the entity to initialize with.</param>
        public Warehouse(IMultichannelOrderManagerEntityKey id)
            : base(id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Warehouse"/> class with the specified key.
        /// </summary>
        /// <param name="id">ID of the entity to initialize with.</param>
        /// <param name="lastAccessed">Date and time the entity was last accessed.</param>
        /// <param name="lastAccessedBy">Username who last accessed the entity.</param>
        public Warehouse(IMultichannelOrderManagerEntityKey id, Instant? lastAccessed, string lastAccessedBy)
            : base(id, lastAccessed, lastAccessedBy)
        { }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IWarehouse);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWarehouse obj)
        {
            return (obj != null) && Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWarehouse x, IWarehouse y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals =
                    String.Equals(x.Code, y.Code, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Description, y.Description, StringComparison.InvariantCultureIgnoreCase)
                    && x.Address.Equals(y.Address)
                    && String.Equals(x.UPS_Canada_ID, y.UPS_Canada_ID, StringComparison.InvariantCultureIgnoreCase)
                    && x.IsRetail == y.IsRetail
                    && x.CustomerNumber == y.CustomerNumber
                    && String.Equals(x.MessageOne, y.MessageOne, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.MessageTwo, y.MessageTwo, StringComparison.InvariantCultureIgnoreCase)
                    && x.IsPickup == y.IsPickup
                    && String.Equals(x.AddressID, y.AddressID, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.UPS_ID, y.UPS_ID, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.FedEx_ID, y.FedEx_ID, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.USPS_ID, y.USPS_ID, StringComparison.InvariantCultureIgnoreCase);
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(base.GetHashCode());
            hash.Add(Code);
            hash.Add(Description);
            hash.Add(Address);
            hash.Add(UPS_Canada_ID);
            hash.Add(IsRetail);
            hash.Add(CustomerNumber);
            hash.Add(MessageOne);
            hash.Add(MessageTwo);
            hash.Add(IsPickup);
            hash.Add(AddressID);
            hash.Add(UPS_ID);
            hash.Add(FedEx_ID);
            hash.Add(USPS_ID);

            return hash.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="IWarehouse"/> object ot get hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(IWarehouse obj)
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
            Warehouse warehouse = new Warehouse();

            warehouse.AddressID = AddressID;
            warehouse.Address = Address;
            warehouse.Code = Code;
            warehouse.CustomerNumber = CustomerNumber;
            warehouse.Description = Description;
            warehouse.FedEx_ID = FedEx_ID;
            warehouse.ID = ID;
            warehouse.IsPickup = IsPickup;
            warehouse.IsRetail = IsRetail;
            warehouse.LastAccessedBy = LastAccessedBy;
            warehouse.LastAccessed = LastAccessed;
            warehouse.MessageOne = MessageOne;
            warehouse.MessageTwo = MessageTwo;
            warehouse.ID = ID;
            warehouse.UPS_Canada_ID = UPS_Canada_ID;
            warehouse.UPS_ID = UPS_ID;
            warehouse.USPS_ID = USPS_ID;

            return warehouse;
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
