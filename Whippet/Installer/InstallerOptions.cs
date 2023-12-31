using System;

namespace Athi.Whippet.Installer
{
    /// <summary>
    /// Provides options to apply to a Whippet Framework installation, such as skipping seed data, automatic user creation, and more. This class must be inherited.
    /// </summary>
    public abstract class InstallerOptions
    {
        /// <summary>
        /// If <see langword="true"/>, will skip <b>all</b> seed activities for the data store configuration. This setting will override all subsequent seed flags.
        /// </summary>
        public virtual bool SkipAllSeed
        { get; set; }

        /// <summary>
        /// Specifies whether to skip creating addressing entities, such as cities, states, countries, postal codes, etc. Useful for creating lightweight installs for unit tests and debugging.
        /// </summary>
        public virtual bool SkipAddressingSeed
        { get; set; }
        
        /// <summary>
        /// Specifies whether to create an admin user. If this value is <see langword="true"/>, both <see cref="AdminUserName"/> and <see cref="AdminPassword"/> must be populated. 
        /// </summary>
        public virtual bool CreateAdminUser
        { get; set; }
        
        /// <summary>
        /// Gets or sets the root administrator account username. 
        /// </summary>
        public virtual string AdminUserName
        { get; set; }
        
        /// <summary>
        /// Gets or sets the root administrator password. 
        /// </summary>
        public virtual string AdminPassword
        { get; set; }
        
        /// <summary>
        /// Gets or sets the root tenant name.
        /// </summary>
        public virtual string RootTenantName
        { get; set; }
        
        /// <summary>
        /// Gets or sets the root tenant ID, which is a <see cref="Guid"/> value.
        /// </summary>
        public virtual string RootTenantID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the root tenant URL.
        /// </summary>
        public virtual string RootTenantUrl
        { get; set; }
        
        /// <summary>
        /// Gets or sets the connection string used to install the framework database.
        /// </summary>
        public virtual string SetupConnectionString
        { get; set; }
        
        /// <summary>
        /// Gets or sets the database vendor to use when installing the framework database. Used in conjunction with <see cref="SetupConnectionString"/>.
        /// </summary>
        public virtual string SetupDatabaseVendor
        { get; set; }
        
        /// <summary>
        /// Specifies whether the installation should be interactive.
        /// </summary>
        public virtual bool Interactive
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="InstallerOptions"/> class with no arguments.
        /// </summary>
        protected InstallerOptions()
        { }
    }
}
