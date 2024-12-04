using System.ComponentModel.DataAnnotations;
using CA_CatalogService.Application.Category.Commands.CreateCategory;
using CA_CatalogService.Application.Category.Commands.DeteteCategory;
using CA_CatalogService.Application.Category.Commands.UpdateCategory;
using CA_CatalogService.Application.Category.Queries.GetCategories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

    public async Task<IResult> CreateCategory(ISender sender, CreateCategoryCommand command)
    {
        bool isValid = isValidCommand(command);
        if (isValid)
        {
            var r = await sender.Send(command);
            return Results.Ok(r);
        }
        return Results.BadRequest();
    }

    public async Task<IResult> UpdateCategory(ISender sender, int id, UpdateCategoryCommand command)
    {
        bool isValid = isValidCommand(command);
        if (!isValid)
        {
            return Results.BadRequest();
        }

        if (id != command.Id) { 
            return Results.BadRequest(); 
        }
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteCategory(ISender sender, int id)
    {
        await sender.Send(new DeleteCategoryCommand(id));
        return Results.NoContent();
    }

    private bool isValidCommand(object command)
    {
        var context = new ValidationContext(command, serviceProvider: null, items: null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(command, context, results, true);
        return isValid;
    }
}
