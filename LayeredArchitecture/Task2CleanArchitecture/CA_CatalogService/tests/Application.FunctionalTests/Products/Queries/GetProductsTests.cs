using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA_CatalogService.Application.Products.Commands.CreateProduct;
using CA_CatalogService.Application.Products.Queries.GetProducts;
using CA_CatalogService.Application.TodoLists.Queries.GetTodos;
using CA_CatalogService.Domain.Entities;
using CA_CatalogService.Domain.ValueObjects;
using static CA_CatalogService.Application.FunctionalTests.Testing;

namespace CA_CatalogService.Application.FunctionalTests.Products.Queries;
public class GetProductsTests : BaseTestFixture
{
    [Test]
    public async Task ShouldReturnProductById()
    {
        var createCommand = new CreateProductCommand
        {
            Name = "Product 12",
            CategoryId = -1
        };

        var id = await SendAsync(createCommand);

        var query = new GetProductQuery() { 
         Id = id
        };

        var result = await SendAsync<ProductDTO>(query);
        result.Should().NotBeNull();
        result.Id.Should().Be(id);
    }
}
