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
    /// Represents an event data store for <see cref="WhippetDomainEvent"/> objects.
    /// </summary>
    public interface IWhippetDomainEventStore : IWhippetEventStore
    {
        /// <summary>
        /// Getse all <see cref="WhippetDomainEvent"/> objects that match the specified aggregate root ID.
        /// </summary>
        /// <param name="aggregateRootId">Aggregate root ID.</param>
        /// <param name="startSequence">Starting sequence of the events to start retrieval from.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="WhippetDomainEvent"/> objects.</returns>
        IEnumerable<WhippetDomainEvent> GetEvents(Guid aggregateRootId, int startSequence);

        /// <summary>
        /// Appends the specified <see cref="IEnumerable{T}"/> collection of <see cref="WhippetDomainEvent"/> objects to the store.
        /// </summary>
        /// <param name="wEvents"><see cref="IEnumerable{T}"/> collection of <see cref="WhippetDomainEvent"/> objects to append.</param>
        /// <exception cref="ArgumentNullException" />
        new void Append(IEnumerable<WhippetEvent> wEvents);

        /// <summary>
        /// Retrieves all <see cref="WhippetDomainEvent"/> objects that are of the specified type.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="WhippetDomainEvent"/> object to return.</typeparam>
        /// <param name="eventTypes"><see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects to filter on.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="WhippetDomainEvent"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        IEnumerable<WhippetDomainEvent> GetEventsByEventTypes(IEnumerable<Type> eventTypes);

        /// <summary>
        /// Retrieves all <see cref="WhippetDomainEvent"/> objects that are of the specified type.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="WhippetDomainEvent"/> object to return.</typeparam>
        /// <param name="eventTypes"><see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects to filter on.</param>
        /// <param name="aggregateRootID">Aggregate root ID.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="WhippetDomainEvent"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        IEnumerable<WhippetDomainEvent> GetEventsByEventTypes(IEnumerable<Type> eventTypes, Guid aggregateRootID);

        /// <summary>
        /// Retrieves all <see cref="WhippetDomainEvent"/> objects that are of the specified type.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="WhippetDomainEvent"/> object to return.</typeparam>
        /// <param name="eventTypes"><see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects to filter on.</param>
        /// <param name="startDate">Starting date range to filter the events on.</param>
        /// <param name="endDate">Ending date range to filter the events on.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="WhippetDomainEvent"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        IEnumerable<WhippetDomainEvent> GetEventsByEventTypes(IEnumerable<Type> eventTypes, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Retrieves all <see cref="WhippetDomainEvent"/> objects that are of the specified type.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="WhippetDomainEvent"/> object to return.</typeparam>
        /// <param name="eventTypes"><see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects to filter on.</param>
        /// <param name="startDate">Starting date range to filter the events on.</param>
        /// <param name="endDate">Ending date range to filter the events on.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="WhippetDomainEvent"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        IEnumerable<WhippetDomainEvent> GetEventsByEventTypes(IEnumerable<Type> eventTypes, Instant startDate, Instant endDate);
    }
}
