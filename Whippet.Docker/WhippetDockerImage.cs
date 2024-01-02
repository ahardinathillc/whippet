using System;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace Athi.Whippet.Docker
{
    /// <summary>
    /// Represents a Docker disk image. Docker containers are created from images.
    /// </summary>
    public class WhippetDockerImage : IDockerImage
    {
        private readonly Progress<JSONMessage> _DefaultProgress;
        private readonly ImagesCreateParameters _ImageCreateParams;
        private readonly AuthConfig _Authorization;
        
        /// <summary>
        /// Gets the image name. This property is read-only.
        /// </summary>
        public string Name
        {
            get
            {
                return Properties.FromImage;
            }
        }

        /// <summary>
        /// Gets the <see cref="System.Progress{T}"/> delegate that handles callbacks from the client. This property is read-only.
        /// </summary>
        public Progress<JSONMessage> Progress
        {
            get
            {
                return _DefaultProgress;
            }
        }

        /// <summary>
        /// Gets the authorization values to use when obtaining the image (if any). This property is read-only. 
        /// </summary>
        public AuthConfig Authorization
        {
            get
            {
                return _Authorization;
            }
        }

        /// <summary>
        /// Gets the properties of the <see cref="WhippetDockerImage"/> that were supplied upon instantiation needed to obtain the image. This property is read-only.
        /// </summary>
        public ImagesCreateParameters Properties
        {
            get
            {
                return _ImageCreateParams;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDockerImage"/> class with no arguments.
        /// </summary>
        private WhippetDockerImage()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDockerImage"/> class with the specified parameters.
        /// </summary>
        /// <param name="image">Image name.</param>
        /// <param name="authorization">Authorization parameters used when obtaining the image.</param>
        /// <param name="progress"><see cref="System.Progress{T}"/> delegate that provides callbacks during the event.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetDockerImage(string image, AuthConfig authorization = null, Progress<JSONMessage> progress = null)
            : this(new ImagesCreateParameters() { FromImage = image }, authorization, progress)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(image);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDockerImage"/> class with the specified parameters.
        /// </summary>
        /// <param name="createParameters">Arguments to provide to Docker when obtaining the image.</param>
        /// <param name="authorization">Authorization parameters used when obtaining the image.</param>
        /// <param name="progress"><see cref="System.Progress{T}"/> delegate that provides callbacks during the event.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetDockerImage(ImagesCreateParameters createParameters, AuthConfig authorization = null, Progress<JSONMessage> progress = null)
            : this()
        {
            ArgumentNullException.ThrowIfNull(createParameters);

            _ImageCreateParams = createParameters;
            _Authorization = authorization;
            _DefaultProgress = progress;
        }

        /// <summary>
        /// Downloads and stores the current image into the specified <see cref="IDockerClient"/>.
        /// </summary>
        /// <returns><see cref="WhippetResult"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResult> Create(IDockerClient client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                try
                {
                    await client.Images.CreateImageAsync(Properties, Authorization, Progress ?? new Progress<JSONMessage>());
                }
                catch (Exception e)
                {
                    result = new WhippetResult(e);
                }

                return result;
            }
        }
    }
}
