using System;
using Docker.DotNet;

namespace Athi.Whippet.Docker
{
    /// <summary>
    /// Serves as a wrapper class around <see cref="DockerClient"/> for use in the Whippet framework. 
    /// </summary>
    public class WhippetDockerClient : IDockerClient, IDisposable
    {
        /// <summary>
        /// Gets the internal client. This property is read-only.
        /// </summary>
        protected virtual DockerClient Client
        { get; private set; }

        /// <summary>
        /// Gets the client configuration for the current instance.
        /// </summary>
        public virtual DockerClientConfiguration Configuration
        {
            get
            {
                return Client.Configuration;
            }
        }

        /// <summary>
        /// Specifies the default timeout for connecting to a Docker instance.
        /// </summary>
        public virtual TimeSpan DefaultTimeout
        {
            get
            {
                return Client.DefaultTimeout;
            }
            set
            {
                Client.DefaultTimeout = value;
            }
        }

        /// <summary>
        /// Gets the Docker containers that are available on the current instance. This property is read-only.
        /// </summary>
        public virtual IContainerOperations Containers
        {
            get
            {
                return Client.Containers;
            }
        }

        /// <summary>
        /// Gets the Docker images available on the current instance. This property is read-only.
        /// </summary>
        public virtual IImageOperations Images
        {
            get
            {
                return Client.Images;
            }
        }

        /// <summary>
        /// Gets the available networks available on the current instance. This property is read-only.
        /// </summary>
        public virtual INetworkOperations Networks
        {
            get
            {
                return Client.Networks;
            }
        }

        /// <summary>
        /// Gets the available disk volumes available on the current instance. This property is read-only.
        /// </summary>
        public virtual IVolumeOperations Volumes
        {
            get
            {
                return Client.Volumes;
            }
        }

        /// <summary>
        /// Gets the available secrets on the current instance. This property is read-only.
        /// </summary>
        public virtual ISecretsOperations Secrets
        {
            get
            {
                return Client.Secrets;
            }
        }

        /// <summary>
        /// Gets the available configuration options on the current instance. This property is read-only.
        /// </summary>
        public virtual IConfigOperations Configs
        {
            get
            {
                return Client.Configs;
            }
        }

        /// <summary>
        /// Gets the available swarm operations available on the current instance. This property is read-only.
        /// </summary>
        public virtual ISwarmOperations Swarm
        {
            get
            {
                return Client.Swarm;
            }
        }

        /// <summary>
        /// Gets the available tasks currently registered on the current instance. This property is read-only.
        /// </summary>
        public virtual ITasksOperations Tasks
        {
            get
            {
                return Client.Tasks;
            }
        }

        /// <summary>
        /// Gets the system daemon of the current instance. This property is read-only.
        /// </summary>
        public virtual ISystemOperations System
        {
            get
            {
                return Client.System;
            }
        }

        /// <summary>
        /// Gets the available plugin of the current instance. This property is read-only.
        /// </summary>
        public virtual IPluginOperations Plugin
        {
            get
            {
                return Client.Plugin;
            }
        }

        /// <summary>
        /// Gets the available execution operations available on the current instance. This property is read-only.
        /// </summary>
        public virtual IExecOperations Exec
        {
            get
            {
                return Client.Exec;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DockerClient"/> class with no arguments.
        /// </summary>
        private WhippetDockerClient()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDockerClient"/> class with the specified <see cref="DockerClient"/> object.
        /// </summary>
        /// <param name="client"><see cref="DockerClient"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetDockerClient(DockerClient client)
            : this()
        {
            ArgumentNullException.ThrowIfNull(client);
            Client = client;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDockerClient"/> class with the specified <see cref="DockerClientConfiguration"/> object.
        /// </summary>
        /// <param name="configuration"><see cref="DockerClientConfiguration"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetDockerClient(DockerClientConfiguration configuration)
            : this((configuration == null) ? null : configuration.CreateClient())
        {
            ArgumentNullException.ThrowIfNull(configuration);
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public virtual void Dispose()
        {
            Client.Dispose();
        }

        /// <summary>
        /// Creates a new <see cref="IDockerClient"/> that points to the local Docker instance on the host machine.
        /// </summary>
        /// <returns><see cref="IDockerClient"/> object.</returns>
        public static IDockerClient CreateLocalClient()
        {
            return new WhippetDockerClient(new DockerClientConfiguration().CreateClient());
        }
    }
}
