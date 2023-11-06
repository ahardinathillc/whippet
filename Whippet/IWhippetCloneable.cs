using System;

namespace Athi.Whippet
{
    /// <summary>
    /// Supports cloning, which creates a new instance of a class with the same value as the existing instance.
    /// </summary>
    public interface IWhippetCloneable : ICloneable
    {
        /// <summary>
        /// Creates a duplicate instance of the current object with the optional <see cref="Guid"/> that represents the user ID of the user who instantiated the new instance.
        /// </summary>
        /// <typeparam name="TObject">Type of object to return from the operation.</typeparam>
        /// <param name="createdBy"><see cref="Guid"/> ID of the user who instantiated the new instance.</param>
        /// <returns>Object of type <typeparamref name="TObject"/>.</returns>
        TObject Clone<TObject>(Guid? createdBy = null);
    }
}

