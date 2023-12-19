using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.SuperDuper.Data;
using Athi.Whippet.SuperDuper.Legacy;
using Athi.Whippet.ParadoxLabs.Magento.Subscriptions;
using Athi.Whippet.ParadoxLabs.Magento.Subscriptions.Extensions;
using Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.Extensions;
using Athi.Whippet.SuperDuper.Legacy.Extensions;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy
{
    /// <summary>
    /// Represents a Super Duper Digital Library (SDDL) user subscription.
    /// </summary>
    public class LegacyDigitalLibrarySubscription : SuperDuperLegacyEntity, IWhippetEntity, ISuperDuperLegacyEntity, ILegacyDigitalLibrarySubscription, IEqualityComparer<ILegacyDigitalLibrarySubscription>
    {
        private LegacySuperDuperAccount _account;
        private LegacyDigitalLibrarySubscriptionPeriod _period;
        private LegacyDigitalLibrarySubscriptionLevel _level;
        
        /// <summary>
        /// Gets or sets the parent <see cref="LegacySuperDuperAccount"/> object.
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
        /// Gets or sets the parent <see cref="ILegacySuperDuperAccount"/> object.
        /// </summary>
        ILegacySuperDuperAccount ILegacyDigitalLibrarySubscription.Account
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
        /// Gets or sets the subscription period.
        /// </summary>
        public virtual LegacyDigitalLibrarySubscriptionPeriod SubscriptionPeriod
        {
            get
            {
                if (_period == null)
                {
                    _period = new LegacyDigitalLibrarySubscriptionPeriod();
                }

                return _period;
            }
            set
            {
                _period = value;
            }
        }

        /// <summary>
        /// Gets or sets the subscription period.
        /// </summary>
        ILegacyDigitalLibrarySubscriptionPeriod ILegacyDigitalLibrarySubscription.SubscriptionPeriod
        {
            get
            {
                return SubscriptionPeriod;
            }
            set
            {
                SubscriptionPeriod = value.ToLegacyDigitalLibrarySubscriptionPeriod();
            }
        }

        /// <summary>
        /// Gets or sets the subscription access level.
        /// </summary>
        public virtual LegacyDigitalLibrarySubscriptionLevel AccessLevel
        {
            get
            {
                if (_level == null)
                {
                    _level = new LegacyDigitalLibrarySubscriptionLevel();
                }

                return _level;
            }
            set
            {
                _level = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the subscription access level.
        /// </summary>
        ILegacyDigitalLibrarySubscriptionLevel ILegacyDigitalLibrarySubscription.AccessLevel
        {
            get
            {
                return AccessLevel;
            }
            set
            {
                AccessLevel = value.ToLegacyDigitalLibrarySubscriptionLevel();
            }
        }
        
        /// <summary>
        /// Gets or sets the expiration date and time of the subscription.
        /// </summary>
        public virtual Instant ExpirationDTTM
        { get; set; }
        
        /// <summary>
        /// Gets or sets the subscription's license limit.
        /// </summary>
        public virtual int LicenseLimit
        { get; set; }
        
        /// <summary>
        /// Specifies whether the subscription is a free trial subscription.
        /// </summary>
        public virtual bool FreeTrial
        { get; set; }

        /// <summary>
        /// Specifies whether the account has printing enabled.
        /// </summary>
        public virtual bool CanPrint
        { get; set; }
        
        /// <summary>
        /// Gets or sets the subscription's unique <see cref="Guid"/> identifier.
        /// </summary>
        public virtual Guid? UUID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the date/time the subscription was removed.
        /// </summary>
        public virtual Instant? RemovedDTTM
        { get; set; }
        
        /// <summary>
        /// Gets or sets the associated <see cref="Subscription"/> object. This property is populated only if an existing mapping exists in Magento.
        /// </summary>
        public virtual Subscription MagentoSubscription
        { get; set; }

        /// <summary>
        /// Gets or sets the associated <see cref="ISubscription"/> object. This property is populated only if an existing mapping exists in Magento.
        /// </summary>
        ISubscription ILegacyDigitalLibrarySubscription.MagentoSubscription
        {
            get
            {
                return MagentoSubscription;
            }
            set
            {
                MagentoSubscription = value.ToSubscription();
            }
        }

        /// <summary>
        /// Gets or sets the unique ID of <see cref="MagentoSubscription"/>.
        /// </summary>
        protected internal int? _MagentoSubscriptionID
        {
            get
            {
                return MagentoSubscription == null ? null : MagentoSubscription.ID;
            }
            set
            {
                if (!value.HasValue)
                {
                    MagentoSubscription = null;
                }
                else
                {
                    MagentoSubscription = new Subscription(Convert.ToUInt32(value.Value));
                }
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyDigitalLibrarySubscription"/> class with no arguments.
        /// </summary>
        public LegacyDigitalLibrarySubscription()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyDigitalLibrarySubscription"/> class with the specified ID.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        public LegacyDigitalLibrarySubscription(int id)
            : base(id)
        { }
        
                /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as ILegacyDigitalLibrarySubscription);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ILegacyDigitalLibrarySubscription obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="ILegacyDigitalLibrarySubscription"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="ILegacyDigitalLibrarySubscription"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ILegacyDigitalLibrarySubscription a, ILegacyDigitalLibrarySubscription b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals = (((a.Account == null) && (b.Account == null)) || ((a.Account != null) && a.Account.Equals(b.Account)))
                         && (((a.SubscriptionPeriod == null) && (b.SubscriptionPeriod == null)) || ((a.SubscriptionPeriod != null) && a.SubscriptionPeriod.Equals(b.SubscriptionPeriod)))
                         && (((a.AccessLevel == null) && (b.AccessLevel == null)) || ((a.AccessLevel != null) && a.AccessLevel.Equals(b.AccessLevel)))
                         && a.ExpirationDTTM.Equals(b.ExpirationDTTM)
                         && a.LicenseLimit == b.LicenseLimit
                         && a.FreeTrial == b.FreeTrial
                         && a.CanPrint == b.CanPrint
                         && a.UUID.GetValueOrDefault().Equals(b.UUID.GetValueOrDefault())
                         && a.RemovedDTTM.GetValueOrDefault().Equals(b.RemovedDTTM.GetValueOrDefault())
                         && (((a.MagentoSubscription == null) && (b.MagentoSubscription == null)) || ((a.MagentoSubscription != null) && a.MagentoSubscription.Equals(b.MagentoSubscription)));
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
            hash.Add(Account);
            hash.Add(SubscriptionPeriod);
            hash.Add(AccessLevel);
            hash.Add(ExpirationDTTM);
            hash.Add(LicenseLimit);
            hash.Add(FreeTrial);
            hash.Add(CanPrint);
            hash.Add(UUID);
            hash.Add(RemovedDTTM);
            hash.Add(MagentoSubscription);

            return hash.ToHashCode();
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual int GetHashCode(ILegacyDigitalLibrarySubscription obj)
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
    }
}
