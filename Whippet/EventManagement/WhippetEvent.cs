using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;

namespace Athi.Whippet.EventManagement
{
    /// <summary>
    /// Represents an event that is triggered in Whippet. This class must be inherited.
    /// </summary>
    [Serializable]
    public abstract class WhippetEvent : IEqualityComparer<WhippetEvent>
    {
        /// <summary>
        /// Sequence in the event chain that the event took place.
        /// </summary>
        public virtual int Sequence
        { get; set; }

        /// <summary>
        /// Timestamp that the event took place.
        /// </summary>
        public virtual Instant EventDate
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetEvent"/> class with no arguments.
        /// </summary>
        protected WhippetEvent()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetEvent"/> class with the specified parameters.
        /// </summary>
        /// <param name="sequence">Sequence in the event chain that the event took place.</param>
        /// <param name="eventDate">Timestamp that the event took place.</param>
        protected WhippetEvent(int sequence, Instant eventDate)
            : this()
        {
            Sequence = sequence;
            EventDate = eventDate;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetEvent"/> class with the specified parameters.
        /// </summary>
        /// <param name="rootID">Aggregate root ID.</param>
        /// <param name="sequence">Sequence in the event chain that the event took place.</param>
        /// <param name="eventDate">Timestamp that the event took place.</param>
        protected WhippetEvent(Guid rootID, int sequence, DateTime eventDate)
            : this(sequence, Instant.FromDateTimeUtc(eventDate.Kind == DateTimeKind.Utc ? eventDate : eventDate.ToUniversalTime()))
        { }

        /// <summary>
        /// Compares the current object to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as WhippetEvent);
        }

        /// <summary>
        /// Compares the current object to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetEvent obj)
        {
            bool equals = false;

            if (obj != null)
            {
                equals = obj.Sequence.Equals(Sequence)
                        && obj.EventDate.Equals(EventDate);
            }

            return equals;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetEvent x, WhippetEvent y)
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
        /// <param name="obj"><see cref="WhippetEvent"/> object to get hash code for.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(WhippetEvent obj)
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
