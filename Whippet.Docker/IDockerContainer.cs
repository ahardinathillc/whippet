using System;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace Athi.Whippet.Docker
{
    /// <summary>
    /// Represents a Docker container.
    /// </summary>
    public interface IDockerContainer
    {
        /// <summary>
        /// Gets the ID of the container. This property is read-only.
        /// </summary>
        string ID
        { get; }

        /// <summary>
        /// Gets all warnings that were returned by Docker upon container instantiation. This property is read-only.
        /// </summary>
        IEnumerable<string> Warnings
        { get; }
        
        /// <summary>
        /// Specifies whether the container has been created. This property is read-only.
        /// </summary>
        bool Created
        { get; }

        /// <summary>
        /// Creates a new instance of the current container.
        /// </summary>
        /// <param name="client"><see cref="IDockerClient"/> that represents the Docker instance to create the container on.</param>
        /// <returns><see cref="WhippetResult"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<WhippetResult> Create(IDockerClient client);

        /// <summary>
        /// Deletes the current container.
        /// </summary>
        /// <param name="client"><see cref="IDockerClient"/> that represents the Docker instance the current container is hosted on.</param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        Task<WhippetResult> Delete(IDockerClient client, ContainerRemoveParameters options = null);
    }
}
