using System;
using RestSharp;

namespace Athi.Whippet.Net.Rest
{
    /// <summary>
    /// Client to translate <see cref="RestRequest"/> objects into HTTP requests and process response results.
    /// </summary>
    public interface IWhippetRestClient : IRestClient, IDisposable
    { }
}

