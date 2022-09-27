using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;

namespace Tests.EnvironmentBuilder;

public class TestClientFactory : IFlurlClientFactory
{
    private readonly HttpClient _httpClient;

    public TestClientFactory(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public void Dispose() => _httpClient.Dispose();

    public IFlurlClient Get(Url url)
    {
        var flurlClient = new FlurlClient(httpClient: _httpClient);
        return flurlClient;
    }
}