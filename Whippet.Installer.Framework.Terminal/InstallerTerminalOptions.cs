using System;
using CommandLine;

namespace Athi.Whippet.Installer.Framework.Terminal
{
    /// <summary>
    /// Provides options to apply to a Whippet Framework installation, such as skipping seed data, automatic user creation, and more. This class cannot be inherited.
    /// </summary>
    internal sealed class InstallerTerminalOptions : InstallerOptions
    {
        /// <summary>
        /// If <see langword="true"/>, will skip <b>all</b> seed activities for the data store configuration. This setting will override all subsequent seed flags.
        /// </summary>
        [Option("noseed", Default = false, HelpText = "Skips all seed activities for the data store configuration. This setting will override all subsequent seed options.")]
        public override bool SkipAllSeed
        { get; set; }

        /// <summary>
        /// Specifies whether to skip creating addressing entities, such as cities, states, countries, postal codes, etc. Useful for creating lightweight installs for unit tests and debugging.
        /// </summary>
        [Option("noaddress", Default = false, HelpText = "Skips the addressing entities seed. Useful for creating lightweight installs for unit tests and debugging.")]
        public override bool SkipAddressingSeed
        { get; set; }
        
        /// <summary>
        /// Specifies whether the installation should be interactive.
        /// </summary>
        [Option("interactive", Default = true, HelpText = "Enables or disables an interactive installation.")]
        public override bool Interactive
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="InstallerTerminalOptions"/> class with no arguments.
        /// </summary>
        public InstallerTerminalOptions()
            : base()
        { }
    }
}
