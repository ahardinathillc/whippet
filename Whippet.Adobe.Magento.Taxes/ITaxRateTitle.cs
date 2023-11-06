using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.EAV;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// <see cref="ITaxRate"/> label that is associated to individual <see cref="ITaxRate"/> objects and their respective <see cref="IStore"/> assignment.
    /// </summary>
    public interface ITaxRateTitle : IMagentoEntity, IEqualityComparer<ITaxRateTitle>, ICloneable, IWhippetCloneable
    {
        /// <summary>
        /// Gets or sets the unique ID of the <see cref="ITaxRateTitle"/>.
        /// </summary>
        new int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IStore"/> that the <see cref="ITaxRateTitle"/> is assigned to.
        /// </summary>
        IStore Store
        { get; set; }

        /// <summary>
        /// Gets or sets the unique store ID. Value must be able to be represented as an unsigned 16-bit integer.
        /// </summary>
        /// <exception cref="FormatException" />
        /// <exception cref="OverflowException" />
        string StoreID
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ITaxRate"/> that is associated with the <see cref="IStore"/>.
        /// </summary>
        ITaxRate Rate
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ITaxRateTitle"/> value.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string Value
        { get; set; }
    }
}

