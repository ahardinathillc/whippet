using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.SuperDuper.Data;

namespace Athi.Whippet.SuperDuper.Legacy
{
    /// <summary>
    /// Represents a <see cref="ILegacySuperDuperAccount"/> address in Super Duper legacy applications.
    /// </summary>
    public interface ILegacySuperDuperAccountAddress
    {
        /// <summary>
        /// Gets or sets the parent <see cref="ILegacySuperDuperAccount"/> object the current instance is associated with.
        /// </summary>
        ILegacySuperDuperAccount Account
        { get; set; }
        
        /// <summary>
        /// Gets or sets the last name of the address recipient line.
        /// </summary>
        string LastName
        { get; set; }
        
        /// <summary>
        /// Gets or sets the first name of the address recipient line.
        /// </summary>
        string FirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the company of the address recipient line.
        /// </summary>
        string Company
        { get; set; }

        /// <summary>
        /// Gets or sets the first line of the address.
        /// </summary>
        string LineOne
        { get; set; }

        /// <summary>
        /// Gets or sets the second line of the address.
        /// </summary>
        string LineTwo
        { get; set; }

        /// <summary>
        /// Gets or sets the city of the address.
        /// </summary>
        string City
        { get; set; }

        /// <summary>
        /// Gets or sets the state of the address.
        /// </summary>
        string State
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code of the address.
        /// </summary>
        string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ILegacySuperDuperCountry"/> of the address.
        /// </summary>
        ILegacySuperDuperCountry Country
        { get; set; }
        
        /// <summary>
        /// Gets or sets the phone number associated with the address.
        /// </summary>
        string Phone
        { get; set; }
        
        /// <summary>
        /// Gets or sets the extension for <see cref="Phone"/>.
        /// </summary>
        string PhoneExtension
        { get; set; }
        
        /// <summary>
        /// Gets or sets the date/time the address was last used for shipping.
        /// </summary>
        Instant? LastShippingDTTM
        { get; set; }
        
        /// <summary>
        /// Gets or sets the date/time the address was last used for billing.
        /// </summary>
        Instant? LastBillingDTTM
        { get; set; }        
    }
}
