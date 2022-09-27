using FluentAssertions;
using Flurl.Http;
using SubtitleRed.Infrastructure.Identity.Signup;
using Tests.EnvironmentBuilder.Fixtures;
using Xunit;

namespace Tests.EnvironmentBuilder.Base;

public class IntegrationTestsBase : IAsyncLifetime, IClassFixture<IntegrationTestFixture>
{
    protected const string TestEmail = "test1@mail.com";
    protected const string TestPassword = "123abcABC!";
    protected const string TestLogin = "Test";
    
    protected IntegrationTestFixture TestFixture { get; }

    protected IntegrationTestsBase(IntegrationTestFixture testFixture)
    {
        TestFixture = testFixture;
    }

    protected Task<SignupResponseDto> CreateDefaultTestUser() => CreateNewTestUser(TestEmail, TestPassword, TestLogin);

    protected async Task<SignupResponseDto> CreateDefaultTestUserWithValidReply()
    {
        var reply = await CreateDefaultTestUser();
        
        return reply;
    }

    private async Task<SignupResponseDto> CreateNewTestUser(string email, string password, string login)
    {
        var signupRequestDto = new SignupRequestDto
        {
            Email = email,
            Password = password,
            Login = login
        };
        
        var reply = await "Signup".PostJsonAsync(signupRequestDto);
        
        var response = await reply.GetJsonAsync<SignupResponseDto>();
        response.Token.Should().NotBeNull();
        return response;
    }

    #region TestSetup

    public Task InitializeAsync() => Task.CompletedTask;

    public Task DisposeAsync() => TestFixture.DatabaseContext.DisposeAsync().AsTask();

    #endregion
        
}