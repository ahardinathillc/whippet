using System;
using System.Text;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.EAV.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.EAV
{
    /// <summary>
    /// Represents an individual store in Magento.
    /// </summary>
    public class Store : MagentoEntity, IMagentoEntity, IStore, IEqualityComparer<IStore>, IWhippetActiveEntity, ICloneable, IWhippetCloneable
    {
        private StoreWebsite _website;
        private StoreGroup _group;

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
        /// Gets or sets the unique store ID.
        /// </summary>
        public virtual ushort StoreID
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
        /// Gets or sets the store code that identifies it in Magento.
        /// </summary>
        public virtual string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the website associated with the store.
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
        /// Gets or sets the website associated with the store.
        /// </summary>
        IStoreWebsite IStore.Website
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
        /// Gets or sets the group the store belongs to.
        /// </summary>
        public virtual StoreGroup Group
        {
            get
            {
                if (_group == null)
                {
                    _group = new StoreGroup();
                }

                return _group;
            }
            set
            {
                _group = value;
            }
        }

        /// <summary>
        /// Gets or sets the group the store belongs to.
        /// </summary>
        IStoreGroup IStore.Group
        {
            get
            {
                return Group;
            }
            set
            {
                Group = value.ToStoreGroup();
            }
        }

        /// <summary>
        /// Gets or sets the store name.
        /// </summary>
        public virtual string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the store sort order.
        /// </summary>
        public virtual ushort SortOrder
        { get; set; }

        /// <summary>
        /// Specifies whether the store is currently active.
        /// </summary>
        public virtual bool Active
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Store"/> class with no arguments.
        /// </summary>
        public Store()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Store"/> class with the specified rule ID and <see cref="MagentoServer"/>.
        /// </summary>
        /// <param name="ruleId">Rule ID.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        public Store(uint ruleId, MagentoServer server)
            : base(ruleId, server)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return (obj == null || !(obj is IStore)) ? false : Equals(obj as IStore);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IStore obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IStore x, IStore y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.Code, y.Code, StringComparison.InvariantCultureIgnoreCase)
                    && ((x.Group == null && y.Group == null) || (x.Group != null && x.Group.Equals(y.Group)))
                    && String.Equals(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase)
                    && x.SortOrder == y.SortOrder
                    && x.StoreID == y.StoreID
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
        /// <param name="obj"><see cref="IStore"/> object.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IStore obj)
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
            Store obj = new Store();

            obj.Active = Active;
            obj.Code = Code;
            obj.Group = Group.Clone<StoreGroup>();
            obj.ID = ID;
            obj.Name = Name;
            obj.RestEndpoint = RestEndpoint.Clone<MagentoRestEndpoint>();
            obj.Server = Server.Clone<MagentoServer>();
            obj.SortOrder = SortOrder;
            obj.StoreID = StoreID;
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
