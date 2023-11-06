using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;

namespace Athi.Whippet.EventManagement
{
    /// <summary>
    /// Represents an event data store for <see cref="WhippetEvent"/> objects.
    /// </summary>
    public interface IWhippetEventStore
    {
        /// <summary>
        /// Gets all events that match the specified filter criteria.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="WhippetEvent"/> object to return.</typeparam>
        /// <param name="filter">Function delegate that serves as a filter.</param>
        /// <param name="startSequence">Starting sequence in the event chain at which to begin retrieval.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="WhippetEvent"/> objects.</returns>
        IEnumerable<T> GetEvents<T>(Func<T, bool> filter, int startSequence) where T : WhippetEvent, new();

        /// <summary>
        /// Appends the specified <see cref="IEnumerable{T}"/> collection of <see cref="WhippetEvent"/> objects to the store.
        /// </summary>
        /// <param name="wEvents"><see cref="IEnumerable{T}"/> collection of <see cref="WhippetEvent"/> objects to append.</param>
        /// <exception cref="ArgumentNullException" />
        void Append(IEnumerable<WhippetEvent> wEvents);

        /// <summary>
        /// Retrieves all <see cref="WhippetEvent"/> objects that are of the specified type.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="WhippetEvent"/> object to return.</typeparam>
        /// <param name="eventTypes"><see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects to filter on.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="WhippetEvent"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        IEnumerable<T> GetEventsByEventTypes<T>(IEnumerable<Type> eventTypes) where T : WhippetEvent, new();

        /// <summary>
        /// Retrieves all <see cref="WhippetEvent"/> objects that are of the specified type.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="WhippetEvent"/> object to return.</typeparam>
        /// <param name="eventTypes"><see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects to filter on.</param>
        /// <param name="startDate">Starting date range to filter the events on.</param>
        /// <param name="endDate">Ending date range to filter the events on.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="WhippetEvent"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        IEnumerable<T> GetEventsByEventTypes<T>(IEnumerable<Type> eventTypes, DateTime startDate, DateTime endDate) where T : WhippetEvent, new();

        /// <summary>
        /// Retrieves all <see cref="WhippetEvent"/> objects that are of the specified type.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="WhippetEvent"/> object to return.</typeparam>
        /// <param name="eventTypes"><see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects to filter on.</param>
        /// <param name="startDate">Starting date range to filter the events on.</param>
        /// <param name="endDate">Ending date range to filter the events on.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="WhippetEvent"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        IEnumerable<T> GetEventsByEventTypes<T>(IEnumerable<Type> eventTypes, Instant startDate, Instant endDate) where T : WhippetEvent, new();
    }
}
