using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Provides support for event handlers by specifying the types of event it handles.
    /// </summary>
    /// <typeparam name="TDomainEvent"><see cref="WhippetDomainEvent"/> class type to handle.</typeparam>
    public interface IWhippetDomainEventHandler<in TDomainEvent> where TDomainEvent : WhippetDomainEvent
    {
        /// <summary>
        /// Handles the specified <see cref="WhippetDomainEvent"/>.
        /// </summary>
        /// <param name="domainEvent"><see cref="WhippetDomainEvent"/> of type <typeparamref name="TDomainEvent"/> to handle.</param>
        /// <exception cref="ArgumentNullException" />
        void Handle(TDomainEvent domainEvent);
    }
}
