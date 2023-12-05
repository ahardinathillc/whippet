using System;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// Represents a tax rate that is applied to a sellable item in Magento.
    /// </summary>
    public struct AppliedTaxRate : IExtensionInterfaceMap<TaxRateAppliedRateInterface>
    {
        /// <summary>
        /// Gets or sets the tax code.
        /// </summary>
        public string Code
        { get; set; }
        
        /// <summary>
        /// Gets or sets the tax title.
        /// </summary>
        public string Title
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rate percentage.
        /// </summary>
        public decimal Percent
        { get; set; }

        /// <summary>
        /// Gets or sets the base tax amount.
        /// </summary>
        public decimal BaseAmount
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppliedTaxRate"/> struct with no arguments.
        /// </summary>
        static AppliedTaxRate()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AppliedTaxRate"/> struct with no arguments.
        /// </summary>
        public AppliedTaxRate()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppliedTaxRate"/> struct with the specified <see cref="TaxRateAppliedRateInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="TaxRateAppliedRateInterface"/> object.</param>
        public AppliedTaxRate(TaxRateAppliedRateInterface model)
            : this()
        {
            FromModel(model);
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="TaxRateAppliedRateInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="TaxRateAppliedRateInterface"/>.</returns>
        public TaxRateAppliedRateInterface ToInterface()
        {
            TaxRateAppliedRateInterface taxInterface = new TaxRateAppliedRateInterface();

            taxInterface.Code = Code;
            taxInterface.Title = Title;
            taxInterface.Percent = Percent;
            taxInterface.ExtensionAttributes = new TaxRateAppliedRateExtensionInterface();
            
            return taxInterface;
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="TaxRateAppliedRateInterface"/> object used to populate the object.</param>
        public void FromModel(TaxRateAppliedRateInterface model)
        {
            if (model != null)
            {
                Code = model.Code;
                Title = model.Title;
                Percent = model.Percent;
            }
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.Format("[Title: {0} | Code: {1} | Percent: {2}]", Title, Code, Percent);
        }
    }
}
