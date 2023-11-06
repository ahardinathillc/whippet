using System;
using System.ComponentModel;
using System.Text;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.EAV
{
    /// <summary>
    /// Represents a website that is associated with a <see cref="Store"/>.
    /// </summary>
    public class StoreWebsite : MagentoEntity, IMagentoEntity, IStoreWebsite, IEqualityComparer<IStoreWebsite>
    {
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
        public virtual ushort WebsiteID
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
        /// Gets or sets the website code that identifies it in Magento.
        /// </summary>
        public virtual string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the website name.
        /// </summary>
        public virtual string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the sort order of the website.
        /// </summary>
        public virtual ushort SortOrder
        { get; set; }

        /// <summary>
        /// This property is unused.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is not used and is only retained for legacy purposes.", false)]
        public virtual ushort DefaultGroupID
        { get; set; }

        /// <summary>
        /// Indicates whether the website is the default site.
        /// </summary>
        public virtual bool IsDefault
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreWebsite"/> class with no arguments
        /// </summary>
        public StoreWebsite()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreWebsite"/> class with the specified rule ID and <see cref="MagentoServer"/>.
        /// </summary>
        /// <param name="websiteId">Website ID.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        public StoreWebsite(ushort websiteId, MagentoServer server)
            : base(websiteId, server)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return (obj == null || !(obj is IStoreWebsite)) ? false : Equals(obj as IStoreWebsite);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IStoreWebsite obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IStoreWebsite x, IStoreWebsite y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = x.WebsiteID == y.WebsiteID
                    && String.Equals(x.Code, y.Code, StringComparison.InvariantCultureIgnoreCase)
                    && x.DefaultGroupID == y.DefaultGroupID
                    && x.IsDefault == y.IsDefault
                    && String.Equals(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase)
                    && x.SortOrder == y.SortOrder
                    && x.WebsiteID == y.WebsiteID;
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
        /// <param name="obj"><see cref="IStoreWebsite"/> object.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IStoreWebsite obj)
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
            StoreWebsite obj = new StoreWebsite();

            obj.Code = Code;
            obj.DefaultGroupID = DefaultGroupID;
            obj.ID = ID;
            obj.IsDefault = IsDefault;
            obj.Name = Name;
            obj.RestEndpoint = RestEndpoint.Clone<MagentoRestEndpoint>();
            obj.Server = Server.Clone<MagentoServer>();
            obj.SortOrder = SortOrder;
            obj.WebsiteID = WebsiteID;

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
