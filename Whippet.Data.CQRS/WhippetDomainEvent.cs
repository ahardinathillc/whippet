using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using Athi.Whippet.EventManagement;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Represents an event that is triggered on a domain entity.
    /// </summary>
    [Serializable]
    public class WhippetDomainEvent : WhippetEvent, IEqualityComparer<WhippetDomainEvent>
    {
        /// <summary>
        /// Gets or sets the ID of the <see cref="WhippetAggregateRoot"/>.
        /// </summary>
        public virtual Guid AggregateRootId
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDomainEvent"/> class with no arguments.
        /// </summary>
        public WhippetDomainEvent()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDomainEvent"/> class with the specified parameters.
        /// </summary>
        /// <param name="rootID">Aggregate root ID.</param>
        /// <param name="sequence">Sequence in the event chain that the event took place.</param>
        /// <param name="eventDate">Timestamp that the event took place.</param>
        public WhippetDomainEvent(Guid rootID, int sequence, Instant eventDate)
            : base(sequence, eventDate)
        {
            AggregateRootId = rootID;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDomainEvent"/> class with the specified parameters.
        /// </summary>
        /// <param name="rootID">Aggregate root ID.</param>
        /// <param name="sequence">Sequence in the event chain that the event took place.</param>
        /// <param name="eventDate">Timestamp that the event took place.</param>
        public WhippetDomainEvent(Guid rootID, int sequence, DateTime eventDate)
            : this(rootID, sequence, Instant.FromDateTimeUtc(eventDate.Kind == DateTimeKind.Utc ? eventDate : eventDate.ToUniversalTime()))
        { }

        /// <summary>
        /// Compares the current object to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return Equals(obj as WhippetDomainEvent);
        }

        /// <summary>
        /// Compares the current object to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetDomainEvent obj)
        {
            bool equals = false;

            if(obj != null)
            {
                equals = obj.AggregateRootId.Equals(AggregateRootId) && base.Equals(obj);
            }

            return equals;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetDomainEvent x, WhippetDomainEvent y)
        {
            bool equals = (x == null && y == null);

            if(!equals && (x != null) && (y != null))
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
        public virtual int GetHashCode(WhippetDomainEvent obj)
        {
            if(obj == null)
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
