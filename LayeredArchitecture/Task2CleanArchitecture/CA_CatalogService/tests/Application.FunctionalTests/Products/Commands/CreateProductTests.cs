using CA_CatalogService.Application.Products.Commands.CreateProduct;
using CA_CatalogService.Application.Products.Queries.GetProducts;
using static CA_CatalogService.Application.FunctionalTests.Testing;

namespace CA_CatalogService.Application.FunctionalTests.Products.Commands;
public class CreateProductTests : BaseTestFixture
{
    [Test]
    public async Task ShouldCreateProduct()
    {
        //var userId = await RunAsDefaultUserAsync();
        
        var createCommand = new CreateProductCommand
        {
            Name = "Product 12",
            CategoryId = -1
        };

        var id = await SendAsync(createCommand);
        id.Should().BeGreaterThan(0);

        var getCommand = new GetProductQuery
        {
            Id = id
        };

        ProductDTO prod = await SendAsync<ProductDTO>(getCommand);
        prod.Should().NotBeNull();
        prod.CategoryId.Should().Be(-1);
    }
}
