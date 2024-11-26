using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA_CatalogService.Application.Category.Commands.CreateCategory;
using CA_CatalogService.Application.Category.Queries.GetCategories;
using CA_CatalogService.Application.Products.Commands.CreateProduct;
using CA_CatalogService.Application.Products.Queries.GetProducts;
using static CA_CatalogService.Application.FunctionalTests.Testing;

namespace CA_CatalogService.Application.FunctionalTests.Categories;
public class CreateCategoryTests : BaseTestFixture
{
    [Test]
    public async Task ShouldCreateCategory()
    {
        //var userId = await RunAsDefaultUserAsync();

        var createCommand = new CreateCategoryCommand
        {
            Name = "Test Category",
        };

        var id = await SendAsync(createCommand);
        id.Should().BeGreaterThan(0);

        var getCommand = new GetCategoriesQuery();

        IList<CategoryDTO> categories = await SendAsync<IList<CategoryDTO>>(getCommand);
        CategoryDTO category = categories.First(c => c.Id == id);
        category.Should().NotBeNull();
        category.Name.Should().Be("Test Category");
    }
}
