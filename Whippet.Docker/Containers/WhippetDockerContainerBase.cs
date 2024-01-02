using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.Text;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace Athi.Whippet.Docker.Containers
{
    /// <summary>
    /// Base class for all Docker containers in Whippet. This class must be inherited.
    /// </summary>
    /// <remarks>See <a href="https://docs.docker.com/engine/api/sdk/">Docker Docs</a> for more information on working with Docker via the API.</remarks>
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
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResult> Create(IDockerClient client, CancellationToken cancellationToken = default)
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
                    response = await CreateInternal(client, Parameters, HostConfiguration, cancellationToken);

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
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetDockerResult{T}"/> containing the result of the operation.</returns>
        protected abstract Task<WhippetDockerResult<CreateContainerResponse>> CreateInternal(IDockerClient client, CreateContainerParameters createParameters, HostConfig configuration = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes the current container.
        /// </summary>
        /// <param name="client"><see cref="IDockerClient"/> that represents the Docker instance the current container is hosted on.</param>
        /// <param name="options"><see cref="ContainerRemoveParameters"/> object that specifies options to use when removing the container.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public virtual async Task<WhippetResult> Delete(IDockerClient client, ContainerRemoveParameters options = null, CancellationToken cancellationToken = default)
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
                    await client.Containers.RemoveContainerAsync(ID, options, cancellationToken);
                }
                catch (Exception e)
                {
                    result = new WhippetResult(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Attempts to start the current container on the specified <see cref="IDockerClient"/>. Will return a <see cref="WhippetResultSeverity.Warning"/> if the container failed to start but did not throw an exception.
        /// </summary>
        /// <param name="client"><see cref="IDockerClient"/> to start the container on.</param>
        /// <param name="options"><see cref="ContainerStartParameters"/> to apply when starting the container.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetDockerResult{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetDockerResult<bool>> Start(IDockerClient client, ContainerStartParameters options = null, CancellationToken cancellationToken = default)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            else
            {
                WhippetDockerResult<bool> result = null;
                bool success = false;
                
                try
                {
                    success = await client.Containers.StartContainerAsync(ID, options, cancellationToken);
                    result = new WhippetDockerResult<bool>(success, client, success ? WhippetResultSeverity.Success : WhippetResultSeverity.Warning);
                }
                catch (Exception e)
                {
                    result = new WhippetDockerResult<bool>(new WhippetResultContainer<bool>(e), client);
                }

                return result;
            }
        }

        /// <summary>
        /// Attempts to stop the current container on the specified <see cref="IDockerClient"/>. Will return a <see cref="WhippetResultSeverity.Warning"/> if the container failed to stop but did not throw an exception.
        /// </summary>
        /// <param name="client"><see cref="IDockerClient"/> to stop the container on.</param>
        /// <param name="options"><see cref="ContainerStopParameters"/> to apply when stopping the container.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetDockerResult{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetDockerResult<bool>> Stop(IDockerClient client, ContainerStopParameters options = null, CancellationToken cancellationToken = default)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            else
            {
                WhippetDockerResult<bool> result = null;
                bool success = false;
                
                try
                {
                    success = await client.Containers.StopContainerAsync(ID, options, cancellationToken);
                    result = new WhippetDockerResult<bool>(success, client, success ? WhippetResultSeverity.Success : WhippetResultSeverity.Warning);
                }
                catch (Exception e)
                {
                    result = new WhippetDockerResult<bool>(new WhippetResultContainer<bool>(e), client);
                }

                return result;
            }
        }

        /// <summary>
        /// Creates an exposed port entry for a Docker container.
        /// </summary>
        /// <param name="portNumber">Port number.</param>
        /// <param name="protocol">Protocol the port uses.</param>
        /// <returns><see cref="KeyValuePair{TKey, TValue}"/> containing the port configuration.</returns>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        protected static KeyValuePair<string, EmptyStruct> CreateExposedPort(ushort portNumber, ProtocolType protocol = ProtocolType.Tcp)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(portNumber);
            builder.Append('/');
            
            switch (protocol)
            {
                case ProtocolType.Unknown:
                case ProtocolType.Unspecified:
                    throw new InvalidEnumArgumentException(nameof(protocol), Convert.ToInt32(protocol), typeof(ProtocolType));
                default:
                    builder.Append(protocol.ToString().ToLower());
                    break;
            }
            
            return new KeyValuePair<string, EmptyStruct>(builder.ToString(), new EmptyStruct());
        }
    }
}
