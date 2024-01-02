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
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<WhippetResult> Create(IDockerClient client, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes the current container.
        /// </summary>
        /// <param name="client"><see cref="IDockerClient"/> that represents the Docker instance the current container is hosted on.</param>
        /// <param name="options"><see cref="ContainerRemoveParameters"/> object that specifies options to use when removing the container.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        Task<WhippetResult> Delete(IDockerClient client, ContainerRemoveParameters options = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Attempts to start the current container on the specified <see cref="IDockerClient"/>. Will return a <see cref="WhippetResultSeverity.Warning"/> if the container failed to start but did not throw an exception.
        /// </summary>
        /// <param name="client"><see cref="IDockerClient"/> to start the container on.</param>
        /// <param name="options"><see cref="ContainerStartParameters"/> to apply when starting the container.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetDockerResult{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<WhippetDockerResult<bool>> Start(IDockerClient client, ContainerStartParameters options = null, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Attempts to stop the current container on the specified <see cref="IDockerClient"/>. Will return a <see cref="WhippetResultSeverity.Warning"/> if the container failed to stop but did not throw an exception.
        /// </summary>
        /// <param name="client"><see cref="IDockerClient"/> to stop the container on.</param>
        /// <param name="options"><see cref="ContainerStopParameters"/> to apply when stopping the container.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetDockerResult{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<WhippetDockerResult<bool>> Stop(IDockerClient client, ContainerStopParameters options = null, CancellationToken cancellationToken = default);
    }
}
