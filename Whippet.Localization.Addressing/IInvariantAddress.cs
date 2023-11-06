using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data;
using Athi.Whippet.Extensions;

namespace Athi.Whippet.Localization.Addressing
{
    /// <summary>
    /// Represents an invariant address, that is, an address that is unformatted with respect to its respective country.
    /// </summary>
    public interface IInvariantAddress : IWhippetEntity, IEqualityComparer<IInvariantAddress>, IWhippetCloneable
    {
        /// <summary>
        /// Represents the first line of the address. This is typically the recipient or receiving entity.
        /// </summary>
        string LineOne
        { get; set; }

        /// <summary>
        /// Represents the second line of the address. Normally this specifies a department, "Attention" or "Care Of" directive.
        /// </summary>
        string LineTwo
        { get; set; }

        /// <summary>
        /// Represents the third line of the address.
        /// </summary>
        string LineThree
        { get; set; }

        /// <summary>
        /// Represents the fourth line of the address.
        /// </summary>
        string LineFour
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICity"/> that the address resides in. The state/province is determined by this property.
        /// </summary>
        ICity City
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IPostalCode"/> that the mail service used to route mail to the address. This property is independent of <see cref="City"/>.
        /// </summary>
        IPostalCode PostalCode
        { get; set; }

        /// <summary>
        /// Gets the <see cref="IStateProvince"/> that the address resides in based on the <see cref="City"/> property. This property is read-only.
        /// </summary>
        IStateProvince StateProvince
        { get; }

        /// <summary>
        /// Gets the <see cref="ICountry"/> that the address resides in based on the <see cref="StateProvince"/> property. This property is read-only.
        /// </summary>
        ICountry Country
        { get; }
    }
}

