using Soenneker.OpenAI.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.OpenAI.HttpClients.Tests;

[Collection("Collection")]
public sealed class OpenAIOpenApiHttpClientTests : FixturedUnitTest
{
    private readonly IOpenAIOpenApiHttpClient _httpclient;

    public OpenAIOpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<IOpenAIOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
