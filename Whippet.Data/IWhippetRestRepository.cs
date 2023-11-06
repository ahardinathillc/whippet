using System;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Represents a generic repository that is independent of the backing data store for <see cref="IWhippetEntity"/> objects that are stored on a remote server accessed via a RESTful interface.
    /// </summary>
    /// <typeparam name="TEntity">Type of object to store in the repository.</typeparam>
    /// <typeparam name="TKey">Non-nullable type of key that <typeparamref name="TEntity"/> uses.</typeparam>
    public interface IWhippetRestRepository<TEntity, TKey> : IWhippetEntityRepository<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        /// <summary>
        /// Gets the authorization bearer token for making requests. This property is read-only.
        /// </summary>
        string BearerToken
        { get; }
    }
}

