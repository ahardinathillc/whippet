using System;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Directory.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.Directory
{
    /// <summary>
    /// Represents a localized region name in Magento.
    /// </summary>
    public class RegionName : MagentoEntity, IMagentoEntity, IRegionName, IEqualityComparer<IRegionName>, IJsonObject
    {
        private const byte MAX_LEN_NAME = 255;
        private const byte MAX_LEN_LOCALE = 16;

        private bool _initialized;

        private Region _region;

        private RegionNameKey _id;

        private string _name;
        private string _locale;

        /// <summary>
        /// Gets or sets the composite ID of the <see cref="RegionName"/>.
        /// </summary>
        public new virtual RegionNameKey ID
        {
            get
            {
                if (!_initialized)
                {
                    _id = new RegionNameKey(Region, Locale);
                }

                return _id;
            }
            set
            {
                _id = value;
                Region = value.Region.ToRegion();
                Locale = value.Locale;
            }
        }

        /// <summary>
        /// Gets or sets the composite ID of the <see cref="IRegionName"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        RegionNameKey IRegionName.ID
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="RegionName"/> locale.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Locale
        {
            get
            {
                return _locale;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else if (value.Length > MAX_LEN_LOCALE)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                else
                {
                    _locale = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Directory.Region"/> that the <see cref="RegionName"/> is for.
        /// </summary>
        public virtual Region Region
        {
            get
            {
                if (_region == null)
                {
                    _region = new Region();
                }

                return _region;
            }
            set
            {
                _region = value;
            }
        }

        /// <summary>
        /// Gets or sets the ID of <see cref="Region"/>.
        /// </summary>
        protected internal virtual uint RegionID
        {
            get
            {
                return Region.ID;
            }
            set
            {
                Region = new Region(value, Server);
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IRegion"/> that the <see cref="IRegionName"/> is for.
        /// </summary>
        IRegion IRegionName.Region
        {
            get
            {
                return Region;
            }
            set
            {
                Region = value.ToRegion();
            }
        }

        /// <summary>
        /// Gets or sets the region name.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value) && (value.Length > MAX_LEN_NAME))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _name = value;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionName"/> class with no arguments.
        /// </summary>
        public RegionName()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionName"/> class with the specified ID and <see cref="MagentoServer"/>.
        /// </summary>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        public RegionName(MagentoServer server)
            : base(default(uint), server)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionName"/> class with the specified parameters.
        /// </summary>
        /// <param name="locale">Locale (e.g., "en-us").</param>
        /// <param name="region"><see cref="Directory.Region"/> that the name applies to.</param>
        /// <param name="name">Region name.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public RegionName(string locale, Region region, string name, MagentoServer server)
            : this(server)
        {
            Locale = locale;
            Region = region;
            Name = name;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return (obj == null || !(obj is IRegionName)) ? false : Equals(obj as IRegionName);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IRegionName obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IRegionName x, IRegionName y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.Locale, y.Locale, StringComparison.InvariantCultureIgnoreCase)
                    && ((x.Region == null && y.Region == null) || (x.Region != null && x.Region.Equals(y.Region)))
                    && String.Equals(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase);
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
        /// <param name="obj"><see cref="IRegionName"/> object.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IRegionName obj)
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
            return String.IsNullOrWhiteSpace(Name) ? base.ToString() : Name + "{" + Region.ToString() + "}";
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

