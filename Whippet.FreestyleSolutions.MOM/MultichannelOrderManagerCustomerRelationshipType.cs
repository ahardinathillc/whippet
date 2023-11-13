using System;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents a relationship type for a <see cref="MultichannelOrderManagerCustomerRelationship"/>.
    /// </summary>
    public enum MultichannelOrderManagerCustomerRelationshipType : byte
    {
        /// <summary>
        /// Primary address.
        /// </summary>
        PrimaryAddress,
        /// <summary>
        /// Mail to address.
        /// </summary>
        MailToAddress,
        /// <summary>
        /// Ship to address.
        /// </summary>
        ShipToAddress,
        /// <summary>
        /// Bill to address.
        /// </summary>
        BillToAddress,
        /// <summary>
        /// Sold to address.
        /// </summary>
        SoldToAddress,
        /// <summary>
        /// Alternate address.
        /// </summary>
        AlternateAddress,
        /// <summary>
        /// Contact name/address.
        /// </summary>
        ContactNameAddress,
        /// <summary>
        /// Gift recipient.
        /// </summary>
        GiftRecipient
    }
}
