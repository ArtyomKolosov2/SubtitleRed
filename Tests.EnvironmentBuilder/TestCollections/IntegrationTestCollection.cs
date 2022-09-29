using Tests.EnvironmentBuilder.Fixtures;
using Xunit;

namespace Tests.EnvironmentBuilder.TestCollections;

[CollectionDefinition(nameof(IntegrationTestCollection))]
public class IntegrationTestCollection : ICollectionFixture<IntegrationTestFixture>
{
}