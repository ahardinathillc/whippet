using System;
using NodaTime;
using Athi.Whippet.Extensions;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Provides shipping information for an <see cref="ISalesOrder"/>.
    /// </summary>
    public struct SalesOrderShippingTotal : IExtensionInterfaceMap<SalesOrderShippingTotalInterface>
    {
        /// <summary>
        /// Gets or sets the shipping amount in base currency.
        /// </summary>
        public decimal ShippingAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount canceled in base currency.
        /// </summary>
        public decimal ShippingCanceledBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount amount in base currency.
        /// </summary>
        public decimal ShippingDiscountAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount tax compensation amount in base currency.
        /// </summary>
        public decimal ShippingDiscountTaxCompensationAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount including tax in base currency.
        /// </summary>
        public decimal ShippingWithTaxBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount invoiced in base currency.
        /// </summary>
        public decimal ShippingInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount refunded in base currency.
        /// </summary>
        public decimal ShippingRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping tax amount in base currency.
        /// </summary>
        public decimal ShippingTaxAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping tax refunded amount in base currency.
        /// </summary>
        public decimal ShippingTaxRefundedBase
        { get; set; }
        
        /// <summary>
        /// Gets or sets the shipping amount.
        /// </summary>
        public decimal ShippingAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping canceled amount.
        /// </summary>
        public decimal ShippingCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping description.
        /// </summary>
        public string ShippingDescription
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount amount. 
        /// </summary>
        public decimal ShippingDiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount tax compensation amount.
        /// </summary>
        public decimal ShippingDiscountTaxCompensationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping including tax amount.
        /// </summary>
        public decimal ShippingWithTax
        { get; set; }

        /// <summary>
        /// Gets or sets the total shipping amount that was invoiced.
        /// </summary>
        public decimal ShippingInvoiced
        { get; set; }
        
        /// <summary>
        /// Gets or sets the shipping including tax refund amount.
        /// </summary>
        public decimal ShippingTaxRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the item's shipping tax amount.
        /// </summary>
        public decimal ShippingTaxAmount
        { get; set; }
        
        /// <summary>
        /// Gets or sets the total shipping refund amount.
        /// </summary>
        public decimal ShippingRefunded
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderShippingTotal"/> struct with no arguments.
        /// </summary>
        static SalesOrderShippingTotal()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderShippingTotal"/> struct with no arguments.
        /// </summary>
        public SalesOrderShippingTotal()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderShippingTotal"/> struct with the specified <see cref="SalesOrderShippingTotalInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="SalesOrderShippingTotalInterface"/> object.</param>
        public SalesOrderShippingTotal(SalesOrderShippingTotalInterface model)
            : this()
        {
            FromModel(model);
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="SalesOrderShippingTotalInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="SalesOrderShippingTotalInterface"/>.</returns>
        public SalesOrderShippingTotalInterface ToInterface()
        {
            SalesOrderShippingTotalInterface sInterface = new SalesOrderShippingTotalInterface();

            sInterface.ShippingAmountBase = ShippingAmountBase;
            sInterface.ShippingCanceledBase = ShippingCanceledBase;
            sInterface.ShippingDiscountAmountBase = ShippingDiscountAmountBase;
            sInterface.ShippingDiscountTaxCompensationAmountBase = ShippingDiscountTaxCompensationAmountBase;
            sInterface.ShippingWithTaxBase = ShippingWithTaxBase;
            sInterface.ShippingInvoicedBase = ShippingInvoicedBase;
            sInterface.ShippingRefundedBase = ShippingRefundedBase;
            sInterface.ShippingTaxAmountBase = ShippingTaxAmountBase;
            sInterface.ShippingTaxRefundedBase = ShippingTaxRefundedBase;
            sInterface.ShippingAmount = ShippingAmount;
            sInterface.ShippingCanceled = ShippingCanceled;
            sInterface.ShippingDescription = ShippingDescription;
            sInterface.ShippingDiscountAmount = ShippingDiscountAmount;
            sInterface.ShippingDiscountTaxCompensationAmount = ShippingDiscountTaxCompensationAmount;
            sInterface.ShippingWithTax = ShippingWithTax;
            sInterface.ShippingInvoiced = ShippingInvoiced;
            sInterface.ShippingTaxRefunded = ShippingTaxRefunded;
            sInterface.ShippingTaxAmount = ShippingTaxAmount;
            sInterface.ShippingRefunded = ShippingRefunded;
            
            return sInterface;
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="SalesOrderShippingTotalInterface"/> object used to populate the object.</param>
        public void FromModel(SalesOrderShippingTotalInterface model)
        {
            if (model != null)
            {
                ShippingAmountBase = ShippingAmountBase;
                ShippingCanceledBase = model.ShippingCanceledBase;
                ShippingDiscountAmountBase = model.ShippingDiscountAmountBase;
                ShippingDiscountTaxCompensationAmountBase = model.ShippingDiscountTaxCompensationAmountBase;
                ShippingWithTaxBase = model.ShippingWithTaxBase;
                ShippingInvoicedBase = model.ShippingInvoicedBase;
                ShippingRefundedBase = model.ShippingRefundedBase;
                ShippingTaxAmountBase = model.ShippingTaxAmountBase;
                ShippingTaxRefundedBase = model.ShippingTaxRefundedBase;
                ShippingAmount = model.ShippingAmount;
                ShippingCanceled = model.ShippingCanceled;
                ShippingDescription = model.ShippingDescription;
                ShippingDiscountAmount = model.ShippingDiscountAmount;
                ShippingDiscountTaxCompensationAmount = model.ShippingDiscountTaxCompensationAmount;
                ShippingWithTax = model.ShippingWithTax;
                ShippingInvoiced = model.ShippingInvoiced;
                ShippingTaxRefunded = model.ShippingTaxRefunded;
                ShippingTaxAmount = model.ShippingTaxAmount;
                ShippingRefunded = model.ShippingRefunded;
            }
        }
    }
}
