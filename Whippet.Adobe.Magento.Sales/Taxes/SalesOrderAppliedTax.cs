using System;
using NodaTime;
using Athi.Whippet.Extensions;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Taxes;

namespace Athi.Whippet.Adobe.Magento.Sales.Taxes
{
    /// <summary>
    /// Lists all taxes and their respective rates that were applied to an <see cref="ISalesOrder"/>.
    /// </summary>
    public struct SalesOrderAppliedTax : IExtensionInterfaceMap<SalesOrderAppliedTaxInterface>
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
        /// Gets or sets the tax amount.
        /// </summary>
        public decimal Amount
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount in the base currency.
        /// </summary>
        public decimal BaseAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the applied tax rates.
        /// </summary>
        public IEnumerable<AppliedTaxRate> Rates
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderAppliedTax"/> struct with no arguments.
        /// </summary>
        static SalesOrderAppliedTax()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderAppliedTax"/> struct with no arguments.
        /// </summary>
        public SalesOrderAppliedTax()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderAppliedTax"/> struct with the specified parameters.
        /// </summary>
        /// <param name="code">Tax code.</param>
        /// <param name="title">Tax title.</param>
        /// <param name="amount">Tax amount.</param>
        /// <param name="baseAmount">Tax base amount.</param>
        /// <param name="rates">Tax rates that were applied.</param>
        public SalesOrderAppliedTax(string code, string title, decimal amount, decimal baseAmount, IEnumerable<AppliedTaxRate> rates)
            : this()
        {
            Code = code;
            Title = title;
            Amount = amount;
            BaseAmount = baseAmount;
            Rates = rates;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderAppliedTax"/> struct with the specified <see cref="SalesOrderAppliedTaxInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="SalesOrderAppliedTaxInterface"/> object.</param>
        public SalesOrderAppliedTax(SalesOrderAppliedTaxInterface model)
            : this()
        {
            FromModel(model);
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="SalesOrderAppliedTaxInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="SalesOrderAppliedTaxInterface"/>.</returns>
        public SalesOrderAppliedTaxInterface ToInterface()
        {
            SalesOrderAppliedTaxInterface taxInterface = new SalesOrderAppliedTaxInterface();

            taxInterface.Code = Code;
            taxInterface.Title = Title;
            taxInterface.Amount = Amount;
            taxInterface.AmountBase = BaseAmount;
            taxInterface.ExtensionAttributes = new SalesOrderAppliedTaxExtensionInterface();
            taxInterface.ExtensionAttributes.Rates = (Rates == null) ? null : Rates.Select(r => r.ToInterface()).ToArray();
            
            return taxInterface;
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="SalesOrderAppliedTaxInterface"/> object used to populate the object.</param>
        public void FromModel(SalesOrderAppliedTaxInterface model)
        {
            if (model != null)
            {
                Code = model.Code;
                Title = model.Title;
                Amount = model.Amount;
                BaseAmount = model.AmountBase;

                if (model.ExtensionAttributes != null && model.ExtensionAttributes.Rates != null)
                {
                    Rates = model.ExtensionAttributes.Rates.Select(r => new AppliedTaxRate(r));
                }
            }
        }
        
        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.Format("[Title: {0} | Code: {1} | Amount: {2}]", Title, Code, Amount);
        }
    }
}
