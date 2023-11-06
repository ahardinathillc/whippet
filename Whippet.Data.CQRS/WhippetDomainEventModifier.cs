using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Provides for a dynamic injection to apply modifications to a <see cref="WhippetDomainEvent"/> upon its application. This class cannot be inherited.
    /// </summary>
    public static class WhippetDomainEventModifier
    {
        /// <summary>
        /// Gets or sets the internal <see cref="IWhippetDomainEventModification"/> object.
        /// </summary>
        private static IWhippetDomainEventModification Modification
        { get; set; }

        /// <summary>
        /// Enables an event modification that is invoked whenever a <see cref="WhippetDomainEvent"/> is applied.
        /// </summary>
        /// <param name="modification"><see cref="IWhippetDomainEventModification"/> object to apply.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void EnableModification(IWhippetDomainEventModification modification)
        {
            if(modification == null)
            {
                throw new ArgumentNullException(nameof(modification));
            }
            else
            {
                Modification = modification;
            }
        }

        /// <summary>
        /// Removes the current modification.
        /// </summary>
        public static void RemoveModification()
        {
            Modification = null;
        }

        /// <summary>
        /// Replaces the current event modification.
        /// </summary>
        /// <param name="modification"><see cref="IWhippetDomainEventModification"/> object to apply.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ReplaceModification(IWhippetDomainEventModification modification)
        {
            EnableModification(modification);
        }

        /// <summary>
        /// Applies the current modification to the specified <see cref="WhippetDomainEvent"/> object.
        /// </summary>
        /// <param name="domainEvent"><see cref="WhippetDomainEvent"/> object to apply modification to.</param>
        /// <exception cref="ArgumentNullException" />
        public static void ApplyModification(WhippetDomainEvent domainEvent)
        {
            if (domainEvent == null)
            {
                throw new ArgumentNullException(nameof(domainEvent));
            }
            else
            {
                if (Modification != null)
                {
                    Modification.Apply(domainEvent);
                }
            }
        }
    }
}
