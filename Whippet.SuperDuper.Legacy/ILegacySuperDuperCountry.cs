using System;
using Athi.Whippet.Data;
using Athi.Whippet.SuperDuper.Data;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager;

namespace Athi.Whippet.SuperDuper.Legacy
{
    /// <summary>
    /// Represents a country in the Super Duper legacy framework.
    /// </summary>
    public interface ILegacySuperDuperCountry : IWhippetEntity, ISuperDuperLegacyEntity, IEqualityComparer<ILegacySuperDuperCountry>
    {
        /// <summary>
        /// Gets or sets the country name.
        /// </summary>
        string Name
        { get; set; }
        
        // TODO: Add Country object from MOM project (the new one)
        
        /// <summary>
        /// Gets or sets the PayPal country code of the address.
        /// </summary>
        string PayPalCode
        { get; set; }
        
        /// <summary>
        /// Specifies whether the country qualifies for free shipping.
        /// </summary>
        bool FreeShipping
        { get; set; }
        
        /// <summary>
        /// Gets or sets the country's display order.
        /// </summary>
        int DisplayOrder
        { get; set; }
        
        /// <summary>
        /// Specifies whether the <see cref="ILegacySuperDuperCountry"/> is the default option.
        /// </summary>
        bool IsDefaultSelection
        { get; set; }        
    }
}
