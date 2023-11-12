using System;
using System.Collections.ObjectModel;
using Athi.Whippet.Adobe.Magento.ServiceManagers.Commands;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates multiple <see cref="TaxRate"/> objects in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateTaxRateBulkCommand : MagentoEntityBulkCommandBase<TaxRate>, IMagentoEntityBulkCommand<ITaxRate>
    {
        private IReadOnlyList<ITaxRate> _entities;
        
        /// <summary>
        /// Read-only collection of all <see cref="ITaxRate"/> objects in the command. This property is read-only.
        /// </summary>
        IReadOnlyList<ITaxRate> IMagentoEntityBulkCommand<ITaxRate>.Entities
        {
            get
            {
                if (_entities == null)
                {
                    if (base.Entities != null && base.Entities.Count > 0)
                    {
                        _entities = new ReadOnlyCollection<ITaxRate>(new List<ITaxRate>(base.Entities));
                    }
                }

                return _entities;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTaxRateBulkCommand"/> class with the specified <see cref="IEnumerable{T}"/> collection of <see cref="TaxRate"/> objects.
        /// </summary>
        /// <param name="taxRates"><see cref="IEnumerable{T}"/> collection of <see cref="TaxRate"/> objects to execute on.</param>
        public CreateTaxRateBulkCommand(IEnumerable<TaxRate> taxRates)
            : base(taxRates)
        { }
    }
}
