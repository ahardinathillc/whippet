using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.EAV;
using Athi.Whippet.Adobe.Magento.EAV.Extensions;
using Athi.Whippet.Adobe.Magento.Taxes.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// <see cref="TaxRate"/> label that is associated to individual <see cref="TaxRate"/> objects and their respective <see cref="Store"/> assignment.
    /// </summary>
    public class TaxRateTitle : MagentoEntity, IMagentoEntity, ITaxRateTitle, IEqualityComparer<ITaxRateTitle>, ICloneable, IWhippetCloneable
    {
        private const byte MAX_LEN_VALUE = 255;

        private string _value;

        private Store _store;
        private TaxRate _rate;

        /// <summary>
        /// Gets or sets the unique ID of the <see cref="TaxRateTitle"/>.
        /// </summary>
        public new int ID
        {
            get
            {
                return Convert.ToInt32(base.ID);
            }
            set
            {
                base.ID = Convert.ToUInt32(value);
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="EAV.Store"/> that the <see cref="TaxRateTitle"/> is assigned to.
        /// </summary>
        public virtual Store Store
        {
            get
            {
                if (_store == null)
                {
                    _store = new Store();
                }

                return _store;
            }
            set
            {
                _store = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IStore"/> that the <see cref="ITaxRateTitle"/> is assigned to.
        /// </summary>
        IStore ITaxRateTitle.Store
        {
            get
            {
                return Store;
            }
            set
            {
                Store = value.ToStore();
            }
        }

        /// <summary>
        /// Gets or sets the unique store ID. Value must be able to be represented as an unsigned 16-bit integer.
        /// </summary>
        /// <exception cref="FormatException" />
        /// <exception cref="OverflowException" />
        [JsonProperty("store_id")]
        public virtual string StoreID
        {
            get
            {
                return Convert.ToString(Store.StoreID);
            }
            set
            {
                Store = new Store();
                Store.Server = Server;
                Store.StoreID = Convert.ToUInt16(value);
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="TaxRate"/> that is associated with the <see cref="EAV.Store"/>.
        /// </summary>
        public virtual TaxRate Rate
        {
            get
            {
                if (_rate == null)
                {
                    _rate = new TaxRate();
                }

                return _rate;
            }
            set
            {
                _rate = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ITaxRate"/> that is associated with the <see cref="IStore"/>.
        /// </summary>
        ITaxRate ITaxRateTitle.Rate
        {
            get
            {
                return Rate;
            }
            set
            {
                Rate = value.ToTaxRate();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="TaxRateTitle"/> value.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        [JsonProperty("value")]
        public virtual string Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value) && (value.Length > MAX_LEN_VALUE))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _value = value;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateTitle"/> class with no arguments.
        /// </summary>
        public TaxRateTitle()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateTitle"/> class with the specified ID and <see cref="MagentoServer"/>.
        /// </summary>
        /// <param name="id">ID of the tax rate title.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        public TaxRateTitle(int id, MagentoServer server)
            : base(Convert.ToUInt32(id), server)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return (obj == null || !(obj is ITaxRateTitle)) ? false : Equals(obj as ITaxRateTitle);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ITaxRateTitle obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ITaxRateTitle x, ITaxRateTitle y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = ((x.Rate == null && y.Rate == null) || (x.Rate != null && x.Rate.Equals(y.Rate)))
                    && ((x.Store == null && y.Store == null) || (x.Store != null && x.Store.Equals(y.Store)))
                    && String.Equals(x.Value, y.Value, StringComparison.InvariantCultureIgnoreCase);
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
        /// <param name="obj"><see cref="ITaxRateTitle"/> object.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ITaxRateTitle obj)
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
            TaxRateTitle obj = new TaxRateTitle();

            obj.ID = ID;
            obj.Rate = Rate.ToTaxRate();
            obj.RestEndpoint = RestEndpoint.Clone<MagentoRestEndpoint>();
            obj.Server = Server.Clone<MagentoServer>();
            obj.Store = Store.Clone<Store>();
            obj.StoreID = StoreID;
            obj.Value = Value;

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
            return String.IsNullOrWhiteSpace(Value) ? base.ToString() : Value + " [" + Store.ToString() + "]";
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