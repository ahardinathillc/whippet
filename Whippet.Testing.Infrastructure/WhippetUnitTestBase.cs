using System;
using Docker.DotNet;
using Docker.DotNet.Models;
using Athi.Whippet.Docker;

namespace Athi.Whippet.Testing.Infrastructure
{
    /// <summary>
    /// Base class for all unit tests in Whippet. This class must be inherited.
    /// </summary>
    public abstract class WhippetUnitTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUnitTestBase"/> class with no arguments.
        /// </summary>
        protected WhippetUnitTestBase()
        { }

        /// <summary>
        /// Creates a new <see cref="IDockerClient"/> with a Microsoft SQL Server database image preloaded.
        /// </summary>
        /// <param name="sqlImage">Microsoft SQL Server Docker image to use.</param>
        /// <returns><see cref="IDockerClient"/> object.</returns>
        protected virtual async Task<IDockerClient> CreateSqlServerImage(string sqlImage = DockerImageIndex.Databases.Microsoft.MsSql2022)
        {
            ImagesCreateParameters imageParameters = new ImagesCreateParameters();
            imageParameters.FromImage = sqlImage;

            return await CreateImage(imageParameters);
        }

        /// <summary>
        /// Creates a new <see cref="IDockerClient"/> with a Microsoft SQL Server database image already loaded in the client.
        /// </summary>
        /// <param name="sqlImage">Microsoft SQL Server Docker image to create a container from.</param>
        /// <param name="createImage">If <see langword="true"/>, will load the image by calling <see cref="CreateSqlServerImage"/> prior to initialization; otherwise, will create a container based on the supplied image name.</param>
        /// <returns><see cref="IDockerClient"/> object.</returns>
        protected virtual async Task<IDockerClient> CreateSqlServerContainer(string sqlImage = DockerImageIndex.Databases.Microsoft.MsSql2022, bool createImage = true)
        {
            IDockerClient client = null;
            bool failed = false;
            
            try
            {
                // https://github.com/dotnet/Docker.DotNet/
            }
            catch (Exception e)
            {
                failed = true;
                throw;
            }
            finally
            {
                if (failed && (client != null))
                {
                    client.Dispose();
                    client = null;
                }
            }
        }

        /// <summary>
        /// Creates a new <see cref="IDockerClient"/> with a Microsoft SQL Server database image preloaded.
        /// </summary>
        /// <param name="imageParameters"><see cref="ImagesCreateParameters"/> object that contains the options used to load the image to create a container from.</param>
        /// <param name="authConfig">Authorization options.</param>
        /// <param name="progress">Progress reporter of the operation.</param>
        /// <returns><see cref="IDockerClient"/> object with the configured image.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected virtual async Task<IDockerClient> CreateImage(ImagesCreateParameters imageParameters, AuthConfig authConfig = null, IProgress<JSONMessage> progress = null)
        {
            if (imageParameters == null)
            {
                throw new ArgumentNullException(nameof(imageParameters));
            }
            else
            {
                IDockerClient client = null;
                bool failed = false;

                try
                {
                    client = WhippetDockerClient.CreateLocalClient();
                    await client.Images.CreateImageAsync(imageParameters, authConfig, progress ?? new Progress<JSONMessage>());
                }
                catch (Exception e)
                {
                    failed = true;
                    throw;
                }
                finally
                {
                    if (failed)
                    {
                        if (client != null)
                        {
                            client.Dispose();
                            client = null;
                        }
                    }
                }

                return client;
            }
        }

        protected virtual async Task<IDockerClient> CreateContainer(CreateContainerParameters containerParameters)
        {
            
        }
    }
}
