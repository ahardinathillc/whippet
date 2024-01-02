using System;
using Docker.DotNet;
using Docker.DotNet.Models;
using Athi.Whippet.Testing.Infrastructure;
using Athi.Whippet.Docker.Containers.Databases;

namespace Athi.Whippet.Docker.UnitTests
{
    /// <summary>
    /// Provides unit tests for creating and running Microsoft SQL Server unit tests.
    /// </summary>
    [TestClass]
    public class MsSqlServerDockerTest : WhippetUnitTestBase
    {
        private const string TEST_CATEGORY = "Docker Initialization";
        
        /// <summary>
        /// Tests the ability to load an image from Docker.
        /// </summary>
        [TestMethod]
        [TestCategory(TEST_CATEGORY)]
        [Description("Load an image from the Docker Hub.")]
        public virtual async Task Test_1_LoadImageTest()
        {
            IDockerClient client = null;
            IDockerImage image = null;

            WhippetResult result = WhippetResult.Success;
            
            try
            {
                client = WhippetDockerClient.CreateLocalClient();
                image = new WhippetDockerImage(DockerImageIndex.Databases.Microsoft.MsSql2022);

                result = await image.Create(client);
                result.ThrowIfFailed();
            }
            finally
            {
                if (client != null)
                {
                    client.Dispose();
                    client = null;
                }
            }
        }

        /// <summary>
        /// Tests the ability to crete a new Docker container.
        /// </summary>
        [TestMethod]
        [TestCategory(TEST_CATEGORY)]
        [Description("Create a new Docker container instance.")]
        public virtual async Task Test_2_CreateContainerTest()
        {
            IDockerClient client = null;
            IDockerImage image = null;
            IDockerContainer container = null;
            
            ContainerRemoveParameters removeParameters = null;
            
            WhippetResult result = WhippetResult.Success;            
            
            try
            {
                client = WhippetDockerClient.CreateLocalClient();
                image = new WhippetDockerImage(DockerImageIndex.Databases.Microsoft.MsSql2022);

                result = await image.Create(client);
                result.ThrowIfFailed();

                container = new MsSqlServer2022Container();
                
                result = await container.Create(client);
                result.ThrowIfFailed();
                
                Assert.IsTrue(container.Created);
            }
            finally
            {
                if (client != null && container != null && container.Created)
                {
                    removeParameters = new ContainerRemoveParameters();
                    removeParameters.Force = true;
                    
                    result = await container.Delete(client);

                    if (!result.IsSuccess)
                    {
                        WriteWarning("Container " + container.ID + " was not removed from Docker instance.");
                    }
                }

                if (client != null)
                {
                    client.Dispose();
                    client = null;
                }
            }
        }

        /// <summary>
        /// Tests starting a Docker container.
        /// </summary>
        [TestMethod]
        [TestCategory(TEST_CATEGORY)]
        [Description("Start a Docker container image.")]
        public virtual async Task Test_3_StartContainerTest()
        {
            IDockerClient client = null;
            IDockerImage image = null;
            IDockerContainer container = null;

            ContainerRemoveParameters removeParameters = null;
            
            WhippetResult result = WhippetResult.Success;
            WhippetDockerResult<bool> dockerResult = null;
            
            try
            {
                client = WhippetDockerClient.CreateLocalClient();
                image = new WhippetDockerImage(DockerImageIndex.Databases.Microsoft.MsSql2022);

                result = await image.Create(client);
                result.ThrowIfFailed();

                container = new MsSqlServer2022Container();
                
                result = await container.Create(client);
                result.ThrowIfFailed();
                
                Assert.IsTrue(container.Created);

                dockerResult = await container.Start(client);
                dockerResult.ThrowIfFailed();

                Assert.IsTrue(dockerResult.IsSuccess);
            }
            finally
            {
                if (client != null && container != null && container.Created)
                {
                    removeParameters = new ContainerRemoveParameters();
                    removeParameters.Force = true;
                    
                    result = await container.Delete(client, removeParameters);

                    if (!result.IsSuccess)
                    {
                        WriteWarning("Container " + container.ID + " was not removed from Docker instance.");
                    }
                }

                if (client != null)
                {
                    client.Dispose();
                    client = null;
                }
            }
        }
    }
}
