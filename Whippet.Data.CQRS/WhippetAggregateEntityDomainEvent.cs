using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Represents an event that is triggered on a <see cref="WhippetAggregateEntity"/> object.
    /// </summary>
    [Serializable]
    public class WhippetAggregateEntityDomainEvent : WhippetDomainEvent, IEqualityComparer<WhippetAggregateEntityDomainEvent>
    {
        /// <summary>
        /// Unique ID of the <see cref="WhippetAggregateEntity"/> that the event takes place on.
        /// </summary>
        public Guid EntityID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAggregateEntityDomainEvent"/> class with no arguments.
        /// </summary>
        public WhippetAggregateEntityDomainEvent()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAggregateEntityDomainEvent"/> class with the specified parameters.
        /// </summary>
        /// <param name="rootID">Aggregate root ID.</param>
        /// <param name="sequence">Sequence in the event chain that the event took place.</param>
        /// <param name="eventDate">Timestamp that the event took place.</param>
        public WhippetAggregateEntityDomainEvent(Guid rootID, int sequence, Instant eventDate)
            : this()
        {
            AggregateRootId = rootID;
            Sequence = sequence;
            EventDate = eventDate;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAggregateEntityDomainEvent"/> class with the specified parameters.
        /// </summary>
        /// <param name="rootID">Aggregate root ID.</param>
        /// <param name="sequence">Sequence in the event chain that the event took place.</param>
        /// <param name="eventDate">Timestamp that the event took place.</param>
        public WhippetAggregateEntityDomainEvent(Guid rootID, int sequence, DateTime eventDate)
            : this(rootID, sequence, Instant.FromDateTimeUtc(eventDate.Kind == DateTimeKind.Utc ? eventDate : eventDate.ToUniversalTime()))
        { }

        /// <summary>
        /// Compares the current object to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return Equals(obj as WhippetAggregateEntityDomainEvent);
        }

        /// <summary>
        /// Compares the current object to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetAggregateEntityDomainEvent obj)
        {
            bool equals = false;

            if (obj != null)
            {
                equals = base.Equals(obj) && EntityID.Equals(obj.EntityID);
            }

            return equals;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetAggregateEntityDomainEvent x, WhippetAggregateEntityDomainEvent y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = x.Equals(y);
            }

            return equals;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="WhippetDomainEvent"/> object to get hash code for.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(WhippetAggregateEntityDomainEvent obj)
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
