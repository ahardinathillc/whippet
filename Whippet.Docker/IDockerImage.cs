using System;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace Athi.Whippet.Docker
{
    public interface IDockerImage
    {
        /// <summary>
        /// Gets the image name. This property is read-only.
        /// </summary>
        string Name
        { get; }

        /// <summary>
        /// Gets the <see cref="System.Progress{T}"/> delegate that handles callbacks from the client. This property is read-only.
        /// </summary>
        Progress<JSONMessage> Progress
        { get; }

        /// <summary>
        /// Gets the authorization values to use when obtaining the image (if any). This property is read-only. 
        /// </summary>
        AuthConfig Authorization
        { get; }

        /// <summary>
        /// Gets the properties of the <see cref="WhippetDockerImage"/> that were supplied upon instantiation needed to obtain the image. This property is read-only.
        /// </summary>
        ImagesCreateParameters Properties
        { get; }

        /// <summary>
        /// Downloads and stores the current image into the specified <see cref="IDockerClient"/>.
        /// </summary>
        /// <returns><see cref="WhippetResult"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<WhippetResult> Create(IDockerClient client);
    }
}
