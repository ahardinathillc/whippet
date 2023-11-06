using System;
namespace Athi.Whippet.Logging
{
    /// <summary>
    /// Provides an index of constant values used in logging. This class cannot be inherited.
    /// </summary>
    public static class EventConstants
    {
        /// <summary>
        /// Base integer range for Whippet event IDs.
        /// </summary>
        public const int WHIPPET_EVENT_BASE = 698300000;

        /// <summary>
        /// Creates an event ID based on the supplied value.
        /// </summary>
        /// <param name="eventId">Value to append to the Whippet event base.</param>
        /// <returns>Fully qualified Whippet event ID.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int CreateEventId(int eventId)
        {
            if (eventId < 0 || eventId >= 99999)
            {
                throw new ArgumentOutOfRangeException(nameof(eventId));
            }
            else
            {
                return WHIPPET_EVENT_BASE + eventId;
            }
        }
    }
}

