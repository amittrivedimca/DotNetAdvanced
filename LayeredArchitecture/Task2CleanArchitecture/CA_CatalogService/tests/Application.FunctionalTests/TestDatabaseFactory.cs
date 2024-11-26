namespace CA_CatalogService.Application.FunctionalTests;

public static class TestDatabaseFactory
{
    public static async Task<ITestDatabase> CreateAsync()
    {
        var database = new SqlServerTestDatabase(); //new TestcontainersTestDatabase();

        await database.InitialiseAsync();

        return database;
    }
}
