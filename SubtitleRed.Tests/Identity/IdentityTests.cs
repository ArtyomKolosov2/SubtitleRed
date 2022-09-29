using System.Security.Cryptography;
using FluentAssertions;
using Flurl.Http;
using Microsoft.AspNetCore.Http;
using SubtitleRed.Infrastructure.Identity.Login;
using SubtitleRed.Infrastructure.Identity.Logout;
using SubtitleRed.Infrastructure.Identity.Signup;
using Tests.EnvironmentBuilder.Base;
using Tests.EnvironmentBuilder.Fixtures;
using Tests.EnvironmentBuilder.TestCollections;
using Xunit;

namespace SubtitleRed.Tests.Identity;

[Collection(nameof(IntegrationTestCollection))]
public class IdentityTests : IntegrationTestsBase
{
    private const string SignupUrl = "Signup";
    private const string LoginUrl = "Login";
    private const string LogoutUrl = "Logout";

    public IdentityTests(IntegrationTestFixture testFixture) : base(testFixture)
    {
    }

    [Fact]
    public async Task Signup_SendRequest_UserCreatedSuccessfullyAndTokenReceived() => await GetAuthorizeToken();

    [Fact]
    public async Task Login_UserIsCreatedAndLoginIsRequested_LoginSuccessful()
    {
        // Arrange
        var email = $"random_{RandomNumberGenerator.GetInt32(100_000)}@mail.com";
        var password = "Test_Password_123";

        var signupRequestDto = new SignupRequestDto
        {
            Email = email,
            Password = password,
            Login = $"random_{RandomNumberGenerator.GetInt32(100_000)}"
        };

        await SignupUrl.PostJsonAsync(signupRequestDto);

        var loginRequestDto = new LoginRequestDto
        {
            Email = email,
            Password = password,
        };

        // Act
        var response = await LoginUrl.PostJsonAsync(loginRequestDto);

        // Assert
        var loginResponseDto = await response.GetJsonAsync<LoginResponseDto>();
        loginResponseDto.Token.Should().NotBeNull();
    }

    [Fact]
    public async Task Login_UserIsNotCreated_LoginFailed()
    {
        // Arrange
        var email = $"random_{RandomNumberGenerator.GetInt32(100_000)}@mail.com";
        const string password = "Test_Password_123";

        var loginRequestDto = new LoginRequestDto
        {
            Email = email,
            Password = password,
        };

        // Act
        var response = await LoginUrl.AllowAnyHttpStatus().PostJsonAsync(loginRequestDto);

        // Assert
        response.StatusCode.Should().Be(StatusCodes.Status422UnprocessableEntity);
    }

    [Fact]
    public async Task Logout_UserIsCreatedAndLogoutIsDone_LogoutSuccessful()
    {
        // Arrange
        var token = await GetAuthorizeToken();

        // Act
        var response = await LogoutUrl.WithOAuthBearerToken(token).PostAsync();

        // Assert
        var logoutResponseDto = await response.GetJsonAsync<LogoutResponseDto>();

        logoutResponseDto.Message.Should().Be("Logout successful.");
        response.StatusCode.Should().Be(StatusCodes.Status200OK);
    }
}