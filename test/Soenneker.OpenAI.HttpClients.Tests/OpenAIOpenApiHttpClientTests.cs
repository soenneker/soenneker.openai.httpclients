using Soenneker.OpenAI.HttpClients.Abstract;
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
}
