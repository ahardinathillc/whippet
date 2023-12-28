namespace Athi.Whippet.Localization.Addressing.ServiceManagers
{
    /// <summary>
    /// Provides an index of all resource (.resx) files in the assembly.
    /// </summary>
    internal static class ResourceFileIndex
    {
        private const string FILE_EXT = ".resx";

        public const string Addressing_Cities_PostalCodes = nameof(Addressing_Cities_PostalCodes) + FILE_EXT;
        public const string Addressing_Countries = nameof(Addressing_Countries) + FILE_EXT;
        public const string Addressing_StateProvinces = nameof(Addressing_StateProvinces) + FILE_EXT;
    }
}
