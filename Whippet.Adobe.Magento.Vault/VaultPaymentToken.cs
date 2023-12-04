using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Extensions;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Store;
using Athi.Whippet.Adobe.Magento.Customer;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Adobe.Magento.Store.Extensions;
using MagentoCustomer = Athi.Whippet.Adobe.Magento.Customer.Customer;

namespace Athi.Whippet.Adobe.Magento.Vault
{
    /// <summary>
    /// Represents a gateway payment token in Magento.
    /// </summary>
    public class VaultPaymentToken : MagentoRestEntity<VaultPaymentTokenInterface>, IMagentoEntity, IVaultPaymentToken, IEqualityComparer<IVaultPaymentToken>, IMagentoRestEntity, IMagentoRestEntity<VaultPaymentTokenInterface>, IWhippetActiveEntity
    {
        private MagentoCustomer _customer;

        /// <summary>
        /// Gets or sets the customer associated with the payment token.
        /// </summary>
        public virtual MagentoCustomer Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new MagentoCustomer();
                }

                return _customer;
            }
            set
            {
                _customer = value;
            }
        }

        /// <summary>
        /// Gets or sets the customer associated with the payment token.
        /// </summary>
        ICustomer IVaultPaymentToken.Customer
        {
            get
            {
                return Customer;
            }
            set
            {
                Customer = (value == null) ? null : value.ToCustomer();
            }
        }

        /// <summary>
        /// Gets or sets the public hash value.
        /// </summary>
        public virtual string PublicHash
        { get; set; }

        /// <summary>
        /// Gets or sets the payment method code.
        /// </summary>
        public virtual string PaymentMethodCode
        { get; set; }

        /// <summary>
        /// Gets or sets the token type.
        /// </summary>
        public virtual string Type
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the token was created.
        /// </summary>
        public virtual Instant? CreatedTimestamp
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the token expires.
        /// </summary>
        public virtual Instant? ExpiresTimestamp
        { get; set; }

        /// <summary>
        /// Gets or sets the gateway token ID.
        /// </summary>
        public virtual string GatewayToken
        { get; set; }

        /// <summary>
        /// Gets or sets the token details.
        /// </summary>
        public virtual string TokenDetails
        { get; set; }

        /// <summary>
        /// Specifies whether the token is active.
        /// </summary>
        public virtual bool Active
        { get; set; }

        /// <summary>
        /// Specifies whether the token is currently visible.
        /// </summary>
        public virtual bool Visible
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="VaultPaymentToken"/> class with no arguments.
        /// </summary>
        public VaultPaymentToken()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="VaultPaymentToken"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public VaultPaymentToken(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="VaultPaymentToken"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public VaultPaymentToken(VaultPaymentTokenInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is IVaultPaymentToken)) ? false : Equals((IVaultPaymentToken)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IVaultPaymentToken obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IVaultPaymentToken x, IVaultPaymentToken y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = x.CreatedTimestamp.GetValueOrDefault().Equals(y.CreatedTimestamp.GetValueOrDefault())
                        && x.ExpiresTimestamp.GetValueOrDefault().Equals(y.ExpiresTimestamp.GetValueOrDefault())
                        && (((x.Customer == null) && (y.Customer == null)) || ((x.Customer != null) && x.Customer.Equals(y.Customer)))
                        && String.Equals(x.PublicHash?.Trim(), y.PublicHash?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.PaymentMethodCode?.Trim(), y.PaymentMethodCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.Type?.Trim(), y.Type?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.GatewayToken?.Trim(), y.GatewayToken?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.TokenDetails?.Trim(), y.TokenDetails?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                        && x.Active == y.Active
                        && x.Visible == y.Visible
                        && (((x.Server == null) && (y.Server == null)) || ((x.Server != null) && x.Server.Equals(y.Server)))
                        && (((x.RestEndpoint == null) && (y.RestEndpoint == null)) || ((x.RestEndpoint != null) && x.RestEndpoint.Equals(y.RestEndpoint)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="VaultPaymentTokenInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="VaultPaymentTokenInterface"/>.</returns>
        public override VaultPaymentTokenInterface ToInterface()
        {
            VaultPaymentTokenInterface token = new VaultPaymentTokenInterface();

            token.ID = ID;
            token.Active = Active;
            token.CustomerID = Customer.ID;
            token.PublicHash = PublicHash;
            token.PaymentMethodCode = PaymentMethodCode;
            token.Type = Type;
            token.CreatedAt = CreatedTimestamp.HasValue ? CreatedTimestamp.Value.ToDateTimeUtc().ToString() : String.Empty;
            token.ExpiresAt = ExpiresTimestamp.HasValue ? ExpiresTimestamp.Value.ToDateTimeUtc().ToString() : String.Empty;
            token.GatewayToken = GatewayToken;
            token.TokenDetails = TokenDetails;
            token.Active = Active;
            token.Visible = Visible;
            
            return token;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            VaultPaymentToken token = new VaultPaymentToken();

            token.ID = ID;
            token.Customer = Customer.Clone<MagentoCustomer>();
            token.PublicHash = PublicHash;
            token.PaymentMethodCode = PaymentMethodCode;
            token.Type = Type;
            token.CreatedTimestamp = CreatedTimestamp;
            token.ExpiresTimestamp = ExpiresTimestamp;
            token.GatewayToken = GatewayToken;
            token.TokenDetails = TokenDetails;
            token.Visible = Visible;
            token.Active = Active;
            
            return token;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(ID);
            hash.Add(Customer);
            hash.Add(PublicHash);
            hash.Add(PaymentMethodCode);
            hash.Add(Type);
            hash.Add(CreatedTimestamp);
            hash.Add(ExpiresTimestamp);
            hash.Add(GatewayToken);
            hash.Add(TokenDetails);
            hash.Add(Visible);
            hash.Add(Active);
            
            return hash.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="product"><see cref="IVaultPaymentToken"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IVaultPaymentToken product)
        {
            ArgumentNullException.ThrowIfNull(product);
            return product.GetHashCode();
        }
        
        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(VaultPaymentTokenInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                Customer = new MagentoCustomer(Convert.ToUInt32(model.CustomerID));
                PublicHash = model.PublicHash;
                PaymentMethodCode = model.PaymentMethodCode;
                Type = model.Type;
                CreatedTimestamp = !String.IsNullOrWhiteSpace(model.CreatedAt) ? Instant.FromDateTimeUtc(DateTime.Parse(model.CreatedAt).ToUniversalTime(true)) : null;
                ExpiresTimestamp = !String.IsNullOrWhiteSpace(model.ExpiresAt) ? Instant.FromDateTimeUtc(DateTime.Parse(model.ExpiresAt).ToUniversalTime(true)) : null;
                GatewayToken = model.GatewayToken;
                TokenDetails = model.TokenDetails;
                Visible = model.Visible;
                Active = model.Active;
            }
        }
    }
}
