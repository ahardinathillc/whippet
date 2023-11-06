using System;

namespace Athi.Whippet.Data.Database.SQLite
{
    /// <summary>
    /// Initializes one or more <see cref="IWhippetEntity"/> objects in a SQLite instance if they do not already exist.
    /// </summary>
    /// <typeparam name="TEntity"><see cref="IWhippetEntity"/> data type to initialize.</typeparam>
    public interface ISQLiteInitializable<TEntity>
        where TEntity : IWhippetEntity, new()
    {
        /// <summary>
        /// Creates the required table that maps to <typeparamref name="TEntity"/> in the SQLite instance.
        /// </summary>
        void Initialize();
    }
}

