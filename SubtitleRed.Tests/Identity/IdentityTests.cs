using Tests.EnvironmentBuilder.Base;
using Tests.EnvironmentBuilder.Fixtures;
using Tests.EnvironmentBuilder.TestCollections;
using Xunit;

namespace SubtitleRed.Tests.Identity;

[Collection(nameof(IntegrationTestCollection))]
public class IdentityTests : IntegrationTestsBase
{
    public IdentityTests(IntegrationTestFixture testFixture) : base(testFixture)
    {
    }

    [Fact]
    public void Test()
    {
        CreateDefaultTestUser();
    }
}