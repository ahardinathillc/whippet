namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Taxes
{
    /// <summary>
    /// Indicates the categorization of the region an entity is tax exempt in.
    /// </summary>
    [Flags]
    public enum MultichannelOrderManagerTaxExemptCategory
    {
        /// <summary>
        /// Entity is not exempt from any taxes. This flag precedes all other flags.
        /// </summary>
        None = 0,
        /// <summary>
        /// Entity is exempt from city taxes.
        /// </summary>
        City = 1,
        /// <summary>
        /// Entity is exempt from state or province taxes.
        /// </summary>
        StateProvince = 2,
        /// <summary>
        /// Entity is exempt from national taxes (e.g., Value Added Tax).
        /// </summary>
        Nation = 4
    }
}
