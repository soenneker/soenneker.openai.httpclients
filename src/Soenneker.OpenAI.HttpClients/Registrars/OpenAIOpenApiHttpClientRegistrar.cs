using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.OpenAI.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.OpenAI.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class OpenAIOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="OpenAIOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddOpenAIOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IOpenAIOpenApiHttpClient, OpenAIOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="OpenAIOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddOpenAIOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IOpenAIOpenApiHttpClient, OpenAIOpenApiHttpClient>();

        return services;
    }
}
