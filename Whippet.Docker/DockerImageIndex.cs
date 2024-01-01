namespace Athi.Whippet.Docker
{
    /// <summary>
    /// Provides an index of available known Docker images used by Whippet. This class cannot be inherited.
    /// </summary>
    public static class DockerImageIndex
    {
        /// <summary>
        /// Provides an index of available known Docker database images used by Whippet. This class cannot be inherited.
        /// </summary>
        public static class Databases
        {
            /// <summary>
            /// Provides an index of available known Docker Microsoft database images used by Whippet. This class cannot be inherited.
            /// </summary>
            public static class Microsoft
            {
                /// <summary>
                /// Microsoft SQL Server 2022.
                /// </summary>
                public const string MsSql2022 = "mcr.microsoft.com/mssql/server:2022-latest";
            }
        }
    }
}
