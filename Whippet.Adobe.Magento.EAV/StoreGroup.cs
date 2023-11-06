using System;
using System.Text;
using System.ComponentModel;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.EAV.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.EAV
{
    /// <summary>
    /// Represents a logical grouping for a <see cref="Store"/>.
    /// </summary>
    public class StoreGroup : MagentoEntity, IMagentoEntity, IStoreGroup, IEqualityComparer<IStoreGroup>, ICloneable, IWhippetCloneable
    {
        private StoreWebsite _website;

        /// <summary>
        /// Gets or sets the unique ID of the <see cref="MagentoEntity"/>.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public override uint ID
        {
            get
            {
                return base.ID;
            }
            set
            {
                if (value > ushort.MaxValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                else
                {
                    base.ID = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the unique website ID.
        /// </summary>
        public virtual ushort GroupID
        {
            get
            {
                return Convert.ToUInt16(ID);
            }
            set
            {
                ID = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="StoreWebsite"/> that is assigned to the group.
        /// </summary>
        public virtual StoreWebsite Website
        {
            get
            {
                if (_website == null)
                {
                    _website = new StoreWebsite();
                }

                return _website;
            }
            set
            {
                _website = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IStoreWebsite"/> that is assigned to the group.
        /// </summary>
        IStoreWebsite IStoreGroup.Website
        {
            get
            {
                return Website;
            }
            set
            {
                Website = value.ToStoreWebsite();
            }
        }

        /// <summary>
        /// Gets or sets the group name.
        /// </summary>
        public virtual string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the group code.
        /// </summary>
        public virtual string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the root category that the group is a child of. Root categories are stored in Magento configuration.
        /// </summary>
        public virtual uint RootCategoryID
        { get; set; }

        /// <summary>
        /// This property is unused.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is not used and is only retained for legacy purposes.", false)]
        public virtual ushort DefaultStoreID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreGroup"/> class with no arguments
        /// </summary>
        public StoreGroup()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreGroup"/> class with the specified rule ID and <see cref="MagentoServer"/>.
        /// </summary>
        /// <param name="websiteId">Group ID.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        public StoreGroup(ushort websiteId, MagentoServer server)
            : base(websiteId, server)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return (obj == null || !(obj is IStoreGroup)) ? false : Equals(obj as IStoreGroup);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IStoreGroup obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IStoreGroup x, IStoreGroup y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = x.GroupID == y.GroupID
                    && String.Equals(x.Code, y.Code, StringComparison.InvariantCultureIgnoreCase)
                    && x.DefaultStoreID == y.DefaultStoreID
                    && String.Equals(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase)
                    && x.RootCategoryID == y.RootCategoryID
                    && ((x.Website == null && y.Website == null) || (x.Website != null && x.Website.Equals(y.Website)));
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
        /// <param name="obj"><see cref="IStoreGroup"/> object.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IStoreGroup obj)
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
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public virtual object Clone()
        {
            StoreGroup obj = new StoreGroup();

            obj.Code = Code;
            obj.DefaultStoreID = DefaultStoreID;
            obj.GroupID = GroupID;
            obj.ID = ID;
            obj.Name = Name;
            obj.RestEndpoint = RestEndpoint.Clone<MagentoRestEndpoint>();
            obj.RootCategoryID = RootCategoryID;
            obj.Server = Server.Clone<MagentoServer>();
            obj.Website = Website.Clone<StoreWebsite>();

            return obj;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object with the optional <see cref="Guid"/> that represents the user ID of the user who instantiated the new instance.
        /// </summary>
        /// <typeparam name="TObject">Type of object to return from the operation.</typeparam>
        /// <param name="createdBy"><see cref="Guid"/> ID of the user who instantiated the new instance.</param>
        /// <returns>Object of type <typeparamref name="TObject"/>.</returns>
        public virtual TObject Clone<TObject>(Guid? createdBy = null)
        {
            return (TObject)(Clone());
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            bool closeBracket = false;

            if (!String.IsNullOrWhiteSpace(Name))
            {
                builder.Append(Name);
            }

            if (!String.IsNullOrWhiteSpace(Code))
            {
                if (!String.IsNullOrWhiteSpace(builder.ToString()))
                {
                    builder.Append("[");
                    closeBracket = true;
                }

                builder.Append(Code);

                if (closeBracket)
                {
                    builder.Append("]");
                }
            }

            return String.IsNullOrWhiteSpace(builder.ToString()) ? base.ToString() : builder.ToString();
        }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be inherited.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public override string ToJson<T>()
        {
            return this.SerializeJson(this);
        }
    }
}
