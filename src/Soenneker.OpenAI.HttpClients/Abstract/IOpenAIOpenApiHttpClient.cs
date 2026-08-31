using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.OpenAI.HttpClients.Abstract;

/// <summary>
/// Provides a cached, authenticated HTTP client for the OpenAI API.
/// </summary>
public interface IOpenAIOpenApiHttpClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the configured OpenAI HTTP client.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The cached client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
