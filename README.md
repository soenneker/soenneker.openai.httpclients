[![](https://img.shields.io/nuget/v/soenneker.openai.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.openai.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.openai.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.openai.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.openai.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.openai.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.openai.httpclients/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.openai.httpclients/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.OpenAI.HttpClients

Provides a cached, bearer-authenticated `HttpClient` for the OpenAI API.

## Installation

```bash
dotnet add package Soenneker.OpenAI.HttpClients
```

## Configuration

```json
{
  "OpenAI": {
    "ApiKey": "your-api-key"
  }
}
```

`OpenAI:ClientBaseUrl` can override the default `https://api.openai.com/v1` endpoint. `OpenAI:AuthHeaderName` and `OpenAI:AuthHeaderValueTemplate` can override the default bearer header for a compatible endpoint.

## Usage

```csharp
using Soenneker.OpenAI.HttpClients.Abstract;
using Soenneker.OpenAI.HttpClients.Registrars;

services.AddOpenAIOpenApiHttpClientAsSingleton();

IOpenAIOpenApiHttpClient openAI = serviceProvider
    .GetRequiredService<IOpenAIOpenApiHttpClient>();

HttpClient client = await openAI.Get(cancellationToken);
```

Do not dispose the returned `HttpClient`; the registered provider owns it and removes it from the cache when disposed.
