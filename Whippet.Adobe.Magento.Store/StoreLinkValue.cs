using System.ComponentModel;

namespace Athi.Whippet.Adobe.Magento.Store
{
    /// <summary>
    /// Represents the <see cref="Uri"/> value for a <see cref="Store"/> link. This class cannot be inherited.
    /// </summary>
    public sealed class StoreLinkValue
    {
        /// <summary>
        /// Gets or sets the URL of the store link.
        /// </summary>
        public Uri URL
        { get; set; }
        
        /// <summary>
        /// Gets the link type of the <see cref="StoreLinkValue"/>. This property is read-only.
        /// </summary>
        public StoreLinkType Type
        { get; private set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreLinkValue"/> class with no arguments. 
        /// </summary>
        private StoreLinkValue()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreLinkValue"/> class with the specified <see cref="StoreLinkType"/> and URL.
        /// </summary>
        /// <param name="type"><see cref="StoreLinkType"/> that specifies the type of link represented.</param>
        /// <param name="url">URL of the link.</param>
        internal StoreLinkValue(StoreLinkType type, Uri url)
            : this()
        {
            Type = type;
            URL = url;
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            string typeString = null;

            switch (Type)
            {
                case StoreLinkType.Store:
                    typeString = "Store";
                    break;
                case StoreLinkType.Link:
                    typeString = "Link";
                    break;
                case StoreLinkType.Static:
                    typeString = "Static";
                    break;
                case StoreLinkType.Media:
                    typeString = "Media";
                    break;
                case StoreLinkType.SecureStore:
                    typeString = "Store (Secure)";
                    break;
                case StoreLinkType.SecureLink:
                    typeString = "Link (Secure)";
                    break;
                case StoreLinkType.SecureStatic:
                    typeString = "Static (Secure)";
                    break;
                case StoreLinkType.SecureMedia:
                    typeString = "Media (Secure)";
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(Type), Convert.ToInt32(Type), typeof(StoreLinkType));
            }

            return "[Link Type: " + typeString + " | URL: " + ((URL == null) ? String.Empty : URL.ToString()) + "]";
        }
    }
}
