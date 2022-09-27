using Flurl.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using SubtitleRed.Infrastructure.DataAccess.Context;
using Tests.EnvironmentBuilder.ApplicationFactory;

namespace Tests.EnvironmentBuilder.Fixtures;

public class IntegrationTestFixture: IDisposable, IAsyncDisposable
{
    private readonly TestApplicationFactory<Program> _webApplicationFactory;
    private readonly HttpClient _httpClient;
    private readonly TestServer _server;
    public DatabaseContext DatabaseContext { get; init; }

    public IntegrationTestFixture()
    {
        _webApplicationFactory = new TestApplicationFactory<Program>();
        _httpClient = _webApplicationFactory.CreateDefaultClient();
        _server = _webApplicationFactory.Server;
        using var scope = _webApplicationFactory.Services.CreateScope();
        DatabaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>() ?? throw new ArgumentNullException();
        FlurlHttp.Configure(settings => { settings.FlurlClientFactory = new TestClientFactory(_httpClient); });
    }

    public async ValueTask DisposeAsync()
    {
        await DatabaseContext.DisposeAsync();
        await _webApplicationFactory.DisposeAsync();
        
        _httpClient.Dispose();
        _server.Dispose();
    }

    public async void Dispose() => await DisposeAsync();
}