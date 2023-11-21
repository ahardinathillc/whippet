namespace Athi.Whippet.Adobe.Magento.Store
{
    /// <summary>
    /// Indicates the type of link used for the store in a store's configuration.
    /// </summary>
    public enum StoreLinkType
    {
        /// <summary>
        /// Base URL for the store.
        /// </summary>
        Store,
        /// <summary>
        /// Base hyperlink URL for the store.
        /// </summary>
        Link,
        /// <summary>
        /// Base static URL for the store.
        /// </summary>
        Static,
        /// <summary>
        /// Base media URl for the store.
        /// </summary>
        Media,
        /// <summary>
        /// Base secure (HTTPS) URL for the store.
        /// </summary>
        SecureStore,
        /// <summary>
        /// Base secure (HTTPS) hyperlink URL for the store.
        /// </summary>
        SecureLink,
        /// <summary>
        /// Base secure (HTTPS) static URL for the store.
        /// </summary>
        SecureStatic,
        /// <summary>
        /// Base secure (HTTPS) media URL for the store.
        /// </summary>
        SecureMedia
    }
}
