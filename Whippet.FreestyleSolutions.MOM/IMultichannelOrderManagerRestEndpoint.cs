using System;
using Athi.Whippet.Data;
using Athi.Whippet.Net.Rest;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents a single instance of the Multichannel Order Manager e-commerce product that is locally or remotely hosted.
    /// </summary>
    public interface IMultichannelOrderManagerRestEndpoint : IWhippetAuditableEntity, IWhippetActiveEntity, IWhippetSoftDeleteEntity, IEqualityComparer<IMultichannelOrderManagerRestEndpoint>, IRestEndpoint, IMultichannelOrderManagerServer
    { }
}