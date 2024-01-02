using System;
using System.Net;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace Athi.Whippet.Docker.Containers.Databases
{
    /// <summary>
    /// Represents a Microsoft SQL Server 2022 Docker container instance.
    /// </summary>
    public class MsSqlServer2022Container : WhippetDockerContainerBase, IDockerContainer
    {
        private const ushort DEFAULT_MSSQL_PORT = 1433;

        /// <summary>
        /// Default password that is assigned to the system administrator login if no password is specified in the container startup commands.
        /// </summary>
        public const string DefaultPassword = @"<YourStrong@Pass20rd>";
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MsSqlServer2022Container"/> class with no arguments.
        /// </summary>
        public MsSqlServer2022Container()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MsSqlServer2022Container"/> class with the specified parameters.
        /// </summary>
        /// <param name="createParameters">Parameters used to create the container.</param>
        /// <param name="configuration">Host configuration.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MsSqlServer2022Container(CreateContainerParameters createParameters, HostConfig configuration = null)
            : base(createParameters ?? GetDefaultContainerParameters(), configuration)
        { }
        
        /// <summary>
        /// Creates a new <see cref="IDockerClient"/> with a Microsoft SQL Server database image already loaded in the client.
        /// </summary>
        /// <param name="client"><see cref="IDockerClient"/> that represents the Docker instance to create the container on.</param>
        /// <param name="parameters"><see cref="CreateContainerParameters"/> object that specifies the options to apply to the container.</param>
        /// <param name="configuration"><see cref="HostConfig"/> object that configures the Docker container environment.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="IDockerClient"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected override async Task<WhippetDockerResult<CreateContainerResponse>> CreateInternal(IDockerClient client, CreateContainerParameters parameters, HostConfig configuration = null, CancellationToken cancellationToken = default)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            else
            {
                WhippetDockerResult<CreateContainerResponse> result = null;
                
                CreateContainerResponse containerResponse = null;
                
                HostConfig hostConfig = null;
                
                try
                {
                    if (configuration != null)
                    {
                        parameters.HostConfig = configuration;
                    }

                    containerResponse = await client.Containers.CreateContainerAsync(parameters, cancellationToken);
                    result = new WhippetDockerResult<CreateContainerResponse>(containerResponse, client);
                }
                catch (Exception e)
                {
                    result = new WhippetDockerResult<CreateContainerResponse>(new WhippetResultContainer<CreateContainerResponse>(e), client);
                }

                return result;                
            }
        }

        /// <summary>
        /// Creates a default set of <see cref="CreateContainerParameters"/> with a default <see cref="HostConfig"/> assigned.
        /// </summary>
        /// <returns><see cref="CreateContainerParameters"/> object.</returns>
        private static CreateContainerParameters GetDefaultContainerParameters()
        {
            CreateContainerParameters parameters = null;

            HostConfig hostConfig = null;
            
            Dictionary<string, IList<PortBinding>> portBindingsIndex = null;
            
            List<PortBinding> portBindings = null;
            
            PortBinding defaultBinding = null;
            
            string[] environmentSettings = null;

            environmentSettings = new[] { "ACCEPT_EULA=Y", String.Format("MSSQL_SA_PASSWORD={0}", DefaultPassword) };

            parameters = new CreateContainerParameters();
            parameters.Image = DockerImageIndex.Databases.Microsoft.MsSql2022;
            parameters.Env = environmentSettings;
            parameters.ExposedPorts = new Dictionary<string, EmptyStruct>(new[] { CreateExposedPort(DEFAULT_MSSQL_PORT) });

            hostConfig = new HostConfig();

            portBindingsIndex = new Dictionary<string, IList<PortBinding>>();
            portBindings = new List<PortBinding>();

            defaultBinding = new PortBinding();
            defaultBinding.HostIP = IPAddress.Any.ToString();
            defaultBinding.HostPort = DEFAULT_MSSQL_PORT.ToString();

            portBindings.Add(defaultBinding);
            portBindingsIndex.Add(CreateExposedPort(DEFAULT_MSSQL_PORT).Key, portBindings);

            hostConfig.PortBindings = portBindingsIndex;

            parameters.HostConfig = hostConfig;
            
            return parameters;
        }
    }
}
