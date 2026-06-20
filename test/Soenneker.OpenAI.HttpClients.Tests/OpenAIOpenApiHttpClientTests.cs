using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.OpenAI.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.OpenAI.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class OpenAIOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IOpenAIOpenApiHttpClient _httpclient;

    public OpenAIOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IOpenAIOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }

    [Test]
    public async ValueTask Get_ShouldUseBearerAuthorizationByDefault()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["OpenAI:ApiKey"] = "test-key"
            })
            .Build();

        using var httpClientCache = new HttpClientCache();
        await using var httpClientUtil = new OpenAIOpenApiHttpClient(httpClientCache, configuration);

        System.Net.Http.HttpClient client = await httpClientUtil.Get(CancellationToken.None);

        client.DefaultRequestHeaders.TryGetValues("Authorization", out IEnumerable<string>? values);

        await Assert.That(values?.Single()).IsEqualTo("Bearer test-key");
    }
}
