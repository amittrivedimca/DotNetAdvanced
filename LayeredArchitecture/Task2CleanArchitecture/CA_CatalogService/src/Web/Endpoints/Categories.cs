using CA_CatalogService.Application.Category.Queries.GetCategories;
using CA_CatalogService.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using CA_CatalogService.Application.TodoLists.Queries.GetTodos;

namespace CA_CatalogService.Web.Endpoints;

public class Categories : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetCategories)
            //.MapPost(CreateTodoList)
            //.MapPut(UpdateTodoList, "{id}")
            //.MapDelete(DeleteTodoList, "{id}")
            ;
    }

    public Task<IList<CategoryDTO>> GetCategories(ISender sender, [AsParameters] GetCategoriesQuery query)
    {
        return sender.Send(query);
    }
}
