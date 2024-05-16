using GlobalShopSolutions.Server.Tests.Integration.Fixtures;

namespace GlobalShopSolutions.Server.Tests.Integration.Modules;

[Collection(nameof(FixtureFactoryCollectionDefinition))]
public sealed class InventoryTests
{
    private readonly InventoryDsl _inventoryDsl;
    private readonly AccountsReceivableDsl _accountsReceivableDsl;

    public InventoryTests(FixtureFactoryLifetimeAdapter adapter)
    {
        _inventoryDsl = adapter.FixtureFactory.GetFixture<InventoryDsl>();
        _accountsReceivableDsl = adapter.FixtureFactory.GetFixture<AccountsReceivableDsl>();
    }
    
    [Fact]
    public async Task GetsIntegratedAccount()
    {
        await _accountsReceivableDsl.AddAccount();
        await _inventoryDsl.GetIntegratedAccount();
        
        _inventoryDsl.AssertAccountExists();
    }
}