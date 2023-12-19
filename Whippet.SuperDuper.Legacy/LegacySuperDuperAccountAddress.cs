using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.SuperDuper.Data;
using Athi.Whippet.SuperDuper.Legacy.Extensions;

namespace Athi.Whippet.SuperDuper.Legacy
{
    /// <summary>
    /// Represents a <see cref="LegacySuperDuperAccount"/> address in Super Duper legacy applications.
    /// </summary>
    public class LegacySuperDuperAccountAddress : SuperDuperLegacyEntity, IWhippetEntity, ISuperDuperLegacyEntity, ILegacySuperDuperAccountAddress, IEqualityComparer<ILegacySuperDuperAccountAddress>
    {
        private LegacySuperDuperAccount _account;
        private LegacySuperDuperCountry _country;
        
        /// <summary>
        /// Gets or sets the parent <see cref="LegacySuperDuperAccount"/> object the current instance is associated with.
        /// </summary>
        public virtual LegacySuperDuperAccount Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new LegacySuperDuperAccount();
                }

                return _account;
            }
            set
            {
                _account = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent <see cref="ILegacySuperDuperAccount"/> object the current instance is associated with.
        /// </summary>
        ILegacySuperDuperAccount ILegacySuperDuperAccountAddress.Account
        {
            get
            {
                return Account;
            }
            set
            {
                Account = value.ToLegacySuperDuperAccount();
            }
        }
        
        /// <summary>
        /// Gets or sets the last name of the address recipient line.
        /// </summary>
        public virtual string LastName
        { get; set; }
        
        /// <summary>
        /// Gets or sets the first name of the address recipient line.
        /// </summary>
        public virtual string FirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the company of the address recipient line.
        /// </summary>
        public virtual string Company
        { get; set; }

        /// <summary>
        /// Gets or sets the first line of the address.
        /// </summary>
        public virtual string LineOne
        { get; set; }

        /// <summary>
        /// Gets or sets the second line of the address.
        /// </summary>
        public virtual string LineTwo
        { get; set; }

        /// <summary>
        /// Gets or sets the city of the address.
        /// </summary>
        public virtual string City
        { get; set; }

        /// <summary>
        /// Gets or sets the state of the address.
        /// </summary>
        public virtual string State
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code of the address.
        /// </summary>
        public virtual string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="LegacySuperDuperCountry"/> of the address.
        /// </summary>
        public virtual LegacySuperDuperCountry Country
        {
            get
            {
                if (_country == null)
                {
                    _country = new LegacySuperDuperCountry();
                }

                return _country;
            }
            set
            {
                _country = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ILegacySuperDuperCountry"/> of the address.
        /// </summary>
        ILegacySuperDuperCountry ILegacySuperDuperAccountAddress.Country
        {
            get
            {
                return Country;
            }
            set
            {
                Country = value.ToLegacySuperDuperCountry();
            }
        }
        
        /// <summary>
        /// Gets or sets the phone number associated with the address.
        /// </summary>
        public virtual string Phone
        { get; set; }
        
        /// <summary>
        /// Gets or sets the extension for <see cref="Phone"/>.
        /// </summary>
        public virtual string PhoneExtension
        { get; set; }
        
        /// <summary>
        /// Gets or sets the date/time the address was last used for shipping.
        /// </summary>
        public virtual Instant? LastShippingDTTM
        { get; set; }
        
        /// <summary>
        /// Gets or sets the date/time the address was last used for billing.
        /// </summary>
        public virtual Instant? LastBillingDTTM
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="LegacySuperDuperAccountAddress"/> class with no arguments.
        /// </summary>
        public LegacySuperDuperAccountAddress()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="LegacySuperDuperAccountAddress"/> class with the specified entity ID.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        public LegacySuperDuperAccountAddress(int id)
            : base(id)
        { }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(object obj)
        {
            return (obj == null) || !(obj is ILegacySuperDuperAccountAddress) ? false : Equals((ILegacySuperDuperAccountAddress)(obj));
        }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ILegacySuperDuperAccountAddress obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ILegacySuperDuperAccountAddress x, ILegacySuperDuperAccountAddress y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = (((x.Account == null) && (y.Account == null)) || ((x.Account != null) && x.Account.Equals(y.Account)))
                         && String.Equals(x.LastName?.Trim(), y.LastName?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.FirstName?.Trim(), y.FirstName?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.Company?.Trim(), y.Company?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.LineOne?.Trim(), y.LineOne?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.LineTwo?.Trim(), y.LineTwo?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.City?.Trim(), y.City?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.State?.Trim(), y.State?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.PostalCode?.Trim(), y.PostalCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && (((x.Country == null) && (y.Country == null)) || ((x.Country != null) && x.Country.Equals(y.Country)))
                         && String.Equals(x.Phone?.Trim(), y.Phone?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.PhoneExtension?.Trim(), y.PhoneExtension?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.LastShippingDTTM.GetValueOrDefault().Equals(y.LastShippingDTTM.GetValueOrDefault())
                         && x.LastBillingDTTM.GetValueOrDefault().Equals(y.LastBillingDTTM.GetValueOrDefault());
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
            hash.Add(Account);
            hash.Add(LastName);
            hash.Add(FirstName);
            hash.Add(Company);
            hash.Add(LineOne);
            hash.Add(LineTwo);
            hash.Add(City);
            hash.Add(State);
            hash.Add(PostalCode);
            hash.Add(Country);
            hash.Add(Phone);
            hash.Add(PhoneExtension);
            hash.Add(LastShippingDTTM);
            hash.Add(LastBillingDTTM);

            return hash.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get the hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        public virtual int GetHashCode(ILegacySuperDuperAccountAddress obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            return obj.GetHashCode();
        }
    }
}
