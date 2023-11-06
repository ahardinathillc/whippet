using System;

namespace Athi.Whippet.Web.Mvc
{
    /// <summary>
    /// Represents an individual view (or endpoint) that is a member of a <see cref="WhippetController{TController}"/>. Provides extra details such as the unique view ID, name, description, and URL. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetViewProfile : IEqualityComparer<WhippetViewProfile>, ICloneable, IWhippetCloneable
    {
        /// <summary>
        /// Gets the unique ID of the view. This property is read-only.
        /// </summary>
        public Guid ViewID
        { get; private set; }

        /// <summary>
        /// Gets the parent ID of the controller that renders the view. This property is read-only.
        /// </summary>
        public Guid ControllerID
        { get; private set; }

        /// <summary>
        /// Gets or sets the friendly name of the view. This is the name that is displayed to the user. This property is read-only.
        /// </summary>
        public string FriendlyName
        { get; private set; }

        /// <summary>
        /// Gets the name of the view method that retrieves the view or invokes the endpoint. This property is read-only.
        /// </summary>
        public string Name
        { get; private set; }

        /// <summary>
        /// If the view is not an endpoint, retrieves the file name of the CSHTML file that is loaded and rendered to the browser. This property is read-only.
        /// </summary>
        public string Filename
        { get; private set; }

        /// <summary>
        /// Indicates whether the view or endpoint is a system view. This property is read-only.
        /// </summary>
        public bool IsSystem
        { get; private set; }

        public string FullyQualifiedID
        {
            get
            {
                return ControllerID.ToString("N") + "." + ViewID.ToString("N");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewProfile"/> class with no arguments.
        /// </summary>
        private WhippetViewProfile()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewProfile"/> class with the specified arguments.
        /// </summary>
        /// <param name="controllerId">Parent ID of the controller that renders the view.</param>
        /// <param name="viewId">Unique ID of the view.</param>
        /// <param name="name">Name of the view method that retrieves the view or invokes the endpoint.</param>
        /// <param name="friendlyName">Optional friendly name that is displayed to the user.</param>
        /// <param name="fileName">If the view is not an endpoint, the file name of the CSHTML file that is loaded and rendered to the browser.</param>
        /// <param name="isSystem">Indicates whether the view or endpoint is a system view.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetViewProfile(Guid controllerId, Guid viewId, string name, string friendlyName, string fileName, bool isSystem)
            : this()
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            else
            {
                ControllerID = controllerId;
                ViewID = viewId;
                Name = name;
                FriendlyName = friendlyName;
                Filename = fileName;
                IsSystem = isSystem;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewProfile"/> class with the specified arguments.
        /// </summary>
        /// <param name="controllerId">Parent ID of the controller that renders the view.</param>
        /// <param name="viewIdAndMethodName">Unique ID of the view and its method name invoked on the controller that renders the view.</param>
        /// <param name="friendlyName">Optional friendly name that is displayed to the user.</param>
        /// <param name="fileName">If the view is not an endpoint, the file name of the CSHTML file that is loaded and rendered to the browser.</param>
        /// <param name="isSystem">Indicates whether the view or endpoint is a system view.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetViewProfile(Guid controllerId, Tuple<Guid, string> viewIdAndMethodName, string friendlyName, string fileName, bool isSystem)
            : this(controllerId, (viewIdAndMethodName == null) ? Guid.Empty : viewIdAndMethodName.Item1, viewIdAndMethodName?.Item2, friendlyName, fileName, isSystem)
        {
            if (viewIdAndMethodName == null)
            {
                throw new ArgumentNullException(nameof(viewIdAndMethodName));
            }
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public object Clone()
        {
            WhippetViewProfile profile = new WhippetViewProfile();
            profile.ControllerID = ControllerID;
            profile.Filename = Filename;
            profile.FriendlyName = FriendlyName;
            profile.IsSystem = IsSystem;
            profile.Name = Name;
            profile.ViewID = ViewID;

            return profile;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object with the optional <see cref="Guid"/> that represents the user ID of the user who instantiated the new instance.
        /// </summary>
        /// <typeparam name="TObject">Type of object to return from the operation.</typeparam>
        /// <param name="createdBy"><see cref="Guid"/> ID of the user who instantiated the new instance.</param>
        /// <returns>Object of type <typeparamref name="TObject"/>.</returns>
        public TObject Clone<TObject>(Guid? createdBy = null)
        {
            return (TObject)(Clone());
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null) ? false : Equals(obj as WhippetViewProfile);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetViewProfile obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetViewProfile x, WhippetViewProfile y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals =
                    x.ViewID.Equals(y.ViewID)
                        && String.Equals(x.Name?.Trim(), y.Name?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.FriendlyName?.Trim(), y.FriendlyName?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(x.Filename?.Trim(), y.Filename?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                        && (x.IsSystem == y.IsSystem)
                        && x.ControllerID.Equals(y.ControllerID);
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current instance.
        /// </summary>
        /// <returns>Hash code for the current instance.</returns>
        public override int GetHashCode()
        {
            return FullyQualifiedID.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get the hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(WhippetViewProfile obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else
            {
                return obj.GetHashCode();
            }
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return (Name + " [" + ViewID.ToString() + "]").Trim();
        }
    }
}

