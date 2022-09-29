using System.Security.Cryptography;
using FluentAssertions;
using Flurl.Http;
using Microsoft.AspNetCore.Identity;
using SubtitleRed.Infrastructure.Identity.Signup;
using Tests.EnvironmentBuilder.Fixtures;
using Xunit;

namespace Tests.EnvironmentBuilder.Base;

public class IntegrationTestsBase : IClassFixture<IntegrationTestFixture>
{
    protected const string CreateUrl = "Create";
    protected const string GetUrl = "Get";
    protected const string UpdateUrl = "Update";
    protected const string Delete = "Delete";
    private const string SignupUrl = "Signup";

    protected IntegrationTestFixture TestFixture { get; }

    protected IntegrationTestsBase(IntegrationTestFixture testFixture)
    {
        TestFixture = testFixture;
    }

    protected async Task<string> GetAuthorizeToken()
    {
        var signupRequestDto = new SignupRequestDto
        {
            Email = $"random_{RandomNumberGenerator.GetInt32(100_000)}@mail.com",
            Password = "Test_Password_123",
            Login = $"random_{RandomNumberGenerator.GetInt32(100_000)}"
        };

        var reply = await SignupUrl.PostJsonAsync(signupRequestDto);

        var response = await reply.GetJsonAsync<SignupResponseDto>();
        var user = await TestFixture.GetService<UserManager<IdentityUser<Guid>>>().FindByEmailAsync(signupRequestDto.Email);

        response.Token.Should().NotBeNull();
        user.Email.Should().Be(signupRequestDto.Email);
        user.UserName.Should().Be(signupRequestDto.Login);

        return response.Token;
    }
}