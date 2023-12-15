using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager;
using Athi.Whippet.SuperDuper.Data;

namespace Athi.Whippet.SuperDuper.Legacy
{
    /// <summary>
    /// Represents a user account in Super Duper legacy applications. User accounts define both administrators and customers inside of an application.
    /// </summary>
    public interface ILegacySuperDuperAccount : IWhippetEntity, ISuperDuperLegacyEntity, IEqualityComparer<ILegacySuperDuperAccount>
    {
        /// <summary>
        /// Gets or sets the customer number of the account.
        /// </summary>
        int CustomerNumber
        { get; set; }
        
        /// <summary>
        /// Gets or sets the customer's unique identifier as a <see cref="Guid"/>.
        /// </summary>
        Guid UUID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the customer's e-mail.
        /// </summary>
        string Email
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the account was created. 
        /// </summary>
        Instant CreatedDTTM
        { get; set; }
        
        /// <summary>
        /// Specifies whether the account is registered.
        /// </summary>
        bool Registered
        { get; set; }
        
        /// <summary>
        /// Gets or sets the encrypted account password.
        /// </summary>
        byte[] Password
        { get; set; }
        
        /// <summary>
        /// Gets or sets the customer's last name.
        /// </summary>
        string LastName
        { get; set; }
        
        /// <summary>
        /// Gets or sets the customer's first name.
        /// </summary>
        string FirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the account's occupation.
        /// </summary>
        ILegacySuperDuperAccountOccupation SuperDuperAccountOccupation
        { get; set; }
        
        /// <summary>
        /// Gets or sets the password reset ID.
        /// </summary>
        Guid? PasswordResetID
        { get; set; }
        
        /// <summary>
        /// Specifies whether the account is tax-exempt.
        /// </summary>
        bool TaxExempt
        { get; set; }
        
        /// <summary>
        /// Gets or sets the account's corresponding Freestyle Solutions Multichannel Order Manager account.
        /// </summary>
        int? MultichannelOrderManagerAccountID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the account's current session ID.
        /// </summary>
        string SessionID
        { get; set; }        
    }
}
