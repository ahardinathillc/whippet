using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.SuperDuper.Data;
using Athi.Whippet.SuperDuper.Legacy;
using Athi.Whippet.ParadoxLabs.Magento.Subscriptions;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy
{
    /// <summary>
    /// Represents a Super Duper Digital Library (SDDL) user subscription.
    /// </summary>
    public interface ILegacyDigitalLibrarySubscription : IWhippetEntity, ISuperDuperLegacyEntity, IEqualityComparer<ILegacyDigitalLibrarySubscription>
    {
        /// <summary>
        /// Gets or sets the parent <see cref="ILegacySuperDuperAccount"/> object.
        /// </summary>
        ILegacySuperDuperAccount Account
        { get; set; }

        /// <summary>
        /// Gets or sets the subscription period.
        /// </summary>
        ILegacyDigitalLibrarySubscriptionPeriod SubscriptionPeriod
        { get; set; }

        /// <summary>
        /// Gets or sets the subscription access level.
        /// </summary>
        ILegacyDigitalLibrarySubscriptionLevel AccessLevel
        { get; set; }
        
        /// <summary>
        /// Gets or sets the expiration date and time of the subscription.
        /// </summary>
        Instant ExpirationDTTM
        { get; set; }
        
        /// <summary>
        /// Gets or sets the subscription's license limit.
        /// </summary>
        int LicenseLimit
        { get; set; }
        
        /// <summary>
        /// Specifies whether the subscription is a free trial subscription.
        /// </summary>
        bool FreeTrial
        { get; set; }

        /// <summary>
        /// Specifies whether the account has printing enabled.
        /// </summary>
        bool CanPrint
        { get; set; }
        
        /// <summary>
        /// Gets or sets the subscription's unique <see cref="Guid"/> identifier.
        /// </summary>
        Guid? UUID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the date/time the subscription was removed.
        /// </summary>
        Instant? RemovedDTTM
        { get; set; }
        
        /// <summary>
        /// Gets or sets the associated <see cref="ISubscription"/> object. This property is populated only if an existing mapping exists in Magento.
        /// </summary>
        ISubscription MagentoSubscription
        { get; set; }        
    }
}
