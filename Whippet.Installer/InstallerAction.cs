namespace Athi.Whippet.Installer
{
    /// <summary>
    /// Represents a an individual command to execute in order to set up the application. This class must be inherited. 
    /// </summary>
    public abstract class InstallerAction
    {
        /// <summary>
        /// Gets or sets the installer action title.
        /// </summary>
        public virtual string ActionTitle
        { get; private set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="InstallerAction"/> class with no arguments.
        /// </summary>
        private InstallerAction()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstallerAction"/> class with the specified action title.
        /// </summary>
        /// <param name="actionTitle">Short descriptive title of the installer action that is being executed.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected InstallerAction(string actionTitle)
            : this()
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(actionTitle);
            ActionTitle = actionTitle;
        }

        /// <summary>
        /// Executes the installer action with the specified parameters (if any).
        /// </summary>
        /// <returns><see cref="WhippetResult"/> object containing the result of the operation.</returns>
        public abstract WhippetResult DoAction();

        /// <summary>
        /// For installation steps that only require one <see cref="InstallerAction"/>, returns the current instance as an <see cref="InstallerActionCollection"/> with the instance as the sole member of the collection.
        /// </summary>
        /// <returns><see cref="InstallerActionCollection"/> object.</returns>
        public virtual InstallerActionCollection ToInstallerActionCollection()
        {
            return new InstallerActionCollection() { { 1, this } };
        }
    }
}
