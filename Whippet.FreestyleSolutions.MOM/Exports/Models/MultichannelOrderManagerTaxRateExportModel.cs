using System;
using Newtonsoft.Json;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Exports.Models
{
    /// <summary>
    /// Model for lightweight, data store independent implementation of a tax rate export record from a Multichannel Order Manager server. This class cannot be inherited.
    /// </summary>
    public sealed class MultichannelOrderManagerTaxRateExportModel : IMultichannelOrderManagerTaxRateExport, IEqualityComparer<IMultichannelOrderManagerTaxRateExport>, IJsonObject
    {
        private IMultichannelOrderManagerTaxRateExport _export;

        /// <summary>
        /// Gets or sets the internal <see cref="IMultichannelOrderManagerTaxRateExport"/> object.
        /// </summary>
        private IMultichannelOrderManagerTaxRateExport InternalObject
        {
            get
            {
                if (_export == null)
                {
                    _export = new MultichannelOrderManagerFlattenedTaxRateExport();
                }

                return _export;
            }
            set
            {
                _export = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IMultichannelOrderManagerServer"/> that the export was generated from.
        /// </summary>
        [JsonProperty("server")]
        public IMultichannelOrderManagerServer Server
        {
            get
            {
                return InternalObject.Server;
            }
            set
            {
                InternalObject.Server = value;
            }
        }

        /// <summary>
        /// Gets or sets the tax rate.
        /// </summary>
        [JsonProperty("taxRate")]
        public decimal TaxRate
        {
            get
            {
                return InternalObject.TaxRate;
            }
            set
            {
                InternalObject.TaxRate = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IMultichannelOrderManagerPostalCode"/> that the tax rate applies to.
        /// </summary>
        [JsonProperty("postalCode")]
        public IMultichannelOrderManagerPostalCode PostalCode
        {
            get
            {
                return InternalObject.PostalCode;
            }
            set
            {
                InternalObject.PostalCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IMultichannelOrderManagerStateProvince"/> that the tax rate applies to.
        /// </summary>
        [JsonProperty("stateProvince")]
        public IMultichannelOrderManagerStateProvince StateProvince
        {
            get
            {
                return InternalObject.StateProvince;
            }
            set
            {
                InternalObject.StateProvince = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IMultichannelOrderManagerCountry"/> that the tax rate applies to.
        /// </summary>
        [JsonProperty("country")]
        public IMultichannelOrderManagerCountry Country
        {
            get
            {
                return InternalObject.Country;
            }
            set
            {
                InternalObject.Country = value;
            }
        }

        /// <summary>
        /// Specifies whether shipping should be taxed.
        /// </summary>
        [JsonProperty("taxShipping")]
        public bool TaxShipping
        {
            get
            {
                return InternalObject.TaxShipping;
            }
            set
            {
                InternalObject.TaxShipping = value;
            }
        }

        /// <summary>
        /// Specifies whether non-tangible products (such as services, including subscription-based software) should be taxed.
        /// </summary>
        [JsonProperty("taxServices")]
        public bool TaxServices
        {
            get
            {
                return InternalObject.TaxServices;
            }
            set
            {
                InternalObject.TaxServices = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerTaxRateExportModel"/> class with no arguments.
        /// </summary>
        private MultichannelOrderManagerTaxRateExportModel()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerTaxRateExportModel"/> class with the specified <see cref="IMultichannelOrderManagerTaxRateExport"/> object.
        /// </summary>
        /// <param name="export"><see cref="IMultichannelOrderManagerTaxRateExport"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerTaxRateExportModel(IMultichannelOrderManagerTaxRateExport export)
            : this()
        {
            if (export == null)
            {
                throw new ArgumentNullException(nameof(export));
            }
            else
            {
                InternalObject = export;
            }
        }

        /// <summary>
        /// Determines whether the current instance is equal to the specified object.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return InternalObject.Equals(obj);
        }

        /// <summary>
        /// Determines whether the current instance is equal to the specified object.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(IMultichannelOrderManagerTaxRateExport obj)
        {
            return InternalObject.Equals(obj);
        }

        /// <summary>
        /// Determines whether the two objects are equal.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(IMultichannelOrderManagerTaxRateExport x, IMultichannelOrderManagerTaxRateExport y)
        {
            return InternalObject.Equals(x, y);
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return InternalObject.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="IMultichannelOrderManagerTaxRateExport"/> object to get hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException" />
        public int GetHashCode(IMultichannelOrderManagerTaxRateExport obj)
        {
            return InternalObject.GetHashCode(obj);
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return InternalObject.ToString();
        }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be overridden.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public string ToJson<T>() where T : IJsonSerializableObject
        {
            return DefaultWhippetJsonObjectWriter.Instance.ToJson(this);
        }
    }
}
