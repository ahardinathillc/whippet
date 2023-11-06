using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Networking.Smtp.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="WhippetSmtpServerProfile"/> objects. This class must be inherited.
    /// </summary>
    public abstract class WhippetSmtpServerProfileCommandBase : WhippetCommand, IWhippetCommand, IWhippetSmtpServerProfileCommand
    {
        /// <summary>
        /// Gets the <see cref="WhippetSmtpServerProfile"/> instance to act upon in the data store. This property is read-only.
        /// </summary>
        public WhippetSmtpServerProfile ServerProfile
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IWhippetSmtpServerProfile"/> instance to act upon in the data store. This property is read-only.
        /// </summary>
        IWhippetSmtpServerProfile IWhippetSmtpServerProfileCommand.ServerProfile
        {
            get
            {
                return ServerProfile;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSmtpServerProfileCommandBase"/> class with no arguments.
        /// </summary>
        protected WhippetSmtpServerProfileCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSmtpServerProfileCommandBase"/> class with the specified <see cref="WhippetSmtpServerProfile"/>.
        /// </summary>
        /// <param name="profile"><see cref="WhippetSmtpServerProfile"/> instance to create or act upon in the data store.</param>
        protected WhippetSmtpServerProfileCommandBase(WhippetSmtpServerProfile profile)
            : base()
        {
            ServerProfile = profile;
        }
    }
}
