namespace GlobalShopSolutions.Server.Spec.Fixtures;

[CollectionDefinition(nameof(FixtureFactoryCollectionDefinition))]
public sealed class FixtureFactoryCollectionDefinition : IClassFixture<FixtureFactoryLifetimeAdapter>;