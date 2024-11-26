using CA_CatalogService.Application.Products.Commands.CreateProduct;
using CA_CatalogService.Application.Products.Commands.DeleteProduct;
using CA_CatalogService.Application.Products.Commands.UpdateProduct;
using CA_CatalogService.Application.Products.Queries.GetProducts;
using CA_CatalogService.Application.Products.Queries.ListProducts;

namespace CA_CatalogService.Web.Endpoints;

public class Products : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetProduct, "{id}")
            .MapGet(ListProducts)
            .MapPost(CreateProduct)
            .MapPut(UpdateProduct, "{id}")
            .MapDelete(DeleteProduct, "{id}");
    }
        
    public async Task<ProductDTO> GetProduct(ISender sender, [AsParameters] GetProductQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<IList<ProductShortInfoDTO>> ListProducts(ISender sender, [AsParameters] ListProductsQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<int> CreateProduct(ISender sender, CreateProductCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateProduct(ISender sender, int id, UpdateProductCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteProduct(ISender sender, int id)
    {
        await sender.Send(new DeleteProductCommand(id));
        return Results.NoContent();
    }
}
