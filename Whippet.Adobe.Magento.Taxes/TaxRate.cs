using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Directory;
using Athi.Whippet.Adobe.Magento.Directory.Extensions;
using Athi.Whippet.Adobe.Magento.Taxes.Extensions;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// Represents a tax rate in Magento.
    /// </summary>
    public class TaxRate : MagentoRestEntity<TaxRateInterface>, IMagentoEntity, ITaxRate, IEqualityComparer<ITaxRate>, IMagentoRestEntity<TaxRateInterface>, IMagentoRestEntity
    {
        private Country _country;
        private Region _region;
        
        /// <summary>
        /// Gets or sets the tax rate's parent country.
        /// </summary>
        public virtual Country Country
        {
            get
            {
                if (_country == null)
                {
                    _country = new Country();
                }

                return _country;
            }
            set
            {
                _country = value;
            }
        }

        /// <summary>
        /// Gets or sets the tax rate's parent country.
        /// </summary>
        ICountry ITaxRate.Country
        {
            get
            {
                return Country;
            }
            set
            {
                Country = value.ToCountry();
            }
        }

        /// <summary>
        /// Gets or sets the tax rate's region.
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
        /// Gets or sets the tax rate's region.
        /// </summary>
        IRegion ITaxRate.Region
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
        /// Gets or sets the tax rate's applicable postal code.
        /// </summary>
        public virtual string PostalCode
        { get; set; }
        
        /// <summary>
        /// Specifies whether the tax rate applies to a range of postal codes.
        /// </summary>
        public virtual bool PostalCodeIsRange
        { get; set; }

        /// <summary>
        /// Gets or sets the lower bound of the <see cref="PostalCode"/> range.
        /// </summary>
        public virtual int? PostalCodeLowerBound
        { get; set; }

        /// <summary>
        /// Gets or sets the upper bound of the <see cref="PostalCode"/> range.
        /// </summary>
        public virtual int? PostalCodeUpperBound
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rate percentage.
        /// </summary>
        public virtual decimal Rate
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rate code.
        /// </summary>
        public virtual string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rate titles.
        /// </summary>
        public virtual IEnumerable<TaxRateTitle> Titles
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rate titles.
        /// </summary>
        IEnumerable<ITaxRateTitle> ITaxRate.Titles
        {
            get
            {
                return (Titles == null) ? null : Titles.Select(t => t);
            }
            set
            {
                if (value == null)
                {
                    Titles = null;
                }
                else
                {
                    Titles = value.Select(t => t.ToTaxRateTitle());
                }
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRate"/> class with no arguments.
        /// </summary>
        public TaxRate()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRate"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public TaxRate(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRate"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public TaxRate(TaxRateInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ITaxRate)) ? false : Equals((ITaxRate)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ITaxRate obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ITaxRate x, ITaxRate y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = (((x.Titles == null) && (y.Titles == null)) || ((x.Titles) != null && x.Titles.SequenceEqual(y.Titles)))
                         && (x.PostalCodeIsRange == y.PostalCodeIsRange)
                         && (((x.Region == null) && (y.Region == null)) || ((x.Region) != null && x.Region.Equals(y.Region)))
                         && String.Equals(x.Code?.Trim(), y.Code?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && (((x.Country == null) && (y.Country == null)) || ((x.Country) != null && x.Country.Equals(y.Country)))
                         && (x.Rate == y.Rate)
                         && String.Equals(x.PostalCode?.Trim(), y.PostalCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.PostalCodeLowerBound.GetValueOrDefault().Equals(y.PostalCodeLowerBound.GetValueOrDefault())
                         && x.PostalCodeUpperBound.GetValueOrDefault().Equals(y.PostalCodeUpperBound.GetValueOrDefault());
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="TaxRateInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="TaxRateInterface"/>.</returns>
        public override TaxRateInterface ToInterface()
        {
            TaxRateInterface taxInterface = new TaxRateInterface();
            taxInterface.ID = ID;
            taxInterface.Code = Code;
            taxInterface.Titles = (Titles == null) ? null : Titles.Select(t => t.ToInterface()).ToArray();
            taxInterface.Region = Convert.ToInt32(Region.ID);
            taxInterface.Country = Country.ID;
            taxInterface.Rate = Rate;
            taxInterface.PostalCode = PostalCode;
            taxInterface.RegionName = Region.Name;
            taxInterface.PostalCodeFrom = PostalCodeLowerBound.GetValueOrDefault();
            taxInterface.PostalCodeTo = PostalCodeUpperBound.GetValueOrDefault();
            taxInterface.PostalCodeIsRange = PostalCodeIsRange.ToMagentoBoolean();
            
            return taxInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            TaxRate taxRate = new TaxRate();

            taxRate.Rate = Rate;
            taxRate.RestEndpoint = RestEndpoint.Clone<MagentoRestEndpoint>();
            taxRate.PostalCode = PostalCode;
            taxRate.Code = Code;
            taxRate.Country = Country.Clone<Country>();
            taxRate.Region = Region.Clone<Region>();
            taxRate.Titles = (Titles == null) ? null : new ReadOnlyCollection<TaxRateTitle>(Titles.Select(t => t.Clone<TaxRateTitle>()).ToList());
            taxRate.PostalCodeIsRange = PostalCodeIsRange;
            taxRate.PostalCodeLowerBound = PostalCodeLowerBound;
            taxRate.PostalCodeUpperBound = PostalCodeUpperBound;
            taxRate.Server = Server.Clone<MagentoServer>();
            taxRate.ID = ID;
            
            return taxRate;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(ID);
            hash.Add(Rate);
            hash.Add(PostalCode);
            hash.Add(Code);
            hash.Add(Country);
            hash.Add(Region);
            hash.Add(Titles);
            hash.Add(PostalCodeIsRange);
            hash.Add(PostalCodeLowerBound);
            hash.Add(PostalCodeUpperBound);
            
            return hash.ToHashCode();
        }

        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(TaxRateInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                PostalCode = model.PostalCode;
                Code = model.Code;
                Country = new Country() { ID = model.Country };
                Region = new Region() { ID = model.Region };
                Titles = (model.Titles == null) ? null : model.Titles.Select(t => new TaxRateTitle(t));
                PostalCodeIsRange = model.PostalCodeIsRange.FromMagentoBoolean();
                PostalCodeLowerBound = (model.PostalCodeFrom > 0) ? model.PostalCodeFrom : null;
                PostalCodeUpperBound = (model.PostalCodeTo > 0) ? model.PostalCodeTo : null;
                Rate = model.Rate;
            }
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="taxRate"><see cref="ITaxRate"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ITaxRate taxRate)
        {
            ArgumentNullException.ThrowIfNull(taxRate);
            return taxRate.GetHashCode();
        }
        
        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Code) ? base.ToString() : Code;
        }
    }
}
