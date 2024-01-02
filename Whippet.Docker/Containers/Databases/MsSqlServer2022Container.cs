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
        private const short DEFAULT_MSSQL_PORT = 1433;

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
            : base(createParameters, configuration)
        { }
        
        /// <summary>
        /// Creates a new <see cref="IDockerClient"/> with a Microsoft SQL Server database image already loaded in the client.
        /// </summary>
        /// <param name="client"><see cref="IDockerClient"/> that represents the Docker instance to create the container on.</param>
        /// <param name="parameters"><see cref="CreateContainerParameters"/> object that specifies the options to apply to the container.</param>
        /// <param name="configuration"><see cref="HostConfig"/> object that configures the Docker container environment.</param>
        /// <returns><see cref="IDockerClient"/> object.</returns>
        protected override async Task<WhippetDockerResult<CreateContainerResponse>> CreateInternal(IDockerClient client, CreateContainerParameters parameters, HostConfig configuration = null)
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
                
                Dictionary<string, IList<PortBinding>> portBindingsIndex = null;
                
                List<PortBinding> portBindings = null;
                
                PortBinding defaultBinding = null;
                
                try
                {
                    if (parameters == null)
                    {
                        parameters = new CreateContainerParameters();
                        parameters.Image = DockerImageIndex.Databases.Microsoft.MsSql2022;

                        if (configuration != null)
                        {
                            parameters.HostConfig = configuration;
                        }
                        else
                        {
                            hostConfig = new HostConfig();
                            portBindingsIndex = new Dictionary<string, IList<PortBinding>>();
                            portBindings = new List<PortBinding>();

                            defaultBinding = new PortBinding();
                            defaultBinding.HostIP = IPAddress.Loopback.ToString();
                            defaultBinding.HostPort = DEFAULT_MSSQL_PORT.ToString();

                            portBindings.Add(defaultBinding);
                            portBindingsIndex.Add(DEFAULT_MSSQL_PORT.ToString(), portBindings);

                            hostConfig.PortBindings = portBindingsIndex;
                        }
                    }

                    containerResponse = await client.Containers.CreateContainerAsync(parameters);
                    result = new WhippetDockerResult<CreateContainerResponse>(containerResponse, client);
                }
                catch (Exception e)
                {
                    result = new WhippetDockerResult<CreateContainerResponse>(new WhippetResultContainer<CreateContainerResponse>(e), client);
                }
                finally
                {
                    if (!result.IsSuccess)
                    {
                        client.Dispose();
                    }
                }

                return result;                
            }
        }
    }
}
