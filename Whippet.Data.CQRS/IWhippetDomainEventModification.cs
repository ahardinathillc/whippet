using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Represents a modification that is applied to a <see cref="WhippetDomainEvent"/>.
    /// </summary>
    public interface IWhippetDomainEventModification
    {
        /// <summary>
        /// Applies a modification to the target <see cref="WhippetDomainEvent"/> object.
        /// </summary>
        /// <param name="domainEvent"><see cref="WhippetDomainEvent"/> object to modify.</param>
        void Apply(WhippetDomainEvent domainEvent);
    }
}
