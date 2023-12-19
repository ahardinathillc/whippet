using System;
using Athi.Whippet.Data;
using Athi.Whippet.SuperDuper.Data;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager;

namespace Athi.Whippet.SuperDuper.Legacy
{
    /// <summary>
    /// Represents a country in the Super Duper legacy framework.
    /// </summary>
    public class LegacySuperDuperCountry : SuperDuperLegacyEntity, IWhippetEntity, ISuperDuperLegacyEntity, ILegacySuperDuperCountry, IEqualityComparer<ILegacySuperDuperCountry>
    {
        /// <summary>
        /// Gets or sets the country name.
        /// </summary>
        public virtual string Name
        { get; set; }
        
        // TODO: Add Country object from MOM project (the new one)
        
        /// <summary>
        /// Gets or sets the three-digit country code that corresponds to a country in Multichannel Order Manager.
        /// </summary>
        protected internal string _MultichannelOrderManagerCode
        { get; set; }
        
        /// <summary>
        /// Gets or sets the PayPal country code of the address.
        /// </summary>
        public virtual string PayPalCode
        { get; set; }
        
        /// <summary>
        /// Specifies whether the country qualifies for free shipping.
        /// </summary>
        public virtual bool FreeShipping
        { get; set; }
        
        /// <summary>
        /// Gets or sets the country's display order.
        /// </summary>
        public virtual int DisplayOrder
        { get; set; }
        
        /// <summary>
        /// Specifies whether the <see cref="LegacySuperDuperCountry"/> is the default option.
        /// </summary>
        public virtual bool IsDefaultSelection
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="LegacySuperDuperCountry"/> class with no arguments.
        /// </summary>
        public LegacySuperDuperCountry()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacySuperDuperCountry"/> class with the specified account ID.
        /// </summary>
        /// <param name="id">Account ID.</param>
        public LegacySuperDuperCountry(int id)
            : base(id)
        { }
        
        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as ILegacySuperDuperCountry);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ILegacySuperDuperCountry obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="ILegacySuperDuperCountry"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="ILegacySuperDuperCountry"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ILegacySuperDuperCountry a, ILegacySuperDuperCountry b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals = String.Equals(a.Name?.Trim(), b.Name?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(a.PayPalCode?.Trim(), b.PayPalCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && a.FreeShipping == b.FreeShipping
                         && a.DisplayOrder == b.DisplayOrder
                         && a.IsDefaultSelection == b.IsDefaultSelection;
            }

            return equals;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(base.GetHashCode());
            hash.Add(Name);
            hash.Add(PayPalCode);
            hash.Add(FreeShipping);
            hash.Add(DisplayOrder);
            hash.Add(IsDefaultSelection);
            
            return hash.ToHashCode();
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual int GetHashCode(ILegacySuperDuperCountry obj)
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
        /// Gets the name of the of the <see cref="ILegacySuperDuperCountry"/> object.
        /// </summary>
        /// <returns>String description of the <see cref="ILegacySuperDuperCountry"/> object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Name) ? base.ToString() : Name;
        }                    
    }
}
