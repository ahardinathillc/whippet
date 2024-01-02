using System;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace Athi.Whippet.Docker.Containers
{
    /// <summary>
    /// Base class for all Docker containers in Whippet. This class must be inherited.
    /// </summary>
    public abstract class WhippetDockerContainerBase : IDockerContainer
    {
        private CreateContainerResponse _response;
        
        /// <summary>
        /// Gets the ID of the container. This property is read-only.
        /// </summary>
        public string ID
        {
            get
            {
                return Response.ID;
            }
        }

        /// <summary>
        /// Gets all warnings that were returned by Docker upon container instantiation. This property is read-only.
        /// </summary>
        public IEnumerable<string> Warnings
        {
            get
            {
                return Response.Warnings;
            }
        }

        /// <summary>
        /// Gets or sets the response from Docker when the container was created.
        /// </summary>
        private CreateContainerResponse Response
        {
            get
            {
                if (_response == null)
                {
                    _response = new CreateContainerResponse();
                }

                return _response;
            }
            set
            {
                _response = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the parameters used to create the container.
        /// </summary>
        private CreateContainerParameters Parameters
        { get; set; }
        
        /// <summary>
        /// Gets or sets the host configuration.
        /// </summary>
        private HostConfig HostConfiguration
        { get; set; }

        /// <summary>
        /// Specifies whether the container has been created. This property is read-only.
        /// </summary>
        public bool Created
        {
            get
            {
                return !String.IsNullOrWhiteSpace(ID);
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDockerContainerBase"/> class with no arguments.
        /// </summary>
        protected WhippetDockerContainerBase()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDockerContainerBase"/> class with the specified parameters.
        /// </summary>
        /// <param name="createParameters">Parameters used to create the container.</param>
        /// <param name="configuration">Host configuration.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetDockerContainerBase(CreateContainerParameters createParameters, HostConfig configuration = null)
            : this()
        {
            ArgumentNullException.ThrowIfNull(createParameters);
            
            Parameters = createParameters;
            HostConfiguration = configuration;
        }

        /// <summary>
        /// Creates a new instance of the current container.
        /// </summary>
        /// <param name="client"><see cref="IDockerClient"/> that represents the Docker instance to create the container on.</param>
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
                WhippetDockerResult<CreateContainerResponse> response = null;
                
                try
                {
                    response = await CreateInternal(client, Parameters, HostConfiguration);

                    if (response.IsSuccess)
                    {
                        Response = response.Item;
                    }
                    else
                    {
                        throw response.Exception;
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResult(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Creates a new instance of the current container. This method must be overridden.
        /// </summary>
        /// <param name="client"><see cref="IDockerClient"/> that represents the Docker instance to create the container on.</param>
        /// <param name="createParameters">Parameters supplied to Docker on how to create the container.</param>
        /// <param name="configuration">Host configuration.</param>
        /// <returns><see cref="WhippetDockerResult{T}"/> containing the result of the operation.</returns>
        protected abstract Task<WhippetDockerResult<CreateContainerResponse>> CreateInternal(IDockerClient client, CreateContainerParameters createParameters, HostConfig configuration = null);

        /// <summary>
        /// Deletes the current container.
        /// </summary>
        /// <param name="client"><see cref="IDockerClient"/> that represents the Docker instance the current container is hosted on.</param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public virtual async Task<WhippetResult> Delete(IDockerClient client, ContainerRemoveParameters options = null)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            else if (!Created)
            {
                throw new InvalidOperationException();
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                try
                {
                    await client.Containers.RemoveContainerAsync(ID, options);
                }
                catch (Exception e)
                {
                    result = new WhippetResult(e);
                }

                return result;
            }
        }
        
        /// <summary>
        /// Removes the container with the specified ID from the given <see cref="IDockerClient"/>.
        /// </summary>
        /// <param name="client"><see cref="IDockerClient"/> of the Docker instance to remove the container from.</param>
        /// <param name="containerId">ID of the Docker container to remove.</param>
        /// <param name="parameters"><see cref="ContainerRemoveParameters"/> object that provides extra options to apply.</param>
        /// <returns><see cref="WhippetResult"/> of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResult> RemoveContainer(IDockerClient client, string containerId, ContainerRemoveParameters parameters = null)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            else if (String.IsNullOrWhiteSpace(containerId))
            {
                throw new ArgumentNullException(nameof(containerId));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                try
                {
                    await client.Containers.RemoveContainerAsync(containerId, parameters);
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
