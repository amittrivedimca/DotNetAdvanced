using CA_CatalogService.Application.Category.Commands.CreateCategory;
using CA_CatalogService.Application.Category.Commands.DeteteCategory;
using CA_CatalogService.Application.Category.Commands.UpdateCategory;
using CA_CatalogService.Application.Category.Queries.GetCategories;
using CA_CatalogService.Application.Products.Queries.GetProducts;
using CA_CatalogService.Application.Products.Queries.ListProducts;
using Microsoft.AspNetCore.Mvc;

namespace CA_CatalogService.Web.Endpoints;

public class Products : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetProduct, "{id}")
            .MapGet(ListProducts)
            //.MapPost(CreateCategory)
            //.MapPut(UpdateCategory, "{id}")
            //.MapDelete(DeleteCategory, "{id}")
            ;
    }
        
    public Task<ProductDTO> GetProduct(ISender sender, [AsParameters] GetProductQuery query)
    {
        return sender.Send(query);
    }

    public Task<IList<ProductShortInfoDTO>> ListProducts(ISender sender, [AsParameters] ListProductsQuery query)
    {
        return sender.Send(query);
    }    

    //public Task<int> CreateCategory(ISender sender, CreateCategoryCommand command)
    //{
    //    return sender.Send(command);
    //}

    //public async Task<IResult> UpdateCategory(ISender sender, int id, UpdateCategoryCommand command)
    //{
    //    if (id != command.Id) return Results.BadRequest();
    //    await sender.Send(command);
    //    return Results.NoContent();
    //}

    //public async Task<IResult> DeleteCategory(ISender sender, int id)
    //{
    //    await sender.Send(new DeleteCategoryCommand(id));
    //    return Results.NoContent();
    //}
}
