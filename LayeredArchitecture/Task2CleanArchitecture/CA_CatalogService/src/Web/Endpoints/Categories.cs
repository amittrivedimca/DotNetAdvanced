using CA_CatalogService.Application.Category.Commands.CreateCategory;
using CA_CatalogService.Application.Category.Commands.DeteteCategory;
using CA_CatalogService.Application.Category.Commands.UpdateCategory;
using CA_CatalogService.Application.Category.Queries.GetCategories;

namespace CA_CatalogService.Web.Endpoints;

public class Categories : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetCategories)
            .MapPost(CreateCategory)
            .MapPut(UpdateCategory, "{id}")
            .MapDelete(DeleteCategory, "{id}");
    }

    public async Task<IList<CategoryDTO>> GetCategories(ISender sender, [AsParameters] GetCategoriesQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<int> CreateCategory(ISender sender, CreateCategoryCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateCategory(ISender sender, int id, UpdateCategoryCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteCategory(ISender sender, int id)
    {
        await sender.Send(new DeleteCategoryCommand(id));
        return Results.NoContent();
    }
}
