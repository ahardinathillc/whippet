using System;
using Newtonsoft.Json;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft;
using Athi.Whippet.Adobe.Magento.Taxes;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Models
{
    /// <summary>
    /// Represents a data transfer object (DTO) for synchronizing Magento tax rates.
    /// </summary>
    public class MagentoSalesTaxRateSynchronizationRecordDataModel : IMagentoSalesTaxRateSynchronizationRecordModel, IWhippetCloneable, IJsonObject, IJsonSerializableObject
    {
        private bool _skipRate;

        /// <summary>
        /// Gets the unique ID of the target Magento server. This property is read-only.
        /// </summary>
        [JsonProperty("magentoServerId")]
        public virtual Guid MagentoServerID
        { get; protected set; }

        /// <summary>
        /// If <see langword="true"/>, the rate will be added to (or updated in) Magento.
        /// </summary>
        [JsonProperty("createOrUpdateRate")]
        public virtual bool CreateOrUpdateRate
        {
            get
            {
                return !DeleteRate && !SkipRate;
            }
            set
            {
                DeleteRate = !value;
                SkipRate = !value;
            }
        }

        /// <summary>
        /// If <see langword="true"/>, the rate will be removed from Magento.
        /// </summary>
        [JsonProperty("deleteRate")]
        public virtual bool DeleteRate
        { get; set; }

        /// <summary>
        /// If <see langword="true"/>, the rate will not be added to Magento.
        /// </summary>
        [JsonProperty("skipRate")]
        public virtual bool SkipRate
        {
            get
            {
                return _skipRate;
            }
            set
            {
                if (value)
                {
                    DeleteRate = false;
                }

                _skipRate = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="ITaxRate"/> to create or remove. This property is read-only.
        /// </summary>
        [JsonProperty("rate")]
        public virtual ITaxRate Rate
        { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoSalesTaxRateSynchronizationRecordDataModel"/> class with no arguments.
        /// </summary>
        public MagentoSalesTaxRateSynchronizationRecordDataModel()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoSalesTaxRateSynchronizationRecordDataModel"/> class with the specified <see cref="TaxRateViewModel"/>.
        /// </summary>
        /// <param name="taxRate"><see cref="ITaxRate"/> object to create or delete.</param>
        /// <param name="magentoServerId">Magento server ID.</param>
        /// <param name="delete">If <see langword="true"/>, the rate will be deleted in Magento; otherwise, it will be created.</param>
        /// <exception cref="ArgumentNullException" />
        public MagentoSalesTaxRateSynchronizationRecordDataModel(ITaxRate taxRate, Guid magentoServerId, bool delete = false)
            : this()
        {
            if (taxRate == null)
            {
                throw new ArgumentNullException(nameof(taxRate));
            }
            else
            {
                Rate = taxRate;
                MagentoServerID = magentoServerId;
                DeleteRate = delete;
            }
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return (Rate == null) ? base.ToString() : Rate.ToString() + " [" + (DeleteRate ? "Delete" : "Create/Update") + "]";
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public virtual object Clone()
        {
            MagentoSalesTaxRateSynchronizationRecordDataModel obj = new MagentoSalesTaxRateSynchronizationRecordDataModel();

            obj.CreateOrUpdateRate = CreateOrUpdateRate;
            obj.DeleteRate = DeleteRate;
            obj.MagentoServerID = MagentoServerID;
            obj.Rate = Rate.Clone<ITaxRate>();

            return obj;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object with the optional <see cref="Guid"/> that represents the user ID of the user who instantiated the new instance.
        /// </summary>
        /// <typeparam name="TObject">Type of object to return from the operation.</typeparam>
        /// <param name="createdBy"><see cref="Guid"/> ID of the user who instantiated the new instance.</param>
        /// <returns>Object of type <typeparamref name="TObject"/>.</returns>
        public virtual TObject Clone<TObject>(Guid? createdBy = null)
        {
            return (TObject)(Clone());
        }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be inherited.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public string ToJson<T>() where T : IJsonSerializableObject
        {
            return DefaultWhippetJsonObjectWriter.Instance.ToJson(this);
        }
    }
}
