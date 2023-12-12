using System;
using System.ComponentModel;
using System.Text;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.SuperDuper.Data;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager;

namespace Athi.Whippet.SuperDuper.Legacy
{
    /// <summary>
    /// Represents a user account in Super Duper legacy applications. User accounts define both administrators and customers inside of an application.
    /// </summary>
    public class SuperDuperAccount : SuperDuperLegacyEntity, IWhippetEntity, ISuperDuperLegacyEntity, ISuperDuperAccount, IEqualityComparer<ISuperDuperAccount>
    {
        /// <summary>
        /// Gets or sets the customer number of the account.
        /// </summary>
        public virtual int CustomerNumber
        { get; set; }
        
        /// <summary>
        /// Gets or sets the customer's unique identifier as a <see cref="Guid"/>.
        /// </summary>
        public virtual Guid UUID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the customer's e-mail.
        /// </summary>
        public virtual string Email
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the account was created. 
        /// </summary>
        public virtual Instant CreatedDTTM
        { get; set; }
        
        /// <summary>
        /// Specifies whether the account is registered.
        /// </summary>
        public virtual bool Registered
        { get; set; }
        
        /// <summary>
        /// Gets or sets the encrypted account password.
        /// </summary>
        public virtual byte[] Password
        { get; set; }
        
        /// <summary>
        /// Gets or sets the customer's last name.
        /// </summary>
        public virtual string LastName
        { get; set; }
        
        /// <summary>
        /// Gets or sets the customer's first name.
        /// </summary>
        public virtual string FirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the account's occupation.
        /// </summary>
        public virtual SuperDuperAccountOccupation Occupation
        { get; set; }
        
        /// <summary>
        /// Gets or sets the password reset ID.
        /// </summary>
        public virtual Guid? PasswordResetID
        { get; set; }
        
        /// <summary>
        /// This property is no longer used.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int? SpecialPriceID
        { get; set; }
        
        /// <summary>
        /// This property is no longer used.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Guid? WishlistID
        { get; set; }
        
        /// <summary>
        /// This property is no longer used.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual string CompanyCode
        { get; set; }

        /// <summary>
        /// This property is no longer used.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual string CPACS
        { get; set; }
        
        /// <summary>
        /// This property is no longer used.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual string CAAP
        { get; set; }
        
        /// <summary>
        /// This property is no longer used.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Instant? ShoppingCart_Abandonment_Email_Sent
        { get; set; }
        
        /// <summary>
        /// This property is no longer used.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual string TesterProjects
        { get; set; }
        
        /// <summary>
        /// Specifies whether the account is tax-exempt.
        /// </summary>
        public virtual bool TaxExempt
        { get; set; }
        
        /// <summary>
        /// Gets or sets the account's corresponding Freestyle Solutions Multichannel Order Manager account.
        /// </summary>
        public virtual int? MultichannelOrderManagerAccountID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the account's current session ID.
        /// </summary>
        public virtual string SessionID
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SuperDuperAccount"/> class with no arguments.
        /// </summary>
        public SuperDuperAccount()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SuperDuperAccount"/> class with the specified account ID.
        /// </summary>
        /// <param name="id">Account ID.</param>
        public SuperDuperAccount(int id)
            : base(id)
        { }
        
        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as ISuperDuperAccount);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ISuperDuperAccount obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="ISuperDuperAccount"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="ISuperDuperAccount"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ISuperDuperAccount a, ISuperDuperAccount b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals = a.CustomerNumber == b.CustomerNumber
                         && a.UUID == b.UUID
                         && String.Equals(a.Email?.Trim(), b.Email?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && a.CreatedDTTM.Equals(b.CreatedDTTM)
                         && a.Registered == b.Registered
                         && (((a.Password == null) && (b.Password == null)) || ((a.Password != null) && a.Password.SequenceEqual(b.Password)))
                         && String.Equals(a.LastName?.Trim(), b.LastName?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(a.FirstName?.Trim(), b.FirstName?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && (((a.Occupation == null) && (b.Occupation == null)) || ((a.Occupation != null) && a.Occupation.Equals(b.Occupation)))
                         && a.PasswordResetID.GetValueOrDefault().Equals(b.PasswordResetID.GetValueOrDefault())
                         && a.TaxExempt == b.TaxExempt
                         && a.MultichannelOrderManagerAccountID == b.MultichannelOrderManagerAccountID
                         && String.Equals(a.SessionID?.Trim(), b.SessionID?.Trim(), StringComparison.InvariantCultureIgnoreCase);
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
            hash.Add(CustomerNumber);
            hash.Add(UUID);
            hash.Add(Email);
            hash.Add(Registered);
            hash.Add(CreatedDTTM);
            hash.Add(Password);
            hash.Add(LastName);
            hash.Add(FirstName);
            hash.Add(Occupation);
            hash.Add(PasswordResetID);
            hash.Add(TaxExempt);
            hash.Add(MultichannelOrderManagerAccountID);
            hash.Add(SessionID);

            return hash.ToHashCode();
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual int GetHashCode(ISuperDuperAccount obj)
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
        /// Gets the name of the of the <see cref="ISuperDuperAccount"/> object.
        /// </summary>
        /// <returns>String description of the <see cref="ISuperDuperAccount"/> object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            if (String.IsNullOrWhiteSpace(FirstName) || String.IsNullOrWhiteSpace(LastName))
            {
                if (CustomerNumber > 0)
                {
                    builder.Append(CustomerNumber);
                }
                else
                {
                    builder.Append(base.ToString());
                }
            }
            else
            {
                builder.Append(FirstName + " " + LastName);
            }

            return builder.ToString();
        }            
    }
}
